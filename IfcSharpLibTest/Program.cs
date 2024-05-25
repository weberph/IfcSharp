using IfcSharpLib;

namespace IfcSharpLibTest
{
    internal sealed partial class Program
    {
        static partial void Test(string[] args);

        static void Main(string[] args)
        {
            IfcSizeValidation.Test();

            Test(args);
        }
    }
}
