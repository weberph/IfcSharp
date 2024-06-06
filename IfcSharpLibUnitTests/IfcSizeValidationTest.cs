using IfcSharpLib;
using System.Runtime.InteropServices;

namespace IfcSharpLibUnitTests
{
    public class IfcSizeValidationTest : IfcSizeValidation
    {
        [Fact]
        public void TestSizeOfStructs() => ExecuteTest();

        protected override void AssertSize<T>(int expected)
        {
            var actual = Marshal.SizeOf<T>();

            Assert.True(expected == actual, $"{typeof(T).Name} has unexpected size: {actual} instead of expected {expected}.");
        }
    }
}