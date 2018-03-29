namespace GISharp.Lib.Gio
{
    /// <summary>
    /// The prototype for a task function to be run in a thread via
    /// g_task_run_in_thread() or g_task_run_in_thread_sync().
    /// </summary>
    /// <remarks>
    /// If the return-on-cancel flag is set on @task, and @cancellable gets
    /// cancelled, then the #GTask will be completed immediately (as though
    /// g_task_return_error_if_cancelled() had been called), without
    /// waiting for the task function to complete. However, the task
    /// function will continue running in its thread in the background. The
    /// function therefore needs to be careful about how it uses
    /// externally-visible state in this case. See
    /// g_task_set_return_on_cancel() for more details.
    /// 
    /// Other than in that case, @task will be completed when the
    /// #GTaskThreadFunc returns, not when it calls a
    /// `g_task_return_` function.
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.36")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate void UnmanagedTaskThreadFunc(
    /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr task,
    /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr sourceObject,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr taskData,
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr cancellable);
}