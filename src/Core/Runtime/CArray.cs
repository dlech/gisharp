using System;
using System.Collections;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    public abstract class CArray : Opaque
    {
        protected int Length { get; }

        protected CArray(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                handle = IntPtr.Zero;
                throw new NotSupportedException();
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

        public (IntPtr, int) TakeData()
        {
            var ret = (Handle, Length);
            handle = IntPtr.Zero;
            return ret;
        }

        public static CArray<T> GetInstance<T>(IntPtr handle, int length, Transfer ownership) where T : unmanaged
        {
            return new CArray<T>(handle, length, ownership);
        }
    }

    public class CArray<T> : CArray, IReadOnlyList<T> where T : unmanaged
    {
        public CArray(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }

        public unsafe CArray(T* array, int length, Transfer ownership) : this((IntPtr)array, length, ownership)
        {
        }

        public unsafe T this[int index] {
            get {
                var this_ = (T*)Handle;
                if (index < 0 || index >= Length) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                var ret = this_[index];
                return ret;
            }
        }

        public int Count => Length;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        public static unsafe implicit operator ReadOnlySpan<T>(CArray<T> array)
        {
            return new ReadOnlySpan<T>((void*)array.Handle, array.Length);
        }
    }
}
