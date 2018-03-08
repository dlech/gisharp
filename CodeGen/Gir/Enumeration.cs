using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Enumeration : GIEnum
    {
        public Enumeration(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "enumeration") {
                throw new ArgumentException("Requrires <enumeration> element", nameof(element));
            }
        }
    }
}
