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
    public class ConstantInfo : MemberInfo
    {
        /// <summary>
        /// Gets the managed type info for this constant
        /// </summary>
        public TypeInfo TypeInfo => _TypeInfo.Value;
        readonly Lazy<TypeInfo> _TypeInfo;

        public ConstantInfo(XElement element, MemberInfo declaringMember)
            : base(element, declaringMember)
        {
            if (element.Name != gi + "constant") {
                throw new ArgumentException("Requires  <constant> element.", nameof(element));
            }
            _TypeInfo = new Lazy<TypeInfo>(() => new TypeInfo(Element, true));
        }

        internal override IEnumerable<BaseInfo> GetChildInfos()
        {
            yield break;
        }

        protected override IEnumerable<SyntaxToken> GetModifiers()
        {
            return base.GetModifiers().Concat(GetConstantModifiers());
        }

        IEnumerable<SyntaxToken> GetConstantModifiers()
        {
            yield return Token(ConstKeyword);
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            var type = TypeInfo.Type;
            var variable = VariableDeclarator(ManagedName);
            var value = GetValueAsLiteralExpression();
            var equalsValueClause = EqualsValueClause(value);
            variable = variable.WithInitializer(equalsValueClause);
            if (TypeInfo.TypeObject == typeof(GISharp.GLib.Utf8)) {
                type = ParseTypeName(typeof(string).FullName);
            }
            var variableDeclaration = VariableDeclaration(type)
                .AddVariables(variable);
            var field = FieldDeclaration(variableDeclaration)
                .WithModifiers(Modifiers)
                .WithAttributeLists(AttributeLists)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
            yield return field;
        }

        LiteralExpressionSyntax GetValueAsLiteralExpression()
        {
            var managedType = Element.Attribute(gs + "managed-type")?.Value;
            if (managedType == null) {
                throw new ArgumentException("Requires element to have 'managed-type' attribute.");
            }
            var value = Element.Attribute("value")?.Value;
            if (value == null) {
                throw new ArgumentException("Requires element to have 'value' attribute.");
            }

            switch (managedType) {
            case "bool":
            case "System.Boolean":
                switch (value) {
                case "true":
                    return LiteralExpression(TrueLiteralExpression);
                case "false":
                    return LiteralExpression(FalseLiteralExpression);
                default:
                    throw new Exception(string.Format("Unknown bool constant value '{0}'.", value));
                }
            case "byte":
            case "System.Byte":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(byte.Parse(value)));
            case "sbyte":
            case "System.SByte":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(sbyte.Parse(value)));
            case "short":
            case "System.Int16":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(short.Parse(value)));
            case "ushort":
            case "System.UInt16":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(ushort.Parse(value)));
            case "int":
            case "System.Int32":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(int.Parse(value)));
            case "uint":
            case "System.Uint32":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(uint.Parse(value)));
            case "long":
            case "System.Int64":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(long.Parse(value)));
            case "ulong":
            case "System.UInt64":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(ulong.Parse(value)));
            case "float":
            case "System.Float":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(float.Parse(value)));
            case "double":
            case "System.Double":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(double.Parse(value)));
            case "string":
            case "System.String":
            case "GISharp.GLib.Utf8":
                return LiteralExpression(StringLiteralExpression,
                    Literal(value));
            default:
                var message = string.Format("Bad constant type: {0}", managedType);
                throw new Exception(message);
            }
        }
    }
}
