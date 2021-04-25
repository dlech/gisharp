// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='ParamSpecChar']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamChar", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecChar : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.Minimum']/*" />
            public readonly sbyte Minimum;

            /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.Maximum']/*" />
            public readonly sbyte Maximum;

            /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly sbyte DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecChar(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecChar instance specifying a %G_TYPE_CHAR property.
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
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_char(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* blurb,
        /* <type name="gint8" type="gint8" /> */
        /* transfer-ownership:none direction:in */
        sbyte minimum,
        /* <type name="gint8" type="gint8" /> */
        /* transfer-ownership:none direction:in */
        sbyte maximum,
        /* <type name="gint8" type="gint8" /> */
        /* transfer-ownership:none direction:in */
        sbyte defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, sbyte minimum, sbyte maximum, sbyte defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, sbyte minimum, sbyte maximum, sbyte defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, minimum, maximum, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var minimum_ = (sbyte)minimum;
            var maximum_ = (sbyte)maximum;
            var defaultValue_ = (sbyte)defaultValue;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_char(name_,nick_,blurb_,minimum_,maximum_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecChar.xmldoc" path="declaration/member[@name='ParamSpecChar.ParamSpecChar(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,sbyte,sbyte,sbyte,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecChar(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.UnownedUtf8 nick, GISharp.Runtime.UnownedUtf8 blurb, sbyte minimum, sbyte maximum, sbyte defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, minimum, maximum, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}