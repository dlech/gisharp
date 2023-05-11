// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecUnichar.xmldoc" path="declaration/member[@name='ParamSpecUnichar']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamUnichar", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecUnichar : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecUnichar.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecUnichar.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly uint DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecUnichar(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecUnichar instance specifying a %G_TYPE_UINT
        /// property. #GValue structures for this property can be accessed with
        /// g_value_set_uint() and g_value_get_uint().
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
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_unichar(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* blurb,
        /* <type name="gunichar" type="gunichar" /> */
        /* transfer-ownership:none direction:in */
        uint defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, System.Text.Rune defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, System.Text.Rune defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var defaultValue_ = (uint)defaultValue.Value;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_unichar(name_,nick_,blurb_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecUnichar.xmldoc" path="declaration/member[@name='ParamSpecUnichar.ParamSpecUnichar(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,System.Text.Rune,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecUnichar(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, System.Text.Rune defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}