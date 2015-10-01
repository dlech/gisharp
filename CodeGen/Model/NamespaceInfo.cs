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

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            return GetTypeDeclarationInfos ().SelectMany (x => x.Declarations);
        }

        IEnumerable<MemberInfo> GetTypeDeclarationInfos ()
        {
            foreach (var child in namespaceElement.Elements ()) {
                var childName = child.Attribute ("name").Value;
                if (child.Name == gi + "callback") {
                    yield return new DelegateInfo (child, this);
                } else if (child.Name == gi + "enumeration" || child.Name == gi + "bitfield") {
                    yield return new EnumInfo (child, this);
                } else if (child.Name == gi + "object" || (child.Name == gi + "record" && child.Attribute (gs + "opaque") != null) || child.Name == gs + "static-class") {
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
