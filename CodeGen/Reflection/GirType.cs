using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Runtime;
using System.Reflection.Emit;
using GISharp.Lib.GObject;
using GISharp.Lib.GLib;

namespace GISharp.CodeGen.Reflection
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
        readonly bool unmanaged;


        /// <summary>
        /// Creates a new type based on GIR XML data
        /// </summary>
        /// <param name="element">
        /// A GIR XML element that defines a type
        /// </param>
        /// <param name="unmanaged">
        /// Special flag for callback types indicating whether to use the
        /// managed or unmanaged metadata.
        /// </param>
        public GirType(XElement element, bool unmanaged)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (!Fixup.ElementsThatDefineAType.Contains (element.Name)) {
                throw new ArgumentException ("Requires a type definition element.", nameof(element));
            }
            this.element = element;
            this.unmanaged = unmanaged;
            _Module = new Lazy<Module>(() => new GirModule(element.Ancestors(gi + "repository").Single()), false);
        }

        /// <summary>
        /// Resolves a GIR type node to the cooresponding .NET type
        /// </summary>
        public static Type ResolveManagedType(Gir.GIType node)
        {
            if (node.ParentNode is Gir.Field field) {
                if (field.Callback != null) {
                    return new GirType(field.Callback.Element, true);
                }
            }

            var typeName = node.ManagedName;
            if (!typeName.Contains('.')) {
                typeName = $"GISharp.Lib.{node.Namespace.Name}.{typeName}";
            }

            if (node.TypeParameters.Any()) {
                if (typeName == typeof(Strv).ToString()) {
                    return typeof(Strv);
                }
                if (typeName == typeof(FilenameArray).ToString()) {
                    return typeof(FilenameArray);
                }
                if (typeName == typeof(IArray<>).ToString()) {
                    return typeof(IArray<>).MakeGenericType(ResolveManagedType(node.TypeParameters.Single()));
                }
                throw new NotImplementedException();
            }

            var type = GetType(typeName);
            if (type != null) {
                // TODO: handle interfaces
                return type;
            }

            var typeNode = node.Namespace.AllTypes.Single(x => x.GirName == node.GirName);
            return new GirType(typeNode.Element, false);
        }

        /// <summary>
        /// Resolves a GIR type node to the cooresponding .NET type
        /// </summary>
        public static Type ResolveUnmanagedType(Gir.GIType node)
        {
            if (node.ParentNode is Gir.Field field) {
                if (field.Callback != null) {
                    return new GirType(field.Callback.Element, true);
                }
            }

            var typeName = node.GirName;
            switch (typeName) {
                // basic/fundamental types
                case "none":
                    return typeof(void);
                case "gboolean":
                    return typeof(bool);
                case "gchar":
                case "gint8":
                    return typeof(sbyte);
                case "guchar":
                case "guint8":
                    return typeof(byte);
                case "gshort":
                case "gint16":
                    return typeof(short);
                case "gushort":
                case "guint16":
                    return typeof(ushort);
                case "gunichar2":
                    return typeof(char);
                case "gint":
                case "gint32":
                    return typeof(int);
                case "guint":
                case "guint32":
                case "gunichar":
                    return typeof(uint);
                case "glong":
                    return typeof(NativeLong);
                case "gulong":
                    return typeof(NativeULong);
                case "gint64":
                case "goffset":
                    return typeof(long);
                case "guint64":
                    return typeof(ulong);
                case "gfloat":
                    return typeof(float);
                case "gdouble":
                    return typeof(double);
                case "gpointer":
                case "gconstpointer":
                case "gintptr":
                case "gssize":
                case "filename":
                case "utf8":
                // we get null for C arrays
                case null:
                    return typeof(IntPtr);
                case "guintptr":
                case "gsize":
                    return typeof(UIntPtr);
                case "GType":
                    return typeof(GType);
                case "va_list":
                    // va_list should be filtered out, but just in case...
                    throw new NotSupportedException("va_list is not supported");
            }

            if (!typeName.Contains('.')) {
                typeName = $"{node.Namespace.Name}.{typeName}";
            }
            typeName = $"GISharp.Lib.{typeName}";

            var isDelegate = false;

            if (node.ParentNode is Gir.GIArg arg) {
                isDelegate = arg.Scope != null;
            }

            if (isDelegate) {
                if (typeName == "GISharp.Lib.GObject.Callback") {
                    return typeof(IntPtr);
                }
                var index = typeName.LastIndexOf('.') + 1;
                typeName = typeName.Substring(0, index) + "Unmanaged" + typeName.Substring(index);
            }

            if (node.IsPointer) {
                return typeof(IntPtr);
            }

            // assuming this is a value type
            var type = GetType(typeName);
            if (type != null) {
                // TODO: handle delegates
                return type;
            }

            var typeNode = node.Namespace.AllTypes.Single(x => x.GirName == node.GirName);
            return new GirType(typeNode.Element, true);
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
                type = typeof(GISharp.Lib.GLib.List<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.SList":
                type = typeof(GISharp.Lib.GLib.SList<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.HashTable":
                type = typeof(GISharp.Lib.GLib.HashTable<,>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                if (genericArgs[1] == typeof(IntPtr)) {
                    genericArgs[1] = typeof(Opaque);
                }
                break;
            case "GLib.Array":
                type = typeof(GISharp.Lib.GLib.Array<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.PtrArray":
                type = typeof(GISharp.Lib.GLib.PtrArray<>);
                if (genericArgs[0] == typeof(IntPtr)) {
                    genericArgs[0] = typeof(Opaque);
                }
                break;
            case "GLib.ByteArray":
                type = typeof(GISharp.Lib.GLib.ByteArray);
                isGeneric = false;
                break;
            case "GLib.Quark":
                type = typeof(GISharp.Lib.GLib.Quark);
                break;
            }

            if (type == null) {
                var unqualifiedTypeName = typeName.Split ('.').Last ();
                if (!girTypeCache.TryGetValue(typeName, out var typeDefinitionElement)) {
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
                    type = new GirType(typeDefinitionElement, unqualifiedTypeName.StartsWith("Unmanaged"));
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
                .SelectMany(e => GetTypesForElement(e));
        }

        static IEnumerable<GirType> GetTypesForElement(XElement element)
        {
            yield return new GirType(element, false);
            if (element.Name == gi + "callback") {
                yield return new GirType(element, true);
            }
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

        public override bool IsSZArray => false;

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
                if (unmanaged && this.IsDelegate()) {
                    name = "Unmanaged" + name;
                }

                return name;
            }
        }

        public override bool IsSubclassOf(Type c)
        {
            if (c == null) {
                throw new ArgumentNullException(nameof(c));
            }

            var baseType = BaseType;
            while (baseType != null) {
                if (c == baseType) {
                    return true;
                }
                baseType = baseType.BaseType;
            }

            return c.IsAssignableFrom(this);
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
            // TODO: create GirFunctionInfo and GirMethodInfo and return them as well
            return element.Elements(gi + "virtual-method").Select(x => new GirVirtualMethodInfo(x))
                .ToArray();
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

        protected override bool HasElementTypeImpl() => false;

        protected override bool IsArrayImpl() => false;

        protected override bool IsByRefImpl() => false;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => false;

        protected override bool IsPrimitiveImpl() => false;

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
                    if (element.Attribute(gs + "source").AsBool()) {
                        return typeof(Source);
                    }
                    var opaqueAttr = element.Attribute (gs + "opaque");
                    if (opaqueAttr != null) {
                        switch (opaqueAttr.Value) {
                        case "boxed":
                            return typeof(Boxed);
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
                    return typeof(System.Enum);
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

        public override string ToString() => FullName;

        public override Guid GUID {
            get {
                throw new InvalidOperationException ();
            }
        }

        public override bool IsConstructedGenericType => false;

        public override Module Module => _Module.Value;
        readonly Lazy<Module> _Module;

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
