using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Implements : GirNode
    {
        /// <summary>
        /// Gets the name of the implemented interface
        /// </summary>
        public string GirName { get; }

        /// <summary>
        /// Gets the fixed up managed name of the implemented interface
        /// </summary>
        public string ManagedName { get; }

        /// <summary>
        /// Gets the .NET type associated with the implemented interface
        /// </summary>
        public System.Type Type => _Type.Value;
        readonly Lazy<System.Type> _Type;

        public Implements(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "implements") {
                throw new ArgumentException("Requrires <implements> element", nameof(element));
            }
            GirName = element.Attribute("name").AsString();
            ManagedName = element.Attribute(gs + "managed-name").AsString();
            _Type = new Lazy<System.Type>(LazyGetType);
        }

        System.Type LazyGetType()
        {
            var parts = ManagedName.Split('.');
            var fixedUpName = string.Join('.', parts.SkipLast(1).Append("I" + parts.Last()));
            return Reflection.GirType.ResolveType(fixedUpName, Element.Document);
        }
    }
}
