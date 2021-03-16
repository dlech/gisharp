// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="CClosure.xmldoc" path="declaration/member[@name='CClosure']/*" />
    public sealed unsafe partial class CClosure : GISharp.Lib.GObject.Closure
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="CClosure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Closure']/*" />
            public readonly GISharp.Lib.GObject.Closure.UnmanagedStruct Closure;

            /// <include file="CClosure.xmldoc" path="declaration/member[@name='UnmanagedStruct.Callback']/*" />
            public readonly System.IntPtr Callback;
#pragma warning restore CS0169, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CClosure(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new closure which invokes @callback_func with @user_data as
        /// the last parameter.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @destroy_data will be called as a finalize notifier on the #GClosure.
        /// </para>
        /// </remarks>
        /// <param name="callbackFunc">
        /// the function to invoke
        /// </param>
        /// <param name="userData">
        /// user data to pass to @callback_func
        /// </param>
        /// <param name="destroyData">
        /// destroy notify to be called when @user_data is no longer used
        /// </param>
        /// <returns>
        /// a floating reference to a new #GCClosure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_cclosure_new(
        /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
        delegate* unmanaged[Cdecl]<void> callbackFunc,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:0 direction:in */
        System.IntPtr userData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> destroyData);

        /// <summary>
        /// A variant of g_cclosure_new() which uses @object as @user_data and
        /// calls g_object_watch_closure() on @object and the created
        /// closure. This function is useful when you have a callback closely
        /// associated with a #GObject, and want the callback to no longer run
        /// after the object is is freed.
        /// </summary>
        /// <param name="callbackFunc">
        /// the function to invoke
        /// </param>
        /// <param name="object">
        /// a #GObject pointer to pass to @callback_func
        /// </param>
        /// <returns>
        /// a new #GCClosure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_cclosure_new_object(
        /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<void> callbackFunc,
        /* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* @object);

        /// <summary>
        /// A variant of g_cclosure_new_swap() which uses @object as @user_data
        /// and calls g_object_watch_closure() on @object and the created
        /// closure. This function is useful when you have a callback closely
        /// associated with a #GObject, and want the callback to no longer run
        /// after the object is is freed.
        /// </summary>
        /// <param name="callbackFunc">
        /// the function to invoke
        /// </param>
        /// <param name="object">
        /// a #GObject pointer to pass to @callback_func
        /// </param>
        /// <returns>
        /// a new #GCClosure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_cclosure_new_object_swap(
        /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<void> callbackFunc,
        /* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* @object);

        /// <summary>
        /// Creates a new closure which invokes @callback_func with @user_data as
        /// the first parameter.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @destroy_data will be called as a finalize notifier on the #GClosure.
        /// </para>
        /// </remarks>
        /// <param name="callbackFunc">
        /// the function to invoke
        /// </param>
        /// <param name="userData">
        /// user data to pass to @callback_func
        /// </param>
        /// <param name="destroyData">
        /// destroy notify to be called when @user_data is no longer used
        /// </param>
        /// <returns>
        /// a floating reference to a new #GCClosure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Closure" type="GClosure*" managed-name="Closure" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Closure.UnmanagedStruct* g_cclosure_new_swap(
        /* <type name="Callback" type="GCallback" managed-name="Callback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
        delegate* unmanaged[Cdecl]<void> callbackFunc,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:0 direction:in */
        System.IntPtr userData,
        /* <type name="ClosureNotify" type="GClosureNotify" managed-name="ClosureNotify" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.Closure.UnmanagedStruct*, void> destroyData);
    }
}