using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Alias : GIRegisteredType
    {
        /// <summary>
        /// Gets the type that this type is an alias for
        /// </summary>
        public GIType Type => _Type.Value;
        readonly Lazy<GIType> _Type;

        public Alias(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "alias") {
                throw new ArgumentException("Requrires <alias> element", nameof(element));
            }
            _Type = new(LazyGetType, false);
        }

        GIType LazyGetType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));
    }
}
