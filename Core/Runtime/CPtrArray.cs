using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public abstract class CPtrArray : Opaque
    {
        protected int Length { get; }

        protected CPtrArray(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.Full) {
                this.handle = IntPtr.Zero;
                throw new NotSupportedException();
            }
            if (ownership != Transfer.Container) {
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

        public static CPtrArray<T> GetInstance<T>(IntPtr handle, int length, Transfer ownership) where T : IOpaque?
        {
            return new CPtrArray<T>(handle, length, ownership);
        }
    }

    public class CPtrArray<T> : CPtrArray, IReadOnlyList<T> where T : IOpaque?
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

        private unsafe ReadOnlySpan<IntPtr> Data => new ReadOnlySpan<IntPtr>((void*)Handle, Length);

        public int Count => Length;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        public static implicit operator UnownedCPtrArray<T>(CPtrArray<T>? array)
        {
            if (array == null) {
                return default(UnownedCPtrArray<T>);
            }
            return new UnownedCPtrArray<T>(array.Data);
        }
    }

    public ref struct UnownedCPtrArray<T> where T : IOpaque?
    {
        public ReadOnlySpan<IntPtr> Data { get; }

        public unsafe UnownedCPtrArray(IntPtr handle, int length, Transfer ownership)
        {
            if (ownership != Transfer.None) {
                throw new NotSupportedException();
            }
            if (length < 0) {
                // TODO: lazy-get length for null terminated arrays
                throw new NotSupportedException();
            }
            Data = new ReadOnlySpan<IntPtr>((void*)handle, length);
        }

        public UnownedCPtrArray(ReadOnlySpan<IntPtr> data)
        {
            Data = data;
        }

        public T this[int index] {
            get {
                if (index < 0 || index >= Data.Length) {
                    throw new IndexOutOfRangeException();
                }
                return Opaque.GetInstance<T>(Data[index], Transfer.None);
            }
        }

        public int Length => Data.Length;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ref readonly IntPtr GetPinnableReference()
        {
            return ref Data.GetPinnableReference();
        }

        public ref struct Enumerator
        {
            private readonly UnownedCPtrArray<T> array;
            private int index;

            internal Enumerator(UnownedCPtrArray<T> array)
            {
                this.array = array;
                index = -1;
            }
            public T Current => array[index];

            public bool MoveNext()
            {
                index++;
                return index < array.Data.Length;
            }
        }

        public Enumerator GetEnumerator() => new Enumerator(this);
    }
}
