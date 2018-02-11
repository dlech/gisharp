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

        /// <summary>
        /// Gets a field declaration for a field containing the offset to an
        /// unmanaged field.
        /// </summary>
        public FieldDeclarationSyntax OffsetDeclaration => _OffsetDeclaration.Value;
        readonly Lazy<FieldDeclarationSyntax> _OffsetDeclaration;

        /// <summary>
        /// Gets a field declaration for a field containing the delegate to an
        /// unmanaged callback implementation
        /// </summary>
        public FieldDeclarationSyntax DelegateDeclaration => _DelegateDeclaration.Value;
        readonly Lazy<FieldDeclarationSyntax> _DelegateDeclaration;

        /// <summary>
        /// Gets a field declaration for a field containing the function pointer
        /// to a unmanaged callback delegate
        /// </summary>
        public FieldDeclarationSyntax DelegatePtrDeclaration => _DelegatePtrDeclaration.Value;
        readonly Lazy<FieldDeclarationSyntax> _DelegatePtrDeclaration;

        public FieldInfo(XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "field") {
                throw new ArgumentException("Requires <field> element.", nameof(element));
            }
            IsCallback = Element.Element(gi + "callback") != null;
            _TypeInfo = new Lazy<TypeInfo>(() => new TypeInfo(Element, false));
            _CallbackInfo = new Lazy<DelegateInfo>(GetCallbackInfo);
            _OffsetDeclaration = new Lazy<FieldDeclarationSyntax>(GetOffsetDeclaration);
            _DelegateDeclaration = new Lazy<FieldDeclarationSyntax>(GetDelegateDeclaration);
            _DelegatePtrDeclaration = new Lazy<FieldDeclarationSyntax>(GetDelegatePointerDeclaration);
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
        }

        // Gets a field declaration like:
        // static readonly IntPtr xxxOffset = Marshal.OffsetOf<Struct>(nameof(Struct.xxx));
        FieldDeclarationSyntax GetOffsetDeclaration()
        {
            var variableType = ParseTypeName(typeof(IntPtr).FullName);
            var variableName = ManagedName.ToCamelCase() + "Offset";
            var valueExpression = ParseExpression(string.Format("{0}.{1}<Struct>(nameof(Struct.{2}))",
                typeof(Marshal).FullName,
                nameof(Marshal.OffsetOf),
                ManagedName));

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator(variableName)
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        // Gets a field declaration like:
        // static readonly UnmanagedYyy xxxDelegate = OnYyy;
        FieldDeclarationSyntax GetDelegateDeclaration()
        {
            if (!IsCallback) {
                throw new InvalidOperationException("Must be a callback field");
            }

            var variableType = ParseTypeName(CallbackInfo.UnmanagedIdentifier.Text);
            var variableName = ManagedName.ToCamelCase() + "Delegate";
            var valueExpression = ParseExpression($"On{ManagedName}");

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator(variableName)
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        // Gets a field declaration like:
        // static readonly IntPtr xxxDelegate_ = Marshal.GetFunctionPointerForDelegate(xxxDelegate);
        FieldDeclarationSyntax GetDelegatePointerDeclaration()
        {
            if (!IsCallback) {
                throw new InvalidOperationException("Must be a callback field");
            }

            var variableType = ParseTypeName(typeof(IntPtr).FullName);
            var variableName = ManagedName.ToCamelCase() + "Delegate";
            var valueExpression = ParseExpression(string.Format("{0}.{1}({2})",
                typeof(Marshal).FullName,
                nameof(Marshal.GetFunctionPointerForDelegate),
                variableName));

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator($"{variableName}_")
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            TypeSyntax type;
            if (IsCallback) {
                type = ParseTypeName(CallbackInfo.UnmanagedIdentifier.Text);
            }
            else {
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
