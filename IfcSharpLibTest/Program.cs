using IfcSharpLib;

namespace IfcSharpLibTest
{
    internal sealed partial class Program
    {
        static partial void Test(string[] args);

        static void Main(string[] args)
        {
            IfcSizeValidation.Test();

            ReflectionTest.Run(args.Contains("-v"));

            Test(args);
        }
    }
}
