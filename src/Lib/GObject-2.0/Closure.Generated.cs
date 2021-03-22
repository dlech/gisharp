// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="Closure.xmldoc" path="declaration/member[@name='Closure']/*" />
    [GISharp.Runtime.GTypeAttribute("GClosure", IsProxyForUnmanagedType = true)]
    public unsafe partial class Closure : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Runtime.GType _GType = g_closure_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="Closure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Bits0']/*" />
            public readonly uint Bits0;

            /// <include file="Closure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Marshal']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Closure.UnmanagedStruct*, GISharp.Lib.GObject.Value*, uint, GISharp.Lib.GObject.Value*, System.IntPtr, System.IntPtr, void> Marshal;

            /// <include file="Closure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Data']/*" />
            internal readonly System.IntPtr Data;

            /// <include file="Closure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Notifiers']/*" />
            internal readonly GISharp.Lib.GObject.ClosureNotifyData* Notifiers;
#pragma warning restore CS0169, CS0414, CS0649
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_closure_new_object(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint sizeofClosure,
        /* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* @object);
        static partial void CheckNewObjectArgs(uint sizeofClosure, GISharp.Lib.GObject.Object @object);

        static GISharp.Lib.GObject.Closure.UnmanagedStruct* NewObject(uint sizeofClosure, GISharp.Lib.GObject.Object @object)
        {
            CheckNewObjectArgs(sizeofClosure, @object);
            var sizeofClosure_ = (uint)sizeofClosure;
            var @object_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)@object.UnsafeHandle;
            var ret_ = g_closure_new_object(sizeofClosure_,@object_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Allocates a struct of the given size and initializes the initial
        /// part as a #GClosure. This function is mainly useful when
        /// implementing new types of closures.
        /// </summary>
        /// <remarks>
        /// <para>
        /// |[&lt;!-- language="C" --&gt;
        /// typedef struct _MyClosure MyClosure;
        /// struct _MyClosure
        /// {
        ///   GClosure closure;
        ///   // extra data goes here
        /// };
        /// </para>
        /// <para>
        /// static void
        /// my_closure_finalize (gpointer  notify_data,
        ///                      GClosure *closure)
        /// {
        ///   MyClosure *my_closure = (MyClosure *)closure;
        /// </para>
        /// <para>
        ///   // free extra data here
        /// }
        /// </para>
        /// <para>
        /// MyClosure *my_closure_new (gpointer data)
        /// {
        ///   GClosure *closure;
        ///   MyClosure *my_closure;
        /// </para>
        /// <para>
        ///   closure = g_closure_new_simple (sizeof (MyClosure), data);
        ///   my_closure = (MyClosure *) closure;
        /// </para>
        /// <para>
        ///   // initialize extra data here
        /// </para>
        /// <para>
        ///   g_closure_add_finalize_notifier (closure, notify_data,
        ///                                    my_closure_finalize);
        ///   return my_closure;
        /// }
        /// ]|
        /// </para>
        /// </remarks>
        /// <param name="sizeofClosure">
        /// the size of the structure to allocate, must be at least
        ///                  `sizeof (GClosure)`
        /// </param>
        /// <param name="data">
        /// data to store in the @data field of the newly allocated #GClosure
        /// </param>
        /// <returns>
        /// a floating reference to a new #GClosure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_closure_new_simple(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint sizeofClosure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data);
        static partial void CheckNewSimpleArgs(uint sizeofClosure, System.IntPtr data);

        static GISharp.Lib.GObject.Closure.UnmanagedStruct* NewSimple(uint sizeofClosure, System.IntPtr data)
        {
            CheckNewSimpleArgs(sizeofClosure, data);
            var sizeofClosure_ = (uint)sizeofClosure;
            var data_ = (System.IntPtr)data;
            var ret_ = g_closure_new_simple(sizeofClosure_,data_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_closure_get_type();

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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_add_finalize_notifier(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr notifyData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> notifyFunc);

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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_add_invalidate_notifier(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr notifyData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> notifyFunc);

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
        /// data to pass
        ///  to @pre_marshal_notify
        /// </param>
        /// <param name="preMarshalNotify">
        /// a function to call before the closure callback
        /// </param>
        /// <param name="postMarshalData">
        /// data to pass
        ///  to @post_marshal_notify
        /// </param>
        /// <param name="postMarshalNotify">
        /// a function to call after the closure callback
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_add_marshal_guards(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr preMarshalData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> preMarshalNotify,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr postMarshalData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> postMarshalNotify);

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
        /// <para>
        /// Note that g_closure_invalidate() will also be called when the
        /// reference count of a closure drops to zero (unless it has already
        /// been invalidated before).
        /// </para>
        /// </remarks>
        /// <param name="closure">
        /// #GClosure to invalidate
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_closure_invalidate(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure);
        partial void CheckInvalidateArgs();

        /// <include file="Closure.xmldoc" path="declaration/member[@name='Closure.Invalidate()']/*" />
        public void Invalidate()
        {
            CheckInvalidateArgs();
            var closure_ = (GISharp.Lib.GObject.Closure.UnmanagedStruct*)UnsafeHandle;
            g_closure_invalidate(closure_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_closure_invoke(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none optional:1 allow-none:1 */
        GISharp.Lib.GObject.Value* returnValue,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint nParamValues,
        /* <array length="1" zero-terminated="0" type="const GValue*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="Value" type="GValue" managed-name="Value" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Value* paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr invocationHint);
        partial void CheckInvokeArgs(System.ReadOnlySpan<GISharp.Lib.GObject.Value> paramValues, System.IntPtr invocationHint);

        /// <include file="Closure.xmldoc" path="declaration/member[@name='Closure.Invoke(GISharp.Lib.GObject.Value,System.ReadOnlySpan&lt;GISharp.Lib.GObject.Value&gt;,System.IntPtr)']/*" />
        public void Invoke(out GISharp.Lib.GObject.Value returnValue, System.ReadOnlySpan<GISharp.Lib.GObject.Value> paramValues, System.IntPtr invocationHint)
        {
            fixed (GISharp.Lib.GObject.Value* paramValuesData_ = paramValues)
            {
                fixed (GISharp.Lib.GObject.Value* returnValue_ = &returnValue)
                {
                    CheckInvokeArgs(paramValues, invocationHint);
                    var closure_ = (GISharp.Lib.GObject.Closure.UnmanagedStruct*)UnsafeHandle;
                    var paramValues_ = (GISharp.Lib.GObject.Value*)paramValuesData_;
                    var nParamValues_ = (uint)paramValues.Length;
                    var invocationHint_ = (System.IntPtr)invocationHint;
                    g_closure_invoke(closure_, returnValue_, nParamValues_, paramValues_, invocationHint_);
                    GISharp.Runtime.GMarshal.PopUnhandledException();
                }
            }
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_closure_ref(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_closure_ref((GISharp.Lib.GObject.Closure.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Removes a finalization notifier.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Notice that notifiers are automatically removed after they are run.
        /// </para>
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_remove_finalize_notifier(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr notifyData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> notifyFunc);

        /// <summary>
        /// Removes an invalidation notifier.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Notice that notifiers are automatically removed after they are run.
        /// </para>
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_remove_invalidate_notifier(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr notifyData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> notifyFunc);

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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_set_marshal(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Closure.UnmanagedStruct*, GISharp.Lib.GObject.Value*, uint, GISharp.Lib.GObject.Value*, System.IntPtr, System.IntPtr, void> marshal);

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
        /// <para>
        /// For example, class closures for signals (see
        /// g_signal_type_cclosure_new()) retrieve the callback function from a
        /// fixed offset in the class structure.  The meta marshaller retrieves
        /// the right callback and passes it to the marshaller as the
        /// @marshal_data argument.
        /// </para>
        /// </remarks>
        /// <param name="closure">
        /// a #GClosure
        /// </param>
        /// <param name="marshalData">
        /// context-dependent data to pass
        ///  to @meta_marshal
        /// </param>
        /// <param name="metaMarshal">
        /// a #GClosureMarshal function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private protected static extern void g_closure_set_meta_marshal(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr marshalData,
        /* <type name="ClosureMarshal" type="GClosureMarshal" managed-name="ClosureMarshal" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Closure.UnmanagedStruct*, GISharp.Lib.GObject.Value*, uint, GISharp.Lib.GObject.Value*, System.IntPtr, System.IntPtr, void> metaMarshal);

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
        /// <para>
        /// Generally, this function is used together with g_closure_ref(). An example
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
        /// </para>
        /// <para>
        /// Because g_closure_sink() may decrement the reference count of a closure
        /// (if it hasn't been called on @closure yet) just like g_closure_unref(),
        /// g_closure_ref() should be called prior to this function.
        /// </para>
        /// </remarks>
        /// <param name="closure">
        /// #GClosure to decrement the initial reference count on, if it's
        ///           still being held
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_closure_sink(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure);

        /// <summary>
        /// Decrements the reference count of a closure after it was previously
        /// incremented by the same caller. If no other callers are using the
        /// closure, then the closure will be destroyed and freed.
        /// </summary>
        /// <param name="closure">
        /// #GClosure to decrement the reference count on
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_closure_unref(
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_closure_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }
    }
}