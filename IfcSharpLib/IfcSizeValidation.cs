using System.Runtime.InteropServices;

namespace IfcSharpLib
{
    public sealed class IfcSelfTestException(string message) : Exception(message) { }

    public static partial class IfcSizeValidation
    {
        private static void AssertSize<T>(int expected)
        {
            var actual = Marshal.SizeOf<T>();
            if (actual != expected)
            {
                var msg = $"{typeof(T).Name} as unexpected size: {actual} instead of expected {expected}.";
                Console.WriteLine(msg);
                throw new IfcSelfTestException(msg);
            }
        }

        static partial void ExecuteTest();

        public static void Test() => ExecuteTest();
    }
}
