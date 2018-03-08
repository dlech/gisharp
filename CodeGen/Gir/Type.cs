using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using static System.Reflection.BindingFlags;

namespace GISharp.CodeGen.Gir
{
    public sealed class Type : GIType
    {
        public Type(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "type") {
                throw new ArgumentException("Requrires <type> element", nameof(element));
            }
        }

        private protected override System.Type LazyGetUnmanagedType()
        {
            if (IsPointer) {
                return typeof(IntPtr);
            }
            var type = ManagedType;

            if (type.IsDelegate()) {
                var name = string.Concat(type.Name.TakeWhile(x => x != '`'));
                var unmanagedName = $"{type.Namespace}.Unmanaged{name}";
                type = Reflection.GirType.ResolveType(unmanagedName, Element.Document);
            }
            else if (type.IsOpaque()) {
                // if the managed type is opaque and the C type was not a pointer,
                // then we must need the internal struct of the opaque
                type = type.GetNestedType("Struct", NonPublic);
            }
            else if (!type.IsValueType) {
                throw new NotSupportedException("unmanaged type should be pointer, delegate or value type");
            }

            return type;
        }

        private protected override System.Type LazyGetManagedType()
        {
            var type = Reflection.GirType.ResolveType(ManagedName, Element.Document);

            // if we end up with a static class, this must be an interface
            if (type.IsAbstract && type.IsSealed) {
                type = Reflection.GirType.ResolveType("I" + ManagedName, Element.Document);
            }

            return type;
        }

        private protected override System.Type LazyGetExtensionType()
        {
            throw new NotImplementedException();
        }
    }
}
