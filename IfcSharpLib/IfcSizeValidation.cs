using System.Runtime.InteropServices;

namespace IfcSharpLib
{
    public static partial class IfcSizeValidation
    {
        private static void AssertSize<T>(int expected)
        {
            var actual = Marshal.SizeOf<T>();
            if (actual != expected)
            {
                var msg = $"{typeof(T).Name} as unexpected size: {actual} instead of expected {expected}.";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        static partial void ExecuteTest();

        public static void Test() => ExecuteTest();
    }
}
