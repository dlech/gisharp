using GISharp.Lib.GObject;
using GISharp.Runtime;

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
    [Since("2.36")]
    public delegate void TaskThreadFunc(Task task, Object? source, Cancellable? cancellable);
}