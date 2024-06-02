using ifc;
using ifc.symbolic;
using IfcSharpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IfcSharpLibTest
{
    internal class VisitorGenerator
    {
        private readonly Type[] _indexTypes;
        private readonly Dictionary<SortType, Type> _indexTypeBySortType;
        private readonly Dictionary<(SortType, byte), Type> _targetTypeDict;

        public VisitorGenerator()
        {
            var allTypes = typeof(Reader).Assembly.GetTypes();

            var targetTypes = allTypes.Where(t => t.IsAssignableTo(typeof(ITag))).ToArray();

            _targetTypeDict = new Dictionary<(SortType, byte), Type>();
            foreach (var targetType in targetTypes.Where(t => !t.IsInterface))
            {
                if (targetType.Name is nameof(IntegerLiteral) or nameof(FloatingPointLiteral))
                {
                    // they don't have any fields. maybe emit the first parameter of constant_traits as a member (or inline) so that they can behave similar to other types?
                    continue;
                }

                var typeProp = targetType.GetProperty(nameof(ITag.Type), BindingFlags.Public | BindingFlags.Static);
                var sortProp = targetType.GetProperty(nameof(ITag.Sort), BindingFlags.Public | BindingFlags.Static);
                _targetTypeDict.Add(((SortType)typeProp?.GetValue(null)!, (byte)sortProp?.GetValue(null)!), targetType);
            }

            _indexTypes = allTypes.Where(t => t.IsAssignableTo(typeof(IOver)) && !t.Name.StartsWith(nameof(IOver))).ToArray();
            _indexTypeBySortType = _indexTypes.ToDictionary(
                it => (SortType)it.GetProperty(nameof(IOver.Type), BindingFlags.Public | BindingFlags.Static)!.GetValue(null)!,
                it => it);
        }

        public void GenerateVisitMethods()
        {
            //  private void VisitParameterDecl(DeclIndex index)
            //  {
            //      ref readonly var parameterDecl = ref _reader.Get<ParameterDecl>(index);
            //
            //      Visit(in parameterDecl);
            //
            //      AddChild(parameterDecl.type);
            //  }

            var sb = new StringBuilder();

            sb.AppendLine(
                """
                using ifc;
                using ifc.symbolic;
                using ifc.symbolic.microsoft;
                using ifc.symbolic.preprocessing;
                using ifc.symbolic.syntax;
                using ifc.symbolic.syntax.microsoft;

                using Attribute = ifc.symbolic.syntax.Attribute;
                using NoexceptSpecification = ifc.symbolic.syntax.NoexceptSpecification;
                using Tuple = ifc.symbolic.syntax.Tuple;

                namespace IfcSharpLibTest
                {
                    internal partial class TestVisitor
                    {
                """);

            var bySortType = _targetTypeDict.GroupBy(kvp => kvp.Key.Item1).OrderBy(g => g.Key);
            foreach (var group in bySortType)
            {
                var sortType = group.Key;
                //var indexType = indexTypeBySortType[sortType];
                if (!_indexTypeBySortType.TryGetValue(sortType, out var indexType))
                {
                    Console.WriteLine($"TODO: skipping SortType.{sortType}");
                    continue;
                }

                foreach (var (key, type) in group.OrderBy(kvp => kvp.Key.Item2))
                {
                    var sortEnumType = GetSortEnumType(type);
                    var localVariableName = char.ToLowerInvariant(type.Name[0]) + type.Name.Substring(1);

                    // TODO: get type size to determine whether "in" should be used
                    sb.Append(' ', 8).AppendLine($"partial void Visit(in {type.Name} {localVariableName});").AppendLine();

                    sb.AppendLine(
                        $$"""
                                private void Visit{{type.Name}}({{indexType.Name}} index)
                                {
                                    ref readonly var {{localVariableName}} = ref _reader.Get<{{type.Name}}>(index);

                                    Visit(in {{localVariableName}});
                        """);

                    var fields = type.GetFields();
                    bool first = true;
                    foreach (var field in fields.Reverse()) // push children in reverse so that the first child is popped back first
                    {
                        if (_indexTypes.Contains(field.FieldType))
                        {
                            if (first) sb.AppendLine();
                            first = false;

                            var fieldName = field.Name switch
                            {
                                var s when (s is "base" or "string") => '@' + s,
                                var s => s
                            };

                            sb.Append(' ', 12).AppendLine($"AddChild({localVariableName}.{fieldName});");
                        }
                    }

                    sb.Append(' ', 8).AppendLine("}").AppendLine();
                }
            }

            sb.AppendLine(
                """
                    }
                }
                """);

            File.WriteAllText(@"d:\.projects\.unsorted\2024\IfcSharp\IfcSharpLibTest\Visitor.Visit.Generated.cs", sb.ToString());
        }

        public void GenerateDispatchMethod()
        {
            var sb = new StringBuilder();

            sb.AppendLine(
                """
                using ifc;
                using ifc.symbolic;
                using IfcSharpLib;
                using System.Runtime.CompilerServices;

                namespace IfcSharpLibTest
                {
                    internal partial class TestVisitor
                    {
                        partial void Dispatch(ChildIndex childIndex)
                        {
                            switch (childIndex.Type)
                            {
                """);

            var indent = 16;
            var bySortType = _targetTypeDict.GroupBy(kvp => kvp.Key.Item1).OrderBy(g => g.Key);
            foreach (var group in bySortType)
            {
                var sortType = group.Key;
                //var indexType = indexTypeBySortType[sortType];
                if (!_indexTypeBySortType.TryGetValue(sortType, out var indexType))
                {
                    Console.WriteLine($"TODO: skipping SortType.{sortType}");
                    continue;
                }

                sb.Append(' ', indent);
                sb.AppendLine($"case SortType.{sortType}:"); // case SortType.Decl:

                sb.AppendLine(
                    $$"""
                                        {
                                            var index = childIndex.To<{{indexType.Name}}>();
                                            switch (index.Sort)
                                            {
                    """);

                foreach (var (key, type) in group.OrderBy(kvp => kvp.Key.Item2))
                {
                    var sortEnumType = GetSortEnumType(type);
                    var enumeratorName = Enum.GetName(sortEnumType, key.Item2);
                    sb.Append(' ', indent + 12).AppendLine($"case {sortEnumType.Name}.{enumeratorName}:"); // case DeclSort.Parameter:
                    sb.Append(' ', indent + 16).AppendLine($"Visit{type.Name}(index);"); // VisitParameterDecl(index);
                    sb.Append(' ', indent + 16).AppendLine($"break;");
                }

                sb.Append(' ', indent + 8).AppendLine("}");
                sb.Append(' ', indent + 4).AppendLine("}");
                sb.Append(' ', indent + 4).AppendLine("break;");
            }

            sb.AppendLine(
                """
                            }
                        }
                    }
                }
                """);

            File.WriteAllText(@"d:\.projects\.unsorted\2024\IfcSharp\IfcSharpLibTest\Visitor.Dispatch.Generated.cs", sb.ToString());

        }
        private static Type GetSortEnumType(Type type)
        {
            return type.GetInterfaces().First(i => i.Name.StartsWith("ITag")).GenericTypeArguments[1];
        }
    }
}
