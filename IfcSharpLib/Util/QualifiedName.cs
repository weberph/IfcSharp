using ifc.symbolic;
using ifc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace IfcSharpLib.Util
{
    public class QualifiedName
    {
        private static bool TryBuildFullyQualifiedName(Reader reader, DeclIndex declIndex, StringBuilder sb)
        {
            if (!declIndex.IsNull)
            {
                if (declIndex.Sort != DeclSort.Scope)
                {
                    return false;
                }

                ref readonly var scope = ref reader.Get<ScopeDecl, DeclSort>(declIndex);
                if (!TryBuildFullyQualifiedName(reader, scope.home_scope, sb))
                {
                    return false;
                }

                if (sb.Length != 0)
                {
                    sb.Append("::");
                }
                sb.Append(reader.GetString(scope.identity));
            }

            return true;
        }

        public static bool TryBuildFullyQualifiedName(Reader reader, DeclIndex declIndex, [NotNullWhen(true)] out string? fullyQualifiedName)
        {
            var sb = new StringBuilder();
            if (TryBuildFullyQualifiedName(reader, declIndex, sb))
            {
                fullyQualifiedName = sb.ToString();
            }
            else
            {
                fullyQualifiedName = null;
            }

            return fullyQualifiedName != null;
        }
    }
}
