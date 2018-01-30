using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using GISharp.Runtime;
using GISharp.GLib;

using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
{
    public static class Signal
    {
        static Regex signalNameRegex = new Regex("^[a-zA-Z](?:[a-zA-Z0-9_]*|[a-zA-Z0-9-]*)$", RegexOptions.CultureInvariant);

        ///<summary>
        /// Tests if a signal name is valid.
        /// </summary>
        /// <remarks>
        /// A signal name consists of segments consisting of ASCII letters and
        /// digits, separated by either the '-' or '_' character. The first
        /// character of a signal name must be a letter. Names which violate
        /// these rules lead to undefined behavior of the GSignal system.
        ///
        /// When registering a signal and looking up a signal, either separator
        /// can be used, but they cannot be mixed.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="name"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="name"/> does not meet the criteria
        /// specified in the remarks.
        /// </exception>
        public static void ValidateName(string name)
        {
            if (!signalNameRegex.IsMatch(name)) {
                var msg = "does not meet GSignal name criteria";
                throw new ArgumentException(msg, nameof(name));
            }
        }

        /// <summary>
        /// Adds an emission hook for a signal, which will get called for any emission
        /// of that signal, independent of the instance. This is possible only
        /// for signals which don't have #G_SIGNAL_NO_HOOKS flag set.
        /// </summary>
        /// <param name="signalId">
        /// the signal identifier, as returned by g_signal_lookup().
        /// </param>
        /// <param name="detail">
        /// the detail on which to call the hook.
        /// </param>
        /// <param name="hookFunc">
        /// a #GSignalEmissionHook function.
        /// </param>
        /// <param name="hookData">
        /// user data for @hook_func.
        /// </param>
        /// <param name="dataDestroy">
        /// a #GDestroyNotify for @hook_data.
        /// </param>
        /// <returns>
        /// the hook id, for later use with g_signal_remove_emission_hook().
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        static extern nulong g_signal_add_emission_hook (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark detail,
            /* <type name="SignalEmissionHook" type="GSignalEmissionHook" managed-name="SignalEmissionHook" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            UnmanagedSignalEmissionHook hookFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr hookData,
            /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GLib.DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify dataDestroy);

        /// <summary>
        /// Adds an emission hook for a signal, which will get called for any emission
        /// of that signal, independent of the instance. This is possible only
        /// for signals which don't have #G_SIGNAL_NO_HOOKS flag set.
        /// </summary>
        /// <param name="signalId">
        /// the signal identifier, as returned by g_signal_lookup().
        /// </param>
        /// <param name="detail">
        /// the detail on which to call the hook.
        /// </param>
        /// <param name="hookFunc">
        /// a #GSignalEmissionHook function.
        /// </param>
        /// <returns>
        /// the hook id, for later use with g_signal_remove_emission_hook().
        /// </returns>
        //        public static nulong AddEmissionHook (uint signalId, Quark detail, SignalEmissionHook hookFunc)
        //        {
        //            if (hookFunc == null) {
        //                throw new ArgumentNullException ("hookFunc");
        //            }
        //            var hookFunc_ = UnmanagedSignalEmissionHookFactory.Create (hookFunc, false);
        //            var hookFuncHandle = GCHandle.Alloc (hookFunc);
        //            var dataDestroy_ = UnmanagedDestoryNotifyFactory.Create (hookFuncHandle);
        //            var hookData_ = GCHandle.ToIntPtr (GCHandle.Alloc (dataDestroy_));
        //            var ret = g_signal_add_emission_hook (signalId, detail, hookFunc_, hookData_, dataDestroy_);
        //            return ret;
        //        }

        /// <summary>
        /// Calls the original class closure of a signal. This function should only
        /// be called from an overridden class closure; see
        /// g_signal_override_class_closure() and
        /// g_signal_override_class_handler().
        /// </summary>
        /// <param name="instanceAndParams">
        /// the argument list of the signal emission.
        ///  The first element in the array is a #GValue for the instance the signal
        ///  is being emitted on. The rest are any arguments to be passed to the signal.
        /// </param>
        /// <param name="returnValue">
        /// Location for the return value.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_chain_from_overridden (
            /* <array zero-terminated="0" type="GValue*">
                <type name="Value" type="GValue" managed-name="Value" />
                </array> */
            /* transfer-ownership:none */
            IntPtr instanceAndParams,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr returnValue);

        /// <summary>
        /// Calls the original class closure of a signal. This function should only
        /// be called from an overridden class closure; see
        /// g_signal_override_class_closure() and
        /// g_signal_override_class_handler().
        /// </summary>
        /// <param name="instanceAndParams">
        /// the argument list of the signal emission.
        ///  The first element in the array is a #GValue for the instance the signal
        ///  is being emitted on. The rest are any arguments to be passed to the signal.
        /// </param>
        /// <param name="returnValue">
        /// Location for the return value.
        /// </param>
        //        public static void ChainFromOverridden (Value[] instanceAndParams, Value returnValue)
        //        {
        //            if (instanceAndParams == null) {
        //                throw new ArgumentNullException ("instanceAndParams");
        //            }
        //            if (returnValue == null) {
        //                throw new ArgumentNullException ("returnValue");
        //            }
        //            var instanceAndParams_ = MarshalG.OpaqueCArrayToPtr<Value> (instanceAndParams, false);
        //            var returnValue_ = returnValue == null ? IntPtr.Zero : returnValue.Handle;
        //            g_signal_chain_from_overridden (instanceAndParams_, returnValue_);
        //            MarshalG.Free (instanceAndParams_);
        //        }

        /// <summary>
        /// Connects a closure to a signal for a particular object.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="closure">
        /// the closure to connect.
        /// </param>
        /// <param name="after">
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        static extern nulong g_signal_connect_closure (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr detailedSignal,
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool after);

        /// <summary>
        /// Connects a closure to a signal for a particular object.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="closure">
        /// the closure to connect.
        /// </param>
        /// <param name="after">
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        //        public static nulong ConnectClosure (Object instance, string detailedSignal, Closure closure, bool after)
        //        {
        //            if (instance == null) {
        //                throw new ArgumentNullException ("instance");
        //            }
        //            if (detailedSignal == null) {
        //                throw new ArgumentNullException ("detailedSignal");
        //            }
        //            if (closure == null) {
        //                throw new ArgumentNullException ("closure");
        //            }
        //            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
        //            var detailedSignal_ = MarshalG.StringToUtf8Ptr (detailedSignal);
        //            var closure_ = closure == null ? IntPtr.Zero : closure.Handle;
        //            var ret = g_signal_connect_closure (instance_, detailedSignal_, closure_, after);
        //            MarshalG.Free (detailedSignal_);
        //            return ret;
        //        }

        /// <summary>
        /// Connects a closure to a signal for a particular object.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="signalId">
        /// the id of the signal.
        /// </param>
        /// <param name="detail">
        /// the detail.
        /// </param>
        /// <param name="closure">
        /// the closure to connect.
        /// </param>
        /// <param name="after">
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        static extern nulong g_signal_connect_closure_by_id (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark detail,
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool after);

        /// <summary>
        /// Connects a closure to a signal for a particular object.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="signalId">
        /// the id of the signal.
        /// </param>
        /// <param name="detail">
        /// the detail.
        /// </param>
        /// <param name="closure">
        /// the closure to connect.
        /// </param>
        /// <param name="after">
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        //        public static nulong ConnectClosureById (Object instance, uint signalId, Quark detail, Closure closure, bool after)
        //        {
        //            if (instance == null) {
        //                throw new ArgumentNullException ("instance");
        //            }
        //            if (closure == null) {
        //                throw new ArgumentNullException ("closure");
        //            }
        //            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
        //            var closure_ = closure == null ? IntPtr.Zero : closure.Handle;
        //            var ret = g_signal_connect_closure_by_id (instance_, signalId, detail, closure_, after);
        //            return ret;
        //        }

        /// <summary>
        /// Connects a #GCallback function to a signal for a particular object. Similar
        /// to g_signal_connect(), but allows to provide a #GClosureNotify for the data
        /// which will be called when the signal handler is disconnected and no longer
        /// used. Specify @connect_flags if you need `..._after()` or
        /// `..._swapped()` variants of this function.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="cHandler">
        /// the #GCallback to connect.
        /// </param>
        /// <param name="data">
        /// data to pass to @c_handler calls.
        /// </param>
        /// <param name="destroyData">
        /// a #GClosureNotify for @data.
        /// </param>
        /// <param name="connectFlags">
        /// a combination of #GConnectFlags.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        internal static extern nulong g_signal_connect_data (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr detailedSignal,
            /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
            /* transfer-ownership:none closure:3 */
            IntPtr cHandler,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify destroyData,
            /* <type name="ConnectFlags" type="GConnectFlags" managed-name="ConnectFlags" /> */
            /* transfer-ownership:none */
            ConnectFlags connectFlags);

        /// <summary>
        /// Connects a #GCallback function to a signal for a particular object. Similar
        /// to g_signal_connect(), but allows to provide a #GClosureNotify for the data
        /// which will be called when the signal handler is disconnected and no longer
        /// used. Specify @connect_flags if you need `..._after()` or
        /// `..._swapped()` variants of this function.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="handler">
        /// the #GCallback to connect.
        /// </param>
        /// <param name="connectFlags">
        /// a combination of #GConnectFlags.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        public static SignalHandler Connect (Object instance, string detailedSignal, Action handler, ConnectFlags connectFlags = default(ConnectFlags))
        {
            if (instance == null) {
                throw new ArgumentNullException (nameof (instance));
            }
            if (detailedSignal == null) {
                throw new ArgumentNullException (nameof (detailedSignal));
            }
            if (handler == null) {
                throw new ArgumentNullException (nameof (handler));
            }

            var detailedSignal_ = GMarshal.StringToUtf8Ptr (detailedSignal);
            UnmanagedCallback nativeHandler = () => {
                try {
                    handler ();
                }
                catch (Exception ex) {
                    ex.DumpUnhandledException();
                }
            };
            var nativeHandlerPtr = Marshal.GetFunctionPointerForDelegate<UnmanagedCallback> (nativeHandler);
            var data = (IntPtr)GCHandle.Alloc (nativeHandler);
            var ret = g_signal_connect_data (instance.Handle, detailedSignal_, nativeHandlerPtr, data, destroyConnectDataDelegate, connectFlags);
            GMarshal.Free (detailedSignal_);

            if (ret == 0) {
                // TODO: More specific exception
                throw new Exception ("Failed to connect signal.");
            }

            return new SignalHandler (instance, ret);
        }

        static UnmanagedClosureNotify destroyConnectDataDelegate = DestroyConnectData;

        static void DestroyConnectData (IntPtr dataPtr, IntPtr closurePtr)
        {
            try {
                var gcHandle = (GCHandle)dataPtr;
                gcHandle.Free ();
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
            }
        }

        /// <summary>
        /// Emits a signal.
        /// </summary>
        /// <remarks>
        /// Note that g_signal_emitv() doesn't change @return_value if no handlers are
        /// connected, in contrast to g_signal_emit() and g_signal_emit_valist().
        /// </remarks>
        /// <param name="instanceAndParams">
        /// argument list for the signal emission.
        ///  The first element in the array is a #GValue for the instance the signal
        ///  is being emitted on. The rest are any arguments to be passed to the signal.
        /// </param>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="detail">
        /// the detail
        /// </param>
        /// <param name="returnValue">
        /// Location to
        /// store the return value of the signal emission. This must be provided if the
        /// specified signal returns a value, but may be ignored otherwise.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_emitv (
            /* <array zero-terminated="0" type="GValue*">
                <type name="Value" type="GValue" managed-name="Value" />
                </array> */
            /* transfer-ownership:none */
            IntPtr instanceAndParams,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark detail,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* direction:inout caller-allocates:0 transfer-ownership:full optional:1 */
            out Value returnValue);

        /// <summary>
        /// Emits a signal.
        /// </summary>
        /// <param name="instance">
        /// the object the signal is being emitted on
        /// </param>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="detail">
        /// the detail
        /// </param>
        /// <param name="parameters">
        /// argument list for the signal emission.
        ///  The arguments to be passed to the signal.
        /// </param>
        public static object Emit (Object instance, uint signalId, Quark detail = default(Quark), params object[] parameters)
        {
            if (instance == null) {
                throw new ArgumentNullException (nameof(instance));
            }
            var query = Signal.Query (signalId);
            if (!instance.GetGType ().IsA (query.IType)) {
                throw new ArgumentException ("Instance type does not match signal type");
            }
            if (query.ParamTypes.Length != parameters.Length) {
                var message = $"Incorrect number of parameters, expecting {query.ParamTypes.Length}, but got {parameters.Length}";
                throw new ArgumentException (message);
            }
            using (var instanceAndParams = new GLib.Array<Value> (false, true, parameters.Length + 1)) {
                instanceAndParams.Append (new Value (instance.GetGType (), instance));
                for (var i = 0; i < parameters.Length; i++) {
                    instanceAndParams.Append (new Value (query.ParamTypes[i], parameters[i]));
                }

                g_signal_emitv (instanceAndParams.Data, signalId, detail, out var returnValue);
                foreach (var p in instanceAndParams) {
                    p.Unset ();
                }
                if (query.ReturnType == GType.None) {
                    return null;
                }
                return returnValue.Get();
            }
        }

        /// <summary>
        /// Returns the invocation hint of the innermost signal emission of instance.
        /// </summary>
        /// <param name="instance">
        /// the instance to query
        /// </param>
        /// <returns>
        /// the invocation hint of the innermost signal  emission.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" /> */
        /* transfer-ownership:none */
        static extern SignalInvocationHint g_signal_get_invocation_hint (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        /// <summary>
        /// Returns the invocation hint of the innermost signal emission of instance.
        /// </summary>
        /// <param name="instance">
        /// the instance to query
        /// </param>
        /// <returns>
        /// the invocation hint of the innermost signal  emission.
        /// </returns>
        static SignalInvocationHint GetInvocationHint (Object instance)
        {
            if (instance == null) {
                throw new ArgumentNullException (nameof(instance));
            }
            var ret = g_signal_get_invocation_hint (instance.Handle);

            return ret;
        }

        /// <summary>
        /// Returns whether there are any handlers connected to @instance for the
        /// given signal id and detail.
        /// </summary>
        /// <remarks>
        /// If @detail is 0 then it will only match handlers that were connected
        /// without detail.  If @detail is non-zero then it will match handlers
        /// connected both without detail and with the given detail.  This is
        /// consistent with how a signal emitted with @detail would be delivered
        /// to those handlers.
        ///
        /// One example of when you might use this is when the arguments to the
        /// signal are difficult to compute. A class implementor may opt to not
        /// emit the signal if no one is attached anyway, thus saving the cost
        /// of building the arguments.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers are sought.
        /// </param>
        /// <param name="signalId">
        /// the signal id.
        /// </param>
        /// <param name="detail">
        /// the detail.
        /// </param>
        /// <param name="mayBeBlocked">
        /// whether blocked handlers should count as match.
        /// </param>
        /// <returns>
        /// %TRUE if a handler is connected to the signal, %FALSE
        ///          otherwise.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_signal_has_handler_pending (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark detail,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool mayBeBlocked);

        /// <summary>
        /// Returns whether there are any handlers connected to @instance for the
        /// given signal id and detail.
        /// </summary>
        /// <remarks>
        /// If @detail is 0 then it will only match handlers that were connected
        /// without detail.  If @detail is non-zero then it will match handlers
        /// connected both without detail and with the given detail.  This is
        /// consistent with how a signal emitted with @detail would be delivered
        /// to those handlers.
        ///
        /// One example of when you might use this is when the arguments to the
        /// signal are difficult to compute. A class implementor may opt to not
        /// emit the signal if no one is attached anyway, thus saving the cost
        /// of building the arguments.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers are sought.
        /// </param>
        /// <param name="signalId">
        /// the signal id.
        /// </param>
        /// <param name="detail">
        /// the detail.
        /// </param>
        /// <param name="mayBeBlocked">
        /// whether blocked handlers should count as match.
        /// </param>
        /// <returns>
        /// %TRUE if a handler is connected to the signal, %FALSE
        ///          otherwise.
        /// </returns>
        public static bool HasHandlerPending (Object instance, uint signalId, Quark detail, bool mayBeBlocked)
        {
            if (instance == null) {
                throw new ArgumentNullException (nameof (instance));
            }
            var ret = g_signal_has_handler_pending (instance.Handle, signalId, detail, mayBeBlocked);
            return ret;
        }

        /// <summary>
        /// Lists the signals by id that a certain instance or interface type
        /// created. Further information about the signals can be acquired through
        /// g_signal_query().
        /// </summary>
        /// <param name="itype">
        /// Instance or interface type.
        /// </param>
        /// <param name="nIds">
        /// Location to store the number of signal ids for @itype.
        /// </param>
        /// <returns>
        /// Newly allocated array of signal IDs.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="guint*">
            <type name="guint" type="guint" managed-name="Guint" />
            </array> */
        /* transfer-ownership:none */
        static extern IntPtr g_signal_list_ids (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType itype,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out uint nIds);

        /// <summary>
        /// Lists the signals by id that a certain instance or interface type
        /// created. Further information about the signals can be acquired through
        /// g_signal_query().
        /// </summary>
        /// <param name="itype">
        /// Instance or interface type.
        /// </param>
        /// <returns>
        /// Newly allocated array of signal IDs.
        /// </returns>
        public static uint[] ListIds (GType itype)
        {
            uint nIds_;
            var ret_ = g_signal_list_ids (itype, out nIds_);
            var ret = GMarshal.PtrToCArray<uint> (ret_, (int)nIds_, false);
            return ret;
        }

        /// <summary>
        /// Given the name of the signal and the type of object it connects to, gets
        /// the signal's identifying integer. Emitting the signal by number is
        /// somewhat faster than using the name each time.
        /// </summary>
        /// <remarks>
        /// Also tries the ancestors of the given type.
        ///
        /// See g_signal_new() for details on allowed signal names.
        /// </remarks>
        /// <param name="name">
        /// the signal's name.
        /// </param>
        /// <param name="itype">
        /// the type that the signal operates on.
        /// </param>
        /// <returns>
        /// the signal's identifying number, or 0 if no signal was found.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_signal_lookup (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType itype);

        /// <summary>
        /// Given the name of the signal and the type of object it connects to, gets
        /// the signal's identifying integer. Emitting the signal by number is
        /// somewhat faster than using the name each time.
        /// </summary>
        /// <remarks>
        /// Also tries the ancestors of the given type.
        ///
        /// See g_signal_new() for details on allowed signal names.
        /// </remarks>
        /// <param name="name">
        /// the signal's name.
        /// </param>
        /// <param name="itype">
        /// the type that the signal operates on.
        /// </param>
        /// <returns>
        /// the signal's identifying number, or 0 if no signal was found.
        /// </returns>
        public static uint Lookup (string name, GType itype)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            var name_ = GMarshal.StringToUtf8Ptr (name);
            var ret = g_signal_lookup (name_, itype);
            GMarshal.Free (name_);
            return ret;
        }

        public static uint Lookup<T> (string name)
        {
            return Lookup (name, typeof(T).GetGType ());
        }

        /// <summary>
        /// Given the signal's identifier, finds its name.
        /// </summary>
        /// <remarks>
        /// Two different signals may have the same name, if they have differing types.
        /// </remarks>
        /// <param name="signalId">
        /// the signal's identifying number.
        /// </param>
        /// <returns>
        /// the signal name, or %NULL if the signal number was invalid.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_signal_name (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId);

        /// <summary>
        /// Given the signal's identifier, finds its name.
        /// </summary>
        /// <remarks>
        /// Two different signals may have the same name, if they have differing types.
        /// </remarks>
        /// <param name="signalId">
        /// the signal's identifying number.
        /// </param>
        /// <returns>
        /// the signal name, or %NULL if the signal number was invalid.
        /// </returns>
        public static string Name (uint signalId)
        {
            var ret_ = g_signal_name (signalId);
            var ret = GMarshal.Utf8PtrToString (ret_, false);
            return ret;
        }

        /// <summary>
        /// Creates a new signal. (This is usually done in the class initializer.)
        /// </summary>
        /// <remarks>
        /// See g_signal_new() for details on allowed signal names.
        ///
        /// If c_marshaller is %NULL, g_cclosure_marshal_generic() will be used as
        /// the marshaller for this signal.
        /// </remarks>
        /// <param name="signalName">
        /// the name for the signal
        /// </param>
        /// <param name="itype">
        /// the type this signal pertains to. It will also pertain to
        ///     types which are derived from this type
        /// </param>
        /// <param name="signalFlags">
        /// a combination of #GSignalFlags specifying detail of when
        ///     the default handler is to be invoked. You should at least specify
        ///     %G_SIGNAL_RUN_FIRST or %G_SIGNAL_RUN_LAST
        /// </param>
        /// <param name="classClosure">
        /// The closure to invoke on signal emission;
        ///     may be %NULL
        /// </param>
        /// <param name="accumulator">
        /// the accumulator for this signal; may be %NULL
        /// </param>
        /// <param name="accuData">
        /// user data for the @accumulator
        /// </param>
        /// <param name="cMarshaller">
        /// the function to translate arrays of
        ///     parameter values to signal emissions into C language callback
        ///     invocations or %NULL
        /// </param>
        /// <param name="returnType">
        /// the type of return value, or #G_TYPE_NONE for a signal
        ///     without a return value
        /// </param>
        /// <param name="nParams">
        /// the length of @param_types
        /// </param>
        /// <param name="paramTypes">
        /// an array of types, one for
        ///     each parameter
        /// </param>
        /// <returns>
        /// the signal id
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        internal static extern uint g_signal_newv (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr signalName,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType itype,
            /* <type name="SignalFlags" type="GSignalFlags" managed-name="SignalFlags" /> */
            /* transfer-ownership:none */
            SignalFlags signalFlags,
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr classClosure,
            /* <type name="SignalAccumulator" type="GSignalAccumulator" managed-name="SignalAccumulator" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 closure:5 */
            UnmanagedSignalAccumulator accumulator,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr accuData,
            /* <type name="SignalCMarshaller" type="GSignalCMarshaller" managed-name="SignalCMarshaller" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            SignalCMarshaller cMarshaller,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType returnType,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nParams,
            /* <array length="8" zero-terminated="0" type="GType*">
                <type name="GType" type="GType" managed-name="GType" />
                </array> */
            /* transfer-ownership:none */
            IntPtr paramTypes);

        /// <summary>
        /// Overrides the class closure (i.e. the default handler) for the given signal
        /// for emissions on instances of @instance_type. @instance_type must be derived
        /// from the type to which the signal belongs.
        /// </summary>
        /// <remarks>
        /// See g_signal_chain_from_overridden() and
        /// g_signal_chain_from_overridden_handler() for how to chain up to the
        /// parent class closure from inside the overridden one.
        /// </remarks>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="instanceType">
        /// the instance type on which to override the class closure
        ///  for the signal.
        /// </param>
        /// <param name="classClosure">
        /// the closure.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_override_class_closure (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr classClosure);

        /// <summary>
        /// Overrides the class closure (i.e. the default handler) for the given signal
        /// for emissions on instances of @instance_type. @instance_type must be derived
        /// from the type to which the signal belongs.
        /// </summary>
        /// <remarks>
        /// See g_signal_chain_from_overridden() and
        /// g_signal_chain_from_overridden_handler() for how to chain up to the
        /// parent class closure from inside the overridden one.
        /// </remarks>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="instanceType">
        /// the instance type on which to override the class closure
        ///  for the signal.
        /// </param>
        /// <param name="classClosure">
        /// the closure.
        /// </param>
        //        public static void OverrideClassClosure (uint signalId, GType instanceType, Closure classClosure)
        //        {
        //            if (classClosure == null) {
        //                throw new ArgumentNullException ("classClosure");
        //            }
        //            var classClosure_ = classClosure == null ? IntPtr.Zero : classClosure.Handle;
        //            g_signal_override_class_closure (signalId, instanceType, classClosure_);
        //        }

        /// <summary>
        /// Overrides the class closure (i.e. the default handler) for the
        /// given signal for emissions on instances of @instance_type with
        /// callback @class_handler. @instance_type must be derived from the
        /// type to which the signal belongs.
        /// </summary>
        /// <remarks>
        /// See g_signal_chain_from_overridden() and
        /// g_signal_chain_from_overridden_handler() for how to chain up to the
        /// parent class closure from inside the overridden one.
        /// </remarks>
        /// <param name="signalName">
        /// the name for the signal
        /// </param>
        /// <param name="instanceType">
        /// the instance type on which to override the class handler
        ///  for the signal.
        /// </param>
        /// <param name="classHandler">
        /// the handler.
        /// </param>
        [Since ("2.18")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_override_class_handler (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr signalName,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
            /* transfer-ownership:none */
            UnmanagedCallback classHandler);

        /// <summary>
        /// Overrides the class closure (i.e. the default handler) for the
        /// given signal for emissions on instances of @instance_type with
        /// callback @class_handler. @instance_type must be derived from the
        /// type to which the signal belongs.
        /// </summary>
        /// <remarks>
        /// See g_signal_chain_from_overridden() and
        /// g_signal_chain_from_overridden_handler() for how to chain up to the
        /// parent class closure from inside the overridden one.
        /// </remarks>
        /// <param name="signalName">
        /// the name for the signal
        /// </param>
        /// <param name="instanceType">
        /// the instance type on which to override the class handler
        ///  for the signal.
        /// </param>
        /// <param name="classHandler">
        /// the handler.
        /// </param>
        //        [Since ("2.18")]
        //        public static void OverrideClassHandler (string signalName, GType instanceType, Callback classHandler)
        //        {
        //            if (signalName == null) {
        //                throw new ArgumentNullException ("signalName");
        //            }
        //            if (classHandler == null) {
        //                throw new ArgumentNullException ("classHandler");
        //            }
        //            var signalName_ = MarshalG.StringToUtf8Ptr (signalName);
        //            var classHandler_ = UnmanagedCallbackFactory.Create (classHandler, false);
        //            g_signal_override_class_handler (signalName_, instanceType, classHandler_);
        //            MarshalG.Free (signalName_);
        //        }

        /// <summary>
        /// Internal function to parse a signal name into its @signal_id
        /// and @detail quark.
        /// </summary>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="itype">
        /// The interface/instance type that introduced "signal-name".
        /// </param>
        /// <param name="signalIdP">
        /// Location to store the signal id.
        /// </param>
        /// <param name="detailP">
        /// Location to store the detail quark.
        /// </param>
        /// <param name="forceDetailQuark">
        /// %TRUE forces creation of a #GQuark for the detail.
        /// </param>
        /// <returns>
        /// Whether the signal name could successfully be parsed and @signal_id_p and @detail_p contain valid return values.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_signal_parse_name (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr detailedSignal,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType itype,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out uint signalIdP,
            /* <type name="GLib.Quark" type="GQuark*" managed-name="GLib.Quark" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out Quark detailP,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool forceDetailQuark);

        /// <summary>
        /// Internal function to parse a signal name into its @signal_id
        /// and @detail quark.
        /// </summary>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="itype">
        /// The interface/instance type that introduced "signal-name".
        /// </param>
        /// <param name="signalIdP">
        /// Location to store the signal id.
        /// </param>
        /// <param name="detailP">
        /// Location to store the detail quark.
        /// </param>
        /// <param name="forceDetailQuark">
        /// %TRUE forces creation of a #GQuark for the detail.
        /// </param>
        /// <returns>
        /// Whether the signal name could successfully be parsed and @signal_id_p and @detail_p contain valid return values.
        /// </returns>
        public static bool ParseName (string detailedSignal, GType itype, out uint signalIdP, out Quark detailP, bool forceDetailQuark)
        {
            if (detailedSignal == null) {
                throw new ArgumentNullException (nameof (detailedSignal));
            }
            var detailedSignal_ = GMarshal.StringToUtf8Ptr (detailedSignal);
            var ret = g_signal_parse_name (detailedSignal_, itype, out signalIdP, out detailP, forceDetailQuark);
            GMarshal.Free (detailedSignal_);
            return ret;
        }

        /// <summary>
        /// Queries the signal system for in-depth information about a
        /// specific signal. This function will fill in a user-provided
        /// structure to hold signal-specific information. If an invalid
        /// signal id is passed in, the @signal_id member of the #GSignalQuery
        /// is 0. All members filled into the #GSignalQuery structure should
        /// be considered constant and have to be left untouched.
        /// </summary>
        /// <param name="signalId">
        /// The signal id of the signal to query information for.
        /// </param>
        /// <param name="query">
        /// A user provided structure that is
        ///  filled in with constant values upon success.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_query (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="SignalQuery" type="GSignalQuery*" managed-name="SignalQuery" /> */
            /* direction:out caller-allocates:1 transfer-ownership:none */
            out SignalQuery query);

        /// <summary>
        /// Queries the signal system for in-depth information about a
        /// specific signal.
        /// </summary>
        /// <param name="signalId">
        /// The signal id of the signal to query information for.
        /// </param>
        /// <returns>
        /// A structure with signal-specific information.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw if and invalid signal id is passed in.
        /// </exception>
        public static SignalQuery Query (uint signalId)
        {
            g_signal_query (signalId, out var query);
            if (query.SignalId == 0) {
                throw new ArgumentOutOfRangeException (nameof (signalId));
            }
            return query;
        }

        /// <summary>
        /// Deletes an emission hook.
        /// </summary>
        /// <param name="signalId">
        /// the id of the signal
        /// </param>
        /// <param name="hookId">
        /// the id of the emission hook, as returned by
        ///  g_signal_add_emission_hook()
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_remove_emission_hook (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
            /* transfer-ownership:none */
            nulong hookId);

        /// <summary>
        /// Deletes an emission hook.
        /// </summary>
        /// <param name="signalId">
        /// the id of the signal
        /// </param>
        /// <param name="hookId">
        /// the id of the emission hook, as returned by
        ///  g_signal_add_emission_hook()
        /// </param>
        public static void RemoveEmissionHook (uint signalId, nulong hookId)
        {
            g_signal_remove_emission_hook (signalId, hookId);
        }

        /// <summary>
        /// Stops a signal's current emission.
        /// </summary>
        /// <remarks>
        /// This will prevent the default method from running, if the signal was
        /// %G_SIGNAL_RUN_LAST and you connected normally (i.e. without the "after"
        /// flag).
        ///
        /// Prints a warning if used on a signal which isn't being emitted.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers you wish to stop.
        /// </param>
        /// <param name="signalId">
        /// the signal identifier, as returned by g_signal_lookup().
        /// </param>
        /// <param name="detail">
        /// the detail which the signal was emitted with.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_stop_emission (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint signalId,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark detail);

        /// <summary>
        /// Stops a signal's current emission.
        /// </summary>
        /// <remarks>
        /// This will prevent the default method from running, if the signal was
        /// %G_SIGNAL_RUN_LAST and you connected normally (i.e. without the "after"
        /// flag).
        ///
        /// Prints a warning if used on a signal which isn't being emitted.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers you wish to stop.
        /// </param>
        /// <param name="signalId">
        /// the signal identifier, as returned by g_signal_lookup().
        /// </param>
        /// <param name="detail">
        /// the detail which the signal was emitted with.
        /// </param>
        public static void StopEmission (Object instance, uint signalId, Quark detail)
        {
            if (instance == null) {
                throw new ArgumentNullException ("instance");
            }
            g_signal_stop_emission (instance.Handle, signalId, detail);
        }

        /// <summary>
        /// Stops a signal's current emission.
        /// </summary>
        /// <remarks>
        /// This is just like g_signal_stop_emission() except it will look up the
        /// signal id for you.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers you wish to stop.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_signal_stop_emission_by_name (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr detailedSignal);

        /// <summary>
        /// Stops a signal's current emission.
        /// </summary>
        /// <remarks>
        /// This is just like g_signal_stop_emission() except it will look up the
        /// signal id for you.
        /// </remarks>
        /// <param name="instance">
        /// the object whose signal handlers you wish to stop.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        public static void StopEmissionByName (Object instance, string detailedSignal)
        {
            if (instance == null) {
                throw new ArgumentNullException (nameof (instance));
            }
            if (detailedSignal == null) {
                throw new ArgumentNullException (nameof (detailedSignal));
            }
            var detailedSignal_ = GMarshal.StringToUtf8Ptr (detailedSignal);
            g_signal_stop_emission_by_name (instance.Handle, detailedSignal_);
            GMarshal.Free (detailedSignal_);
        }

        /// <summary>
        /// Creates a new closure which invokes the function found at the offset
        /// @struct_offset in the class structure of the interface or classed type
        /// identified by @itype.
        /// </summary>
        /// <param name="itype">
        /// the #GType identifier of an interface or classed type
        /// </param>
        /// <param name="structOffset">
        /// the offset of the member function of @itype's class
        ///  structure which is to be invoked by the new closure
        /// </param>
        /// <returns>
        /// a new #GCClosure
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_signal_type_cclosure_new (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType itype,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint structOffset);

        /// <summary>
        /// Creates a new closure which invokes the function found at the offset
        /// @struct_offset in the class structure of the interface or classed type
        /// identified by @itype.
        /// </summary>
        /// <param name="itype">
        /// the #GType identifier of an interface or classed type
        /// </param>
        /// <param name="structOffset">
        /// the offset of the member function of @itype's class
        ///  structure which is to be invoked by the new closure
        /// </param>
        /// <returns>
        /// a new #GCClosure
        /// </returns>
        //        public static Closure TypeCclosureNew (GType itype, uint structOffset)
        //        {
        //            var ret_ = g_signal_type_cclosure_new (itype, structOffset);
        //            var ret = Opaque.GetInstance<Closure> (ret_, Transfer.All);
        //            return ret;
        //        }
    }
}
