using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public class ModuleInfo : MemberInfo
    {
        /// <summary>
        /// Gets the namespace for this module
        /// </summary>
        public NamespaceInfo Namespace => _Namespace.Value;
        readonly Lazy<NamespaceInfo> _Namespace;

        public ModuleInfo(XElement element) : base (element, null)
        {
            if (element == null) {
                throw new ArgumentNullException(nameof(element));
            }
            if (element.Name != gi + "repository") {
                throw new ArgumentException("Requires <gi:repository> element.", nameof(element));
            }
            if (element.Attribute("version").AsString() != "1.2") {
                throw new ArgumentException("Bad GIR version.", nameof(element));
            }
            _Namespace = new Lazy<NamespaceInfo>(GetNamespace);
        }

        /// <summary>
        /// Finds the info for the specified element.
        /// </summary>
        /// <returns>The info or <c>null</c> if the element was not found.</returns>
        /// <param name="element">The element to search for.</param>
        public BaseInfo FindInfo(XElement element)
        {
            var info = element.Annotation<BaseInfo>();
            if (info != null) {
                return info;
            }
            return InternalFindInfo(element);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos()
        {
            yield return Namespace;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            return Namespace.AllDeclarations;
        }

        NamespaceInfo GetNamespace()
        {
            return new NamespaceInfo(Element.Element(gi + "namespace"), this);
        }
    }
}
