// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper for unmanaged arrays of pointers.
    /// </summary>
    public abstract unsafe class CPtrArray : Opaque
    {
        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        public int Length { get; }

        private protected CPtrArray(IntPtr handle, int length) : base(handle)
        {
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
        /// Takes ownership of the unmanaged array.
        /// </summary>
        /// <returns>
        /// Pointer to the array and length of the array.
        /// </returns>
        /// <remarks>
        /// The managed wrapper will become disposed after calling this method.
        /// </remarks>
        public (IntPtr handle, int length) TakeData()
        {
            var ret = (UnsafeHandle, Length);
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
            return ret;
        }

        private protected T GetElement<T>(int index) where T : IOpaque?
        {
            if (index < 0 || index >= Length) {
                throw new IndexOutOfRangeException(nameof(index));
            }
            var element_ = ((IntPtr*)UnsafeHandle)[index];
            return GetInstance<T>(element_, Transfer.None);
        }

        private protected ReadOnlySpan<IntPtr> Data => new((void*)UnsafeHandle, Length);

        private protected IEnumerator<T> GetEnumerator<T>() where T : IOpaque?
        {
            for (int i = 0; i < Length; i++) {
                yield return GetElement<T>(i);
            }
        }
    }

    /// <summary>
    /// Managed wrapper for C array of pointers to opaque data types.
    /// </summary>
    public unsafe class CPtrArray<T> : CPtrArray, IReadOnlyList<T> where T : IOpaque?
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, length)
        {
            if (ownership != Transfer.Full) {
                GC.SuppressFinalize(this);
                throw new NotSupportedException("owned array must own everything");
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            // TODO: need to call free function on each element
            base.Dispose(disposing);
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
        public T this[int index] => GetElement<T>(index);

        /// <inheritdoc/>
        int IReadOnlyCollection<T>.Count => Length;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator<T>();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator<T>();

        /// <summary>
        /// Casts a <see cref="CPtrArray{T}"/> to an <see cref="UnownedCPtrArray{T}"/>.
        /// </summary>
        public static implicit operator UnownedCPtrArray<T>(CPtrArray<T>? array)
        {
            if (array is null) {
                return default;
            }
            return new UnownedCPtrArray<T>(array.Data);
        }
    }

    /// <summary>
    /// Managed wrapper for C array of pointers to opaque data types.
    /// </summary>
    public unsafe class WeakCPtrArray<T> : CPtrArray, IReadOnlyList<T> where T : IOpaque?
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WeakCPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, length)
        {
            if (ownership != Transfer.Container) {
                GC.SuppressFinalize(this);
                throw new NotSupportedException("weak array must only own container");
            }
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
        public T this[int index] => GetElement<T>(index);

        /// <inheritdoc/>
        int IReadOnlyCollection<T>.Count => Length;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator<T>();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator<T>();

        /// <summary>
        /// Casts a <see cref="WeakCPtrArray{T}"/> to an <see cref="UnownedCPtrArray{T}"/>.
        /// </summary>
        public static implicit operator UnownedCPtrArray<T>(WeakCPtrArray<T>? array)
        {
            if (array is null) {
                return default;
            }
            return new UnownedCPtrArray<T>(array.Data);
        }
    }

    /// <summary>
    /// Managed wrapper for unowned C arrays of pointers to opaque data types.
    /// </summary>
    public unsafe ref struct UnownedCPtrArray<T> where T : IOpaque?
    {
        /// <summary>
        /// Gets an empty array.
        /// </summary>
        public static UnownedCPtrArray<T> Empty => default;

        /// <summary>
        /// The array as a span of pointers.
        /// </summary>
        public ReadOnlySpan<IntPtr> Data { get; }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedCPtrArray(void* handle, int length) : this((IntPtr)handle, length, Transfer.None)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedCPtrArray(IntPtr handle, int length, Transfer ownership)
        {
            if (ownership != Transfer.None) {
                throw new NotSupportedException();
            }

            // length of < 0 means zero-terminated, so we have to go through
            // the whole array to find the length
            if (length < 0) {
                var array = (IntPtr*)handle;
                for (length = 0; array[length] != IntPtr.Zero; length++) {
                }
            }

            Data = new((void*)handle, length);
        }

        /// <summary>
        /// Creates a new <see cref="UnownedCPtrArray{T}"/> from a span.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedCPtrArray(ReadOnlySpan<IntPtr> data)
        {
            Data = data;
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
                if (index < 0 || index >= Data.Length) {
                    throw new IndexOutOfRangeException();
                }
                return Opaque.GetInstance<T>(Data[index], Transfer.None);
            }
        }

        /// <summary>
        /// Gets the number of elements in this array.
        /// </summary>
        public int Length => Data.Length;

        /// <summary>
        /// Gets a pinnable reference for passing to unmanged code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ref readonly IntPtr GetPinnableReference()
        {
            return ref Data.GetPinnableReference();
        }


        /// <summary>
        /// Enumerator for iterating <see cref="UnownedCPtrArray{T}"/>.
        /// </summary>
        public ref struct Enumerator
        {
            private readonly UnownedCPtrArray<T> array;
            private int index;

            internal Enumerator(UnownedCPtrArray<T> array)
            {
                this.array = array;
                index = -1;
            }

            /// <summary>
            /// Implements the <c>Current</c> property for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public T Current => array[index];

            /// <summary>
            /// Implements the <c>MoveNext</c> method for the <c>foreach</c>
            /// enumerator pattern.
            /// </summary>
            public bool MoveNext()
            {
                index++;
                return index < array.Data.Length;
            }
        }

        /// <summary>
        /// Gets an enumerator for this array.
        /// </summary>
        public Enumerator GetEnumerator() => new(this);
    }

    /// <summary>
    /// Extension methods for <see cref="UnownedCPtrArray{T}"/>
    /// </summary>
    public static class UnownedCPtrArrayExtensions
    {
        /// <summary>
        /// Casts a managed array of pointers to an unmanaged C array.
        /// </summary>
        public static UnownedCPtrArray<T> ToUnownedCPtrArray<T>(this T[] array) where T : IOpaque
        {
            if (array is null) {
                return UnownedCPtrArray<T>.Empty;
            }
            return new UnownedCPtrArray<T>(array.Select(x => x.UnsafeHandle).ToArray());
        }
    }
}
