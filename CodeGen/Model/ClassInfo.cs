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
    public class ClassInfo : TypeDeclarationInfo
    {
        BaseListSyntax _BaseList;
        public BaseListSyntax BaseList {
            get {
                if (_BaseList == default(BaseListSyntax)) {
                    var types = SyntaxFactory.SeparatedList<BaseTypeSyntax> ();
                    var opaqueTypeName = Element.Attribute (gs + "opaque")?.Value;
                    if (opaqueTypeName != null) {
                        switch (opaqueTypeName) {
                        case "ref-counted":
                            opaqueTypeName = typeof(GISharp.Core.ReferenceCountedOpaque<>).FullName;
                            break;
                        case "owned":
                            opaqueTypeName = typeof(GISharp.Core.OwnedOpaque<>).FullName;
                            break;
                        case "static":
                            opaqueTypeName = typeof(GISharp.Core.StaticOpaque<>).FullName;
                            break;
                        default:
                            var message = string.Format ("Unknown oqaue type '{0}.", opaqueTypeName);
                            throw new Exception (message);
                        }
                        opaqueTypeName= opaqueTypeName.Remove (opaqueTypeName.IndexOf ('`'));
                        // TODO: use full name with namespace instead of ManagedName
                        opaqueTypeName = string.Format ("{0}<{1}>", opaqueTypeName, ManagedName);
                        var baseType = SyntaxFactory.ParseTypeName (opaqueTypeName);
                        types = types.Add (SyntaxFactory.SimpleBaseType (baseType));
                    }
                    // TODO: add parent type for objects
                    // TODO: add interfaces for objects
                    if (MethodInfos.Any (x => x.IsEquals)) {
                        var typeName = string.Concat (typeof(IEquatable<>).FullName.TakeWhile (x => x != '`'));
                        typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                        types = types.Add (SyntaxFactory.SimpleBaseType (SyntaxFactory.ParseTypeName (typeName)));
                    }
                    if (MethodInfos.Any (x => x.IsCompare)) {
                        var typeName = string.Concat (typeof(IComparable<>).FullName.TakeWhile (x => x != '`'));
                        typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                        types = types.Add (SyntaxFactory.SimpleBaseType (SyntaxFactory.ParseTypeName (typeName)));
                    }
                    _BaseList = SyntaxFactory.BaseList (types);
                }
                return _BaseList;
            }
        }
        public ClassInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "object" && element.Name != gi + "record" && element.Name != gs + "static-class") {
                throw new ArgumentException ("Requires <object>, <record> or <static-class> element.", nameof(element));
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
                yield return SyntaxFactory.Token (SyntaxKind.StaticKeyword);
            }
            yield return SyntaxFactory.Token (SyntaxKind.PartialKeyword);
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var classDeclaration = SyntaxFactory.ClassDeclaration (Identifier)
                .WithAttributeLists (AttributeLists)
                .WithModifiers (Modifiers)
                .WithMembers (TypeMembers)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            if (BaseList.Types.Any ()) {
                classDeclaration = classDeclaration.WithBaseList (BaseList);
            }
            yield return classDeclaration;
        }
    }
}
