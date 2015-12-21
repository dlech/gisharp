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
    public abstract class TypeDeclarationInfo : MemberInfo
    {
        SyntaxToken? _InstanceIdentifier;
        public SyntaxToken InstanceIdentifier {
            get {
                if (!_InstanceIdentifier.HasValue) {
                    _InstanceIdentifier = Element.Name == gi + "alias"
                        ? Identifier("value") : Identifier ("Handle");
                }
                return _InstanceIdentifier.Value;
            }
        }

        List<FieldInfo> _FieldInfos;
        public IReadOnlyList<FieldInfo> FieldInfos {
            get {
                if (_FieldInfos == null) {
                    _FieldInfos = GetFieldInfos ().ToList ();
                }
                return _FieldInfos.AsReadOnly ();
            }
        }

        List<MethodInfo> _MethodInfos;
        public IReadOnlyList<MethodInfo> MethodInfos {
            get {
                if (_MethodInfos == null) {
                    _MethodInfos = GetMethodInfos ().ToList ();
                }
                return _MethodInfos.AsReadOnly ();
            }
        }

        SyntaxList<MemberDeclarationSyntax>? _TypeMembers;
        public SyntaxList<MemberDeclarationSyntax> TypeMembers {
            get {
                if (!_TypeMembers.HasValue) {
                    _TypeMembers = List<MemberDeclarationSyntax> ()
                        .AddRange (FieldInfos.SelectMany (x => x.Declarations))
                        .AddRange (MethodInfos.SelectMany (x => x.Declarations));
                }
                return _TypeMembers.Value;
            }
        }

        public bool IsGType {
            get {
                return Element.Attribute (glib + "get-type") != null;
            }
        }

        public string GTypeName {
            get {
                return Element.Attribute (glib + "type-name").AsString ();
            }
        }

        protected TypeDeclarationInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (!Fixup.ElementsThatDefineAType.Contains (element.Name)) {
                throw new ArgumentException ("Requires <gi:alias>, <gi:record>, <gi:union>, <gi:interface>, <gi:class>, <gs:static-class> or <gi:callback> element.", nameof(element));
            }
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return FieldInfos.Cast<BaseInfo> ().Concat (MethodInfos);
        }

        IEnumerable<FieldInfo> GetFieldInfos ()
        {
            foreach (var constant in Element.Elements (gi + "constant")) {
                yield return new FieldInfo (constant, this);
            }
            foreach (var field in Element.Elements (gi + "field")) {
                yield return new FieldInfo (field, this);
            }
        }

        IEnumerable<MethodInfo> GetMethodInfos ()
        {
            foreach (var constructor in Element.Elements (gi + "constructor")) {
                yield return new MethodInfo (constructor, this);
            }
            foreach (var function in Element.Elements (gi + "function")) {
                yield return new MethodInfo (function, this);
            }
            foreach (var method in Element.Elements (gi + "method")) {
                yield return new MethodInfo (method, this);
            }
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            return base.GetAttributeLists ().Union (GetTypeDeclarationAttributeLists ());
        }

        IEnumerable<AttributeListSyntax> GetTypeDeclarationAttributeLists ()
        {
            if (IsGType) {
                var nameArgument = string.Format (
                    "{0} = \"{1}\"",
                    nameof (GISharp.Core.GTypeAttribute.Name),
                    GTypeName);
                var registerArgument = string.Format (
                    "{0} = false",
                    nameof (GISharp.Core.GTypeAttribute.Register));
                yield return AttributeList ().AddAttributes (
                    Attribute (ParseName (typeof (GISharp.Core.GTypeAttribute).FullName))
                    .AddArgumentListArguments(
                        AttributeArgument (ParseExpression (nameArgument)),
                        AttributeArgument (ParseExpression(registerArgument))));
            }
        }
    }
}
