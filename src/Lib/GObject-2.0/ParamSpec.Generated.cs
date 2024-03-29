// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec']/*" />
    [GISharp.Runtime.GTypeAttribute("GParam", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ParamSpecClass))]
    public abstract unsafe partial class ParamSpec : GISharp.Lib.GObject.TypeInstance
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.GTypeInstance']/*" />
            public readonly GISharp.Lib.GObject.TypeInstance.UnmanagedStruct GTypeInstance;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.Name']/*" />
            public readonly byte* Name;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.Flags']/*" />
            public readonly GISharp.Lib.GObject.ParamFlags Flags;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.ValueType']/*" />
            public readonly GISharp.Runtime.GType ValueType;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.OwnerType']/*" />
            public readonly GISharp.Runtime.GType OwnerType;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.Nick']/*" />
            internal readonly byte* Nick;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.Blurb']/*" />
            internal readonly byte* Blurb;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.Qdata']/*" />
            internal readonly GISharp.Lib.GLib.Data.UnmanagedStruct* Qdata;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.RefCount']/*" />
            internal readonly uint RefCount;

            /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParamId']/*" />
            internal readonly uint ParamId;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.mask']/*" />
        private const int mask = 255;

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.staticStrings']/*" />
        private const int staticStrings = 224;

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.userShift']/*" />
        private const int userShift = 8;

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.Blurb']/*" />
        public GISharp.Runtime.NullableUnownedUtf8 Blurb { get => GetBlurb(); }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DefaultValue']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public ref readonly GISharp.Lib.GObject.Value DefaultValue { get => ref GetDefaultValue(); }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.Name']/*" />
        public GISharp.Runtime.UnownedUtf8 Name { get => GetName(); }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.NameQuark']/*" />
        [GISharp.Runtime.SinceAttribute("2.46")]
        public GISharp.Lib.GLib.Quark NameQuark { get => GetNameQuark(); }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.Nick']/*" />
        public GISharp.Runtime.UnownedUtf8 Nick { get => GetNick(); }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.RedirectTarget']/*" />
        [GISharp.Runtime.SinceAttribute("2.4")]
        public GISharp.Lib.GObject.ParamSpec? RedirectTarget { get => GetRedirectTarget(); }

        /// <summary>
        /// Validate a property name for a #GParamSpec. This can be useful for
        /// dynamically-generated properties which need to be validated at run-time
        /// before actually trying to create them.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See [canonical parameter names][canonical-parameter-names] for details of
        /// the rules for valid names.
        /// </para>
        /// </remarks>
        /// <param name="name">
        /// the canonical name of the property
        /// </param>
        /// <returns>
        /// %TRUE if @name is a valid property name, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.66")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_param_spec_is_valid_name(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name);
        static partial void CheckIsValidNameArgs(GISharp.Runtime.UnownedUtf8 name);

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.IsValidName(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.66")]
        public static bool IsValidName(GISharp.Runtime.UnownedUtf8 name)
        {
            CheckIsValidNameArgs(name);
            var name_ = (byte*)name.UnsafeHandle;
            var ret_ = g_param_spec_is_valid_name(name_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Get the short description of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the short description of @pspec.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_param_spec_get_blurb(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetBlurbArgs();

        private GISharp.Runtime.NullableUnownedUtf8 GetBlurb()
        {
            CheckGetBlurbArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_blurb(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Gets the default value of @pspec as a pointer to a #GValue.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The #GValue will remain valid for the life of @pspec.
        /// </para>
        /// </remarks>
        /// <param name="pspec">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// a pointer to a #GValue which must not be modified
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Value" type="const GValue*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Value* g_param_spec_get_default_value(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetDefaultValueArgs();

        [GISharp.Runtime.SinceAttribute("2.38")]
        private ref readonly GISharp.Lib.GObject.Value GetDefaultValue()
        {
            CheckGetDefaultValueArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_default_value(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            ref var ret = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.Value>(ret_);
            return ref ret;
        }

        /// <summary>
        /// Get the name of a #GParamSpec.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The name is always an "interned" string (as per g_intern_string()).
        /// This allows for pointer-value comparisons.
        /// </para>
        /// </remarks>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the name of @pspec.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_param_spec_get_name(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetNameArgs();

        private GISharp.Runtime.UnownedUtf8 GetName()
        {
            CheckGetNameArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_name(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Gets the GQuark for the name.
        /// </summary>
        /// <param name="pspec">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// the GQuark for @pspec-&gt;name.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.46")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark g_param_spec_get_name_quark(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetNameQuarkArgs();

        [GISharp.Runtime.SinceAttribute("2.46")]
        private GISharp.Lib.GLib.Quark GetNameQuark()
        {
            CheckGetNameQuarkArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_name_quark(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        /// <summary>
        /// Get the nickname of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the nickname of @pspec.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_param_spec_get_nick(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetNickArgs();

        private GISharp.Runtime.UnownedUtf8 GetNick()
        {
            CheckGetNickArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_nick(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata().
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern System.IntPtr g_param_spec_get_qdata(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark quark);
        partial void CheckGetQdataArgs(GISharp.Lib.GLib.Quark quark);

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.GetQdata(GISharp.Lib.GLib.Quark)']/*" />
        public System.IntPtr GetQdata(GISharp.Lib.GLib.Quark quark)
        {
            CheckGetQdataArgs(quark);
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var quark_ = (GISharp.Lib.GLib.Quark)quark;
            var ret_ = g_param_spec_get_qdata(pspec_,quark_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type #GParamSpecOverride. See g_object_class_override_property()
        /// for an example of the use of this capability.
        /// </summary>
        /// <param name="pspec">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// paramspec to which requests on this
        ///          paramspec should be redirected, or %NULL if none.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_get_redirect_target(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckGetRedirectTargetArgs();

        [GISharp.Runtime.SinceAttribute("2.4")]
        private GISharp.Lib.GObject.ParamSpec? GetRedirectTarget()
        {
            CheckGetRedirectTargetArgs();
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_param_spec_get_redirect_target(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Increments the reference count of @pspec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the #GParamSpec that was passed into this function
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_ref(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_param_spec_ref((GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Convenience function to ref and sink a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the #GParamSpec that was passed into this function
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.10")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_ref_sink(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Sets an opaque, named pointer on a #GParamSpec. The name is
        /// specified through a #GQuark (retrieved e.g. via
        /// g_quark_from_static_string()), and the pointer can be gotten back
        /// from the @pspec with g_param_spec_get_qdata().  Setting a
        /// previously set user data pointer, overrides (frees) the old pointer
        /// set, using %NULL as pointer essentially removes the data stored.
        /// </summary>
        /// <param name="pspec">
        /// the #GParamSpec to set store a user data pointer
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <param name="data">
        /// an opaque user data pointer
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_set_qdata(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark quark,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data);
        partial void CheckSetQdataArgs(GISharp.Lib.GLib.Quark quark, System.IntPtr data);

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.SetQdata(GISharp.Lib.GLib.Quark,System.IntPtr)']/*" />
        public void SetQdata(GISharp.Lib.GLib.Quark quark, System.IntPtr data)
        {
            CheckSetQdataArgs(quark, data);
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            var quark_ = (GISharp.Lib.GLib.Quark)quark;
            var data_ = (System.IntPtr)data;
            g_param_spec_set_qdata(pspec_, quark_, data_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// This function works like g_param_spec_set_qdata(), but in addition,
        /// a `void (*destroy) (gpointer)` function may be
        /// specified which is called with @data as argument when the @pspec is
        /// finalized, or the data is being overwritten by a call to
        /// g_param_spec_set_qdata() with the same @quark.
        /// </summary>
        /// <param name="pspec">
        /// the #GParamSpec to set store a user data pointer
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <param name="data">
        /// an opaque user data pointer
        /// </param>
        /// <param name="destroy">
        /// function to invoke with @data as argument, when @data needs to
        ///  be freed
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_set_qdata_full(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark quark,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> destroy);

        /// <summary>
        /// The initial reference count of a newly created #GParamSpec is 1,
        /// even though no one has explicitly called g_param_spec_ref() on it
        /// yet. So the initial reference count is flagged as "floating", until
        /// someone calls `g_param_spec_ref (pspec); g_param_spec_sink
        /// (pspec);` in sequence on it, taking over the initial
        /// reference count (thus ending up with a @pspec that has a reference
        /// count of 1 still, but is not flagged "floating" anymore).
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_sink(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata()
        /// and removes the @data from @pspec without invoking its destroy()
        /// function (if any was set).  Usually, calling this function is only
        /// required to update user data pointers with a destroy notifier.
        /// </summary>
        /// <param name="pspec">
        /// the #GParamSpec to get a stored user data pointer from
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern System.IntPtr g_param_spec_steal_qdata(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark quark);

        /// <summary>
        /// Decrements the reference count of a @pspec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_unref(
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DoFinalize()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ParamSpecClass.UnmanagedFinalize))]
        protected virtual void DoFinalize()
        {
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ParamSpecClass.UnmanagedFinalize>(_GType)!(pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DoValueIsValid(GISharp.Lib.GObject.Value)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ParamSpecClass.UnmanagedValueIsValid))]
        protected virtual bool DoValueIsValid(in GISharp.Lib.GObject.Value value)
        {
            fixed (GISharp.Lib.GObject.Value* value_ = &value)
            {
                var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
                var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ParamSpecClass.UnmanagedValueIsValid>(_GType)!(pspec_,value_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DoValueSetDefault(GISharp.Lib.GObject.Value)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ParamSpecClass.UnmanagedValueSetDefault))]
        protected virtual void DoValueSetDefault(ref GISharp.Lib.GObject.Value value)
        {
            fixed (GISharp.Lib.GObject.Value* value_ = &value)
            {
                var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
                GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ParamSpecClass.UnmanagedValueSetDefault>(_GType)!(pspec_, value_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DoValueValidate(GISharp.Lib.GObject.Value)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ParamSpecClass.UnmanagedValueValidate))]
        protected virtual bool DoValueValidate(ref GISharp.Lib.GObject.Value value)
        {
            fixed (GISharp.Lib.GObject.Value* value_ = &value)
            {
                var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
                var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ParamSpecClass.UnmanagedValueValidate>(_GType)!(pspec_,value_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }

        /// <include file="ParamSpec.xmldoc" path="declaration/member[@name='ParamSpec.DoValuesCmp(GISharp.Lib.GObject.Value,GISharp.Lib.GObject.Value)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ParamSpecClass.UnmanagedValuesCmp))]
        protected virtual int DoValuesCmp(in GISharp.Lib.GObject.Value value1, in GISharp.Lib.GObject.Value value2)
        {
            fixed (GISharp.Lib.GObject.Value* value2_ = &value2)
            {
                fixed (GISharp.Lib.GObject.Value* value1_ = &value1)
                {
                    var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)UnsafeHandle;
                    var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ParamSpecClass.UnmanagedValuesCmp>(_GType)!(pspec_,value1_,value2_);
                    GISharp.Runtime.GMarshal.PopUnhandledException();
                    var ret = (int)ret_;
                    return ret;
                }
            }
        }
    }
}