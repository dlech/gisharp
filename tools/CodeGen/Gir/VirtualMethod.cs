using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class VirtualMethod : GICallable
    {
        public VirtualMethod(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "virtual-method") {
                throw new ArgumentException("Requrires <virtual-method> element", nameof(element));
            }
        }
    }
}