using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public class NamespaceInfo : MemberInfo
    {
        public const string GlobalPrefix = "GISharp";

        readonly XElement namespaceElement;

        public string Version { get; private set; }

        public string FullManagedName {
            get { return string.Join (".", GlobalPrefix, ManagedName); }
        }

        public NameSyntax Name {
            get {
                return ParseName (FullManagedName);
            }
        }

        NamespaceDeclarationSyntax _Syntax;
        public NamespaceDeclarationSyntax Syntax { get
            {
                if (_Syntax == null) {
                    var globalNamespaceNameSyntax = ParseName (GlobalPrefix);
                    var namespaceNameSyntax = IdentifierName (ManagedName);
                    var nameSyntax = QualifiedName (globalNamespaceNameSyntax, namespaceNameSyntax);
                    var members = List<MemberDeclarationSyntax> ()
                        .AddRange (Declarations);
                    _Syntax = NamespaceDeclaration (nameSyntax)
                        .WithMembers (members);
                }
                return _Syntax;
            }
        }

        List<MemberInfo> _TypeDeclarationInfos;
        public IReadOnlyList<MemberInfo> TypeDeclarationInfos {
            get {
                if (_TypeDeclarationInfos == null) {
                    _TypeDeclarationInfos = GetTypeDeclarationInfos ().ToList ();
                }
                return _TypeDeclarationInfos.AsReadOnly ();
            }
        }

        public NamespaceInfo (XDocument document) 
            : base (document.Element (gi + "repository").Element (gi + "namespace"), null)
        {
            if (document == null) {
                throw new ArgumentNullException (nameof(document));
            }
            var repositoryElement = document.Element (gi + "repository");
            if (repositoryElement == null) {
                throw new ArgumentException ("Missing <repository> element.", nameof(document));
            }
            var girVersion = repositoryElement.Attribute ("version").Value;
            if (girVersion != "1.2") {
                throw new ArgumentException ("Expecting gir version 1.2.", nameof(document));
            }
            namespaceElement = repositoryElement.Element (gi + "namespace");
            if (namespaceElement == null) {
                throw new ArgumentException ("Missing <namespace> element.", nameof(document));
            }

            Version = namespaceElement.Attribute ("version").Value;
        }

        /// <summary>
        /// Finds the info for the specified element.
        /// </summary>
        /// <returns>The info or <c>null</c> if the element was not found.</returns>
        /// <param name="element">The element to search for.</param>
        public BaseInfo FindInfo (XElement element)
        {
            var info = element.Annotation<BaseInfo> ();
            if (info != null) {
                return info;
            }
            return InternalFindInfo (element);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return TypeDeclarationInfos;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            return TypeDeclarationInfos.SelectMany (x => x.Declarations);
        }

        IEnumerable<MemberInfo> GetTypeDeclarationInfos ()
        {
            foreach (var child in namespaceElement.Elements ()) {
                var childName = child.Attribute ("name").Value;
                if (child.Name == gi + "callback") {
                    yield return new DelegateInfo (child, this);
                } else if (child.Name == gi + "enumeration" || child.Name == gi + "bitfield") {
                    yield return new EnumInfo (child, this);
                } else if (child.Name == gi + "interface") {
                    yield return new InterfaceInfo (child, this);
                } else if (child.Name == gi + "class" || (child.Name == gi + "record" && child.Attribute (gs + "opaque") != null) || child.Name == gs + "static-class") {
                    yield return new ClassInfo (child, this);
                } else if (child.Name == gi + "record" || child.Name == gi + "alias" || child.Name == gi + "union") {
                    yield return new StructInfo (child, this);
                } else {
                    Console.Error.WriteLine ("Unhandled element <{0} name=\"{1}\"> in namespace.", child.Name.LocalName, child.Attribute ("name")?.Value);
                }
            }
        }
    }
}
