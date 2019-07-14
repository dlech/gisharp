
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
    public delegate Runtime.Boolean UnmanagedSourceFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:0 */
        IntPtr userData);

    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    public delegate bool SourceFunc();

    public static class SourceFuncMarshal
    {
        class UserData
        {
            public readonly SourceFunc Func;
            public readonly CallbackScope Scope;

            public UserData(SourceFunc func, CallbackScope scope)
            {
                Func = func;
                Scope = scope;
            }
        }

        public static SourceFunc FromPointer(IntPtr func_, IntPtr userData_)
        {
            var func = Marshal.GetDelegateForFunctionPointer<UnmanagedSourceFunc>(func_);
            return new SourceFunc(() => {
                var ret = func(userData_);
                return ret;
            });
        }

        public static (IntPtr func_, IntPtr destroy_, IntPtr userData_) ToPointer(SourceFunc func, CallbackScope scope)
        {
            var data = new UserData(func, scope);
            var gcHandle = GCHandle.Alloc(data);
            var userData_ = (IntPtr)gcHandle;

            return (unmanagedFunc_, unmanagedNotify_, userData_);
        }

        static readonly UnmanagedSourceFunc UnmanagedFuncDelegate = UnmanagedFunc;
        static readonly IntPtr unmanagedFunc_ = Marshal.GetFunctionPointerForDelegate(UnmanagedFuncDelegate);
        static Runtime.Boolean UnmanagedFunc(IntPtr userData_)
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
                return default;
            }
        }

        static readonly UnmanagedDestroyNotify UnmanagedNotifyDelegate = UnmanagedNotify;
        static readonly IntPtr unmanagedNotify_ = Marshal.GetFunctionPointerForDelegate(UnmanagedNotifyDelegate);
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
