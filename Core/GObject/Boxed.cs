using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GObject
{
    static class Boxed
    {
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_boxed_copy (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType boxedType,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr srcBoxed);

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
        public static IntPtr Copy (GType boxedType, IntPtr srcBoxed)
        {
            var ret = g_boxed_copy (boxedType, srcBoxed);
            return ret;
        }

        /// <summary>
        /// Free the boxed structure @boxed which is of type @boxed_type.
        /// </summary>
        /// <param name="boxedType">
        /// The type of @boxed.
        /// </param>
        /// <param name="boxed">
        /// The boxed structure to be freed.
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_boxed_free (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType boxedType,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr boxed);

        /// <summary>
        /// Free the boxed structure @boxed which is of type @boxed_type.
        /// </summary>
        /// <param name="boxedType">
        /// The type of @boxed.
        /// </param>
        /// <param name="boxed">
        /// The boxed structure to be freed.
        /// </param>
        public static void Free (GType boxedType, IntPtr boxed)
        {
            g_boxed_free (boxedType, boxed);
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_boxed_type_register_static (IntPtr name,
            NativeBoxedCopyFunc boxedCopy,
            NativeBoxedFreeFunc boxedFree);

        public static GType Register (string name, NativeBoxedCopyFunc boxedCopy, NativeBoxedFreeFunc boxedFree)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            if (boxedCopy == null) {
                throw new ArgumentNullException (nameof (boxedCopy));
            }
            if (boxedFree == null) {
                throw new ArgumentNullException (nameof (boxedFree));
            }
            var name_ = MarshalG.StringToUtf8Ptr (name);
            return g_boxed_type_register_static (name_, boxedCopy, boxedFree);
        }

        public static IntPtr CopyManagedType (IntPtr boxed)
        {
            if (boxed == IntPtr.Zero) {
                return IntPtr.Zero;
            }
            var target = GCHandle.FromIntPtr (boxed).Target;
            return GCHandle.ToIntPtr (GCHandle.Alloc (target));
        }

        public static void FreeManagedType (IntPtr boxed)
        {
            if (boxed == IntPtr.Zero) {
                return;
            }
            GCHandle.FromIntPtr (boxed).Free ();
        }
    }

    /// <summary>
    /// This function is provided by the user and should produce a copy
    /// of the passed in boxed structure.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate IntPtr NativeBoxedCopyFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr boxed);

    /// <summary>
    /// This function is provided by the user and should free the boxed
    /// structure passed.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeBoxedFreeFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr boxed);
}
