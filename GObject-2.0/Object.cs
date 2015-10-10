using System;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace GISharp.GObject
{
    public partial class Object
    {
        GCHandle toggleRefGCHandle;

        protected Object (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
            // we are guaranteed to have a reference at this point.

            // this allocates a GCHandle in case someone else has a reference already.
            handleToggleRef (IntPtr.Zero, Handle, false);
            // This will free the GCHandle if we have the only reference
            SwapRefForToggleRef ();
        }

        protected override void Ref ()
        {
            AssertNotDisposed ();
            // take the floating reference if there is one
            g_object_ref_sink (Handle);
            SwapRefForToggleRef ();
        }

        void SwapRefForToggleRef ()
        {
            // use toggle reference so we don't get GCed when unmanaged code still has a reference
            g_object_add_toggle_ref (Handle, handleToggleRef, IntPtr.Zero);
            // release the original ref since we now have a toggle ref
            g_object_unref (Handle);
        }

        protected override void Unref ()
        {
            AssertNotDisposed ();
            g_object_remove_toggle_ref (Handle, handleToggleRef, IntPtr.Zero);
        }

        void handleToggleRef (IntPtr data, IntPtr obj, bool isLastRef)
        {
            if (isLastRef) {
                toggleRefGCHandle.Free ();
            } else {
                toggleRefGCHandle = GCHandle.Alloc (this);
            }
        }
    }
}
