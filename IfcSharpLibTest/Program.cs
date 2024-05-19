using ifc.symbolic;
using IfcSharpLib;

namespace IfcSharpLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IfcSizeValidation.Test();
            IfcMeta.Init();

            var reader = new Reader(@"d:\.projects\.unsorted\2024\WrapAllInModuleTest\WrapAllInModuleTest\x64\Debug\Everything.ixx.ifc");

            var enums = reader.Partition<EnumerationDecl>();

            foreach (var e in enums)
            {
                if (e.identity.locus.column == 0 && e.identity.locus.line == 0)
                {
                    continue;
                }

                var name = reader.GetString(e.identity.name);
                Console.WriteLine(name);
            }
        }
    }
}
