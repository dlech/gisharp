namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Provides a base class for implementing asynchronous function results.
    /// </summary>
    /// <remarks>
    /// Asynchronous operations are broken up into two separate operations
    /// which are chained together by a <see cref="AsyncReadyCallback"/>. To begin
    /// an asynchronous operation, provide a <see cref="AsyncReadyCallback"/> to the
    /// asynchronous function. This callback will be triggered when the
    /// operation has completed, and must be run in a later iteration of
    /// the [thread-default main context][g-main-context-push-thread-default]
    /// from where the operation was initiated. It will be passed a
    /// <see cref="IAsyncResult"/> instance filled with the details of the operation's
    /// success or failure, the object the asynchronous function was
    /// started for and any error codes returned. The asynchronous callback
    /// function is then expected to call the corresponding "_finish()"
    /// function, passing the object the function was called for, the
    /// <see cref="IAsyncResult"/> instance, and (optionally) an <paramref name="error"/> to grab any
    /// error conditions that may have occurred.
    /// 
    /// The "_finish()" function for an operation takes the generic result
    /// (of type <see cref="IAsyncResult"/>) and returns the specific result that the
    /// operation in question yields (e.g. a #GFileEnumerator for a
    /// "enumerate children" operation). If the result or error status of the
    /// operation is not needed, there is no need to call the "_finish()"
    /// function; GIO will take care of cleaning up the result and error
    /// information after the <see cref="AsyncReadyCallback"/> returns. You can pass
    /// <c>null</c> for the <see cref="AsyncReadyCallback"/> if you don't need to take any
    /// action at all after the operation completes. Applications may also
    /// take a reference to the <see cref="IAsyncResult"/> and call "_finish()" later;
    /// however, the "_finish()" function may be called at most once.
    /// 
    /// Example of a typical asynchronous operation flow:
    /// |[&lt;!-- language="C" --&gt;
    /// void _theoretical_frobnitz_async (Theoretical         *t,
    ///                                   GCancellable        *c,
    ///                                   GAsyncReadyCallback  cb,
    ///                                   gpointer             u);
    /// 
    /// gboolean _theoretical_frobnitz_finish (Theoretical   *t,
    ///                                        GAsyncResult  *res,
    ///                                        GError       **e);
    /// 
    /// static void
    /// frobnitz_result_func (GObject      *source_object,
    /// 		 GAsyncResult *res,
    /// 		 gpointer      user_data)
    /// {
    ///   gboolean success = FALSE;
    /// 
    ///   success = _theoretical_frobnitz_finish (source_object, res, NULL);
    /// 
    ///   if (success)
    ///     g_printf ("Hurray!\n");
    ///   else
    ///     g_printf ("Uh oh!\n");
    /// 
    ///   ...
    /// 
    /// }
    /// 
    /// int main (int argc, void *argv[])
    /// {
    ///    ...
    /// 
    ///    _theoretical_frobnitz_async (theoretical_data,
    ///                                 NULL,
    ///                                 frobnitz_result_func,
    ///                                 NULL);
    /// 
    ///    ...
    /// }
    /// ]|
    /// 
    /// The callback for an asynchronous operation is called only once, and is
    /// always called, even in the case of a cancelled operation. On cancellation
    /// the result is a <see cref="IOErrorEnum.Cancelled"/> error.
    /// 
    /// ## I/O Priority # {#io-priority}
    /// 
    /// Many I/O-related asynchronous operations have a priority parameter,
    /// which is used in certain cases to determine the order in which
    /// operations are executed. They are not used to determine system-wide
    /// I/O scheduling. Priorities are integers, with lower numbers indicating
    /// higher priority. It is recommended to choose priorities between
    /// %G_PRIORITY_LOW and %G_PRIORITY_HIGH, with %G_PRIORITY_DEFAULT
    /// as a default.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GAsyncResult", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(AsyncResultIface))]
    public partial interface IAsyncResult : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Gets the source object from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <returns>
        /// a new reference to the source
        ///    object for the <paramref name="res"/>, or <c>null</c> if there is none.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetSourceObject))]
        GISharp.Lib.GObject.Object DoGetSourceObject();

        /// <summary>
        /// Gets the user data from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <returns>
        /// the user data for <paramref name="res"/>.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetUserData))]
        System.IntPtr DoGetUserData();

        /// <summary>
        /// Checks if <paramref name="res"/> has the given <paramref name="sourceTag"/> (generally a function
        /// pointer indicating the function <paramref name="res"/> was created by).
        /// </summary>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="res"/> has the indicated <paramref name="sourceTag"/>, <c>false</c> if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedIsTagged))]
        System.Boolean DoIsTagged(System.IntPtr sourceTag);
    }

    public static class AsyncResult
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_async_result_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_async_result_get_type();

        /// <summary>
        /// Gets the source object from a #GAsyncResult.
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult
        /// </param>
        /// <returns>
        /// a new reference to the source
        ///    object for the @res, or %NULL if there is none.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_async_result_get_source_object(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

        /// <summary>
        /// Gets the source object from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>
        /// </param>
        /// <returns>
        /// a new reference to the source
        ///    object for the <paramref name="res"/>, or <c>null</c> if there is none.
        /// </returns>
        public unsafe static GISharp.Lib.GObject.Object GetSourceObject(this GISharp.Lib.Gio.IAsyncResult res)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var ret_ = g_async_result_get_source_object(res_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the user data from a #GAsyncResult.
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult.
        /// </param>
        /// <returns>
        /// the user data for @res.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_async_result_get_user_data(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

        /// <summary>
        /// Gets the user data from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// the user data for <paramref name="res"/>.
        /// </returns>
        public unsafe static System.IntPtr GetUserData(this GISharp.Lib.Gio.IAsyncResult res)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var ret_ = g_async_result_get_user_data(res_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if @res has the given @source_tag (generally a function
        /// pointer indicating the function @res was created by).
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult
        /// </param>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// %TRUE if @res has the indicated @source_tag, %FALSE if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_async_result_is_tagged(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);

        /// <summary>
        /// Checks if <paramref name="res"/> has the given <paramref name="sourceTag"/> (generally a function
        /// pointer indicating the function <paramref name="res"/> was created by).
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>
        /// </param>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="res"/> has the indicated <paramref name="sourceTag"/>, <c>false</c> if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public unsafe static System.Boolean IsTagged(this GISharp.Lib.Gio.IAsyncResult res, System.IntPtr sourceTag)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var sourceTag_ = (System.IntPtr)sourceTag;
            var ret_ = g_async_result_is_tagged(res_,sourceTag_);
            var ret = (System.Boolean)ret_;
            return ret;
        }
    }
}