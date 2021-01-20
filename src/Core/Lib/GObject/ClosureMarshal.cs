// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The type used for marshaller functions.
    /// </summary>
    public delegate void ClosureMarshal(Closure closure, ref object? returnValue, object?[] paramValues, SignalInvocationHint? invocationHint);

    /// <summary>
    /// The type used for marshaller functions.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void UnmanagedClosureMarshal(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        Value* returnValue,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nParamValues,
        /* <array length="2" zero-terminated="0" type="GValue*">
            <type name="Value" type="GValue" managed-name="Value" />
            </array> */
        /* transfer-ownership:none */
        Value* paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr invocationHint,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr marshalData);

    static class ClosureMarshalFactory
    {
        class UserData {
            public readonly ClosureMarshal ClosureMarshal;
            public readonly UnmanagedClosureMarshal UnmanagedClosureMarshal;
            public readonly UnmanagedClosureNotify UnmanagedClosureNotify;
            public readonly CallbackScope Scope;

            public UserData(ClosureMarshal closureMarshal, UnmanagedClosureMarshal unmanagedClosureMarshal, UnmanagedClosureNotify unmanagedClosureNotify, CallbackScope scope)
            {
                ClosureMarshal = closureMarshal;
                UnmanagedClosureMarshal = unmanagedClosureMarshal;
                UnmanagedClosureNotify = unmanagedClosureNotify;
                Scope = scope;
            }
        }

        public unsafe static (UnmanagedClosureMarshal, UnmanagedClosureNotify, IntPtr) Create(ClosureMarshal closureMarshal, CallbackScope scope)
        {
            var userData = new UserData(closureMarshal, UnmanagedClosureMarshal, UnmanagedClosureNotify, scope);
            var userData_ = GCHandle.Alloc(userData);

            return (userData.UnmanagedClosureMarshal, userData.UnmanagedClosureNotify, (IntPtr)userData_);
        }

        static unsafe void UnmanagedClosureMarshal(IntPtr closure_, Value* returnValue_, uint nParamValues_, Value* paramValues_, IntPtr invocationHint_, IntPtr marshalData_)
        {
            try {
                var closure = Opaque.GetInstance<Closure>(closure_, Transfer.None);
                object? returnValue = null;
                if (returnValue_ is not null) {
                    returnValue = returnValue_->Get();
                }
                var paramValues = new object?[nParamValues_];
                for (int i = 0; i < nParamValues_; i++) {
                    paramValues[i] = paramValues_[i].Get();
                }
                SignalInvocationHint? invocationHint = null;
                if (invocationHint_ != IntPtr.Zero) {
                    invocationHint = Marshal.PtrToStructure<SignalInvocationHint>(invocationHint_);
                }
                var gcHandle = (GCHandle)marshalData_;
                var marshalData = (UserData)gcHandle.Target!;
                marshalData.ClosureMarshal(closure, ref returnValue, paramValues, invocationHint);

                if (returnValue_ is not null) {
                    returnValue_->Set(returnValue!);
                }
                if (marshalData.Scope == CallbackScope.Async) {
                    UnmanagedClosureNotify(marshalData_, closure_);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void UnmanagedClosureNotify(IntPtr data_, IntPtr closure_)
        {
            try {
                var gcHandle = (GCHandle)data_;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }
}
