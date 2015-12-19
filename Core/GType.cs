using System;

namespace GISharp.Core
{
    /// <summary>
    /// A numerical value which represents the unique identifier of a registered
    /// type.
    /// </summary>
    public struct GType
    {
        private UInt64 value;

        public static implicit operator GType(UInt64 value)
        {
            return new GType { value = value };
        }

        public static implicit operator UInt64(GType value)
        {
            return value.value;
        }

        public static GType None { get { return 0ul; } }
    }
}
