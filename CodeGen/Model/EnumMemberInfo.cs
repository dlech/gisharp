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
    public class EnumMemberInfo : BaseInfo
    {
        EnumMemberDeclarationSyntax _EnumMemberDeclaration;
        public EnumMemberDeclarationSyntax EnumMemberDeclaration {
            get {
                if (_EnumMemberDeclaration == default(EnumMemberDeclarationSyntax)) {
                    var literalValue = SyntaxFactory.Literal (int.Parse (Element.Attribute ("value").Value));
                    var literalExpression = SyntaxFactory.LiteralExpression (SyntaxKind.NumericLiteralExpression, literalValue);
                    var equalsValue = SyntaxFactory.EqualsValueClause (literalExpression);
                    _EnumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration (ManagedName)
                        .WithEqualsValue (equalsValue)
                        .WithAttributeLists (AttributeLists)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                }
                return _EnumMemberDeclaration;
            }
        }

        public EnumMemberInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "member") {
                throw new ArgumentException ("Requires <member> element.", nameof(element));
            }
        }
    }
}
