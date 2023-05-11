// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecBoxed.xmldoc" path="declaration/member[@name='ParamSpecBoxed']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamBoxed", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecBoxed : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecBoxed.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecBoxed(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecBoxed instance specifying a %G_TYPE_BOXED
        /// derived property.
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
        /// <param name="boxedType">
        /// %G_TYPE_BOXED derived type of this property
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
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_boxed(
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
        GISharp.Runtime.GType boxedType,
        /* <type name="ParamFlags" type="GParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType boxedType, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType boxedType, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, boxedType, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var boxedType_ = (GISharp.Runtime.GType)boxedType;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_boxed(name_,nick_,blurb_,boxedType_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecBoxed.xmldoc" path="declaration/member[@name='ParamSpecBoxed.ParamSpecBoxed(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,GISharp.Runtime.NullableUnownedUtf8,GISharp.Runtime.GType,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecBoxed(GISharp.Runtime.UnownedUtf8 name, GISharp.Runtime.NullableUnownedUtf8 nick, GISharp.Runtime.NullableUnownedUtf8 blurb, GISharp.Runtime.GType boxedType, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, boxedType, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}