
namespace GISharp.Runtime
{
    public struct NativeLong
    {
        public static readonly NativeLong MinValue = new NativeLong (long.MinValue);

        public static readonly NativeLong MaxValue = new NativeLong (long.MaxValue);

        readonly long value;

        NativeLong (long value)
        {
            this.value = value;
        }

        public static NativeLong operator + (NativeLong a, NativeLong b)
        {
            return new NativeLong (a.value + b.value);
        }

        public static NativeLong operator - (NativeLong a, NativeLong b)
        {
            return new NativeLong (a.value - b.value);
        }

        public static NativeLong operator * (NativeLong a, NativeLong b)
        {
            return new NativeLong (a.value * b.value);
        }

        public static NativeLong operator / (NativeLong a, NativeLong b)
        {
            return new NativeLong (a.value / b.value);
        }

        public static NativeLong operator % (NativeLong a, NativeLong b)
        {
            return new NativeLong (a.value % b.value);
        }

        public static NativeLong operator << (NativeLong a, int b)
        {
            return new NativeLong (a.value << b);
        }

        public static NativeLong operator >> (NativeLong a, int b)
        {
            return new NativeLong (a.value >> b);
        }

        public static bool operator < (NativeLong a, NativeLong b)
        {
            return a.value < b.value;
        }

        public static bool operator > (NativeLong a, NativeLong b)
        {
            return a.value > b.value;
        }

        public static bool operator <= (NativeLong a, NativeLong b)
        {
            return a.value <= b.value;
        }

        public static bool operator >= (NativeLong a, NativeLong b)
        {
            return a.value >= b.value;
        }

        public static implicit operator NativeLong (int n)
        {
            return new NativeLong (n);
        }

        public static implicit operator long (NativeLong n)
        {
            return n.value;
        }

        public override bool Equals (object obj)
        {
            if (obj is NativeLong) {
                return value == ((NativeLong)obj).value;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }
    }

    public struct NativeULong
    {
        public static readonly NativeULong MinValue = new NativeULong (ulong.MinValue);

        public static readonly NativeULong MaxValue = new NativeULong (ulong.MaxValue);

        readonly ulong value;

        NativeULong (ulong value)
        {
            this.value = value;
        }

        public static NativeULong operator + (NativeULong a, NativeULong b)
        {
            return new NativeULong (a.value + b.value);
        }

        public static NativeULong operator - (NativeULong a, NativeULong b)
        {
            return new NativeULong (a.value - b.value);
        }

        public static NativeULong operator * (NativeULong a, NativeULong b)
        {
            return new NativeULong (a.value * b.value);
        }

        public static NativeULong operator / (NativeULong a, NativeULong b)
        {
            return new NativeULong (a.value / b.value);
        }

        public static NativeULong operator % (NativeULong a, NativeULong b)
        {
            return new NativeULong (a.value % b.value);
        }

        public static NativeULong operator << (NativeULong a, int b)
        {
            return new NativeULong (a.value << b);
        }

        public static NativeULong operator >> (NativeULong a, int b)
        {
            return new NativeULong (a.value >> b);
        }

        public static bool operator < (NativeULong a, NativeULong b)
        {
            return a.value < b.value;
        }

        public static bool operator > (NativeULong a, NativeULong b)
        {
            return a.value > b.value;
        }

        public static bool operator <= (NativeULong a, NativeULong b)
        {
            return a.value <= b.value;
        }

        public static bool operator >= (NativeULong a, NativeULong b)
        {
            return a.value >= b.value;
        }

        public static implicit operator NativeULong (uint n)
        {
            return new NativeULong (n);
        }

        public static implicit operator ulong (NativeULong n)
        {
            return n.value;
        }

        public override bool Equals (object obj)
        {
            if (obj is NativeULong) {
                return value == ((NativeULong)obj).value;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }
    }
}
