using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class InstanceParameter : GIArg
    {
        public InstanceParameter(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "instance-parameter") {
                throw new ArgumentException("Requrires <instance-parameter> element", nameof(element));
            }
        }
    }
}
