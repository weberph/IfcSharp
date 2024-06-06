using ifc;
using ifc.symbolic;
using IfcBuilderLib;
using IfcSharpLib;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IfcSharpLibTest
{
    internal sealed class Program
    {
        static void Main()
        {
            new IfcSizeValidationSelfTest().ExecuteTest();

            PrintEnumsExample();

            // GenerateTestVisitorCode();

            // BuildBoost();

            // TestVisitor(new Reader(@"IfcTestData\IfcHeaderUnit.ixx.ifc"));

            // ExecuteForEachTestFile(r => ReflectionTest.Run(r, false));

            // ExecuteForEachTestFile(TestVisitor);
        }

        private static void PrintEnumsExample()
        {
            // see IfcTestData project; the ixx file is compiled with /exportHeader
            var reader = new Reader(@"IfcTestData\IfcHeaderUnit.ixx.ifc");

            // step 1: search for the namespace of interest ("ifc") and get its index

            DeclIndex ifcNamespace = default;
            foreach (ref readonly var scopeDecl in reader.Partition<ScopeDecl>())
            {
                if (scopeDecl.home_scope.IsNull // search top level declarations
                    && reader.Get<FundamentalType>(scopeDecl.type).basis == TypeBasis.Namespace
                    && reader.GetString(scopeDecl.identity) == "ifc")
                {
                    reader.IndexOf(scopeDecl, out ifcNamespace);
                }
            }

            // step 2: find and print all enums in that namespace

            foreach (ref readonly var enumerationDecl in reader.Partition<EnumerationDecl>())
            {
                if (enumerationDecl.home_scope != ifcNamespace)
                {
                    continue;
                }

                // check if this is an enum class. see specification @ https://github.com/microsoft/ifc-spec
                // "TypeBasis::Class or TypeBasis::Struct meaning a scoped enumeration"
                bool enumClass = reader.Get<FundamentalType>(enumerationDecl.type).basis is TypeBasis.Class or TypeBasis.Struct;

                Console.WriteLine($"{(enumClass ? "enum class" : "enum")} {reader.GetString(enumerationDecl.identity)}");

                // "The initializer is a slice of the enumerator partition. It designates the sequence of enumerators (...)"
                foreach (ref readonly var enumeratorDecl in reader.Sequence(enumerationDecl.initializer))
                {
                    // get the value of the enum member
                    var literalExpr = reader.Get<LiteralExpr>(enumeratorDecl.initializer);
                    var literalSort = reader.GetLiteral(literalExpr.value, out ulong value, out _);

                    Debug.Assert(literalSort is LiteralSort.Integer or LiteralSort.Immediate);

                    Console.WriteLine($"  {reader.GetString(enumeratorDecl.identity)} = {value}");
                }
            }
        }

        private static void GenerateTestVisitorCode()
        {
            static string GetSourceFileDirectory([CallerFilePath] string? path = null)
                => Path.GetDirectoryName(path) ?? throw new NotSupportedException("Failed to get source location");

            var outputDirectory = GetSourceFileDirectory();
            var generator = new VisitorGenerator();
            generator.GenerateVisitMethods(Path.Combine(outputDirectory, "Visitor.Visit.Generated.cs"));
            generator.GenerateDispatchMethod(Path.Combine(outputDirectory, "Visitor.Dispatch.Generated.cs"));
        }

        private static void ExecuteForEachTestFile(Action<Reader> action)
        {
            var ifcPaths = Directory.EnumerateFiles("IfcTestData", "*.ifc");

            foreach (var ifcPath in ifcPaths)
            {
                var sw = Stopwatch.StartNew();
                var reader = new Reader(ifcPath);
                sw.Stop();

                Console.Write($"Processing {Path.GetFileName(ifcPath)} (reader creation time: {sw.ElapsedMilliseconds})... ");
                try
                {
                    sw.Restart();
                    action(reader);
                    sw.Stop();
                    Console.WriteLine($"success after {sw.ElapsedMilliseconds} ms");
                }
                catch (Exception e)
                {
                    sw.Stop();
                    Console.WriteLine($"fail after {sw.ElapsedMilliseconds} ms: {e.Message}");
                }
            }
        }

        private static void TestVisitor(Reader reader)
        {
            var visitor = new TestVisitor(reader);

            static ReadOnlySpan<PartitionSummaryData> GetSummaries<T>(Reader reader)
                where T : struct, IOver<T>
            {
                if (!PartitionTypes.TryGetPartitionType(T.Type, out var partitionType))
                {
                    throw new ArgumentOutOfRangeException(nameof(T), "No partition found for " + T.Type);
                }

                return reader.PartitionSummaries(partitionType);
            }

            static void VisitSort<TIndex, TSort>(Reader reader, TestVisitor visitor)
                where TIndex : struct, IOver<TIndex, TSort>
                where TSort : unmanaged, Enum
            {
                var summaries = GetSummaries<TIndex>(reader);
                Debug.Assert(summaries.Length == Enum.GetValues<TSort>().Length - 1);

                for (int i = 0; i < summaries.Length; i++)
                {
                    var indexCount = (int)summaries[i].cardinality;
                    for (int j = 0; j < indexCount; j++)
                    {
                        var index = TIndex.Create(Unsafe.BitCast<byte, TSort>((byte)i), (ifc.Index)j);
                        visitor.Start(index);
                    }
                }
            }

            VisitSort<TypeIndex, TypeSort>(reader, visitor);
            VisitSort<DeclIndex, DeclSort>(reader, visitor);
            VisitSort<SyntaxIndex, SyntaxSort>(reader, visitor);
            VisitSort<StmtIndex, StmtSort>(reader, visitor);
            VisitSort<ExprIndex, ExprSort>(reader, visitor);
            VisitSort<PragmaIndex, PragmaSort>(reader, visitor);
            VisitSort<MacroIndex, MacroSort>(reader, visitor);
            VisitSort<AttrIndex, AttrSort>(reader, visitor);
            VisitSort<DirIndex, DirSort>(reader, visitor);
            VisitSort<FormIndex, FormSort>(reader, visitor);
        }

        private static void BuildBoost()
        {
            string[] additionalOptions = ["/DWIN32_LEAN_AND_MEAN"];
            string[] includeDirs = [@"d:\workspace\.source\boost_1_85_0\"];

            var devEnv = new DeveloperEnvironment();
            devEnv.ActivateDeveloperEnvironmentAsync(@"c:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat").Wait();

            var boostDir = @"d:\workspace\.source\boost_1_85_0\boost\";
            var files = Directory.EnumerateFiles(boostDir, "*.hpp").ToArray();

            var consoleLock = new object();
            var successCount = 0;
            Parallel.ForEach(files, (f, t) =>
            {
                var name = Path.GetFileName(f);
                var output = Path.Combine(Directory.GetCurrentDirectory(), "IfcTestData", name + ".ifc");
                File.Delete(output);

                var (stdout, stderr, exitCode) = devEnv.CreateIfcAsync(f, includeDirs, output, additionalOptions).Result;
                lock (consoleLock)
                {
                    if (exitCode != 0)
                    {
                        Console.WriteLine($"{name} failed: " + stdout + "\n" + stderr);
                        Console.WriteLine();
                    }
                    else
                    {
                        ++successCount;
                    }
                }
            });

            Console.WriteLine($"Built {successCount} / {files.Length} successfully. {files.Length - successCount} failed.");
        }
    }
}
