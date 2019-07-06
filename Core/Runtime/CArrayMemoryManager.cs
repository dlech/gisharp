using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public unsafe sealed class CArrayMemoryManager<T> : MemoryManager<T>, IOpaque where T : unmanaged
    {
        T* handle;
        readonly int length;
        int refCount;
        bool disposed;

        public IntPtr Handle => handle == null ? throw new ObjectDisposedException(null) : (IntPtr)handle;

        public CArrayMemoryManager(IntPtr handle, int length, Transfer ownership) {
            if (ownership == Transfer.None) {
                throw new NotSupportedException("Unowned arrays should use ReadOnlySpan<T>");
            }
            // TODO: what about full vs. container. It seems that there are many
            // cases where full is specified, but there is actually nothing to
            // be done to free the elements (e.g. byte array, GType array, etc.)
            this.handle = (T*)handle;
            this.length = length;
            refCount = 1;
        }

        public override Span<T> GetSpan()
        {
            // FIXME: what about case of null-terminated array?
            return new Span<T>(handle, length);
        }

        public override MemoryHandle Pin(int elementIndex = 0)
        {
            lock (this) {
                if (refCount == 0) {
                    throw new ObjectDisposedException(null);
                }
                refCount++;
                return new MemoryHandle(handle, GCHandle.Alloc(this), this);
            }
        }

        public override void Unpin()
        {
            lock (this) {
                refCount--;
                if (refCount == 0) {
                    GMarshal.Free((IntPtr)handle);
                    handle = null;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (this) {
                if (!disposed) {
                    disposed = true;
                    // free the initial reference
                    Unpin();
                }
            }
        }
    }
}
