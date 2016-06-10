using System;
using System.Runtime.InteropServices;
using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base class for all GType struct wrappers.
    /// </summary>
    /// <remarks>
    /// This does not have a cooresponding type in GObject, but rather TypeClass,
    /// TypeInterface, etc. are considered fundamental. However, to make things
    /// easier in managed code, we can pretend that they are related.
    /// </remarks>
    public abstract class GTypeStruct : IDisposable
    {
        readonly bool ownsRef;

        /// <summary>
        /// Gets the unmanged handle.
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets the GType that cooresponds to this struct.
        /// </summary>
        public GType GType {
            get {
                // GType is always the first field
                return Marshal.PtrToStructure<GType> (Handle);
            }
        }

        /// <summary>
        /// Gets the actual struct for the type to be used for marshalling.
        /// </summary>
        public abstract Type StructType { get; }

        protected GTypeStruct (IntPtr handle, bool ownsRef)
        {
            Handle = handle;
            this.ownsRef = ownsRef;
        }

        #region IDisposable implementation

        public void Dispose ()
        {
            Dispose (true, ownsRef);
            GC.SuppressFinalize (this);
        }

        protected abstract void Dispose (bool disposing, bool ownsRef);

        ~GTypeStruct ()
        {
            Dispose (false, ownsRef);
        }

        #endregion

        public static GTypeStruct CreateInstance (IntPtr handle, bool ownsRef)
        {
            if (handle == IntPtr.Zero) {
                return null;
            }
            var gtype = Marshal.PtrToStructure<GType> (handle);
            var type = gtype.GetGTypeStruct ();
            var ret = Activator.CreateInstance (type, new object[] { handle, ownsRef }, null);
            return (GTypeStruct)ret;
        }
    }
}
