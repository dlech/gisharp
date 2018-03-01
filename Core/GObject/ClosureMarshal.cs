using System;
using System.Runtime.InteropServices;
using GISharp.GLib;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// The type used for marshaller functions.
    /// </summary>
    public delegate void ClosureMarshal(Closure closure, ref Value returnValue, Value[] paramValues, SignalInvocationHint? invocationHint);

    /// <summary>
    /// The type used for marshaller functions.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void UnmanagedClosureMarshal(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr returnValue,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nParamValues,
        /* <array length="2" zero-terminated="0" type="GValue*">
            <type name="Value" type="GValue" managed-name="Value" />
            </array> */
        /* transfer-ownership:none */
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        Value[] paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr invocationHint,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr marshalData);

    static class ClosureMarshalFactory
    {
        class UserData {
            public ClosureMarshal ClosureMarshal;
            public UnmanagedClosureMarshal UnmanagedClosureMarshal;
            public UnmanagedClosureNotify UnmanagedClosureNotify;
            public CallbackScope Scope;
        }

        public static (UnmanagedClosureMarshal, UnmanagedClosureNotify, IntPtr) Create(ClosureMarshal closureMarshal, CallbackScope scope)
        {
            var userData = new UserData {
                ClosureMarshal = closureMarshal ?? throw new ArgumentNullException(nameof(closureMarshal)),
                UnmanagedClosureMarshal = UnmanagedClosureMarshal,
                UnmanagedClosureNotify = UnmanagedClosureNotify,
                Scope = scope
            };
            var userData_ = GCHandle.Alloc(userData);

            return (userData.UnmanagedClosureMarshal, userData.UnmanagedClosureNotify, (IntPtr)userData_);
        }

        static void UnmanagedClosureMarshal(IntPtr closure_, IntPtr returnValue_, uint nParamValues_, Value[] paramValues_, IntPtr invocationHint_, IntPtr marshalData_)
        {
            try {
                var closure = Opaque.GetInstance<Closure>(closure_, Transfer.None);
                var returnValue = default(Value);
                if (returnValue_ != IntPtr.Zero) {
                    returnValue = Marshal.PtrToStructure<Value>(returnValue_);
                }
                SignalInvocationHint? invocationHint = null;
                if (invocationHint_ != IntPtr.Zero) {
                    invocationHint = Marshal.PtrToStructure<SignalInvocationHint>(invocationHint_);
                }
                var gcHandle = (GCHandle)marshalData_;
                var marshalData = (UserData)gcHandle.Target;
                marshalData.ClosureMarshal(closure, ref returnValue, paramValues_, invocationHint);
                if (returnValue_ != IntPtr.Zero) {
                    Marshal.StructureToPtr<Value>(returnValue, returnValue_, false);
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
