using System;
using GISharp.Runtime;

namespace GISharp.GObject
{

    /// <summary>
    /// The class of a flags type holds information about its
    /// possible values.
    /// </summary>
    public sealed class FlagsClass : TypeClass
    {
        public sealed new class SafeHandle : TypeClass.SafeHandle
        {
            internal struct FlagsClassStruct
            {
                #pragma warning disable CS0649
                /// <summary>
                /// the parent class
                /// </summary>
                public TypeClass GTypeClass;

                /// <summary>
                /// a mask covering all possible values.
                /// </summary>
                public uint Mask;

                /// <summary>
                /// the number of possible values.
                /// </summary>
                public uint NValues;

                /// <summary>
                /// an array of #GFlagsValue structs describing the
                ///  individual values.
                /// </summary>
                public IntPtr Values;
                #pragma warning restore CS0649
            }

            public SafeHandle (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }
        }

        public new SafeHandle Handle {
            get {
                return (SafeHandle)base.Handle;
            }
        }

        public override Type StructType {
            get {
                return typeof(SafeHandle.FlagsClassStruct);
            }
        }

        public FlagsClass (SafeHandle handle) : base (handle)
        {
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotSupportedException ();
        }
    }
}
