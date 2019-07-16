using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Constructor : GIFunction
    {
        /// <summary>
        /// Indicates that the constructor has a custom implementation.
        /// </summary>
        public bool HasCustomConstructor { get; }

        public Constructor(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "constructor") {
                throw new ArgumentException("Requrires <constructor> element", nameof(element));
            }
            HasCustomConstructor = element.Attribute(gs + "custom-constructor").AsBool();
        }
    }
}
