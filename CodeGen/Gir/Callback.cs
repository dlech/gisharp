using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Callback : GIFunction
    {
        public Callback(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException("Requrires <callback> element", nameof(element));
            }
        }
    }
}
