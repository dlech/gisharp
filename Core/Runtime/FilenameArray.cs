


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using GISharp.Lib.GLib;
using System.ComponentModel;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null-terminated array of null-terminated file names
    /// </summary>
    public sealed class FilenameArray : Opaque, IEnumerable<Filename>
    {
        bool Owned { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FilenameArray(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.Full) {
                Owned = true;
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

        public FilenameArray(params string[] filenames) : this(New(filenames), Transfer.Full)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_strfreev(IntPtr strv);

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_strfreev(handle);
            }
            base.Dispose(disposing);
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
