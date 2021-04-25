// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='ParamSpecUInt']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamUInt", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecUInt : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.Minimum']/*" />
            public readonly uint Minimum;

            /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.Maximum']/*" />
            public readonly uint Maximum;

            /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly uint DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecUInt(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecUInt instance specifying a %G_TYPE_UINT property.
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
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_uint(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* blurb,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint minimum,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint maximum,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, uint minimum, uint maximum, uint defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, uint minimum, uint maximum, uint defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, minimum, maximum, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var minimum_ = (uint)minimum;
            var maximum_ = (uint)maximum;
            var defaultValue_ = (uint)defaultValue;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_uint(name_,nick_,blurb_,minimum_,maximum_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecUInt.xmldoc" path="declaration/member[@name='ParamSpecUInt.ParamSpecUInt(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,uint,uint,uint,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecUInt(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, uint minimum, uint maximum, uint defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, minimum, maximum, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}