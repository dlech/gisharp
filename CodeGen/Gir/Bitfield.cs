using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Bitfield : GIEnum
    {
        public Bitfield(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "bitfield") {
                throw new ArgumentException("Requrires <bitfield> element", nameof(element));
            }
        }
    }
}
