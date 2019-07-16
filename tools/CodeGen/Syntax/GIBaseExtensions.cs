using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class GIBaseExtensions
    {
        /// <summary>
        /// Adds member declaration attributes (such as [Since]) to a declaration
        /// </summary>
        public static SyntaxList<AttributeListSyntax> GetCommonAttributeLists(this GIBase member)
        {
            var list = List<AttributeListSyntax>();

            // Translate GIR "deprecated" annotation to .NET ObsoleteAttribute
            // and possibly a GISharp DeprecatedSinceAttribute

            if (member.IsDeprecated) {
                var attr = Attribute(ParseName(typeof(ObsoleteAttribute).FullName));

                // if there is a "doc-deprecated" annotation, use it as the
                // message parameter of ObsoleteAttribute

                if (member.DocDeprecated != null) {
                    var arg = AttributeArgument(LiteralExpression(StringLiteralExpression,
                        Literal(member.DocDeprecated.Text)));
                    attr = attr.AddArgumentListArguments(arg);
                }

                list = list.Add(AttributeList().AddAttributes(attr));

                // translate the "deprecated-version" annotation to a DeprecatedSinceAttribute

                if (member.DeprecatedVersion != null) {
                    var arg = AttributeArgument(LiteralExpression(StringLiteralExpression,
                        Literal(member.DeprecatedVersion)));
                    var attr2 = Attribute(ParseName(typeof(DeprecatedSinceAttribute).FullName))
                        .AddArgumentListArguments(arg);
                    list = list.Add(AttributeList().AddAttributes(attr2));
                }
            }

            // If there is a "version" GIR annotation, convert it to a GISharp SinceAttribute

            if (member.Version != null) {
                var attrName = ParseName(typeof(GISharp.Runtime.SinceAttribute).FullName);
                var arg = AttributeArgument(LiteralExpression(StringLiteralExpression,
                    Literal(member.Version)));
                var attr = Attribute(attrName).AddArgumentListArguments(arg);

                list = list.Add(AttributeList().AddAttributes(attr));
            }

            return list;
        }

        internal static SyntaxTokenList GetCommonAccessModifiers(this GIBase member)
        {
            var list = TokenList();

            if (member.AccessModifiers == null) {
                list = list.Add(Token(PublicKeyword));
            }
            else {
                list = list.AddRange(member.AccessModifiers.Split(" ").Select(x => ParseToken(x)));
            }

            return list;
        }

        internal static void LogException(this GIBase member, Exception ex)
        {
            Log.Warning($"Problem with {member.Element.GetXPath()}: {ex.Message}");
        }
    }
}
