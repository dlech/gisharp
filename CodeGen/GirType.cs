﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Runtime;
using System.Reflection.Emit;

namespace GISharp.CodeGen
{
    public class GirType : Type
    {
        #pragma warning disable 0414 // ignore private field not used
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;
        #pragma warning restore 0414

        static readonly Dictionary<string, XElement> girTypeCache = new Dictionary<string, XElement> ();

        readonly XElement element;

        public GirType (XElement element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (!Fixup.ElementsThatDefineAType.Contains (element.Name)) {
                throw new ArgumentException ("Requires a type definition element.", nameof(element));
            }
            this.element = element;
        }

        public static Type ResolveType (string typeName, XDocument document)
        {
            var type = GetType (typeName);
            if (type != null) {
                return type;
            }

            var isArray = false;
            if (typeName.EndsWith ("[]", StringComparison.Ordinal)) {
                typeName = typeName.Remove (typeName.Length - "[]".Length);
                isArray = true;
            }
            var isGeneric = false;
            var genericArgs = default(Type[]);
            if (typeName.Contains ('`')) {
                isGeneric = true;
                genericArgs = string.Concat (typeName
                    .SkipWhile (x => x != '[')
                    .Skip (1)
                    .TakeWhile (x => x != ']'))
                    .Split (',')
                    .Select (x => ResolveType (x, document))
                    .ToArray ();
                typeName = typeName.Remove (typeName.IndexOf ('['));
                type = ResolveType (typeName, document);
            }

            switch (typeName) {
            case "GLib.List":
                type = typeof(GISharp.GLib.List<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.SList":
                type = typeof(GISharp.GLib.SList<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.HashTable":
                type = typeof(GISharp.GLib.HashTable<,>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                if (genericArgs[1] == typeof(IntPtr)) {
                    genericArgs[1] = typeof(Opaque);
                }
                break;
            case "GLib.Array":
                type = typeof(GISharp.GLib.Array<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.PtrArray":
                type = typeof(GISharp.GLib.PtrArray<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.ByteArray":
                type = typeof(GISharp.GLib.ByteArray);
                isGeneric = false;
                break;
            case "GLib.Quark":
                type = typeof(GISharp.GLib.Quark);
                break;
            }

            if (type == null) {
                XElement typeDefinitionElement;
                if (!girTypeCache.TryGetValue (typeName, out typeDefinitionElement)) {
                    var unqualifiedTypeName = typeName.Split ('.').Last ();
                    typeDefinitionElement = document.Descendants ()
                        .Where (d => Fixup.ElementsThatDefineAType.Contains (d.Name))
                        .SingleOrDefault (d => d.Attribute (gs + "managed-name").Value == unqualifiedTypeName);
                    if (typeDefinitionElement == null) {
                        // special case for callbacks since there is a "Unmanaged" version of each of those as well.
                        typeDefinitionElement = document.Descendants (gi + "callback")
                            .SingleOrDefault (d => "Unmanaged" + d.Attribute (gs + "managed-name").Value == unqualifiedTypeName);
                    }
                    if (typeDefinitionElement == null) {
                        // special case for interfaces since we add the "I" prefix.
                        typeDefinitionElement = document.Descendants (gi + "interface")
                            .SingleOrDefault (d => "I" + d.Attribute (gs + "managed-name").Value == unqualifiedTypeName);
                    }
                    if (typeDefinitionElement != null) {
                        girTypeCache.Add (typeName, typeDefinitionElement);
                    }
                }
                if (typeDefinitionElement != null) {
                    type = new GirType (typeDefinitionElement);
                }
            }

            if (type != null) {
                if (isGeneric) {
                    type = type.MakeGenericType (genericArgs);
                }
                if (isArray) {
                    type = type.MakeArrayType ();
                }
                return type;
            }

            // If we couldn't find a matching type, try adding the GISharp namespace prefix
            if (!typeName.StartsWith ($"{MainClass.parentNamespace}.", StringComparison.Ordinal)) {
                return ResolveType ($"{MainClass.parentNamespace}.{typeName}", document);
            }

            throw new TypeNotFoundException (typeName);
        }

        public static IEnumerable<GirType> GetTypes (XDocument document)
        {
            return document.Element (gi + "repository").Element (gi + "namespace").Elements ()
                .Where (e => Fixup.ElementsThatDefineAType.Contains (e.Name))
                .Select (e => new GirType (e));
        }

        public override Type MakeGenericType (params Type[] typeArguments)
        {
            return new GirGenericType (this, typeArguments);
        }

        public override Type MakeArrayType ()
        {
            return new GirArrayType (this);
        }

        #region implemented abstract members of MemberInfo

        public override bool IsDefined (Type attributeType, bool inherit)
        {
            throw new InvalidOperationException ();
        }

        public override object[] GetCustomAttributes (bool inherit)
        {
            throw new InvalidOperationException ();
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
        {
            throw new InvalidOperationException ();
        }

        public override string Name {
            get {
                // strip off generic parameters
                var name = string.Concat (element.Attribute (gs + "managed-name").Value.TakeWhile (x => x != '['));

                if (IsInterface) {
                    name = "I" + name;
                }

                return name;
            }
        }

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface (string name, bool ignoreCase)
        {
            throw new InvalidOperationException ();
        }

        public override Type[] GetInterfaces ()
        {
            throw new InvalidOperationException ();
        }

        public override Type GetElementType ()
        {
            throw new InvalidOperationException ();
        }

        public override EventInfo GetEvent (string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override EventInfo[] GetEvents (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override FieldInfo GetField (string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override FieldInfo[] GetFields (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override MemberInfo[] GetMembers (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        protected override MethodInfo GetMethodImpl (string name, System.Reflection.BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException ();
        }

        public override MethodInfo[] GetMethods (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override Type GetNestedType (string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override Type[] GetNestedTypes (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override PropertyInfo[] GetProperties (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        protected override PropertyInfo GetPropertyImpl (string name, System.Reflection.BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException ();
        }

        protected override ConstructorInfo GetConstructorImpl (System.Reflection.BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException ();
        }

        protected override TypeAttributes GetAttributeFlagsImpl ()
        {
            var flags = default(TypeAttributes);
            if (element.Name == gi + "interface") {
                flags |= TypeAttributes.Interface;
            }
            return flags;
        }

        protected override bool HasElementTypeImpl ()
        {
            return false;
        }

        protected override bool IsArrayImpl ()
        {
            return false;
        }

        protected override bool IsByRefImpl ()
        {
            return false;
        }

        protected override bool IsCOMObjectImpl ()
        {
            throw new InvalidOperationException ();
        }

        protected override bool IsPointerImpl ()
        {
            throw new InvalidOperationException ();
        }

        protected override bool IsPrimitiveImpl ()
        {
            return false;
        }

        public override ConstructorInfo[] GetConstructors (System.Reflection.BindingFlags bindingAttr)
        {
            throw new InvalidOperationException ();
        }

        public override object InvokeMember (string name, System.Reflection.BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new InvalidOperationException ();
        }

        public override Assembly Assembly {
            get {
                return Assembly.GetExecutingAssembly ();
            }
        }

        public override string AssemblyQualifiedName {
            get {
                throw new InvalidOperationException ();
            }
        }

        public override Type BaseType {
            get {
                // <class> elements have parent attribute unless they are a fundamental type
                var parentAttribute = element.Attribute ("parent");
                if (parentAttribute != null) {
                    return ResolveType (parentAttribute.Value, element.Document);
                } else if (element.Name == gi + "class") {
                    return typeof(Opaque);
                }
                if (element.Name == gi + "record") {
                    var opaqueAttr = element.Attribute (gs + "opaque");
                    if (opaqueAttr != null) {
                        switch (opaqueAttr.Value) {
                        case "owned":
                            return typeof(Opaque);
                        case "static":
                            return typeof(Opaque);
                        default:
                            var message = string.Format ("Unknown opaque type '{0}'.",
                                          opaqueAttr.Value);
                            throw new Exception (message);
                        }
                    }
                    // this indicates a struct
                    return typeof(ValueType);
                }
                if (element.Name == gi + "alias" || element.Name == gi + "union") {
                    return typeof(ValueType);
                }
                if (element.Name == gi + "enumeration" || element.Name == gi + "bitfield") {
                    return typeof(Enum);
                }
                if (element.Name == gi + "callback") {
                    return typeof(Delegate);
                }
                return typeof(object);
            }
        }

        public override string FullName {
            get {
                return string.Format ("{0}.{1}", Namespace, Name);
            }
        }

        public override Guid GUID {
            get {
                throw new InvalidOperationException ();
            }
        }

        public override Module Module {
            get {
                throw new InvalidOperationException ();
            }
        }

        public override string Namespace {
            get {
                return string.Format ("{0}.{1}",
                    MainClass.parentNamespace,
                    element.GetNamespace ());
            }
        }

        public override Type UnderlyingSystemType {
            get {
                if (element.Name == gi + "enumeration" || element.Name == gi + "bitfield") {
                    return typeof(int);
                }
                return this;
            }
        }

        #endregion
    }
}
