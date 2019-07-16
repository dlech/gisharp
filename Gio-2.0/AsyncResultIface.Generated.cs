// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='AsyncResultIface']/*" />
    public sealed class AsyncResultIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='GIface']/*" />
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;

            /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='GetUserData']/*" />
            public System.IntPtr GetUserData;

            /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='GetSourceObject']/*" />
            public System.IntPtr GetSourceObject;

            /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='IsTagged']/*" />
            public System.IntPtr IsTagged;
#pragma warning restore CS0649
        }

        static AsyncResultIface()
        {
            System.Int32 getUserDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetUserData));
            RegisterVirtualMethod(getUserDataOffset, GetUserDataMarshal.Create);
            System.Int32 getSourceObjectOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetSourceObject));
            RegisterVirtualMethod(getSourceObjectOffset, GetSourceObjectMarshal.Create);
            System.Int32 isTaggedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.IsTagged));
            RegisterVirtualMethod(isTaggedOffset, IsTaggedMarshal.Create);
        }

        /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='GetUserData']/*" />
        public delegate System.IntPtr GetUserData();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetUserData(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        /// <summary>
        /// Class for marshalling <see cref="GetUserData"/> methods.
        /// </summary>
        public static class GetUserDataMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetUserData Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetUserData(System.IntPtr res_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None)!;
                        var doGetUserData = (GetUserData)methodInfo.CreateDelegate(typeof(GetUserData), res);
                        var ret = doGetUserData();
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedGetUserData;
            }
        }

        /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='GetSourceObject']/*" />
        public delegate GISharp.Lib.GObject.Object? GetSourceObject();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetSourceObject(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        /// <summary>
        /// Class for marshalling <see cref="GetSourceObject"/> methods.
        /// </summary>
        public static class GetSourceObjectMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetSourceObject Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetSourceObject(System.IntPtr res_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None)!;
                        var doGetSourceObject = (GetSourceObject)methodInfo.CreateDelegate(typeof(GetSourceObject), res);
                        var ret = doGetSourceObject();
                        var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedGetSourceObject;
            }
        }

        /// <include file="AsyncResultIface.xmldoc" path="declaration/member[@name='IsTagged']/*" />
        public delegate System.Boolean IsTagged(System.IntPtr sourceTag);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedIsTagged(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr sourceTag);

        /// <summary>
        /// Class for marshalling <see cref="IsTagged"/> methods.
        /// </summary>
        public static class IsTaggedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedIsTagged Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedIsTagged(System.IntPtr res_, System.IntPtr sourceTag_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None)!;
                        var sourceTag = (System.IntPtr)sourceTag_;
                        var doIsTagged = (IsTagged)methodInfo.CreateDelegate(typeof(IsTagged), res);
                        var ret = doIsTagged(sourceTag);
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedIsTagged;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public AsyncResultIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}