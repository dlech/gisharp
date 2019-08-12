using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Union : GIRegisteredType
    {
        public Union(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "union") {
                throw new ArgumentException("Requrires <union> element", nameof(element));
            }
        }
    }
}