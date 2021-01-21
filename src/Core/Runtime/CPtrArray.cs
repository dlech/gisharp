// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper for unmanaged arrays of pointers.
    /// </summary>
    public abstract class CPtrArray : Opaque
    {
        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        protected int Length { get; }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.Full) {
                this.handle = IntPtr.Zero;
                throw new NotSupportedException();
            }
            if (ownership != Transfer.Container) {
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

        /// <summary>
        /// Creates an managed wrapper around an unmanaged C array.
        /// </summary>
        public static CPtrArray<T> GetInstance<T>(IntPtr handle, int length, Transfer ownership) where T : IOpaque?
        {
            return new CPtrArray<T>(handle, length, ownership);
        }
    }

    /// <summary>
    /// Managed wrapper for C array of pointers to opaque data types.
    /// </summary>
    public class CPtrArray<T> : CPtrArray, IReadOnlyList<T> where T : IOpaque?
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
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
                var this_ = UnsafeHandle;
                if (index < 0 || index >= Length) {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                var offset = IntPtr.Size * index;
                var ptr = Marshal.ReadIntPtr(this_, offset);
                return Opaque.GetInstance<T>(ptr, Transfer.None);
            }
        }

        private unsafe ReadOnlySpan<IntPtr> Data => new ReadOnlySpan<IntPtr>((void*)UnsafeHandle, Length);

        /// <summary>
        /// Gets the number of elements in the array.
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
    /// Managed wrapper for unowned C arrays of pointers to opaque data types.
    /// </summary>
    public ref struct UnownedCPtrArray<T> where T : IOpaque?
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
        public unsafe UnownedCPtrArray(IntPtr handle, int length, Transfer ownership)
        {
            if (ownership != Transfer.None) {
                throw new NotSupportedException();
            }
            if (length < 0) {
                // TODO: lazy-get length for null terminated arrays
                throw new NotSupportedException();
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
        public Enumerator GetEnumerator() => new Enumerator(this);
    }

    /// <summary>
    /// Extension methods for <see cref="UnownedCPtrArray{T}"/>
    /// </summary>
    public static class UnownedCPtrArrayExtensions
    {
        /// <summary>
        /// Casts a managed array of pointers to an unmanaged C array.
        /// </summary>
        public static UnownedCPtrArray<T> AsUnownedCPtrArray<T>(this T[] array) where T : IOpaque
        {
            if (array is null) {
                return UnownedCPtrArray<T>.Empty;
            }
            return new UnownedCPtrArray<T>(array.Select(x => x.UnsafeHandle).ToArray());
        }
    }
}
