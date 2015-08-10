// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using GISharp.Core;
using System.Text;

namespace GISharp.GI
{
    /// <summary>
    /// GIBaseInfo is the common base struct of all other *Info classes.
    /// </summary>
    [DebuggerDisplay ("{Namespace}.{Name}")]
    public class BaseInfo : IEquatable<BaseInfo>, IDisposable
    {
        public IntPtr Handle { get; private set; }

        internal static T MarshalPtr<T> (IntPtr raw, bool owned = true) where T : BaseInfo
        {
            if (raw == IntPtr.Zero) {
                return null;
            }
            if (!owned) {
                g_base_info_ref (raw);
            }
            Type type = typeof(BaseInfo);
            switch ((InfoType)g_base_info_get_type (raw)) {
            case InfoType.Arg:
                type = typeof(ArgInfo);
                break;
            case InfoType.Boxed:
                // TODO: could be struct or union
                type = typeof(StructInfo);
                break;
            case InfoType.Callback:
                type = typeof(CallbackInfo);
                break;
            case InfoType.Constant:
                type = typeof(ConstantInfo);
                break;
            case InfoType.Enum:
            case InfoType.Flags:
                type = typeof(EnumInfo);
                break;
            case InfoType.Field:
                type = typeof(FieldInfo);
                break;
            case InfoType.Function:
                type = typeof(FunctionInfo);
                break;
            case InfoType.Interface:
                type = typeof(InterfaceInfo);
                break;
            case InfoType.Object:
                type = typeof(ObjectInfo);
                break;
            case InfoType.Property:
                type = typeof(PropertyInfo);
                break;
            case InfoType.Signal:
                type = typeof(SignalInfo);
                break;
            case InfoType.Struct:
                type = typeof(StructInfo);
                break;
            case InfoType.Type:
                type = typeof(TypeInfo);
                break;
            case InfoType.Union:
                type = typeof(UnionInfo);
                break;
            case InfoType.Unresolved:
                type = typeof(UnresolvedInfo);
                break;
            case InfoType.Value:
                type = typeof(ValueInfo);
                break;
            case InfoType.VFunc:
                type = typeof(VFuncInfo);
                break;
            }
            return (T)Activator.CreateInstance (type, new object[] { raw });
        }

        /// <summary>
        /// Gets all attributes associated with this node.
        /// </summary>
        /// <value>The attributes.</value>
        public IEnumerable<KeyValuePair<string, string>> Attributes {
            get {
                AttributeIter iter = AttributeIter.Zero;
                string key, value;
                while (IterateAttributes (ref iter, out key, out value)) {
                    yield return new KeyValuePair<string, string> (key, value);
                }
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_base_info_equal (IntPtr raw, IntPtr info2);

        #region IEquatable implementation

        public bool Equals (BaseInfo other)
        {
            if (this == null && other == null) {
                return true;
            }
            if (other != null) {
                return g_base_info_equal (Handle, other.Handle);
            }
            return false;
        }

        #endregion

        public override bool Equals (object obj)
        {
            return Equals (obj as BaseInfo);
        }

        public override int GetHashCode ()
        {
            return Handle.GetHashCode ();
        }

        public static bool operator == (BaseInfo info1, BaseInfo info2)
        {
            if ((object)info1 == null) {
                return (object)info2 == null;
            }
            if ((object)info2 == null) {
                return false;
            }
            return info1.Equals (info2);
        }

        public static bool operator != (BaseInfo info1, BaseInfo info2)
        {
            return !(info1 == info2);
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_attribute (IntPtr raw, IntPtr name);

        /// <summary>
        /// Retrieve an arbitrary attribute associated with this node.
        /// </summary>
        /// <returns>The attribute or <c>null</c> if no such attribute exists.</returns>
        /// <param name="name">Name.</param>
        public string GetAttribute (string name)
        {
            IntPtr native_name = MarshalG.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_base_info_get_attribute (Handle, native_name);
            string ret = MarshalG.Utf8PtrToString (raw_ret);
            MarshalG.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_container (IntPtr raw);

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container or <c>null</c>.</value>
        /// <remarks>
        /// The container is the parent <see cref="BaseInfo"/>. For instance, the
        /// parent of a <see cref="FunctionInfo"/> is an <see cref="ObjectInfo"/>
        /// or <see cref="InterfaceInfo"/>.
        /// </remarks>
        public GISharp.GI.BaseInfo Container {
            get {
                IntPtr raw_ret = g_base_info_get_container (Handle);
                GISharp.GI.BaseInfo ret = MarshalPtr<GISharp.GI.BaseInfo> (raw_ret, false);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_name (IntPtr raw);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name or <c>null</c>.</value>
        /// <remarks>
        /// What the name represents depends on the <see cref="InfoType"/> of the
        /// info . For instance for <see cref="FunctionInfo"/> it is the name of
        /// the function.
        /// </remarks>
        public string Name {
            get {
                // calling g_base_info_get_name on a TypeInfo will cause a crash.
                var typeInfo = this as TypeInfo;
                if (typeInfo != null) {
                    return null;
                }
                IntPtr raw_ret = g_base_info_get_name (Handle);
                return MarshalG.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_namespace (IntPtr raw);

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        /// <value>The namespace.</value>
        public string Namespace {
            get {
                IntPtr raw_ret = g_base_info_get_namespace (Handle);
                string ret = MarshalG.Utf8PtrToString (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_base_info_get_type (IntPtr raw);

        /// <summary>
        /// Gets the info type of the BaseInfo.
        /// </summary>
        /// <value>The info type.</value>
        public InfoType InfoType {
            get {
                int raw_ret = g_base_info_get_type (Handle);
                GISharp.GI.InfoType ret = (GISharp.GI.InfoType)raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_base_info_is_deprecated (IntPtr raw);

        /// <summary>
        /// Gets a value indicating whether this instance is deprecated or not.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        public bool IsDeprecated {
            get {
                bool raw_ret = g_base_info_is_deprecated (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_base_info_iterate_attributes (IntPtr raw, ref AttributeIter iterator, out IntPtr name, out IntPtr value);

        bool IterateAttributes (ref AttributeIter iterator, out string name, out string value)
        {
            IntPtr native_name;
            IntPtr native_value;
            bool ret = g_base_info_iterate_attributes (Handle, ref iterator, out native_name, out native_value);
            name = MarshalG.Utf8PtrToString (native_name);
            value = MarshalG.Utf8PtrToString (native_value);
            return ret;
        }

        public BaseInfo (IntPtr raw)
        {
            Handle = raw;
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_ref (IntPtr raw);

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_base_info_unref (IntPtr raw);

        ~BaseInfo ()
        {
            Dispose (false);
        }

        #region IDisposable implementation

        public void Dispose ()
        {
            Dispose (true);
        }

        #endregion

        protected virtual void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                var oldHandle = Handle;
                Handle = IntPtr.Zero;
                g_base_info_unref (oldHandle);
            }
        }

        public override string ToString ()
        {
            var builder = new StringBuilder ();
            var current = this;
            while (current != null) {
                if (current.Name != null) {
                    builder.Insert (0, current.Name);
                    builder.Insert (0, ".");
                }
                builder.Insert (0, current.InfoType);
                builder.Insert (0, ".");
                current = current.Container;
            }
            return string.Format ("{0}{1}", Namespace, builder);
        }
    }
}
