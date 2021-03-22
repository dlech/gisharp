// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='ParamSpecUChar']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamUChar", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecUChar : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.Minimum']/*" />
            public readonly byte Minimum;

            /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.Maximum']/*" />
            public readonly byte Maximum;

            /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly byte DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecUChar(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecUChar instance specifying a %G_TYPE_UCHAR property.
        /// </summary>
        /// <param name="name">
        /// canonical name of the property specified
        /// </param>
        /// <param name="nick">
        /// nick name for the property specified
        /// </param>
        /// <param name="blurb">
        /// description of the property specified
        /// </param>
        /// <param name="minimum">
        /// minimum value for the property specified
        /// </param>
        /// <param name="maximum">
        /// maximum value for the property specified
        /// </param>
        /// <param name="defaultValue">
        /// default value for the property specified
        /// </param>
        /// <param name="flags">
        /// flags for the property specified
        /// </param>
        /// <returns>
        /// a newly created parameter specification
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_uchar(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* blurb,
        /* <type name="guint8" type="guint8" /> */
        /* transfer-ownership:none direction:in */
        byte minimum,
        /* <type name="guint8" type="guint8" /> */
        /* transfer-ownership:none direction:in */
        byte maximum,
        /* <type name="guint8" type="guint8" /> */
        /* transfer-ownership:none direction:in */
        byte defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, byte minimum, byte maximum, byte defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, byte minimum, byte maximum, byte defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, minimum, maximum, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var minimum_ = (byte)minimum;
            var maximum_ = (byte)maximum;
            var defaultValue_ = (byte)defaultValue;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_uchar(name_,nick_,blurb_,minimum_,maximum_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecUChar.xmldoc" path="declaration/member[@name='ParamSpecUChar.ParamSpecUChar(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,byte,byte,byte,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecUChar(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, byte minimum, byte maximum, byte defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, minimum, maximum, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}