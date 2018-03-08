
using System;
using System.Runtime.InteropServices;

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

using nulong = GISharp.Runtime.NativeULong;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Lib.Gio
{
    partial class Cancellable
    {
        public nulong Connect(CancelledCallback callback)
        {
            var this_ = Handle;
            var (connect_, dataDestroyFunc_, data_) = CancelledFactory.Create(callback);
            var ret = g_cancellable_connect(this_, connect_, data_, dataDestroyFunc_);
            return ret;
        }

        public delegate void CancelledCallback(Cancellable cancellable);

        delegate void UnmanagedCancelledCallback(IntPtr cancellable, IntPtr userData);

        static class CancelledFactory
        {
            class UserData
            {
                public CancelledCallback ManagedDelegate;
                public UnmanagedCancelledCallback UnmanagedDelegate;
                public UnmanagedDestroyNotify DestroyDelegate;
            }

            public static (IntPtr, UnmanagedDestroyNotify, IntPtr) Create(CancelledCallback callback)
            {
                var userData = new UserData
                {
                    ManagedDelegate = callback ?? throw new ArgumentNullException(nameof(callback)),
                    UnmanagedDelegate = UnmanagedCallback,
                    DestroyDelegate = Destroy,
                };
                var callback_ = Marshal.GetFunctionPointerForDelegate(userData.UnmanagedDelegate);
                var userData_ = (IntPtr)GCHandle.Alloc(userData);
                return (callback_, userData.DestroyDelegate, userData_);
            }

            static void UnmanagedCallback(IntPtr cancellable_, IntPtr userData_)
            {
                try {
                    var cancellable = Object.GetInstance<Cancellable>(cancellable_, Transfer.None);
                    var gcHandle = (GCHandle)userData_;
                    var userData = (UserData)gcHandle.Target;
                    userData.ManagedDelegate(cancellable);
                }
                catch (System.Exception ex) {
                    ex.LogUnhandledException();
                }
            }

            static void Destroy(IntPtr userData_)
            {
                try {
                    var gcHandle = (GCHandle)userData_;
                    gcHandle.Free();
                }
                catch (System.Exception ex) {
                    ex.LogUnhandledException();
                }
            }
        }
    }
}
