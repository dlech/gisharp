using System;

namespace GISharp.Core
{
    public struct IntN
    {
        IntPtr value;

        public static implicit operator int (IntN n)
        {
            return n.value.ToInt32 ();
        }

        public static implicit operator long (IntN n)
        {
            return n.value.ToInt64 ();
        }

        public static implicit operator IntN (int i)
        {
            return new IntN { value = (IntPtr)i };
        }

        public static implicit operator IntN (long l)
        {
            return new IntN { value = (IntPtr)l };
        }

        public static IntN operator + (IntN n1, IntN n2)
        {
            if (IntPtr.Size == 4) {
                return n1.value.ToInt32 () + n2.value.ToInt32 ();
            }
            return n1.value.ToInt64 () + n2.value.ToInt64 ();
        }
    }

    public struct UIntN
    {
        UIntPtr value;

        public static implicit operator uint (UIntN un)
        {
            return un.value.ToUInt32 ();
        }

        public static implicit operator ulong (UIntN n)
        {
            return n.value.ToUInt64 ();
        }

        public static implicit operator UIntN (uint ui)
        {
            return new UIntN { value = (UIntPtr)ui };
        }

        public static implicit operator UIntN (ulong ul)
        {
            return new UIntN { value = (UIntPtr)ul };
        }

        public static UIntN operator + (UIntN un1, UIntN un2)
        {
            if (IntPtr.Size == 4) {
                return un1.value.ToUInt32 () + un2.value.ToUInt32 ();
            }
            return un1.value.ToUInt64 () + un2.value.ToUInt64 ();
        }
    }
}
