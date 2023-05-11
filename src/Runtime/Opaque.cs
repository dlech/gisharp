// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base type for wrapping unmanged pointers
    /// </summary>
    public abstract class Opaque : IOpaque, IDisposable
    {
        /// <summary>
        /// Raw pointer value.
        /// </summary>
        /// <remarks>
        /// This should be treated as write-only by overriding. <see cref="UnsafeHandle" />
        /// should be used instead when reading to ensure that the pointer is
        /// still valid.
        /// </remarks>
        protected IntPtr handle;

        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public virtual IntPtr UnsafeHandle
        {
            get
            {
                if (handle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(null);
                }
                return handle;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Opaque(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Opaque(IntPtr handle, Transfer ownership)
        {
            this.handle = handle;
        }

        /// <inheritdoc />
        ~Opaque()
        {
            Dispose(false);
        }

        /// <summary>
        /// Take unmanaged handle from this object
        /// </summary>
        /// <remarks>
        /// This object is no longer valid after calling <see cref="Take"/> (it
        /// will throw <see cref="ObjectDisposedException"/>).
        /// </remarks>
        public virtual IntPtr Take()
        {
            var this_ = UnsafeHandle;
            handle = IntPtr.Zero;
            return this_;
        }

        /// <summary>
        /// Releases all resource used by the <see cref="Opaque"/> object.
        /// </summary>
        /// <remarks>
        /// Call <see cref="Dispose()"/> when you are finished using the <see cref="Opaque"/>. The <see cref="Dispose()"/>
        /// method leaves the <see cref="Opaque"/> in an unusable state. After calling <see cref="Dispose()"/>, you must
        /// release all references to the <see cref="Opaque"/> so the garbage collector can reclaim the memory that the
        /// <see cref="Opaque"/> was occupying.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        protected virtual void Dispose(bool disposing)
        {
            handle = IntPtr.Zero;
        }

        /// <summary>
        /// Marshals an unmanged pointer to a managed object.
        /// </summary>
        public static T GetInstance<T>(IntPtr handle, Transfer ownership)
            where T : IOpaque?
        {
            return (T)GetInstance(typeof(T), handle, ownership)!;
        }

        /// <summary>
        /// Marshals an unmanged pointer to a managed object.
        /// </summary>
        public static IOpaque? GetInstance(Type type, IntPtr handle, Transfer ownership)
        {
            // special case for OpaqueInt so 0 doesn't become null
            if (type == typeof(OpaqueInt))
            {
                var ret = new OpaqueInt((int)handle);
                return ret;
            }

            if (handle == IntPtr.Zero)
            {
                return null;
            }

            if (
                typeResolvers.Keys
                    .Where(x => x.IsAssignableFrom(type))
                    .Select(x => typeResolvers[x])
                    .SingleOrDefault()
                is Func<IntPtr, Transfer, IOpaque?> getInstance
            )
            {
                return getInstance(handle, ownership);
            }

            return (IOpaque)Activator.CreateInstance(type, handle, ownership)!;
        }

        private static readonly Dictionary<Type, Func<IntPtr, Transfer, IOpaque?>> typeResolvers =
            new();

        /// <summary>
        /// Registers a new fundamental type for getting correct subclass type.
        /// </summary>
        protected static void RegisterTypeResolver<T>(Func<IntPtr, Transfer, IOpaque?> getInstance)
            where T : IOpaque
        {
            typeResolvers.Add(typeof(T), getInstance);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is Opaque opaque)
            {
                return handle == opaque.handle;
            }
            return base.Equals(obj);
        }
    }
}
