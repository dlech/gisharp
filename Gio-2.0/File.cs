using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using GISharp.Runtime;

using Tasks = System.Threading.Tasks;

namespace GISharp.Lib.Gio
{
    partial class File
    {
        /// <summary>
        /// Copies the file <paramref name="source"/> to the location specified by <paramref name="destination"/>
        /// asynchronously. For details of the behaviour, see <see cref="File.Copy"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="progressCallback"/> is not <c>null</c>, then that function that will be called
        /// just like in <see cref="File.Copy"/>. The callback will run in the default main context
        /// of the thread calling <see cref="File.CopyAsync"/> — the same context as <paramref name="callback"/> is
        /// run in.
        /// 
        /// When the operation is finished, <paramref name="callback"/> will be called. You can then call
        /// <see cref="File.CopyFinish"/> to get the result of the operation.
        /// </remarks>
        /// <param name="source">
        /// input <see cref="IFile"/>
        /// </param>
        /// <param name="destination">
        /// destination <see cref="IFile"/>
        /// </param>
        /// <param name="flags">
        /// set of <see cref="FileCopyFlags"/>
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object,
        ///     <c>null</c> to ignore
        /// </param>
        public unsafe static Tasks.Task CopyAsync(this IFile source, IFile destination, FileCopyFlags flags, int ioPriority = Priority.Default,
            Cancellable? cancellable = null, FileProgressCallback? progressCallback = null)
        {
            var source_ = source.Handle;
            var destination_ = destination.Handle;
            var flags_ = flags;
            var ioPriority_ = ioPriority;
            var cancellable_ = cancellable?.Handle ?? IntPtr.Zero;
            var (progressCallback_, progressCallbackDestroy_, progressCallbackData_) = progressCallback == null ?
                default : FileProgressCallbackFactory.Create(progressCallback, CallbackScope.Notified);
            var progressCallbackDestroy = new System.Action(() => progressCallbackDestroy_(progressCallbackData_));
            var completionSource = new TaskCompletionSource<Unit>(progressCallbackDestroy);
            var callback_ = copyAsyncCallbackDelegate;
            var userData_ = (IntPtr)GCHandle.Alloc(completionSource);
            g_file_copy_async(source_, destination_, flags_, ioPriority_, cancellable_, progressCallback_, progressCallbackData_, callback_, userData_);
            return completionSource.Task;
        }

        static unsafe void CopyFinish(IntPtr file_, IntPtr res_, IntPtr userData_)
        {
            try {
                var userData = (GCHandle)userData_;
                var completionSource = (TaskCompletionSource<Unit>)userData.Target;
                userData.Free();
                var progressCallbackDestroy = (System.Action)completionSource.Task.AsyncState;
                progressCallbackDestroy();
                var error_ = IntPtr.Zero;
                g_file_copy_finish(file_, res_, &error_);
                if (error_ != IntPtr.Zero) {
                    var error = Opaque.GetInstance<Error>(error_, Transfer.Full);
                    completionSource.SetException(new GErrorException(error));
                    return;
                }
                completionSource.SetResult(Unit.Default);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static readonly UnmanagedAsyncReadyCallback copyAsyncCallbackDelegate = CopyFinish;
    }
}
