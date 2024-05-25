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

            var reader = new Reader(@"d:\.projects\.unsorted\2024\IfcSharp\CppEnumApp\bin\x64\Debug\net8.0-windows\current.ifc");

            var enums = reader.Partition<EnumerationDecl>();

            for (int i = 0; i < enums.Length; i++)
            {
                var current = enums[i];
                var name = reader.GetString(current.identity);
                if (name.StartsWith('<') || current.type.Sort != TypeSort.Fundamental)
                {
                    continue;
                }

                if (!QualifiedName.TryBuildFullyQualifiedName(reader, current.home_scope, out var @namespace))
                {
                    continue;
                }

                if (reader.Get<FundamentalType>(current.type).basis is TypeBasis.Class or TypeBasis.Struct)
                {
                    Console.WriteLine("enum class: ");
                }

                if (name == "_TaskInliningMode") Debugger.Break();
                if (name == "_Invoker_strategy") Debugger.Break();

                var initializers = reader.Sequence(current.initializer);
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
