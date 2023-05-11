// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2021 David Lechner <david@lechnology.com>

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Bytes : IReadOnlyList<byte>
    {
        partial void CheckNewFromBytesArgs(int offset, int length)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (offset + length > Size)
            {
                throw new ArgumentException("offset + length exceeds size");
            }
        }

        static UnmanagedStruct* NewWithFreeFunc(ReadOnlyMemory<byte> data)
        {
            var memoryHandle = data.Pin();
            var data_ = (byte*)memoryHandle.Pointer;
            var size_ = (nuint)data.Length;
            var freeFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&FreeMemoryHandle;
            var userData_ = (IntPtr)GCHandle.Alloc(memoryHandle);
            var ret_ = g_bytes_new_with_free_func(data_, size_, freeFunc_, userData_);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void FreeMemoryHandle(IntPtr userData_)
        {
            try
            {
                var gcHandle = GCHandle.FromIntPtr(userData_);
                var memoryHandle = (MemoryHandle)gcHandle.Target!;
                memoryHandle.Dispose();
                gcHandle.Free();
            }
            catch (Exception ex)
            {
                GMarshal.PushUnhandledException(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Bytes"/> from <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        /// The memory is used directly and must not be modified. For managed
        /// memory, it means that it will be pinned until all references to the
        /// <see cref="Bytes"/> instance have been released.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        public Bytes(ReadOnlyMemory<byte> data)
            : this((IntPtr)NewWithFreeFunc(data), Transfer.Full) { }

        /// <inheritdoc/>
        int IReadOnlyCollection<byte>.Count => Size;

        /// <summary>
        /// Gets an element in the array.
        /// </summary>
        public byte this[int index]
        {
            get
            {
                try
                {
                    return Data[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
