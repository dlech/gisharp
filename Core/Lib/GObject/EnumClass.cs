
using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject {

    /// <summary>
    /// The class of an enumeration type holds information about its
    /// possible values.
    /// </summary>
    public sealed class EnumClass : TypeClass
    {
        new struct Struct
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

        public EnumClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
