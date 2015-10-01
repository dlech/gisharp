using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public abstract class MemberInfo : BaseInfo
    {
        SyntaxToken _Identifier;
        public SyntaxToken Identifier {
            get {
                if (_Identifier == default(SyntaxToken)) {
                    _Identifier = Identifier (ManagedName);
                }
                return _Identifier;
            }
        }

        SyntaxTokenList _Modifiers;
        public SyntaxTokenList Modifiers {
            get {
                if (_Modifiers == default(SyntaxTokenList)) {
                    _Modifiers = TokenList (GetModifiers ());
                }
                return _Modifiers;
            }
        }

        List<MemberDeclarationSyntax> _Declarations;
        public IReadOnlyList<MemberDeclarationSyntax> Declarations {
            get {
                if (_Declarations == null) {
                    _Declarations = GetDeclarations ().ToList ();
                }
                return _Declarations.AsReadOnly ();
            }
        }

        protected MemberInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
        }

        protected virtual IEnumerable<SyntaxToken> GetModifiers ()
        {
            // default value is "public" unless "access-modifier" attribute is present
            var accessModifierAttr = Element.Attribute (gs + "access-modifier");
            var tokens = ParseTokens (accessModifierAttr?.Value ?? "public");
            return tokens;
        }

        protected abstract IEnumerable<MemberDeclarationSyntax> GetDeclarations ();
    }
}
