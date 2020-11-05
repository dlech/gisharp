using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.CodeGen.Reflection;

namespace GISharp.CodeGen.Gir
{
    public sealed class Implements : GIBase
    {
        /// <summary>
        /// The parent node
        /// </summary>
        public new Class ParentNode => (Class)base.ParentNode;

        /// <summary>
        /// Gets the .NET type associated with the implemented interface
        /// </summary>
        public System.Type ManagedType => _Type.Value;
        readonly Lazy<System.Type> _Type;

        public Implements(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "implements") {
                throw new ArgumentException("Requrires <implements> element", nameof(element));
            }
            _Type = new(LazyGetType);
        }

        System.Type LazyGetType() => GirInterfaceType.ResolveType(this);
    }
}
