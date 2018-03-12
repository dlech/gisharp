using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public class Repository : GirNode
    {
        /// <summary>
        /// Gets the GIR version
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets the namespace for this repository
        /// </summary>
        public Namespace Namespace => _Namespace.Value;
        readonly Lazy<Namespace> _Namespace;

        /// <summary>
        /// Gets the package for this repository
        /// </summary>
        public Package Package => _Package.Value;
        readonly Lazy<Package> _Package;

        public Repository(XDocument document) : base(document?.Root, null)
        {
            if (Element.Name != gi + "repository") {
                throw new ArgumentException("Requires <repository> root element.", nameof(document));
            }

            Version = Element.Attribute("version").AsString();
            if (Version != "1.2") {
                throw new ArgumentException("Bad GIR version.", nameof(document));
            }

            _Namespace = new Lazy<Namespace>(LazyGetNamespace, false);
            _Package = new Lazy<Package>(LazyGetPackage, false);
        }

        Namespace LazyGetNamespace() =>
            (Namespace)GetNode(Element.Element(gi + "namespace"));

        Package LazyGetPackage() =>
            (Package)GetNode(Element.Element(gi + "package"));
    }
}