namespace CppEnumStringGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ifc = new Ifc(@"d:\.projects\.unsorted\2024\WrapAllInModuleTest\WrapAllInModuleTest\x64\Debug\Everything.ixx.ifc");
            var enums = ifc.GetEnums();
            foreach (var e in enums)
            {
                Console.WriteLine($"{e.Name} @ {e.Namespace}");
            }
        }
    }
}
