// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
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
        /// Gets unmanaged function for <c>GDestroyNotify</c> callbacks
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
                PushUnhandledException(ex);
            }
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
            PopUnhandledException();
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
            var declaringType = type.DeclaringType ?? throw new ArgumentException($"expecting signal handler delegate '{type}' to be a nested type");

            var managedCallback = declaringType.GetMethod($"Managed{type.Name}", BindingFlags.Static | BindingFlags.NonPublic) ??
                throw new ArgumentException($"missing Managed{type.Name} in {type.DeclaringType}");

            return managedCallback.MethodHandle.GetFunctionPointer();
        }

        [ThreadStatic]
        private static Exception? unhandledException;

        /// <summary>
        /// Push an exception the the thread-local storage. This is used to
        /// persist exceptions across the managed/unmanaged code boundary.
        /// </summary>
        /// <param name="ex">
        /// the exception
        /// </param>
        public static void PushUnhandledException(Exception ex)
        {
            unhandledException = ex;
        }

        /// <summary>
        /// Raises the excpetion set with <see cref="PushUnhandledException"/>
        /// and clears the thread-local storage.
        /// </summary>
        public static void PopUnhandledException()
        {
            if (unhandledException is Exception ex) {
                unhandledException = null;
                throw new UnhandledException(ex);
            }
        }
    }
}
