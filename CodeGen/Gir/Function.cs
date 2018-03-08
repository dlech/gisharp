using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Function : GIFunction
    {
        public Function(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "function") {
                throw new ArgumentException("Requrires <function> element", nameof(element));
            }
        }
    }
}
