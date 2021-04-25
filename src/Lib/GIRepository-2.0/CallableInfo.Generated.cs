// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo']/*" />
    public abstract unsafe partial class CallableInfo : GISharp.Lib.GIRepository.BaseInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.CanThrowGError']/*" />
        [GISharp.Runtime.SinceAttribute("1.34")]
        public bool CanThrowGError { get => GetCanThrowGError(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.CallerOwns']/*" />
        public GISharp.Lib.GIRepository.Transfer CallerOwns { get => GetCallerOwns(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.InstanceOwnershipTransfer']/*" />
        [GISharp.Runtime.SinceAttribute("1.42")]
        public GISharp.Lib.GIRepository.Transfer InstanceOwnershipTransfer { get => GetInstanceOwnershipTransfer(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.NArgs']/*" />
        private int NArgs { get => GetNArgs(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.ReturnType']/*" />
        public GISharp.Lib.GIRepository.TypeInfo ReturnType { get => GetReturnType(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.IsMethod']/*" />
        [GISharp.Runtime.SinceAttribute("1.34")]
        public bool IsMethod { get => GetIsMethod(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.MayReturnNull']/*" />
        public bool MayReturnNull { get => GetMayReturnNull(); }

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.IsSkipReturn']/*" />
        public bool IsSkipReturn { get => GetIsSkipReturn(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CallableInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// %TRUE if this #GICallableInfo can throw a #GError
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.34")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_can_throw_gerror(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetCanThrowGErrorArgs();

        [GISharp.Runtime.SinceAttribute("1.34")]
        private bool GetCanThrowGError()
        {
            CheckGetCanThrowGErrorArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_can_throw_gerror(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain information about a particular argument of this callable.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <param name="n">
        /// the argument index to fetch
        /// </param>
        /// <returns>
        /// the #GIArgInfo. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ArgInfo" type="GIArgInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* g_callable_info_get_arg(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetArgArgs(int n);

        private GISharp.Lib.GIRepository.ArgInfo GetArg(int n)
        {
            CheckGetArgArgs(n);
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_callable_info_get_arg(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.ArgInfo.GetInstance<GISharp.Lib.GIRepository.ArgInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// See whether the caller owns the return value of this callable.
        /// #GITransfer contains a list of possible transfer values.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// the transfer mode for the return value of the callable
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Transfer" type="GITransfer" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.Transfer g_callable_info_get_caller_owns(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetCallerOwnsArgs();

        private GISharp.Lib.GIRepository.Transfer GetCallerOwns()
        {
            CheckGetCallerOwnsArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_get_caller_owns(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.Transfer)ret_;
            return ret;
        }

        /// <summary>
        /// Obtains the ownership transfer for the instance argument.
        /// #GITransfer contains a list of possible transfer values.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// the transfer mode of the instance argument
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.42")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Transfer" type="GITransfer" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.Transfer g_callable_info_get_instance_ownership_transfer(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetInstanceOwnershipTransferArgs();

        [GISharp.Runtime.SinceAttribute("1.42")]
        private GISharp.Lib.GIRepository.Transfer GetInstanceOwnershipTransfer()
        {
            CheckGetInstanceOwnershipTransferArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_get_instance_ownership_transfer(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.Transfer)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of arguments (both IN and OUT) for this callable.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// The number of arguments this callable expects.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_callable_info_get_n_args(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetNArgsArgs();

        private int GetNArgs()
        {
            CheckGetNArgsArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_get_n_args(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieve an arbitrary attribute associated with the return value.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <param name="name">
        /// a freeform string naming an attribute
        /// </param>
        /// <returns>
        /// The value of the attribute, or %NULL if no such attribute exists
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_callable_info_get_return_attribute(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name);
        partial void CheckGetReturnAttributeArgs(GISharp.Runtime.UnownedUtf8 name);

        /// <include file="CallableInfo.xmldoc" path="declaration/member[@name='CallableInfo.GetReturnAttribute(GISharp.Runtime.UnownedUtf8)']/*" />
        public GISharp.Runtime.UnownedUtf8 GetReturnAttribute(GISharp.Runtime.UnownedUtf8 name)
        {
            CheckGetReturnAttributeArgs(name);
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (byte*)name.UnsafeHandle;
            var ret_ = g_callable_info_get_return_attribute(info_,name_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain the return type of a callable item as a #GITypeInfo.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// the #GITypeInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_callable_info_get_return_type(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetReturnTypeArgs();

        private GISharp.Lib.GIRepository.TypeInfo GetReturnType()
        {
            CheckGetReturnTypeArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_get_return_type(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.TypeInfo.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="info">
        /// TODO
        /// </param>
        /// <param name="function">
        /// TODO
        /// </param>
        /// <param name="inArgs">
        /// TODO
        /// </param>
        /// <param name="nInArgs">
        /// TODO
        /// </param>
        /// <param name="outArgs">
        /// TODO
        /// </param>
        /// <param name="nOutArgs">
        /// TODO
        /// </param>
        /// <param name="returnValue">
        /// TODO
        /// </param>
        /// <param name="isMethod">
        /// TODO
        /// </param>
        /// <param name="throws">
        /// TODO
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_invoke(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr function,
        /* <array length="3" zero-terminated="0" type="const GIArgument*" is-pointer="1">
*   <type name="Argument" type="GIArgument" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.Argument* inArgs,
        /* <type name="gint" type="int" /> */
        /* transfer-ownership:none direction:in */
        int nInArgs,
        /* <array length="5" zero-terminated="0" type="const GIArgument*" is-pointer="1">
*   <type name="Argument" type="GIArgument" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.Argument* outArgs,
        /* <type name="gint" type="int" /> */
        /* transfer-ownership:none direction:in */
        int nOutArgs,
        /* <type name="Argument" type="GIArgument*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.Argument* returnValue,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean isMethod,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean throws,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Determines if the callable info is a method. For #GIVFuncInfo&lt;!-- --&gt;s,
        /// #GICallbackInfo&lt;!-- --&gt;s, and #GISignalInfo&lt;!-- --&gt;s,
        /// this is always true. Otherwise, this looks at the %GI_FUNCTION_IS_METHOD
        /// flag on the #GIFunctionInfo.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Concretely, this function returns whether g_callable_info_get_n_args()
        /// matches the number of arguments in the raw C method. For methods, there
        /// is one more C argument than is exposed by introspection: the "self"
        /// or "this" object.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// %TRUE if @info is a method, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.34")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_is_method(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetIsMethodArgs();

        [GISharp.Runtime.SinceAttribute("1.34")]
        private bool GetIsMethod()
        {
            CheckGetIsMethodArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_is_method(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Iterate over all attributes associated with the return value.  The
        /// iterator structure is typically stack allocated, and must have its
        /// first member initialized to %NULL.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Both the @name and @value should be treated as constants
        /// and must not be freed.
        /// </para>
        /// <para>
        /// See g_base_info_iterate_attributes() for an example of how to use a
        /// similar API.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <param name="iterator">
        /// a #GIAttributeIter structure, must be initialized; see below
        /// </param>
        /// <param name="name">
        /// Returned name, must not be freed
        /// </param>
        /// <param name="value">
        /// Returned name, must not be freed
        /// </param>
        /// <returns>
        /// %TRUE if there are more attributes
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_iterate_return_attributes(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="AttributeIter" type="GIAttributeIter*" /> */
        /* direction:inout caller-allocates:0 transfer-ownership:full */
        GISharp.Lib.GIRepository.AttributeIter* iterator,
        /* <type name="utf8" type="char**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:none */
        byte** name,
        /* <type name="utf8" type="char**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:none */
        byte** value);
        partial void CheckTryIterateReturnAttributesArgs(ref GISharp.Lib.GIRepository.AttributeIter iterator);

        private bool TryIterateReturnAttributes(ref GISharp.Lib.GIRepository.AttributeIter iterator, out GISharp.Runtime.UnownedUtf8 name, out GISharp.Runtime.UnownedUtf8 value)
        {
            fixed (GISharp.Lib.GIRepository.AttributeIter* iterator_ = &iterator)
            {
                CheckTryIterateReturnAttributesArgs(ref iterator);
                var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
                byte* name_;
                byte* value_;
                var ret_ = g_callable_info_iterate_return_attributes(info_,iterator_,&name_,&value_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                name = new GISharp.Runtime.UnownedUtf8(name_);
                value = new GISharp.Runtime.UnownedUtf8(value_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }

        /// <summary>
        /// Obtain information about a particular argument of this callable; this
        /// function is a variant of g_callable_info_get_arg() designed for stack
        /// allocation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The initialized @arg must not be referenced after @info is deallocated.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <param name="n">
        /// the argument index to fetch
        /// </param>
        /// <param name="arg">
        /// Initialize with argument number @n
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_callable_info_load_arg(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n,
        /* <type name="ArgInfo" type="GIArgInfo*" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* arg);

        /// <summary>
        /// Obtain information about a return value of callable; this
        /// function is a variant of g_callable_info_get_return_type() designed for stack
        /// allocation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The initialized @type must not be referenced after @info is deallocated.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <param name="type">
        /// Initialized with return type of @info
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_callable_info_load_return_type(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info,
        /* <type name="TypeInfo" type="GITypeInfo*" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* type);

        /// <summary>
        /// See if a callable could return %NULL.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// %TRUE if callable could return %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_may_return_null(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetMayReturnNullArgs();

        private bool GetMayReturnNull()
        {
            CheckGetMayReturnNullArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_may_return_null(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// See if a callable's return value is only useful in C.
        /// </summary>
        /// <param name="info">
        /// a #GICallableInfo
        /// </param>
        /// <returns>
        /// %TRUE if return value is only useful in C.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_callable_info_skip_return(
        /* <type name="CallableInfo" type="GICallableInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct* info);
        partial void CheckGetIsSkipReturnArgs();

        private bool GetIsSkipReturn()
        {
            CheckGetIsSkipReturnArgs();
            var info_ = (GISharp.Lib.GIRepository.CallableInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_callable_info_skip_return(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}