// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
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

                if (member.DocDeprecated is not null) {
                    var arg = AttributeArgument(LiteralExpression(StringLiteralExpression,
                        Literal(member.DocDeprecated.Text)));
                    attr = attr.AddArgumentListArguments(arg);
                }

                list = list.Add(AttributeList().AddAttributes(attr));

                // translate the "deprecated-version" annotation to a DeprecatedSinceAttribute

                if (member.DeprecatedVersion is not null) {
                    var arg = AttributeArgument(LiteralExpression(StringLiteralExpression,
                        Literal(member.DeprecatedVersion)));
                    var attr2 = Attribute(ParseName(typeof(DeprecatedSinceAttribute).FullName))
                        .AddArgumentListArguments(arg);
                    list = list.Add(AttributeList().AddAttributes(attr2));
                }
            }

            // If there is a "version" GIR annotation, convert it to a GISharp SinceAttribute

            if (member.Version is not null) {
                var attrName = ParseName(typeof(SinceAttribute).FullName);
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

            if (member.AccessModifiers is null) {
                list = list.Add(Token(PublicKeyword));
            }
            else {
                list = list.AddRange(member.AccessModifiers.Split(" ").Select(x => ParseToken(x)));
            }

            return list;
        }

        internal static SyntaxTokenList GetInheritanceModifiers(this GIBase member, SyntaxToken? @default)
        {
            if (member.InheritanceModifiers is null) {
                if (@default.HasValue) {
                    return TokenList(@default.Value);
                }
                return TokenList();
            }
            return TokenList(ParseTokens(member.InheritanceModifiers));
        }

        private static readonly ILogger logger = Globals.LoggerFactory.CreateLogger("Generator");

        internal static void LogException(this GIBase member, Exception ex)
        {
            logger.LogWarning("Problem with {XPath}: {ExceptionMessage}", member.Element.GetXPath(), ex.Message);
            logger.LogDebug("{StackTrace}", ex.StackTrace);
        }
    }
}
