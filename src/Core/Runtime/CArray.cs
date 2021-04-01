// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper for an unmanaged C array.
    /// </summary>
    public abstract unsafe class CArray : Opaque
    {
        /// <summary>
        /// Gets the number of elements in this array.
        /// </summary>
        protected int Length { get; }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CArray(IntPtr handle, int length, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                this.handle = IntPtr.Zero;
                throw new NotSupportedException();
            }
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            Length = length;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            GMarshal.Free(handle);
            base.Dispose(disposing);
        }

        /// <summary>
        /// Takes ownership of the unmanaged C array.
        /// </summary>
        /// <returns>
        /// Pointer to the unmanaged C array and the length of the array.
        /// </returns>
        /// <remarks>
        /// This instance becomes disposed after calling this method.
        /// </remarks>
        public (IntPtr handle, int length) TakeData()
        {
            var ret = (UnsafeHandle, Length);
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
            return ret;
        }

        /// <summary>
        /// Creates a new managed wrapper for an unmanaged C array.
        /// </summary>
        public static CArray<T> GetInstance<T>(IntPtr handle, int length, Transfer ownership) where T : unmanaged
        {
            return new CArray<T>(handle, length, ownership);
        }
    }

    /// <summary>
    /// Managed wrapper around an unmanged C array.
    /// </summary>
    /// <seealso cref="CPtrArray{T}"/>
    public unsafe class CArray<T> : CArray, IReadOnlyList<T> where T : unmanaged
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CArray(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }

        /// <summary>
        /// Gets an element of this array.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the element in the array.
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// The index is outside of the bounds of the array.
        /// </exception>
        public T this[int index] {
            get {
                var this_ = (T*)UnsafeHandle;
                if (index < 0 || index >= Length) {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                var ret = this_[index];
                return ret;
            }
        }

        /// <summary>
        /// Gets the number of elements in this array.
        /// </summary>
        public int Count => Length;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Converts a <see cref="CArray{T}"/> to a span.
        /// </summary>
        public static implicit operator ReadOnlySpan<T>(CArray<T> array)
        {
            return new ReadOnlySpan<T>((void*)array.UnsafeHandle, array.Length);
        }
    }

    /// <summary>
    /// Managed wrapper for unowned C arrays of pointers to opaque data types.
    /// </summary>
    public unsafe class ZeroTerminatedCArray<T> : Opaque where T : unmanaged
    {
        private int length;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ZeroTerminatedCArray(void* handle) : this((IntPtr)handle, -1, Transfer.None)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ZeroTerminatedCArray(void* handle, int length) : this((IntPtr)handle, length, Transfer.None)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ZeroTerminatedCArray(IntPtr handle, int length, Transfer ownership) : base(handle)
        {
            if (ownership != Transfer.Full) {
                GC.SuppressFinalize(this);
                throw new NotSupportedException();
            }
            this.length = length;
        }

        /// <summary>
        /// Gets a pinnable reference for passing to unmanged code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ref readonly T GetPinnableReference()
        {
            return ref Unsafe.AsRef<T>((void*)handle);
        }

        /// <summary>
        /// Enumerator for iterating <see cref="ZeroTerminatedCArray{T}"/>.
        /// </summary>
        public ref struct Enumerator
        {
            private readonly ZeroTerminatedCArray<T> array;
            private T* current;

            internal Enumerator(ZeroTerminatedCArray<T> array)
            {
                this.array = array;
                current = null;
            }

            /// <summary>
            /// Implements the <c>Current</c> property for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public ref T Current => ref *current;

            /// <summary>
            /// Implements the <c>MoveNext</c> method for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public bool MoveNext()
            {
                if (current == null) {
                    current = (T*)array.UnsafeHandle;
                }
                else {
                    current++;
                }

                return !EqualityComparer<T>.Default.Equals(*current, default);
            }
        }

        /// <summary>
        /// Gets an enumerator for this array.
        /// </summary>
        public Enumerator GetEnumerator() => new(this);
    }

    /// <summary>
    /// Managed wrapper for unowned C arrays of pointers to opaque data types.
    /// </summary>
    public unsafe ref struct UnownedZeroTerminatedCArray<T> where T : unmanaged
    {
        private readonly T* handle;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedZeroTerminatedCArray(void* handle) : this((IntPtr)handle, -1, Transfer.None)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedZeroTerminatedCArray(void* handle, int length) : this((IntPtr)handle, length, Transfer.None)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedZeroTerminatedCArray(IntPtr handle, int length, Transfer ownership)
        {
            if (ownership != Transfer.None) {
                throw new NotSupportedException();
            }

            this.handle = (T*)handle;
            // TODO: could save length in case it is >= 0 for later conversion
            // to UnownedCPtrArray
        }

        /// <summary>
        /// Gets a pinnable reference for passing to unmanged code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ref readonly T GetPinnableReference()
        {
            return ref Unsafe.AsRef<T>(handle);
        }

        /// <summary>
        /// Enumerator for iterating <see cref="UnownedZeroTerminatedCArray{T}"/>.
        /// </summary>
        public ref struct Enumerator
        {
            private readonly UnownedZeroTerminatedCArray<T> array;
            private T* current;

            internal Enumerator(UnownedZeroTerminatedCArray<T> array)
            {
                this.array = array;
                current = null;
            }

            /// <summary>
            /// Implements the <c>Current</c> property for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public ref T Current => ref *current;

            /// <summary>
            /// Implements the <c>MoveNext</c> method for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public bool MoveNext()
            {
                if (current == null) {
                    current = array.handle;
                }
                else {
                    current++;
                }

                return !EqualityComparer<T>.Default.Equals(*current, default);
            }
        }

        /// <summary>
        /// Gets an enumerator for this array.
        /// </summary>
        public Enumerator GetEnumerator() => new(this);
    }
}
