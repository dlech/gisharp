// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using System;
using System.Reflection;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for GObject callbacks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate, Inherited = false)]
    public sealed class GCallbackAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="unmanagedCallbackFactory">
        /// A type that contains a public static method named <c>ToUnmanagedFunctionPointer</c>
        /// that conforms to <see cref="ToUnmanagedFunctionPointer"/>.
        /// </param>
        public GCallbackAttribute(Type unmanagedCallbackFactory)
        {
            var method = unmanagedCallbackFactory.GetMethod("ToUnmanagedFunctionPointer", BindingFlags.Public | BindingFlags.Static);
            if (method is null) {
                var message = $"Type '{unmanagedCallbackFactory}' is missing public static 'ToUnmanagedFunctionPointer' method";
                throw new ArgumentException(message, nameof(unmanagedCallbackFactory));
            }
            ToUnmanagedFunctionPointer = method.CreateDelegate<ToUnmanagedFunctionPointer>();
        }

        /// <summary>
        /// Gets a delegate for mashalling a managed callback to an unmanaged
        /// function pointer.
        /// </summary>
        public ToUnmanagedFunctionPointer ToUnmanagedFunctionPointer { get; }
    }

    /// <summary>
    /// Delegate type for GCallback marshalling function.
    /// </summary>
    /// <param name="callback">
    /// A managed callback.
    /// </param>
    /// <param name="scope">
    /// The scope of the lifetime of the callback in unmanaged code.
    /// </param>
    /// <returns>
    /// A tuple containing an unmanaged function pointer that wraps <paramref name="callback"/>,
    /// user data containing a GC handle for the <paramref name="callback"/>.
    /// </returns>
    public delegate (IntPtr unmanagedFunctionPointer, IntPtr destroyNotifyFunctionPointer, IntPtr userData)
        ToUnmanagedFunctionPointer(Delegate callback, CallbackScope scope);

    /// <summary>
    /// Extension methods for GCallback delegates.
    /// </summary>
    /// <remarks>
    /// GCallback delegates are decorated with <see cref="GCallbackAttribute"/>.
    /// </remarks>
    public static class GCallbackExtensions
    {
        /// <summary>
        /// Gets the <see cref="ToUnmanagedFunctionPointer"/> method for <paramref name="callback"/>.
        /// </summary>
        public static ToUnmanagedFunctionPointer GetToUnmanagedFunctionPointer(this Delegate callback)
        {
            var attr = callback.GetType().GetCustomAttribute<GCallbackAttribute>();
            if (attr is null) {
                var msg = $"Type '{callback.GetType()}' is missing GCallbackAttribute";
                throw new ArgumentException(msg, nameof(callback));
            }
            return attr.ToUnmanagedFunctionPointer;
        }
    }
}
