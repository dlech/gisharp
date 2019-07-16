using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A simple function pointer to get invoked when the signal is emitted. This
    /// allows you to tie a hook to the signal type, so that it will trap all
    /// emissions of that signal, from any object.
    /// </summary>
    /// <remarks>
    /// You may not attach these to signals created with the #G_SIGNAL_NO_HOOKS flag.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate bool UnmanagedSignalEmissionHook (
        /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" /> */
        /* transfer-ownership:none */
        SignalInvocationHint ihint,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nParamValues,
        /* <array length="1" zero-terminated="0" type="GValue*">
            <type name="Value" type="GValue" managed-name="Value" />
            </array> */
        /* transfer-ownership:none */
        IntPtr paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data);

    /// <summary>
    /// The type used for callback functions in structure definitions and function
    /// signatures. This doesn't mean that all callback functions must take no
    /// parameters and return void. The required signature of a callback function
    /// is determined by the context in which is used (e.g. the signal to which it
    /// is connected). Use G_CALLBACK() to cast the callback function to a #GCallback.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void UnmanagedCallback();

    /// <summary>
    /// The type used for the various notification callbacks which can be registered
    /// on closures.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void UnmanagedClosureNotify(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data,
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure);

    public delegate bool SignalAccumulator(SignalInvocationHint invocationHint, ref Value returnAccu, ref Value handlerReturn);

    /// <summary>
    /// The signal accumulator is a special callback function that can be used
    /// to collect return values of the various callbacks that are called
    /// during a signal emission. The signal accumulator is specified at signal
    /// creation time, if it is left %NULL, no accumulation of callback return
    /// values is performed. The return value of signal emissions is then the
    /// value returned by the last callback.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate bool UnmanagedSignalAccumulator (
        /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" /> */
        /* transfer-ownership:none */
        SignalInvocationHint ihint,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        IntPtr returnAccu,
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        IntPtr handlerReturn,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data);

    /// <summary>
    /// This is the signature of marshaller functions, required to marshall
    /// arrays of parameter values to signal emissions into C language callback
    /// invocations. It is merely an alias to #GClosureMarshal since the #GClosure
    /// mechanism takes over responsibility of actual function invocation for the
    /// signal system.
    /// </summary>
    public delegate void SignalCMarshaller(Closure closure, ref object? returnValue, object[] paramValues, SignalInvocationHint? invocationHint);

    /// <summary>
    /// This is the signature of marshaller functions, required to marshall
    /// arrays of parameter values to signal emissions into C language callback
    /// invocations. It is merely an alias to #GClosureMarshal since the #GClosure
    /// mechanism takes over responsibility of actual function invocation for the
    /// signal system.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    unsafe delegate void UnmanagedSignalCMarshaller(
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
         *   <type name="Value" type="GValue" managed-name="Value" />
         * </array> */
        /* transfer-ownership:none */
        Value* paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr invocationHint,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr marshalData);

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate bool UnmanagedBindingTransformFunc (
        IntPtr binding,
        ref Value fromValue,
        ref Value toValue,
        IntPtr userData);

    /// <summary>
    /// A function to be called to transform <paramref name="fromValue"/> to <paramref name="toValue"/>.
    /// </summary>
    /// <remarks>
    /// If this is the <c>transformTo</c> function of a binding, then <paramref name="fromValue"/>
    /// is the <c>sourceProperty</c> on the source object, and <paramref name="toValue"/>
    /// is the <c>targetProperty</c> on the target object. If this is the <c>transformFrom</c>
    /// function of a <see cref="BindingFlags.Bidirectional"/> binding, then those roles are reversed.
    /// </remarks>
    public delegate bool BindingTransformFunc (
        Binding binding,
        ref Value fromValue,
        ref Value toValue);
}
