// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Helper functions for marshaling GLib data structures.
    /// </summary>
    public static unsafe class GMarshal
    {
        [DllImport("glib-2.0")]
        extern static IntPtr g_malloc(UIntPtr nBytes);

        /// <summary>
        /// Allocates <paramref name="size"/> bytes of memory.
        /// If <paramref name="size"/> is 0 it returns <c>IntPtr.Zero</c>.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <exception cref="ArgumentException">If size is less than 0.</exception>
        public static IntPtr Alloc(int size)
        {
            if (size < 0) {
                throw new ArgumentException("Size must be >= 0", nameof(size));
            }
            return g_malloc((UIntPtr)(uint)size);
        }

        [DllImport("glib-2.0")]
        extern static IntPtr g_malloc0(UIntPtr nBytes);

        /// <summary>
        /// Allocates <paramref name="size"/> bytes of memory, initialized to 0's.
        /// If <paramref name="size"/> is 0 it returns <c>IntPtr.Zero</c>.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <exception cref="ArgumentException">If size is less than 0.</exception>
        public static IntPtr Alloc0(int size)
        {
            if (size < 0) {
                throw new ArgumentException("Size must be >= 0", nameof(size));
            }
            return g_malloc0((UIntPtr)(uint)size);
        }

        [DllImport("glib-2.0")]
        extern static void g_free(IntPtr ptr);

        /// <summary>
        /// Free the specified pointer with g_free.
        /// </summary>
        /// <param name="ptr">Pointer to an unmanaged data structure.</param>
        /// <remarks>
        /// The pointer being freed must have been allocated using g_malloc.
        /// Also, there is no need to check for IntPtr.Zero.
        /// </remarks>
        public static void Free(IntPtr ptr)
        {
            g_free(ptr);
        }

        /// <summary>
        /// Gets unmanaged function for <see cref="DestroyNotify"/>
        /// that expects the user data to be a <see cref="GCHandle"/> and
        /// frees it.
        /// </summary>
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static void DestroyGCHandle(IntPtr userData)
        {
            try {
                var gcHandle = GCHandle.FromIntPtr(userData);
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Like <see cref="Marshal.SizeOf{T}()"/> but can handle enum types.
        /// </summary>
        public static int SizeOf<T>()
        {
            if (typeof(T).IsEnum) {
                return Marshal.SizeOf(typeof(T).GetEnumUnderlyingType());
            }
            return Marshal.SizeOf<T>();
        }

        /// <summary>
        /// Marshals a C string pointer to a byte array.
        /// </summary>
        /// <returns>The string as a byte array.</returns>
        /// <param name="ptr">Pointer to the unmanaged string.</param>
        /// <param name="freePtr">If set to <c>true</c> free the unmanaged memory.</param>
        /// <remarks>
        /// Since encoding is not specified, the string is returned as a byte array.
        /// The byte array does not include the null terminator.
        /// </remarks>
        public static byte[]? PtrToByteString(IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var bytes = new System.Collections.Generic.List<byte>();
            var offset = 0;
            while (true) {
                var b = Marshal.ReadByte(ptr, offset++);
                if (b == 0)
                    break;
                bytes.Add(b);
            }
            if (freePtr) {
                g_free(ptr);
            }
            return bytes.ToArray();
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
        public static IntPtr ByteStringToPtr(byte[]? bytes)
        {
            if (bytes is null) {
                return IntPtr.Zero;
            }
            var ptr = g_malloc(new UIntPtr((ulong)bytes.Length + 1));
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            Marshal.WriteByte(ptr, bytes.Length, 0);
            return ptr;
        }

        /// <summary>
        /// Marshals a GLib UTF8 char* to a managed string.
        /// </summary>
        /// <returns>The managed string string.</returns>
        /// <param name="ptr">Pointer to the GLib string.</param>
        /// <param name="freePtr">If set to <c>true</c>, free the GLib string.</param>
        public static string? Utf8PtrToString(IntPtr ptr, bool freePtr = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            return Encoding.UTF8.GetString(PtrToByteString(ptr, freePtr)!);
        }

        /// <summary>
        /// Marshals a managed string to a GLib UTF8 char*.
        /// </summary>
        /// <returns>The to pointer to the GLib string.</returns>
        /// <param name="str">The managed string.</param>
        /// <remarks>
        /// The returned pointer should be freed by calling <see cref="Free"/>.
        /// </remarks>
        public static IntPtr StringToUtf8Ptr(string? str)
        {
            if (str is null) {
                return IntPtr.Zero;
            }
            return ByteStringToPtr(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        /// Converts a <see cref="Strv"/> to a managed array of managed UTF-16 strings.
        /// </summary>
        public static string[]? GStrvPtrToStringArray(IntPtr ptr, bool freePtr = false, bool freeElements = false)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var strings = new System.Collections.Generic.List<string>();
            IntPtr current;
            var offset = 0;
            while ((current = Marshal.ReadIntPtr(ptr, offset)) != IntPtr.Zero) {
                strings.Add(Utf8PtrToString(current)!);
                if (freeElements) {
                    g_free(current);
                }
                offset += IntPtr.Size;
            }
            if (freePtr) {
                g_free(ptr);
            }
            return strings.ToArray();
        }

        /// <summary>
        /// Converts an array of managed UTF-16 strings to <see cref="Strv"/>.
        /// </summary>
        public static IntPtr StringArrayToGStrvPtr(string[]? strings)
        {
            if (strings is null) {
                return IntPtr.Zero;
            }
            if (strings.Any(s => s is null)) {
                throw new ArgumentException("All array elements must be non-null.", nameof(strings));
            }
            var ptr = Alloc((strings.Length + 1) * IntPtr.Size);
            var offset = 0;
            foreach (var str in strings) {
                Marshal.WriteIntPtr(ptr, offset, StringToUtf8Ptr(str));
                offset += IntPtr.Size;
            }
            Marshal.WriteIntPtr(ptr, offset, IntPtr.Zero);
            return ptr;
        }

        [DllImport("glib-2.0")]
        extern static void g_strfreev(IntPtr list);

        /// <summary>
        /// Frees an unmanaged null terminated string array (GStrv).
        /// </summary>
        /// <param name="ptr">Pointer to the unmanaged array.</param>
        public static void FreeGStrv(IntPtr ptr)
        {
            g_strfreev(ptr);
        }

        struct GList
        {
#pragma warning disable CS0649
            public IntPtr Data;
            public IntPtr Next;
            public IntPtr Prev;
#pragma warning restore CS0649
        }

        [DllImport("glib-2.0")]
        extern static void g_list_free(IntPtr list);

        /// <summary>
        /// Marshals a GList of strings to a managed string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="ptr">Pointer to the GList</param>
        /// <param name="freePtr">If set to <c>true</c>, frees the GList.</param>
        public static string?[] GListToStringArray(IntPtr ptr, bool freePtr = false)
        {
            var ret = new System.Collections.Generic.List<string?>();
            var itemPtr = ptr;
            while (itemPtr != IntPtr.Zero) {
                var item = Marshal.PtrToStructure<GList>(itemPtr);
                ret.Add(Utf8PtrToString(item.Data));
                itemPtr = item.Next;
            }
            if (freePtr) {
                g_list_free(ptr);
            }
            return ret.ToArray();
        }

        struct GSList
        {
#pragma warning disable CS0649
            public IntPtr Data;
            public IntPtr Next;
#pragma warning restore CS0649
        }

        [DllImport("glib-2.0")]
        extern static void g_slist_free(IntPtr list);

        /// <summary>
        /// Marshals a GSList of strings to a managed string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="ptr">Pointer to the GSList</param>
        /// <param name="freePtr">If set to <c>true</c>, frees the GSList.</param>
        public static string?[] GSListToStringArray(IntPtr ptr, bool freePtr = false)
        {
            var ret = new System.Collections.Generic.List<string?>();
            var itemPtr = ptr;
            while (itemPtr != IntPtr.Zero) {
                var item = Marshal.PtrToStructure<GSList>(itemPtr);
                ret.Add(Utf8PtrToString(item.Data));
                itemPtr = item.Next;
            }
            if (freePtr) {
                g_slist_free(ptr);
            }
            return ret.ToArray();
        }

        /// <summary>
        /// Marshals a C-style array from unmanged memory to managed memory.
        /// </summary>
        /// <returns>The managed array.</returns>
        /// <param name="ptr">Pointer to the unmanged array.</param>
        /// <param name="length">The length of the array or null if the array is null-terminated.</param>
        /// <param name="freePtr">Setting to <c>true</c> will call g_free() on <paramref name="ptr"/>.</param>
        /// <typeparam name="T">The array element type.</typeparam>
        public static T[]? PtrToCArray<T>(IntPtr ptr, int? length, bool freePtr = false) where T : unmanaged
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            T[] array;
            var elementSize = SizeOf<T>();
            if (length.HasValue) {
                array = new T[length.Value];
                var current = ptr;
                for (int i = 0; i < array.Length; i++) {
                    array[i] = Marshal.PtrToStructure<T>(current);
                    current += elementSize;
                }
            }
            else {
                var list = new System.Collections.Generic.List<T>();
                T item;
                var current = ptr;
                while (!(item = Marshal.PtrToStructure<T>(current)).Equals(default(T))) {
                    list.Add(item);
                    current += elementSize;
                }
                array = list.ToArray();
            }
            if (freePtr) {
                Free(ptr);
            }

            return array;
        }

        /// <summary>
        /// Marshalls an array of structs to unmanged memory.
        /// </summary>
        /// <returns>The pointer to the array in unmanged memory.</returns>
        /// <param name="array">The managed array.</param>
        /// <param name="nullTerminated">Set to <c>true</c> to make the array null-terminated</param>
        /// <exception cref="NotSupportedException">
        /// Thrown if array element type is not a value type
        /// </exception>
        public static IntPtr CArrayToPtr<T>(T[] array, bool nullTerminated) where T : unmanaged
        {
            if (array is null) {
                return IntPtr.Zero;
            }
            var elementSize = SizeOf<T>();
            var ptr = Alloc((array.Length + (nullTerminated ? 1 : 0)) * elementSize);
            var current = ptr;
            for (int i = 0; i < array.Length; i++) {
                Marshal.StructureToPtr((T)array.GetValue(i)!, current, false);
                current += elementSize;
            }
            if (nullTerminated) {
                Marshal.StructureToPtr(default(T), current, false);
            }
            return ptr;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_set_error_literal(IntPtr err, Quark domain, int code, IntPtr message);

        /// <summary>
        /// Does nothing if err is NULL; if err is non-NULL, then *err must be NULL.
        /// A new GError is created and assigned to *err.
        /// </summary>
        /// <param name="error">a return location for a GError.</param>
        /// <param name="domain">error domain.</param>
        /// <param name="code">error code.</param>
        /// <param name="message">error message.</param>
        public static void SetError(IntPtr error, Quark domain, int code, string message)
        {
            var messagePtr = StringToUtf8Ptr(message);
            g_set_error_literal(error, domain, code, messagePtr);
            Free(messagePtr);
        }

        /// <summary>
        /// Does nothing if err is NULL; if err is non-NULL, then *err must be NULL.
        /// A new GError is created and assigned to *err.
        /// </summary>
        /// <param name="error">a return location for a GError.</param>
        /// <param name="domain">error domain.</param>
        /// <param name="code">error code.</param>
        /// <param name="format">error message format string.</param>
        /// <param name="args">error message format args.</param>
        public static void SetError(IntPtr error, Quark domain, int code, string format, params object[] args)
        {
            SetError(error, domain, code, string.Format(format, args));
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_propagate_error(Error.UnmanagedStruct** dest, Error.UnmanagedStruct* src);

        /// <summary>
        /// If dest is NULL, free src; otherwise, moves src into *dest. The error
        /// variable dest points to must be NULL.
        /// </summary>
        /// <param name="dest">Destination.</param>
        /// <param name="src">Source.</param>
        /// <remarks>
        /// Note that src is no longer valid after this call.
        /// </remarks>
        public static void PropagateError(Error.UnmanagedStruct** dest, Error src)
        {
            var src_ = (Error.UnmanagedStruct*)src.Take();
            g_propagate_error(dest, src_);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_clear_error(IntPtr err);

        /// <summary>
        /// If err or *err is NULL, does nothing. Otherwise, calls g_error_free()
        /// on *err and sets *err to NULL.
        /// </summary>
        /// <param name="err">Error.</param>
        public static void ClearError(IntPtr err)
        {
            g_clear_error(err);
        }

        /// <summary>
        /// Gets a delegate for an unmanaged virtual function
        /// </summary>
        /// <param name="ptr">
        /// Pointer to an unmanaged data structure
        /// </param>
        /// <param name="fieldOffset">
        /// The offset to the function pointer field in the unmanaged data structure
        /// </param>
        /// <returns>
        /// A delagate or <c>null</c>
        /// </returns>
        public static T? GetVirtualMethodDelegate<T>(IntPtr ptr, int fieldOffset) where T : Delegate
        {
            var ret_ = Marshal.ReadIntPtr(ptr, fieldOffset);
            if (ret_ == IntPtr.Zero) {
                return default;
            }
            var ret = Marshal.GetDelegateForFunctionPointer<T>(ret_);
            return ret;
        }

        /// <summary>
        /// Get the unmanaged function pointer for the managed callback associated
        /// with <paramref name="handler"/>.
        /// </summary>
        /// <param name="handler">
        /// A delegate whose type is a c-closure callback/signal handler.
        /// </param>
        /// <returns>
        /// Pointer to the unmanaged function.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if delegate does not have a matching managed callback method.
        /// </exception>
        public static IntPtr GetCClosureUnmanagedFunctionPointer(this Delegate? handler)
        {
            if (handler is null) {
                return IntPtr.Zero;
            }

            var type = handler.GetType();
            var declaringType = type.DeclaringType ?? throw new ArgumentException($"expecting {type} to be nested");

            var managedCallback = declaringType.GetMethod($"Managed{type.Name}", BindingFlags.Static | BindingFlags.NonPublic) ??
                throw new ArgumentException($"missing Managed{type.Name} in {type.DeclaringType}");

            return managedCallback.MethodHandle.GetFunctionPointer();
        }
    }
}
