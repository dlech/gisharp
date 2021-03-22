// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The signal accumulator is a special callback function that can be used
    /// to collect return values of the various callbacks that are called
    /// during a signal emission. The signal accumulator is specified at signal
    /// creation time, if it is left %NULL, no accumulation of callback return
    /// values is performed. The return value of signal emissions is then the
    /// value returned by the last callback.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedSignalAccumulator(
    /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.SignalInvocationHint* ihint,
    /* <type name="Value" type="GValue*" managed-name="Value" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.Value* returnAccu,
    /* <type name="Value" type="const GValue*" managed-name="Value" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.Value* handlerReturn,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr data);

    /// <include file="SignalAccumulator.xmldoc" path="declaration/member[@name='SignalAccumulator']/*" />
    public delegate bool SignalAccumulator(ref GISharp.Lib.GObject.SignalInvocationHint ihint, ref GISharp.Lib.GObject.Value returnAccu, in GISharp.Lib.GObject.Value handlerReturn, System.IntPtr data);

    /// <summary>
    /// Class for marshalling <see cref="SignalAccumulator"/> methods.
    /// </summary>
    public static unsafe class SignalAccumulatorMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="SignalAccumulator"/>.
        /// </summary>
        public static GISharp.Lib.GObject.SignalAccumulator FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.SignalInvocationHint*, GISharp.Lib.GObject.Value*, GISharp.Lib.GObject.Value*, System.IntPtr, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            bool managedCallback(ref GISharp.Lib.GObject.SignalInvocationHint ihint, ref GISharp.Lib.GObject.Value returnAccu, in GISharp.Lib.GObject.Value handlerReturn, System.IntPtr data)
            {
                fixed (GISharp.Lib.GObject.Value* handlerReturn_ = &handlerReturn)
                {
                    fixed (GISharp.Lib.GObject.Value* returnAccu_ = &returnAccu)
                    {
                        fixed (GISharp.Lib.GObject.SignalInvocationHint* ihint_ = &ihint)
                        {
                            var data_ = (System.IntPtr)data;
                            var ret_ = callback_(ihint_,returnAccu_,handlerReturn_,data_);
                            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                            return ret;
                        }
                    }
                }
            }

            return managedCallback;
        }
    }
}