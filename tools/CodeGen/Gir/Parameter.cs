using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Parameter : GIArg
    {
        public Parameter(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "parameter") {
                throw new ArgumentException("Requrires <parameter> element", nameof(element));
            }
        }
    }
}