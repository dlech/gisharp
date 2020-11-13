
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    public delegate bool SourceFunc();

    public static class SourceFuncMarshal
    {
        record UserData(SourceFunc Func, CallbackScope Scope);

        public unsafe static SourceFunc FromPointer(IntPtr func_, IntPtr userData_)
        {
            var func = (delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean>)func_;
            return new SourceFunc(() => {
                var ret_ = func(userData_);
                var ret = ret_.IsTrue();
                return ret;
            });
        }

        public unsafe static (IntPtr func_, IntPtr destroy_, IntPtr userData_) ToPointer(SourceFunc func, CallbackScope scope)
        {
            delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean> unmanagedFunc = &UnmanagedFunc;
            delegate* unmanaged[Cdecl]<IntPtr, void> unmanagedNotify = &UnmanagedNotify;
            var userData = GCHandle.Alloc(new UserData(func, scope));

            return ((IntPtr)unmanagedFunc, (IntPtr)unmanagedNotify, (IntPtr)userData);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Runtime.Boolean UnmanagedFunc(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var userData = (UserData)gcHandle.Target!;
                var ret = userData.Func();
                if (userData.Scope == CallbackScope.Async) {
                    gcHandle.Free();
                }
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
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
