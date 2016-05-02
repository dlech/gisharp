using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public class FieldInfo : MemberInfo
    {
        public bool IsCallback {
            get {
                return Element.Element (gi + "callback") != null;
            }
        }

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

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            yield break;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }

            if (Element.Name == gi + "field") {
                if (Element.Parent.Name == gi + "union") {
                    var fieldOffsetAttrName = ParseName (typeof(FieldOffsetAttribute).FullName);
                    var fieldOffsetAttrArgList = ParseAttributeArgumentList ("(0)");
                    var fieldOffsetAttr = Attribute (fieldOffsetAttrName)
                    .WithArgumentList (fieldOffsetAttrArgList);
                    yield return AttributeList ().AddAttributes (fieldOffsetAttr);
                }

                if (IsCallback) {
                    var marshalAsAttrName = ParseName (typeof(MarshalAsAttribute).FullName);
                    var marshalAsAttrArgListText = string.Format ("({0}.{1})", typeof(UnmanagedType).FullName, UnmanagedType.FunctionPtr);
                    var marshalAsAttrArgList = ParseAttributeArgumentList (marshalAsAttrArgListText);
                    var marshalAsAttr = Attribute (marshalAsAttrName)
                    .WithArgumentList (marshalAsAttrArgList);
                    yield return AttributeList ().AddAttributes (marshalAsAttr);
                }
            }
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }
            if (Element.Name == gi + "constant") {
                yield return Token (SyntaxKind.ConstKeyword);
            }
        }

        DelegateInfo _CallbackInfo;
        public DelegateInfo CallbackInfo {
            get {
                if (!IsCallback) {
                    throw new InvalidOperationException ();
                }
                if (_CallbackInfo == null) {
                    _CallbackInfo = new DelegateInfo (Element.Element (gi + "callback"), this);
                }
                return _CallbackInfo;
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            TypeSyntax type;
            if (IsCallback) {
                foreach (var callbackDeclaration in CallbackInfo.Declarations) {
                    yield return callbackDeclaration;
                }
                type = ParseTypeName (CallbackInfo.NativeIdentifier.Text);

            } else if (Element.Parent.Parent.Attribute (glib + "is-gtype-struct-for") != null
                && !Element.ElementsBeforeSelf ().Any ())
            {
                // The first element of a GType struct is always another GType struct
                // rather than a pointer.
                var parentTypeName = Element.Attribute (gs + "managed-type").Value;
                var lastDot = parentTypeName.LastIndexOf ('.');
                var parentStructName = parentTypeName.Substring (lastDot) + "Struct";
                type = ParseTypeName (parentTypeName + parentStructName);
            } else {
                type = TypeInfo.Type;
            }
            var variable = VariableDeclarator (ManagedName);
            if (Element.Name == gi + "constant") {
                var value = GetValueAsLiteralExpression ();
                var equalsValueClause = EqualsValueClause (value);
                variable = variable.WithInitializer (equalsValueClause);
            }
            var variableDeclaration = VariableDeclaration (type)
                .AddVariables (variable);
            var field = FieldDeclaration (variableDeclaration)
                .WithModifiers (Modifiers)
                .WithAttributeLists (AttributeLists)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return field;

            // aliases only have one field, named "value". This creates implicit cast
            // operators to cast the alias to and from the value type.
            if (Element.Name != gi + "constant" && Element.Parent.Name == gi + "alias") {
                var castToOperator = ConversionOperatorDeclaration (
                    Token (SyntaxKind.ImplicitKeyword),
                    ParseTypeName (DeclaringMember.ManagedName))
                    .WithModifiers (TokenList (
                        Token (SyntaxKind.PublicKeyword),
                        Token(SyntaxKind.StaticKeyword)))
                    .WithParameterList (ParseParameterList (
                        string.Format ("({0} value)", TypeInfo.Type)))
                    .WithBody (Block (
                        ReturnStatement (
                            ObjectCreationExpression (
                                ParseTypeName (DeclaringMember.ManagedName))
                            .WithInitializer (InitializerExpression (
                                SyntaxKind.ObjectInitializerExpression)
                                .AddExpressions (
                                    ParseExpression ("value = value"))))));
                yield return castToOperator;

                var castFromOperator = ConversionOperatorDeclaration (
                    Token (SyntaxKind.ImplicitKeyword), TypeInfo.Type)
                    .WithModifiers (TokenList (
                        Token (SyntaxKind.PublicKeyword),
                        Token(SyntaxKind.StaticKeyword)))
                    .WithParameterList (ParseParameterList (
                        string.Format ("({0} value)",
                            ParseTypeName (DeclaringMember.ManagedName))))
                    .WithBody (Block (
                        ReturnStatement (
                            ParseExpression ("value.value"))));
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
                    return LiteralExpression (SyntaxKind.TrueLiteralExpression);
                case "false":
                    return LiteralExpression (SyntaxKind.FalseLiteralExpression);
                default:
                    throw new Exception (string.Format ("Unknown bool constant value '{0}'.", value));
                }
            case "byte":
            case "System.Byte":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (byte.Parse (value)));
            case "sbyte":
            case "System.SByte":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (sbyte.Parse (value)));
            case "short":
            case "System.Int16":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (short.Parse (value)));
            case "ushort":
            case "System.UInt16":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (ushort.Parse (value)));
            case "int":
            case "System.Int32":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (int.Parse (value)));
            case "uint":
            case "System.Uint32":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (uint.Parse (value)));
            case "long":
            case "System.Int64":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (long.Parse (value)));
            case "ulong":
            case "System.UInt64":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (ulong.Parse (value)));
            case "float":
            case "System.Float":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (float.Parse (value)));
            case "double":
            case "System.Double":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (double.Parse (value)));
            case "string":
            case "System.String":
                return LiteralExpression (SyntaxKind.StringLiteralExpression,
                    Literal (value));
            default:
                var message = string.Format ("Bad constant type: {0}", managedType);
                throw new Exception (message);
            }
        }
    }
}
