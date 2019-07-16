


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using GISharp.Lib.GLib;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null-terminated array of null-terminated file names
    /// </summary>
    public sealed class FilenameArray : Opaque, IReadOnlyList<Filename>
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
        public FilenameArray(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
        {
            if (ownership != Transfer.Full) {
                this.handle = IntPtr.Zero;
                GC.SuppressFinalize(this);
                throw new NotSupportedException();
            }
        }

        static IntPtr New(string[] filenames) {
            var ptr = GMarshal.Alloc(IntPtr.Size * filenames.Length + 1);
            for (int i = 0; i < filenames.Length; i++) {
                Marshal.WriteIntPtr(ptr, IntPtr.Size * i, new Filename(filenames[i]).Take());
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

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_strfreev(IntPtr strv);

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_strfreev(handle);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets a ref to the unmanaged pointer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe ref readonly IntPtr GetPinnableReference()
        {
            return ref Unsafe.AsRef<IntPtr>((void*)Handle);
        }

        IEnumerator<Filename> IEnumerable<Filename>.GetEnumerator()
        {
            var this_ = Handle;

            return GetEnumerator();

            IEnumerator<Filename> GetEnumerator()
            {
                IntPtr str_;
                var offset = 0;
                while ((str_ = Marshal.ReadIntPtr(this_, offset)) != IntPtr.Zero) {
                    yield return Opaque.GetInstance<Filename>(str_, Transfer.None);
                    offset += IntPtr.Size;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Filename>)this).GetEnumerator();
    }
}
