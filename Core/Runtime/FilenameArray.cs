


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.GObject;
using GISharp.Runtime;
using GISharp.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null-terminated array of null-terminated file names
    /// </summary>
    public sealed class FilenameArray : Opaque, IEnumerable<Filename>
    {
        bool Owned { get; }

        public FilenameArray(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.Full) {
                Owned = true;
            }
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
