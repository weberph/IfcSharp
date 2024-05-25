using IfcSharpLib;

namespace IfcSharpLibTest
{
    internal partial class Program
    {
        static partial void Test(string[] args);

        static void Main(string[] args)
        {
            IfcSizeValidation.Test();

            Test(args);
        }
    }
}
