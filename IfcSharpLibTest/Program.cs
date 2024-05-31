using IfcBuilderLib;
using IfcSharpLib;

namespace IfcSharpLibTest
{
    internal sealed partial class Program
    {
        static partial void Test(string[] args);

        static void Main(string[] args)
        {
            IfcSizeValidation.Test();

            //ReflectionTest.Run(@"IfcTestData\IfcHeaderUnit.ixx.ifc", args.Contains("-v"));

            BuildBoost();

            var ifcPaths = Directory.EnumerateFiles("IfcTestData", "*.ifc");

            foreach (var ifcPath in ifcPaths)
            {
                Console.Write($"Processing {Path.GetFileName(ifcPath)}... ");
                try
                {
                    ReflectionTest.Run(ifcPath, false);
                    Console.WriteLine("success");
                }
                catch (Exception e)
                {
                    Console.WriteLine("fail: " + e.Message);
                }
            }

            Test(args);
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
