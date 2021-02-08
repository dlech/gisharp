// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

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
    [GType("GClosure", IsProxyForUnmanagedType = true)]
    public sealed unsafe class Closure : Boxed
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="Closure"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct UnmanagedStruct
        {
#pragma warning disable CS0649
#pragma warning disable CS0169
            internal uint BitFields;
            private IntPtr marshal;
            internal IntPtr Data;
            private IntPtr notifiers;
#pragma warning restore CS0169
#pragma warning restore CS0649
        }

        uint BitFields => ((UnmanagedStruct*)UnsafeHandle)->BitFields;

        uint RefCount => BitFields & 0x7FFF;

        IntPtr Data => ((UnmanagedStruct*)UnsafeHandle)->Data;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Closure(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
            g_closure_sink(this.handle);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_closure_ref(IntPtr closure);

        /// <inheritdoc/>
        public override IntPtr Take() => g_closure_ref(UnsafeHandle);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_closure_sink(IntPtr closure);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_closure_unref(IntPtr closure);

        /// <summary>
        /// Indicates whether the closure is currently being invoked with <see cref="Invoke"/>.
        /// </summary>
        public bool InMarshal {
            get {
                var ret_ = BitFields >> 30;
                var ret = Convert.ToBoolean(ret_ & 0x1);
                return ret;
            }
        }

        /// <summary>
        /// Indicates whether the closure has been invalidated by <see cref="Invalidate"/>.
        /// </summary>
        public bool IsInvalid {
            get {
                var ret_ = BitFields >> 31;
                var ret = Convert.ToBoolean(ret_ & 0x1);
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_closure_new_object(
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint sizeofClosure,
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object);

        static readonly int sizeOfStruct = Marshal.SizeOf<UnmanagedStruct>();

        static IntPtr NewObject(int sizeofClosure, Object @object)
        {
            if (sizeofClosure < sizeOfStruct) {
                const string message = "size must be at least as big as Closure.Struct";
                throw new ArgumentOutOfRangeException(message, nameof(sizeofClosure));
            }
            var object_ = @object.UnsafeHandle;
            var ret = g_closure_new_object((uint)sizeofClosure, object_);
            return ret;
        }

        /// <summary>
        /// A variant of g_closure_new_simple() which stores @object in the
        /// @data field of the closure and calls g_object_watch_closure() on
        /// @object and the created closure. This function is mainly useful
        /// when implementing new types of closures.
        /// </summary>
        /// <param name="callback">
        /// Callback that will be called when the closure is invoked.
        /// </param>
        /// <param name="object">
        /// a #GObject pointer to store in the @data field of the newly
        ///  allocated #GClosure
        /// </param>
        /// <returns>
        /// a newly allocated #GClosure
        /// </returns>
        public Closure(Func<object[], object> callback, Object @object)
            : this(NewObject(Marshal.SizeOf<ManagedClosure>(), @object), Transfer.None)
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

        static IntPtr NewSimple(uint sizeofClosure, IntPtr data)
        {
            var ret = g_closure_new_simple(sizeofClosure, data);
            return ret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Closure"/> class.
        /// </summary>
        public Closure(Func<object[], object> callback)
            : this(NewSimple((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureFuncCallback);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Closure"/> class.
        /// </summary>
        public Closure(Action<object[]> callback)
            : this(NewSimple((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureActionCallback);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Closure"/> class.
        /// </summary>
        public Closure(Action callback)
            : this(NewSimple((uint)Marshal.SizeOf<ManagedClosure>(), IntPtr.Zero), Transfer.None)
        {
            SetCallback(callback, ManagedClosureVoidActionCallback);
        }

        void SetCallback(Delegate callback, ClosureMarshal callbackWrapper)
        {
            var gcHandle = GCHandle.Alloc(callback, GCHandleType.Weak);
            Marshal.WriteIntPtr(handle, (int)callbackGCHandleOffset, (IntPtr)gcHandle);
            var (callback_, notify_, userData_) = ClosureMarshalFactory.Create(callbackWrapper, CallbackScope.Notified);
            g_closure_set_meta_marshal(handle, userData_, callback_);
            g_closure_add_invalidate_notifier(handle, userData_, notify_);
        }

        static void ManagedClosureFuncCallback(Closure closure, ref object? returnValue, object?[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Func<object?[], object>)gcHandle.Target!;
            returnValue = callback(paramValues);
        }

        static void ManagedClosureActionCallback(Closure closure, ref object? returnValue, object?[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Action<object?[]>)gcHandle.Target!;
            callback(paramValues);
        }

        static void ManagedClosureVoidActionCallback(Closure closure, ref object? returnValue, object?[] paramValues, SignalInvocationHint? invocationHintPtr)
        {
            var gcHandle = (GCHandle)Marshal.ReadIntPtr(closure.handle, (int)callbackGCHandleOffset);
            var callback = (Action)gcHandle.Target!;
            callback();
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_closure_get_type();

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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_finalize_notifier(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_invalidate_notifier(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_add_marshal_guards(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_invalidate(
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
        public void Invalidate()
        {
            g_closure_invalidate(UnsafeHandle);
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_invoke(
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            Value* returnValue,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nParamValues,
            /* <array length="1" zero-terminated="0" type="GValue*">
                <type name="Value" type="GValue" managed-name="Value" />
            </array> */
            /* transfer-ownership:none */
            Value* paramValues,
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
        public T Invoke<T>(params object?[] paramValues)
        {
            var this_ = UnsafeHandle;
            if (paramValues is null) {
                throw new ArgumentNullException(nameof(paramValues));
            }

            var returnValue = new Value(GType.Of<T>());
            var paramValues_ = stackalloc Value[paramValues.Length];
            for (int i = 0; i < paramValues.Length; i++) {
                var p = paramValues[i];
                if (p is string s) {
                    p = (Utf8)s;
                }
                paramValues_[i].Init(p?.GetGType() ?? throw new NotImplementedException());
                paramValues_[i].Set(p);
            }

            g_closure_invoke(this_, &returnValue, (uint)paramValues.Length, paramValues_, IntPtr.Zero);
            for (int i = 0; i < paramValues.Length; i++) {
                paramValues_[i].Unset();
            }

            var ret = returnValue.Get();
            returnValue.Unset();

            return (T)ret!;
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_remove_finalize_notifier(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_remove_invalidate_notifier(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_set_marshal(
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_closure_set_meta_marshal(
            /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
            /* transfer-ownership:none */
            IntPtr closure,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr marshalData,
            /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
            /* transfer-ownership:none */
            UnmanagedClosureMarshal metaMarshal);

        struct ManagedClosure
        {
#pragma warning disable CS0649
            public UnmanagedStruct Closure;
            public IntPtr ManagedClosureGCHandle;
            public IntPtr CallbackGCHandle;
#pragma warning restore CS0649
        }

        static IntPtr managedClosureGCHandleOffset = Marshal.OffsetOf<ManagedClosure>(nameof(ManagedClosure.ManagedClosureGCHandle));
        static IntPtr callbackGCHandleOffset = Marshal.OffsetOf<ManagedClosure>(nameof(ManagedClosure.CallbackGCHandle));
    }
}
