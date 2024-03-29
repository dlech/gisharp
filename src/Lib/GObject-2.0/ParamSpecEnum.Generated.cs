// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='ParamSpecEnum']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamEnum", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecEnum : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='UnmanagedStruct.EnumClass']/*" />
            public readonly GISharp.Lib.GObject.EnumClass.UnmanagedStruct* EnumClass;

            /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly int DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecEnum(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecEnum instance specifying a %G_TYPE_ENUM
        /// property.
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
        /// <param name="enumType">
        /// a #GType derived from %G_TYPE_ENUM
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
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_enum(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* blurb,
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.GType enumType,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType enumType, int defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType enumType, int defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, enumType, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var enumType_ = (GISharp.Runtime.GType)enumType;
            var defaultValue_ = (int)defaultValue;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_enum(name_,nick_,blurb_,enumType_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='ParamSpecEnum.ParamSpecEnum(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,GISharp.Runtime.GType,int,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecEnum(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType enumType, int defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, enumType, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}