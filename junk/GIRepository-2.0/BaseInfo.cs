// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// GIBaseInfo is the common base struct of all other *Info classes.
    /// </summary>
    [DebuggerDisplay("{Namespace}.{Name}")]
    public abstract class BaseInfo : IEquatable<BaseInfo>, IDisposable
    {
        public IntPtr UnsafeHandle { get; private set; }

        internal static T? GetInstanceOrNull<T>(IntPtr raw, bool owned = true) where T : BaseInfo
        {
            if (raw == IntPtr.Zero) {
                return null;
            }
            return GetInstance<T>(raw, owned);
        }

        internal static T GetInstance<T>(IntPtr raw, bool owned = true) where T : BaseInfo
        {
            if (raw == IntPtr.Zero) {
                throw new ArgumentException("Null pointer", nameof(raw));
            }
            if (!owned) {
                g_base_info_ref(raw);
            }
            Type type = typeof(BaseInfo);
            switch ((InfoType)g_base_info_get_type(raw)) {
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
            return (T)Activator.CreateInstance(type, new object[] { raw })!;
        }

        /// <summary>
        /// Gets all attributes associated with this node.
        /// </summary>
        /// <value>The attributes.</value>
        public IEnumerable<KeyValuePair<string, string>> Attributes {
            get {
                AttributeIter iter = AttributeIter.Zero;
                while (IterateAttributes(ref iter, out var key, out var value)) {
                    yield return new KeyValuePair<string, string>(key, value);
                }
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_base_info_equal(IntPtr raw, IntPtr info2);

        #region IEquatable implementation

        private static bool Equal(BaseInfo? info1, BaseInfo? info2)
        {
            if (info1 is null) {
                return info2 is null;
            }
            if (info2 is null) {
                return false;
            }
            var ret_ = g_base_info_equal(info1.UnsafeHandle, info2.UnsafeHandle);
            var ret = ret_.IsTrue();
            return ret;
        }

        public bool Equals(BaseInfo? other)
        {
            return Equal(this, other);
        }

        #endregion

        public override bool Equals(object? obj)
        {
            if (obj is BaseInfo info) {
                return Equals(info);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return UnsafeHandle.GetHashCode();
        }

        public static bool operator ==(BaseInfo? info1, BaseInfo? info2)
        {
            return Equal(info1, info2);
        }

        public static bool operator !=(BaseInfo? info1, BaseInfo? info2)
        {
            return !Equal(info1, info2);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_attribute(IntPtr raw, IntPtr name);

        /// <summary>
        /// Retrieve an arbitrary attribute associated with this node.
        /// </summary>
        /// <returns>The attribute or <see cref="Utf8.Null"/> if no such attribute exists.</returns>
        /// <param name="name">Name.</param>
        public NullableUnownedUtf8 GetAttribute(UnownedUtf8 name)
        {
            var ret_ = g_base_info_get_attribute(UnsafeHandle, name.UnsafeHandle);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_container(IntPtr raw);

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container or <c>null</c>.</value>
        /// <remarks>
        /// The container is the parent <see cref="BaseInfo"/>. For instance, the
        /// parent of a <see cref="FunctionInfo"/> is an <see cref="ObjectInfo"/>
        /// or <see cref="InterfaceInfo"/>.
        /// </remarks>
        public BaseInfo? Container {
            get {
                var ret_ = g_base_info_get_container(UnsafeHandle);
                var ret = GetInstanceOrNull<BaseInfo>(ret_, false);
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_name(IntPtr raw);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name or <see cref="Utf8.Null"/>.</value>
        /// <remarks>
        /// What the name represents depends on the <see cref="InfoType"/> of the
        /// info . For instance for <see cref="FunctionInfo"/> it is the name of
        /// the function.
        /// </remarks>
        public NullableUnownedUtf8 Name {
            get {
                // calling g_base_info_get_name on a TypeInfo will cause a crash.
                if (this is TypeInfo) {
                    return Utf8.Null;
                }
                var ret_ = g_base_info_get_name(UnsafeHandle);
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_get_namespace(IntPtr raw);

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        /// <value>The namespace.</value>
        public UnownedUtf8 Namespace {
            get {
                var ret_ = g_base_info_get_namespace(UnsafeHandle);
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_base_info_get_type(IntPtr raw);

        /// <summary>
        /// Gets the info type of the BaseInfo.
        /// </summary>
        /// <value>The info type.</value>
        public InfoType InfoType {
            get {
                int raw_ret = g_base_info_get_type(UnsafeHandle);
                var ret = (InfoType)raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_base_info_is_deprecated(IntPtr raw);

        /// <summary>
        /// Gets a value indicating whether this instance is deprecated or not.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        public bool IsDeprecated {
            get {
                var ret_ = g_base_info_is_deprecated(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_base_info_iterate_attributes(IntPtr raw, ref AttributeIter iterator, out IntPtr name, out IntPtr value);

        bool IterateAttributes(ref AttributeIter iterator, out UnownedUtf8 name, out UnownedUtf8 value)
        {
            var ret_ = g_base_info_iterate_attributes(UnsafeHandle, ref iterator, out var name_, out var value_);
            var ret = ret_.IsTrue();
            name = ret ? new UnownedUtf8(name_, -1) : default!;
            value = ret ? new UnownedUtf8(value_, -1) : default!;
            return ret;
        }

        protected BaseInfo(IntPtr raw)
        {
            UnsafeHandle = raw;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_base_info_ref(IntPtr raw);

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_base_info_unref(IntPtr raw);

        ~BaseInfo()
        {
            Dispose(false);
        }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (UnsafeHandle != IntPtr.Zero) {
                var oldHandle = UnsafeHandle;
                UnsafeHandle = IntPtr.Zero;
                g_base_info_unref(oldHandle);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            BaseInfo? current = this;
            while (current is not null) {
                if (current.Name.HasValue) {
                    builder.Insert(0, current.Name.ToString());
                    builder.Insert(0, ".");
                }
                builder.Insert(0, current.InfoType);
                builder.Insert(0, ".");
                current = current.Container;
            }
            return string.Format("{0}{1}", Namespace, builder);
        }
    }
}