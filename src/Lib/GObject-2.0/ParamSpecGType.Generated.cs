// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecGType.xmldoc" path="declaration/member[@name='ParamSpecGType']/*" />
    [GISharp.Runtime.SinceAttribute("2.10")]
    [GISharp.Runtime.GTypeAttribute("GParamGType", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecGType : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecGType.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecGType.xmldoc" path="declaration/member[@name='UnmanagedStruct.IsAType']/*" />
            public readonly GISharp.Runtime.GType IsAType;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecGType(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecGType instance specifying a
        /// %G_TYPE_GTYPE property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See g_param_spec_internal() for details on property names.
        /// </para>
        /// </remarks>
        /// <param name="name">
        /// canonical name of the property specified
        /// </param>
        /// <param name="nick">
        /// nick name for the property specified
        /// </param>
        /// <param name="blurb">
        /// description of the property specified
        /// </param>
        /// <param name="isAType">
        /// a #GType whose subtypes are allowed as values
        ///  of the property (use %G_TYPE_NONE for any type)
        /// </param>
        /// <param name="flags">
        /// flags for the property specified
        /// </param>
        /// <returns>
        /// a newly created parameter specification
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.10")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_gtype(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* blurb,
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.GType isAType,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, GISharp.Runtime.GType isAType, GISharp.Lib.GObject.ParamFlags flags);

        [GISharp.Runtime.SinceAttribute("2.10")]
        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, GISharp.Runtime.GType isAType, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, isAType, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var isAType_ = (GISharp.Runtime.GType)isAType;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_gtype(name_,nick_,blurb_,isAType_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecGType.xmldoc" path="declaration/member[@name='ParamSpecGType.ParamSpecGType(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,GISharp.Runtime.GType,GISharp.Lib.GObject.ParamFlags)']/*" />
        [GISharp.Runtime.SinceAttribute("2.10")]
        public ParamSpecGType(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, GISharp.Runtime.GType isAType, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, isAType, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}