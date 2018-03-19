using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Property : GIBase
    {
        /// <summary>
        /// Gets if the property is readable
        /// </summary>
        public bool IsReadable { get; }

        /// <summary>
        /// Gets if the property is writeable
        /// </summary>
        public bool IsWriteable { get; }

        /// <summary>
        /// Gets if the property is construct writeable
        /// </summary>
        public bool Construct { get; }

        /// <summary>
        /// Gets if the property is only construct writeable
        /// </summary>
        public bool ConstructOnly { get; }

        /// <summary>
        /// Gets the ownership transfer of the property
        /// </summary>
        public Transfer Ownership { get; }

        /// <summary>
        /// Gets the type of the property
        /// </summary>
        public GIType Type => _Type.Value;
        readonly Lazy<GIType> _Type;

        public Property(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "property") {
                throw new ArgumentException("Requrires <property> element", nameof(element));
            }

            IsReadable = Element.Attribute("readable").AsBool(true);
            IsWriteable = Element.Attribute("writeable").AsBool(false);
            IsWriteable = Element.Attribute("construct").AsBool(false);
            IsWriteable = Element.Attribute("construct-only").AsBool(false);
            Ownership = Element.Attribute("transfer-ownership").AsTransfer(null);
            _Type = new Lazy<GIType>(LazyGetType, false);
        }

        GIType LazyGetType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));
    }
}
