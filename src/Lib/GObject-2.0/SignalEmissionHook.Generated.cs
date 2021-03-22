// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A simple function pointer to get invoked when the signal is emitted. This
    /// allows you to tie a hook to the signal type, so that it will trap all
    /// emissions of that signal, from any object.
    /// </summary>
    /// <remarks>
    /// <para>
    /// You may not attach these to signals created with the #G_SIGNAL_NO_HOOKS flag.
    /// </para>
    /// </remarks>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedSignalEmissionHook(
    /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.SignalInvocationHint* ihint,
    /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
    /* transfer-ownership:none direction:in */
    uint nParamValues,
    /* <array length="1" zero-terminated="0" type="const GValue*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="Value" type="GValue" managed-name="Value" />
* </array> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.Value* paramValues,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:3 direction:in */
    System.IntPtr data);

    /// <include file="SignalEmissionHook.xmldoc" path="declaration/member[@name='SignalEmissionHook']/*" />
    public delegate bool SignalEmissionHook(ref GISharp.Lib.GObject.SignalInvocationHint ihint, System.ReadOnlySpan<GISharp.Lib.GObject.Value> paramValues);

    /// <summary>
    /// Class for marshalling <see cref="SignalEmissionHook"/> methods.
    /// </summary>
    public static unsafe class SignalEmissionHookMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="SignalEmissionHook"/>.
        /// </summary>
        public static GISharp.Lib.GObject.SignalEmissionHook FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.SignalInvocationHint*, uint, GISharp.Lib.GObject.Value*, System.IntPtr, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            var data_ = userData_;
            bool managedCallback(ref GISharp.Lib.GObject.SignalInvocationHint ihint, System.ReadOnlySpan<GISharp.Lib.GObject.Value> paramValues)
            {
                fixed (GISharp.Lib.GObject.Value* paramValuesData_ = paramValues)
                {
                    fixed (GISharp.Lib.GObject.SignalInvocationHint* ihint_ = &ihint)
                    {
                        var paramValues_ = (GISharp.Lib.GObject.Value*)paramValuesData_;
                        var nParamValues_ = (uint)paramValues.Length;
                        var ret_ = callback_(ihint_,nParamValues_,paramValues_,data_);
                        GISharp.Runtime.GMarshal.PopUnhandledException();
                        var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                        return ret;
                    }
                }
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Runtime.Boolean Callback(GISharp.Lib.GObject.SignalInvocationHint* ihint_, uint nParamValues_, GISharp.Lib.GObject.Value* paramValues_, System.IntPtr data_)
        {
            try
            {
                ref var ihint = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.SignalInvocationHint>(ihint_);
                var paramValues = new System.ReadOnlySpan<GISharp.Lib.GObject.Value>(paramValues_, (int)nParamValues_);
                var dataHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var (data, dataScope) = ((SignalEmissionHook, GISharp.Runtime.CallbackScope))dataHandle.Target!;
                var ret = data.Invoke(ref ihint, paramValues);
                if (dataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    dataHandle.Free();
                }

                var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }
    }
}