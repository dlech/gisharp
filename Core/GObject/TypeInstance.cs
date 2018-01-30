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
    public abstract class TypeInstance : Opaque
    {
        protected struct Struct
        {
            public IntPtr GClass;
        }

        protected ObjectClass GClass {
            get {
                AssertNotDisposed ();
                if (_GClass == null) {
                    var ptr = Marshal.ReadIntPtr(Handle);
                    _GClass = new ObjectClass(ptr, Transfer.None);
                }
                return _GClass;
            }
        }
        ObjectClass _GClass;

        protected TypeInstance (IntPtr handle) : base (handle)
        {
        }
    }
}
