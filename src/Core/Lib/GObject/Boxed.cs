using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A mechanism to wrap opaque C structures registered by the type system
    /// </summary>
    [GType("GBoxed", IsProxyForUnmanagedType = true)]
    public abstract class Boxed : Opaque
    {
        static readonly GType _GType = GType.Boxed;

        readonly GType gType;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Boxed(GType gType, IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (!gType.IsA(GType.Boxed)) {
                this.handle = IntPtr.Zero;
                throw new ArgumentException("GType does not inherit from GBoxed", nameof(gType));
            }
            if (ownership == Transfer.Container) {
                this.handle = IntPtr.Zero;
                throw new NotSupportedException("Don't know how to handle containers yet");
            }
            this.gType = gType;
            if (ownership == Transfer.None) {
                this.handle = g_boxed_copy(gType, handle);
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_boxed_free(gType, handle);
            }
            base.Dispose(disposing);
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
        static extern IntPtr g_boxed_copy(
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
        static extern void g_boxed_free(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType boxedType,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr boxed);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern GType g_boxed_type_register_static(IntPtr name,
            UnmanagedBoxedCopyFunc boxedCopy,
            UnmanagedBoxedFreeFunc boxedFree);

    }

    /// <summary>
    /// Type for boxing managed (non-GType) types for passing to unmanaged code.
    /// </summary>
    [GType(IsProxyForUnmanagedType = true)]
    public sealed class Boxed<T> : Boxed
    {
        static GType GetGType()
        {
            var name = typeof(Boxed<T>).GetGTypeName();
            GType.AssertGTypeName(name);
            using var utf8 = (Utf8)name;
            UnmanagedBoxedCopyFunc boxedCopy = CopyManagedType;
            UnmanagedBoxedFreeFunc boxedFree = FreeManagedType;
            // these are never freed
            GCHandle.Alloc(boxedCopy);
            GCHandle.Alloc(boxedFree);
            return g_boxed_type_register_static(utf8.Handle, boxedCopy, boxedFree);
        }
        static readonly GType _GType = GetGType();

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boxed(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
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
        public Boxed(T obj) : base(_GType, New(obj), Transfer.Full)
        {
        }

        /// <summary>
        /// Gets the managed instance wrapped by this boxed instance.
        /// </summary>
        public T Value => (T)GCHandle.FromIntPtr(Handle).Target!;

        static IntPtr CopyManagedType(IntPtr boxed)
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
                return IntPtr.Zero;
            }
        }

        static void FreeManagedType(IntPtr boxed)
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
    /// This function is provided by the user and should produce a copy
    /// of the passed in boxed structure.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate IntPtr UnmanagedBoxedCopyFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr boxed);

    /// <summary>
    /// This function is provided by the user and should free the boxed
    /// structure passed.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void UnmanagedBoxedFreeFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr boxed);
}
