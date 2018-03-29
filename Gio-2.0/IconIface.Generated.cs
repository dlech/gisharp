namespace GISharp.Lib.Gio
{
    /// <summary>
    /// GIconIface is used to implement GIcon types for various
    /// different systems. See <see cref="ThemedIcon"/> and #GLoadableIcon for
    /// examples of how to implement this interface.
    /// </summary>
    public sealed class IconIface : GISharp.Lib.GObject.TypeInterface
    {
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            /// <summary>
            /// The parent interface.
            /// </summary>
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedHash Hash;
            public UnmanagedEqual Equal;
            public System.IntPtr ToTokens;
            public System.IntPtr FromTokens;
            public UnmanagedSerialize Serialize;
#pragma warning restore CS0649
        }

        static IconIface()
        {
            System.Int32 hashOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Hash));
            RegisterVirtualMethod(hashOffset, HashFactory.Create);
            System.Int32 equalOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Equal));
            RegisterVirtualMethod(equalOffset, EqualFactory.Create);
            System.Int32 serializeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Serialize));
            RegisterVirtualMethod(serializeOffset, SerializeFactory.Create);
        }

        public delegate System.UInt32 Hash();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.UInt32 UnmanagedHash(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Factory for creating <see cref="Hash"/> methods.
        /// </summary>
        public static class HashFactory
        {
            public static unsafe UnmanagedHash Create(System.Reflection.MethodInfo methodInfo)
            {
                System.UInt32 hash(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None);
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

                return hash;
            }
        }

        public delegate System.Boolean Equal(GISharp.Lib.Gio.IIcon icon2);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedEqual(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon1,
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon2);

        /// <summary>
        /// Factory for creating <see cref="Equal"/> methods.
        /// </summary>
        public static class EqualFactory
        {
            public static unsafe UnmanagedEqual Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean equal(System.IntPtr icon1_, System.IntPtr icon2_)
                {
                    try
                    {
                        var icon1 = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon1_, GISharp.Runtime.Transfer.None);
                        var icon2 = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon2_, GISharp.Runtime.Transfer.None);
                        var doEqual = (Equal)methodInfo.CreateDelegate(typeof(Equal), icon1);
                        var ret = doEqual(icon2);
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return equal;
            }
        }

        public delegate GISharp.Lib.GLib.Variant Serialize();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedSerialize(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Factory for creating <see cref="Serialize"/> methods.
        /// </summary>
        public static class SerializeFactory
        {
            public static unsafe UnmanagedSerialize Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr serialize(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None);
                        var doSerialize = (Serialize)methodInfo.CreateDelegate(typeof(Serialize), icon);
                        var ret = doSerialize();
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return serialize;
            }
        }

        public IconIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}