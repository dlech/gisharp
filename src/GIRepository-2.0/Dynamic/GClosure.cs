using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository.Dynamic
{
    public sealed unsafe class GClosure : IDisposable
    {
        struct Closure
        {
#pragma warning disable CS0649
            // the base GClosure struct
            public uint BitFields;
            public IntPtr Marshal;
            public IntPtr Data;
            public IntPtr Notifiers;
#pragma warning restore CS0649
        }

        Closure* handle;
        public IntPtr Handle =>
            handle == null ? throw new ObjectDisposedException(null) : (IntPtr)handle;

        uint RefCount => handle->BitFields & 0x7FFF;

        public bool InMarshal {
            get {
                var ret_ = handle->BitFields >> 30;
                var ret = Convert.ToBoolean(ret_ & 0x1);
                return ret;
            }
        }

        public bool IsInvalid {
            get {
                var ret_ = handle->BitFields >> 31;
                var ret = Convert.ToBoolean(ret_ & 0x1);
                return ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Closure* g_closure_ref(IntPtr closure);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_closure_sink(Closure* closure);

        GClosure(IntPtr handle)
        {
            this.handle = g_closure_ref(handle);
            g_closure_sink(this.handle);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_closure_unref(Closure* closure);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (handle != null) {
                g_closure_unref(handle);
                handle = null;
            }
        }

        ~GClosure()
        {
            Dispose(false);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_closure_new_simple(
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint sizeofClosure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data);

        static IntPtr NewSimple(int sizeofClosure, IntPtr data)
        {
            var ret = g_closure_new_simple((uint)sizeofClosure, data);
            return ret;
        }

        static GClosureNotify finalizeDelegate = Finalize;

        static void Finalize(IntPtr data, Closure* closure)
        {
            GCHandle.FromIntPtr(data).Free();
        }

        public GClosure(System.Func<object?[], object?> callback)
            : this(NewSimple(Marshal.SizeOf<Closure>(), IntPtr.Zero))
        {
            var gcHandle = (IntPtr)GCHandle.Alloc(callback);
            g_closure_set_meta_marshal(handle, gcHandle, marshalFuncDelegate);
            g_closure_add_finalize_notifier(handle, gcHandle, finalizeDelegate);
        }

        static GClosureMarshal marshalFuncDelegate = MarshalFunc;

        static void MarshalFunc(Closure* closure, GValue* returnValue, uint nParamValues,
            GValue* paramValues, IntPtr invocationHint, IntPtr marshalData)
        {
            try {
                var gcHandle = (GCHandle)marshalData;
                var callback = (System.Func<object?[], object?>)gcHandle.Target!;

                var parameters = new object?[nParamValues];
                for (int i = 0; i < nParamValues; i++) {
                    parameters[i] = paramValues[i].Get();
                }
                var ret = callback.Invoke(parameters);
                returnValue[0].Set(ret);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        public GClosure(System.Func<object?> callback)
            : this(NewSimple(Marshal.SizeOf<Closure>(), IntPtr.Zero))
        {
            var gcHandle = (IntPtr)GCHandle.Alloc(callback);
            g_closure_set_meta_marshal(handle, gcHandle, marshalFunc2Delegate);
            g_closure_add_finalize_notifier(handle, gcHandle, finalizeDelegate);
        }

        static GClosureMarshal marshalFunc2Delegate = MarshalFunc2;

        static void MarshalFunc2(Closure* closure, GValue* returnValue, uint nParamValues,
            GValue* paramValues, IntPtr invocationHint, IntPtr marshalData)
        {
            try {
                var gcHandle = (GCHandle)marshalData;
                var callback = (System.Func<object?>)gcHandle.Target!;

                var ret = callback.Invoke();
                returnValue[0].Set(ret);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        public GClosure(Action<object?[]> callback)
            : this(NewSimple(Marshal.SizeOf<Closure>(), IntPtr.Zero))
        {
            var gcHandle = (IntPtr)GCHandle.Alloc(callback);
            g_closure_set_meta_marshal(handle, gcHandle, marshalActionDelegate);
            g_closure_add_finalize_notifier(handle, gcHandle, finalizeDelegate);
        }

        static GClosureMarshal marshalActionDelegate = MarshalAction;

        static void MarshalAction(Closure* closure, GValue* returnValue, uint nParamValues,
            GValue* paramValues, IntPtr invocationHint, IntPtr marshalData)
        {
            try {
                var gcHandle = (GCHandle)marshalData;
                var callback = (Action<object?[]>)gcHandle.Target!;

                var parameters = new object?[nParamValues];
                for (int i = 0; i < nParamValues; i++) {
                    parameters[i] = paramValues[i].Get();
                }
                callback.Invoke(parameters);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        public GClosure(Action callback)
            : this(NewSimple(Marshal.SizeOf<Closure>(), IntPtr.Zero))
        {
            var gcHandle = (IntPtr)GCHandle.Alloc(callback);
            g_closure_set_meta_marshal(handle, gcHandle, marshalAction2Delegate);
            g_closure_add_finalize_notifier(handle, gcHandle, finalizeDelegate);
        }

        static GClosureMarshal marshalAction2Delegate = MarshalAction2;

        static void MarshalAction2(Closure* closure, GValue* returnValue, uint nParamValues,
            GValue* paramValues, IntPtr invocationHint, IntPtr marshalData)
        {
            try {
                var gcHandle = (GCHandle)marshalData;
                var callback = (Action)gcHandle.Target!;

                callback.Invoke();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Sets the meta marshaller of @closure.  A meta marshaller wraps
        /// @closure-&gt;marshal and modifies the way it is called in some
        /// fashion. The most common use of this facility is for C callbacks.
        /// The same marshallers (generated by [glib-genmarshal][glib-genmarshal]),
        /// are used everywhere, but the way that we get the callback function
        /// differs. In most cases we want to use @closure-&gt;callback, but in
        /// other cases we want to use some different technique to retrieve the
        /// callback function.
        /// </summary>
        /// <remarks>
        /// For example, class closures for signals (see
        /// g_signal_type_cclosure_new()) retrieve the callback function from a
        /// fixed offset in the class structure.  The meta marshaller retrieves
        /// the right callback and passes it to the marshaller as the
        /// @marshal_data argument.
        /// </remarks>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="marshalData">
        /// context-dependent data to pass to @meta_marshal
        /// </param>
        /// <param name="metaMarshal">
        /// a #GClosureMarshal function
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_set_meta_marshal(
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            Closure* closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr marshalData,
            /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
            /* transfer-ownership:none */
            GClosureMarshal metaMarshal);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void GClosureMarshal(
            Closure* closure,
            GValue* return_value,
            uint n_param_values,
            GValue* param_values,
            IntPtr invocation_hint,
            IntPtr marshal_data);

        /// <summary>
        /// Registers a finalization notifier which will be called when the
        /// reference count of @closure goes down to 0. Multiple finalization
        /// notifiers on a single closure are invoked in unspecified order. If
        /// a single call to g_closure_unref() results in the closure being
        /// both invalidated and finalized, then the invalidate notifiers will
        /// be run before the finalize notifiers.
        /// </summary>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="notifyData">
        /// data to pass to @notify_func
        /// </param>
        /// <param name="notifyFunc">
        /// the callback function to register
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_finalize_notifier(
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            Closure* closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr notifyData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            GClosureNotify notifyFunc);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void GClosureNotify(IntPtr data, Closure* closure);
    }
}
