using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper around unmanged C array.
    /// </summary>
    public unsafe sealed class CArrayMemoryManager<T> : MemoryManager<T> where T : unmanaged
    {
        T* handle;
        readonly int length;
        int refCount;
        bool disposed;

        /// <summary>
        /// Pointer to the unmanged array.
        /// </summary>
        public IntPtr Handle => handle == null ? throw new ObjectDisposedException(null) : (IntPtr)handle;

        /// <summary>
        /// Creates a new memory manager for unmanged C arrays.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <inheritdoc/>
        public override Span<T> GetSpan()
        {
            // FIXME: what about case of null-terminated array?
            return new Span<T>(handle, length);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
