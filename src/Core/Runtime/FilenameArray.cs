// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null-terminated array of null-terminated file names
    /// </summary>
    public sealed class FilenameArray : ByteStringArray, IReadOnlyList<Filename>
    {
        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        public int Count => throw new NotImplementedException();

        /// <summary>
        /// Gets the filename at the specified index.
        /// </summary>
        public Filename this[int index] => throw new NotImplementedException();

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FilenameArray(IntPtr handle, Transfer ownership) : this(handle, -1, ownership)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FilenameArray(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }
        static IntPtr New(string[] filenames)
        {
            var ptr = GMarshal.Alloc(IntPtr.Size * filenames.Length + 1);
            for (int i = 0; i < filenames.Length; i++) {
                Marshal.WriteIntPtr(ptr, IntPtr.Size * i, ((Filename)filenames[i]).Take());
            }
            // null termination
            Marshal.WriteIntPtr(ptr, IntPtr.Size * filenames.Length, IntPtr.Zero);

            return ptr;
        }

        /// <summary>
        /// Creates a new array with the specified file names.
        /// </summary>
        public FilenameArray(params string[] filenames) : this(New(filenames), filenames.Length, Transfer.Full)
        {
        }

        IEnumerator<Filename> IEnumerable<Filename>.GetEnumerator()
        {
            var this_ = UnsafeHandle;

            return GetEnumerator();

            IEnumerator<Filename> GetEnumerator()
            {
                IntPtr str_;
                var offset = 0;
                while ((str_ = Marshal.ReadIntPtr(this_, offset)) != IntPtr.Zero) {
                    yield return GetInstance<Filename>(str_, Transfer.None);
                    offset += IntPtr.Size;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Filename>)this).GetEnumerator();
    }
}
