using System;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// A union holding one collected value.
    /// </summary>
    [StructLayout (LayoutKind.Explicit)]
    struct TypeCValue
    {
        /// <summary>
        /// the field for holding integer values
        /// </summary>
        [FieldOffset (0)]
        public int VInt;

        /// <summary>
        /// the field for holding long integer values
        /// </summary>
        [FieldOffset (0)]
        public long VLong;

        /// <summary>
        /// the field for holding 64 bit integer values
        /// </summary>
        [FieldOffset (0)]
        public long VInt64;

        /// <summary>
        /// the field for holding floating point values
        /// </summary>
        [FieldOffset (0)]
        public double VDouble;

        /// <summary>
        /// the field for holding pointers
        /// </summary>
        [FieldOffset (0)]
        public IntPtr VPointer;
    }
}
