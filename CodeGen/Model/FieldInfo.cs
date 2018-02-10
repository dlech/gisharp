using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Model
{
    public class FieldInfo : MemberInfo
    {
        /// <summary>
        /// Returns true if this field is a function pointer
        /// </summary>
        public bool IsCallback { get; }

        /// <summary>
        /// Gets the unmanaged type info for this field
        /// </summary>
        public TypeInfo TypeInfo => _TypeInfo.Value;
        readonly Lazy<TypeInfo> _TypeInfo;

        /// <summary>
        /// Gets the callback info for this field if it is a function pointer
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// Thrown if this field is not a function pointer
        /// </exception>
        public DelegateInfo CallbackInfo => _CallbackInfo.Value;
        readonly Lazy<DelegateInfo> _CallbackInfo;

        public FieldInfo(XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "field") {
                throw new ArgumentException("Requires <field> element.", nameof(element));
            }
            IsCallback = Element.Element(gi + "callback") != null;
            _TypeInfo = new Lazy<TypeInfo>(() => new TypeInfo(Element, false));
            _CallbackInfo = new Lazy<DelegateInfo>(GetCallbackInfo);
        }

        DelegateInfo GetCallbackInfo()
        {
            if (!IsCallback) {
                throw new InvalidOperationException("Field is not a function pointer");
            }
            return new DelegateInfo(Element.Element(gi + "callback"), this);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos()
        {
            yield break;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists()
        {
            return base.GetAttributeLists().Concat(GetFieldAttributeLists());
        }

        IEnumerable<AttributeListSyntax> GetFieldAttributeLists()
        {
            if (Element.Parent.Name == gi + "union") {
                var fieldOffsetAttrName = ParseName(typeof(FieldOffsetAttribute).FullName);
                var fieldOffsetAttrArgList = ParseAttributeArgumentList("(0)");
                var fieldOffsetAttr = Attribute(fieldOffsetAttrName)
                .WithArgumentList(fieldOffsetAttrArgList);
                yield return AttributeList().AddAttributes(fieldOffsetAttr);
            }

            if (IsCallback) {
                var marshalAsAttrName = ParseName(typeof(MarshalAsAttribute).FullName);
                var marshalAsAttrArgListText = string.Format("({0}.{1})",
                    typeof(UnmanagedType).FullName, UnmanagedType.FunctionPtr);
                var marshalAsAttrArgList = ParseAttributeArgumentList(marshalAsAttrArgListText);
                var marshalAsAttr = Attribute(marshalAsAttrName)
                .WithArgumentList(marshalAsAttrArgList);
                yield return AttributeList().AddAttributes(marshalAsAttr);
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            TypeSyntax type;
            if (IsCallback) {
                foreach (var callbackDeclaration in CallbackInfo.AllDeclarations) {
                    yield return callbackDeclaration;
                }
                type = ParseTypeName(CallbackInfo.UnmanagedIdentifier.Text);

            } else if (Element.Parent.Parent.Attribute(glib + "is-gtype-struct-for") != null
                && !Element.ElementsBeforeSelf().Any())
            {
                // The first element of a GType struct is always another GType struct
                // rather than a pointer.
                var parentTypeName = Element.Attribute(gs + "managed-type").Value;
                var lastDot = parentTypeName.LastIndexOf('.');
                var parentStructName = parentTypeName.Substring(lastDot) + "Struct";
                type = ParseTypeName(parentTypeName + parentStructName);
            } else {
                type = TypeInfo.Type;
            }
            var variable = VariableDeclarator(ManagedName);
            var variableDeclaration = VariableDeclaration(type)
                .AddVariables(variable);
            var field = FieldDeclaration(variableDeclaration)
                .WithModifiers(Modifiers)
                .WithAttributeLists(AttributeLists)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
            yield return field;

            // aliases only have one field, named "value". This creates implicit cast
            // operators to cast the alias to and from the value type.
            if (Element.Parent.Name == gi + "alias") {
                var castToOperator = ConversionOperatorDeclaration(
                    Token(ImplicitKeyword),
                    ParseTypeName(DeclaringMember.ManagedName))
                    .WithModifiers(TokenList(
                        Token(PublicKeyword),
                        Token(StaticKeyword)))
                    .WithParameterList(ParseParameterList(
                        string.Format("({0} value)", TypeInfo.Type)))
                    .WithBody(Block(
                        ReturnStatement(
                            ObjectCreationExpression(
                                ParseTypeName(DeclaringMember.ManagedName))
                            .WithInitializer(InitializerExpression(ObjectInitializerExpression)
                                .AddExpressions(
                                    ParseExpression("value = value"))))));
                yield return castToOperator;

                var castFromOperator = ConversionOperatorDeclaration(
                    Token(ImplicitKeyword), TypeInfo.Type)
                    .WithModifiers(TokenList(
                        Token(PublicKeyword),
                        Token(StaticKeyword)))
                    .WithParameterList(ParseParameterList(
                        string.Format("({0} value)",
                            ParseTypeName(DeclaringMember.ManagedName))))
                    .WithBody(Block(
                        ReturnStatement(
                            ParseExpression("value.value"))));
                yield return castFromOperator;
            }
        }
    }
}
