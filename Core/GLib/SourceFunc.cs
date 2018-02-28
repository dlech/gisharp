
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool UnmanagedSourceFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:0 */
        IntPtr userData);

    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    public delegate bool SourceFunc();

    public static class UnmanagedSourceFuncFactory
    {
        class UserData
        {
            public SourceFunc Func;
            public UnmanagedSourceFunc UnmanagedFunc;
            public UnmanagedDestroyNotify UnmanagedNotify;
            public CallbackScope Scope;
        }

        public static (UnmanagedSourceFunc, UnmanagedDestroyNotify, IntPtr) Create(SourceFunc func, CallbackScope scope) {
            var data = new UserData {
                Func = func ?? throw new ArgumentNullException(nameof(func)),
                UnmanagedFunc = UnmanagedFunc,
                UnmanagedNotify = UnmanagedNotify,
                Scope = scope
            };
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnmanagedFunc, data.UnmanagedNotify, (IntPtr)gcHandle);
        }

        static bool UnmanagedFunc(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                var ret = userData.Func();
                if (userData.Scope == CallbackScope.Async) {
                    gcHandle.Free();
                }
                return ret;
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default(bool);
            }
        }

        static void UnmanagedNotify(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }
}
