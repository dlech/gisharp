using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Prerequisite : GirNode
    {
        /// <summary>
        /// Gets the name of the prerequisite
        /// </summary>
        public string Name { get; }

        public System.Type Type => _Type.Value;
        readonly Lazy<System.Type> _Type;

        public Prerequisite(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "prerequisite") {
                throw new ArgumentException("Requrires <prerequisite> element", nameof(element));
            }
            Name = element.Attribute("name").Value;
            _Type = new Lazy<System.Type>(LazyGetType);
        }

        System.Type LazyGetType()
        {
            var type = Reflection.GirType.ResolveType(Name, Element.Document);
            if (type.IsOpaque()) {
                type = typeof(GInterface<>).MakeGenericType(type);
            }
            else {
                type = Reflection.GirType.ResolveType("I" + Name, Element.Document);
            }
            return type;
        }
    }
}
