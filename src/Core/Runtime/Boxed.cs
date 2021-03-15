// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// A mechanism to wrap opaque C structures registered by the type system
    /// </summary>
    [GType("GBoxed", IsProxyForUnmanagedType = true)]
    public abstract unsafe class Boxed : Opaque
    {
        static readonly GType _GType = GType.Boxed;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Boxed(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Provide a copy of a boxed structure @src_boxed which is of type @boxed_type.
        /// </summary>
        /// <param name="boxedType">
        /// The type of @src_boxed.
        /// </param>
        /// <param name="srcBoxed">
        /// The boxed structure to be copied.
        /// </param>
        /// <returns>
        /// The newly created copy of the boxed structure.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:full */
        private protected static extern IntPtr g_boxed_copy(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType boxedType,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr srcBoxed);

        /// <summary>
        /// Free the boxed structure @boxed which is of type @boxed_type.
        /// </summary>
        /// <param name="boxedType">
        /// The type of @boxed.
        /// </param>
        /// <param name="boxed">
        /// The boxed structure to be freed.
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        private protected static extern void g_boxed_free(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType boxedType,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr boxed);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern GType g_boxed_type_register_static(byte* name,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr> boxedCopy,
            delegate* unmanaged[Cdecl]<IntPtr, void> boxedFree);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private protected static IntPtr CopyManagedType(IntPtr boxed)
        {
            try {
                if (boxed == IntPtr.Zero) {
                    return IntPtr.Zero;
                }
                var target = GCHandle.FromIntPtr(boxed).Target;
                return GCHandle.ToIntPtr(GCHandle.Alloc(target));
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private protected static void FreeManagedType(IntPtr boxed)
        {
            try {
                if (boxed == IntPtr.Zero) {
                    return;
                }
                GCHandle.FromIntPtr(boxed).Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }

    /// <summary>
    /// Type for boxing managed (non-GType) types for passing to unmanaged code.
    /// </summary>
    [GType(IsProxyForUnmanagedType = true)]
    public sealed unsafe class Boxed<T> : Boxed
    {
        static GType GetGType()
        {
            var name = typeof(Boxed<T>).GetGTypeName();
            GType.AssertGTypeName(name);
            using var utf8 = (Utf8)name;
            return g_boxed_type_register_static((byte*)utf8.Take(), &CopyManagedType, &FreeManagedType);
        }

        static readonly GType _GType = GetGType();

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boxed(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                this.handle = g_boxed_copy(_GType, handle);
            }
        }

        static IntPtr New(T obj)
        {
            return (IntPtr)GCHandle.Alloc(obj);
        }

        /// <summary>
        /// Creates a new boxed wrapper around a managed object.
        /// </summary>
        /// <param name="obj">
        /// The managed object.
        /// </param>
        public Boxed(T obj) : base(New(obj))
        {
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_boxed_free(_GType, handle);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the managed instance wrapped by this boxed instance.
        /// </summary>
        public T Value => (T)GCHandle.FromIntPtr(UnsafeHandle).Target!;
    }
}
