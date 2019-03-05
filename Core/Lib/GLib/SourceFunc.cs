
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
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

    public static class SourceFuncFactory
    {
        class UserData
        {
            public readonly SourceFunc Func;
            public readonly UnmanagedSourceFunc UnmanagedFunc;
            public readonly UnmanagedDestroyNotify UnmanagedNotify;
            public readonly CallbackScope Scope;

            public UserData(SourceFunc func, UnmanagedSourceFunc unmanagedFunc,
                UnmanagedDestroyNotify unmanagedNotify, CallbackScope scope)
            {
                Func = func;
                UnmanagedFunc = unmanagedFunc;
                UnmanagedNotify = unmanagedNotify;
                Scope = scope;
            }
        }

        public static SourceFunc Create(UnmanagedSourceFunc func, IntPtr userData)
        {
            return new SourceFunc(() => {
                var ret = func(userData);
                return ret;
            });
        }

        public static (UnmanagedSourceFunc, UnmanagedDestroyNotify, IntPtr) Create(SourceFunc func, CallbackScope scope) {
            var data = new UserData(func, UnmanagedFunc, UnmanagedNotify, scope);
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
