using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Member : GIBase
    {
        /// <summary>
        /// Gets the value of the member
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the C identifier of the member
        /// </summary>
        public string CIdentifier { get; }

        public Member(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "member") {
                throw new ArgumentException("Requrires <member> element", nameof(element));
            }
            Value = element.Attribute("value").Value;
            CIdentifier = element.Attribute(c + "identifier").Value;
        }
    }
}