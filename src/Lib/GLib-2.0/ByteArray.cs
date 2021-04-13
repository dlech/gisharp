// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class ByteArray : IReadOnlyList<byte>, IList<byte>
    {
        partial void CheckRemoveIndexArgs(uint index)
        {
            AssertIndexInRange((int)index);
        }

        partial void CheckRemoveIndexFastArgs(uint index)
        {
            AssertIndexInRange((int)index);
        }

        partial void CheckRemoveRangeArgs(uint index, uint length)
        {
            AssertIndexInRange((int)index);
            if (length < 0 || index + length > Length) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
        }

        /// <summary>
        /// a <see cref="Span{T}"/> of the element data. The data may be moved as elements
        /// are added to the <see cref="ByteArray"/>.
        /// </summary>
        public Span<byte> Data => new(((UnmanagedStruct*)UnsafeHandle)->Data, Length);

        /// <summary>
        /// Gets the number of elements in the <see cref="ByteArray"/>.
        /// </summary>
        public int Length => (int)((UnmanagedStruct*)UnsafeHandle)->Len;

        /// <inheritdoc/>
        int IReadOnlyCollection<byte>.Count => Length;

        /// <inheritdoc/>
        int ICollection<byte>.Count => Length;

        /// <inheritdoc/>
        bool ICollection<byte>.IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="ByteArray"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public byte this[int index] {
            get {
                try {
                    return Data[index];
                }
                catch (IndexOutOfRangeException) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set {
                try {
                    Data[index] = value;
                }
                catch (IndexOutOfRangeException) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        /// <summary>
        /// Adds the given bytes to the end of the <see cref="ByteArray"/>.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Append(params byte[] data) => Append(data.AsSpan());

        /// <inheritdoc/>
        void ICollection<byte>.Add(byte item) => Append(item);

        /// <summary>
        /// Adds the given data to the start of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Prepend(params byte[] data) => Prepend(data.AsSpan());

        /// <summary>
        /// Insert the specified item at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, byte item)
        {
            if (index == 0) {
                Prepend(item);
                return;
            }

            var len = Length;
            if (index == len) {
                Append(item);
                return;
            }

            AssertIndexInRange(index);

            SetSize((uint)len + 1);
            for (var i = len; i > index; i--) {
                this[i] = this[i - 1];
            }
            this[index] = item;
        }

        /// <inheritdoc/>
        void IList<byte>.RemoveAt(int index)
        {
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            RemoveIndex((uint)index);
        }

        /// <inheritdoc/>
        bool ICollection<byte>.Remove(byte item)
        {
            for (int i = 0; i < Length; i++) {
                if (this[i] == item) {
                    RemoveIndex((uint)i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all items from the array.
        /// </summary>
        public void Clear() => SetSize(0);

        /// <summary>
        /// Checks if the array contains the specified item.
        /// </summary>
        /// <returns><c>true</c> if the array contains <paramref name="item"/>.</returns>
        /// <param name="item">The item to search for.</param>
        public bool Contains(byte item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Gets the index of the first occurrence of <paramref name="item"/>.
        /// </summary>
        /// <returns>The index or <c>-1</c> if <paramref name="item"/> was not found.</returns>
        /// <param name="item">The item to search for.</param>
        public int IndexOf(byte item) => Data.IndexOf(item);

        /// <summary>
        /// Copies elements of this array to <paramref name="array"/>, starting
        /// at a particular index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The starting index of <paramref name="array"/>.</param>
        public void CopyTo(byte[] array, int arrayIndex)
        {
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (arrayIndex + Length > array.Length) {
                throw new ArgumentException("Destination array is not long enough.");
            }
            for (int i = 0; i < Length; i++) {
                array[i + arrayIndex] = this[i];
            }
        }

        /// <summary>
        /// Sorts a byte array, using @compareFunc which should be a
        /// qsort()-style comparison function (returns less than zero for first
        /// arg is less than second arg, zero for equal, greater than zero if
        /// first arg is greater than second arg).
        /// </summary>
        /// <remarks>
        /// If two array elements compare equal, their order in the sorted array
        /// is undefined. If you want equal elements to keep their order (i.e.
        /// you want a stable sort) you can write a comparison function that,
        /// if two elements would otherwise compare equal, compares them by
        /// their addresses.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        public void Sort(Comparison<byte> compareFunc)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            var unmanagedCompareFunc = new UnmanagedCompareFunc((a, b) => {
                try {
                    var x = Marshal.ReadByte(a);
                    var y = Marshal.ReadByte(b);
                    var ret = compareFunc(x, y);
                    return ret;
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            });
            var compareFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)Marshal.GetFunctionPointerForDelegate(unmanagedCompareFunc);
            g_byte_array_sort(array_, compareFunc_);
            GMarshal.PopUnhandledException();
            GC.KeepAlive(unmanagedCompareFunc);
        }

        IEnumerator<byte> GetEnumerator()
        {
            // TODO: protect against modified array
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void AssertIndexInRange(int index)
        {
            if (index < 0 || index >= Length) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Converts a <see cref="ByteArray"/> to a <see cref="ReadOnlySpan{T}"/> of bytes.
        /// </summary>.
        public static implicit operator ReadOnlySpan<byte>(ByteArray array)
        {
            return array.Data;
        }
    }
}
