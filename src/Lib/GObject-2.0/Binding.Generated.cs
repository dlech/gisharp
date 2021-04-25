// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding']/*" />
    [GISharp.Runtime.SinceAttribute("2.26")]
    [GISharp.Runtime.GTypeAttribute("GBinding", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class Binding : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Runtime.GType _GType = g_binding_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Flags_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("flags", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.BindingFlags Flags_ { get => (GISharp.Lib.GObject.BindingFlags)GetProperty("flags")!; set => SetProperty("flags", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Source_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("source", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.Object? Source_ { get => (GISharp.Lib.GObject.Object?)GetProperty("source")!; set => SetProperty("source", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.SourceProperty_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("source-property", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Runtime.Utf8? SourceProperty_ { get => (GISharp.Runtime.Utf8?)GetProperty("source-property")!; set => SetProperty("source-property", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Target_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("target", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.Object? Target_ { get => (GISharp.Lib.GObject.Object?)GetProperty("target")!; set => SetProperty("target", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.TargetProperty_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("target-property", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Runtime.Utf8? TargetProperty_ { get => (GISharp.Runtime.Utf8?)GetProperty("target-property")!; set => SetProperty("target-property", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Flags']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.BindingFlags Flags { get => GetFlags(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Source']/*" />
        [System.ObsoleteAttribute("Use g_binding_dup_source() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.Object? Source { get => GetSource(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.SourceProperty']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Runtime.UnownedUtf8 SourceProperty { get => GetSourceProperty(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Target']/*" />
        [System.ObsoleteAttribute("Use g_binding_dup_target() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.Object? Target { get => GetTarget(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.TargetProperty']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Runtime.UnownedUtf8 TargetProperty { get => GetTargetProperty(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Binding(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_binding_get_type();

        /// <summary>
        /// Retrieves the flags passed when constructing the #GBinding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the #GBindingFlags used by the #GBinding
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="BindingFlags" type="GBindingFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.BindingFlags g_binding_get_flags(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetFlagsArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.BindingFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_flags(binding_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GObject.BindingFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the source of the binding.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A #GBinding can outlive the source #GObject as the binding does not hold a
        /// strong reference to the source. If the source is destroyed before the
        /// binding then this function will return %NULL.
        /// </para>
        /// <para>
        /// Use g_binding_dup_source() if the source or binding are used from different
        /// threads as otherwise the pointer returned from this function might become
        /// invalid if the source is finalized from another thread in the meantime.
        /// </para>
        /// </remarks>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the source #GObject, or %NULL if the
        ///     source does not exist any more.
        /// </returns>
        [System.ObsoleteAttribute("Use g_binding_dup_source() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_binding_get_source(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetSourceArgs();

        [System.ObsoleteAttribute("Use g_binding_dup_source() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.Object? GetSource()
        {
            CheckGetSourceArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_source(binding_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the property of #GBinding:source used as the source
        /// of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the name of the source property
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_binding_get_source_property(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetSourcePropertyArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Runtime.UnownedUtf8 GetSourceProperty()
        {
            CheckGetSourcePropertyArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_source_property(binding_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the target of the binding.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A #GBinding can outlive the target #GObject as the binding does not hold a
        /// strong reference to the target. If the target is destroyed before the
        /// binding then this function will return %NULL.
        /// </para>
        /// <para>
        /// Use g_binding_dup_target() if the target or binding are used from different
        /// threads as otherwise the pointer returned from this function might become
        /// invalid if the target is finalized from another thread in the meantime.
        /// </para>
        /// </remarks>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the target #GObject, or %NULL if the
        ///     target does not exist any more.
        /// </returns>
        [System.ObsoleteAttribute("Use g_binding_dup_target() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_binding_get_target(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetTargetArgs();

        [System.ObsoleteAttribute("Use g_binding_dup_target() for a safer version of this\nfunction.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.68")]
        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.Object? GetTarget()
        {
            CheckGetTargetArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_target(binding_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the property of #GBinding:target used as the target
        /// of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the name of the target property
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_binding_get_target_property(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetTargetPropertyArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Runtime.UnownedUtf8 GetTargetProperty()
        {
            CheckGetTargetPropertyArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_target_property(binding_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Explicitly releases the binding between the source and the target
        /// property expressed by @binding.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function will release the reference that is being held on
        /// the @binding instance if the binding is still bound; if you want to hold on
        /// to the #GBinding instance after calling g_binding_unbind(), you will need
        /// to hold a reference to it.
        /// </para>
        /// <para>
        /// Note however that this function does not take ownership of @binding, it
        /// only unrefs the reference that was initially created by
        /// g_object_bind_property() and is owned by the binding.
        /// </para>
        /// </remarks>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_binding_unbind(
        /* <type name="Binding" type="GBinding*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
    }
}