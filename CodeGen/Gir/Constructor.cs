using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Constructor : GIFunction
    {
        public Constructor(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "constructor") {
                throw new ArgumentException("Requrires <constructor> element", nameof(element));
            }
        }
    }
}
