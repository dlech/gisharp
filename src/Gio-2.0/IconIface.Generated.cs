// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IconIface.xmldoc" path="declaration/member[@name='IconIface']/*" />
    public sealed class IconIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Hash']/*" />
            public System.IntPtr Hash;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Equal']/*" />
            public System.IntPtr Equal;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ToTokens']/*" />
            public System.IntPtr ToTokens;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.FromTokens']/*" />
            public System.IntPtr FromTokens;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Serialize']/*" />
            public System.IntPtr Serialize;
#pragma warning restore CS0649
        }

        static IconIface()
        {
            System.Int32 hashOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Hash));
            RegisterVirtualMethod(hashOffset, HashMarshal.Create);
            System.Int32 equalOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Equal));
            RegisterVirtualMethod(equalOffset, EqualMarshal.Create);
            System.Int32 serializeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Serialize));
            RegisterVirtualMethod(serializeOffset, SerializeMarshal.Create);
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='Hash']/*" />
        public delegate System.UInt32 Hash();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.UInt32 UnmanagedHash(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Class for marshalling <see cref="Hash"/> methods.
        /// </summary>
        public static class HashMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedHash Create(System.Reflection.MethodInfo methodInfo)
            {
                System.UInt32 unmanagedHash(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None)!;
                        var doHash = (Hash)methodInfo.CreateDelegate(typeof(Hash), icon);
                        var ret = doHash();
                        var ret_ = (System.UInt32)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.UInt32);
                }

                return unmanagedHash;
            }
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='Equal']/*" />
        public delegate System.Boolean Equal(GISharp.Lib.Gio.IIcon? icon2);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedEqual(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon1,
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon2);

        /// <summary>
        /// Class for marshalling <see cref="Equal"/> methods.
        /// </summary>
        public static class EqualMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedEqual Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedEqual(System.IntPtr icon1_, System.IntPtr icon2_)
                {
                    try
                    {
                        var icon1 = (GISharp.Lib.Gio.IIcon?)GISharp.Lib.GObject.Object.GetInstance(icon1_, GISharp.Runtime.Transfer.None);
                        var icon2 = (GISharp.Lib.Gio.IIcon?)GISharp.Lib.GObject.Object.GetInstance(icon2_, GISharp.Runtime.Transfer.None);
                        var doEqual = (Equal)methodInfo.CreateDelegate(typeof(Equal), icon1);
                        var ret = doEqual(icon2);
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedEqual;
            }
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='Serialize']/*" />
        public delegate GISharp.Lib.GLib.Variant Serialize();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedSerialize(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Class for marshalling <see cref="Serialize"/> methods.
        /// </summary>
        public static class SerializeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedSerialize Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedSerialize(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None)!;
                        var doSerialize = (Serialize)methodInfo.CreateDelegate(typeof(Serialize), icon);
                        var ret = doSerialize();
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedSerialize;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public IconIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}