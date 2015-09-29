using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Model
{
    public class FieldInfo : MemberInfo
    {
        TypeInfo _TypeInfo;
        public TypeInfo TypeInfo {
            get {
                if (_TypeInfo == null) {
                    // constants use the managed type and fields use the unmanaged type.
                    var managed = Element.Name == gi + "constant";
                    _TypeInfo = new TypeInfo (Element, managed);
                }
                return _TypeInfo;
            }
        }

        public FieldInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "field" && element.Name != gi + "constant") {
                throw new ArgumentException ("Requires <field> or <constant> element.", nameof(element));
            }
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }

            if (Element.Name == gi + "field") {
                if (Element.Parent.Name == gi + "union") {
                    var fieldOffsetAttrName = SyntaxFactory.ParseName (typeof(FieldOffsetAttribute).FullName);
                    var fieldOffsetAttrArgList = SyntaxFactory.ParseAttributeArgumentList ("(0)");
                    var fieldOffsetAttr = SyntaxFactory.Attribute (fieldOffsetAttrName)
                    .WithArgumentList (fieldOffsetAttrArgList);
                    yield return SyntaxFactory.AttributeList ().AddAttributes (fieldOffsetAttr);
                }

                if (Element.Element (gi + "callback") != null) {
                    var marshalAsAttrName = SyntaxFactory.ParseName (typeof(MarshalAsAttribute).FullName);
                    var marshalAsAttrArgListText = string.Format ("({0}.{1})", typeof(UnmanagedType).FullName, UnmanagedType.FunctionPtr);
                    var marshalAsAttrArgList = SyntaxFactory.ParseAttributeArgumentList (marshalAsAttrArgListText);
                    var marshalAsAttr = SyntaxFactory.Attribute (marshalAsAttrName)
                    .WithArgumentList (marshalAsAttrArgList);
                    yield return SyntaxFactory.AttributeList ().AddAttributes (marshalAsAttr);
                }
            }
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }
            if (Element.Name == gi + "constant") {
                yield return SyntaxFactory.Token (SyntaxKind.ConstKeyword);
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            TypeSyntax type;
            var callbackElement = Element.Element (gi + "callback");
            if (callbackElement != null) {
                var delegateInfo = new DelegateInfo (callbackElement, this);
                foreach (var callbackDeclaration in delegateInfo.Declarations) {
                    yield return callbackDeclaration;
                }
                type = SyntaxFactory.ParseTypeName (delegateInfo.NativeIdentifier.Text);
            } else {
                type = TypeInfo.Type;
            }
            var variable = SyntaxFactory.VariableDeclarator (ManagedName);
            if (Element.Name == gi + "constant") {
                var value = GetValueAsLiteralExpression ();
                var equalsValueClause = SyntaxFactory.EqualsValueClause (value);
                variable = variable.WithInitializer (equalsValueClause);
            }
            var variableDeclaration = SyntaxFactory.VariableDeclaration (type)
                .AddVariables (variable);
            var field = SyntaxFactory.FieldDeclaration (variableDeclaration)
                .WithModifiers (Modifiers)
                .WithAttributeLists (AttributeLists)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return field;

            // aliases only have one field, named "value". This creates implicit cast
            // operators to cast the alias to and from the value type.
            if (Element.Name != gi + "constant" && Element.Parent.Name == gi + "alias") {
                var castToOperator = SyntaxFactory.ConversionOperatorDeclaration (
                    SyntaxFactory.Token (SyntaxKind.ImplicitKeyword),
                    SyntaxFactory.ParseTypeName (DeclaringMember.ManagedName))
                    .WithModifiers (SyntaxFactory.TokenList (
                        SyntaxFactory.Token (SyntaxKind.PublicKeyword),
                        SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
                    .WithParameterList (SyntaxFactory.ParseParameterList (
                        string.Format ("({0} value)", TypeInfo.Type)))
                    .WithBody (SyntaxFactory.Block (
                        SyntaxFactory.ReturnStatement (
                            SyntaxFactory.ObjectCreationExpression (
                                SyntaxFactory.ParseTypeName (DeclaringMember.ManagedName))
                            .WithInitializer (SyntaxFactory.InitializerExpression (
                                SyntaxKind.ObjectInitializerExpression)
                                .AddExpressions (
                                    SyntaxFactory.ParseExpression ("value = value"))))));
                yield return castToOperator;

                var castFromOperator = SyntaxFactory.ConversionOperatorDeclaration (
                    SyntaxFactory.Token (SyntaxKind.ImplicitKeyword), TypeInfo.Type)
                    .WithModifiers (SyntaxFactory.TokenList (
                        SyntaxFactory.Token (SyntaxKind.PublicKeyword),
                        SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
                    .WithParameterList (SyntaxFactory.ParseParameterList (
                        string.Format ("({0} value)",
                            SyntaxFactory.ParseTypeName (DeclaringMember.ManagedName))))
                    .WithBody (SyntaxFactory.Block (
                        SyntaxFactory.ReturnStatement (
                            SyntaxFactory.ParseExpression ("value.value"))));
                yield return castFromOperator;
            }
        }

        LiteralExpressionSyntax GetValueAsLiteralExpression ()
        {
            var managedType = Element.Attribute (gs + "managed-type")?.Value;
            if (managedType == null) {
                throw new ArgumentException ("Requires element to have 'managed-type' attribute.");
            }
            var value = Element.Attribute ("value")?.Value;
            if (value == null) {
                throw new ArgumentException ("Requires element to have 'value' attribute.");
            }

            switch (managedType) {
            case "bool":
            case "System.Boolean":
                switch (value) {
                case "true":
                    return SyntaxFactory.LiteralExpression (SyntaxKind.TrueLiteralExpression);
                case "false":
                    return SyntaxFactory.LiteralExpression (SyntaxKind.FalseLiteralExpression);
                default:
                    throw new Exception (string.Format ("Unknown bool constant value '{0}'.", value));
                }
            case "byte":
            case "System.Byte":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (byte.Parse (value)));
            case "sbyte":
            case "System.SByte":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (sbyte.Parse (value)));
            case "short":
            case "System.Int16":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (short.Parse (value)));
            case "ushort":
            case "System.UInt16":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (ushort.Parse (value)));
            case "int":
            case "System.Int32":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (int.Parse (value)));
            case "uint":
            case "System.Uint32":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (uint.Parse (value)));
            case "long":
            case "System.Int64":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (long.Parse (value)));
            case "ulong":
            case "System.UInt64":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (ulong.Parse (value)));
            case "float":
            case "System.Float":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (float.Parse (value)));
            case "double":
            case "System.Double":
                return SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    SyntaxFactory.Literal (double.Parse (value)));
            case "string":
            case "System.String":
                return SyntaxFactory.LiteralExpression (SyntaxKind.StringLiteralExpression,
                    SyntaxFactory.Literal (value));
            default:
                var message = string.Format ("Bad constant type: {0}", managedType);
                throw new Exception (message);
            }
        }
    }
}
