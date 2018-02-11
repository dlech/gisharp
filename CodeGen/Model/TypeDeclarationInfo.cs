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

        List<TypeDeclarationInfo> _NestedTypeInfos;
        public IReadOnlyList<TypeDeclarationInfo> NestedTypeInfos {
            get {
                if (_NestedTypeInfos == null) {
                    _NestedTypeInfos = GetNestedTypeInfos ().ToList ();
                }
                return _NestedTypeInfos.AsReadOnly ();
            }
        }

        /// <summary>
        /// Gets a list of constant declarations for this type
        /// </summary>
        public IReadOnlyList<ConstantInfo> ConstantInfos => _ConstantInfos.Value;
        readonly Lazy<IReadOnlyList<ConstantInfo>> _ConstantInfos;

        /// <summary>
        /// Gets a list of field declarations for this type
        /// </summary>
        public IReadOnlyList<FieldInfo> FieldInfos => _FieldInfos.Value;
        readonly Lazy<IReadOnlyList<FieldInfo>> _FieldInfos;

        List<PropertyInfo> _PropertyInfos;
        public IReadOnlyList<PropertyInfo> PropertyInfos {
            get {
                if (_PropertyInfos == null) {
                    _PropertyInfos = GetPropertyInfos ().ToList ();
                }
                return _PropertyInfos.AsReadOnly ();
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

        List<MethodInfo> _VirtualMethodInfos;
        public IReadOnlyList<MethodInfo> VirtualMethodInfos {
            get {
                if (_VirtualMethodInfos == null) {
                    _VirtualMethodInfos = GetVirtualMethodInfos ().ToList ();
                }
                return _VirtualMethodInfos.AsReadOnly ();
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

        public string GTypeStruct {
            get {
                return Element.Attribute (glib + "type-struct").AsString ();
            }
        }

        /// <summary>
        /// Gets GType-specific member declarations (e.g. glib:get-type)
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> GTypeMembers => _GTypeMembers.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _GTypeMembers;

        protected TypeDeclarationInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (!Fixup.ElementsThatDefineAType.Contains (element.Name)) {
                throw new ArgumentException ("Requires <gi:alias>, <gi:record>, <gi:union>, <gi:interface>, <gi:class>, <gs:static-class> or <gi:callback> element.", nameof(element));
            }
            _ConstantInfos = new Lazy<IReadOnlyList<ConstantInfo>>(() => GetConstantInfos().ToList().AsReadOnly());
            _FieldInfos = new Lazy<IReadOnlyList<FieldInfo>>(() => GetFieldInfos().ToList().AsReadOnly());
            _GTypeMembers = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetGTypeMembers()));
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return NestedTypeInfos.Cast<BaseInfo> ().Concat (FieldInfos).Concat (MethodInfos);
        }

        IEnumerable<TypeDeclarationInfo> GetNestedTypeInfos ()
        {
            foreach (var record in Element.Elements (gi + "record")) {
                yield return new StructInfo (record, this);
            }
        }

        IEnumerable<ConstantInfo> GetConstantInfos ()
        {
            return Element.Elements(gi + "constant").Select(x => new ConstantInfo(x, this));
        }

        IEnumerable<FieldInfo> GetFieldInfos ()
        {
            return Element.Elements(gi + "field").Select(x => new FieldInfo(x, this));
        }

        IEnumerable<PropertyInfo> GetPropertyInfos ()
        {
            foreach (var property in Element.Elements (gi + "property")) {
                yield return new PropertyInfo (property, this);
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

        IEnumerable<MethodInfo> GetVirtualMethodInfos ()
        {
            foreach (var method in Element.Elements (gi + "virtual-method")) {
                yield return new MethodInfo (method, this);
            }
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            return base.GetAttributeLists ().Union (GetTypeDeclarationAttributeLists ());
        }

        IEnumerable<AttributeListSyntax> GetTypeDeclarationAttributeLists ()
        {
            // If a type is a GType, then decorate it with the GTypeAttribute
            if (IsGType) {
                var nameArgument = string.Format ("\"{0}\"", GTypeName);
                var registerArgument = string.Format (
                    "{0} = true",
                    nameof (GISharp.Runtime.GTypeAttribute.IsProxyForUnmanagedType));
                yield return AttributeList ().AddAttributes (
                    Attribute (ParseName (typeof (GISharp.Runtime.GTypeAttribute).FullName))
                    .AddArgumentListArguments(
                        AttributeArgument (ParseExpression (nameArgument)),
                        AttributeArgument (ParseExpression(registerArgument))));
            }

            // If a type has an associate GType struct, decorate it with the GTypeStructAttribute
            if (GTypeStruct != null) {
                var typeArgument = GirType.ResolveType (GTypeStruct, Element.Document);
                yield return AttributeList ().AddAttributes (
                    Attribute (ParseName (typeof(GISharp.Runtime.GTypeStructAttribute).FullName))
                        .AddArgumentListArguments (
                            AttributeArgument (ParseExpression ($"typeof({typeArgument.FullName})"))));
            }
        }

        IEnumerable<MemberDeclarationSyntax> GetGTypeMembers()
        {
            if (IsGType) {
                // emits: static readonly GType _GType = xxx_get_type();
                var getGType = Element.Attribute(glib + "get-type").AsString();
                var typeName = typeof(GISharp.GObject.GType).FullName;
                yield return FieldDeclaration(VariableDeclaration(ParseTypeName(typeName))
                        .AddVariables(VariableDeclarator(ParseToken("_GType"))
                            .WithInitializer(EqualsValueClause(ParseExpression($"{getGType}()")))))
                    .WithModifiers(TokenList(Token(StaticKeyword), Token(ReadOnlyKeyword)));
            }
        }
    }
}
