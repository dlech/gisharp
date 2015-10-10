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
    /// <summary>
    /// Wraps elements from a fixed up .gir file that declare a class.
    /// </summary>
    public class ClassInfo : TypeDeclarationInfo
    {
        /// <summary>
        /// Indicates if this is a static class.
        /// </summary>
        /// <value><c>true</c> if this is a static class.</value>
        public bool IsStaticClass {
            get {
                return Element.Name == gs + "static-class";
            }
        }

        public bool IsGObject {
            get {
                return Element.Name == gi + "class";
            }
        }

        BaseListSyntax _BaseList;
        /// <summary>
        /// Gets the base list syntax for the class declaration.
        /// </summary>
        /// <value>The base list.</value>
        public BaseListSyntax BaseList {
            get {
                if (_BaseList == null) {
                    var types = SeparatedList<BaseTypeSyntax> ();
                    var opaqueTypeName = Element.Attribute (gs + "opaque")?.Value;
                    if (opaqueTypeName != null) {
                        switch (opaqueTypeName) {
                        case "ref-counted":
                            opaqueTypeName = typeof(GISharp.Core.ReferenceCountedOpaque).FullName;
                            break;
                        case "owned":
                            opaqueTypeName = typeof(GISharp.Core.OwnedOpaque).FullName;
                            break;
                        case "static":
                            opaqueTypeName = typeof(GISharp.Core.StaticOpaque).FullName;
                            break;
                        default:
                            var message = string.Format ("Unknown oqaue type '{0}.", opaqueTypeName);
                            throw new Exception (message);
                        }
                        var baseType = ParseTypeName (opaqueTypeName);
                        types = types.Add (SimpleBaseType (baseType));
                    }
                    if (IsGObject) {
                        var parent = Element.Attribute ("parent")?.Value;
                        if (parent == null) {
                            types = types.Add (SimpleBaseType (
                                ParseTypeName (typeof(GISharp.Core.ReferenceCountedOpaque).FullName)));
                        } else {
                            types = types.Add (SimpleBaseType (ParseTypeName (parent)));
                        }
                        // TODO: add interfaces for objects
                    }
                    if (MethodInfos.Any (x => x.IsEquals)) {
                        var typeName = string.Concat (typeof(IEquatable<>).FullName.TakeWhile (x => x != '`'));
                        typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                        types = types.Add (SimpleBaseType (ParseTypeName (typeName)));
                    }
                    if (MethodInfos.Any (x => x.IsCompare)) {
                        var typeName = string.Concat (typeof(IComparable<>).FullName.TakeWhile (x => x != '`'));
                        typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                        types = types.Add (SimpleBaseType (ParseTypeName (typeName)));
                    }
                    _BaseList = BaseList (types);
                }
                return _BaseList;
            }
        }

        ConstructorDeclarationSyntax _DefaultConstructor;
        /// <summary>
        /// Gets the default constructor declaration syntax for the class.
        /// </summary>
        /// <value>The default constructor.</value>
        public ConstructorDeclarationSyntax DefaultConstructor {
            get {
                if (_DefaultConstructor == null) {
                    var modifiers = TokenList ()
                        .Add (Token (SyntaxKind.ProtectedKeyword));
                    var paramerList = ParseParameterList (string.Format ("({0} handle, {1} ownership)",
                        typeof(IntPtr).FullName,
                        typeof(GISharp.Core.Transfer).FullName));
                    var argList = ParseArgumentList ("(handle, ownership)");
                    var initializer = ConstructorInitializer (SyntaxKind.BaseConstructorInitializer)
                        .WithArgumentList (argList);
                    _DefaultConstructor = ConstructorDeclaration (Identifier)
                        .WithModifiers (modifiers)
                        .WithParameterList (paramerList)
                        .WithInitializer (initializer.WithLeadingTrivia (EndOfLine("\n"), Whitespace("\t")))
                        .WithBody (Block ());
                }
                return _DefaultConstructor;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassInfo"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="declaringMember">Declaring member.</param>
        /// <exception cref="ArgumentException">If the element is not an element that declares a class.</exception>
        public ClassInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "class" && element.Name != gi + "record" && element.Name != gs + "static-class") {
                throw new ArgumentException ("Requires <gi:class>, <gi:record> or <gs:static-class> element.", nameof(element));
            }
            if (element.Name == gi + "record" && element.Attribute (gs + "opaque") == null) {
                throw new ArgumentException ("<record> element must be opaque.", nameof(element));
            }
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }
            if (Element.Name == gs + "static-class") {
                yield return Token (SyntaxKind.StaticKeyword);
            }
            yield return Token (SyntaxKind.PartialKeyword);
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var classDeclaration = ClassDeclaration (Identifier)
                .WithAttributeLists (AttributeLists)
                .WithModifiers (Modifiers)
                .WithMembers (TypeMembers)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            if (BaseList.Types.Any ()) {
                classDeclaration = classDeclaration.WithIdentifier (
                    classDeclaration.Identifier.WithTrailingTrivia (EndOfLine ("\n")));
                classDeclaration = classDeclaration.WithBaseList (
                    BaseList.WithLeadingTrivia (Whitespace ("\t")));
            }
            // TODO: should probably make this optional (via xml attribute) in
            // case we need to implment manually
            if (!IsStaticClass) {
                classDeclaration = classDeclaration.AddMembers (DefaultConstructor);
            }
            yield return classDeclaration;
        }
    }
}
