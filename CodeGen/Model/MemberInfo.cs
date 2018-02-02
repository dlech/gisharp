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
        /// <summary>
        /// Gets the identifier for this member
        /// </summary>
        public SyntaxToken Identifier => _Identifier.Value;
        readonly Lazy<SyntaxToken> _Identifier;

        /// <summary>
        /// Gets the qualified name for this member
        /// </summary>
        public QualifiedNameSyntax QualifiedName => _QualifiedName.Value;
        readonly Lazy<QualifiedNameSyntax> _QualifiedName;

        /// <summary>
        /// Gets the access modifiers for this member
        /// </summary>
        public SyntaxTokenList Modifiers => _Modifiers.Value;
        readonly Lazy<SyntaxTokenList> _Modifiers;

        /// <summary>
        /// Gets the list of all child member declarations for this member
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> AllDeclarations => _AllDeclarations.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _AllDeclarations;

        protected MemberInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            _Identifier = new Lazy<SyntaxToken>(() => Identifier(ManagedName));
            _QualifiedName = new Lazy<QualifiedNameSyntax>(GetQualifiedName);
            _Modifiers = new Lazy<SyntaxTokenList>(() => TokenList(GetModifiers()));
            _AllDeclarations = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetAllDeclarations()));
        }

        protected virtual IEnumerable<SyntaxToken> GetModifiers ()
        {
            // default value is "public" unless "access-modifiers" attribute is present
            var accessModifierAttr = Element.Attribute (gs + "access-modifiers");
            var tokens = ParseTokens (accessModifierAttr?.Value ?? "public");
            return tokens;
        }
        QualifiedNameSyntax GetQualifiedName()
        {
            var name = QualifiedName(NamespaceInfo.Name, IdentifierName(Identifier));

            // callbacks can be declared by fields, in which case they are a child type.
            var declaringType = DeclaringMember.DeclaringMember as TypeDeclarationInfo;
            if (declaringType != null) {
                name = QualifiedName(QualifiedName(name.Left, IdentifierName(declaringType.Identifier)), name.Right);
            }

            return name;
        }

        protected abstract IEnumerable<MemberDeclarationSyntax> GetAllDeclarations();
    }
}
