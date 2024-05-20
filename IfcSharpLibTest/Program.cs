using ifc;
using ifc.symbolic;
using IfcSharpLib;
using IfcSharpLib.Util;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

namespace IfcSharpLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IfcSizeValidation.Test();
            IfcMeta.Init();

            var reader = new Reader(@"d:\.projects\.unsorted\2024\IfcSharp\IfcTestData\x64\Debug\IfcHeaderUnit.ixx.ifc");

            var enums = reader.Partition<EnumerationDecl>();

            for (int i = 0; i < enums.Length; i++)
            {
                var name = reader.GetString(enums[i].identity);
                if (name.StartsWith('<'))
                {
                    continue;
                }

                if (!QualifiedName.TryBuildFullyQualifiedName(reader, enums[i].home_scope, out var @namespace))
                {
                    continue;
                }

                var initializers = reader.Sequence(enums[i].initializer);
                var members = new string[initializers.Length];
                for (int j = 0; j < initializers.Length; j++)
                {
                    members[j] = reader.GetString(initializers[j].identity);
                    Console.WriteLine(members[j]);
                }

                Console.WriteLine($"  @ {@namespace}, Members: " + members.Length);
            }
        }
    }
}
