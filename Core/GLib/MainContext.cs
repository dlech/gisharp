using System;
using System.Runtime.InteropServices;
using System.Threading;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The `GMainContext` struct is an opaque data
    /// type representing a set of sources to be handled in a main loop.
    /// </summary>
    [GType ("GMainContext", IsProxyForUnmanagedType = true)]
    public sealed class MainContext : Boxed
    {
       static  readonly GType GType = g_main_context_get_type();

        public MainContext(IntPtr handle, Transfer ownership) : base(GType, handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_main_context_ref (IntPtr context);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_main_context_unref (IntPtr context);

        /// <summary>
        /// Creates a new #GMainContext structure.
        /// </summary>
        /// <returns>
        /// the new #GMainContext
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_main_context_new ();

        static IntPtr New ()
        {
            var ret = g_main_context_new ();
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="MainContext"/> structure.
        /// </summary>
        /// <returns>
        /// the new <see cref="MainContext"/>
        /// </returns>
        public MainContext () : this (New (), Transfer.Full)
        {
        }

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop. See also
        /// g_main_context_get_thread_default().
        /// </summary>
        /// <returns>
        /// the global default main context.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_main_context_default ();

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop.
        /// </summary>
        /// <seealso cref="ThreadDefault"/>
        /// <returns>
        /// the global default main context.
        /// </returns>
        public static MainContext Default {
            get {
                var ret_ = g_main_context_default ();
                var ret = GetInstance<MainContext> (ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Gets the thread-default #GMainContext for this thread, as with
        /// g_main_context_get_thread_default(), but also adds a reference to
        /// it with g_main_context_ref(). In addition, unlike
        /// g_main_context_get_thread_default(), if the thread-default context
        /// is the global default context, this will return that #GMainContext
        /// (with a ref added to it) rather than returning %NULL.
        /// </summary>
        /// <returns>
        /// the thread-default #GMainContext. Unref
        ///     with g_main_context_unref() when you are done with it.
        /// </returns>
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_main_context_ref_thread_default ();

        /// <summary>
        /// Gets the thread-default <see cref="MainContext"/> for this thread.
        /// </summary>
        /// <returns>
        /// the thread-default <see cref="MainContext"/>.
        /// </returns>
        [Since ("2.32")]
        public static MainContext ThreadDefault {
            get {
                var ret_ = g_main_context_ref_thread_default ();
                var ret = GetInstance<MainContext> (ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// g_main_context_dispatch() on any #GMainContext in the current thread.
        ///  That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from g_main_context_iteration()
        /// (or g_main_loop_run(), etc.) it returns 1. When called from within
        /// a callback to a recursive call to g_main_context_iteration(),
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using g_main_depth()
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use g_main_depth() to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if g_main_depth() returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_main_depth ();

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// <see cref="Dispatch"/> on any <see cref="MainContext"/> in the current thread.
        /// That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from <see cref="Iteration"/>
        /// (or <see cref="MainLoop.Run"/>, etc.) it returns 1. When called from within
        /// a callback to a recursive call to <see cref="Iteration"/>,
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using <see cref="Depth"/>
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use <see cref="Depth"/> to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if <see cref="Depth"/> returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        public static int Depth {
            get {
                var ret = g_main_depth ();
                return ret;
            }
        }

        /// <summary>
        /// Polls @fds, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by #GMainContext, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of @fds is a #GPollFD describing a single file
        /// descriptor to poll. The %fd field indicates the file descriptor,
        /// and the %events field indicates the events to poll for. On return,
        /// the %revents fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in @fds can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// #GPollFDs with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="nfds">
        /// the number of file descriptors in @fds
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in @fds whose %revents fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [Since ("2.20")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_poll (
            /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)] PollFD[] fds,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nfds,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int timeout);

        /// <summary>
        /// Polls <paramref name="fds"/>, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by <see cref="MainContext"/>, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of <paramref name="fds"/> is a <see cref="PollFD"/> describing a single file
        /// descriptor to poll. The <see cref="PollFD.Fd"/> field indicates the file descriptor,
        /// and the <see cref="PollFD.Events"/> field indicates the events to poll for. On return,
        /// the <see cref="PollFD.Revents"/> fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in <paramref name="fds"/> can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// <see cref="PollFD"/>s with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in <paramref name="fds"/> whose <see cref="PollFD.Revents"/> fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [Since ("2.20")]
        public static int Poll (PollFD[] fds, int timeout)
        {
            if (fds == null) {
                throw new ArgumentNullException (nameof (fds));
            }
            var ret = g_poll (fds, (uint)fds.Length, timeout);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_main_context_get_type ();

        static GType getGType ()
        {
            var ret = g_main_context_get_type ();
            return ret;
        }

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns %FALSE immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when g_main_context_release()
        /// is called as many times as g_main_context_acquire().
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call g_main_context_prepare(), g_main_context_query(),
        /// g_main_context_check(), g_main_context_dispatch().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if the operation succeeded, and
        ///   this thread is now the owner of @context.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_context_acquire (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns <c>false</c> immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when <see cref="Release"/>
        /// is called as many times as <see cref="Acquire"/>.
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call <see cref="Prepare"/>, <see cref="Query"/>,
        /// <see cref="Check"/>, <see cref="Dispatch"/>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the operation succeeded, and
        /// this thread is now the owner of this context.
        /// </returns>
        public bool Acquire ()
        {
            AssertNotDisposed ();
            var ret = g_main_context_acquire (handle);
            return ret;
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use g_source_add_unix_fd() instead.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (or %NULL for the default context)
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        ///      the same as the priority used for g_source_attach() to ensure that the
        ///      file descriptor is polled whenever the results may be needed.
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_add_poll (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context,
            /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
            /* transfer-ownership:none */
            PollFD fd,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use <see cref="Source.AddUnixFd"/> instead.
        /// </summary>
        /// <param name="fd">
        /// a <see cref="PollFD"/> structure holding information about a file
        /// descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        /// the same as the priority used for <see cref="Source.Attach"/> to ensure that the
        /// file descriptor is polled whenever the results may be needed.
        /// </param>
        public void AddPoll (PollFD fd, int priority)
        {
            AssertNotDisposed ();
            g_main_context_add_poll (handle, fd, priority);
        }

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of #GPollFD's that was passed to
        ///       the last call to g_main_context_query()
        /// </param>
        /// <param name="nFds">
        /// return value of g_main_context_query()
        /// </param>
        /// <returns>
        /// %TRUE if some sources are ready to be dispatched.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_main_context_check (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int maxPriority,
            /* <array length="2" zero-terminated="0" type="GPollFD*">
                <type name="PollFD" type="GPollFD" managed-name="PollFD" />
                </array> */
            /* transfer-ownership:none */
            IntPtr fds,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int nFds);

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// <see cref="Acquire"/> before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of <see cref="PollFD"/>s that was passed to
        /// the last call to <see cref="Query"/>
        /// </param>
        /// <returns>
        ///<c>true</c> if some sources are ready to be dispatched.
        /// </returns>
        public int Check (int maxPriority, PollFD[] fds)
        {
            AssertNotDisposed ();
            if (fds == null) {
                throw new ArgumentNullException (nameof(fds));
            }
            var fds_ = GMarshal.CArrayToPtr (fds, false);
            var nFds_ = fds?.Length ?? 0;
            var ret = g_main_context_check (handle, maxPriority, fds_, nFds_);
            GMarshal.Free (fds_);
            return ret;
        }

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_dispatch (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// <see cref="Acquire"/> before you may call this function.
        /// </remarks>
        public void Dispatch ()
        {
            AssertNotDisposed ();
            g_main_context_dispatch (handle);
        }

        /// <summary>
        /// Finds a #GSource given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
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
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="sourceId">
        /// the source ID, as returned by g_source_get_id().
        /// </param>
        /// <returns>
        /// the #GSource
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_main_context_find_source_by_id (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint sourceId);

        /// <summary>
        /// Finds a <see cref="Source"/> given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
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
        /// <param name="sourceId">
        /// the source ID, as returned by <see cref="Source.Id"/>.
        /// </param>
        /// <returns>
        /// the <see cref="Source"/>
        /// </returns>
        public Source FindSourceById (uint sourceId)
        {
            AssertNotDisposed ();
            var ret_ = g_main_context_find_source_by_id (handle, sourceId);
            var ret = GetInstance<Source> (ret_, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the poll function set by g_main_context_set_poll_func().
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// the poll function
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="PollFunc" type="GPollFunc" managed-name="PollFunc" /> */
        /* */
        static extern UnmanagedPollFunc g_main_context_get_poll_func (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// Gets and sets the function to use to handle polling of file descriptors.
        /// </summary>
        /// <value>
        /// the function to call to poll all file descriptors
        /// </value>
        /// <returns>
        /// the poll function
        /// </returns>
        /// <remarks>
        /// It will be used instead of the poll() system call (or GLib's replacement
        /// function, which is used where poll() isn't available).
        ///
        /// This function could possibly be used to integrate the GLib event loop
        /// with an external event loop.
        /// </remarks>
        public UnmanagedPollFunc PollFunc {
            get {
                AssertNotDisposed ();
                var ret = g_main_context_get_poll_func (handle);
                return ret;
            }

            set {
                AssertNotDisposed ();
                g_main_context_set_poll_func (handle, value);
            }
        }

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// This function is the same as g_main_context_invoke() except that it
        /// lets you specify the priority incase @function ends up being
        /// scheduled as an idle and also lets you give a #GDestroyNotify for @data.
        /// 
        /// @notify should not assume that it is called from any particular
        /// thread or with any particular context acquired.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL
        /// </param>
        /// <param name="priority">
        /// the priority at which to run @function
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [Since ("2.28")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_invoke_full (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:2 destroy:3 */
            UnmanagedSourceFunc function,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:async */
            UnmanagedDestroyNotify notify);

        /// <summary>
        /// Invokes a function in such a way that this context is owned during the
        /// invocation of <paramref name="function"/>.
        /// </summary>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority at which to run <paramref name="function"/>
        /// </param>
        [Since ("2.28")]
        public void Invoke (SourceFunc function, int priority = Priority.Default)
        {
            AssertNotDisposed ();
            if (function == null) {
                throw new ArgumentNullException (nameof(function));
            }
            var (function_, notify_, data_) = UnmanagedSourceFuncFactory.CreateNotifyDelegate (function);
            g_main_context_invoke_full (handle, priority, function_, data_, notify_);
        }

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this #GMainContext. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of @context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if current thread is owner of @context.
        /// </returns>
        [Since ("2.10")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_context_is_owner (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this <see cref="MainContext"/>. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of this context.
        /// </summary>
        /// <returns>
        /// <c>true</c> if current thread is owner of this context.
        /// </returns>
        [Since ("2.10")]
        public bool IsOwner {
            get {
                AssertNotDisposed ();
                var ret = g_main_context_is_owner (handle);
                return ret;
            }
        }

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and @may_block is %TRUE, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if @may_block is <c>false</c>
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when @may_block is %TRUE, it is still possible for
        /// g_main_context_iteration() to return <c>false</c>, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// %TRUE if events were dispatched.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_context_iteration (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool mayBlock);

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and <paramref name="mayBlock"/> is <c>true</c>, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if <paramref name="mayBlock"/> is <c>false</c>
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when <paramref name="mayBlock"/> is <c>true</c>, it is still possible for
        /// <see cref="Iteration"/> to return <c>false</c>, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// <c>ture</c> if events were dispatched.
        /// </returns>
        public bool Iteration (bool mayBlock)
        {
            AssertNotDisposed ();
            var ret = g_main_context_iteration (handle, mayBlock);
            return ret;
        }

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// %TRUE if events are pending.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_context_pending (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context);

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <returns>
        /// <c>true</c> if events are pending.
        /// </returns>
        public bool CheckPending ()
        {
            AssertNotDisposed ();
            var ret = g_main_context_pending (handle);
            return ret;
        }

        /// <summary>
        /// Pops @context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        /// <param name="context">
        /// a #GMainContext object, or %NULL
        /// </param>
        [Since ("2.22")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_pop_thread_default (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context);

        /// <summary>
        /// Pops this context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        [Since ("2.22")]
        public void PopThreadDefault ()
        {
            AssertNotDisposed ();
            g_main_context_pop_thread_default (handle);
        }

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling g_main_context_query ().
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="priority">
        /// location to store priority of highest priority
        ///            source already ready.
        /// </param>
        /// <returns>
        /// %TRUE if some source is ready to be dispatched
        ///               prior to polling.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_context_prepare (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context,
            /* <type name="gint" type="gint*" managed-name="Gint" /> */
            /* transfer-ownership:none */
            out int priority);

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling <see cref="Query"/>.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// <see cref="Acquire"/> before you may call this function.
        /// </remarks>
        /// <param name="priority">
        /// location to store priority of highest priority
        /// source already ready.
        /// </param>
        /// <returns>
        /// <c>true</c> if some source is ready to be dispatched
        /// prior to polling.
        /// </returns>
        public bool Prepare (out int priority)
        {
            AssertNotDisposed ();
            var ret = g_main_context_prepare (handle, out priority);
            return ret;
        }

        /// <summary>
        /// Acquires @context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under @context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by g_main_context_get_thread_default(),
        /// not the one returned by g_main_context_default(), so it does not affect
        /// the context used by functions like g_idle_add().
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a #GMainContext which will be run by a
        /// #GMainLoop in that thread, to set a new default context for all
        /// async operations in that thread. In this case you may not need to
        /// ever call g_main_context_pop_thread_default(), assuming you want the
        /// new #GMainContext to be the default for the whole lifecycle of the
        /// thread.
        /// 
        /// If you don't have control over how the new thread was created (e.g.
        /// in the new thread isn't newly created, or if the thread life
        /// cycle is managed by a #GThreadPool), it is always suggested to wrap
        /// the logic that needs to use the new #GMainContext inside a
        /// g_main_context_push_thread_default() / g_main_context_pop_thread_default()
        /// pair, otherwise threads that are re-used will end up never explicitly
        /// releasing the #GMainContext reference they hold.
        /// 
        /// In some cases you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// g_main_context_push_thread_default() /
        /// g_main_context_pop_thread_default() pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL for the global default context
        /// </param>
        [Since ("2.22")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_push_thread_default (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context);

        /// <summary>
        /// Acquires this context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under this context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by <see cref="ThreadDefault"/>,
        /// not the one returned by <see cref="Default"/>, so it does not affect
        /// the context used by functions like <see cref="Idle.Add"/>.
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a <see cref="MainContext"/> which will be run by a
        /// <see cref="MainLoop"/> in that thread, to set a new default context for all
        /// async operations in that thread. In this case you may not need to
        /// ever call <see cref="PopThreadDefault"/>, assuming you want the
        /// new <see cref="MainContext"/> to be the default for the whole lifecycle of the
        /// thread.
        /// 
        /// If you don't have control over how the new thread was created (e.g.
        /// in the new thread isn't newly created, or if the thread life
        /// cycle is managed by a <see cref="ThreadPool"/>), it is always suggested to wrap
        /// the logic that needs to use the new <see cref="MainContext"/> inside a
        /// <see cref="PushThreadDefault"/> / <see cref="PopThreadDefault"/>
        /// pair, otherwise threads that are re-used will end up never explicitly
        /// releasing the <see cref="MainContext"/> reference they hold.
        /// 
        /// In some cases you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// <see cref="PushThreadDefault"/> /
        /// <see cref="PopThreadDefault"/> pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        [Since ("2.22")]
        public void PushThreadDefault ()
        {
            AssertNotDisposed ();
            g_main_context_push_thread_default (handle);
        }

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        ///       store #GPollFD records that need to be polled.
        /// </param>
        /// <param name="nFds">
        /// length of @fds.
        /// </param>
        /// <returns>
        /// the number of records actually stored in @fds,
        ///   or, if more than @n_fds records need to be stored, the number
        ///   of records that need to be stored.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_main_context_query (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int maxPriority,
            /* <type name="gint" type="gint*" managed-name="Gint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out int timeout,
            /* <array length="3" zero-terminated="0" type="GPollFD*">
                <type name="PollFD" type="GPollFD" managed-name="PollFD" />
                </array> */
            /* direction:out caller-allocates:1 transfer-ownership:none */
            IntPtr fds,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none direction:in */
            int nFds);

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// <see cref="Acquire"/> before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        /// store <see cref="PollFD"/> records that need to be polled.
        /// </param>
        public void Query (int maxPriority, out int timeout, out PollFD[] fds)
        {
            AssertNotDisposed ();
            // call first time to get the size
            var ret = g_main_context_query (handle, maxPriority, out timeout, IntPtr.Zero, 0);
            // then call again with appropriate storage space
            var fds_ = GMarshal.Alloc (Marshal.SizeOf<PollFD> () * ret);
            ret = g_main_context_query (handle, maxPriority, out timeout, fds_, ret);
            fds = GMarshal.PtrToCArray<PollFD> (fds_, ret, true);
        }

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with g_main_context_acquire(). If the context was acquired multiple
        /// times, the ownership will be released only when g_main_context_release()
        /// is called as many times as it was acquired.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_release (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with <see cref="Acquire"/>. If the context was acquired multiple
        /// times, the ownership will be released only when <see cref="Release"/>
        /// is called as many times as it was acquired.
        /// </summary>
        public void Release ()
        {
            AssertNotDisposed ();
            g_main_context_release (handle);
        }

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="fd">
        /// a #GPollFD descriptor previously added with g_main_context_add_poll()
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_remove_poll (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context,
            /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
            /* transfer-ownership:none */
            PollFD fd);

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="fd">
        /// a <see cref="PollFD"/> descriptor previously added with <see cref="AddPoll"/>
        /// </param>
        public void RemovePoll (PollFD fd)
        {
            AssertNotDisposed ();
            g_main_context_remove_poll (handle, fd);
        }

        /// <summary>
        /// Sets the function to use to handle polling of file descriptors. It
        /// will be used instead of the poll() system call
        /// (or GLib's replacement function, which is used where
        /// poll() isn't available).
        /// </summary>
        /// <remarks>
        /// This function could possibly be used to integrate the GLib event
        /// loop with an external event loop.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="func">
        /// the function to call to poll all file descriptors
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_set_poll_func (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context,
            /* <type name="PollFunc" type="GPollFunc" managed-name="PollFunc" /> */
            /* transfer-ownership:none */
            UnmanagedPollFunc func);

        /// <summary>
        /// If @context is currently blocking in g_main_context_iteration()
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// g_main_context_iteration() to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over #GMainContext; for
        /// example, integrating it with main loop implementations such as
        /// #GMainLoop.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_context_wakeup (
            /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none */
            IntPtr context);

        /// <summary>
        /// If this context is currently blocking in <see cref="Iteration"/>
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// <see cref="Iteration"/> to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over <see cref="MainContext"/>; for
        /// example, integrating it with main loop implementations such as
        /// <see cref="MainLoop"/>.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        public void Wakeup ()
        {
            AssertNotDisposed ();
            g_main_context_wakeup (handle);
        }

        GSyncronizationContext _SynchronizationContext;
        /// <summary>
        /// Gets the .NET synchronization context for this context.
        /// </summary>
        /// <value>The synchronization context.</value>
        /// <remarks>
        /// This is used to integrate with .NET async.
        ///
        /// SynchronizationContext.SetSynchronizationContext (MainContext.Default.SynchronizationContext);
        ///
        /// ...should be called once at the begining of a program so that async
        /// function callbacks will run in the default GLib main context.
        /// </remarks>
        public SynchronizationContext SynchronizationContext {
            get {
                if (_SynchronizationContext == null) {
                    _SynchronizationContext = new GSyncronizationContext (this);
                }
                return _SynchronizationContext;
            }
        }
    }

    /// <summary>
    /// .NET syncronization context for a GLib <see cref="MainContext"/>
    /// </summary>
    class GSyncronizationContext : SynchronizationContext
    {
        readonly MainContext context;

        public GSyncronizationContext (MainContext context)
        {
            if (context == null) {
                throw new ArgumentNullException (nameof (context));
            }
            this.context = context;
        }

        public override SynchronizationContext CreateCopy ()
        {
            return new GSyncronizationContext (context);
        }

        public override void Post (SendOrPostCallback d, object state)
        {
            var source = Idle.CreateSource ();
            source.SetCallback (() => {
                d.Invoke (state);
                return Source.Remove_;
            });
            source.Attach (context);
        }

        public override void Send (SendOrPostCallback d, object state)
        {
            context.Invoke (() => {
                d.Invoke (state);
                return Source.Remove_;
            });
        }
    }
}
