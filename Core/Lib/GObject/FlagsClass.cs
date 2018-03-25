using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{

    /// <summary>
    /// The class of a flags type holds information about its
    /// possible values.
    /// </summary>
    public sealed class FlagsClass : TypeClass
    {
        new struct Struct
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlagsClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
