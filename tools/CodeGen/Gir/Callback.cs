using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Callback : GIFunction
    {
        /// <summary>
        /// Gets the C type of this type
        /// </summary>
        public string CType { get; }

        public Callback(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException("Requrires <callback> element", nameof(element));
            }
            CType = element.Attribute(c + "type").AsString();
        }
    }
}