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
        public GIType GirType => _GirType.Value;
        readonly Lazy<GIType> _GirType;

        public Alias(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "alias") {
                throw new ArgumentException("Requrires <alias> element", nameof(element));
            }
            _GirType = new Lazy<GIType>(LazyGetGirType, false);
        }

        GIType LazyGetGirType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));
    }
}
