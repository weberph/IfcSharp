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

            //BuildBoost();

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
            var files = Directory.EnumerateFiles(boostDir, "*.hpp");
            var tasks = new List<(string, Task)>();
            foreach (var file in files)
            {
                var name = Path.GetFileName(file);
                var output = Path.Combine(Directory.GetCurrentDirectory(), "IfcTestData", name + ".ifc");
                tasks.Add((name, devEnv.CreateIfcAsync(file, includeDirs, output, additionalOptions)));
            }

            Task.WhenAll(tasks.Select(t => t.Item2).ToArray());

            foreach (var (file, task) in tasks)
            {
                Console.WriteLine($"{file}: {(task.IsCompletedSuccessfully ? "success" : "fail")}");
            }
        }
    }
}
