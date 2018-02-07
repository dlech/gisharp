using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public abstract class CPtrArray : Opaque
    {
        public bool Owned { get; }

        public int Length { get; }

        public CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.Full) {
                this.handle = IntPtr.Zero;
                throw new NotSupportedException();
            }
            if (ownership != Transfer.None) {
                Owned = true;
            }
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            Length = length;
        }

        protected override void Dispose(bool disposing)
        {
            GMarshal.Free(handle);
            base.Dispose(disposing);
        }

        public static CPtrArray<T> GetInstance<T>(IntPtr handle, int length, Transfer ownership) where T :Opaque
        {
            return new CPtrArray<T>(handle, length, ownership);
        }
    }

    public class CPtrArray<T> : CPtrArray, IPtrArray<T> where T : Opaque
    {
        public CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }

        public T this[int index] {
            get {
                var this_ = Handle;
                if (index < 0 || index >= Length) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                var offset = IntPtr.Size * index;
                var ptr = Marshal.ReadIntPtr(this_, offset);
                return Opaque.GetInstance<T>(ptr, Transfer.None);
            }
        }

        IntPtr IPtrArray<T>.Data => Handle;

        int IReadOnlyCollection<T>.Count => Length;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
    }
}
