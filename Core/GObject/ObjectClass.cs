using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using GISharp.GLib;
using GISharp.Runtime;
using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
{
    /// <summary>
    /// The class structure for the GObject type.
    /// </summary>
    public class ObjectClass : TypeClass
    {
        static readonly IntPtr setPropertyOffset = Marshal.OffsetOf<Struct> (nameof(Struct.SetProperty));
        static readonly IntPtr getPropertyOffset = Marshal.OffsetOf<Struct> (nameof(Struct.GetProperty));
        static readonly IntPtr notifyOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Notify));
        static readonly Struct.UnmanagedSetProperty setPropertyDelegate = ManagedClassSetProperty;
        static readonly IntPtr setPropertyPtr = Marshal.GetFunctionPointerForDelegate (setPropertyDelegate);
        static readonly Struct.UnmanagedSetProperty getPropertyDelegate = ManagedClassGetProperty;
        static readonly IntPtr getPropertyPtr = Marshal.GetFunctionPointerForDelegate (getPropertyDelegate);
        static readonly Struct.UnmanagedNotify notifyDelegate = ManagedNotify;
        static readonly IntPtr notifyPtr = Marshal.GetFunctionPointerForDelegate (notifyDelegate);

        new internal struct Struct
        {
            #pragma warning disable CS0649
            public TypeClass.Struct GTypeClass;

            public IntPtr ConstructProperties;

            /* seldom overidden */
            public UnmanagedConstructor Constructor;
            /* overridable methods */
            public UnmanagedSetProperty SetProperty;
            public UnmanagedGetProperty GetProperty;
            public UnmanagedDispose Dispose;
            public UnmanagedFinalize Finalize;
            /* seldom overidden */
            public UnmanagedDispatchPropertiesChanged DispatchPropertiesChanged;
            /* signals */
            public UnmanagedNotify Notify;

            /* called when done constructing */
            public UnmanagedConstructed Constructed;

            public UIntPtr Flags;
            public IntPtr Dummy0;
            public IntPtr Dummy1;
            public IntPtr Dummy2;
            public IntPtr Dummy3;
            public IntPtr Dummy4;
            public IntPtr Dummy5;
            #pragma warning restore CS0649

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate IntPtr UnmanagedConstructor (GType type, uint nConstructProperties, IntPtr constructProperties);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedSetProperty (IntPtr @object, uint propertyId, ref Value value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedGetProperty (IntPtr @object, uint propertyId, ref Value value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedDispose (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedFinalize (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedDispatchPropertiesChanged (IntPtr @object, uint nPspecs, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedNotify (IntPtr @object, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedConstructed (IntPtr @object);
        }

        public ObjectClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public override Type StructType {
            get {
                return typeof (Struct);
            }
        }

        internal static readonly Quark managedClassPropertyInfoQuark =
            Quark.FromString ("gisharp-object-class-managed-class-property-info-quark");

        /// <summary>
        /// Gets the type info for registering a managed class with the GObject
        /// type system.
        /// </summary>
        /// <returns>The type info.</returns>
        /// <param name="type">The managed type to register.</param>
        public override TypeInfo GetTypeInfo (Type type)
        {
            var parentGType = type.BaseType.GetGType ();
            var parentTypeQuery = parentGType.Query ();
            var ret = new TypeInfo {
                ClassSize = (ushort)parentTypeQuery.ClassSize,
                ClassInit = UnmanagedInitManagedClass,
                ClassData = GCHandle.ToIntPtr (GCHandle.Alloc (type)),
                InstanceSize = (ushort)parentTypeQuery.InstanceSize,
            };

            return ret;
        }

        /// <summary>
        /// ClassInit callback for managed classes.
        /// </summary>
        /// <param name="classPtr">Pointer to <see cref="Struct"/>.</param>
        /// <param name="userDataPtr">Pointer to user data from <see cref="TypeInfo"/>.</param>
        /// <remarks>
        /// This takes care of overriding the methods to make the managed type
        /// interop with the GObject type system.
        /// </remarks>
        static void UnmanagedInitManagedClass (IntPtr classPtr, IntPtr userDataPtr)
        {
            try {
                // Can't use type.GetGType () here since the type registration has
                // not finished. So, we get the GType this way instead.
                var gtype = Marshal.PtrToStructure<GType> (classPtr);
                var type = (Type)GCHandle.FromIntPtr (userDataPtr).Target;

                // override property native accessors

                Marshal.WriteIntPtr (classPtr, (int)setPropertyOffset, setPropertyPtr);
                Marshal.WriteIntPtr (classPtr, (int)getPropertyOffset, getPropertyPtr);
                Marshal.WriteIntPtr (classPtr, (int)notifyOffset, notifyPtr);

                // Install Properties

                uint propId = 1; // propId 0 is used internally, so we start with 1
                foreach (var propInfo in type.GetProperties ()) {
                    if (propInfo.DeclaringType != type) {
                        // only register properties declared in this type or in interfaces
                        continue;
                    }

                    var name = propInfo.TryGetGPropertyName();
                    if (name == null) {
                        // this property is not to be registered with the GObject type system
                        continue;
                    }
                    // TODO: localize strings for nick and blurb
                    var nick = propInfo.GetCustomAttribute<DisplayNameAttribute> (true)
                        ?.DisplayName ?? name;
                    var blurb = propInfo.GetCustomAttribute<DescriptionAttribute> (true)
                        ?.Description ?? nick;
                    var defaultValue = propInfo.GetCustomAttribute<DefaultValueAttribute> (true)
                        ?.Value;

                    // setup the flags

                    var flags = default(ParamFlags);

                    if (propInfo.CanRead) {
                        flags |= ParamFlags.Readable;
                    }
                    if (propInfo.CanWrite) {
                        flags |= ParamFlags.Writable;
                    }
                    // Construct properties don't work with managed types because they
                    // require setting the property before the class has been instantiated.
                    // So, we don't ever set ParamFlags.Construct or ParamFlags.ConstructOnly

                    flags |= ParamFlags.StaticName;
                    flags |= ParamFlags.StaticNick;
                    flags |= ParamFlags.StaticBlurb;

                    // Always explicit notify. Setting properties from managed code
                    // must manually call notify, so if a property was set via
                    // unmanaged code, it would result in double notification if
                    // ExplicitNotify was not set.
                    flags |= ParamFlags.ExplicitNotify;

                    if (propInfo.GetCustomAttribute<ObsoleteAttribute> (true) != null) {
                        flags |= ParamFlags.Deprecated;
                    }

                    // create the pspec instance based on type

                    ParamSpec pspec;
                    // TODO: Need to create special boxed type for non-GType objects
                    var propertyGType = (GType)propInfo.PropertyType;
                    var fundamentalGType = propertyGType.Fundamental;
                    if (fundamentalGType == GType.Boolean) {
                        pspec = new ParamSpecBoolean (name, nick, blurb, (bool)(defaultValue ?? default(bool)), flags);
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
                        pspec = new ParamSpecEnum (name, nick, blurb, propertyGType, (System.Enum)defaultValue, flags);
                    } else if (fundamentalGType == GType.Flags) {
                        pspec = new ParamSpecFlags (name, nick, blurb, propertyGType, (System.Enum)defaultValue, flags);
                    } else if (fundamentalGType == GType.Int) {
                        pspec = new ParamSpecInt (name, nick, blurb, int.MinValue, int.MaxValue, (int)(defaultValue ?? default(int)), flags);
                    } else if (fundamentalGType == GType.UInt) {
                        pspec = new ParamSpecUInt (name, nick, blurb, uint.MinValue, uint.MaxValue, (uint)(defaultValue ?? default(uint)), flags);
                    } else if (fundamentalGType == GType.Int64) {
                        pspec = new ParamSpecInt64 (name, nick, blurb, long.MinValue, long.MaxValue, (long)(defaultValue ?? default(long)), flags);
                    } else if (fundamentalGType == GType.UInt64) {
                        pspec = new ParamSpecUInt64 (name, nick, blurb, ulong.MinValue, ulong.MaxValue, (ulong)(defaultValue ?? default(ulong)), flags);
                    } else if (fundamentalGType == GType.Long) {
                        pspec = new ParamSpecLong (name, nick, blurb, nlong.MinValue, nlong.MaxValue, (nlong)(defaultValue ?? default(nlong)), flags);
                    } else if (fundamentalGType == GType.ULong) {
                        pspec = new ParamSpecULong (name, nick, blurb, nulong.MinValue, nulong.MaxValue, (nulong)(defaultValue ?? default(nulong)), flags);
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
                    } else if (fundamentalGType == GType.Variant) {
                        // TODO: need to pass variant type using attribute?
                        // for now, always using any type
                        var variantType = VariantType.Any;
                        pspec = new ParamSpecVariant (name, nick, blurb, variantType, defaultValue == null ? null : (Variant)defaultValue, flags);
                    } else {
                        // TODO: Need more specific exception
                        throw new Exception ("unhandled GType");
                    }

                    var methodInfo = propInfo.GetAccessors ().First ();
                    if (methodInfo.GetBaseDefinition () != methodInfo || propInfo.TryGetMatchingInterfacePropertyInfo () != null) {
                        // if this type did not declare the property, the we know
                        // we are overriding a property from a base class or interface
                        var namePtr = GMarshal.StringToUtf8Ptr (name);
                        g_object_class_override_property (classPtr, propId, namePtr);
                        GMarshal.Free (namePtr);
                    } else {
                        g_object_class_install_property (classPtr, propId, pspec.Handle);
                        GC.KeepAlive (pspec);
                    }
                    propId++;
                }

                foreach (var eventInfo in type.GetEvents ()) {
                    if (eventInfo.DeclaringType != type) {
                        // only register events declared in this type
                        continue;
                    }

                    var signalAttr = eventInfo.GetCustomAttribute<GSignalAttribute>(true);
                    if (signalAttr == null) {
                        // events without SignalAttribute are not installed
                        continue;
                    }

                    // figure out the name

                    var name = signalAttr.Name ?? eventInfo.Name;
                    Signal.ValidateName(name);

                    // figure out the flags

                    var flags = default(SignalFlags);

                    switch (signalAttr.When) {
                    case EmissionStage.First:
                        flags |= SignalFlags.RunFirst;
                        break;
                    case EmissionStage.Last:
                    default:
                        flags |= SignalFlags.RunLast;
                        break;
                    case EmissionStage.Cleanup:
                        flags |= SignalFlags.RunCleanup;
                        break;
                    }

                    if (signalAttr.NoRecurse) {
                        flags |= SignalFlags.NoRecurse;
                    }

                    if (signalAttr.Detailed) {
                        flags |= SignalFlags.Detailed;
                    }

                    if (signalAttr.Action) {
                        flags |= SignalFlags.Action;
                    }

                    if (signalAttr.NoHooks) {
                        flags |= SignalFlags.NoHooks;
                    }

                    if (eventInfo.GetCustomAttribute<ObsoleteAttribute> (true) != null) {
                        flags |= SignalFlags.Deprecated;
                    }

                    // figure out the parameter types

                    var methodInfo = eventInfo.EventHandlerType.GetMethod ("Invoke");
                    var returnGType = methodInfo.ReturnType.GetGType ();
                    var parameters = methodInfo.GetParameters ();
                    var parameterGTypes = new GType[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++) {
                        parameterGTypes[i] = parameters[i].ParameterType.GetGType ();
                    }

                    // create a closure that will be called when the signal is emitted

                    var fieldInfo = type.GetField(eventInfo.Name,
                        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                    var closure = new Closure((p) => {
                        var eventDelegate = (MulticastDelegate)fieldInfo.GetValue(p[0]);
                        return eventDelegate?.DynamicInvoke(p.Skip(1).ToArray());
                    });

                    // register the signal

                    var namePtr = GMarshal.StringToUtf8Ptr (name);
                    var parameterGTypesPtr = GMarshal.CArrayToPtr<GType> (parameterGTypes, false);
                    Signal.g_signal_newv(namePtr, gtype, flags, closure.Handle,
                        null, IntPtr.Zero, null, returnGType,
                        (uint)parameterGTypes.Length, parameterGTypesPtr);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException ();
            }
        }

        static void ManagedClassSetProperty(IntPtr objPtr, uint propertyId, ref Value value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None);

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark];
                propInfo.SetValue (obj, value.Get ());
            }
            catch (Exception ex) {
                ex.LogUnhandledException ();
            }
        }

        static void ManagedClassGetProperty(IntPtr objPtr, uint propertyId, ref Value value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance (pspecPtr, Transfer.None);

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark];
                value.Set (propInfo.GetValue (obj));
            }
            catch (Exception ex) {
                ex.LogUnhandledException ();
            }
        }

        static void ManagedNotify (IntPtr object_, IntPtr pspec_)
        {
            try {
                var obj = Object.GetInstance(object_, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspec_, Transfer.None);
                // FIXME
            } catch (Exception ex) {
                ex.LogUnhandledException ();
            }
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        /// Looks up the <see cref="ParamSpec"/> for a property of a class.
        /// </summary>
        /// <param name="propertyName">
        /// the name of the property to look up
        /// </param>
        /// <returns>
        /// the <see cref="ParamSpec"/> for the property, or
        /// <c>null</c> if the class doesn't have a property of that name
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw when <paramref name="propertyName"/> is <c>null</c>
        /// </exception>
        public ParamSpec FindProperty(Utf8 propertyName)
        {
            var propertyName_ = propertyName?.Handle ?? throw new ArgumentNullException(nameof(propertyName));
            var ret_ = g_object_class_find_property(Handle, propertyName_);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_properties (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nPspecs,
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
            if (pspecs == null) {
                throw new ArgumentNullException (nameof (pspecs));
            }
            var pspecs_ = GMarshal.OpaqueCArrayToPtr<ParamSpec> (pspecs, false);
            var nPspecs_ = (uint)(pspecs == null ? 0 : pspecs.Length);
            g_object_class_install_properties (Handle, nPspecs_, pspecs_);
            GMarshal.Free (pspecs_);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_property (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint propertyId,
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
        public void InstallProperty (uint propertyId, ParamSpec pspec)
        {
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            g_object_class_install_property (Handle, propertyId, pspec.Handle);
            GC.KeepAlive (pspec);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
            out uint nProperties);

        /// <summary>
        /// Get an array of #GParamSpec* for all properties of a class.
        /// </summary>
        /// <returns>
        /// an array of
        ///          #GParamSpec* which should be freed after use
        /// </returns>
        public ParamSpec[] ListProperties ()
        {
            return ListProperties(Handle);
        }

        internal static ParamSpec[] ListProperties (IntPtr handle)
        {
            uint nProperties_;
            var ret_ = g_object_class_list_properties (handle, out nProperties_);
            var ret = GMarshal.PtrToOpaqueCArray<ParamSpec> (ret_, (int)nProperties_, true);
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
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_override_property (
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint propertyId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);
    }

    /// <summary>
    /// The GObjectConstructParam struct is an auxiliary structure used to hand
    /// GParamSpec/GValue pairs to the constructor of a GObjectClass.
    /// </summary>
    struct ObjectConstructParam
    {
        #pragma warning disable CS0649
        /// <summary>
        /// the GParamSpec of the construct parameter
        /// </summary>
        public IntPtr Pspec;

        /// <summary>
        /// the value to set the parameter to
        /// </summary>
        public IntPtr Value;
        #pragma warning restore CS0649
    }
}
