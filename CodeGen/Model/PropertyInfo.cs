using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

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
                return Element.Attribute("writable").AsBool ();
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

        /// <summary>
        /// Gets a property declaration appropriate for use in a class declaration.
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> ClassDeclarations => _ClassDeclarations.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _ClassDeclarations;

        /// <summary>
        /// Gets a property declaration appropriate for use in an interface declaration.
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> InterfaceDeclarations => _InterfaceDeclarations.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _InterfaceDeclarations;

        public PropertyInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "property") {
                throw new ArgumentException ("Requires <property> element.", nameof(element));
            }

            _ClassDeclarations = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() =>
                List(GetClassDeclarations()));
            _InterfaceDeclarations = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() =>
                List(GetInterfaceMemberDeclarations()));
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            yield break;
        }

        IEnumerable<MemberDeclarationSyntax> GetClassDeclarations()
        {
            var property = PropertyDeclaration(TypeInfo.Type, ManagedName)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers);
            if (IsReadable) {
                var getExpression = ParseExpression($"Get{ManagedName}();");
                property = property.AddAccessorListAccessors(AccessorDeclaration(GetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(getExpression)));
            }
            if (IsWriteable && !IsConstructOnly) {
                var setExpression = ParseExpression($"Set{ManagedName}(value);");
                property = property.AddAccessorListAccessors (AccessorDeclaration (SyntaxKind.SetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(setExpression)));
            }

            yield return property;
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMemberDeclarations()
        {
            var property = PropertyDeclaration(TypeInfo.Type, ManagedName)
                .WithAttributeLists(AttributeLists);
            if (IsReadable) {
                property = property.AddAccessorListAccessors(AccessorDeclaration(GetAccessorDeclaration)
                    .WithSemicolonToken(Token(SemicolonToken)));
            }
            if (IsWriteable) {
                property = property.AddAccessorListAccessors(AccessorDeclaration(SetAccessorDeclaration)
                    .WithSemicolonToken(Token(SemicolonToken)));
            }

            yield return property;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            throw new NotSupportedException("this method is being phased out");
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists()
        {
            return GetPropertyAttributeLists().Concat(base.GetAttributeLists());
        }

        IEnumerable<AttributeListSyntax> GetPropertyAttributeLists()
        {
            // emit a GProperty attribute
            var attrName = ParseName(typeof(GPropertyAttribute).FullName);
            var args = SeparatedList<AttributeArgumentSyntax>();
            // add the default argument (the property name)
            args = args.Add(AttributeArgument(ParseExpression($"\"{GirName}\"")));
            if (IsConstruct || IsConstructOnly) {
                var enumMemberName = IsConstruct ? nameof(GPropertyConstruct.Yes) : nameof(GPropertyConstruct.Only);
                var expression = string.Format("{0} = {1}.{2}",
                    nameof(GPropertyAttribute.Construct),
                    typeof(GPropertyConstruct).FullName,
                    enumMemberName);
                args = args.Add(AttributeArgument(ParseExpression(expression)));
            }
            var propertyAttr = Attribute(attrName).WithArgumentList(AttributeArgumentList(args));
            yield return AttributeList().AddAttributes(propertyAttr);
        }
    }
}
