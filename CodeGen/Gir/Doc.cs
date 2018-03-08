using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Doc : GirNode
    {
        /// <summary>
        /// Gets the documentation text
        /// </summary>
        public string Text => Element.Value;

        public Doc(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentException(nameof(parent)))
        {
            if (element.Name != gi + "doc") {
                throw new ArgumentException("Requrires <doc> element", nameof(element));
            }
        }
    }
}
