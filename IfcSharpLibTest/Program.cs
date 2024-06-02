using ifc;
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
            IfcSizeValidation.Test();

            // GenerateTestVisitorCode();

            // BuildBoost();

            // TestVisitor(new Reader(@"IfcTestData\IfcHeaderUnit.ixx.ifc"));

            // ExecuteForEachTestFile(r => ReflectionTest.Run(r, false));

            ExecuteForEachTestFile(TestVisitor);
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
