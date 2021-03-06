// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// When doing file operations that may take a while, such as moving
    /// a file or copying a file, a progress callback is used to pass how
    /// far along that operation is to the application.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedFileProgressCallback(
    /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
    /* transfer-ownership:none direction:in */
    long currentNumBytes,
    /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
    /* transfer-ownership:none direction:in */
    long totalNumBytes,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <include file="FileProgressCallback.xmldoc" path="declaration/member[@name='FileProgressCallback']/*" />
    public delegate void FileProgressCallback(long currentNumBytes, long totalNumBytes);

    /// <summary>
    /// Class for marshalling <see cref="FileProgressCallback"/> methods.
    /// </summary>
    public static unsafe class FileProgressCallbackMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="FileProgressCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.FileProgressCallback FromPointer(delegate* unmanaged[Cdecl]<long, long, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(long currentNumBytes, long totalNumBytes) { var currentNumBytes_ = (long)currentNumBytes; var totalNumBytes_ = (long)totalNumBytes; callback_(currentNumBytes_, totalNumBytes_, userData_); }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static void Callback(long currentNumBytes_, long totalNumBytes_, System.IntPtr userData_)
        {
            try
            {
                var currentNumBytes = (long)currentNumBytes_;
                var totalNumBytes = (long)totalNumBytes_;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((FileProgressCallback, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                userData.Invoke(currentNumBytes, totalNumBytes);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }
}