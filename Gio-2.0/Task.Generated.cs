namespace GISharp.Lib.Gio
{
    /// <summary>
    /// A <see cref="Task"/> represents and manages a cancellable "task".
    /// </summary>
    /// <remarks>
    /// ## Asynchronous operations
    /// 
    /// The most common usage of <see cref="Task"/> is as a <see cref="IAsyncResult"/>, to
    /// manage data during an asynchronous operation. You call
    /// <see cref="Task.New"/> in the "start" method, followed by
    /// <see cref="Task.SetTaskData"/> and the like if you need to keep some
    /// additional data associated with the task, and then pass the
    /// task object around through your asynchronous operation.
    /// Eventually, you will call a method such as
    /// <see cref="Task.ReturnPointer"/> or <see cref="Task.ReturnError"/>, which will
    /// save the value you give it and then invoke the task's callback
    /// function in the
    /// [thread-default main context][g-main-context-push-thread-default]
    /// where it was created (waiting until the next iteration of the main
    /// loop first, if necessary). The caller will pass the <see cref="Task"/> back to
    /// the operation's finish function (as a <see cref="IAsyncResult"/>), and you can
    /// can use <see cref="Task.PropagatePointer"/> or the like to extract the
    /// return value.
    /// 
    /// Here is an example for using GTask as a GAsyncResult:
    /// |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } DecorationData;
    /// 
    ///     static void
    ///     decoration_data_free (DecorationData *decoration)
    ///     {
    ///       g_free (decoration-&gt;message);
    ///       g_slice_free (DecorationData, decoration);
    ///     }
    /// 
    ///     static void
    ///     baked_cb (Cake     *cake,
    ///               gpointer  user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       DecorationData *decoration = g_task_get_task_data (task);
    ///       GError *error = NULL;
    /// 
    ///       if (cake == NULL)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_NO_FLOUR,
    ///                                    "Go to the supermarket");
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       if (!cake_decorate (cake, decoration-&gt;frosting, decoration-&gt;message, &amp;error))
    ///         {
    ///           g_object_unref (cake);
    ///           // <see cref="Task.ReturnError"/> takes ownership of error
    ///           g_task_return_error (task, error);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       g_task_return_pointer (task, cake, g_object_unref);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       GTask *task;
    ///       DecorationData *decoration;
    ///       Cake  *cake;
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       if (radius &lt; 3)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_TOO_SMALL,
    ///                                    "%ucm radius cakes are silly",
    ///                                    radius);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       cake = _baker_get_cached_cake (self, radius, flavor, frosting, message);
    ///       if (cake != NULL)
    ///         {
    ///           // _baker_get_cached_cake() returns a reffed cake
    ///           g_task_return_pointer (task, cake, g_object_unref);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       decoration = g_slice_new (DecorationData);
    ///       decoration-&gt;frosting = frosting;
    ///       decoration-&gt;message = g_strdup (message);
    ///       g_task_set_task_data (task, decoration, (GDestroyNotify) decoration_data_free);
    /// 
    ///       _baker_begin_cake (self, radius, flavor, cancellable, baked_cb, task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Chained asynchronous operations
    /// 
    /// <see cref="Task"/> also tries to simplify asynchronous operations that
    /// internally chain together several smaller asynchronous
    /// operations. <see cref="Task.GetCancellable"/>, <see cref="Task.GetContext"/>,
    /// and <see cref="Task.GetPriority"/> allow you to get back the task's
    /// <see cref="Cancellable"/>, #GMainContext, and [I/O priority][io-priority]
    /// when starting a new subtask, so you don't have to keep track
    /// of them yourself. g_task_attach_source() simplifies the case
    /// of waiting for a source to fire (automatically using the correct
    /// #GMainContext and priority).
    /// 
    /// Here is an example for chained asynchronous operations:
    ///   |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       Cake *cake;
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } BakingData;
    /// 
    ///     static void
    ///     decoration_data_free (BakingData *bd)
    ///     {
    ///       if (bd-&gt;cake)
    ///         g_object_unref (bd-&gt;cake);
    ///       g_free (bd-&gt;message);
    ///       g_slice_free (BakingData, bd);
    ///     }
    /// 
    ///     static void
    ///     decorated_cb (Cake         *cake,
    ///                   GAsyncResult *result,
    ///                   gpointer      user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       GError *error = NULL;
    /// 
    ///       if (!cake_decorate_finish (cake, result, &amp;error))
    ///         {
    ///           g_object_unref (cake);
    ///           g_task_return_error (task, error);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       // baking_data_free() will drop its ref on the cake, so we have to
    ///       // take another here to give to the caller.
    ///       g_task_return_pointer (task, g_object_ref (cake), g_object_unref);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     static gboolean
    ///     decorator_ready (gpointer user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       BakingData *bd = g_task_get_task_data (task);
    /// 
    ///       cake_decorate_async (bd-&gt;cake, bd-&gt;frosting, bd-&gt;message,
    ///                            g_task_get_cancellable (task),
    ///                            decorated_cb, task);
    /// 
    ///       return G_SOURCE_REMOVE;
    ///     }
    /// 
    ///     static void
    ///     baked_cb (Cake     *cake,
    ///               gpointer  user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       BakingData *bd = g_task_get_task_data (task);
    ///       GError *error = NULL;
    /// 
    ///       if (cake == NULL)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_NO_FLOUR,
    ///                                    "Go to the supermarket");
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       bd-&gt;cake = cake;
    /// 
    ///       // Bail out now if the user has already cancelled
    ///       if (g_task_return_error_if_cancelled (task))
    ///         {
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       if (cake_decorator_available (cake))
    ///         decorator_ready (task);
    ///       else
    ///         {
    ///           GSource *source;
    /// 
    ///           source = cake_decorator_wait_source_new (cake);
    ///           // Attach <paramref name="source"/> to <paramref name="task"/>'s GMainContext and have it call
    ///           // decorator_ready() when it is ready.
    ///           g_task_attach_source (task, source, decorator_ready);
    ///           g_source_unref (source);
    ///         }
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            gint                 priority,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       GTask *task;
    ///       BakingData *bd;
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_priority (task, priority);
    /// 
    ///       bd = g_slice_new0 (BakingData);
    ///       bd-&gt;frosting = frosting;
    ///       bd-&gt;message = g_strdup (message);
    ///       g_task_set_task_data (task, bd, (GDestroyNotify) baking_data_free);
    /// 
    ///       _baker_begin_cake (self, radius, flavor, cancellable, baked_cb, task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Asynchronous operations from synchronous ones
    /// 
    /// You can use g_task_run_in_thread() to turn a synchronous
    /// operation into an asynchronous one, by running it in a thread.
    /// When it completes, the result will be dispatched to the
    /// [thread-default main context][g-main-context-push-thread-default]
    /// where the <see cref="Task"/> was created.
    /// 
    /// Running a task in a thread:
    ///   |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       guint radius;
    ///       CakeFlavor flavor;
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } CakeData;
    /// 
    ///     static void
    ///     cake_data_free (CakeData *cake_data)
    ///     {
    ///       g_free (cake_data-&gt;message);
    ///       g_slice_free (CakeData, cake_data);
    ///     }
    /// 
    ///     static void
    ///     bake_cake_thread (GTask         *task,
    ///                       gpointer       source_object,
    ///                       gpointer       task_data,
    ///                       GCancellable  *cancellable)
    ///     {
    ///       Baker *self = source_object;
    ///       CakeData *cake_data = task_data;
    ///       Cake *cake;
    ///       GError *error = NULL;
    /// 
    ///       cake = bake_cake (baker, cake_data-&gt;radius, cake_data-&gt;flavor,
    ///                         cake_data-&gt;frosting, cake_data-&gt;message,
    ///                         cancellable, &amp;error);
    ///       if (cake)
    ///         g_task_return_pointer (task, cake, g_object_unref);
    ///       else
    ///         g_task_return_error (task, error);
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    ///       cake_data-&gt;radius = radius;
    ///       cake_data-&gt;flavor = flavor;
    ///       cake_data-&gt;frosting = frosting;
    ///       cake_data-&gt;message = g_strdup (message);
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_run_in_thread (task, bake_cake_thread);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Adding cancellability to uncancellable tasks
    /// 
    /// Finally, g_task_run_in_thread() and g_task_run_in_thread_sync()
    /// can be used to turn an uncancellable operation into a
    /// cancellable one. If you call <see cref="Task.SetReturnOnCancel"/>,
    /// passing <c>true</c>, then if the task's <see cref="Cancellable"/> is cancelled,
    /// it will return control back to the caller immediately, while
    /// allowing the task thread to continue running in the background
    /// (and simply discarding its result when it finally does finish).
    /// Provided that the task thread is careful about how it uses
    /// locks and other externally-visible resources, this allows you
    /// to make "GLib-friendly" asynchronous and cancellable
    /// synchronous variants of blocking APIs.
    /// 
    /// Cancelling a task:
    ///   |[&lt;!-- language="C" --&gt;
    ///     static void
    ///     bake_cake_thread (GTask         *task,
    ///                       gpointer       source_object,
    ///                       gpointer       task_data,
    ///                       GCancellable  *cancellable)
    ///     {
    ///       Baker *self = source_object;
    ///       CakeData *cake_data = task_data;
    ///       Cake *cake;
    ///       GError *error = NULL;
    /// 
    ///       cake = bake_cake (baker, cake_data-&gt;radius, cake_data-&gt;flavor,
    ///                         cake_data-&gt;frosting, cake_data-&gt;message,
    ///                         &amp;error);
    ///       if (error)
    ///         {
    ///           g_task_return_error (task, error);
    ///           return;
    ///         }
    /// 
    ///       // If the task has already been cancelled, then we don't want to add
    ///       // the cake to the cake cache. Likewise, we don't  want to have the
    ///       // task get cancelled in the middle of updating the cache.
    ///       // <see cref="Task.SetReturnOnCancel"/> will return <c>true</c> here if it managed
    ///       // to disable return-on-cancel, or <c>false</c> if the task was cancelled
    ///       // before it could.
    ///       if (g_task_set_return_on_cancel (task, FALSE))
    ///         {
    ///           // If the caller cancels at this point, their
    ///           // GAsyncReadyCallback won't be invoked until we return,
    ///           // so we don't have to worry that this code will run at
    ///           // the same time as that code does. But if there were
    ///           // other functions that might look at the cake cache,
    ///           // then we'd probably need a GMutex here as well.
    ///           baker_add_cake_to_cache (baker, cake);
    ///           g_task_return_pointer (task, cake, g_object_unref);
    ///         }
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    /// 
    ///       ...
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_set_return_on_cancel (task, TRUE);
    ///       g_task_run_in_thread (task, bake_cake_thread);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_sync (Baker               *self,
    ///                           guint                radius,
    ///                           CakeFlavor           flavor,
    ///                           CakeFrostingType     frosting,
    ///                           const char          *message,
    ///                           GCancellable        *cancellable,
    ///                           GError             **error)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    ///       Cake *cake;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    /// 
    ///       ...
    /// 
    ///       task = g_task_new (self, cancellable, NULL, NULL);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_set_return_on_cancel (task, TRUE);
    ///       g_task_run_in_thread_sync (task, bake_cake_thread);
    /// 
    ///       cake = g_task_propagate_pointer (task, error);
    ///       g_object_unref (task);
    ///       return cake;
    ///     }
    /// ]|
    /// 
    /// ## Porting from GSimpleAsyncResult
    /// 
    /// <see cref="Task"/>'s API attempts to be simpler than #GSimpleAsyncResult's
    /// in several ways:
    /// - You can save task-specific data with <see cref="Task.SetTaskData"/>, and
    ///   retrieve it later with <see cref="Task.GetTaskData"/>. This replaces the
    ///   abuse of g_simple_async_result_set_op_res_gpointer() for the same
    ///   purpose with #GSimpleAsyncResult.
    /// - In addition to the task data, <see cref="Task"/> also keeps track of the
    ///   [priority][io-priority], <see cref="Cancellable"/>, and
    ///   #GMainContext associated with the task, so tasks that consist of
    ///   a chain of simpler asynchronous operations will have easy access
    ///   to those values when starting each sub-task.
    /// - <see cref="Task.ReturnErrorIfCancelled"/> provides simplified
    ///   handling for cancellation. In addition, cancellation
    ///   overrides any other <see cref="Task"/> return value by default, like
    ///   #GSimpleAsyncResult does when
    ///   g_simple_async_result_set_check_cancellable() is called.
    ///   (You can use <see cref="Task.SetCheckCancellable"/> to turn off that
    ///   behavior.) On the other hand, g_task_run_in_thread()
    ///   guarantees that it will always run your
    ///   `task_func`, even if the task's <see cref="Cancellable"/>
    ///   is already cancelled before the task gets a chance to run;
    ///   you can start your `task_func` with a
    ///   <see cref="Task.ReturnErrorIfCancelled"/> check if you need the
    ///   old behavior.
    /// - The "return" methods (eg, <see cref="Task.ReturnPointer"/>)
    ///   automatically cause the task to be "completed" as well, and
    ///   there is no need to worry about the "complete" vs "complete
    ///   in idle" distinction. (<see cref="Task"/> automatically figures out
    ///   whether the task's callback can be invoked directly, or
    ///   if it needs to be sent to another #GMainContext, or delayed
    ///   until the next iteration of the current #GMainContext.)
    /// - The "finish" functions for <see cref="Task"/> based operations are generally
    ///   much simpler than #GSimpleAsyncResult ones, normally consisting
    ///   of only a single call to <see cref="Task.PropagatePointer"/> or the like.
    ///   Since <see cref="Task.PropagatePointer"/> "steals" the return value from
    ///   the <see cref="Task"/>, it is not necessary to juggle pointers around to
    ///   prevent it from being freed twice.
    /// - With #GSimpleAsyncResult, it was common to call
    ///   g_simple_async_result_propagate_error() from the
    ///   `_finish()` wrapper function, and have
    ///   virtual method implementations only deal with successful
    ///   returns. This behavior is deprecated, because it makes it
    ///   difficult for a subclass to chain to a parent class's async
    ///   methods. Instead, the wrapper function should just be a
    ///   simple wrapper, and the virtual method should call an
    ///   appropriate `g_task_propagate_` function.
    ///   Note that wrapper methods can now use
    ///   g_async_result_legacy_propagate_error() to do old-style
    ///   #GSimpleAsyncResult error-returning behavior, and
    ///   <see cref="IAsyncResult.IsTagged"/> to check if a result is tagged as
    ///   having come from the `_async()` wrapper
    ///   function (for "short-circuit" results, such as when passing
    ///   0 to <see cref="InputStream.ReadAsync"/>).
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GTask", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(TaskClass))]
    public partial class Task : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IAsyncResult
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_task_get_type();

        /// <summary>
        /// Whether the task has completed, meaning its callback (if set) has been
        /// invoked. This can only happen after <see cref="Task.ReturnPointer"/>,
        /// <see cref="Task.ReturnError"/> or one of the other return functions have been called
        /// on the task.
        /// </summary>
        /// <remarks>
        /// This property is guaranteed to change from <c>false</c> to <c>true</c> exactly once.
        /// 
        /// The #GObject::notify signal for this change is emitted in the same main
        /// context as the task’s callback, immediately after that callback is invoked.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [GISharp.Runtime.GPropertyAttribute("completed")]
        public System.Boolean Completed_ { get => (System.Boolean)GetProperty("completed"); }

        /// <summary>
        /// Gets <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.Gio.Cancellable Cancellable { get => GetCancellable(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s check-cancellable flag. See
        /// <see cref="Task.SetCheckCancellable"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean CheckCancellable { get => GetCheckCancellable(); set => SetCheckCancellable(value); }

        /// <summary>
        /// Gets the value of <see cref="Task"/>:completed. This changes from <c>false</c> to <c>true</c> after
        /// the task’s callback is invoked, and will return <c>false</c> if called from inside
        /// the callback.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public System.Boolean Completed { get => GetCompleted(); }

        /// <summary>
        /// Gets the #GMainContext that <paramref name="task"/> will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when <paramref name="task"/> was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-<c>null</c> value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.GLib.MainContext Context { get => GetContext(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s priority
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Int32 Priority { get => GetPriority(); set => SetPriority(value); }

        /// <summary>
        /// Gets <paramref name="task"/>'s return-on-cancel flag. See
        /// <see cref="Task.SetReturnOnCancel"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean ReturnOnCancel { get => GetReturnOnCancel(); }

        /// <summary>
        /// Gets the source object from <paramref name="task"/>. Like
        /// <see cref="IAsyncResult.GetSourceObject"/>, but does not ref the object.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.GObject.Object SourceObject { get => GetSourceObject(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s source tag. See <see cref="Task.SetSourceTag"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.IntPtr SourceTag { get => GetSourceTag(); set => SetSourceTag(value); }

        /// <summary>
        /// Gets <paramref name="task"/>'s `task_data`.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.IntPtr TaskData { get => GetTaskData(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Task(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a #GTask acting on @source_object, which will eventually be
        /// used to invoke @callback in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the #GTask around throughout the asynchronous operation. You
        /// can use g_task_set_task_data() to attach task-specific data to the
        /// object, which you can retrieve later via g_task_get_task_data().
        /// 
        /// By default, if @cancellable is cancelled, then the return value of
        /// the task will always be %G_IO_ERROR_CANCELLED, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// g_task_set_check_cancellable() to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or %NULL.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback.
        /// </param>
        /// <param name="callbackData">
        /// user data passed to @callback.
        /// </param>
        /// <returns>
        /// a #GTask.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_task_new(
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr callbackData);

        /// <summary>
        /// Creates a <see cref="Task"/> acting on <paramref name="sourceObject"/>, which will eventually be
        /// used to invoke <paramref name="callback"/> in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the <see cref="Task"/> around throughout the asynchronous operation. You
        /// can use <see cref="Task.SetTaskData"/> to attach task-specific data to the
        /// object, which you can retrieve later via <see cref="Task.GetTaskData"/>.
        /// 
        /// By default, if <paramref name="cancellable"/> is cancelled, then the return value of
        /// the task will always be <see cref="IOErrorEnum.Cancelled"/>, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// <see cref="Task.SetCheckCancellable"/> to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a <see cref="Task"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        static unsafe System.IntPtr New(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var (callback_, _, callbackData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_task_new(sourceObject_,cancellable_,callback_,callbackData_);
            return ret_;
        }

        /// <summary>
        /// Creates a <see cref="Task"/> acting on <paramref name="sourceObject"/>, which will eventually be
        /// used to invoke <paramref name="callback"/> in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the <see cref="Task"/> around throughout the asynchronous operation. You
        /// can use <see cref="Task.SetTaskData"/> to attach task-specific data to the
        /// object, which you can retrieve later via <see cref="Task.GetTaskData"/>.
        /// 
        /// By default, if <paramref name="cancellable"/> is cancelled, then the return value of
        /// the task will always be <see cref="IOErrorEnum.Cancelled"/>, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// <see cref="Task.SetCheckCancellable"/> to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public Task(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null) : this(New(sourceObject, callback, cancellable), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Checks that @result is a #GTask, and that @source_object is its
        /// source object (or that @source_object is %NULL and @result has no
        /// source object). This can be used in g_return_if_fail() checks.
        /// </summary>
        /// <param name="result">
        /// A #GAsyncResult
        /// </param>
        /// <param name="sourceObject">
        /// the source object
        ///   expected to be associated with the task
        /// </param>
        /// <returns>
        /// %TRUE if @result and @source_object are valid, %FALSE
        /// if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_is_valid(
        /* <type name="AsyncResult" type="gpointer" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject);

        /// <summary>
        /// Checks that <paramref name="result"/> is a <see cref="Task"/>, and that <paramref name="sourceObject"/> is its
        /// source object (or that <paramref name="sourceObject"/> is <c>null</c> and <paramref name="result"/> has no
        /// source object). This can be used in g_return_if_fail() checks.
        /// </summary>
        /// <param name="result">
        /// A <see cref="IAsyncResult"/>
        /// </param>
        /// <param name="sourceObject">
        /// the source object
        ///   expected to be associated with the task
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="result"/> and <paramref name="sourceObject"/> are valid, <c>false</c>
        /// if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public static unsafe System.Boolean IsValid(GISharp.Lib.Gio.IAsyncResult result, GISharp.Lib.GObject.Object sourceObject)
        {
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_task_is_valid(result_,sourceObject_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a #GTask and then immediately calls g_task_return_error()
        /// on it. Use this in the wrapper function of an asynchronous method
        /// when you want to avoid even calling the virtual method. You can
        /// then use g_async_result_is_tagged() in the finish method wrapper to
        /// check if the result there is tagged as having been created by the
        /// wrapper method, and deal with it appropriately if so.
        /// </summary>
        /// <remarks>
        /// See also g_task_report_new_error().
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or %NULL.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback.
        /// </param>
        /// <param name="callbackData">
        /// user data passed to @callback.
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        /// <param name="error">
        /// error to report
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_report_error(
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:2 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr callbackData,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag,
        /* <type name="GLib.Error" type="GError*" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr error);

        /// <summary>
        /// Creates a <see cref="Task"/> and then immediately calls <see cref="Task.ReturnError"/>
        /// on it. Use this in the wrapper function of an asynchronous method
        /// when you want to avoid even calling the virtual method. You can
        /// then use <see cref="IAsyncResult.IsTagged"/> in the finish method wrapper to
        /// check if the result there is tagged as having been created by the
        /// wrapper method, and deal with it appropriately if so.
        /// </summary>
        /// <remarks>
        /// See also g_task_report_new_error().
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        /// <param name="error">
        /// error to report
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public static unsafe void ReportError(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, System.IntPtr sourceTag, GISharp.Lib.GLib.Error error)
        {
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var (callback_, _, callbackData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var sourceTag_ = (System.IntPtr)sourceTag;
            var error_ = error?.Take() ?? throw new System.ArgumentNullException(nameof(error));
            g_task_report_error(sourceObject_, callback_, callbackData_, sourceTag_, error_);
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_task_get_type();

        /// <summary>
        /// Gets @task's #GCancellable
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's #GCancellable
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_task_get_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe GISharp.Lib.Gio.Cancellable GetCancellable()
        {
            var task_ = Handle;
            var ret_ = g_task_get_cancellable(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's check-cancellable flag. See
        /// g_task_set_check_cancellable() for more details.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_get_check_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s check-cancellable flag. See
        /// <see cref="Task.SetCheckCancellable"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe System.Boolean GetCheckCancellable()
        {
            var task_ = Handle;
            var ret_ = g_task_get_check_cancellable(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of #GTask:completed. This changes from %FALSE to %TRUE after
        /// the task’s callback is invoked, and will return %FALSE if called from inside
        /// the callback.
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <returns>
        /// %TRUE if the task has completed, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_get_completed(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the value of <see cref="Task"/>:completed. This changes from <c>false</c> to <c>true</c> after
        /// the task’s callback is invoked, and will return <c>false</c> if called from inside
        /// the callback.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the task has completed, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private unsafe System.Boolean GetCompleted()
        {
            var task_ = Handle;
            var ret_ = g_task_get_completed(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the #GMainContext that @task will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when @task was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-%NULL value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's #GMainContext
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.MainContext" type="GMainContext*" managed-name="GISharp.Lib.GLib.MainContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_task_get_context(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the #GMainContext that <paramref name="task"/> will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when <paramref name="task"/> was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-<c>null</c> value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        /// <returns>
        /// <paramref name="task"/>'s #GMainContext
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe GISharp.Lib.GLib.MainContext GetContext()
        {
            var task_ = Handle;
            var ret_ = g_task_get_context(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.MainContext>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's priority
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's priority
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_task_get_priority(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s priority
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s priority
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe System.Int32 GetPriority()
        {
            var task_ = Handle;
            var ret_ = g_task_get_priority(task_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets @task's return-on-cancel flag. See
        /// g_task_set_return_on_cancel() for more details.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_get_return_on_cancel(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s return-on-cancel flag. See
        /// <see cref="Task.SetReturnOnCancel"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe System.Boolean GetReturnOnCancel()
        {
            var task_ = Handle;
            var ret_ = g_task_get_return_on_cancel(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the source object from @task. Like
        /// g_async_result_get_source_object(), but does not ref the object.
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's source object, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern unsafe System.IntPtr g_task_get_source_object(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the source object from <paramref name="task"/>. Like
        /// <see cref="IAsyncResult.GetSourceObject"/>, but does not ref the object.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s source object, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe GISharp.Lib.GObject.Object GetSourceObject()
        {
            var task_ = Handle;
            var ret_ = g_task_get_source_object(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's source tag. See g_task_set_source_tag().
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's source tag
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern unsafe System.IntPtr g_task_get_source_tag(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s source tag. See <see cref="Task.SetSourceTag"/>.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s source tag
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe System.IntPtr GetSourceTag()
        {
            var task_ = Handle;
            var ret_ = g_task_get_source_tag(task_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Gets @task's `task_data`.
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's `task_data`.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern unsafe System.IntPtr g_task_get_task_data(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s `task_data`.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s `task_data`.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe System.IntPtr GetTaskData()
        {
            var task_ = Handle;
            var ret_ = g_task_get_task_data(task_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Tests if @task resulted in an error.
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <returns>
        /// %TRUE if the task resulted in an error, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_had_error(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Tests if <paramref name="task"/> resulted in an error.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the task resulted in an error, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe System.Boolean HadError()
        {
            var task_ = Handle;
            var ret_ = g_task_had_error(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the result of @task as a #gboolean.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return %FALSE and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or %FALSE on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_task_propagate_boolean(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as a #gboolean.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return <c>false</c> and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe void PropagateBoolean()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            g_task_propagate_boolean(task_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Gets the result of @task as an integer (#gssize).
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return -1 and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or -1 on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_task_propagate_int(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as an integer (#gssize).
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return -1 and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <returns>
        /// the task result, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe System.Int32 PropagateInt()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_task_propagate_int(task_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the result of @task as a pointer, and transfers ownership
        /// of that value to the caller.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return %NULL and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_task_propagate_pointer(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as a pointer, and transfers ownership
        /// of that value to the caller.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return <c>null</c> and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <returns>
        /// the task result, or <c>null</c> on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe System.IntPtr PropagatePointer()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_task_propagate_pointer(task_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="result">
        /// the #gboolean result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_return_boolean(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean result);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="result"/> and completes the task (see
        /// <see cref="Task.ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="result">
        /// the #gboolean result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe void ReturnBoolean(System.Boolean result)
        {
            var task_ = Handle;
            var result_ = (System.Boolean)result;
            g_task_return_boolean(task_, result_);
        }

        /// <summary>
        /// Sets @task's result to @error (which @task assumes ownership of)
        /// and completes the task (see g_task_return_pointer() for more
        /// discussion of exactly what this means).
        /// </summary>
        /// <remarks>
        /// Note that since the task takes ownership of @error, and since the
        /// task may be completed before returning from g_task_return_error(),
        /// you cannot assume that @error is still valid after calling this.
        /// Call g_error_copy() on the error if you need to keep a local copy
        /// as well.
        /// 
        /// See also g_task_return_new_error().
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// the #GError result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_return_error(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError*" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr error);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="error"/> (which <paramref name="task"/> assumes ownership of)
        /// and completes the task (see <see cref="Task.ReturnPointer"/> for more
        /// discussion of exactly what this means).
        /// </summary>
        /// <remarks>
        /// Note that since the task takes ownership of <paramref name="error"/>, and since the
        /// task may be completed before returning from <see cref="Task.ReturnError"/>,
        /// you cannot assume that <paramref name="error"/> is still valid after calling this.
        /// Call g_error_copy() on the error if you need to keep a local copy
        /// as well.
        /// 
        /// See also g_task_return_new_error().
        /// </remarks>
        /// <param name="error">
        /// the #GError result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe void ReturnError(GISharp.Lib.GLib.Error error)
        {
            var task_ = Handle;
            var error_ = error?.Take() ?? throw new System.ArgumentNullException(nameof(error));
            g_task_return_error(task_, error_);
        }

        /// <summary>
        /// Checks if @task's #GCancellable has been cancelled, and if so, sets
        /// @task's error accordingly and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// %TRUE if @task has been cancelled, %FALSE if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_return_error_if_cancelled(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Checks if <paramref name="task"/>'s <see cref="Cancellable"/> has been cancelled, and if so, sets
        /// <paramref name="task"/>'s error accordingly and completes the task (see
        /// <see cref="Task.ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="task"/> has been cancelled, <c>false</c> if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe System.Boolean ReturnErrorIfCancelled()
        {
            var task_ = Handle;
            var ret_ = g_task_return_error_if_cancelled(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="result">
        /// the integer (#gssize) result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_return_int(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="result"/> and completes the task (see
        /// <see cref="Task.ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="result">
        /// the integer (#gssize) result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe void ReturnInt(System.Int32 result)
        {
            var task_ = Handle;
            var result_ = (System.IntPtr)result;
            g_task_return_int(task_, result_);
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task. If @result
        /// is not %NULL, then @result_destroy will be used to free @result if
        /// the caller does not take ownership of it with
        /// g_task_propagate_pointer().
        /// </summary>
        /// <remarks>
        /// "Completes the task" means that for an ordinary asynchronous task
        /// it will either invoke the task's callback, or else queue that
        /// callback to be invoked in the proper #GMainContext, or in the next
        /// iteration of the current #GMainContext. For a task run via
        /// g_task_run_in_thread() or g_task_run_in_thread_sync(), calling this
        /// method will save @result to be returned to the caller later, but
        /// the task will not actually be completed until the #GTaskThreadFunc
        /// exits.
        /// 
        /// Note that since the task may be completed before returning from
        /// g_task_return_pointer(), you cannot assume that @result is still
        /// valid after calling this, unless you are still holding another
        /// reference on it.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <param name="result">
        /// the pointer result of a task
        ///     function
        /// </param>
        /// <param name="resultDestroy">
        /// a #GDestroyNotify function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_return_pointer(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 allow-none:1 direction:in */
        System.IntPtr result,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GISharp.Lib.GLib.UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify resultDestroy);

        /// <summary>
        /// Sets or clears @task's check-cancellable flag. If this is %TRUE
        /// (the default), then g_task_propagate_pointer(), etc, and
        /// g_task_had_error() will check the task's #GCancellable first, and
        /// if it has been cancelled, then they will consider the task to have
        /// returned an "Operation was cancelled" error
        /// (%G_IO_ERROR_CANCELLED), regardless of any other error or return
        /// value the task may have had.
        /// </summary>
        /// <remarks>
        /// If @check_cancellable is %FALSE, then the #GTask will not check the
        /// cancellable itself, and it is up to @task's owner to do this (eg,
        /// via g_task_return_error_if_cancelled()).
        /// 
        /// If you are using g_task_set_return_on_cancel() as well, then
        /// you must leave check-cancellable set %TRUE.
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="checkCancellable">
        /// whether #GTask will check the state of
        ///   its #GCancellable for you.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_set_check_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean checkCancellable);

        /// <summary>
        /// Sets or clears <paramref name="task"/>'s check-cancellable flag. If this is <c>true</c>
        /// (the default), then <see cref="Task.PropagatePointer"/>, etc, and
        /// <see cref="Task.HadError"/> will check the task's <see cref="Cancellable"/> first, and
        /// if it has been cancelled, then they will consider the task to have
        /// returned an "Operation was cancelled" error
        /// (<see cref="IOErrorEnum.Cancelled"/>), regardless of any other error or return
        /// value the task may have had.
        /// </summary>
        /// <remarks>
        /// If <paramref name="checkCancellable"/> is <c>false</c>, then the <see cref="Task"/> will not check the
        /// cancellable itself, and it is up to <paramref name="task"/>'s owner to do this (eg,
        /// via <see cref="Task.ReturnErrorIfCancelled"/>).
        /// 
        /// If you are using <see cref="Task.SetReturnOnCancel"/> as well, then
        /// you must leave check-cancellable set <c>true</c>.
        /// </remarks>
        /// <param name="checkCancellable">
        /// whether <see cref="Task"/> will check the state of
        ///   its <see cref="Cancellable"/> for you.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe void SetCheckCancellable(System.Boolean checkCancellable)
        {
            var task_ = Handle;
            var checkCancellable_ = (System.Boolean)checkCancellable;
            g_task_set_check_cancellable(task_, checkCancellable_);
        }

        /// <summary>
        /// Sets @task's priority. If you do not call this, it will default to
        /// %G_PRIORITY_DEFAULT.
        /// </summary>
        /// <remarks>
        /// This will affect the priority of #GSources created with
        /// g_task_attach_source() and the scheduling of tasks run in threads,
        /// and can also be explicitly retrieved later via
        /// g_task_get_priority().
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="priority">
        /// the [priority][io-priority] of the request
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_set_priority(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 priority);

        /// <summary>
        /// Sets <paramref name="task"/>'s priority. If you do not call this, it will default to
        /// %G_PRIORITY_DEFAULT.
        /// </summary>
        /// <remarks>
        /// This will affect the priority of #GSources created with
        /// g_task_attach_source() and the scheduling of tasks run in threads,
        /// and can also be explicitly retrieved later via
        /// <see cref="Task.GetPriority"/>.
        /// </remarks>
        /// <param name="priority">
        /// the [priority][io-priority] of the request
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe void SetPriority(System.Int32 priority)
        {
            var task_ = Handle;
            var priority_ = (System.Int32)priority;
            g_task_set_priority(task_, priority_);
        }

        /// <summary>
        /// Sets or clears @task's return-on-cancel flag. This is only
        /// meaningful for tasks run via g_task_run_in_thread() or
        /// g_task_run_in_thread_sync().
        /// </summary>
        /// <remarks>
        /// If @return_on_cancel is %TRUE, then cancelling @task's
        /// #GCancellable will immediately cause it to return, as though the
        /// task's #GTaskThreadFunc had called
        /// g_task_return_error_if_cancelled() and then returned.
        /// 
        /// This allows you to create a cancellable wrapper around an
        /// uninterruptable function. The #GTaskThreadFunc just needs to be
        /// careful that it does not modify any externally-visible state after
        /// it has been cancelled. To do that, the thread should call
        /// g_task_set_return_on_cancel() again to (atomically) set
        /// return-on-cancel %FALSE before making externally-visible changes;
        /// if the task gets cancelled before the return-on-cancel flag could
        /// be changed, g_task_set_return_on_cancel() will indicate this by
        /// returning %FALSE.
        /// 
        /// You can disable and re-enable this flag multiple times if you wish.
        /// If the task's #GCancellable is cancelled while return-on-cancel is
        /// %FALSE, then calling g_task_set_return_on_cancel() to set it %TRUE
        /// again will cause the task to be cancelled at that point.
        /// 
        /// If the task's #GCancellable is already cancelled before you call
        /// g_task_run_in_thread()/g_task_run_in_thread_sync(), then the
        /// #GTaskThreadFunc will still be run (for consistency), but the task
        /// will also be completed right away.
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="returnOnCancel">
        /// whether the task returns automatically when
        ///   it is cancelled.
        /// </param>
        /// <returns>
        /// %TRUE if @task's return-on-cancel flag was changed to
        ///   match @return_on_cancel. %FALSE if @task has already been
        ///   cancelled.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_task_set_return_on_cancel(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean returnOnCancel);

        /// <summary>
        /// Sets or clears <paramref name="task"/>'s return-on-cancel flag. This is only
        /// meaningful for tasks run via g_task_run_in_thread() or
        /// g_task_run_in_thread_sync().
        /// </summary>
        /// <remarks>
        /// If <paramref name="returnOnCancel"/> is <c>true</c>, then cancelling <paramref name="task"/>'s
        /// <see cref="Cancellable"/> will immediately cause it to return, as though the
        /// task's <see cref="TaskThreadFunc"/> had called
        /// <see cref="Task.ReturnErrorIfCancelled"/> and then returned.
        /// 
        /// This allows you to create a cancellable wrapper around an
        /// uninterruptable function. The <see cref="TaskThreadFunc"/> just needs to be
        /// careful that it does not modify any externally-visible state after
        /// it has been cancelled. To do that, the thread should call
        /// <see cref="Task.SetReturnOnCancel"/> again to (atomically) set
        /// return-on-cancel <c>false</c> before making externally-visible changes;
        /// if the task gets cancelled before the return-on-cancel flag could
        /// be changed, <see cref="Task.SetReturnOnCancel"/> will indicate this by
        /// returning <c>false</c>.
        /// 
        /// You can disable and re-enable this flag multiple times if you wish.
        /// If the task's <see cref="Cancellable"/> is cancelled while return-on-cancel is
        /// <c>false</c>, then calling <see cref="Task.SetReturnOnCancel"/> to set it <c>true</c>
        /// again will cause the task to be cancelled at that point.
        /// 
        /// If the task's <see cref="Cancellable"/> is already cancelled before you call
        /// g_task_run_in_thread()/g_task_run_in_thread_sync(), then the
        /// <see cref="TaskThreadFunc"/> will still be run (for consistency), but the task
        /// will also be completed right away.
        /// </remarks>
        /// <param name="returnOnCancel">
        /// whether the task returns automatically when
        ///   it is cancelled.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="task"/>'s return-on-cancel flag was changed to
        ///   match <paramref name="returnOnCancel"/>. <c>false</c> if <paramref name="task"/> has already been
        ///   cancelled.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe System.Boolean SetReturnOnCancel(System.Boolean returnOnCancel)
        {
            var task_ = Handle;
            var returnOnCancel_ = (System.Boolean)returnOnCancel;
            var ret_ = g_task_set_return_on_cancel(task_,returnOnCancel_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's source tag. You can use this to tag a task return
        /// value with a particular pointer (usually a pointer to the function
        /// doing the tagging) and then later check it using
        /// g_task_get_source_tag() (or g_async_result_is_tagged()) in the
        /// task's "finish" function, to figure out if the response came from a
        /// particular place.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_set_source_tag(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);

        /// <summary>
        /// Sets <paramref name="task"/>'s source tag. You can use this to tag a task return
        /// value with a particular pointer (usually a pointer to the function
        /// doing the tagging) and then later check it using
        /// <see cref="Task.GetSourceTag"/> (or <see cref="IAsyncResult.IsTagged"/>) in the
        /// task's "finish" function, to figure out if the response came from a
        /// particular place.
        /// </summary>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe void SetSourceTag(System.IntPtr sourceTag)
        {
            var task_ = Handle;
            var sourceTag_ = (System.IntPtr)sourceTag;
            g_task_set_source_tag(task_, sourceTag_);
        }

        /// <summary>
        /// Sets @task's task data (freeing the existing task data, if any).
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="taskData">
        /// task-specific data
        /// </param>
        /// <param name="taskDataDestroy">
        /// #GDestroyNotify for @task_data
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_task_set_task_data(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr taskData,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GISharp.Lib.GLib.UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify taskDataDestroy);

        GISharp.Lib.GObject.Object GISharp.Lib.Gio.IAsyncResult.DoGetSourceObject()
        {
            throw new System.NotImplementedException();
        }

        System.IntPtr GISharp.Lib.Gio.IAsyncResult.DoGetUserData()
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.IAsyncResult.DoIsTagged(System.IntPtr sourceTag)
        {
            throw new System.NotImplementedException();
        }
    }
}