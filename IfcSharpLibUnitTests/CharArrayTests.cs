using ifc;
using ifc.symbolic;
using IfcSharpLib;
using IfcSharpLibTest;
using System.Runtime.InteropServices;
using System.Text;

namespace IfcSharpLibUnitTests
{
    public class CharArray(Reader reader)
    {
        public string GetStringFromArrayDecl(ExprIndex arrayValueExprIndex)
        {
            var elements = reader.Sequence(reader.Get<TupleExpr>(reader.Get<ArrayValueExpr>(arrayValueExprIndex).elements));
            if (elements.Length == 0)
            {
                return string.Empty;
            }

            var type = reader.Get<FundamentalType>(reader.Get<QualifiedType>(reader.Get<LiteralExpr>(elements[0]).type).unqualified_type);
            var charWidth = (type.basis, type.precision) switch
            {
                (TypeBasis.Char, TypePrecision.Default or TypePrecision.Bit8) => 1,
                (TypeBasis.Char, TypePrecision.Short or TypePrecision.Bit16) => 2,
                (TypeBasis.Wchar_t, TypePrecision.Default or TypePrecision.Short or TypePrecision.Bit16) => 2,
                (TypeBasis.Char, TypePrecision.Long or TypePrecision.Bit32) => 4,
                _ => throw new NotSupportedException(),
            };

            if (charWidth == 1)
            {
                var buffer = new byte[elements.Length - 1];
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    reader.GetLiteral(reader.Get<LiteralExpr>(elements[i]).value, out var integer, out _);
                    buffer[i] = (byte)(integer & 0xFF);
                }

                return Encoding.UTF8.GetString(buffer);
            }

            if (charWidth == 2)
            {
                var buffer = new ushort[elements.Length - 1];
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    reader.GetLiteral(reader.Get<LiteralExpr>(elements[i]).value, out var integer, out _);
                    buffer[i] = (ushort)(integer & 0xFFFF);
                }

                return Encoding.Unicode.GetString(MemoryMarshal.Cast<ushort, byte>(buffer));
            }

            if (charWidth == 4)
            {
                var buffer = new uint[elements.Length - 1];
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    reader.GetLiteral(reader.Get<LiteralExpr>(elements[i]).value, out var integer, out _);
                    buffer[i] = (uint)(integer & 0xFFFFFFFF);
                }

                return Encoding.UTF32.GetString(MemoryMarshal.Cast<uint, byte>(buffer));
            }

            throw new NotSupportedException();
        }
    }

    public class CharArrayTests
    {
        private readonly Reader _reader;

        private readonly Dictionary<string, ExprIndex> _charArrays = [];

        public CharArrayTests()
        {
            _reader = new Reader(TestFileLocator.GetTestFilePath("CharArrayTests.ixx.ifc"));

            var decls = _reader.Partition<VariableDecl>();
            foreach (ref readonly var decl in decls)
            {
                var name = _reader.GetString(decl.identity);
                if (name.Contains("UmlautsHex"))
                {
                    _charArrays.Add(name, decl.initializer);
                }
            }
        }

        private string TestGetStringFromArrayDecl(ExprIndex arrayValueExprIndex) => new CharArray(_reader).GetStringFromArrayDecl(arrayValueExprIndex);

        [Fact]
        public void TestCharArray() => Assert.Equal("äöü", TestGetStringFromArrayDecl(_charArrays["LiteralWithUmlautsHex"]));

        [Fact]
        public void TestU8CharArray() => Assert.Equal("äöü", TestGetStringFromArrayDecl(_charArrays["U8LiteralWithUmlautsHex"]));

        [Fact]
        public void TestU16CharArray() => Assert.Equal("äöü", TestGetStringFromArrayDecl(_charArrays["U16LiteralWithUmlautsHex"]));

        [Fact]
        public void TestU32CharArray() => Assert.Equal("äöü", TestGetStringFromArrayDecl(_charArrays["U16LiteralWithUmlautsHex"]));

        [Fact]
        public void TestWideCharArray() => Assert.Equal("äöü", TestGetStringFromArrayDecl(_charArrays["WideLiteralWithUmlautsHex"]));
    }
}
