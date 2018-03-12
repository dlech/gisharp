using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIEnum : GIRegisteredType
    {
        /// <summary>
        /// Indicates that this is an error domain enumeration
        /// </summary>
        public string ErrorDomain { get; }

        /// <summary>
        /// Gets a list of members of the enumeration
        /// </summary>
        public IEnumerable<Member> Members => _Members.Value;
        readonly Lazy<List<Member>> _Members;

        private protected GIEnum(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            ErrorDomain = Element.Attribute(glib + "error-domain").AsString();
            _Members = new Lazy<List<Member>>(() => LazyGetMembers().ToList());            
        }

        IEnumerable<Member> LazyGetMembers() =>
            Element.Elements(gi + "member").Select(x => (Member)GetNode(x));
    }
}