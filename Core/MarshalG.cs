using System;
using System.Collections.Generic;
using System.Linq;
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
        [DllImport ("glib-2.0.dll")]
        extern static IntPtr g_malloc (UIntPtr nBytes);

        /// <summary>
        /// Allocates unmanaged memory using g_malloc.
        /// </summary>
        /// <param name="size">Size in bytes.</param>
        /// <exception cref="ArgumentException">If size is less than 0.</exception>
        public static IntPtr Alloc (int size)
        {
            if (size < 0) {
                throw new ArgumentException ("Size must be >= 0", "size");
            }
            return g_malloc ((UIntPtr)(uint)size);
        }

        [DllImport ("glib-2.0.dll")]
        extern static void g_free (IntPtr ptr);

        /// <summary>
        /// Free the specified pointer with g_free.
        /// </summary>
        /// <param name="ptr">Pointer to an unmanaged data structure.</param>
        /// <remarks>
        /// The pointer being freed must have been allocated using g_malloc.
        /// Also, there is no need to check for IntPtr.Zero.
        /// </remarks>
        public static void Free (IntPtr ptr)
        {
            g_free (ptr);
        }

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
        /// Marshals a C string pointer to a byte array.
        /// </summary>
        /// <returns>The string as a byte array.</returns>
        /// <param name="ptr">Pointer to the unmanaged string.</param>
        /// <param name="freePtr">If set to <c>true</c> free the unmanaged memory.</param>
        /// <remarks>
        /// Since encoding is not specified, the string is retuned as a byte array.
        /// The byte array does not include the null terminator.
        /// </remarks>
        public static byte[] PtrToByteString (IntPtr ptr, bool freePtr = false)
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
            return bytes.ToArray ();
        }

        /// <summary>
        /// Marshals a managed byte array to a C string.
        /// </summary>
        /// <returns>A pointer to the unmanaged string.</returns>
        /// <param name="bytes">The managed byte array.</param>
        /// <remarks>
        /// The returned pointer should be freed by calling <see cref="Free"/>.
        /// The byte array should not include the null terminator. It will be
        /// added automatically.
        /// </remarks>
        public static IntPtr ByteStringToPtr (byte[] bytes)
        {
            if (bytes == null) {
                return IntPtr.Zero;
            }
            var ptr = g_malloc (new UIntPtr ((ulong)bytes.Length + 1));
            Marshal.Copy (bytes, 0, ptr, bytes.Length);
            Marshal.WriteByte (ptr, bytes.Length, 0);
            return ptr;
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
            return Encoding.UTF8.GetString (PtrToByteString (ptr, freePtr));
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
            return ByteStringToPtr (Encoding.UTF8.GetBytes (str));
        }

        [DllImport ("glib-2.0.dll")]
        static extern IntPtr g_filename_to_utf8 (IntPtr opsysstring, IntPtr len, IntPtr bytesRead, out UIntPtr bytesWritten, out IntPtr error);

        public static string FilenamePtrToString (IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            UIntPtr bytesWritten;
            IntPtr error;
            var utf8Ptr = g_filename_to_utf8 (ptr, (IntPtr)(-1), IntPtr.Zero, out bytesWritten, out error);
            if (freePtr) {
                g_free (ptr);
            }
            if (error != IntPtr.Zero) {
                throw new GErrorException (error);
            }
            return Utf8PtrToString (utf8Ptr, freePtr: true);
        }

        [DllImport ("glib-2.0.dll")]
        static extern IntPtr g_filename_from_utf8 (IntPtr utf8string, IntPtr len, IntPtr bytesRead, out UIntPtr bytesWritten, out IntPtr error);

        public static IntPtr StringToFilenamePtr (string str)
        {
            if (str == null) {
                return IntPtr.Zero;
            }
            var utf8Ptr = StringToUtf8Ptr (str);
            UIntPtr bytesWritten;
            IntPtr error;
            var ret = g_filename_from_utf8 (utf8Ptr, (IntPtr)(-1), IntPtr.Zero, out bytesWritten, out error);
            g_free (utf8Ptr);
            if (error != IntPtr.Zero) {
                throw new GErrorException (error);
            }
            return ret;
        }

        public static string[] GStrvPtrToStringArray (IntPtr ptr, bool freePtr = false, bool freeElements = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var strings = new List<string> ();
            IntPtr current;
            var offset = 0;
            while ((current = Marshal.ReadIntPtr (ptr, offset)) != IntPtr.Zero) {
                strings.Add (Utf8PtrToString (current));
                if (freeElements) {
                    g_free (current);
                }
                offset += IntPtr.Size;
            }
            if (freePtr) {
                g_free (ptr);
            }
            return strings.ToArray ();
        }

        public static IntPtr StringArrayToGStrvPtr (string[] strings)
        {
            if (strings == null) {
                return IntPtr.Zero;
            }
            if (strings.Any (s => s == null)) {
                throw new ArgumentException ("All array elements must be non-null.", "strings");
            }
            var ptr = Alloc ((strings.Length + 1) * IntPtr.Size);
            var offset = 0;
            foreach (var str in strings) {
                Marshal.WriteIntPtr (ptr, offset, StringToUtf8Ptr (str));
                offset += IntPtr.Size;
            }
            Marshal.WriteIntPtr (ptr, offset, IntPtr.Zero);
            return ptr;
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
