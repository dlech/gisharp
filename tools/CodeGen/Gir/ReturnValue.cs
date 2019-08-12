using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class ReturnValue : GIArg
    {
        public ReturnValue(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "return-value") {
                throw new ArgumentException("Requrires <return-value> element", nameof(element));
            }
        }
    }
}