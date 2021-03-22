// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IconIface.xmldoc" path="declaration/member[@name='IconIface']/*" />
    public sealed unsafe partial class IconIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Hash']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Icon.UnmanagedStruct*, uint> Hash;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Equal']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Icon.UnmanagedStruct*, GISharp.Lib.Gio.Icon.UnmanagedStruct*, GISharp.Runtime.Boolean> Equal;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ToTokens']/*" />
            public readonly System.IntPtr ToTokens;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.FromTokens']/*" />
            public readonly System.IntPtr FromTokens;

            /// <include file="IconIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Serialize']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Icon.UnmanagedStruct*, GISharp.Lib.GLib.Variant.UnmanagedStruct*> Serialize;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static IconIface()
        {
            int hashOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Hash));
            RegisterVirtualMethod(hashOffset, HashMarshal.Create);
            int equalOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Equal));
            RegisterVirtualMethod(equalOffset, EqualMarshal.Create);
            int serializeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Serialize));
            RegisterVirtualMethod(serializeOffset, SerializeMarshal.Create);
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='_Hash']/*" />
        public delegate uint _Hash();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate uint UnmanagedHash(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Icon.UnmanagedStruct* icon);

        /// <summary>
        /// Class for marshalling <see cref="_Hash"/> methods.
        /// </summary>
        public static unsafe class HashMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedHash Create(System.Reflection.MethodInfo methodInfo)
            {
                uint unmanagedHash(GISharp.Lib.Gio.Icon.UnmanagedStruct* icon_) { try { var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)icon_, GISharp.Runtime.Transfer.None)!; var doHash = (_Hash)methodInfo.CreateDelegate(typeof(_Hash), icon); var ret = doHash(); var ret_ = (uint)ret; return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(uint); }

                return unmanagedHash;
            }
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='_Equal']/*" />
        public delegate bool _Equal(GISharp.Lib.Gio.IIcon? icon2);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedEqual(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Icon.UnmanagedStruct* icon1,
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Icon.UnmanagedStruct* icon2);

        /// <summary>
        /// Class for marshalling <see cref="_Equal"/> methods.
        /// </summary>
        public static unsafe class EqualMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedEqual Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedEqual(GISharp.Lib.Gio.Icon.UnmanagedStruct* icon1_, GISharp.Lib.Gio.Icon.UnmanagedStruct* icon2_) { try { var icon1 = (GISharp.Lib.Gio.IIcon?)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)icon1_, GISharp.Runtime.Transfer.None); var icon2 = (GISharp.Lib.Gio.IIcon?)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)icon2_, GISharp.Runtime.Transfer.None); var doEqual = (_Equal)methodInfo.CreateDelegate(typeof(_Equal), icon1); var ret = doEqual(icon2); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedEqual;
            }
        }

        /// <include file="IconIface.xmldoc" path="declaration/member[@name='_Serialize']/*" />
        public delegate GISharp.Lib.GLib.Variant _Serialize();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedSerialize(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Icon.UnmanagedStruct* icon);

        /// <summary>
        /// Class for marshalling <see cref="_Serialize"/> methods.
        /// </summary>
        public static unsafe class SerializeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSerialize Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedSerialize(GISharp.Lib.Gio.Icon.UnmanagedStruct* icon_) { try { var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)icon_, GISharp.Runtime.Transfer.None)!; var doSerialize = (_Serialize)methodInfo.CreateDelegate(typeof(_Serialize), icon); var ret = doSerialize(); var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)ret.Take(); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*); }

                return unmanagedSerialize;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public IconIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}