using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    /// <summary>
    /// The class structure for the GObject type.
    /// </summary>
    /// <remarks>
    /// &lt;example&gt;
    /// &lt;title&gt;Implementing singletons using a constructor&lt;/title&gt;
    /// &lt;programlisting&gt;
    /// static MySingleton *the_singleton = NULL;
    ///
    /// static GObject*
    /// my_singleton_constructor (GType                  type,
    ///                           guint                  n_construct_params,
    ///                           GObjectConstructParam *construct_params)
    /// {
    ///   GObject *object;
    ///
    ///   if (!the_singleton)
    ///     {
    ///       object = G_OBJECT_CLASS (parent_class)-&gt;constructor (type,
    ///                                                            n_construct_params,
    ///                                                            construct_params);
    ///       the_singleton = MY_SINGLETON (object);
    ///     }
    ///   else
    ///     object = g_object_ref (G_OBJECT (the_singleton));
    ///
    ///   return object;
    /// }
    /// &lt;/programlisting&gt;&lt;/example&gt;
    /// </remarks>
    class ObjectClass : TypeClass
    {
        struct ObjectClass_
        {
            public TypeClass.TypeClass_ GTypeClass;

            IntPtr constructProperties;

            /* seldom overidden */
            public NativeConstructor Constructor;
            /* overridable methods */
            public NativeSetProperty SetProperty;
            public NativeGetProperty GetProperty;
            public NativeDispose Dispose;
            public NativeFinalize Finalize;
            /* seldom overidden */
            public NativeDispatchPropertiesChanged DispatchPropertiesChanged;
            /* signals */
            public NativeNotify Notify;

            /* called when done constructing */
            public NativeConstructed Constructed;

            ulong flags;
            IntPtr pdummy;

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate IntPtr NativeConstructor (GType type, uint nConstructProperties, IntPtr constructProperties);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeSetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeGetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeDispose (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeFinalize (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeDispatchPropertiesChanged (IntPtr @object, uint nPspecs, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeNotify (IntPtr @object, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeConstructed (IntPtr @object);
        }

        internal static void InitManagedClass (IntPtr classPtr, IntPtr userDataPtr)
        {
            var type = (Type)GCHandle.FromIntPtr (userDataPtr).Target;
            var propId = 1u; // id 0 is special, so start with 1

            var test1 = Marshal.SizeOf<TypeClass.TypeClass_> ();
            var test2 = Marshal.SizeOf<ObjectClass_> ();

            Marshal.WriteIntPtr (classPtr,
                (int)Marshal.OffsetOf<ObjectClass_> (nameof (ObjectClass_.SetProperty)),
                Marshal.GetFunctionPointerForDelegate<ObjectClass_.NativeSetProperty> (SetPropertyManagedClass));
            Marshal.WriteIntPtr (classPtr,
                (int)Marshal.OffsetOf<ObjectClass_> (nameof (ObjectClass_.GetProperty)),
                Marshal.GetFunctionPointerForDelegate<ObjectClass_.NativeSetProperty> (GetPropertyManagedClass));

            foreach (var propInfo in type.GetProperties ()) {
                var propAttr = propInfo.GetCustomAttributes (false)
                    .OfType<PropertyAttribute> ()
                    .SingleOrDefault ();
                if (propAttr == null) {
                    continue;
                }
                // TODO: convert propInfo.Name to a more glib friendly name.
                // e.g. "MyProperty" becomes "my-property"
                var name = propAttr.Name ?? propInfo.Name;
                var nick = propInfo.GetCustomAttributes (false)
                    .OfType <DisplayNameAttribute> ()
                    .SingleOrDefault ()?.DisplayName ?? name;
                var blurb = propInfo.GetCustomAttributes (false)
                    .OfType <DescriptionAttribute> ()
                    .SingleOrDefault ()?.Description ?? nick;
                // TODO: localize strings
                var defaultValue = propInfo.GetCustomAttributes (false)
                    .OfType<DefaultValueAttribute> ()
                    .SingleOrDefault ()?.Value;
                var flags = default(ParamFlags);
                if (propInfo.CanRead) {
                    flags |= ParamFlags.Readable;
                }
                if (propInfo.CanWrite) {
                    flags |= ParamFlags.Writable;
                }
                // TODO: How to handle construct properties?
                flags |= ParamFlags.StaticName;
                flags |= ParamFlags.StaticNick;
                flags |= ParamFlags.StaticBlurb;
                // TODO: how to handle explicit notify?
                if (propInfo.CustomAttributes.OfType <ObsoleteAttribute> ().Any ()) {
                    flags |= ParamFlags.Deprecated;
                }
                ParamSpec pspec;
                // TODO: Need to create special boxed type for non-GType objects
                var propertyGType = (GType)propInfo.PropertyType;
                var fundamentalGType = propertyGType.Fundamental;
                if (fundamentalGType == GType.Boolean) {
                    pspec = new ParamSpecBoolean (name, nick, blurb, (bool)defaultValue, flags);
                } else if (fundamentalGType == GType.Boxed) {
                    pspec = new ParamSpecBoxed (name, nick, blurb, propertyGType, flags);
                } else if (fundamentalGType == GType.Char) {
                    pspec = new ParamSpecChar (name, nick, blurb, sbyte.MinValue, sbyte.MaxValue, (sbyte)(defaultValue ?? default(sbyte)), flags);
                } else if (fundamentalGType == GType.UChar) {
                    pspec = new ParamSpecUChar (name, nick, blurb, byte.MinValue, byte.MaxValue, (byte)(defaultValue ?? default(byte)), flags);
                } else if (fundamentalGType == GType.Double) {
                    pspec = new ParamSpecDouble (name, nick, blurb, double.MinValue, double.MaxValue, (double)(defaultValue ?? default(double)), flags);
                } else if (fundamentalGType == GType.Float) {
                    pspec = new ParamSpecFloat (name, nick, blurb, float.MinValue, float.MaxValue, (float)(defaultValue ?? default(float)), flags);
                } else if (fundamentalGType == GType.Enum) {
                    pspec = new ParamSpecEnum (name, nick, blurb, propertyGType, (int)defaultValue, flags);
                } else if (fundamentalGType == GType.Flags) {
                    pspec = new ParamSpecFlags (name, nick, blurb, propertyGType, (int)defaultValue, flags);
                } else if (fundamentalGType == GType.Int) {
                    pspec = new ParamSpecInt (name, nick, blurb, int.MinValue, int.MaxValue, (int)(defaultValue ?? default(int)), flags);
                } else if (fundamentalGType == GType.UInt) {
                    pspec = new ParamSpecUInt (name, nick, blurb, uint.MinValue, uint.MaxValue, (uint)(defaultValue ?? default(uint)), flags);
                } else if (fundamentalGType == GType.Int64) {
                    pspec = new ParamSpecInt64 (name, nick, blurb, long.MinValue, long.MaxValue, (long)(defaultValue ?? default(long)), flags);
                } else if (fundamentalGType == GType.UInt64) {
                    pspec = new ParamSpecUInt64 (name, nick, blurb, ulong.MinValue, ulong.MaxValue, (ulong)(defaultValue ?? default(ulong)), flags);
                } else if (fundamentalGType == GType.Long) {
                    pspec = new ParamSpecLong (name, nick, blurb, long.MinValue, long.MaxValue, (long)(defaultValue ?? default(long)), flags);
                } else if (fundamentalGType == GType.ULong) {
                    pspec = new ParamSpecULong (name, nick, blurb, ulong.MinValue, ulong.MaxValue, (ulong)(defaultValue ?? default(ulong)), flags);
                } else if (fundamentalGType == GType.Object) {
                    pspec = new ParamSpecObject (name, nick, blurb, propertyGType, flags);
                }
                // TODO: do we need this one?
//                else if (fundamentalGType == GType.Param) {
//                    pspec = new ParamSpecParam (name, nick, blurb, ?, flags);
//                }
                else if (fundamentalGType == GType.Pointer) {
                    pspec = new ParamSpecPointer (name, nick, blurb, flags);
                } else if (fundamentalGType == GType.String) {
                    pspec = new ParamSpecString (name, nick, blurb, (string)defaultValue, flags);
                } else if (fundamentalGType == GType.Type) {
                    pspec = new ParamSpecGType (name, nick, blurb, propertyGType, flags);
                } else {
                    // TODO: Need more specific exception
                    throw new Exception ("unhandled GType");
                }
                // TODO: create param specs
                g_object_class_install_property (classPtr, propId++, pspec.Handle);
            }
        }

        internal static void SetPropertyManagedClass(IntPtr objPtr, uint propertyId, IntPtr valuePtr, IntPtr pspecPtr)
        {
            var obj = Opaque.GetInstance <Object> (objPtr, Transfer.None);
            var value = Opaque.GetInstance<Value> (valuePtr, Transfer.None);
            var pspec = Opaque.GetInstance<ParamSpec> (pspecPtr, Transfer.None);

            // TODO: need better name matching for looking up properties
            var propInfo = obj.GetType ().GetProperty (pspec.Name);
            propInfo.SetValue (obj, value.Get ());
        }

        internal static void GetPropertyManagedClass(IntPtr objPtr, uint propertyId, IntPtr valuePtr, IntPtr pspecPtr)
        {
            var obj = Opaque.GetInstance <Object> (objPtr, Transfer.None);
            var value = Opaque.GetInstance<Value> (valuePtr, Transfer.None);
            var pspec = Opaque.GetInstance<ParamSpec> (pspecPtr, Transfer.None);

            // TODO: need better name matching for looking up properties
            var propInfo = obj.GetType ().GetProperty (pspec.Name);
            value.Set (propInfo.GetValue (obj));
        }

        /// <summary>
        /// Looks up the #GParamSpec for a property of a class.
        /// </summary>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyName">
        /// the name of the property to look up
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property, or
        ///          %NULL if the class doesn't have a property of that name
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_class_find_property (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName);

        /// <summary>
        /// Looks up the #GParamSpec for a property of a class.
        /// </summary>
        /// <param name="propertyName">
        /// the name of the property to look up
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property, or
        ///          %NULL if the class doesn't have a property of that name
        /// </returns>
        public ParamSpec FindProperty (String propertyName)
        {
            AssertNotDisposed ();
            if (propertyName == null) {
                throw new ArgumentNullException ("propertyName");
            }
            var propertyName_ = MarshalG.StringToUtf8Ptr (propertyName);
            var ret_ = g_object_class_find_property (Handle, propertyName_);
            var ret = Opaque.GetInstance<ParamSpec> (ret_, Transfer.None);
            MarshalG.Free (propertyName_);
            return ret;
        }

        /// <summary>
        /// Installs new properties from an array of #GParamSpecs.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// The property id of each property is the index of each #GParamSpec in
        /// the @pspecs array.
        ///
        /// The property id of 0 is treated specially by #GObject and it should not
        /// be used to store a #GParamSpec.
        ///
        /// This function should be used if you plan to use a static array of
        /// #GParamSpecs and g_object_notify_by_pspec(). For instance, this
        /// class initialization:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// enum {
        ///   PROP_0, PROP_FOO, PROP_BAR, N_PROPERTIES
        /// };
        ///
        /// static GParamSpec *obj_properties[N_PROPERTIES] = { NULL, };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   GObjectClass *gobject_class = G_OBJECT_CLASS (klass);
        ///
        ///   obj_properties[PROP_FOO] =
        ///     g_param_spec_int ("foo", "Foo", "Foo",
        ///                       -1, G_MAXINT,
        ///                       0,
        ///                       G_PARAM_READWRITE);
        ///
        ///   obj_properties[PROP_BAR] =
        ///     g_param_spec_string ("bar", "Bar", "Bar",
        ///                          NULL,
        ///                          G_PARAM_READWRITE);
        ///
        ///   gobject_class-&gt;set_property = my_object_set_property;
        ///   gobject_class-&gt;get_property = my_object_get_property;
        ///   g_object_class_install_properties (gobject_class,
        ///                                      N_PROPERTIES,
        ///                                      obj_properties);
        /// }
        /// ]|
        ///
        /// allows calling g_object_notify_by_pspec() to notify of property changes:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// void
        /// my_object_set_foo (MyObject *self, gint foo)
        /// {
        ///   if (self-&gt;foo != foo)
        ///     {
        ///       self-&gt;foo = foo;
        ///       g_object_notify_by_pspec (G_OBJECT (self), obj_properties[PROP_FOO]);
        ///     }
        ///  }
        /// ]|
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="nPspecs">
        /// the length of the #GParamSpecs array
        /// </param>
        /// <param name="pspecs">
        /// the #GParamSpecs array
        ///   defining the new properties
        /// </param>
        [Since ("2.26")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_properties (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            UInt32 nPspecs,
            /* <array length="0" zero-terminated="0" type="GParamSpec**">
                 <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
               </array> */
            /* transfer-ownership:none */
            IntPtr pspecs);

        /// <summary>
        /// Installs new properties from an array of #GParamSpecs.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// The property id of each property is the index of each #GParamSpec in
        /// the @pspecs array.
        ///
        /// The property id of 0 is treated specially by #GObject and it should not
        /// be used to store a #GParamSpec.
        ///
        /// This function should be used if you plan to use a static array of
        /// #GParamSpecs and g_object_notify_by_pspec(). For instance, this
        /// class initialization:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// enum {
        ///   PROP_0, PROP_FOO, PROP_BAR, N_PROPERTIES
        /// };
        ///
        /// static GParamSpec *obj_properties[N_PROPERTIES] = { NULL, };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   GObjectClass *gobject_class = G_OBJECT_CLASS (klass);
        ///
        ///   obj_properties[PROP_FOO] =
        ///     g_param_spec_int ("foo", "Foo", "Foo",
        ///                       -1, G_MAXINT,
        ///                       0,
        ///                       G_PARAM_READWRITE);
        ///
        ///   obj_properties[PROP_BAR] =
        ///     g_param_spec_string ("bar", "Bar", "Bar",
        ///                          NULL,
        ///                          G_PARAM_READWRITE);
        ///
        ///   gobject_class-&gt;set_property = my_object_set_property;
        ///   gobject_class-&gt;get_property = my_object_get_property;
        ///   g_object_class_install_properties (gobject_class,
        ///                                      N_PROPERTIES,
        ///                                      obj_properties);
        /// }
        /// ]|
        ///
        /// allows calling g_object_notify_by_pspec() to notify of property changes:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// void
        /// my_object_set_foo (MyObject *self, gint foo)
        /// {
        ///   if (self-&gt;foo != foo)
        ///     {
        ///       self-&gt;foo = foo;
        ///       g_object_notify_by_pspec (G_OBJECT (self), obj_properties[PROP_FOO]);
        ///     }
        ///  }
        /// ]|
        /// </remarks>
        /// <param name="pspecs">
        /// the #GParamSpecs array
        ///   defining the new properties
        /// </param>
        [Since ("2.26")]
        public void InstallProperties (ParamSpec[] pspecs)
        {
            AssertNotDisposed ();
            if (pspecs == null) {
                throw new ArgumentNullException ("pspecs");
            }
            var pspecs_ = MarshalG.OpaqueCArrayToPtr<ParamSpec> (pspecs, false);
            var nPspecs_ = (UInt32)(pspecs == null ? 0 : pspecs.Length);
            g_object_class_install_properties (Handle, nPspecs_, pspecs_);
            MarshalG.Free (pspecs_);
        }

        /// <summary>
        /// Installs a new property.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// Note that it is possible to redefine a property in a derived class,
        /// by installing a property with the same name. This can be useful at times,
        /// e.g. to change the range of allowed values or the default value.
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyId">
        /// the id for the new property
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_property (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            UInt32 propertyId,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Installs a new property.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// Note that it is possible to redefine a property in a derived class,
        /// by installing a property with the same name. This can be useful at times,
        /// e.g. to change the range of allowed values or the default value.
        /// </remarks>
        /// <param name="propertyId">
        /// the id for the new property
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        public void InstallProperty (UInt32 propertyId, ParamSpec pspec)
        {
            AssertNotDisposed ();
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            var pspec_ = pspec == null ? IntPtr.Zero : pspec.Handle;
            g_object_class_install_property (Handle, propertyId, pspec_);
        }

        /// <summary>
        /// Get an array of #GParamSpec* for all properties of a class.
        /// </summary>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="nProperties">
        /// return location for the length of the returned array
        /// </param>
        /// <returns>
        /// an array of
        ///          #GParamSpec* which should be freed after use
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="GParamSpec**">
               <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
           </array> */
        /* transfer-ownership:container */
        static extern IntPtr g_object_class_list_properties (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out UInt32 nProperties);

        /// <summary>
        /// Get an array of #GParamSpec* for all properties of a class.
        /// </summary>
        /// <returns>
        /// an array of
        ///          #GParamSpec* which should be freed after use
        /// </returns>
        public ParamSpec[] ListProperties ()
        {
            AssertNotDisposed ();
            UInt32 nProperties_;
            var ret_ = g_object_class_list_properties (Handle, out nProperties_);
            var ret = MarshalG.PtrToOpaqueCArray<ParamSpec> (ret_, (int)nProperties_, true);
            return ret;
        }

        /// <summary>
        /// Registers @property_id as referring to a property with the name
        /// @name in a parent class or in an interface implemented by @oclass.
        /// This allows this class to "override" a property implementation in
        /// a parent class or to provide the implementation of a property from
        /// an interface.
        /// </summary>
        /// <remarks>
        /// Internally, overriding is implemented by creating a property of type
        /// #GParamSpecOverride; generally operations that query the properties of
        /// the object class, such as g_object_class_find_property() or
        /// g_object_class_list_properties() will return the overridden
        /// property. However, in one case, the @construct_properties argument of
        /// the @constructor virtual function, the #GParamSpecOverride is passed
        /// instead, so that the @param_id field of the #GParamSpec will be
        /// correct.  For virtually all uses, this makes no difference. If you
        /// need to get the overridden property, you can call
        /// g_param_spec_get_redirect_target().
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyId">
        /// the new property ID
        /// </param>
        /// <param name="name">
        /// the name of a property registered in a parent class or
        ///  in an interface of this class.
        /// </param>
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_override_property (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            UInt32 propertyId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);

        /// <summary>
        /// Registers @property_id as referring to a property with the name
        /// @name in a parent class or in an interface implemented by @oclass.
        /// This allows this class to "override" a property implementation in
        /// a parent class or to provide the implementation of a property from
        /// an interface.
        /// </summary>
        /// <remarks>
        /// Internally, overriding is implemented by creating a property of type
        /// #GParamSpecOverride; generally operations that query the properties of
        /// the object class, such as g_object_class_find_property() or
        /// g_object_class_list_properties() will return the overridden
        /// property. However, in one case, the @construct_properties argument of
        /// the @constructor virtual function, the #GParamSpecOverride is passed
        /// instead, so that the @param_id field of the #GParamSpec will be
        /// correct.  For virtually all uses, this makes no difference. If you
        /// need to get the overridden property, you can call
        /// g_param_spec_get_redirect_target().
        /// </remarks>
        /// <param name="propertyId">
        /// the new property ID
        /// </param>
        /// <param name="name">
        /// the name of a property registered in a parent class or
        ///  in an interface of this class.
        /// </param>
        [Since ("2.4")]
        public void OverrideProperty (UInt32 propertyId, String name)
        {
            AssertNotDisposed ();
            if (name == null) {
                throw new ArgumentNullException ("name");
            }
            var name_ = MarshalG.StringToUtf8Ptr (name);
            g_object_class_override_property (Handle, propertyId, name_);
            MarshalG.Free (name_);
        }

        ObjectClass (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
