using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

using GISharp.Runtime;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
using GISharp.Lib.GLib;
using System.Threading.Tasks;

namespace GISharp.CodeGen.Reflection
{
    abstract class GirType : System.Type
    {
        readonly GIRegisteredType type;

        /// <summary>
        /// Creates a new type based on GIR XML data
        /// </summary>
        /// <param name="element">
        /// A GIR XML element that defines a type
        /// </param>
        protected GirType(GIRegisteredType type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            _Module = new Lazy<Module>(() => new GirModule(type.Namespace), false);
        }

        /// <summary>
        /// Resolves a GIR type node to the cooresponding .NET type
        /// </summary>
        public static System.Type ResolveManagedType(Gir.GIType node)
        {
            if (node.ParentNode is Gir.Field field) {
                if (field.Callback != null) {
                    return new GirDelegateType(field.Callback, true);
                }
            }

            var typeName = node.ManagedName;

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
                if (typeName == typeof(Task).ToString()) {
                    System.Type tupleType;
                    switch (node.TypeParameters.Count()) {
                    case 1:
                        return typeof(Task<>).MakeGenericType(ResolveManagedType(node.TypeParameters.Single()));
                    case 2:
                        tupleType = typeof(ValueTuple<,>);
                        break;
                    case 3:
                        tupleType = typeof(ValueTuple<,,>);
                        break;
                    case 4:
                        tupleType = typeof(ValueTuple<,,,>);
                        break;
                    case 5:
                        tupleType = typeof(ValueTuple<,,,,>);
                        break;
                    case 6:
                        tupleType = typeof(ValueTuple<,,,,,>);
                        break;
                    case 7:
                        tupleType = typeof(ValueTuple<,,,,,,>);
                        break;
                    case 8:
                        tupleType = typeof(ValueTuple<,,,,,,,>);
                        break;
                    default:
                        throw new NotSupportedException("ValueTuple only supports up to 8 type parameters");
                    }

                    return typeof(Task<>).MakeGenericType(tupleType.MakeGenericType(node.TypeParameters
                        .Select(x => ResolveManagedType(x)).ToArray()));
                }
                throw new NotImplementedException();
            }

            // if there is no '.', then this type must be declared in the GIR namespace
            if (!typeName.Contains('.')) {
                var typeNode = node.Namespace.AllTypes.SingleOrDefault(x => x.GirName == node.GirName);
                if (typeNode == null) {
                    // OK, maybe it is defined in the Core assembly
                    typeName = $"GISharp.Lib.{node.Namespace.Name}.{typeName}";
                }
                else {
                    if (typeNode is Alias alias) {
                        return new GirAliasType(alias);
                    }
                    if (typeNode is Class @class) {
                        return new GirClassType(@class);
                    }
                    if (typeNode is Interface @interface) {
                        return new GirInterfaceType(@interface);
                    }
                    if (typeNode is Record record) {
                        return new GirRecordType(record);
                    }
                    if (typeNode is GIEnum @enum) {
                        return new GirEnumType(@enum);
                    }
                    if (typeNode is Callback callback) {
                        return new GirDelegateType(callback, false);
                    }
                    throw new NotSupportedException("Unknown GIR node type");
                }
            }

            // otherwise, the type is declared in another assembly
            var type = GetType(typeName);
            if (type != null) {
                if (type.IsAbstract && type.IsSealed) {
                    // if we got a static class, it must be the extension class
                    // for an interface.
                    var index = typeName.LastIndexOf('.') + 1;
                    typeName = typeName.Substring(0, index) + "I" + typeName.Substring(index);
                    type = GetType(typeName);
                    if (type != null) {
                        return type;
                    }
                    throw new TypeNotFoundException(typeName);
                }
                return type;
            }

            throw new TypeNotFoundException(typeName);
        }

        /// <summary>
        /// Resolves a GIR type node to the cooresponding .NET type
        /// </summary>
        public static System.Type ResolveUnmanagedType(Gir.GIType node)
        {
            if (node.ParentNode is Gir.Field field) {
                if (field.Callback != null) {
                    return new GirDelegateType(field.Callback, true);
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
                    return typeof(CLong);
                case "gulong":
                    return typeof(CULong);
                case "gint64":
                case "goffset":
                    return typeof(long);
                case "guint64":
                    return typeof(ulong);
                case "gfloat":
                    return typeof(float);
                case "gdouble":
                    return typeof(double);
                case "gintptr":
                case "gssize":
                    return typeof(IntPtr);
                case "guintptr":
                case "gsize":
                    return typeof(UIntPtr);
                case "GType":
                    return typeof(GType);
                case "gpointer":
                case "gconstpointer":
                case "filename":
                case "utf8":
                // we get null for C arrays
                case null:
                    return typeof(IntPtr);
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

            // assuming this is a value type
            var type = GetType(typeName);
            if (type != null) {
                if (type.IsValueType) {
                    return type;
                }
                if (type.IsDelegate()) {
                    return type;
                }
                return typeof(IntPtr);
            }

            if (node.GirName.EndsWith("Private")) {
                return typeof(IntPtr);
            }

            var typeNode = node.Namespace.AllTypes.SingleOrDefault(x => x.GirName == node.GirName);
            if (typeNode == null) {
                throw new TypeNotFoundException(node.GirName);
            }
            var girType = default(System.Type);
            if (typeNode is Alias alias) {
                girType = new GirAliasType(alias);
            }
            else if (typeNode is GIEnum @enum) {
                girType = new GirEnumType(@enum);
            }
            else if (typeNode is Record record) {
                if (record.GTypeName != null || record.IsDisguised) {
                    return typeof(IntPtr);
                }
                girType = new GirRecordType(record);
            }
            else if (typeNode is Callback callback) {
                return new GirDelegateType(callback, true);
            }
            else if (typeNode is Class || typeNode is Interface) {
                return typeof(IntPtr);
            }

            if (girType == null) {
                throw new NotSupportedException($"Unknown GIR node type: {typeNode.GetType().Name}");
            }
 
            return girType;
        }

        public static System.Type ResolveParentType(Class @class)
        {
            var typeName = @class.Parent;
            if (!typeName.Contains('.')) {
                var match = @class.Namespace.Classes.SingleOrDefault(x => x.GirName == typeName);
                if (match != null) {
                    return new GirClassType(match);
                }
                typeName = $"{@class.Namespace.Name}.{typeName}";
            }
            typeName = $"GISharp.Lib.{typeName}";

            var type = GetType(typeName);
            if (type != null) {
                return type;
            }

            throw new TypeNotFoundException(typeName);
        }

        public static System.Type ResolvePrerequisiteType(Prerequisite prerequisite)
        {
            var typeName = prerequisite.GirName;
            if (!typeName.Contains('.')) {
                var @interface = (Interface)prerequisite.ParentNode;
                var @namespace = @interface.Namespace;
                var match = @namespace.Interfaces.SingleOrDefault(x => x.GirName == typeName);
                if (match != null) {
                    return new GirInterfaceType(match);
                }
                var @class = @namespace.Classes.SingleOrDefault(x => x.GirName == typeName);
                if (@class != null) {
                    return typeof(GInterface<>).MakeGenericType(new GirClassType(@class));
                }
                typeName = $"{@namespace.Name}.{typeName}";
            }
            typeName = $"GISharp.Lib.{typeName}";

            var type = GetType(typeName);
            if (type != null) {
                return type;
            }

            throw new TypeNotFoundException(typeName);
        }

        public override System.Type MakeGenericType(params System.Type[] typeArguments)
        {
            return new GirGenericType(this, typeArguments);
        }

        public override System.Type MakePointerType() => new GirPointerType(this);

        #region implemented abstract members of MemberInfo

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override bool IsSZArray => false;

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override string Name {
            get {
                // strip off generic parameters
                var name = string.Concat(type.ManagedName.TakeWhile(x => x != '['));
                return name;
            }
        }

        public override bool IsSubclassOf(System.Type c)
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

        public override System.Type GetInterface(string name, bool ignoreCase)
        {
            throw new NotSupportedException();
        }

        public override System.Type[] GetInterfaces()
        {
            throw new NotSupportedException();
        }

        public override System.Type GetElementType()
        {
            throw new NotSupportedException();
        }

        public override EventInfo GetEvent (string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override EventInfo[] GetEvents (System.Reflection.BindingFlags bindingAttr)
        {
            return type.Signals.Select(x => new GirEventInfo(x, this)).ToArray();
        }

        public override FieldInfo GetField (string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override FieldInfo[] GetFields (System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override MemberInfo[] GetMembers (System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        protected override MethodInfo GetMethodImpl (string name, System.Reflection.BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        public override MethodInfo[] GetMethods (System.Reflection.BindingFlags bindingAttr)
        {
            // TODO: create GirFunctionInfo and GirMethodInfo and return them as well
            return type.VirtualMethods.Select(x => new GirVirtualMethodInfo(x))
                .ToArray();
        }

        public override System.Type GetNestedType(string name, System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override System.Type[] GetNestedTypes(System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override PropertyInfo[] GetProperties (System.Reflection.BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        protected override PropertyInfo GetPropertyImpl(string name, System.Reflection.BindingFlags bindingAttr,
            Binder binder, System.Type returnType, System.Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override ConstructorInfo GetConstructorImpl(System.Reflection.BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override TypeAttributes GetAttributeFlagsImpl ()
        {
            var flags = default(TypeAttributes);
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
            throw new NotSupportedException();
        }

        public override object InvokeMember (string name, System.Reflection.BindingFlags invokeAttr,
            Binder binder, object target, object[] args, ParameterModifier[] modifiers,
            System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new NotSupportedException();
        }

        public override Assembly Assembly {
            get {
                return Assembly.GetExecutingAssembly ();
            }
        }

        public override string AssemblyQualifiedName {
            get {
                throw new NotSupportedException();
            }
        }

        public override System.Type BaseType => typeof(object);

        public override string FullName {
            get {
                return string.Format ("{0}.{1}", Namespace, Name);
            }
        }

        public override string ToString() => FullName;

        public override Guid GUID {
            get {
                throw new NotSupportedException();
            }
        }

        public override bool IsConstructedGenericType => false;

        public override Module Module => _Module.Value;
        readonly Lazy<Module> _Module;

        public override string Namespace {
            get {
                return string.Format ("{0}.{1}",
                    MainClass.parentNamespace,
                    type.Namespace.Name);
            }
        }

        public override System.Type UnderlyingSystemType => this;

        #endregion
    }
}
