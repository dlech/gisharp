using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// <see cref="Binding"/> is the representation of a binding between a property on a
    /// <see cref="Object"/> instance (or source) and another property on another <see cref="Object"/>
    /// instance (or target).
    /// </summary>
    /// <remarks>
    /// Whenever the source property changes, the same
    /// value is applied to the target property; for instance, the following
    /// binding:
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   g_object_bind_property (object1, "property-a",
    ///                           object2, "property-b",
    ///                           G_BINDING_DEFAULT);
    /// ]|
    ///
    /// will cause the property named "property-b" of @object2 to be updated
    /// every time g_object_set() or the specific accessor changes the value of
    /// the property "property-a" of @object1.
    ///
    /// It is possible to create a bidirectional binding between two properties
    /// of two #GObject instances, so that if either property changes, the
    /// other is updated as well, for instance:
    ///
    /// |[&lt;!-- language="C" --&gt;
    ///   g_object_bind_property (object1, "property-a",
    ///                           object2, "property-b",
    ///                           G_BINDING_BIDIRECTIONAL);
    /// ]|
    ///
    /// will keep the two properties in sync.
    ///
    /// It is also possible to set a custom transformation function (in both
    /// directions, in case of a bidirectional binding) to apply a custom
    /// transformation from the source value to the target value before
    /// applying it; for instance, the following binding:
    ///
    /// |[&lt;!-- language="C" --&gt;
    ///   g_object_bind_property_full (adjustment1, "value",
    ///                                adjustment2, "value",
    ///                                G_BINDING_BIDIRECTIONAL,
    ///                                celsius_to_fahrenheit,
    ///                                fahrenheit_to_celsius,
    ///                                NULL, NULL);
    /// ]|
    ///
    /// will keep the "value" property of the two adjustments in sync; the
    /// @celsius_to_fahrenheit function will be called whenever the "value"
    /// property of @adjustment1 changes and will transform the current value
    /// of the property before applying it to the "value" property of @adjustment2.
    ///
    /// Vice versa, the @fahrenheit_to_celsius function will be called whenever
    /// the "value" property of @adjustment2 changes, and will transform the
    /// current value of the property before applying it to the "value" property
    /// of @adjustment1.
    ///
    /// Note that #GBinding does not resolve cycles by itself; a cycle like
    ///
    /// |[
    ///   object1:propertyA -&gt; object2:propertyB
    ///   object2:propertyB -&gt; object3:propertyC
    ///   object3:propertyC -&gt; object1:propertyA
    /// ]|
    ///
    /// might lead to an infinite loop. The loop, in this particular case,
    /// can be avoided if the objects emit the #GObject::notify signal only
    /// if the value has effectively been changed. A binding is implemented
    /// using the #GObject::notify signal, so it is susceptible to all the
    /// various ways of blocking a signal emission, like g_signal_stop_emission()
    /// or g_signal_handler_block().
    ///
    /// A binding will be severed, and the resources it allocates freed, whenever
    /// either one of the #GObject instances it refers to are finalized, or when
    /// the #GBinding instance loses its last reference.
    ///
    /// Bindings for languages with garbage collection can use
    /// g_binding_unbind() to explicitly release a binding between the source
    /// and target properties, instead of relying on the last reference on the
    /// binding, source, and target instances to drop.
    /// </remarks>
    [Since ("2.26")]
    [GType ("GBinding", IsProxyForUnmanagedType = true)]
    public sealed class Binding : Object
    {
        public Binding (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_binding_get_type ();

        static GType getGType ()
        {
            var ret = g_binding_get_type ();
            return ret;
        }

        /// <summary>
        /// Retrieves the flags passed when constructing the #GBinding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the #GBindingFlags used by the #GBinding
        /// </returns>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="BindingFlags" type="GBindingFlags" managed-name="BindingFlags" /> */
        /* transfer-ownership:none */
        static extern BindingFlags g_binding_get_flags (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Gets the flags passed when constructing the <see cref="T:Binding"/>.
        /// </summary>
        /// <value>
        /// the <see cref="T:BindingFlags"/> used by the <see cref="T:Binding"/>
        /// </value>
        [GTypeProperty ("flags")]
        [Since ("2.26")]
        public BindingFlags Flags {
            get {
                AssertNotDisposed ();
                var ret = g_binding_get_flags (handle);
                return ret;
            }
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the source of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the source #GObject
        /// </returns>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" managed-name="Object" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_binding_get_source (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Retrieves the <see cref="T:Object"/> instance used as the source of the binding.
        /// </summary>
        /// <returns>
        /// the source <see cref="T:Object"/>
        /// </returns>
        [GTypeProperty ("source")]
        [Since ("2.26")]
        public Object Source {
            get {
                AssertNotDisposed ();
                var ret_ = g_binding_get_source (handle);
                var ret = Object.GetInstance(ret_, Transfer.None);
                return ret;
            }
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
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_binding_get_source_property (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Retrieves the name of the property of <see cref="P:Source"/> used as the source
        /// of the binding.
        /// </summary>
        /// <returns>
        /// the name of the source property
        /// </returns>
        [GTypeProperty ("source-property")]
        [Since ("2.26")]
        public string SourceProperty {
            get {
                AssertNotDisposed ();
                var ret_ = g_binding_get_source_property (handle);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the target of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the target #GObject
        /// </returns>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" managed-name="Object" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_binding_get_target (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Retrieves the <see cref="T:Object"/> instance used as the target of the binding.
        /// </summary>
        /// <returns>
        /// the target <see cref="T:Object"/>
        /// </returns>
        [GTypeProperty ("target")]
        [Since ("2.26")]
        public Object Target {
            get {
                AssertNotDisposed ();
                var ret_ = g_binding_get_target (handle);
                var ret = Object.GetInstance(ret_, Transfer.None);
                return ret;
            }
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
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_binding_get_target_property (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Retrieves the name of the property of <see cref="P:Target"/> used as the target
        /// of the binding.
        /// </summary>
        /// <returns>
        /// the name of the target property
        /// </returns>
        [GTypeProperty ("target-property")]
        [Since ("2.26")]
        public string TargetProperty {
            get {
                AssertNotDisposed ();
                var ret_ = g_binding_get_target_property (handle);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        /// <summary>
        /// Explicitly releases the binding between the source and the target
        /// property expressed by @binding.
        /// </summary>
        /// <remarks>
        /// This function will release the reference that is being held on
        /// the @binding instance; if you want to hold on to the #GBinding instance
        /// after calling g_binding_unbind(), you will need to hold a reference
        /// to it.
        /// </remarks>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        [Since ("2.38")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_binding_unbind (
            /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
            /* transfer-ownership:none */
            IntPtr binding);

        /// <summary>
        /// Explicitly releases the binding between the source and the target
        /// property expressed by this instance.
        /// </summary>
        [Since ("2.38")]
        public void Unbind ()
        {
            AssertNotDisposed ();
            // Note: this releases a reference to handle
            g_binding_unbind (handle);
            handle = IntPtr.Zero;
        }
    }
}
