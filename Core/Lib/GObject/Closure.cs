using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A #GClosure represents a callback supplied by the programmer. It
    /// will generally comprise a function of some kind and a marshaller
    /// used to call it. It is the responsibility of the marshaller to
    /// convert the arguments for the invocation from #GValues into
    /// a suitable form, perform the callback on the converted arguments,
    /// and transform the return value back into a #GValue.
    /// </summary>
    /// <remarks>
    /// In the case of C programs, a closure usually just holds a pointer
    /// to a function and maybe a data argument, and the marshaller
    /// converts between #GValue and native C types. The GObject
    /// library provides the #GCClosure type for this purpose. Bindings for
    /// other languages need marshallers which convert between #GValue&lt;!--
    /// --&gt;s and suitable representations in the runtime of the language in
    /// order to use functions written in that languages as callbacks.
    ///
    /// Within GObject, closures play an important role in the
    /// implementation of signals. When a signal is registered, the
    /// @c_marshaller argument to g_signal_new() specifies the default C
    /// marshaller for any closure which is connected to this
    /// signal. GObject provides a number of C marshallers for this
    /// purpose, see the g_cclosure_marshal_*() functions. Additional C
    /// marshallers can be generated with the [glib-genmarshal][glib-genmarshal]
    /// utility.  Closures can be explicitly connected to signals with
    /// g_signal_connect_closure(), but it usually more convenient to let
    /// GObject create a closure automatically by using one of the
    /// g_signal_connect_*() functions which take a callback function/user
    /// data pair.
    ///
    /// Using closures has a number of important advantages over a simple
    /// callback function/data pointer combination:
    ///
    /// - Closures allow the callee to get the types of the callback parameters,
    ///   which means that language bindings don't have to write individual glue
    ///   for each callback type.
    ///
    /// - The reference counting of #GClosure makes it easy to handle reentrancy
    ///   right; if a callback is removed while it is being invoked, the closure
    ///   and its parameters won't be freed until the invocation finishes.
    ///
    /// - g_closure_invalidate() and invalidation notifiers allow callbacks to be
    ///   automatically removed when the objects they point to go away.
    /// </remarks>
    [GType ("GClosure", IsProxyForUnmanagedType = true)]
    public sealed class Closure : Boxed
    {
        static readonly IntPtr bitFieldsOffset = Marshal.OffsetOf<Struct> (nameof (Struct.BitFields));
        static readonly IntPtr dataOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Data));

        struct Struct
        {
    #pragma warning disable CS0649
            public uint BitFields;
            public UnmanagedMarshal Marshal;
            public IntPtr Data;
            public IntPtr Notifiers;
    #pragma warning restore CS0649

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedMarshal (
                IntPtr closure,
                out Value returnValue,
                uint nParamValues,
                [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)] Value[] paramValues,
                IntPtr invocationHint,
                IntPtr marshalData);
        }

        uint BitFields => (uint)Marshal.ReadInt32(Handle, (int)bitFieldsOffset);

        uint RefCount => BitFields & 0x7FFF;

        IntPtr Data => Marshal.ReadIntPtr(Handle, (int)dataOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Closure(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
            g_closure_sink (this.handle);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_closure_ref (IntPtr closure);

        public override IntPtr Take() => g_closure_ref(Handle);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_closure_sink (IntPtr closure);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_closure_unref (IntPtr closure);

        public bool InMarshal {
            get {
                var ret_ = BitFields >> 30;
                var ret = Convert.ToBoolean (ret_ & 0x1);
                return ret;
            }
        }

        public bool IsInvalid {
            get {
                var ret_ = BitFields >> 31;
                var ret = Convert.ToBoolean (ret_ & 0x1);
                return ret;
            }
        }

        /// <summary>
        /// A variant of g_closure_new_simple() which stores @object in the
        /// @data field of the closure and calls g_object_watch_closure() on
        /// @object and the created closure. This function is mainly useful
        /// when implementing new types of closures.
        /// </summary>
        /// <param name="sizeofClosure">
        /// the size of the structure to allocate, must be at least
        ///  `sizeof (GClosure)`
        /// </param>
        /// <param name="object">
        /// a #GObject pointer to store in the @data field of the newly
        ///  allocated #GClosure
        /// </param>
        /// <returns>
        /// a newly allocated #GClosure
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_closure_new_object (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint sizeofClosure,
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object);

        static readonly int sizeOfStruct = Marshal.SizeOf<Struct>();

        static IntPtr NewObject(int sizeofClosure, Object @object)
        {
            if (sizeofClosure < sizeOfStruct) {
                const string message = "size must be at least as big as Closure.Struct";
                throw new ArgumentOutOfRangeException(message, nameof(sizeofClosure));
            }
            var object_ = @object?.Handle ?? throw new ArgumentNullException(nameof(@object));
            var ret = g_closure_new_object((uint)sizeofClosure, object_);
            return ret;
        }

        /// <summary>
        /// A variant of g_closure_new_simple() which stores @object in the
        /// @data field of the closure and calls g_object_watch_closure() on
        /// @object and the created closure. This function is mainly useful
        /// when implementing new types of closures.
        /// </summary>
        /// <param name="object">
        /// a #GObject pointer to store in the @data field of the newly
        ///  allocated #GClosure
        /// </param>
        /// <returns>
        /// a newly allocated #GClosure
        /// </returns>
        public Closure(Func<object[], object> callback, GISharp.Lib.GObject.Object @object)
            : this(NewObject(Marshal.SizeOf<ManagedClosure> (), @object), Transfer.None)
        {
            SetCallback(callback, ManagedClosureFuncCallback);
        }

        /// <summary>
        /// Allocates a struct of the given size and initializes the initial
        /// part as a #GClosure. This function is mainly useful when
        /// implementing new types of closures.
        /// </summary>
        /// <remarks>
        /// |[&lt;!-- language="C" --&gt;
        /// typedef struct _MyClosure MyClosure;
        /// struct _MyClosure
        /// {
        ///   GClosure closure;
        ///   // extra data goes here
        /// };
        ///
        /// static void
        /// my_closure_finalize (gpointer  notify_data,
        ///                      GClosure *closure)
        /// {
        ///   MyClosure *my_closure = (MyClosure *)closure;
        ///
        ///   // free extra data here
        /// }
        ///
        /// MyClosure *my_closure_new (gpointer data)
        /// {
        ///   GClosure *closure;
        ///   MyClosure *my_closure;
        ///
        ///   closure = g_closure_new_simple (sizeof (MyClosure), data);
        ///   my_closure = (MyClosure *) closure;
        ///
        ///   // initialize extra data here
        ///
        ///   g_closure_add_finalize_notifier (closure, notify_data,
        ///                                    my_closure_finalize);
        ///   return my_closure;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="sizeofClosure">
        /// the size of the structure to allocate, must be at least
        ///                  `sizeof (GClosure)`
        /// </param>
        /// <param name="data">
        /// data to store in the @data field of the newly allocated #GClosure
        /// </param>
        /// <returns>
        /// a newly allocated #GClosure
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_closure_new_simple (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint sizeofClosure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data);

        static IntPtr NewSimple (uint sizeofClosure, IntPtr data)
        {
            var ret = g_closure_new_simple (sizeofClosure, data);
            return ret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Closure"/> class.
        /// </summary>
        public Closure (Func<object[], object> callback)
            : this(NewSimple ((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureFuncCallback);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Closure"/> class.
        /// </summary>
        public Closure (Action<object[]> callback)
            : this (NewSimple((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureActionCallback);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Closure"/> class.
        /// </summary>
        public Closure (Action callback)
            : this (NewSimple((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureVoidActionCallback);
        }

        void SetCallback (Delegate callback, ClosureMarshal callbackWrapper)
        {
            var gcHandle = GCHandle.Alloc(callback, GCHandleType.Weak);
            Marshal.WriteIntPtr(handle, (int)callbackGCHandleOffset, (IntPtr)gcHandle);
            var (callback_, notify_, userData_) = ClosureMarshalFactory.Create(callbackWrapper, CallbackScope.Notified);
            g_closure_set_meta_marshal(handle, userData_, callback_);
            g_closure_add_invalidate_notifier(handle, userData_, notify_);
        }

        static void ManagedClosureFuncCallback(Closure closure, ref Value returnValue, Value[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Func<object[], object>)gcHandle.Target;
            var paramObjs = paramValues.Select(p => p.Get()).ToArray();
            var ret = callback(paramObjs);
            if (!returnValue.Equals(default(Value))) {
                returnValue.Set(ret);
            }
        }

        static void ManagedClosureActionCallback(Closure closure, ref Value returnValue, Value[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Action<object[]>)gcHandle.Target;
            var paramObjs = paramValues.Select(p => p.Get()).ToArray();
            callback(paramObjs);
        }

        static void ManagedClosureVoidActionCallback(Closure closure, ref Value returnValue, Value[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Action)gcHandle.Target;
            callback();
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_closure_get_type ();

        static readonly GType _GType = g_closure_get_type();

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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_finalize_notifier (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr notifyData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify notifyFunc);

        /// <summary>
        /// Registers an invalidation notifier which will be called when the
        /// @closure is invalidated with g_closure_invalidate(). Invalidation
        /// notifiers are invoked before finalization notifiers, in an
        /// unspecified order.
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_invalidate_notifier (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr notifyData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify notifyFunc);

        /// <summary>
        /// Adds a pair of notifiers which get invoked before and after the
        /// closure callback, respectively. This is typically used to protect
        /// the extra arguments for the duration of the callback. See
        /// g_object_watch_closure() for an example of marshal guards.
        /// </summary>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="preMarshalData">
        /// data to pass to @pre_marshal_notify
        /// </param>
        /// <param name="preMarshalNotify">
        /// a function to call before the closure callback
        /// </param>
        /// <param name="postMarshalData">
        /// data to pass to @post_marshal_notify
        /// </param>
        /// <param name="postMarshalNotify">
        /// a function to call after the closure callback
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_marshal_guards (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr preMarshalData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none closure:2 */
            UnmanagedClosureNotify preMarshalNotify,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr postMarshalData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify postMarshalNotify);

        /// <summary>
        /// Sets a flag on the closure to indicate that its calling
        /// environment has become invalid, and thus causes any future
        /// invocations of g_closure_invoke() on this @closure to be
        /// ignored. Also, invalidation notifiers installed on the closure will
        /// be called at this point. Note that unless you are holding a
        /// reference to the closure yourself, the invalidation notifiers may
        /// unref the closure and cause it to be destroyed, so if you need to
        /// access the closure after calling g_closure_invalidate(), make sure
        /// that you've previously called g_closure_ref().
        /// </summary>
        /// <remarks>
        /// Note that g_closure_invalidate() will also be called when the
        /// reference count of a closure drops to zero (unless it has already
        /// been invalidated before).
        /// </remarks>
        /// <param name="closure">
        /// GClosure to invalidate
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_invalidate (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure);

        /// <summary>
        /// Sets a flag on the closure to indicate that its calling
        /// environment has become invalid, and thus causes any future
        /// invocations of g_closure_invoke() on this @closure to be
        /// ignored. Also, invalidation notifiers installed on the closure will
        /// be called at this point. Note that unless you are holding a
        /// reference to the closure yourself, the invalidation notifiers may
        /// unref the closure and cause it to be destroyed, so if you need to
        /// access the closure after calling g_closure_invalidate(), make sure
        /// that you've previously called g_closure_ref().
        /// </summary>
        /// <remarks>
        /// Note that g_closure_invalidate() will also be called when the
        /// reference count of a closure drops to zero (unless it has already
        /// been invalidated before).
        /// </remarks>
        public void Invalidate ()
        {
            g_closure_invalidate(Handle);
        }

        /// <summary>
        /// Invokes the closure, i.e. executes the callback represented by the @closure.
        /// </summary>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="returnValue">
        /// a #GValue to store the return
        ///                value. May be %NULL if the callback of @closure
        ///                doesn't return a value.
        /// </param>
        /// <param name="nParamValues">
        /// the length of the @param_values array
        /// </param>
        /// <param name="paramValues">
        /// an array of
        ///                #GValues holding the arguments on which to
        ///                invoke the callback of @closure
        /// </param>
        /// <param name="invocationHint">
        /// a context-dependent invocation hint
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_invoke (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            ref Value returnValue,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nParamValues,
            /* <array length="1" zero-terminated="0" type="GValue*">
                <type name="Value" type="GValue" managed-name="Value" />
            </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)]
            Value[] paramValues,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr invocationHint);

        /// <summary>
        /// Invokes the closure, i.e. executes the callback represented by this closure.
        /// </summary>
        /// <param name="paramValues">
        /// an array of #GValues holding the arguments on which to
        /// invoke the callback of this closure
        /// </param>
        /// <returns>The return value of the closure invocation</returns>
        public T Invoke<T>(params object[] paramValues)
        {
            var this_ = Handle;
            if (paramValues == null) {
                throw new ArgumentNullException (nameof (paramValues));
            }

            var returnValue = new Value(GType.TypeOf<T>());
            var values = paramValues.Select(p => new Value(p?.GetType(), p)).ToArray();
            g_closure_invoke(this_, ref returnValue, (uint)values.Length, values, IntPtr.Zero);
            foreach (var v in values) {
                v.Unset();
            }

            var ret = returnValue.Get();
            returnValue.Unset();

            return (T)ret;
        }

        /// <summary>
        /// Removes a finalization notifier.
        /// </summary>
        /// <remarks>
        /// Notice that notifiers are automatically removed after they are run.
        /// </remarks>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="notifyData">
        /// data which was passed to g_closure_add_finalize_notifier()
        ///  when registering @notify_func
        /// </param>
        /// <param name="notifyFunc">
        /// the callback function to remove
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_remove_finalize_notifier (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr notifyData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify notifyFunc);

        /// <summary>
        /// Removes an invalidation notifier.
        /// </summary>
        /// <remarks>
        /// Notice that notifiers are automatically removed after they are run.
        /// </remarks>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="notifyData">
        /// data which was passed to g_closure_add_invalidate_notifier()
        ///               when registering @notify_func
        /// </param>
        /// <param name="notifyFunc">
        /// the callback function to remove
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_remove_invalidate_notifier (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr notifyData,
            /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
            /* transfer-ownership:none */
            UnmanagedClosureNotify notifyFunc);

        /// <summary>
        /// Sets the marshaller of @closure. The `marshal_data`
        /// of @marshal provides a way for a meta marshaller to provide additional
        /// information to the marshaller. (See g_closure_set_meta_marshal().) For
        /// GObject's C predefined marshallers (the g_cclosure_marshal_*()
        /// functions), what it provides is a callback function to use instead of
        /// @closure-&gt;callback.
        /// </summary>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="marshal">
        /// a #GClosureMarshal function
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_set_marshal (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
            /* transfer-ownership:none */
            UnmanagedClosureMarshal marshal);

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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_set_meta_marshal (
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr marshalData,
            /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
            /* transfer-ownership:none */
            UnmanagedClosureMarshal metaMarshal);

        /// <summary>
        /// Creates a new closure object for a signal implemented as an event handler
        /// </summary>
        public static Closure CreateFor<T>(Object instance, EventHandler<T> handler)
            where T : GSignalEventArgs
        {
            var closure_ = NewObject(Marshal.SizeOf<ManagedClosure>(), instance);

            var (func_, notify_, data_) = SignalClosureMarshalFactory.Create(handler);
            g_closure_set_meta_marshal(closure_, data_, func_);
            g_closure_add_invalidate_notifier(closure_, data_, notify_);

            return new Closure(closure_, Transfer.None);
        }

        static class SignalClosureMarshalFactory
        {
            class UnmanagedSignalClosureMarshalData {
                public EventHandler<GSignalEventArgs> SignalHandler;
                public Type EventArgsType;
                public UnmanagedClosureMarshal UnmanagedClosureMarshal;
                public UnmanagedClosureNotify UnmanagedClosureNotify;
            }

            public static (UnmanagedClosureMarshal, UnmanagedClosureNotify, IntPtr) Create<T>(EventHandler<T> handler)
                where T : GSignalEventArgs
            {
                if (handler == null) {
                    throw new ArgumentNullException(nameof(handler));
                }

                // hack to make EventHandler<T> covariant
                EventHandler<GSignalEventArgs> handlerAction = (s, a) => handler(s, (T)a);
    
                var userData = new UnmanagedSignalClosureMarshalData {
                    SignalHandler = handlerAction,
                    EventArgsType = typeof(T),
                    UnmanagedClosureMarshal = UnmanagedClosureMarshal,
                    UnmanagedClosureNotify = UnmanagedClosureNotify,
                };
                var userData_ = GCHandle.Alloc(userData);

                return (userData.UnmanagedClosureMarshal, userData.UnmanagedClosureNotify, (IntPtr)userData_);
            }

            static void UnmanagedClosureMarshal(IntPtr closure_, IntPtr returnValue_, uint nParamValues_, Value[] paramValues_, IntPtr invocationHint_, IntPtr marshalData_)
            {
                try {
                    var data_ = Marshal.ReadIntPtr(closure_, (int)dataOffset);
                    var obj = Object.GetInstance(data_, Transfer.None);

                    var gcHandle = (GCHandle)marshalData_;
                    var marshalData = (UnmanagedSignalClosureMarshalData)gcHandle.Target;

                    var args = (GSignalEventArgs)Activator.CreateInstance(marshalData.EventArgsType,
                        paramValues_);

                    marshalData.SignalHandler(obj, args);

                    if (returnValue_ != IntPtr.Zero) {
                        var returnValue = Marshal.PtrToStructure<Value>(returnValue_);
                        returnValue.Set(args.GetType().GetProperty("ReturnValue").GetValue(args));
                        Marshal.StructureToPtr<Value>(returnValue, returnValue_, false);
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

        struct ManagedClosure
        {
            #pragma warning disable CS0649
            public Struct Closure;
            public IntPtr ManagedClosureGCHandle;
            public IntPtr CallbackGCHandle;
            #pragma warning restore CS0649
        }

        static IntPtr managedClosureGCHandleOffset = Marshal.OffsetOf<ManagedClosure>(nameof(ManagedClosure.ManagedClosureGCHandle));
        static IntPtr callbackGCHandleOffset = Marshal.OffsetOf<ManagedClosure>(nameof(ManagedClosure.CallbackGCHandle));
    }
}