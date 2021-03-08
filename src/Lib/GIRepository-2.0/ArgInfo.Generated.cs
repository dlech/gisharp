// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo']/*" />
    public sealed unsafe partial class ArgInfo : GISharp.Lib.GIRepository.BaseInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.Closure']/*" />
        public int Closure { get => GetClosure(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.Destroy']/*" />
        public int Destroy { get => GetDestroy(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.Direction']/*" />
        public GISharp.Lib.GIRepository.Direction Direction { get => GetDirection(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.OwnershipTransfer']/*" />
        public GISharp.Lib.GIRepository.Transfer OwnershipTransfer { get => GetOwnershipTransfer(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.Scope']/*" />
        public GISharp.Lib.GIRepository.ScopeType Scope { get => GetScope(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.Type']/*" />
        public GISharp.Lib.GIRepository.TypeInfo Type { get => GetType_(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.IsCallerAllocates']/*" />
        public bool IsCallerAllocates { get => GetIsCallerAllocates(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.IsOptional']/*" />
        public bool IsOptional { get => GetIsOptional(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.IsReturnValue']/*" />
        public bool IsReturnValue { get => GetIsReturnValue(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.IsSkip']/*" />
        [GISharp.Runtime.SinceAttribute("1.30")]
        public bool IsSkip { get => GetIsSkip(); }

        /// <include file="ArgInfo.xmldoc" path="declaration/member[@name='ArgInfo.MayBeNull']/*" />
        public bool MayBeNull { get => GetMayBeNull(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ArgInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the index of the user data argument. This is only valid
        /// for arguments which are callbacks.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// index of the user data argument or -1 if there is none
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_arg_info_get_closure(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetClosureArgs();

        private int GetClosure()
        {
            CheckGetClosureArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_closure(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtains the index of the #GDestroyNotify argument. This is only valid
        /// for arguments which are callbacks.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// index of the #GDestroyNotify argument or -1 if there is none
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_arg_info_get_destroy(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetDestroyArgs();

        private int GetDestroy()
        {
            CheckGetDestroyArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_destroy(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the direction of the argument. Check #GIDirection for possible
        /// direction values.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// the direction
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Direction" type="GIDirection" managed-name="Direction" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.Direction g_arg_info_get_direction(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetDirectionArgs();

        private GISharp.Lib.GIRepository.Direction GetDirection()
        {
            CheckGetDirectionArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_direction(info_);
            var ret = (GISharp.Lib.GIRepository.Direction)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the ownership transfer for this argument.
        /// #GITransfer contains a list of possible values.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// the transfer
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Transfer" type="GITransfer" managed-name="Transfer" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.Transfer g_arg_info_get_ownership_transfer(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetOwnershipTransferArgs();

        private GISharp.Lib.GIRepository.Transfer GetOwnershipTransfer()
        {
            CheckGetOwnershipTransferArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_ownership_transfer(info_);
            var ret = (GISharp.Lib.GIRepository.Transfer)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the scope type for this argument. The scope type explains
        /// how a callback is going to be invoked, most importantly when
        /// the resources required to invoke it can be freed.
        /// #GIScopeType contains a list of possible values.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// the scope type
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ScopeType" type="GIScopeType" managed-name="ScopeType" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.ScopeType g_arg_info_get_scope(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetScopeArgs();

        private GISharp.Lib.GIRepository.ScopeType GetScope()
        {
            CheckGetScopeArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_scope(info_);
            var ret = (GISharp.Lib.GIRepository.ScopeType)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for @info.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// the #GITypeInfo holding the type
        ///   information for @info, free it with g_base_info_unref()
        ///   when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" managed-name="TypeInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_arg_info_get_type(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetType_Args();

        private GISharp.Lib.GIRepository.TypeInfo GetType_()
        {
            CheckGetType_Args();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_get_type(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain if the argument is a pointer to a struct or object that will
        /// receive an output of a function.  The default assumption for
        /// %GI_DIRECTION_OUT arguments which have allocation is that the
        /// callee allocates; if this is %TRUE, then the caller must allocate.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// %TRUE if caller is required to have allocated the argument
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_arg_info_is_caller_allocates(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetIsCallerAllocatesArgs();

        private bool GetIsCallerAllocates()
        {
            CheckGetIsCallerAllocatesArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_is_caller_allocates(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain if the argument is optional.  For 'out' arguments this means
        /// that you can pass %NULL in order to ignore the result.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// %TRUE if it is an optional argument
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_arg_info_is_optional(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetIsOptionalArgs();

        private bool GetIsOptional()
        {
            CheckGetIsOptionalArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_is_optional(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain if the argument is a return value. It can either be a
        /// parameter or a return value.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// %TRUE if it is a return value
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_arg_info_is_return_value(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetIsReturnValueArgs();

        private bool GetIsReturnValue()
        {
            CheckGetIsReturnValueArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_is_return_value(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain if an argument is only useful in C.
        /// </summary>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// %TRUE if argument is only useful in C.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.30")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_arg_info_is_skip(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetIsSkipArgs();

        [GISharp.Runtime.SinceAttribute("1.30")]
        private bool GetIsSkip()
        {
            CheckGetIsSkipArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_is_skip(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain information about a the type of given argument @info; this
        /// function is a variant of g_arg_info_get_type() designed for stack
        /// allocation.
        /// </summary>
        /// <remarks>
        /// The initialized @type must not be referenced after @info is deallocated.
        /// </remarks>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <param name="type">
        /// Initialized with information about type of @info
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_arg_info_load_type(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info,
        /* <type name="TypeInfo" type="GITypeInfo*" managed-name="TypeInfo" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* type);

        /// <summary>
        /// Obtain if the type of the argument includes the possibility of %NULL.
        /// For 'in' values this means that %NULL is a valid value.  For 'out'
        /// values, this means that %NULL may be returned.
        /// </summary>
        /// <remarks>
        /// See also g_arg_info_is_optional().
        /// </remarks>
        /// <param name="info">
        /// a #GIArgInfo
        /// </param>
        /// <returns>
        /// %TRUE if the value may be %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_arg_info_may_be_null(
        /* <type name="ArgInfo" type="GIArgInfo*" managed-name="ArgInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct* info);
        partial void CheckGetMayBeNullArgs();

        private bool GetMayBeNull()
        {
            CheckGetMayBeNullArgs();
            var info_ = (GISharp.Lib.GIRepository.ArgInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_arg_info_may_be_null(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}