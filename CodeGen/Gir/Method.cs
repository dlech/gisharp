using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Method : GIFunction
    {
        /// <summary>
        /// Indicates that this is an extension method
        /// </summary>
        public bool IsExtensionMethod => Element.Attribute(gs + "extension-method").AsBool();

        /// <summary>
        /// Tests if this method is a ref method
        /// </summary>
        public bool IsRef => Element.Attribute(gs + "special-func").AsString() == "ref";


        /// <summary>
        /// Tests if this method is an unref method
        /// </summary>
        public bool IsUnref => Element.Attribute(gs + "special-func").AsString() == "unref";


        /// <summary>
        /// Tests if this method is a copy method
        /// </summary>
        public bool IsCopy => Element.Attribute(gs + "special-func").AsString() == "copy";

        /// <summary>
        /// Tests if this method is a free method
        /// </summary>
        public bool IsFree => Element.Attribute(gs + "special-func").AsString() == "free";

        /// <summary>
        /// Tests if this method is a equal method
        /// </summary>
        public bool IsEquals => Element.Attribute(gs + "special-func").AsString() == "equal";

        /// <summary>
        /// Tests if this method is a compare method
        /// </summary>
        public bool IsCompare => Element.Attribute(gs + "special-func").AsString() == "compare";

        public Method(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "method") {
                throw new ArgumentException("Requrires <method> element", nameof(element));
            }
        }
    }
}
