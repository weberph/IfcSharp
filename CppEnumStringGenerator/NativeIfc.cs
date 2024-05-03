using System.Runtime.InteropServices;

namespace CppEnumStringGenerator
{
    public static class NativeIfc
    {
        // Can't use LPUTF8Str for 'members' because: MarshalDirectiveException: 'Cannot marshal 'parameter #4': Invalid managed/unmanaged type combination (String[] must be paired with an ArraySubType of LPStr, LPWStr, BStr, or LPTStr).'
        public delegate bool EnumCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string name, string @namespace, bool enumClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 4)] string[] members, int memberCount);

        private const string IfcEnumLibPath = @"IfcEnumLib.dll";

        [DllImport(IfcEnumLibPath)]
        public static extern bool GetEnums(IntPtr ifc, EnumCallback callback);

        [DllImport(IfcEnumLibPath)]
        public static extern IntPtr CreateIfc([MarshalAs(UnmanagedType.LPUTF8Str)] string ifcPath);

        [DllImport(IfcEnumLibPath)]
        public static extern void DestroyIfc(IntPtr ifc);
    }
}
