using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Constant : GIBase
    {
        /// <summary>
        /// Gets the value of the constant
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the C identifier for the constant
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Gets the type of the constant
        /// </summary>
        public GIType GirType => _GirType.Value;
        readonly Lazy<GIType> _GirType;

        public Constant(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "constant") {
                throw new ArgumentException("Requrires <constant> element", nameof(element));
            }
            Value = Element.Attribute("value").Value;
            CType = Element.Attribute(c + "type").Value;
            _GirType = new Lazy<GIType>(LazyGetGirType, false);
        }

        GIType LazyGetGirType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));
    }
}
