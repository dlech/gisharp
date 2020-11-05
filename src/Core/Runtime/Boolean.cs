using System;

namespace GISharp.Runtime
{
    public readonly struct Boolean : IEquatable<bool>
    {
        public static readonly Boolean True = new(1);
        public static readonly Boolean False = new(0);

        readonly int value;

        private Boolean(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value == 0 ? false.ToString() : true.ToString();
        }

        bool IEquatable<bool>.Equals(bool other)
        {
            return this == other;
        }

        public static implicit operator bool(Boolean b)
        {
            return b.value != 0;
        }

        public static implicit operator Boolean(bool b)
        {
            return b ? True : False;
        }
    }
}
