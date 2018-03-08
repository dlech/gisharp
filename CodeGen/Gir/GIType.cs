using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIType : GIBase
    {
        /// <summary>
        /// Gets the fixed up managed name of this member
        /// </summary>
        // FIXME: should be using the inherited property here, see FIXME in
        // constructor for details
        public new string ManagedName { get; }

        /// <summary>
        /// Gets the C type for this type
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Indicates if this type is a pointer type
        /// </summary>
        public bool IsPointer { get; }

        /// <summary>
        /// Gets the .NET type for the unmanaged version of this GIR type
        /// </summary>
        public System.Type UnmanagedType => _UnmanagedType.Value;
        readonly Lazy<System.Type> _UnmanagedType;

        /// <summary>
        /// Gets the .NET type for the managed version of this GIR type
        /// </summary>
        public System.Type ManagedType => _ManagedType.Value;
        readonly Lazy<System.Type> _ManagedType;

        /// <summary>
        /// Gets the .NET type for the extension method type for this GIR type,
        /// if any
        /// </summary>
        public System.Type ExtensionType => _ExtensionType.Value;
        readonly Lazy<System.Type> _ExtensionType;

        private protected GIType(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            // FIXME: Fixup should modify the gs:managed-name attribute rather than
            // adding a gs:managed-type attribute to the parent.
            // ManagedName = Element.Attribute(gs + "managed-name").Value;

            string getArrayElementType()
            {
                var arrayType = element.Parent.Parent.Attribute(gs + "managed-type").Value;
                var elementType = string.Concat(arrayType.SkipWhile(x => x != '['));
                elementType = elementType.TrimStart('[').TrimEnd(']');
                return elementType;
            }

            ManagedName = element.Parent.Attribute(gs + "managed-type")?.Value ?? getArrayElementType();

            IsPointer = element.Attribute(gs + "is-pointer").AsBool();
            _UnmanagedType = new Lazy<System.Type>(LazyGetUnmanagedType, false);
            _ManagedType = new Lazy<System.Type>(LazyGetManagedType, false);
            _ExtensionType = new Lazy<System.Type>(LazyGetExtensionType, false);
        }

        private protected abstract System.Type LazyGetUnmanagedType();
        private protected abstract System.Type LazyGetManagedType();
        private protected virtual System.Type LazyGetExtensionType() => null;
    }
}
