using System;
using System.Collections.Generic;
using System.Xml.Linq;
using GISharp.Runtime;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public class PropertyInfo : MemberInfo
    {
        TypeInfo _TypeInfo;
        public TypeInfo TypeInfo {
            get {
                if (_TypeInfo == null) {
                    _TypeInfo = new TypeInfo (Element, true);
                }
                return _TypeInfo;
            }
        }

        public bool IsReadable {
            get {
                return Element.Attribute ("readable").AsBool (true);
            }
        }

        public bool IsWriteable {
            get {
                return Element.Attribute ("writeable").AsBool ();
            }
        }

        public bool IsConstruct {
            get {
                return Element.Attribute ("construct").AsBool ();
            }
        }

        public bool IsConstructOnly {
            get {
                return Element.Attribute ("construct-only").AsBool ();
            }
        }

        public Transfer Transfer {
            get {
                switch (Element.Attribute ("transfer-ownership").AsString ("")) {
                case "none":
                    return Transfer.None;
                case "container":
                    return Transfer.Container;
                case "all":
                    return Transfer.Full;
                default:
                    throw new ArgumentException ("Unknown transfer.");
                }
            }
        }

        public PropertyInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "property") {
                throw new ArgumentException ("Requires <property> element.", nameof(element));
            }
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            yield break;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var property = PropertyDeclaration (TypeInfo.Type, ManagedName)
                .WithAttributeLists (AttributeLists);
            if (IsReadable) {
                property = property.AddAccessorListAccessors (AccessorDeclaration (SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken (Token (SyntaxKind.SemicolonToken)));
            }
            if (IsWriteable) {
                property = property.AddAccessorListAccessors (AccessorDeclaration (SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken (Token (SyntaxKind.SemicolonToken)));
            }

            yield return property;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            var property = AttributeList ()
                .AddAttributes (Attribute (ParseName (typeof(GTypePropertyAttribute).FullName))
                    .AddArgumentListArguments(AttributeArgument (ParseExpression ($"\"{GirName}\""))));
            yield return property;

            foreach (var a in base.GetAttributeLists ()) {
                yield return a;
            }
        }
    }
}
