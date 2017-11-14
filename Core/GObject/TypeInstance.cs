using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract class TypeInstance : ReferenceCountedOpaque
    {
        protected struct Struct
        {
            public IntPtr GClass;
        }

        internal IntPtr GClass {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadIntPtr (Handle);
                return ret;
            }
        }

        protected TypeInstance (IntPtr handle) : base (handle)
        {
        }
    }
}
