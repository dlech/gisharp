// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='ParamSpecInt']/*" />
    [GISharp.Runtime.GTypeAttribute("GParamInt", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ParamSpecInt : GISharp.Lib.GObject.ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.ParamSpec.UnmanagedStruct ParentInstance;

            /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.Minimum']/*" />
            public readonly int Minimum;

            /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.Maximum']/*" />
            public readonly int Maximum;

            /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='UnmanagedStruct.DefaultValue']/*" />
            public readonly int DefaultValue;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecInt(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecInt instance specifying a %G_TYPE_INT property.
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
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_int(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* nick,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* blurb,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int minimum,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int maximum,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int defaultValue,
        /* <type name="ParamFlags" type="GParamFlags" managed-name="ParamFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamFlags flags);
        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, int minimum, int maximum, int defaultValue, GISharp.Lib.GObject.ParamFlags flags);

        static GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* New(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, int minimum, int maximum, int defaultValue, GISharp.Lib.GObject.ParamFlags flags)
        {
            CheckNewArgs(name, nick, blurb, minimum, maximum, defaultValue, flags);
            var name_ = (byte*)name.UnsafeHandle;
            var nick_ = (byte*)nick.UnsafeHandle;
            var blurb_ = (byte*)blurb.UnsafeHandle;
            var minimum_ = (int)minimum;
            var maximum_ = (int)maximum;
            var defaultValue_ = (int)defaultValue;
            var flags_ = (GISharp.Lib.GObject.ParamFlags)flags;
            var ret_ = g_param_spec_int(name_,nick_,blurb_,minimum_,maximum_,defaultValue_,flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ParamSpecInt.xmldoc" path="declaration/member[@name='ParamSpecInt.ParamSpecInt(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.UnownedUtf8,int,int,int,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecInt(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 nick, GISharp.Lib.GLib.UnownedUtf8 blurb, int minimum, int maximum, int defaultValue, GISharp.Lib.GObject.ParamFlags flags) : this((System.IntPtr)New(name, nick, blurb, minimum, maximum, defaultValue, flags), GISharp.Runtime.Transfer.None)
        {
        }
    }
}