// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper for an unmanaged C array.
    /// </summary>
    public abstract class CArray : Opaque
    {
        /// <summary>
        /// Gets the number of elements in this array.
        /// </summary>
        protected int Length { get; }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CArray(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
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
    public class CArray<T> : CArray, IReadOnlyList<T> where T : unmanaged
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
        public unsafe T this[int index] {
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
        public static unsafe implicit operator ReadOnlySpan<T>(CArray<T> array)
        {
            return new ReadOnlySpan<T>((void*)array.UnsafeHandle, array.Length);
        }
    }
}
