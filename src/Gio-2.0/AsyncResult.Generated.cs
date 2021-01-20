// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='IAsyncResult']/*" />
    [GISharp.Runtime.GTypeAttribute("GAsyncResult", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(AsyncResultIface))]
    public partial interface IAsyncResult : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_async_result_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_async_result_get_type();

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='IAsyncResult.DoGetSourceObject()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetSourceObject))]
        GISharp.Lib.GObject.Object? DoGetSourceObject();

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='IAsyncResult.DoGetUserData()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetUserData))]
        System.IntPtr DoGetUserData();

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='IAsyncResult.DoIsTagged(System.IntPtr)']/*" />
        [GISharp.Runtime.SinceAttribute("2.34")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedIsTagged))]
        System.Boolean DoIsTagged(System.IntPtr sourceTag);
    }

    /// <summary>
    /// Extension methods for <see cref="IAsyncResult"/>
    /// </summary>
    public static partial class AsyncResult
    {
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
        private static extern unsafe System.IntPtr g_async_result_get_source_object(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);
        static partial void CheckGetSourceObjectArgs(this GISharp.Lib.Gio.IAsyncResult res);

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='AsyncResult.GetSourceObject(GISharp.Lib.Gio.IAsyncResult)']/*" />
        public unsafe static GISharp.Lib.GObject.Object? GetSourceObject(this GISharp.Lib.Gio.IAsyncResult res)
        {
            CheckGetSourceObjectArgs(res);
            var res_ = res.Handle;
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
        private static extern unsafe System.IntPtr g_async_result_get_user_data(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);
        static partial void CheckGetUserDataArgs(this GISharp.Lib.Gio.IAsyncResult res);

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='AsyncResult.GetUserData(GISharp.Lib.Gio.IAsyncResult)']/*" />
        public unsafe static System.IntPtr GetUserData(this GISharp.Lib.Gio.IAsyncResult res)
        {
            CheckGetUserDataArgs(res);
            var res_ = res.Handle;
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
        private static extern unsafe GISharp.Runtime.Boolean g_async_result_is_tagged(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);
        static partial void CheckIsTaggedArgs(this GISharp.Lib.Gio.IAsyncResult res, System.IntPtr sourceTag);

        /// <include file="AsyncResult.xmldoc" path="declaration/member[@name='AsyncResult.IsTagged(GISharp.Lib.Gio.IAsyncResult,System.IntPtr)']/*" />
        [GISharp.Runtime.SinceAttribute("2.34")]
        public unsafe static System.Boolean IsTagged(this GISharp.Lib.Gio.IAsyncResult res, System.IntPtr sourceTag)
        {
            CheckIsTaggedArgs(res, sourceTag);
            var res_ = res.Handle;
            var sourceTag_ = (System.IntPtr)sourceTag;
            var ret_ = g_async_result_is_tagged(res_,sourceTag_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}