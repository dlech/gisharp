using System;

namespace GISharp.GObject
{

    /// <summary>
    /// The class of a flags type holds information about its
    /// possible values.
    /// </summary>
    public sealed class FlagsClass : TypeClass
    {
        public sealed class SafeFlagsClassHandle : SafeTypeClassHandle
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

            public SafeFlagsClassHandle (GType type) : base (type)
            {
            }
        }

        public new SafeFlagsClassHandle Handle {
            get {
                return (SafeFlagsClassHandle)base.Handle;
            }
        }

        public override Type StructType {
            get {
                return typeof(SafeFlagsClassHandle.FlagsClassStruct);
            }
        }

        public FlagsClass (SafeFlagsClassHandle handle) : base (handle)
        {
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotSupportedException ();
        }
    }
}
