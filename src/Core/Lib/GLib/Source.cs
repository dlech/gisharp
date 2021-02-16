// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;
using GISharp.Runtime;

// GSource is special. It is a GType, but it uses private data appended to the
// GSource struct instead of the usual way of subclassing a GType. So, we are
// making source an abstract class in managed code with a default implementation
// so that it is easy to create new sources in managed code. However, this means
// when wrapping a GSource from unmanaged code, we will have to use a different
// managed class because we cannot instantiate an abstract managed class.

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Data type representing an event source.
    /// </summary>
    [GType("GSource", IsProxyForUnmanagedType = true)]
    public abstract unsafe class Source : Boxed
    {
        /// <summary>
        /// <see cref="Source"/> user data that acts as handle for source.
        /// </summary>
        public sealed class UserData : IDisposable
        {
            internal readonly IntPtr UnsafeHandle;

            internal UserData(IntPtr userData)
            {
                UnsafeHandle = userData;
            }

            [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern Runtime.Boolean g_source_remove_by_user_data(
                IntPtr user_data);

            /// <summary>
            /// Removes a source from the default main loop context given the
            /// user data for the callback.
            /// </summary>
            /// <remarks>
            /// If multiple sources exist with the same user data, only one
            /// will be destroyed.
            /// </remarks>
            public void Dispose()
            {
                g_source_remove_by_user_data(UnsafeHandle);
            }
        }

        /// <summary>
        /// The unmanaged data structure for <see cref="Source"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct UnmanagedStruct
        {
#pragma warning disable CS0649
#pragma warning disable CS0169
            // This is an opaque struct, so the fields should not be used. We
            // just need them to get the correct struct size.
            private IntPtr callbackData;
            private IntPtr callbackFuncs;
            private IntPtr sourceFuncs;
            private uint refCount;
            private IntPtr context;
            private int priority;
            private uint flags;
            private uint sourceId;
            private IntPtr pollFds;
            private IntPtr prev;
            private IntPtr next;
            private IntPtr name;
            private IntPtr priv;
#pragma warning restore CS0169
#pragma warning restore CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Source(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                this.handle = (IntPtr)g_source_ref((UnmanagedStruct*)handle);
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_source_unref((UnmanagedStruct*)handle);
            }
            base.Dispose(disposing);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_source_ref(UnmanagedStruct* source);

        /// <inheritdoc/>
        public override IntPtr Take() => (IntPtr)g_source_ref((UnmanagedStruct*)UnsafeHandle);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_source_unref(UnmanagedStruct* source);

        struct ManagedSource
        {
#pragma warning disable CS0649
            public UnmanagedStruct source;
            public IntPtr gcHandle;
#pragma warning restore CS0649
        }

        static readonly SourceFuncs managedSourceFuncs = new() {
            Prepare = &PrepareManagedSource,
            Check = &CheckManagedSource,
            Dispatch = &DispatchManagedSource,
            Finalize = &FinalizeManagedSource,
        };

        /// <summary>
        /// Use this value as the return value of a <see cref="SourceFunc"/> to leave
        /// the <see cref="Source"/> in the main loop.
        /// </summary>
        [Since("2.32")]
        public const bool Continue = true;

        /// <summary>
        /// Use this value as the return value of a <see cref="SourceFunc"/> to remove
        /// the <see cref="Source"/> from the main loop.
        /// </summary>
        [Since("2.32")]
        public const bool Remove_ = false;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Runtime.Boolean PrepareManagedSource(UnmanagedStruct* source_, int* timeout_)
        {
            try {
                var managedSource = (ManagedSource*)source_;
                var gcHandle = GCHandle.FromIntPtr(managedSource->gcHandle);
                var source = (Source)gcHandle.Target!;
                var ret = source.OnPrepare(out *timeout_);
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        /// <summary>
        /// Called before all the file descriptors are polled.
        /// </summary>
        /// <param name="timeout">Timeout.</param>
        /// <remarks>
        /// If the source can determine that it is ready here (without waiting
        /// for the results of the poll() call) it should return <c>true</c>.
        /// It can also return a <paramref name="timeout"/> value which should
        /// be the maximum timeout (in milliseconds) which should be passed to
        /// the poll() call. The actual timeout used will be -1 if all sources
        /// returned -1, or it will be the minimum of all the <paramref name="timeout"/>
        /// values returned which were >= 0. If <see cref="OnPrepare"/> returns a
        /// timeout and the source also has a 'ready time' set then the nearer
        /// of the two will be used.
        /// </remarks>
        protected virtual bool OnPrepare(out int timeout) => throw new NotImplementedException();

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Runtime.Boolean CheckManagedSource(UnmanagedStruct* source_)
        {
            try {
                var managedSource = (ManagedSource*)source_;
                var gcHandle = GCHandle.FromIntPtr(managedSource->gcHandle);
                var source = (Source)gcHandle.Target!;
                var ret = source.OnCheck();
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        /// <summary>
        /// Called after all the file descriptors are polled.
        /// </summary>
        /// <remarks>
        /// The source should return <c>true</c> if it is ready to be dispatched.
        /// Note that some time may have passed since the previous prepare
        /// function was called, so the source should be checked again here.
        /// </remarks>
        protected virtual bool OnCheck() => throw new NotImplementedException();

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Runtime.Boolean DispatchManagedSource(UnmanagedStruct* source_,
            IntPtr callback_, IntPtr userData_)
        {
            try {
                var managedSource = (ManagedSource*)source_;
                var callback = (delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean>)callback_;
                var gcHandle = GCHandle.FromIntPtr(managedSource->gcHandle);
                var source = (Source)gcHandle.Target!;
                var ret = source.OnDispatch(() => callback(userData_).IsTrue());
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        /// <summary>
        /// Called to dispatch the event source, after it has returned <c>true</c>
        /// in either its <see cref="OnPrepare"/> or its <see cref="OnCheck"/> function.
        /// </summary>
        /// <param name="callback">Callback.</param>
        /// <remarks>
        /// The <see cref="OnDispatch"/> function is passed in a callback function.
        /// The callback function may be <c>null</c> if the source was never
        /// connected to a callback using <see cref="SetCallback"/>. The dispatch
        /// function should call the callback function. The return value of the
        /// dispatch function should be <see cref="Remove_"/> if the source should
        ///  be removed or <see cref="Continue"/> to keep it.
        /// </remarks>
        protected virtual bool OnDispatch(SourceFunc callback) => throw new NotImplementedException();

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void FinalizeManagedSource(UnmanagedStruct* source_)
        {
            try {
                var managedSource = (ManagedSource*)source_;
                var gcHandle = GCHandle.FromIntPtr(managedSource->gcHandle);
                var source = (Source)gcHandle.Target!;
                source.OnFinalize();
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Called when the source is finalized in unmanaged code.
        /// </summary>
        protected virtual void OnFinalize() => throw new NotImplementedException();

        /// <summary>
        /// Creates a new #GSource structure. The size is specified to
        /// allow creating structures derived from #GSource that contain
        /// additional data. The size passed in must be at least
        /// `sizeof (GSource)`.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement
        ///                the sources behavior.
        /// </param>
        /// <param name="structSize">
        /// size of the #GSource structure to create.
        /// </param>
        /// <returns>
        /// the newly-created #GSource.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_source_new(
            /* <type name="SourceFuncs" type="GSourceFuncs*" managed-name="SourceFuncs" /> */
            /* transfer-ownership:none */
            SourceFuncs* sourceFuncs,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint structSize);

        static UnmanagedStruct* NewManagedSource()
        {
            var structSize = Marshal.SizeOf<ManagedSource>();
            fixed (SourceFuncs* managedSourceFuncs_ = &managedSourceFuncs) {
                var ret = g_source_new(managedSourceFuncs_, (uint)structSize);
                return ret;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Source"/>.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Attach"/> before it will be executed.
        /// </remarks>
        Source() : this((IntPtr)NewManagedSource(), Transfer.Full)
        {
            var managedSource = (ManagedSource*)handle;
            // This handle is freed from unmanged code in the FinalizeManagedSource callback.
            managedSource->gcHandle = GCHandle.ToIntPtr(GCHandle.Alloc(this));
        }

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a #GSource is given by g_source_get_id(), or will be
        /// returned by the functions g_source_attach(), g_idle_add(),
        /// g_idle_add_full(), g_timeout_add(), g_timeout_add_full(),
        /// g_child_watch_add(), g_child_watch_add_full(), g_io_add_watch(), and
        /// g_io_add_watch_full().
        ///
        /// See also g_source_destroy(). You must use g_source_destroy() for sources
        /// added to a non-default main context.
        ///
        /// It is a programmer error to attempt to remove a non-existent source.
        ///
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="id">
        /// the ID of the source to remove.
        /// </param>
        /// <returns>
        /// For historical reasons, this function always returns %TRUE
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none skip:1 */
        static extern Runtime.Boolean g_source_remove(
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint id);

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a <see cref="Source"/> is given by <see cref="Id"/>, or will be
        /// returned by the functions <see cref="Attach"/>, <see cref="Idle.Add"/>,
        /// <see cref="Timeout.Add"/>, <see cref="M:ChildWatch.Add"/>
        /// and <see cref="M:Gio.AddWatch"/>.
        ///
        /// You must use <see cref="Destroy"/> for sources
        /// added to a non-default main context.
        ///
        /// It is a programmer error to attempt to remove a non-existent source.
        ///
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with <see cref="Idle.Add"/>: the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <seealso cref="Destroy"/>
        /// <param name="id">
        /// the ID of the source to remove.
        /// </param>
        public static void Remove(uint id)
        {
            g_source_remove(id);
        }

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of g_idle_add(), g_timeout_add(), etc.
        ///
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        ///
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a #GSource ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_name_by_id(
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint tag,
            /* <type name="utf8" type="const char*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* name);

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of <see cref="Idle.Add"/>, <see cref="Timeout.Add"/>, etc.
        ///
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        ///
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with <see cref="Idle.Add"/>: the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a <see cref="Source"/> ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [Since("2.26")]
        public static void SetNameById(uint tag, UnownedUtf8 name)
        {
            var name_ = (byte*)name.UnsafeHandle;
            g_source_set_name_by_id(tag, name_);
        }

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or %NULL.
        /// </returns>
        [Since("2.12")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_main_current_source();

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or <c>null</c>.
        /// </returns>
        [Since("2.12")]
        public static Source Current {
            get {
                var ret_ = g_main_current_source();
                var ret = GetInstance<Source>((IntPtr)ret_, Transfer.None);
                return ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        static extern GType g_source_get_type();

        static readonly GType _GType = g_source_get_type();

        /// <summary>
        /// Adds @child_source to @source as a "polled" source; when @source is
        /// added to a #GMainContext, @child_source will be automatically added
        /// with the same priority, when @child_source is triggered, it will
        /// cause @source to dispatch (in addition to calling its own
        /// callback), and when @source is destroyed, it will destroy
        /// @child_source as well. (@source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need @child_source to do anything on its own when it
        /// triggers, you can call g_source_set_dummy_callback() on it to set a
        /// callback that does nothing (except return %TRUE if appropriate).
        ///
        /// @source will hold a reference on @child_source while @child_source
        /// is attached to it.
        ///
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a second #GSource that @source should "poll"
        /// </param>
        [Since("2.28")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_add_child_source(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* childSource);

        /// <summary>
        /// Adds <paramref name="childSource"/> to this source as a "polled" source; when this source is
        /// added to a <see cref="MainContext"/>, <paramref name="childSource"/> will be automatically added
        /// with the same priority, when <paramref name="childSource"/> is triggered, it will
        /// cause this source to dispatch (in addition to calling its own
        /// callback), and when this source is destroyed, it will destroy
        /// <paramref name="childSource"/> as well. (this source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need <paramref name="childSource"/> to do anything on its own when it
        /// triggers, you can call <see cref="M:SetDummyCallback"/> on it to set a
        /// callback that does nothing (except return <c>true</c> if appropriate).
        ///
        /// This API is only intended to be used by implementations of <see cref="Source"/>.
        /// Do not call this API on a <see cref="Source"/> that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a second <see cref="Source"/> that this source should "poll"
        /// </param>
        [Since("2.28")]
        public void AddChildSource(Source childSource)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            var childSource_ = (UnmanagedStruct*)childSource.UnsafeHandle;
            g_source_add_child_source(source_, childSource_);
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with g_source_new() to add an
        /// event source. The event source's check function will typically test
        /// the @revents field in the #GPollFD struct and return %TRUE if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        ///
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// g_source_add_unix_fd() instead of this API.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_add_poll(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
            /* transfer-ownership:none */
            PollFD* fd);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with <see cref="Source()"/> to add an
        /// event source. The event source's check function will typically test
        /// the revents field in the <see cref="PollFD"/> struct and return <c>true</c> if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of <see cref="Source"/>.
        /// Do not call this API on a <see cref="Source"/> that you did not create.
        ///
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// <see cref="M:AddUnixFd"/> instead of this API.
        /// </remarks>
        /// <param name="fd">
        /// a <see cref="PollFD"/> structure holding information about a file
        /// descriptor to watch.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddPoll(in PollFD fd)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            fixed (PollFD* fd_ = &fd) {
                g_source_add_poll(source_, fd_);
            }
        }

        /// <summary>
        /// Adds a #GSource to a @context so that it will be executed within
        /// that context. Remove it by calling g_source_destroy().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        ///   #GMainContext.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_source_attach(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            MainContext.UnmanagedStruct* context);

        /// <summary>
        /// Adds a <see cref="Source"/> to <paramref name="context"/> so that it will be executed within
        /// that context. Remove it by calling <see cref="Destroy"/>.
        /// </summary>
        /// <param name="context">
        /// a <see cref="MainContext"/> (if <c>null</c>, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        /// <see cref="MainContext"/>.
        /// </returns>
        public uint Attach(MainContext? context)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            if (IsDestroyed) {
                throw new InvalidOperationException("Source has already been destroyed.");
            }
            var context_ = (MainContext.UnmanagedStruct*)(context?.UnsafeHandle ?? IntPtr.Zero);
            var ret = g_source_attach(source_, context_);
            return ret;
        }

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_destroy(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        public void Destroy()
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            g_source_destroy(source_);
        }

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_source_get_can_recurse(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        public bool CanRecurse {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_source_get_can_recurse(source_);
                var ret = ret_.IsTrue();
                return ret;
            }

            set {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var canRecurse_ = value.ToBoolean();
                g_source_set_can_recurse(source_, canRecurse_);
            }
        }

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
        /* transfer-ownership:none nullable:1 */
        static extern MainContext.UnmanagedStruct* g_source_get_context(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        public MainContext Context {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_source_get_context(source_);
                var ret = GetInstance<MainContext>((IntPtr)ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by g_main_context_find_source_by_id().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_source_get_id(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by <see cref="MainContext.FindSourceById(uint)" />).
        /// </summary>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        public uint Id {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_source_get_id(source_);
                return ret;
            }
        }

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the name of the source
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern byte* g_source_get_name(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <returns>
        /// the name of the source
        /// </returns>
        [Since("2.26")]
        public NullableUnownedUtf8 Name {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_source_get_name(source_);
                var ret = new NullableUnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
            set {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var value_ = (byte*)value.UnsafeHandle;
                g_source_set_name(source_, value_);
            }
        }

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the priority of the source
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_source_get_priority(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <returns>
        /// the priority of the source
        /// </returns>
        public int Priority {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_source_get_priority(source_);
                return ret;
            }
            set {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                g_source_set_priority(source_, value);
            }
        }

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern long g_source_get_ready_time(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        public long ReadyTime {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_source_get_ready_time(source_);
                return ret;
            }
            set {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                g_source_set_ready_time(source_, value);
            }
        }

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [Since("2.28")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern long g_source_get_time(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [Since("2.28")]
        public long Time {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_source_get_time(source_);
                return ret;
            }
        }

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///
        ///   return G_SOURCE_REMOVE;
        /// }
        ///
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        ///
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [Since("2.12")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_source_is_destroyed(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source);

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///
        ///   return G_SOURCE_REMOVE;
        /// }
        ///
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        ///
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [Since("2.12")]
        public bool IsDestroyed {
            get {
                var source_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_source_is_destroyed(source_);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Detaches @child_source from @source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a #GSource previously passed to
        ///     g_source_add_child_source().
        /// </param>
        [Since("2.28")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_remove_child_source(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* childSource);

        /// <summary>
        /// Detaches <paramref name="childSource" /> from this source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of <see cref="Source" />.
        /// Do not call this API on a  <see cref="Source" /> that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a <see cref="Source" /> previously passed to <see cref="AddChildSource" />
        /// </param>
        [Since("2.28")]
        public void RemoveChildSource(Source childSource)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            var childSource_ = (UnmanagedStruct*)childSource.UnsafeHandle;
            g_source_remove_child_source(source_, childSource_);
        }

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_remove_poll(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
            /* transfer-ownership:none */
            PollFD* fd);

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of <see cref="Source" />.
        /// Do not call this API on a <see cref="Source" /> that you did not create.
        /// </remarks>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemovePoll(in PollFD fd)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            fixed (PollFD* fd_ = &fd) {
                g_source_remove_poll(source_, fd_);
            }
        }

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        ///
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        ///
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [Since("2.36")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_remove_unix_fd(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr tag);

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        ///
        /// This API is only intended to be used by implementations of <see cref="Source" />.
        /// Do not call this API on a <see cref="Source" /> that you did not create.
        ///
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [Since("2.36")]
        public void RemoveUnixFd(IntPtr tag)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            g_source_remove_unix_fd(source_, tag);
        }

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        ///
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle memory management of @data.
        ///
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="func">
        /// a callback function
        /// </param>
        /// <param name="data">
        /// the data to pass to callback function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_callback(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:1 destroy:2 */
            IntPtr func,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:async */
            IntPtr notify);

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        ///
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle memory management of @data.
        ///
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="func">
        /// the managed callback
        /// </param>
        /// <param name="marshalToPointer">
        /// the unmanaged callback marshal to pointer method
        /// </param>
        protected void SetCallback<T>(T func, Func<T, CallbackScope, (IntPtr, IntPtr, IntPtr)> marshalToPointer) where T : Delegate
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            var (func_, notify_, data_) = marshalToPointer(func, CallbackScope.Notified);
            g_source_set_callback(source_, func_, data_, notify_);
        }

        /// <summary>
        /// Sets the callback function storing the data as a refcounted callback
        /// "object". This is used internally. Note that calling
        /// g_source_set_callback_indirect() assumes
        /// an initial reference count on @callback_data, and thus
        /// @callback_funcs-&gt;unref will eventually be called once more
        /// than @callback_funcs-&gt;ref.
        /// </summary>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="callbackData">
        /// pointer to callback data "object"
        /// </param>
        /// <param name="callbackFuncs">
        /// functions for reference counting @callback_data
        ///                  and getting the callback and data
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_callback_indirect(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr callbackData,
            /* <type name="SourceCallbackFuncs" type="GSourceCallbackFuncs*" managed-name="SourceCallbackFuncs" /> */
            /* transfer-ownership:none */
            SourceCallbackFuncs* callbackFuncs);

        /// <summary>
        /// Sets whether a source can be called recursively. If @can_recurse is
        /// %TRUE, then while the source is being dispatched then this source
        /// will be processed normally. Otherwise, all processing of this
        /// source is blocked until the dispatch function returns.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="canRecurse">
        /// whether recursion is allowed for this source
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_can_recurse(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean canRecurse);

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [Since("2.12")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_funcs(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="SourceFuncs" type="GSourceFuncs*" managed-name="SourceFuncs" /> */
            /* transfer-ownership:none */
            SourceFuncs* funcs);

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [Since("2.12")]
        void SetFuncs(in SourceFuncs funcs)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            fixed (SourceFuncs* funcs_ = &funcs) {
                g_source_set_funcs(source_, funcs_);
            }
        }

        /// <summary>
        /// Sets a name for the source, used in debugging and profiling.
        /// The name defaults to #NULL.
        /// </summary>
        /// <remarks>
        /// The source name should describe in a human-readable way
        /// what the source does. For example, "X11 event queue"
        /// or "GTK+ repaint idle handler" or whatever it is.
        ///
        /// It is permitted to call this function multiple times, but is not
        /// recommended due to the potential performance impact.  For example,
        /// one could change the name in the "check" function of a #GSourceFuncs
        /// to include details like the event type in the source name.
        ///
        /// Use caution if changing the name while another thread may be
        /// accessing it with g_source_get_name(); that function does not copy
        /// the value, and changing the value will free it while the other thread
        /// may be attempting to use it.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_name(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="utf8" type="const char*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* name);

        /// <summary>
        /// Sets the priority of a source. While the main loop is being run, a
        /// source will be dispatched if it is ready to be dispatched and no
        /// sources at a higher (numerically smaller) priority are ready to be
        /// dispatched.
        /// </summary>
        /// <remarks>
        /// A child source always has the same priority as its parent.  It is not
        /// permitted to change the priority of a source once it has been added
        /// as a child of another source.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="priority">
        /// the new priority.
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_priority(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority);

        /// <summary>
        /// Sets a #GSource to be dispatched when the given monotonic time is
        /// reached (or passed).  If the monotonic time is in the past (as it
        /// always will be if @ready_time is 0) then the source will be
        /// dispatched immediately.
        /// </summary>
        /// <remarks>
        /// If @ready_time is -1 then the source is never woken up on the basis
        /// of the passage of time.
        ///
        /// Dispatching the source does not reset the ready time.  You should do
        /// so yourself, from the source dispatch function.
        ///
        /// Note that if you have a pair of sources where the ready time of one
        /// suggests that it will be delivered first but the priority for the
        /// other suggests that it would be delivered first, and the ready time
        /// for both sources is reached during the same main context iteration
        /// then the order of dispatch is undefined.
        ///
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="readyTime">
        /// the monotonic time at which the source will be ready,
        ///              0 for "immediately", -1 for "never"
        /// </param>
        [Since("2.36")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_source_set_ready_time(
            /* <type name="Source" type="GSource*" managed-name="Source" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* source,
            /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
            /* transfer-ownership:none */
            long readyTime);
    }

    sealed class UnmanagedSource : Source
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnmanagedSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        protected override bool OnCheck()
        {
            throw new NotSupportedException();
        }

        protected override bool OnDispatch(SourceFunc callback)
        {
            throw new NotSupportedException();
        }

        protected override void OnFinalize()
        {
            throw new NotSupportedException();
        }

        protected override bool OnPrepare(out int timeout)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// The `GSourceFuncs` struct contains a table of
    /// functions used to handle event sources in a generic manner.
    /// </summary>
    /// <remarks>
    /// For idle sources, the prepare and check functions always return %TRUE
    /// to indicate that the source is always ready to be processed. The prepare
    /// function also returns a timeout value of 0 to ensure that the poll() call
    /// doesn't block (since that would be time wasted which could have been spent
    /// running the idle function).
    ///
    /// For timeout sources, the prepare and check functions both return %TRUE
    /// if the timeout interval has expired. The prepare function also returns
    /// a timeout value to ensure that the poll() call doesn't block too long
    /// and miss the next timeout.
    ///
    /// For file descriptor sources, the prepare function typically returns <c>false</c>,
    /// since it must wait until poll() has been called before it knows whether
    /// any events need to be processed. It sets the returned timeout to -1 to
    /// indicate that it doesn't mind how long the poll() call blocks. In the
    /// check function, it tests the results of the poll() call to see if the
    /// required condition has been met, and returns %TRUE if so.
    /// </remarks>
    unsafe struct SourceFuncs
    {
        public delegate* unmanaged[Cdecl]<Source.UnmanagedStruct*, int*, Runtime.Boolean> Prepare;
        public delegate* unmanaged[Cdecl]<Source.UnmanagedStruct*, Runtime.Boolean> Check;
        public delegate* unmanaged[Cdecl]<Source.UnmanagedStruct*, IntPtr, IntPtr, Runtime.Boolean> Dispatch;
        public delegate* unmanaged[Cdecl]<Source.UnmanagedStruct*, void> Finalize;

        // private fields
#pragma warning disable CS0169
        delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean> closureCallback;
        delegate* unmanaged[Cdecl]<IntPtr, Value*, uint, Value*, IntPtr, IntPtr, void> closureMarshal;
#pragma warning restore CS0169
    }

    /// <summary>
    /// The `GSourceCallbackFuncs` struct contains
    /// functions for managing callback objects.
    /// </summary>
    unsafe struct SourceCallbackFuncs
    {
#pragma warning disable CS0649
        public delegate* unmanaged[Cdecl]<IntPtr, void> Ref;
        public delegate* unmanaged[Cdecl]<IntPtr, void> Unref;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, SourceFuncs*, IntPtr> Get;
#pragma warning restore CS0649
    }
}
