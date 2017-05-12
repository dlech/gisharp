
using System;
using GISharp.Runtime;

namespace GISharp.GObject {

    /// <summary>
    /// The class of an enumeration type holds information about its
    /// possible values.
    /// </summary>
    public sealed class EnumClass : TypeClass
    {
        public sealed new class SafeHandle : TypeClass.SafeHandle
        {
            internal struct EnumClassStruct
            {
                #pragma warning disable CS0649
                /// <summary>
                /// the parent class
                /// </summary>
                public TypeClass GTypeClass;

                /// <summary>
                /// the smallest possible value.
                /// </summary>
                public int Minimum;

                /// <summary>
                /// the largest possible value.
                /// </summary>
                public int Maximum;

                /// <summary>
                /// the number of possible values.
                /// </summary>
                public uint NValues;

                /// <summary>
                /// an array of #GEnumValue structs describing the
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
                return typeof(SafeHandle.EnumClassStruct);
            }
        }

        public EnumClass (SafeHandle handle) : base (handle)
        {
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotSupportedException ();
        }
    }
}
