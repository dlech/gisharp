using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract class TypeInstance : Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        protected struct Struct
        {
            /// <summary>
            /// Pointer to GObjectClass
            /// </summary>
            public IntPtr GClass;
        }

        /// <summary>
        /// Gets the GObject object class.
        /// </summary>
        protected ObjectClass GClass => _GClass.Value;
        readonly Lazy<ObjectClass> _GClass;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
