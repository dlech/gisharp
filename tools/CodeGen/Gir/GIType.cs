using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIType : GIBase
    {
        /// <summary>
        /// Gets the C type for this type
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Indicates if this type is a pointer type
        /// </summary>
        public bool IsPointer { get; }

        public IEnumerable<GIType> TypeParameters => _TypeParameters.Value;
        readonly Lazy<List<GIType>> _TypeParameters;

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

        private protected GIType(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            CType = element.Attribute(c + "type").AsString();
            IsPointer = element.Attribute(gs + "is-pointer").AsBool();
            _TypeParameters = new Lazy<List<GIType>>(() => LazyGetTypeParameters().ToList());
            _UnmanagedType = new Lazy<System.Type>(LazyGetUnmanagedType);
            _ManagedType = new Lazy<System.Type>(LazyGetManagedType);
        }

        IEnumerable<GIType> LazyGetTypeParameters() =>
            Element.Elements().Where(x => x.Name == gi + "type" || x.Name == gi + "array")
                .Select(x => (GIType)GetNode(x));

        System.Type LazyGetUnmanagedType() => Reflection.GirType.ResolveUnmanagedType(this);

        System.Type LazyGetManagedType() => Reflection.GirType.ResolveManagedType(this);
    }
}
