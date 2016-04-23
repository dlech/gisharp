using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
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
    public abstract class ParamSpec : ReferenceCountedOpaque
    {
        /// <summary>
        /// All other fields of the GParamSpec struct are private and should not be used directly.
        /// </summary>
        struct ParamSpec_
        {
            /// <summary>
            /// private GTypeInstance portion
            /// </summary>
            public TypeInstance.TypeInstance_ GTypeInstance;

            /// <summary>
            /// name of this parameter: always an interned string
            /// </summary>
            public IntPtr Name;

            /// <summary>
            /// GParamFlags flags for this parameter
            /// </summary>
            public ParamFlags Flags;

            /// <summary>
            /// the GValue type for this parameter
            /// </summary>
            public GType ValueType;

            /// <summary>
            /// GType type that uses (introduces) this parameter
            /// </summary>
            public GType OwnerType;
        }


        /// <summary>
        /// The <see cref="Value"/> type for this parameter
        /// </summary>
        internal ParamFlags Flags {
            get {
                var offset = Marshal.OffsetOf<ParamSpec_> (nameof (ParamSpec_.Flags));
                var flags = Marshal.ReadInt32 (Handle, (int)offset);

                return (ParamFlags)flags;
            }
        }

        /// <summary>
        /// The <see cref="Value"/> type for this parameter
        /// </summary>
        public GType ValueType {
            get {
                var offset = Marshal.OffsetOf<ParamSpec_> (nameof (ParamSpec_.ValueType));
                var type = Marshal.ReadIntPtr (Handle, (int)offset);
                var gtype = new GType (type);

                return gtype;
            }
        }

        /// <summary>
        /// <see cref="GType"/> type that uses (introduces) this parameter
        /// </summary>
        public GType OwnerType {
            get {
                var offset = Marshal.OffsetOf<ParamSpec_> (nameof (ParamSpec_.OwnerType));
                var type = Marshal.ReadIntPtr (Handle, (int)offset);
                var gtype = new GType (type);

                return gtype;
            }
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

        public ParamSpecBoolean (string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boolean (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            bool defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_boolean (namePtr, nickPtr, blurbPtr, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecBoxed (string name, string nick, string blurb, GType boxedType, ParamFlags flags)
            : this (New (name, nick, blurb, boxedType, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boxed (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType boxedType,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType boxedType, ParamFlags flags)
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
            if (!boxedType.IsA (GType.Boxed)) {
                throw new ArgumentException ("Expecting boxed type.", nameof (boxedType));
            }
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);;
            var pspecPtr = g_param_spec_boxed(namePtr, nickPtr, blurbPtr, boxedType, flags);

            return pspecPtr;
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

        public ParamSpecChar (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_char (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            sbyte min,
            sbyte max,
            sbyte defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_char (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for character properties.
    /// </summary>
    [GType (Name = "GParamUChar", IsWrappedNativeType = true)]
    sealed class ParamSpecUChar : ParamSpec
    {
        ParamSpecUChar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUChar (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uchar (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            byte min,
            byte max,
            byte defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_uchar (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecDouble (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_double (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            double min,
            double max,
            double defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_double (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecEnum (string name, string nick, string blurb, GType enumType, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, enumType, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_enum (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType enumType,
            int defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType enumType, int defaultValue, ParamFlags flags)
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
            if (!enumType.IsA (GType.Enum)) {
                throw new ArgumentException ("Expecting an enum type", nameof (enumType));
            }
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_enum (namePtr, nickPtr, blurbPtr, enumType, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecFlags (string name, string nick, string blurb, GType flagsType, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, flagsType, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_flags (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType flagsType,
            int defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType flagsType, int defaultValue, ParamFlags flags)
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
            if (!flagsType.IsA (GType.Flags)) {
                throw new ArgumentException ("Expecting an enum type", nameof (flagsType));
            }
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_flags(namePtr, nickPtr, blurbPtr, flagsType, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecFloat (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_float (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            float min,
            float max,
            float defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_float (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecGType (string name, string nick, string blurb, GType isAType, ParamFlags flags)
            : this (New (name, nick, blurb, isAType, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_gtype (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType isAType,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType isAType, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_gtype (namePtr, nickPtr, blurbPtr, isAType, flags);

            return pspecPtr;
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

        public ParamSpecInt (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            int min,
            int max,
            int defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_int (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType (Name = "GParamUInt", IsWrappedNativeType = true)]
    sealed class ParamSpecUInt : ParamSpec
    {
        ParamSpecUInt (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUInt (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint min,
            uint max,
            uint defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_uint (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecInt64 (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int64 (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            long min,
            long max,
            long defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_int64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType (Name = "GParamUInt64", IsWrappedNativeType = true)]
    sealed class ParamSpecUInt64 : ParamSpec
    {
        ParamSpecUInt64 (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUInt64 (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint64 (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ulong min,
            ulong max,
            ulong defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_uint64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
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

        public ParamSpecLong (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_long (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nlong min,
            nlong max,
            nlong defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_long (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType (Name = "GParamULong", IsWrappedNativeType = true)]
    sealed class ParamSpecULong : ParamSpec
    {
        ParamSpecULong (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecULong (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_ulong (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nulong min,
            nulong max,
            nulong defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_ulong (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for string properties.
    /// </summary>
    [GType (Name = "GParamString", IsWrappedNativeType = true)]
    sealed class ParamSpecString : ParamSpec
    {
        ParamSpecString (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecString (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_string (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var defaultValuePtr = MarshalG.StringToUtf8Ptr (defaultValue);
            var pspecPtr = g_param_spec_string (namePtr, nickPtr, blurbPtr, defaultValuePtr, flags);

            return pspecPtr;
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

        public ParamSpecObject (string name, string nick, string blurb, GType objectType, ParamFlags flags)
            : this (New (name, nick, blurb, objectType, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_object (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType objectType,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType objectType, ParamFlags flags)
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
            if (!objectType.IsA (GType.Object)) {
                throw new ArgumentException ("Expecting object type.", nameof (objectType));
            }
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);;
            var pspecPtr = g_param_spec_object(namePtr, nickPtr, blurbPtr, objectType, flags);

            return pspecPtr;
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

        public ParamSpecParam (string name, string nick, string blurb, GType paramType, ParamFlags flags)
            : this (New (name, nick, blurb, paramType, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_param (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType paramType,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, GType paramType, ParamFlags flags)
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
            if (!paramType.IsA (GType.Param)) {
                throw new ArgumentException ("Expecting param type.", nameof (paramType));
            }
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);;
            var pspecPtr = g_param_spec_param (namePtr, nickPtr, blurbPtr, paramType, flags);

            return pspecPtr;
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

        public ParamSpecPointer (string name, string nick, string blurb,ParamFlags flags)
            : this (New (name, nick, blurb, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_pointer (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);;
            var pspecPtr = g_param_spec_pointer(namePtr, nickPtr, blurbPtr, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for character properties.
    /// </summary>
    [GType (Name = "GParamUnichar", IsWrappedNativeType = true)]
    sealed class ParamSpecUnichar : ParamSpec
    {
        ParamSpecUnichar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUnichar (string name, string nick, string blurb, uint defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_unichar (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, uint defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_unichar (namePtr, nickPtr, blurbPtr, defaultValue, flags);

            return pspecPtr;
        }
    }

    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for character properties.
    /// </summary>
    [GType (Name = "GParamValueArray", IsWrappedNativeType = true)]
    sealed class ParamSpecValueArray : ParamSpec
    {
        ParamSpecValueArray (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecValueArray (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
            : this (New (name, nick, blurb, elementSpec, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_value_array (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr elementSpec,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_value_array (namePtr, nickPtr, blurbPtr, elementSpec.Handle, flags);

            return pspecPtr;
        }
    }

    /* TODO: Need to move Variant to Core
    /// <summary>
    /// A #GParamSpec derived structure that contains the meta data for character properties.
    /// </summary>
    [GType (Name = "GParamVariant", IsWrappedNativeType = true)]
    sealed class ParamSpecVariant : ParamSpec
    {
        ParamSpecVariant (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecVariant (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, type, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        IntPtr g_param_spec_variant (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            VariantType type,
            Variant defaultValue,
            ParamFlags flags);


        static IntPtr New (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
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
            var namePtr = MarshalG.StringToUtf8Ptr (name);
            var nickPtr = MarshalG.StringToUtf8Ptr (nick);
            var blurbPtr = MarshalG.StringToUtf8Ptr (blurb);
            var pspecPtr = g_param_spec_variant (namePtr, nickPtr, blurbPtr, type, defaultValue, flags);

            return pspecPtr;
        }
    }
    */
}
