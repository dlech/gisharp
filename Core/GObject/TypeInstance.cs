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

        protected ObjectClass GClass => _GClass.Value;
        readonly Lazy<ObjectClass> _GClass;

        protected TypeInstance(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            _GClass = new Lazy<ObjectClass>(GetGClass);
        }

        ObjectClass GetGClass()
        {
            var ret_ = Marshal.ReadIntPtr(Handle);
            var ret = new ObjectClass(ret_, Transfer.None);
            return ret;
        }
    }
}
