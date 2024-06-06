using System.Runtime.InteropServices;

namespace IfcSharpLib
{
    public sealed class IfcSelfTestException(string message) : Exception(message) { }

    public class IfcSizeValidationSelfTest : IfcSizeValidation
    {
        protected override void AssertSize<T>(int expected)
        {
            var actual = Marshal.SizeOf<T>();
            if (actual != expected)
            {
                var msg = $"{typeof(T).Name} has unexpected size: {actual} instead of expected {expected}.";
                throw new IfcSelfTestException(msg);
            }
        }
    }
}
