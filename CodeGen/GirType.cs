using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Core;

namespace GISharp.CodeGen
{
    public class GirType : Type
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

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

        public static Type GetType (string typeName, XDocument document)
        {
            var type = GetType (typeName);
            if (type != null) {
                return type;
            }
            type = GetType (Assembly.CreateQualifiedName (Assembly.GetAssembly (typeof(IWrappedNative)).FullName, typeName));
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
                genericArgs = typeName.Remove(typeName.Length - 1).Substring (typeName.IndexOf ('[') + 1).Split (',')
                    .Select (x => GirType.GetType (x, document))
                    .ToArray ();
                typeName = typeName.Remove (typeName.IndexOf ('[') + 1) + "]";
                type = GetType (typeName, document);
            }

            switch (typeName) {
            case "GLib.List":
                type = typeof(GISharp.Core.List<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(IWrappedNative);
                }
                break;
            case "GLib.SList":
                type = typeof(GISharp.Core.SList<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(IWrappedNative);
                }
                break;
            case "GLib.HashTable":
                type = typeof(GISharp.Core.HashTable<,>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(IWrappedNative);
                }
                if (genericArgs[1] == typeof(IntPtr)) {
                    genericArgs[1] = typeof(IWrappedNative);
                }
                break;
            case "GLib.Array":
                type = typeof(GISharp.Core.Array<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(IWrappedNative);
                }
                break;
            case "GLib.PtrArray":
                type = typeof(GISharp.Core.PtrArray<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(IWrappedNative);
                }
                break;
            case "GLib.ByteArray":
                type = typeof(GISharp.Core.ByteArray);
                isGeneric = false;
                break;
            case "CompareDataFunc":
            case "CompareDataFuncNative":
                type = typeof(GISharp.Core.CompareDataFuncNative);
                break;
            case "CompareFunc":
            case "CompareFuncNative":
                type = typeof(GISharp.Core.CompareFuncNative);
                break;
            case "CopyFunc":
            case "CopyFuncNative":
                type = typeof(GISharp.Core.CopyFuncNative);
                break;
            case "DestoryNotify":
            case "DestoryNotifyNative":
                type = typeof(GISharp.Core.DestroyNotifyNative);
                break;
            case "EqualFunc":
            case "EqualFuncNative":
                type = typeof(GISharp.Core.EqualFuncNative);
                break;
            case "Func":
            case "FuncNative":
                type = typeof(GISharp.Core.FuncNative);
                break;
            case "HashFunc":
            case "HashFuncNative":
                type = typeof(GISharp.Core.HashFuncNative);
                break;
            case "HFunc":
            case "HFuncNative":
                type = typeof(GISharp.Core.HFuncNative);
                break;
            case "HRFunc":
            case "HRFuncNative":
                type = typeof(GISharp.Core.HRFuncNative);
                break;
            }

            if (type == null) {
                XElement typeDefinitionElement = null;
                if (!girTypeCache.TryGetValue (typeName, out typeDefinitionElement)) {
                    var unqualifiedTypeName = typeName.Split ('.').Last ();
                    typeDefinitionElement = document.Descendants ()
                        .Where (d => Fixup.ElementsThatDefineAType.Contains (d.Name))
                        .SingleOrDefault (d => d.Attribute (gs + "managed-name").Value == unqualifiedTypeName);
                    if (typeDefinitionElement == null) {
                        // special case for callbacks since there is a "Native" version of each of those as well.
                        typeDefinitionElement = document.Descendants (gi + "callback")
                            .SingleOrDefault (d => d.Attribute (gs + "managed-name").Value + "Native" == unqualifiedTypeName);
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

            var message = string.Format ("Failed to get type for '{0}'.", typeName);
            Console.Error.WriteLine (message);

            return null;
        }

        public static IEnumerable<GirType> GetTypes (XDocument document)
        {
            return document.Element (gi + "repository").Element (gi + "namespace").Elements ()
                .Where (e => Fixup.ElementsThatDefineAType.Contains (e.Name))
                .Select (e => new GirType (e));
        }

        public override IList<CustomAttributeData> GetCustomAttributesData ()
        {
            return element.GetCustomAttributes (false).ToList ();
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
            throw new NotImplementedException ();
        }

        public override object[] GetCustomAttributes (bool inherit)
        {
            if (inherit) {
                throw new NotImplementedException ();
            }
            return element.GetCustomAttributes (false).ToArray ();
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override string Name {
            get {
                return element.Attribute (gs + "managed-name").Value;
            }
        }

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface (string name, bool ignoreCase)
        {
            throw new NotImplementedException ();
        }

        public override Type[] GetInterfaces ()
        {
            throw new NotImplementedException ();
        }

        public override Type GetElementType ()
        {
            throw new NotImplementedException ();
        }

        public override EventInfo GetEvent (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override EventInfo[] GetEvents (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override FieldInfo GetField (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override FieldInfo[] GetFields (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override MemberInfo[] GetMembers (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        protected override MethodInfo GetMethodImpl (string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        public override MethodInfo[] GetMethods (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override Type GetNestedType (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override Type[] GetNestedTypes (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override PropertyInfo[] GetProperties (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        protected override PropertyInfo GetPropertyImpl (string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        protected override ConstructorInfo GetConstructorImpl (BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        protected override TypeAttributes GetAttributeFlagsImpl ()
        {
            throw new NotImplementedException ();
        }

        protected override bool HasElementTypeImpl ()
        {
            // TODO: This should return true if this is an array, pointer or reference type
            return false;
        }

        protected override bool IsArrayImpl ()
        {
            throw new NotImplementedException ();
        }

        protected override bool IsByRefImpl ()
        {
            return false;
        }

        protected override bool IsCOMObjectImpl ()
        {
            throw new NotImplementedException ();
        }

        protected override bool IsPointerImpl ()
        {
            throw new NotImplementedException ();
        }

        protected override bool IsPrimitiveImpl ()
        {
            return false;
        }

        public override ConstructorInfo[] GetConstructors (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override object InvokeMember (string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new NotImplementedException ();
        }

        public override Assembly Assembly {
            get {
                return Assembly.GetExecutingAssembly ();
            }
        }

        public override string AssemblyQualifiedName {
            get {
                throw new NotImplementedException ();
            }
        }

        public override Type BaseType {
            get {
                // <class> elements have <parent>
                var parentAttribute = element.Attribute ("parent");
                if (parentAttribute != null) {
                    return GetType (parentAttribute.Value, element.Document);
                }
                if (element.Name == gi + "record") {
                    var opaqueAttr = element.Attribute (gs + "opaque");
                    if (opaqueAttr != null) {
                        switch (opaqueAttr.Value) {
                        case "ref-counted":
                            return typeof(ReferenceCountedOpaque<>).MakeGenericType (this);
                        case "owned":
                            return typeof(OwnedOpaque<>).MakeGenericType (this);
                        case "static":
                            return typeof(StaticOpaque<>).MakeGenericType (this);
                        default:
                            var message = string.Format ("Unknown opaque type '{0}'.",
                                          opaqueAttr.Value);
                            throw new Exception (message);
                        }
                    }
                    // this indicates a struct
                    return typeof(ValueType);
                }
                if (element.Name == gi + "alias") {
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
                throw new NotImplementedException ();
            }
        }

        public override Module Module {
            get {
                throw new NotImplementedException ();
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
                return BaseType.UnderlyingSystemType;
            }
        }

        #endregion
    }
}

