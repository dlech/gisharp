using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

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
[GType ("GClosure", IsWrappedNativeType = true)]
public sealed class Closure : ReferenceCountedOpaque
{
    struct ClosureStruct
    {
        #pragma warning disable CS0649
        public uint RefCount;
        public uint MetaMarshalNouse;
        public uint NGuards;
        public uint NFnotifiers;
        public uint NInotifiers;
        public uint InInotify;
        public uint Floating;
        public uint DerivativeFlag;

        /// <summary>
        /// Indicates whether the closure is currently being invoked with
        ///  g_closure_invoke()
        /// </summary>
        public uint InMarshal;

        /// <summary>
        /// Indicates whether the closure has been invalidated by
        ///  g_closure_invalidate()
        /// </summary>
        public uint IsInvalid;

        public IntPtr MarshalImpl;
        public IntPtr Data;
        public IntPtr Notifiers;
        #pragma warning restore CS0649
    }

    public bool InMarshal {
        get {
            var offset = Marshal.OffsetOf<ClosureStruct> (nameof (ClosureStruct.InMarshal));
            var value = Marshal.ReadInt32 (Handle, offset.ToInt32 ());
            return value != 0;
        }
    }

    public bool IsInvalid {
        get {
            var offset = Marshal.OffsetOf<ClosureStruct> (nameof (ClosureStruct.IsInvalid));
            var value = Marshal.ReadInt32 (Handle, offset.ToInt32 ());
            return value != 0;
        }
    }

    public Closure (IntPtr handle, Transfer ownership) : base (handle, ownership)
    {
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

    static IntPtr NewObject (uint sizeofClosure, GISharp.GObject.Object @object)
    {

        if (@object == null) {
            throw new ArgumentNullException (nameof (@object));
        }
        var ret_ = g_closure_new_object (sizeofClosure, @object.Handle);
        return ret_;
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
    public Closure (Func<Value[], Value> callback, GISharp.GObject.Object @object)
        : this (NewObject ((uint)Marshal.SizeOf<ClosureStruct> (), @object), Transfer.None)
    {
        SetCallback (callback);
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
        var ret_ = g_closure_new_simple (sizeofClosure, data);
        return ret_;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Closure"/> class.
    /// </summary>
    public Closure (Func<Value[], Value> callback)
        : this (NewSimple ((uint)Marshal.SizeOf<ClosureStruct> (), IntPtr.Zero), Transfer.None)
    {
        SetCallback (callback);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Closure"/> class.
    /// </summary>
    public Closure (Action<Value[]> callback)
        : this (NewSimple ((uint)Marshal.SizeOf<ClosureStruct> (), IntPtr.Zero), Transfer.None)
    {
        SetCallback (callback);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Closure"/> class.
    /// </summary>
    public Closure (Action callback)
        : this (NewSimple ((uint)Marshal.SizeOf<ClosureStruct> (), IntPtr.Zero), Transfer.None)
    {
        SetCallback (callback);
    }

    void SetCallback (Func<Value[], Value> callback)
    {
        var callbackPtr = (IntPtr)GCHandle.Alloc (callback);
        g_closure_set_meta_marshal (Handle, callbackPtr, NativeMarshalFunc);
        g_closure_add_finalize_notifier (Handle, callbackPtr, FreeCallback);
    }

    static void NativeMarshalFunc (IntPtr closurePtr, ref Value returnValue, uint nParamValues,
                                   Value[] paramValues, IntPtr invocationHintPtr, IntPtr marshalDataPtr)
    {
        var callback = (Func<Value[], Value>)GCHandle.FromIntPtr (marshalDataPtr).Target;
        returnValue = callback.Invoke (paramValues);

    }

    void SetCallback (Action<Value[]> callback)
    {
        var callbackPtr = (IntPtr)GCHandle.Alloc (callback);
        g_closure_set_meta_marshal (Handle, callbackPtr, NativeMarshalNoReturnFunc);
        g_closure_add_finalize_notifier (Handle, callbackPtr, FreeCallback);
    }

    static void NativeMarshalNoReturnFunc (IntPtr closurePtr, ref Value returnValue, uint nParamValues,
                                           Value[] paramValues, IntPtr invocationHintPtr, IntPtr marshalDataPtr)
    {
        var callback = (Action<Value[]>)GCHandle.FromIntPtr (marshalDataPtr).Target;
        callback.Invoke (paramValues);
    }

    void SetCallback (Action callback)
    {
        var callbackPtr = (IntPtr)GCHandle.Alloc (callback);
        g_closure_set_meta_marshal (Handle, callbackPtr, NativeMarshalNoArgsFunc);
        g_closure_add_finalize_notifier (Handle, callbackPtr, FreeCallback);
    }

    static void NativeMarshalNoArgsFunc (IntPtr closurePtr, ref Value returnValue, uint nParamValues,
                                         Value[] paramValues, IntPtr invocationHintPtr, IntPtr marshalDataPtr)
    {
        var callback = (Action)GCHandle.FromIntPtr (marshalDataPtr).Target;
        callback.Invoke ();
    }

    static void FreeCallback (IntPtr dataPtr, IntPtr closurePtr)
    {
        GCHandle.FromIntPtr (dataPtr).Free ();
    }

    [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
    static extern GType g_closure_get_type ();

    static GType getGType ()
    {
        var ret = g_closure_get_type ();
        return ret;
    }

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
        NativeClosureNotify notifyFunc);

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
        NativeClosureNotify notifyFunc);

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
        NativeClosureNotify preMarshalNotify,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr postMarshalData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none */
        NativeClosureNotify postMarshalNotify);

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
        AssertNotDisposed ();
        g_closure_invalidate (Handle);
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
        out Value returnValue,
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
    public Value Invoke (params Value[] paramValues)
    {
        AssertNotDisposed ();
        if (paramValues == null) {
            throw new ArgumentNullException (nameof (paramValues));
        }
        Value returnValue;
        g_closure_invoke (Handle, out returnValue, (uint)paramValues.Length, paramValues, IntPtr.Zero);

        return returnValue;
    }

    /// <summary>
    /// Increments the reference count on a closure to force it staying
    /// alive while the caller holds a pointer to it.
    /// </summary>
    /// <param name="closure">
    /// #GClosure to increment the reference count on
    /// </param>
    /// <returns>
    /// The @closure passed in, for convenience
    /// </returns>
    [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
    /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
    /* transfer-ownership:none skip:1 */
    static extern IntPtr g_closure_ref (
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure);

    /// <summary>
    /// Increments the reference count on a closure to force it staying
    /// alive while the caller holds a pointer to it.
    /// </summary>
    public override void Ref ()
    {
        AssertNotDisposed ();
        g_closure_ref (Handle);
        g_closure_sink (Handle);
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
        NativeClosureNotify notifyFunc);

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
        NativeClosureNotify notifyFunc);

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
        NativeClosureMarshal marshal);

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
        NativeClosureMarshal metaMarshal);

    /// <summary>
    /// Takes over the initial ownership of a closure.  Each closure is
    /// initially created in a "floating" state, which means that the initial
    /// reference count is not owned by any caller. g_closure_sink() checks
    /// to see if the object is still floating, and if so, unsets the
    /// floating state and decreases the reference count. If the closure
    /// is not floating, g_closure_sink() does nothing. The reason for the
    /// existence of the floating state is to prevent cumbersome code
    /// sequences like:
    /// |[&lt;!-- language="C" --&gt;
    /// closure = g_cclosure_new (cb_func, cb_data);
    /// g_source_set_closure (source, closure);
    /// g_closure_unref (closure); // GObject doesn't really need this
    /// ]|
    /// Because g_source_set_closure() (and similar functions) take ownership of the
    /// initial reference count, if it is unowned, we instead can write:
    /// |[&lt;!-- language="C" --&gt;
    /// g_source_set_closure (source, g_cclosure_new (cb_func, cb_data));
    /// ]|
    /// </summary>
    /// <remarks>
    /// Generally, this function is used together with g_closure_ref(). Ane example
    /// of storing a closure for later notification looks like:
    /// |[&lt;!-- language="C" --&gt;
    /// static GClosure *notify_closure = NULL;
    /// void
    /// foo_notify_set_closure (GClosure *closure)
    /// {
    ///   if (notify_closure)
    ///     g_closure_unref (notify_closure);
    ///   notify_closure = closure;
    ///   if (notify_closure)
    ///     {
    ///       g_closure_ref (notify_closure);
    ///       g_closure_sink (notify_closure);
    ///     }
    /// }
    /// ]|
    ///
    /// Because g_closure_sink() may decrement the reference count of a closure
    /// (if it hasn't been called on @closure yet) just like g_closure_unref(),
    /// g_closure_ref() should be called prior to this function.
    /// </remarks>
    /// <param name="closure">
    /// #GClosure to decrement the initial reference count on, if it's
    ///           still being held
    /// </param>
    [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="None" /> */
    /* transfer-ownership:none */
    static extern void g_closure_sink (
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure);

    /// <summary>
    /// Decrements the reference count of a closure after it was previously
    /// incremented by the same caller. If no other callers are using the
    /// closure, then the closure will be destroyed and freed.
    /// </summary>
    /// <param name="closure">
    /// #GClosure to decrement the reference count on
    /// </param>
    [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="None" /> */
    /* transfer-ownership:none */
    static extern void g_closure_unref (
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure);

    /// <summary>
    /// Decrements the reference count of a closure after it was previously
    /// incremented by the same caller. If no other callers are using the
    /// closure, then the closure will be destroyed and freed.
    /// </summary>
    public override void Unref ()
    {
        AssertNotDisposed ();
        g_closure_unref (Handle);
    }
}
