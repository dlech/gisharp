// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;

namespace GISharp.GIRepository
{
    /// <summary>
    /// Struct representing an enum value
    /// </summary>
    public sealed class ValueInfo : BaseInfo
    {
        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern long g_value_info_get_value (IntPtr raw);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <remarks>
        /// This will always be representable as a 32-bit signed or unsigned value.
        /// The use of <c>long</c> as the return type is to allow both.
        /// </remarks>
        public long Value {
            get {
                return g_value_info_get_value (Handle);
            }
        }

        public static explicit operator int (ValueInfo info)
        {
            return (int)info.Value;
        }

        public static explicit operator uint (ValueInfo info)
        {
            return (uint)info.Value;
        }

        public ValueInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
