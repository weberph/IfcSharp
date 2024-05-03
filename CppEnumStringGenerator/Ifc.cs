namespace CppEnumStringGenerator
{
    public class IfcEnum(string name, string @namespace, bool enumClass, string[] members)
    {
        public string Name { get; } = name;
        public string Namespace { get; } = @namespace;
        public bool EnumClass { get; } = enumClass;
        public string[] Members { get; } = members;
    }

    public class Ifc(string ifcPath) : IDisposable
    {
        private readonly IntPtr _ifc = NativeIfc.CreateIfc(ifcPath);
        private bool _disposed;

        public List<IfcEnum> GetEnums()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            var result = new List<IfcEnum>();

            NativeIfc.GetEnums(_ifc, (name, @namespace, enumClass, members, memberCount) =>
            {
                result.Add(new IfcEnum(name, @namespace, enumClass, members ?? []));
                return true;
            });

            return result;
        }

        public void Dispose()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            _disposed = true;
            NativeIfc.DestroyIfc(_ifc);
        }
    }
}
