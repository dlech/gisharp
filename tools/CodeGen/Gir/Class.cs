using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Class : GIRegisteredType
    {
        /// <summary>
        /// Indicates that this is an abstract class
        /// </summary>
        public bool IsAbstract { get; }

        /// <summary>
        /// Gets the name of the parent type of this class
        /// </summary>
        public string Parent { get; }

        /// <summary>
        /// Gets the .NET type associated with the parent type
        /// </summary>
        public System.Type ParentType => _ParentType.Value;
        readonly Lazy<System.Type> _ParentType;

        /// <summary>
        /// Gets a list of interfaces implemented by this class, if any.
        /// </summary>
        public IEnumerable<Implements> Implements => _Implements.Value;
        readonly Lazy<List<Implements>> _Implements;

        public Class(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "class") {
                throw new ArgumentException("Requrires <class> element", nameof(element));
            }
            IsAbstract = Element.Attribute("abstract").AsBool();
            Parent = Element.Attribute("parent").Value;
            _ParentType = new Lazy<System.Type>(LazyGetParentType);
            _Implements = new Lazy<List<Implements>>(() => LazyGetImplements().ToList());
        }

        System.Type LazyGetParentType() =>
            Reflection.GirType.ResolveParentType(this);

        IEnumerable<Implements> LazyGetImplements() =>
            Element.Elements(gi + "implements").Select(x => (Implements)GetNode(x));
    }
}
