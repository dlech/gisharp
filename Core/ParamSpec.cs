using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    /// <summary>
    /// #GParamSpec is an object structure that encapsulates the metadata
    /// required to specify parameters, such as e.g. #GObject properties.
    /// </summary>
    /// <remarks>
    /// ## Parameter names # {#canonical-parameter-names}
    /// 
    /// Parameter names need to start with a letter (a-z or A-Z).
    /// Subsequent characters can be letters, numbers or a '-'.
    /// All other characters are replaced by a '-' during construction.
    /// The result of this replacement is called the canonical name of
    /// the parameter.
    /// </remarks>
    [GType (Name = "GParam", IsWrappedNativeType = true)]
    abstract class ParamSpec : ReferenceCountedOpaque
    {
        /// <summary>
        /// Creates a new #GParamSpec instance.
        /// </summary>
        /// <remarks>
        /// A property name consists of segments consisting of ASCII letters and
        /// digits, separated by either the '-' or '_' character. The first
        /// character of a property name must be a letter. Names which violate these
        /// rules lead to undefined behaviour.
        /// 
        /// When creating and looking up a #GParamSpec, either separator can be
        /// used, but they cannot be mixed. Using '-' is considerably more
        /// efficient and in fact required when using property names as detail
        /// strings for signals.
        /// 
        /// Beyond the name, #GParamSpecs have two more descriptive
        /// strings associated with them, the @nick, which should be suitable
        /// for use as a label for the property in a property editor, and the
        /// @blurb, which should be a somewhat longer description, suitable for
        /// e.g. a tooltip. The @nick and @blurb should ideally be localized.
        /// </remarks>
        /// <param name="paramType">
        /// the #GType for the property; must be derived from #G_TYPE_PARAM
        /// </param>
        /// <param name="name">
        /// the canonical name of the property
        /// </param>
        /// <param name="nick">
        /// the nickname of the property
        /// </param>
        /// <param name="blurb">
        /// a short description of the property
        /// </param>
        /// <param name="flags">
        /// a combination of #GParamFlags
        /// </param>
        /// <returns>
        /// a newly allocated #GParamSpec instance
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_param_spec_internal (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType paramType,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr nick,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr blurb,
            /* <type name="ParamFlags" type="GParamFlags" managed-name="ParamFlags" /> */
            /* transfer-ownership:none */
            ParamFlags flags);

        /// <summary>
        /// Creates a new #GParamSpec instance.
        /// </summary>
        /// <remarks>
        /// A property name consists of segments consisting of ASCII letters and
        /// digits, separated by either the '-' or '_' character. The first
        /// character of a property name must be a letter. Names which violate these
        /// rules lead to undefined behaviour.
        /// 
        /// When creating and looking up a #GParamSpec, either separator can be
        /// used, but they cannot be mixed. Using '-' is considerably more
        /// efficient and in fact required when using property names as detail
        /// strings for signals.
        /// 
        /// Beyond the name, #GParamSpecs have two more descriptive
        /// strings associated with them, the @nick, which should be suitable
        /// for use as a label for the property in a property editor, and the
        /// @blurb, which should be a somewhat longer description, suitable for
        /// e.g. a tooltip. The @nick and @blurb should ideally be localized.
        /// </remarks>
        /// <param name="paramType">
        /// the #GType for the property; must be derived from #G_TYPE_PARAM
        /// </param>
        /// <param name="name">
        /// the canonical name of the property
        /// </param>
        /// <param name="nick">
        /// the nickname of the property
        /// </param>
        /// <param name="blurb">
        /// a short description of the property
        /// </param>
        /// <param name="flags">
        /// a combination of #GParamFlags
        /// </param>
        /// <returns>
        /// a newly allocated #GParamSpec instance
        /// </returns>
        public static IntPtr Internal (GType paramType, string name, string nick, string blurb, ParamFlags flags)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            if (nick == null) {
                throw new ArgumentNullException (nameof (nick));
            }
            if (blurb == null) {
                throw new ArgumentNullException (nameof (blurb));
            }
            var name_ = MarshalG.StringToUtf8Ptr (name);
            var nick_ = MarshalG.StringToUtf8Ptr (nick);
            var blurb_ = MarshalG.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_internal (paramType, name_, nick_, blurb_, flags);
            MarshalG.Free (name_);
            MarshalG.Free (nick_);
            MarshalG.Free (blurb_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_blurb (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the short description of a #GParamSpec.
        /// </summary>
        /// <returns>
        /// the short description of @pspec.
        /// </returns>
        public string Blurb {
            get {
                AssertNotDisposed ();
                var ret_ = g_param_spec_get_blurb (Handle);
                var ret = MarshalG.Utf8PtrToString (ret_, false);
                return ret;
            }
        }

        /// <summary>
        /// Gets the default value of @pspec as a pointer to a #GValue.
        /// </summary>
        /// <remarks>
        /// The #GValue will remain value for the life of @pspec.
        /// </remarks>
        /// <returns>
        /// a pointer to a #GValue which must not be modified
        /// </returns>
        [SinceAttribute ("2.38")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_default_value (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr param);

        /// <summary>
        /// Gets the default value of @pspec as a pointer to a #GValue.
        /// </summary>
        /// <remarks>
        /// The #GValue will remain value for the life of @pspec.
        /// </remarks>
        /// <returns>
        /// a pointer to a #GValue which must not be modified
        /// </returns>
        [SinceAttribute ("2.38")]
        public Value DefaultValue {
            get {
                AssertNotDisposed ();
                var ret_ = g_param_spec_get_default_value (Handle);
                var ret = Opaque.GetInstance<Value> (ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Get the name of a #GParamSpec.
        /// </summary>
        /// <remarks>
        /// The name is always an "interned" string (as per g_intern_string()).
        /// This allows for pointer-value comparisons.
        /// </remarks>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the name of @pspec.
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_name (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the name of a #GParamSpec.
        /// </summary>
        /// <remarks>
        /// The name is always an "interned" string (as per g_intern_string()).
        /// This allows for pointer-value comparisons.
        /// </remarks>
        /// <returns>
        /// the name of @pspec.
        /// </returns>
        public string Name {
            get {
                AssertNotDisposed ();
                var ret_ = g_param_spec_get_name (Handle);
                var ret = MarshalG.Utf8PtrToString (ret_, false);
                return ret;
            }
        }

        /// <summary>
        /// Gets the GQuark for the name.
        /// </summary>
        /// <param name="param">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// the GQuark for @pspec-&gt;name.
        /// </returns>
        //[SinceAttribute ("2.46")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        ///* transfer-ownership:none */
        //static extern GISharp.GLib.Quark g_param_spec_get_name_quark (
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none */
        //    IntPtr param);

        /// <summary>
        /// Gets the GQuark for the name.
        /// </summary>
        /// <returns>
        /// the GQuark for @pspec-&gt;name.
        /// </returns>
        //[SinceAttribute ("2.46")]
        //public GISharp.GLib.Quark NameQuark {
        //    get {
        //        AssertNotDisposed ();
        //        var ret = g_param_spec_get_name_quark (Handle);
        //        return ret;
        //    }
        //}

        /// <summary>
        /// Get the nickname of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the nickname of @pspec.
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_nick (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the nickname of a #GParamSpec.
        /// </summary>
        /// <returns>
        /// the nickname of @pspec.
        /// </returns>
        public string Nick {
            get {
                AssertNotDisposed ();
                var ret_ = g_param_spec_get_nick (Handle);
                var ret = MarshalG.Utf8PtrToString (ret_, false);
                return ret;
            }
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
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        ///* transfer-ownership:none */
        //static extern IntPtr g_param_spec_get_qdata (
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none */
        //    IntPtr pspec,
        //    /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        //    /* transfer-ownership:none */
        //    GISharp.GLib.Quark quark);

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata().
        /// </summary>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        //public IntPtr GetQdata (GISharp.GLib.Quark quark)
        //{
        //    AssertNotDisposed ();
        //    var ret = g_param_spec_get_qdata (Handle, quark);
        //    return ret;
        //}

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
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_redirect_target (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type #GParamSpecOverride. See g_object_class_override_property()
        /// for an example of the use of this capability.
        /// </summary>
        /// <returns>
        /// paramspec to which requests on this
        ///          paramspec should be redirected, or %NULL if none.
        /// </returns>
        [SinceAttribute ("2.4")]
        public ParamSpec RedirectTarget {
            get {
                AssertNotDisposed ();
                var ret_ = g_param_spec_get_redirect_target (Handle);
                var ret = Opaque.GetInstance<ParamSpec> (ret_, Transfer.None);
                return ret;
            }
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* skip:1 */
        static extern IntPtr g_param_spec_ref (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Increments the reference count of @pspec.
        /// </summary>
        protected internal override void Ref ()
        {
            AssertNotDisposed ();
            g_param_spec_ref (Handle);
        }

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
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_param_spec_set_qdata (
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none */
        //    IntPtr pspec,
        //    /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        //    /* transfer-ownership:none */
        //    GISharp.GLib.Quark quark,
        //    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none */
        //    IntPtr data);

        /// <summary>
        /// Sets an opaque, named pointer on a #GParamSpec. The name is
        /// specified through a #GQuark (retrieved e.g. via
        /// g_quark_from_static_string()), and the pointer can be gotten back
        /// from the @pspec with g_param_spec_get_qdata().  Setting a
        /// previously set user data pointer, overrides (frees) the old pointer
        /// set, using %NULL as pointer essentially removes the data stored.
        /// </summary>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <param name="data">
        /// an opaque user data pointer
        /// </param>
        //public void SetQdata (GISharp.GLib.Quark quark, IntPtr data)
        //{
        //    AssertNotDisposed ();
        //    g_param_spec_set_qdata (Handle, quark, data);
        //}

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
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_param_spec_set_qdata_full (
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none */
        //    IntPtr pspec,
        //    /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        //    /* transfer-ownership:none */
        //    GISharp.GLib.Quark quark,
        //    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none */
        //    IntPtr data,
        //    /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GLib.DestroyNotify" /> */
        //    /* transfer-ownership:none scope:async */
        //    NativeDestroyNotify destroy);

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
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        ///* transfer-ownership:none */
        //static extern IntPtr g_param_spec_steal_qdata (
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none */
        //    IntPtr pspec,
        //    /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        //    /* transfer-ownership:none */
        //    GISharp.GLib.Quark quark);

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata()
        /// and removes the @data from @pspec without invoking its destroy()
        /// function (if any was set).  Usually, calling this function is only
        /// required to update user data pointers with a destroy notifier.
        /// </summary>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        //public IntPtr StealQdata (GISharp.GLib.Quark quark)
        //{
        //    AssertNotDisposed ();
        //    var ret = g_param_spec_steal_qdata (Handle, quark);
        //    return ret;
        //}

        /// <summary>
        /// Decrements the reference count of a @pspec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_param_spec_unref (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Decrements the reference count of a @pspec.
        /// </summary>
        protected internal override void Unref ()
        {
            AssertNotDisposed ();
            g_param_spec_unref (Handle);
        }

        protected ParamSpec (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for boolean properties.
    /// </summary>
    [GType (Name = "GParamBoolean", IsWrappedNativeType = true)]
    sealed class ParamSpecBoolean : ParamSpec
    {
        ParamSpecBoolean (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for boxed properties.
    /// </summary>
    [GType (Name = "GParamBoxed", IsWrappedNativeType = true)]
    sealed class ParamSpecBoxed : ParamSpec
    {
        ParamSpecBoxed (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for character properties.
    /// </summary>
    [GType (Name = "GParamChar", IsWrappedNativeType = true)]
    sealed class ParamSpecChar : ParamSpec
    {
        ParamSpecChar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for double properties.
    /// </summary>
    [GType (Name = "GParamDouble", IsWrappedNativeType = true)]
    sealed class ParamSpecDouble : ParamSpec
    {
        ParamSpecDouble (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for enum
    /// properties.
    /// </summary>
    [GType (Name = "GParamEnum", IsWrappedNativeType = true)]
    sealed class ParamSpecEnum : ParamSpec
    {
        ParamSpecEnum (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for flags
    /// properties.
    /// </summary>
    [GType (Name = "GParamFlags", IsWrappedNativeType = true)]
    sealed class ParamSpecFlags : ParamSpec
    {
        ParamSpecFlags (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for float properties.
    /// </summary>
    [GType (Name = "GParamFloat", IsWrappedNativeType = true)]
    sealed class ParamSpecFloat : ParamSpec
    {
        ParamSpecFloat (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for #GType properties.
    /// </summary>
    [SinceAttribute ("2.10")]
    [GType (Name = "GParamGType", IsWrappedNativeType = true)]
    sealed class ParamSpecGType : ParamSpec
    {
        ParamSpecGType (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType (Name = "GParamInt", IsWrappedNativeType = true)]
    sealed class ParamSpecInt : ParamSpec
    {
        ParamSpecInt (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType (Name = "GParamInt64", IsWrappedNativeType = true)]
    sealed class ParamSpecInt64 : ParamSpec
    {
        ParamSpecInt64 (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType (Name = "GParamLong", IsWrappedNativeType = true)]
    sealed class ParamSpecLong : ParamSpec
    {
        ParamSpecLong (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for object properties.
    /// </summary>
    [GType (Name = "GParamObject", IsWrappedNativeType = true)]
    sealed class ParamSpecObject : ParamSpec
    {
        ParamSpecObject (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// This is a type of #GParamSpec type that simply redirects operations to
    /// another paramspec.  All operations other than getting or
    /// setting the value are redirected, including accessing the nick and
    /// blurb, validating a value, and so forth. See
    /// g_param_spec_get_redirect_target() for retrieving the overidden
    /// property. #GParamSpecOverride is used in implementing
    /// g_object_class_override_property(), and will not be directly useful
    /// unless you are implementing a new base type similar to GObject.
    /// </summary>
    [SinceAttribute ("2.4")]
    [GType (Name = "GParamOverride", IsWrappedNativeType = true)]
    sealed class ParamSpecOverride : ParamSpec
    {
        ParamSpecOverride (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for %G_TYPE_PARAM
    /// properties.
    /// </summary>
    [GType (Name = "GParamParam", IsWrappedNativeType = true)]
    sealed class ParamSpecParam : ParamSpec
    {
        ParamSpecParam (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for pointer properties.
    /// </summary>
    [GType (Name = "GParamPointer", IsWrappedNativeType = true)]
    sealed class ParamSpecPointer : ParamSpec
    {
        ParamSpecPointer (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// Through the #GParamFlags flag values, certain aspects of parameters
    /// can be configured. See also #G_PARAM_STATIC_STRINGS.
    /// </summary>
    [Flags]
    enum ParamFlags
    {
        /// <summary>
        /// the parameter is readable
        /// </summary>
        Readable = 1,

        /// <summary>
        /// the parameter is writable
        /// </summary>
        Writable = 2,

        /// <summary>
        /// alias for <see cref="Readable"/> | <see cref="Writable"/>
        /// </summary>
        Readwrite = 3,

        /// <summary>
        /// the parameter will be set upon object construction
        /// </summary>
        Construct = 4,

        /// <summary>
        /// the parameter can only be set upon object construction
        /// </summary>
        ConstructOnly = 8,

        /// <summary>
        /// upon parameter conversion (see g_param_value_convert())
        ///  strict validation is not required
        /// </summary>
        LaxValidation = 16,

        /// <summary>
        /// the string used as name when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticName = 32,

        ///// <summary>
        ///// internal
        ///// </summary>
        //Private = 32,
        /// <summary>
        /// the string used as nick when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticNick = 64,

        /// <summary>
        /// the string used as blurb when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticBlurb = 128,

        /// <summary>
        /// calls to g_object_set_property() for this
        ///   property will not automatically result in a "notify" signal being
        ///   emitted: the implementation must call g_object_notify() themselves
        ///   in case the property actually changes.
        /// </summary>
        [Since ("2.42")]
        ExplicitNotify = 1073741824,

        /// <summary>
        /// the parameter is deprecated and will be removed
        ///  in a future version. A warning will be generated if it is used
        ///  while running with G_ENABLE_DIAGNOSTIC=1.
        /// </summary>
        [Since ("2.26")]
        Deprecated = -2147483648,

        /// <summary>
        /// Mask containing the bits of #GParamSpec.flags which are reserved for GLib.
        /// </summary>
        ParamMask = 255,

        /// <summary>
        /// #GParamFlags value alias for %G_PARAM_STATIC_NAME | %G_PARAM_STATIC_NICK | %G_PARAM_STATIC_BLURB.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [Since ("2.13")]
        ParamStaticStrings = 0,

        /// <summary>
        /// Minimum shift count to be used for user defined flags, to be stored in
        /// #GParamSpec.flags. The maximum allowed is 10.
        /// </summary>
        ParamUserShift = 8
    }
}
