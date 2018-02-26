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
        /// <summary>
        /// Gets the GIR namespace version
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets the name of the namespace
        /// </summary>
        public NameSyntax Name { get; }

        /// <summary>
        /// Gets the namespace declaration (no members)
        /// </summary>
        public NamespaceDeclarationSyntax NamespaceDeclaration => _NamespaceDeclaration.Value;
        Lazy<NamespaceDeclarationSyntax> _NamespaceDeclaration;

        /// <summary>
        /// Gets a list of child type declarations
        /// </summary>
        public IReadOnlyList<MemberInfo> TypeDeclarations => _TypeDeclarations.Value;
        readonly Lazy<IReadOnlyList<MemberInfo>> _TypeDeclarations;

        public NamespaceInfo(XElement element, ModuleInfo declaringMember) : base(element, declaringMember)
        {
            if (element == null) {
                throw new ArgumentNullException(nameof(element));
            }
            if (declaringMember == null) {
                throw new ArgumentNullException(nameof(declaringMember));
            }
            if (element.Name != gi + "namespace") {
                throw new ArgumentException("Requrires 'namespace' element", nameof(element));
            }

            Version = element.Attribute("version").Value;
            Name = ParseName($"GISharp.{ManagedName}");
            _NamespaceDeclaration = new Lazy<NamespaceDeclarationSyntax>(GetNamespaceDeclaration, false);
            _TypeDeclarations = new Lazy<IReadOnlyList<MemberInfo>>(() => GetTypeDeclarations().ToList().AsReadOnly(), false);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return TypeDeclarations;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            var members = TypeDeclarations.SelectMany (x => x.AllDeclarations);
            yield return NamespaceDeclaration.WithMembers(List(members));
        }

        NamespaceDeclarationSyntax GetNamespaceDeclaration()
        {
            return NamespaceDeclaration(Name);
        }

        IEnumerable<MemberInfo> GetTypeDeclarations()
        {
            foreach (var child in Element.Elements()) {
                var childName = child.Attribute ("name").Value;
                if (child.Name == gi + "callback") {
                    yield return new DelegateInfo (child, this);
                } else if (child.Name == gi + "enumeration" || child.Name == gi + "bitfield") {
                    yield return new EnumInfo (child, this);
                } else if (child.Name == gi + "interface") {
                    yield return new InterfaceInfo (child, this);
                }
                else if (child.Name == gi + "record" && child.Attribute (glib + "is-gtype-struct-for") != null) {
                    yield return new GTypeStructInfo(child, this);
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
