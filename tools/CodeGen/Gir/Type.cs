using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using static System.Reflection.BindingFlags;

namespace GISharp.CodeGen.Gir
{
    public sealed class Type : GIType
    {
        public Type(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "type") {
                throw new ArgumentException("Requrires <type> element", nameof(element));
            }
        }
    }
}
