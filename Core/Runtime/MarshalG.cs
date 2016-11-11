using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace GISharp.Runtime
{
    /// <summary>
    /// Helper functions for marshaling GLib data structures.
    /// </summary>
    public static class MarshalG
    {
        [DllImport ("glib-2.0.dll")]
        extern static IntPtr g_malloc (UIntPtr nBytes);

        /// <summary>
        /// Allocates <paramref name="size"/> bytes of memory.
        /// If <paramref name="size"/> is 0 it returns <c>IntPtr.Zero</c>.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <exception cref="ArgumentException">If size is less than 0.</exception>
        public static IntPtr Alloc (int size)
        {
            if (size < 0) {
                throw new ArgumentException ("Size must be >= 0", "size");
            }
            return g_malloc ((UIntPtr)(uint)size);
        }

        [DllImport ("glib-2.0.dll")]
        extern static IntPtr g_malloc0 (UIntPtr nBytes);

        /// <summary>
        /// Allocates <paramref name="size"/> bytes of memory, initialized to 0's.
        /// If <paramref name="size"/> is 0 it returns <c>IntPtr.Zero</c>.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <exception cref="ArgumentException">If size is less than 0.</exception>
        public static IntPtr Alloc0 (int size)
        {
            if (size < 0) {
                throw new ArgumentException ("Size must be >= 0", "size");
            }
            return g_malloc0 ((UIntPtr)(uint)size);
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
            var bytes = new System.Collections.Generic.List<byte> ();
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

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_locale_to_utf8 (IntPtr opsysstring, IntPtr len, UIntPtr bytesRead, UIntPtr bytesWritten, IntPtr error);

        /// <summary>
        /// Marshals a char* in the system locale to a managed string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="ptr">Pointer to the unmanaged string.</param>
        /// <param name="freePtr">If set to <c>true</c> free the pointer.</param>
        public static string LocalePtrToString (IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            // FIXME: There are a couple of problems here. Using -1 for length
            // can cause problems if the locale allows null bytes in the string.
            // Also, we should throw an exception if there is an error.
            var utf8Ptr = g_locale_to_utf8 (ptr, new IntPtr (-1), UIntPtr.Zero, UIntPtr.Zero, IntPtr.Zero);
            if (freePtr) {
                Free (ptr);
            }
            return Utf8PtrToString (utf8Ptr, true);
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
                throw GErrorException.CreateInstance (error);
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
                throw GErrorException.CreateInstance (error);
            }
            return ret;
        }

        public static string[] GStrvPtrToStringArray (IntPtr ptr, bool freePtr = false, bool freeElements = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var strings = new System.Collections.Generic.List<string> ();
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

        [DllImport ("glib-2.0.dll")]
        extern static void g_strfreev (IntPtr list);

        /// <summary>
        /// Frees an unmanaged null terminated string array (GStrv).
        /// </summary>
        /// <param name="ptr">Pointer to the unmanaged array.</param>
        public static void FreeGStrv (IntPtr ptr)
        {
            g_strfreev (ptr);
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
            var ret = new System.Collections.Generic.List<string> ();
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
            var ret = new System.Collections.Generic.List<string> ();
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

        /// <summary>
        /// Marshals a C-style array from unmanged memory to managed memory.
        /// </summary>
        /// <returns>The managed array.</returns>
        /// <param name="ptr">Pointer to the unmanged array.</param>
        /// <param name="length">The length of the array or null if the array is null-terminated.</param>
        /// <param name="freePtr">Setting to <c>true</c> will call g_free() on <paramref name="ptr"/>.</param>
        /// <typeparam name="T">The array element type.</typeparam>
        public static T[] PtrToCArray<T> (IntPtr ptr, int? length, bool freePtr = false) where T : struct
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            T[] array;
            var elementSize = Marshal.SizeOf (typeof(T));
            if (length.HasValue) {
                array = new T[length.Value];
                var current = ptr;
                for (int i = 0; i < array.Length; i++) {
                    array[i] = Marshal.PtrToStructure<T> (current);
                    current += elementSize;
                }
            } else {
                var list = new System.Collections.Generic.List<T> ();
                T item;
                var current = ptr;
                while (!(item = Marshal.PtrToStructure<T> (current)).Equals (default(T))) {
                    list.Add (item);
                    current += elementSize;
                }
                array = list.ToArray ();
            }
            if (freePtr) {
                Free (ptr);
            }

            return array;
        }

        /// <summary>
        /// Marshalls an array of structs to unmanged memory.
        /// </summary>
        /// <returns>The pointer to the array in unmanged memory.</returns>
        /// <param name="array">The managed array.</param>
        /// <param name="nullTerminated">Set to <c>true</c> to make the array null-terminated<./param>
        /// <exception cref="NotSupportedException">
        /// Thrown if array element type is not a value type
        /// </exception>
        public static IntPtr CArrayToPtr<T> (T[] array, bool nullTerminated) where T : struct
        {
            if (array == null) {
                return IntPtr.Zero;
            }
            var elementSize = Marshal.SizeOf<T> ();
            var ptr = Alloc ((array.Length + (nullTerminated ? 1 : 0)) * elementSize);
            var current = ptr;
            for (int i = 0; i < array.Length; i++) {
                Marshal.StructureToPtr (array.GetValue (i), current, false);
                current += elementSize;
            }
            if (nullTerminated) {
                Marshal.StructureToPtr (default(T), current, false);
            }
            return ptr;
        }

        public static T[] PtrToOpaqueCArray<T> (IntPtr ptr, int? length, bool freePtr = false) where T : Opaque
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            T[] array;
            if (length.HasValue) {
                array = new T[length.Value];
                for (int i = 0; i < array.Length; i++) {
                    var handle = Marshal.ReadIntPtr (ptr, i * IntPtr.Size);
                    array[i] = Opaque.GetInstance<T> (handle, Transfer.None);
                }
            } else {
                var list = new System.Collections.Generic.List<T> ();
                IntPtr handle;
                var current = ptr;
                while ((handle = Marshal.ReadIntPtr (current)) != IntPtr.Zero) {
                    var item = Opaque.GetInstance<T> (handle, Transfer.None);
                    list.Add (item);
                    current += IntPtr.Size;
                }
                array = list.ToArray ();
            }
            if (freePtr) {
                Free (ptr);
            }

            return array;
        }

        public static IntPtr OpaqueCArrayToPtr<T> (T[] array, bool nullTerminated) where T : Opaque
        {
            if (array == null) {
                return IntPtr.Zero;
            }
            var ptr = Alloc ((array.Length + (nullTerminated ? 1 : 0)) * IntPtr.Size);
            for (int i = 0; i < array.Length; i++) {
                Marshal.WriteIntPtr (ptr, i * IntPtr.Size, array[i].Handle);
            }
            if (nullTerminated) {
                Marshal.WriteIntPtr (ptr, array.Length * IntPtr.Size, IntPtr.Zero);
            }
            return ptr;
        }
    }
}
