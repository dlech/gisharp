// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

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
        /// asynchronously. For details of the behaviour, see <see cref="Copy"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="progressCallback"/> is not <c>null</c>, then that function that will be called
        /// just like in <see cref="Copy"/>. The callback will run in the default main context
        /// of the thread calling <see cref="CopyAsync"/>.
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
        /// <param name="progressCallback">
        /// function to callback with progress information, or <c>null</c> if
        /// progress information is not needed.
        /// </param>
        public unsafe static Tasks.Task CopyAsync(this IFile source, IFile destination, FileCopyFlags flags, int ioPriority = Priority.Default,
            Cancellable? cancellable = null, FileProgressCallback? progressCallback = null)
        {
            var source_ = (UnmanagedStruct*)source.UnsafeHandle;
            var destination_ = (UnmanagedStruct*)destination.UnsafeHandle;
            var flags_ = flags;
            var ioPriority_ = ioPriority;
            var cancellable_ = (Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? IntPtr.Zero);
            var (progressCallback_, progressCallbackDestroy_, progressCallbackData_) = FileProgressCallbackMarshal.ToUnmanagedFunctionPointer(progressCallback, CallbackScope.Notified);

            // no parameter in g_file_copy_async() for destroy function, so we
            // attach it to the TaskCompletionSource
            var progressCallbackDestroy = default(System.Action);
            if (progressCallbackDestroy_ != IntPtr.Zero) {
                var destroy = Marshal.GetDelegateForFunctionPointer<UnmanagedDestroyNotify>(progressCallbackDestroy_);
                progressCallbackDestroy = () => destroy(progressCallbackData_);
            }

            var completionSource = new TaskCompletionSource<Runtime.Void>(progressCallbackDestroy);
            var callback_ = copyAsyncCallback_;
            var userData_ = (IntPtr)GCHandle.Alloc(completionSource);
            g_file_copy_async(source_, destination_, flags_, ioPriority_, cancellable_, progressCallback_, progressCallbackData_, callback_, userData_);
            return completionSource.Task;
        }

        static unsafe void CopyFinish(GObject.Object.UnmanagedStruct* sourceObject_, AsyncResult.UnmanagedStruct* res_, IntPtr userData_)
        {
            try {
                var file_ = (UnmanagedStruct*)sourceObject_;
                var userData = (GCHandle)userData_;
                var completionSource = (TaskCompletionSource<Runtime.Void>)userData.Target!;
                userData.Free();
                var progressCallbackDestroy = (System.Action)completionSource.Task.AsyncState!;
                progressCallbackDestroy?.Invoke();
                var error_ = default(Error.UnmanagedStruct*);
                g_file_copy_finish(file_, res_, &error_);
                if (error_ != null) {
                    var error = Opaque.GetInstance<Error>((IntPtr)error_, Transfer.Full);
                    completionSource.SetException(new GErrorException(error));
                    return;
                }
                completionSource.SetResult(Runtime.Void.Default);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static readonly unsafe UnmanagedAsyncReadyCallback copyAsyncCallbackDelegate = CopyFinish;
        static readonly unsafe IntPtr copyAsyncCallback_ = Marshal.GetFunctionPointerForDelegate(copyAsyncCallbackDelegate);
    }
}
