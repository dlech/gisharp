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
        SyntaxToken? _Identifier;
        public SyntaxToken Identifier {
            get {
                if (!_Identifier.HasValue) {
                    _Identifier = Identifier (ManagedName);
                }
                return _Identifier.Value;
            }
        }

        QualifiedNameSyntax _QualifiedName;
        public QualifiedNameSyntax QualifiedName {
            get {
                if (_QualifiedName == null) {
                    _QualifiedName = QualifiedName (
                        NamespaceInfo.Name,
                        IdentifierName (Identifier));
                    // callbacks can be declared by fields, in which case they
                    // are a child type.
                    var declaringType = DeclaringMember.DeclaringMember as TypeDeclarationInfo;
                    if (declaringType != null) {
                        _QualifiedName = QualifiedName (
                            QualifiedName (
                                _QualifiedName.Left,
                                IdentifierName (declaringType.Identifier)),
                            _QualifiedName.Right);
                    }
                }
                return _QualifiedName;
            }
        }

        SyntaxTokenList? _Modifiers;
        public SyntaxTokenList Modifiers {
            get {
                if (!_Modifiers.HasValue) {
                    _Modifiers = TokenList (GetModifiers ());
                }
                return _Modifiers.Value;
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
            // default value is "public" unless "access-modifiers" attribute is present
            var accessModifierAttr = Element.Attribute (gs + "access-modifiers");
            var tokens = ParseTokens (accessModifierAttr?.Value ?? "public");
            return tokens;
        }

        protected abstract IEnumerable<MemberDeclarationSyntax> GetDeclarations ();
    }
}
