using ifc;
using IfcSharpLib;
using System.Reflection;
using System.Collections.Frozen;
using ifc.symbolic;
using ifc.symbolic.trait;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ifc.source;

namespace IfcSharpLibTest
{
    internal sealed class InvalidSortTypeException(string message) : Exception(message) { }

    internal sealed class ReflectionVisitor(Reader reader, bool verbose)
    {
        private static readonly FrozenDictionary<(SortType, byte), Type> TypesBySort;
        private static readonly FrozenDictionary<Type, SortType> SortByIndexType;
        private static readonly FrozenDictionary<Type, Func<Reader, object, Array>> SequenceTypes;
        private static readonly MethodInfo GetGeneric;
        private static readonly MethodInfo SequenceAsArray;
        private static readonly MethodInfo ISequenceAsArray;
        private static readonly MethodInfo ITaggedSequenceAsArray;
        private static readonly MethodInfo InlineArrayAsArray;

        private readonly HashSet<uint>[] _visitedTypes = new HashSet<uint>[(int)SortType.Count];
        private readonly Queue<object> _delayedTypes = [];

        private const int RecursionLimit = 50;

        static ReflectionVisitor()
        {
            var allTypes = typeof(Reader).Assembly.GetTypes();

            var targetTypes = allTypes.Where(t => t.IsAssignableTo(typeof(ITag))).ToArray();

            var targetTypeDict = new Dictionary<(SortType, byte), Type>();
            foreach (var targetType in targetTypes.Where(t => !t.IsInterface))
            {
                var typeProp = targetType.GetProperty(nameof(ITag.Type), BindingFlags.Public | BindingFlags.Static);
                var sortProp = targetType.GetProperty(nameof(ITag.Sort), BindingFlags.Public | BindingFlags.Static);
                targetTypeDict.Add(((SortType)typeProp?.GetValue(null)!, (byte)sortProp?.GetValue(null)!), targetType);
            }

            TypesBySort = targetTypeDict.ToFrozenDictionary();

            var sequenceAsArrayMethods = typeof(Reader).GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name == nameof(Reader.SequenceAsArray)).ToArray();
            SequenceAsArray = sequenceAsArrayMethods.Single(m => m.GetParameters().First().ParameterType.Name.StartsWith("Sequence"));
            ISequenceAsArray = sequenceAsArrayMethods.Single(m => m.GetParameters().First().ParameterType.Name.StartsWith("ISequence"));
            ITaggedSequenceAsArray = sequenceAsArrayMethods.Single(m => m.GetParameters().First().ParameterType.Name.StartsWith("ITaggedSequence"));

            var interfaceMap = allTypes.ToDictionary(t => t, t => t.GetInterfaces());
            var sequenceTypes = new Dictionary<Type, Func<Reader, object, Array>>();
            foreach (var (type, interfaces) in interfaceMap.Where(kvp => !kvp.Key.IsInterface))
            {
                if (interfaces.FirstOrDefault(i => i.Name.StartsWith("ITaggedSequence")) is { } iTaggedSequence)
                {
                    var asArray = ITaggedSequenceAsArray.MakeGenericMethod(iTaggedSequence.GenericTypeArguments);
                    sequenceTypes.Add(type, (reader, obj) => (Array)asArray.Invoke(reader, [obj])!);
                }
                else if (interfaces.FirstOrDefault(i => i.Name.StartsWith("ISequence")) is { } iSequence)
                {
                    if (iSequence.GenericTypeArguments[0].IsAssignableTo(typeof(ITag)))
                    {
                        var asArray = ISequenceAsArray.MakeGenericMethod(iSequence.GenericTypeArguments);
                        sequenceTypes.Add(type, (reader, obj) => (Array)asArray.Invoke(reader, [obj])!);
                    }
                }
            }
            SequenceTypes = sequenceTypes.ToFrozenDictionary();

            var indexTypes = allTypes.Where(t => t.IsAssignableTo(typeof(IOver)) && !t.Name.StartsWith(nameof(IOver))).ToArray();
            SortByIndexType = indexTypes.ToDictionary(
                it => it,
                it => (SortType)it.GetProperty(nameof(IOver.Type), BindingFlags.Public | BindingFlags.Static)!.GetValue(null)!).ToFrozenDictionary();

            GetGeneric = typeof(Reader).GetMethod(nameof(Reader.GetGeneric))!;

            InlineArrayAsArray = typeof(ReflectionVisitor).GetMethod(nameof(GetInlineArrayAsArray), BindingFlags.NonPublic | BindingFlags.Static)!;
        }

        public void Visit(object obj, bool reset = true)
        {
            for (int i = 0; i < _visitedTypes.Length; i++)
            {
                _visitedTypes[i] ??= [];
                if (reset)
                {
                    _visitedTypes[i].Clear();
                }
            }

            _delayedTypes.Clear();

            Visit(obj, 0);

            while (_delayedTypes.TryDequeue(out var delayed))
            {
                if (verbose)
                {
                    Console.WriteLine("Continuation of recursion");
                }
                Visit(delayed, 0);
            }
        }

        private void Visit(object obj, int level)
        {
            if (level > RecursionLimit)
            {
                if (verbose)
                {
                    Console.WriteLine($"Recursion limit reached");
                }

                _delayedTypes.Enqueue(obj);
                return;
            }

            var type = obj.GetType();
            var fields = type.GetFields();

            var identity = fields.FirstOrDefault(f => f.Name == "identity") switch
            {
                FieldInfo fi when (fi.FieldType == typeof(Identity<NameIndex>)) => reader.GetString((Identity<NameIndex>)fi.GetValue(obj)!),
                FieldInfo fi when (fi.FieldType == typeof(Identity<TextOffset>)) => reader.GetString((Identity<TextOffset>)fi.GetValue(obj)!),
                _ => "<no name>"
            };

            var indent = new string(' ', level * 2);

            if (verbose)
            {
                Console.WriteLine($"{indent}Visiting {type.Name} '{identity}'");
            }

            var skipSequenceFields = false;
            if (SequenceTypes.TryGetValue(type, out var asArray))
            {
                var array = asArray(reader, obj);
                foreach (var element in array)
                {
                    Visit(element, level + 1);
                }

                skipSequenceFields = true;
            }
            else if (SortByIndexType.TryGetValue(type, out var sortType))
            {
                VisitIndex(indent, level, sortType, (IOver)obj);
            }

            foreach (var field in fields)
            {
                if (skipSequenceFields && field.Name is "start" or "cardinality")
                {
                    continue;
                }

                var fieldType = field.FieldType;
                if (SortByIndexType.TryGetValue(fieldType, out var sortType))
                {
                    if (verbose)
                    {
                        Console.WriteLine($"{indent} found index {fieldType.Name} in member {field.Name} with SortType {sortType}");
                    }

                    if (field.GetValue(obj) is IOver index && !index.IsNull)
                    {
                        VisitIndex(indent, level, sortType, index);
                    }
                }
                else if (field.FieldType.IsGenericType && field.FieldType.Name.StartsWith("Sequence"))
                {
                    var sequenceType = field.FieldType.GenericTypeArguments[0];
                    if (sequenceType.IsAssignableTo(typeof(ITag)))
                    {
                        var array = (Array)SequenceAsArray.MakeGenericMethod(sequenceType).Invoke(reader, [field.GetValue(obj)])!;
                        foreach (var element in array)
                        {
                            Visit(element, level + 1);
                        }
                    }
                }
                else if (fieldType.IsEnum)
                {
                    var fieldTypeName = fieldType.Name;
                    var value = field.GetValue(obj)!;

                    if (fieldTypeName is nameof(DefaultIndex) or nameof(LineNumber) || Enum.GetValues(fieldType).Length == 0)
                    {
                        var valueStr = value.ToString()!;
                        if (verbose)
                        {
                            Console.WriteLine($"{indent}  {fieldTypeName}: {valueStr}");
                        }
                    }
                    else
                    {
                        var valueStr = Enum.GetName(fieldType, value);
                        if (valueStr == null)
                        {
                            Debug.Assert(fieldType.GetCustomAttribute<FlagsAttribute>() != null, "Possibly missing [Flags] attribute - investigate");
                            valueStr = value.ToString()!.Replace(", ", " | ");
                        }

                        if (verbose)
                        {
                            Console.WriteLine($"{indent}  {fieldTypeName}.{valueStr}");
                        }
                    }
                }
                else if (fieldType.IsPrimitive)
                {
                    if (verbose)
                    {
                        Console.WriteLine($"{indent}  {field.GetValue(obj)}");
                    }
                }
                else if (fieldType.Name == nameof(SourceLocation))
                {
                    var sourceLocation = (SourceLocation)field.GetValue(obj)!;
                    if (sourceLocation.column != ColumnNumber.Invalid && sourceLocation.line != 0)
                    {
                        var fileAndLine = reader.Get(sourceLocation.line);
                        Debug.Assert(!fileAndLine.file.IsNull);
                        Debug.Assert(fileAndLine.line != 0);
                        Debug.Assert(fileAndLine.line <= LineNumber.Max);
                        var fileName = reader.GetString(fileAndLine.file);
                        if (verbose)
                        {
                            Console.WriteLine($"{indent}  {fileName}:{fileAndLine.line},{sourceLocation.column}");
                        }
                    }
                }
                else if (fieldType.Name == nameof(Word))
                {
                    var word = (Word)field.GetValue(obj)!;
                    var str = word.algebra_sort switch
                    {
                        WordSort.Unknown => word.category.ToString(),
                        WordSort.Directive => word.src_directive.ToString(),
                        WordSort.Punctuator => word.src_punctuator.ToString(),
                        WordSort.Literal => word.src_literal.ToString(),
                        WordSort.Operator => word.src_operator.ToString(),
                        WordSort.Keyword => word.src_keyword.ToString(),
                        WordSort.Identifier => word.src_identifier.ToString(),
                        _ => throw new InvalidSortTypeException("Invalid WordSort")
                    };

                    if (verbose)
                    {
                        Console.WriteLine($"{indent}  {word.algebra_sort}: {str}");
                    }
                }
                else if (fieldType.Name is nameof(Template))
                {
                    Visit(field.GetValue(obj)!, level); // same level
                }
                else if (fieldType.Name is nameof(NoexceptSpecification) or nameof(ParameterizedEntity) or nameof(MappingDefinition)
                    or nameof(MsvcFileBoundaryProperties) or nameof(MsvcFileHashData) or nameof(MsvcLabelProperties))
                {
                    Visit(field.GetValue(obj)!, level + 1);
                }
                else if (fieldType.FullName == typeof(ifc.Operator).FullName)
                {
                    var op = (ifc.Operator)field.GetValue(obj)!;
                    var tag = (OperatorSort)op.tag;
                    var valueName = tag switch
                    {
                        OperatorSort.Niladic => Enum.GetName((NiladicOperator)op.value),
                        OperatorSort.Monadic => Enum.GetName((MonadicOperator)op.value),
                        OperatorSort.Dyadic => Enum.GetName((DyadicOperator)op.value),
                        OperatorSort.Triadic => Enum.GetName((TriadicOperator)op.value),
                        OperatorSort.Storage => Enum.GetName((StorageOperator)op.value),
                        OperatorSort.Variadic => Enum.GetName((VariadicOperator)op.value),
                        _ => throw new InvalidSortTypeException("Invalid OperatorSort")
                    };

                    if (verbose)
                    {
                        Console.WriteLine($"{indent}  {tag}: {valueName}");
                    }
                }
                else if (fieldType.Name == nameof(PPOperator))
                {
                    var op = (PPOperator)field.GetValue(obj)!;
                    var tag = (WordSort)op.tag;
                    var str = tag switch
                    {
                        WordSort.Punctuator => Enum.GetName((Punctuator)op.value),
                        WordSort.Operator => Enum.GetName((ifc.source.Operator)op.value),
                        _ => throw new InvalidSortTypeException("Invalid PPOperator WordSort") // see concept PPOperatorCategory
                    };

                    if (verbose)
                    {
                        Console.WriteLine($"{indent} {tag}: {str}");
                    }
                }
                else if (fieldType.GetCustomAttribute<InlineArrayAttribute>() is { } inlineAttribute)
                {
                    var inlineArray = field.GetValue(obj)!;
                    var inlineArrayType = inlineArray.GetType();
                    var elementType = inlineArrayType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single().FieldType;
                    var inlineArrayAsArray = InlineArrayAsArray.MakeGenericMethod(inlineArrayType, elementType);

                    // handle byte explicitly?

                    var array = (Array)inlineArrayAsArray.Invoke(null, [inlineArray, inlineAttribute.Length])!;
                    foreach (var element in array)
                    {
                        Visit(element, level + 1);
                    }
                }
                else
                {
                    if (field.Name is not ("identity" or "unused"))
                    {
                        Console.WriteLine("Ignoring field " + field.Name);
                        Debug.Assert(false);
                    }
                }
            }
        }

        private void VisitIndex(string indent, int level, SortType sortType, IOver index)
        {
            if (sortType is SortType.Name)
            {
                var name = reader.GetString((NameIndex)index);
                if (verbose)
                {
                    Console.WriteLine($"{indent}  Name: " + name);
                }

                return;
            }

            if (sortType == SortType.String)
            {
                var literal = reader.GetString((StringIndex)index);
                if (verbose)
                {
                    Console.WriteLine($"{indent}  Literal: " + literal);
                }

                return;
            }

            if (sortType == SortType.Literal)
            {
                var literal = reader.GetLiteral((LitIndex)index, out var integer, out var fp) switch
                {
                    LiteralSort.FloatingPoint => fp.ToString(),
                    _ => integer.ToString(),
                };

                if (verbose)
                {
                    Console.WriteLine($"{indent}  Literal: " + literal);
                }

                return;
            }

            if (_visitedTypes[(int)sortType].Add((uint)index.GetHashCode()))
            {
                if (verbose)
                {
                    Console.WriteLine($"{indent}  Reference: {sortType}_{index.GetHashCode()}");
                }

                if (index.UntypedSort == 0)
                {
                    if (verbose)
                    {
                        Console.WriteLine("Skipping VendorExtension?");
                    }
                }
                else
                {
                    var ioverType = index.GetType();
                    var ioverTypeArg = ioverType.GetInterfaces().First().GenericTypeArguments[1];

                    var targetType = TypesBySort[(sortType, index.UntypedSort)];

                    var newObj = GetGeneric.MakeGenericMethod(targetType, ioverTypeArg, ioverType).Invoke(reader, [index])!;
                    Visit(newObj, level + 1);
                }
            }
            else
            {
                if (verbose)
                {
                    Console.WriteLine($"{indent}  See Reference: {sortType}_{index.GetHashCode()}");
                }
            }
        }

        private static TElement[] GetInlineArrayAsArray<TBuffer, TElement>(in TBuffer buffer, int length)
        {
            var span = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<TBuffer, TElement>(ref Unsafe.AsRef(in buffer)), length);
            return [.. span];
        }
    }

    internal sealed class ReflectionTest
    {
        static void TestVisitAllFriends(Reader reader)
        {
            var friends = reader.Partition<Friends>();
            foreach (var friend in friends)
            {
                var decls = reader.Declarations(friend.trait);
                Debug.Assert(decls.Length > 0);
            }
        }

        static void TestVisitAllSpecializations(Reader reader)
        {
            var specializations = reader.Partition<Specializations>();
            foreach (var specialization in specializations)
            {
                var decls = reader.Declarations(specialization.trait);
                Debug.Assert(decls.Length > 0);
            }
        }

        public static void Run(string ifcPath, bool verbose)
        {
            var reader = new Reader(ifcPath);
            Run(reader, verbose);
        }

        public static void Run(Reader reader, bool verbose)
        {
            TestVisitAllFriends(reader);
            TestVisitAllSpecializations(reader);

            var visitor = new ReflectionVisitor(reader, verbose);

            var allTypes = typeof(Reader).Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ITag)) && !t.Name.StartsWith(nameof(ITag))).ToArray();

            var getPartition = typeof(Reader).GetMethod(nameof(Reader.PartitionAsArray), [])!;

            foreach (var type in allTypes)
            {
                if (type.Name.StartsWith(nameof(ITag)) || type.Name.StartsWith(nameof(ITraitTag)))
                {
                    continue;
                }

                if (type.Name is nameof(IntegerLiteral) or nameof(FloatingPointLiteral))
                {
                    // they don't have any fields. maybe emit the first parameter of constant_traits as a member (or inline) so that they can behave similar to other types?
                    continue;
                }

                if (type.Name is nameof(Friends) or nameof(Specializations))
                {
                    continue; // explicitly tested separately
                }

                var typeProp = type.GetProperty(nameof(ITag.Type), BindingFlags.Public | BindingFlags.Static)!;

                var sortType = (SortType)typeProp.GetValue(null)!;
                if (sortType != SortType.Name)
                {
                    var array = (Array)getPartition.MakeGenericMethod(type).Invoke(reader, [])!;

                    foreach (var element in array)
                    {
                        visitor.Visit(element, false);
                    }
                }
            }
        }
    }
}
