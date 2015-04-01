using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace GISharp.Core
{
    /// <summary>
    /// Helper functions for marshaling GLib data structures.
    /// </summary>
    public static class MarshalG
    {
        /// <summary>
        /// Marshals pointer to unmanaged stuct to an Opaque object.
        /// </summary>
        /// <returns>The to opaque object.</returns>
        /// <param name="ptr">Handle.</param>
        /// <param name="owned">If set to <c>true</c> the pointer is owned.</param>
        /// <typeparam name="T">The type to cast the pointer to.</typeparam>
        public static T PtrToReferenceCountedOpaque<T> (IntPtr ptr, bool owned) where T : ReferenceCountedOpaque<T>
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var instance = Activator.CreateInstance (typeof(T), new object[] { ptr }, null) as T;
            if (!owned) {
                instance.Ref ();
            }
            return instance;
        }

        public static T PtrToOwnedOpaque<T> (IntPtr ptr, bool owned) where T : OwnedOpaque<T>
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var instance = Activator.CreateInstance (typeof(T), new object[] { ptr }, null) as T;
            instance.Owned = owned;
            return instance;
        }

        /// <summary>
        /// Marshals a GLib UTF8 char* to a managed string.
        /// </summary>
        /// <returns>The managed string string.</returns>
        /// <param name="ptr">Pointer to the GLib string.</param>
        /// <param name="freePtr">If set to <c>true</c>, free the GLib string.</param>
        public static string Utf8PtrToString (IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var bytes = new List<byte> ();
            var offset = 0;
            while (true) {
                var b = Marshal.ReadByte (ptr, offset++);
                if (b == 0)
                    break;
                bytes.Add (b);
            }
            if (freePtr) {
                g_free (ptr);
            }
            return Encoding.UTF8.GetString (bytes.ToArray ());
        }

        /// <summary>
        /// Marshals a managed string to a GLib UTF8 char*.
        /// </summary>
        /// <returns>The to pointer to the GLib string.</returns>
        /// <param name="str">The managed string.</param>
        /// <remarks>
        /// The returned pointer should be freed by calling <see cref="Free"/>.
        /// </remarks>
        public static IntPtr StringToUtf8Ptr (string str)
        {
            if (str == null) {
                return IntPtr.Zero;
            }
            var bytes = Encoding.UTF8.GetBytes (str);
            var ptr = g_malloc (new UIntPtr ((ulong)bytes.Length + 1));
            Marshal.Copy (bytes, 0, ptr, bytes.Length);
            Marshal.WriteByte (ptr, bytes.Length, 0);
            return ptr;
        }

        public static string FilenamePtrToString (IntPtr ptr)
        {
            // TODO: use filesystem encoding
            return Utf8PtrToString (ptr);
        }

        public static IntPtr StringToFilenamePtr (string str)
        {
            // TODO: use filesystem encoding
            return StringToUtf8Ptr (str);
        }

        [StructLayout (LayoutKind.Sequential)]
        struct GList
        {
            public IntPtr Data;
            public IntPtr Next;
            public IntPtr Prev;
        }

        [DllImport ("glib-2.0.dll")]
        extern static void g_list_free (IntPtr list);

        /// <summary>
        /// Marshals a GList of strings to a managed string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="ptr">Pointer to the GList</param>
        /// <param name="freePtr">If set to <c>true</c>, frees the GList.</param>
        public static string[] GListToStringArray (IntPtr ptr, bool freePtr = false)
        {
            var ret = new List<string> ();
            var itemPtr = ptr;
            while (itemPtr != IntPtr.Zero) {
                var item = (GList)Marshal.PtrToStructure<GList> (itemPtr);
                ret.Add (Utf8PtrToString (item.Data));
                itemPtr = item.Next;
            }
            if (freePtr) {
                g_list_free (ptr);
            }
            return ret.ToArray ();
        }

        [StructLayout (LayoutKind.Sequential)]
        struct GSList
        {
            public IntPtr Data;
            public IntPtr Next;
        }

        [DllImport ("glib-2.0.dll")]
        extern static void g_slist_free (IntPtr list);

        /// <summary>
        /// Marshals a GSList of strings to a managed string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="ptr">Pointer to the GSList</param>
        /// <param name="freePtr">If set to <c>true</c>, frees the GSList.</param>
        public static string[] GSListToStringArray (IntPtr ptr, bool freePtr = false)
        {
            var ret = new List<string> ();
            var itemPtr = ptr;
            while (itemPtr != IntPtr.Zero) {
                var item = (GSList)Marshal.PtrToStructure<GSList> (itemPtr);
                ret.Add (Utf8PtrToString (item.Data));
                itemPtr = item.Next;
            }
            if (freePtr) {
                g_slist_free (ptr);
            }
            return ret.ToArray ();
        }

        [DllImport ("glib-2.0.dll")]
        extern static void g_strfreev (IntPtr list);

        /// <summary>
        /// Marshals a null terminated char** (strv) to a managed string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="ptr">Pointer to the unmanaged array.</param>
        /// <param name="freePtr">If set to <c>true</c>, frees the unmanaged array.</param>
        public static string[] NullTermPtrToStringArray (IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return new string[0];
            }
            var list = new List<string> ();
            var intPtr = Marshal.ReadIntPtr (ptr);
            var offset = 0;
            while (intPtr != IntPtr.Zero) {
                list.Add (Utf8PtrToString (intPtr));
                offset += IntPtr.Size;
                intPtr = Marshal.ReadIntPtr (ptr, offset);
            }
            if (freePtr) {
                g_strfreev (ptr);
            }
            return list.ToArray ();
        }

        [DllImport ("glib-2.0.dll")]
        extern static IntPtr g_malloc (UIntPtr ptr);

        [DllImport ("glib-2.0.dll")]
        extern static void g_free (IntPtr ptr);

        /// <summary>
        /// Free the specified pointer with g_free.
        /// </summary>
        /// <param name="ptr">Pointer to an unmanaged data structure.</param>
        /// <remarks>
        /// The pointer being freed must have been allocated using g_alloc.
        /// Also, there is no need to check for IntPtr.Zero.
        /// </remarks>
        public static void Free (IntPtr ptr)
        {
            g_free (ptr);
        }

        public static GType PtrToGType (IntPtr ptr)
        {
            throw new NotImplementedException ();
        }

        public static T PtrToGObject<T> (IntPtr ptr, bool owned) where T : GObject
        {
            throw new NotImplementedException ();
        }

        public static T PtrToGObjectInterface<T> (IntPtr ptr, bool owned)
        {
            throw new NotImplementedException ();
        }

        public static T PtrToCArray<T> (IntPtr ptr, bool owned, bool itemsOwned)
        {
            throw new NotImplementedException ();
        }

        public static IntPtr CArrayToPtr<T> (T array)
        {
            throw new NotImplementedException ();
        }

        public static T[] PtrToGList<T> (IntPtr ptr, bool owned, bool itemsOwned)
        {
            throw new NotImplementedException ();
        }
    }
}
