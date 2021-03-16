// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;
using static System.Reflection.BindingFlags;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// Extension methods for working with types/GTypes.
    /// </summary>
    public static unsafe class TypeExtensions
    {
        static readonly Quark managedTypeQuark = Quark.FromString("gisharp-gtype-managed-type-quark");
        static readonly Dictionary<Type, GType> typeMap = new();
        static readonly object mapLock = new();

        /// <summary>
        /// Adds bidirectional mapping of type/GType
        /// </summary>
        /// <remarks>
        /// must be called with mapLock held.
        /// </remarks>
        static void Add(GType gtype, Type type)
        {
            g_type_set_qdata(gtype, managedTypeQuark, (IntPtr)GCHandle.Alloc(type));
            typeMap.Add(type, gtype);
        }

#pragma warning disable 414
        // There is an unfortunate bug that g_type_add_interface_static() will
        // fail to install properties because class_init of GObject has not
        // been run yet to create the param spec pool.
        //
        // The error is "g_param_spec_pool_lookup: assertion 'pool != NULL' failed"
        //
        // creating an object here and keeping it around forever will ensure
        // that class_init is run before we try to add any interfaces.
        //
        // Since the GISharp.Lib.GObject.Object class depends on GType, we have to
        // use pinvoke directly.
        static readonly IntPtr eternalObject = Object.g_object_newv(GType.Object, 0, IntPtr.Zero);
#pragma warning restore 414

        static TypeExtensions()
        {
            // add the built-in fundamental types
            lock (mapLock) {
                Add(GType.None, typeof(void));
                Add(GType.Interface, typeof(GInterface<>));
                Add(GType.Char, typeof(sbyte));
                Add(GType.UChar, typeof(byte));
                Add(GType.Boolean, typeof(bool));
                Add(GType.Int, typeof(int));
                Add(GType.UInt, typeof(uint));
                Add(GType.Long, typeof(clong));
                Add(GType.ULong, typeof(culong));
                Add(GType.Int64, typeof(long));
                Add(GType.UInt64, typeof(ulong));
                Add(GType.Enum, typeof(System.Enum));
                // Flags is special-cased in lookup
                g_type_set_qdata(GType.Flags, managedTypeQuark,
                    (IntPtr)GCHandle.Alloc(typeof(System.Enum)));
                Add(GType.Float, typeof(float));
                Add(GType.Double, typeof(double));
                Add(GType.String, typeof(Utf8));
                Add(GType.Pointer, typeof(IntPtr));
                Add(GType.Boxed, typeof(Boxed));
                Add(GType.Param, typeof(ParamSpec));
                Add(GType.Object, typeof(Object));
                Add(GType.Type, typeof(GType));
                Add(GType.Variant, typeof(Variant));
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_register_static(
            GType parentType,
            IntPtr typeName,
            TypeInfo* info,
            TypeFlags flags);

        /// <summary>
        /// Registers <paramref name="typeName"/> as the name of a new static
        /// type derived from <paramref name="parentType"/>.
        /// </summary>
        /// <returns>The new type identifier.</returns>
        /// <param name="parentType">Type from which this type will be derived.</param>
        /// <param name="typeName">The name of the new type.</param>
        /// <param name="info"><see cref="TypeInfo"/> structure for this type.</param>
        /// <param name="flags">Bitwise combination of <see cref="TypeFlags"/> values.</param>
        static GType RegisterStatic(GType parentType, string typeName, in TypeInfo info, TypeFlags flags)
        {
            using var typeNameUtf8 = typeName.ToUtf8();
            var typeName_ = typeNameUtf8.UnsafeHandle;
            var handle = GCHandle.Alloc(info, GCHandleType.Pinned);
            var info_ = (TypeInfo*)handle.AddrOfPinnedObject();
            var ret = g_type_register_static(parentType, typeName_, info_, flags);

            return ret;
        }

        static void MapPropertyInfo(GType gtype, Type type)
        {
            // type registration has not been completed here, so have to get the
            // object class the hard way by not using our nice wrapper class
            var objClassPtr = TypeClass.g_type_class_ref(gtype);
            try {
                foreach (var pspec in ObjectClass.ListProperties(objClassPtr)) {
                    var prop = type.GetProperties(Public | NonPublic | Instance)
                        .SingleOrDefault(p => p.TryGetGPropertyName() == pspec.Name);
                    if (prop is null) {
                        var message = $"Could not find matching property for \"{pspec.Name}\" in type {type.FullName}";
                        throw new ArgumentException(message, nameof(type));
                    }
                    pspec[ObjectClass.managedClassPropertyInfoQuark] = prop;
                }
            }
            finally {
                TypeClass.g_type_class_unref(objClassPtr);
            }
        }

        /// <summary>
        /// Register the specified type with the GObject type system.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <remarks>
        /// This is meant to be called from that static constructor of a type.
        /// </remarks>
        static GType Register(Type type)
        {
            lock (mapLock) {
                if (typeMap.ContainsKey(type)) {
                    throw new ArgumentException("This type is already registered.", nameof(type));
                }

                var gtypeAttribute = type.GetCustomAttributes()
                    .OfType<GTypeAttribute>().SingleOrDefault();
                if (gtypeAttribute is null) {
                    throw new ArgumentException($"Type '{type}' is missing GType attribute. Boxed<T> can be used for manged types.");
                }

                if (gtypeAttribute.IsProxyForUnmanagedType) {
                    // enums and interfaces can't have method implementations,
                    // so we need to find the associated static type for the
                    // actual implementation.
                    var implementationType = type;
                    if (type.IsEnum) {
                        // Error domain enums have "Domain" suffix for extensions class.
                        var suffix = type.CustomAttributes.Any(x => x.AttributeType == typeof(GErrorDomainAttribute))
                            ? "Domain" : "Extensions";
                        implementationType = type.Assembly.GetType(type.FullName + suffix) ?? implementationType;
                    }
                    else if (type.IsGenericType && type.BaseType != typeof(Boxed)) {
                        implementationType = type.BaseType ?? throw new ArgumentException("generic type without base type", nameof(type));
                    }
                    var gtypeField = implementationType.GetField("_GType", Static | NonPublic);
                    if (gtypeField is null) {
                        var message = $"Could not find _GType field for {implementationType.FullName}.";
                        throw new ArgumentException(message, nameof(type));
                    }
                    var gtype = (GType)gtypeField.GetValue(null)!;
                    if (gtype == GType.Invalid) {
                        throw new InvalidOperationException("Something bad happend while registering wrapped type.");
                    }

                    if (gtype.Fundamental == GType.Object) {
                        MapPropertyInfo(gtype, type);
                    }

                    Add(gtype, type);

                    return gtype;
                }

                var gtypeName = type.GetGTypeName();
                if (type.IsClass) {
                    if (!type.IsSubclassOf(typeof(Object))) {
                        var message = string.Format("Class does not inherit from {0}",
                                          typeof(Object).FullName);
                        throw new ArgumentException(message, nameof(type));
                    }
                    var parentGType = type.BaseType?.ToGType() ?? throw new ArgumentException("class without base type", nameof(type));
                    var parentTypeclass = TypeClass.Get(parentGType);
                    var parentTypeInfo = ObjectClass.GetTypeInfo(type);

                    TypeFlags flags = default;
                    // TODO: do we need to set any flags?

                    var gtype = RegisterStatic(parentGType, gtypeName, parentTypeInfo, flags);
                    if (gtype == GType.Invalid) {
                        throw new InvalidOperationException("Something bad happend while registering object.");
                    }

                    // Install interfaces

                    // The order matters here. When we have multiple GType interfaces
                    // we need to make sure the prerequisites of an interface get
                    // installed before that interface itself gets installed.
                    // Sorting by number of inherited interfaces works because
                    // if interface B inherits interface A, B.GetInterfaces ().Length
                    // will be greater than A.GetInterfaces ().Length because it
                    // includes A in addition to all of A's interfaces.
                    var ifaces = type.GetInterfaces().OrderBy(i => i.GetInterfaces().Length);
                    foreach (var ifaceType in ifaces) {
                        var ifaceMap = type.GetInterfaceMap(ifaceType);
                        if (ifaceMap.TargetType != type) {
                            // only interested in interfaces that are actually
                            // implemented by this type and not inherited
                            continue;
                        }
                        var gtypeAttr = ifaceType.GetCustomAttribute<GTypeAttribute>();
                        if (gtypeAttr is null) {
                            // only care about interfaces registered with the
                            // GObject type system
                            continue;
                        }
                        var ifaceGType = ifaceType.ToGType();
                        var prereqs = TypeInterface.GetPrerequisites(ifaceGType);
                        foreach (var p in prereqs.Span) {
                            if (!p.ToType().IsAssignableFrom(type)) {
                                var message = $"Type {type.FullName} is missing prerequisite {ifaceType.FullName} ({p})";
                                throw new ArgumentException(message, nameof(type));
                            }
                        }

                        var interfaceInfo = TypeInterface.CreateInterfaceInfo(ifaceType, type);
                        AddInterfaceStatic(gtype, ifaceGType, interfaceInfo);
                    }

                    MapPropertyInfo(gtype, type);
                    Add(gtype, type);

                    return gtype;
                }
                if (type.IsEnum) {
                    var underlyingType = type.GetEnumUnderlyingType();
                    if (underlyingType != typeof(int) && underlyingType != typeof(uint)) {
                        throw new ArgumentException("GType enums must be int/uint", nameof(type));
                    }
                    var values = (int[])type.GetEnumValues();
                    var names = type.GetEnumNames();
                    var flagsAttribute = type.GetCustomAttributes()
                        .OfType<FlagsAttribute>().SingleOrDefault();
                    if (flagsAttribute is null) {
                        var gtypeValues = new EnumValue[values.Length + 1];
                        for (int i = 0; i < values.Length; i++) {
                            var enumValueField = type.GetField(names[i]);
                            var enumValueAttr = enumValueField?.GetCustomAttributes()
                                .OfType<GEnumMemberAttribute>()
                                .SingleOrDefault();
                            var valueName = enumValueAttr?.Name ?? names[i];
                            var valueNick = enumValueAttr?.Nick ?? names[i];
                            var enumValue = new EnumValue(values[i], valueName, valueNick);
                            gtypeValues[i] = enumValue;
                        }
                        var gtype = Enum.RegisterStatic(gtypeName, gtypeValues);
                        if (gtype == GType.Invalid) {
                            throw new InvalidOperationException("Something bad happend while registering enum.");
                        }

                        Add(gtype, type);

                        return gtype;
                    }
                    else {
                        var gtypeValues = new FlagsValue[values.Length + 1];
                        for (int i = 0; i < values.Length; i++) {
                            var enumValueField = type.GetField(names[i]);
                            var enumValueAttr = enumValueField?
                                .GetCustomAttributes()
                                .OfType<GEnumMemberAttribute>()
                                .SingleOrDefault();
                            var valueName = enumValueAttr?.Name ?? names[i];
                            var valueNick = enumValueAttr?.Nick ?? names[i];
                            var flagValue = new FlagsValue((uint)values[i], valueName, valueNick);
                            gtypeValues[i] = flagValue;
                        }
                        var gtype = Flags.RegisterStatic(gtypeName, gtypeValues);
                        if (gtype == GType.Invalid) {
                            throw new InvalidOperationException("Something bad happend while registering flags.");
                        }

                        Add(gtype, type);

                        return gtype;
                    }
                }
            }
            throw new NotImplementedException();
        }

        internal static GType FromType(Type type)
        {
            lock (mapLock) {
                if (typeMap.ContainsKey(type)) {
                    var gtype = typeMap[type];
                    if (gtype == GType.Enum && type.GetCustomAttributes<FlagsAttribute>().Any()) {
                        // special case for Flags vs. Enum
                        return GType.Flags;
                    }
                    return gtype;
                }

                var ret = Register(type);

                return ret;
            }
        }

        /// <summary>
        /// Gets the corresponding managed type for a GType.
        /// </summary>
        public static Type ToType(this GType gtype)
        {
            lock (mapLock) {
                var type = default(Type);
                var data = g_type_get_qdata(gtype, managedTypeQuark);

                if (data == IntPtr.Zero) {
                    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
                        var name = gtype.Name;
                        type = (asm.IsDynamic ? asm.DefinedTypes : asm.ExportedTypes)
                            .FirstOrDefault(t => t.GetCustomAttributes()
                               .OfType<GTypeAttribute>()
                               .Any(a => a.Name == name));
                        if (type is not null) {
                            break;
                        }
                    }
                    if (type is null) {
                        var message = $"Could not find type for GType '{gtype.Name}' in loaded assemblies.";
                        throw new GTypeException(message);
                    }
                    Register(type);
                }
                else {
                    var handle = (GCHandle)data;
                    type = (Type)handle.Target!;
                }

                return type;
            }
        }

        /// <summary>
        /// Queries the type system for information about a specific type.
        /// This function will fill in a user-provided structure to hold
        /// type-specific information. If an invalid #GType is passed in, the
        /// @type member of the #GTypeQuery is 0. All members filled into the
        /// #GTypeQuery structure should be considered constant and have to be
        /// left untouched.
        /// </summary>
        /// <param name="type">
        /// #GType of a static, classed type
        /// </param>
        /// <param name="query">
        /// a user provided structure that is
        ///     filled in with constant values upon success
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_query(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="TypeQuery" type="GTypeQuery*" managed-name="TypeQuery" /> */
            /* direction:out caller-allocates:1 transfer-ownership:none */
            out TypeQuery query);

        /// <summary>
        /// Queries the type system for information about a specific type.
        /// </summary>
        public static TypeQuery Query(this GType gtype)
        {
            g_type_query(gtype, out TypeQuery query);
            return query;
        }

        /// <summary>
        /// Adds the static @interface_type to @instantiable_type.
        /// The information contained in the #GInterfaceInfo structure
        /// pointed to by @info is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="info">
        /// #GInterfaceInfo structure for this
        ///        (@instance_type, @interface_type) combination
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_static(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="InterfaceInfo" type="const GInterfaceInfo*" managed-name="InterfaceInfo" /> */
            /* transfer-ownership:none */
            IntPtr info);

        /// <summary>
        /// Adds the static @interface_type to @instantiable_type.
        /// The information contained in the #GInterfaceInfo structure
        /// pointed to by @info is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="info">
        /// #GInterfaceInfo structure for this
        ///        (@instance_type, @interface_type) combination
        /// </param>
        static void AddInterfaceStatic(GType instanceType, GType interfaceType, InterfaceInfo info)
        {
            // making a copy of info in unmanged memory that will never be freed
            var infoPtr = GMarshal.Alloc(Marshal.SizeOf<InterfaceInfo>());
            Marshal.StructureToPtr(info, infoPtr, false);

            // also make sure the delegates are never GCed.
            GCHandle.Alloc(info.InterfaceInit);
            GCHandle.Alloc(info.InterfaceFinalize);

            g_type_add_interface_static(instanceType, interfaceType, infoPtr);
        }

        /// <summary>
        /// Obtains data which has previously been attached to @type
        /// with g_type_set_qdata().
        /// </summary>
        /// <remarks>
        /// Note that this does not take subtyping into account; data
        /// attached to one type with g_type_set_qdata() cannot
        /// be retrieved from a subtype using g_type_get_qdata().
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <returns>
        /// the data, or %NULL if no data was found
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_get_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

        /// <summary>
        /// Attaches arbitrary data to a type.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <param name="data">
        /// the data
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_set_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data);

#if THIS_CODE_IS_NOT_COMPILED
        /// <summary>
        /// Adds a #GTypeClassCacheFunc to be called before the reference count of a
        /// class goes from one to zero. This can be used to prevent premature class
        /// destruction. All installed #GTypeClassCacheFunc functions will be chained
        /// until one of them returns %TRUE. The functions have to check the class id
        /// passed in to figure whether they actually want to cache the class of this
        /// type, since all classes are routed through the same #GTypeClassCacheFunc
        /// chain.
        /// </summary>
        /// <param name="cacheData">
        /// data to be passed to @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeClassCacheFunc cacheFunc);

        /// <summary>
        /// Adds a #GTypeClassCacheFunc to be called before the reference count of a
        /// class goes from one to zero. This can be used to prevent premature class
        /// destruction. All installed #GTypeClassCacheFunc functions will be chained
        /// until one of them returns %TRUE. The functions have to check the class id
        /// passed in to figure whether they actually want to cache the class of this
        /// type, since all classes are routed through the same #GTypeClassCacheFunc
        /// chain.
        /// </summary>
        /// <param name="cacheData">
        /// data to be passed to @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        public static void AddClassCacheFunc(IntPtr cacheData, TypeClassCacheFunc cacheFunc)
        {
            var cacheFunc_ = UnmanagedTypeClassCacheFuncFactory.Create(cacheFunc, false);
            g_type_add_class_cache_func(cacheData, cacheFunc_);
        }

        /// <summary>
        /// Registers a private class structure for a classed type;
        /// when the class is allocated, the private structures for
        /// the class and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        /// </summary>
        /// <remarks>
        /// This function should be called in the
        /// type's get_type() function after the type is registered.
        /// The private structure can be retrieved using the
        /// G_TYPE_CLASS_GET_PRIVATE() macro.
        /// </remarks>
        /// <param name="classType">
        /// GType of an classed type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [Since ("2.24")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_class_private(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType classType,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint privateSize);

        /// <summary>
        /// Registers a private class structure for a classed type;
        /// when the class is allocated, the private structures for
        /// the class and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        /// </summary>
        /// <remarks>
        /// This function should be called in the
        /// type's get_type() function after the type is registered.
        /// The private structure can be retrieved using the
        /// G_TYPE_CLASS_GET_PRIVATE() macro.
        /// </remarks>
        /// <param name="classType">
        /// GType of an classed type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [Since ("2.24")]
        public static void AddClassPrivate(GType classType, int privateSize)
        {
            if (privateSize < 0) {
                throw new ArgumentOutOfRangeException(nameof(privateSize));
            }
            g_type_add_class_private(classType, privateSize);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_type_add_instance_private(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType classType,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint privateSize);

        public static int AddInstancePrivate(GType classType, int privateSize)
        {
            if (privateSize < 0) {
                throw new ArgumentOutOfRangeException(nameof(privateSize));
            }
            var ret = g_type_add_instance_private(classType, (nuint)privateSize);
            return ret;
        }

        /// <summary>
        /// Adds a function to be called after an interface vtable is
        /// initialized for any class (i.e. after the @interface_init
        /// member of #GInterfaceInfo has been called).
        /// </summary>
        /// <remarks>
        /// This function is useful when you want to check an invariant
        /// that depends on the interfaces of a class. For instance, the
        /// implementation of #GObject uses this facility to check that an
        /// object implements all of the properties that are defined on its
        /// interfaces.
        /// </remarks>
        /// <param name="checkData">
        /// data to pass to @check_func
        /// </param>
        /// <param name="checkFunc">
        /// function to be called after each interface
        ///     is initialized
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            IntPtr checkFunc);

        /// <summary>
        /// Adds a function to be called after an interface vtable is
        /// initialized for any class (i.e. after the @interface_init
        /// member of #GInterfaceInfo has been called).
        /// </summary>
        /// <remarks>
        /// This function is useful when you want to check an invariant
        /// that depends on the interfaces of a class. For instance, the
        /// implementation of #GObject uses this facility to check that an
        /// object implements all of the properties that are defined on its
        /// interfaces.
        /// </remarks>
        /// <param name="checkData">
        /// data to pass to @check_func
        /// </param>
        /// <param name="checkFunc">
        /// function to be called after each interface
        ///     is initialized
        /// </param>
        [Since ("2.4")]
        public static IDisposable AddInterfaceCheck(TypeInterfaceCheckFunc checkFunc)
        {
            var (checkFunc_, destroy_, checkData_) = TypeInterfaceCheckFuncMarshal.ToUnmanagedFunctionPointer(checkFunc, CallbackScope.Notified);
            g_type_add_interface_check(checkData_, checkFunc_);

            return new RemoveInterfaceCheck(checkFunc_, destroy_, checkData_);
        }

        /// <summary>
        /// Adds the dynamic @interface_type to @instantiable_type. The information
        /// contained in the #GTypePlugin structure pointed to by @plugin
        /// is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GInterfaceInfo from
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_dynamic(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
            /* transfer-ownership:none */
            IntPtr plugin);

        /// <summary>
        /// Adds the dynamic @interface_type to @instantiable_type. The information
        /// contained in the #GTypePlugin structure pointed to by @plugin
        /// is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GInterfaceInfo from
        /// </param>
        public static void AddInterfaceDynamic(GType instanceType, GType interfaceType, TypePlugin plugin)
        {
            var plugin_ = default(IntPtr);
            throw new System.NotImplementedException();
            g_type_add_interface_dynamic(instanceType, interfaceType, plugin_);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
        /* */
        static extern IntPtr g_type_check_class_cast(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        public static TypeClass CheckClassCast(TypeClass gClass, GType isAType)
        {
            var gClass_ = gClass.UnsafeHandle;
            var ret_ = g_type_check_class_cast(gClass_, isAType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeClass>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_class_is_a(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        public static bool CheckClassIsA(TypeClass gClass, GType isAType)
        {
            var gClass_ = gClass.UnsafeHandle;
            var ret = g_type_check_class_is_a(gClass_, isAType);
            return ret;
        }

        /// <summary>
        /// Private helper function to aid implementation of the
        /// G_TYPE_CHECK_INSTANCE() macro.
        /// </summary>
        /// <param name="instance">
        /// a valid #GTypeInstance structure
        /// </param>
        /// <returns>
        /// %TRUE if @instance is valid, %FALSE otherwise
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        /// <summary>
        /// Private helper function to aid implementation of the
        /// G_TYPE_CHECK_INSTANCE() macro.
        /// </summary>
        /// <param name="instance">
        /// a valid #GTypeInstance structure
        /// </param>
        /// <returns>
        /// %TRUE if @instance is valid, %FALSE otherwise
        /// </returns>
        public static bool CheckInstance(TypeInstance instance)
        {
            var instance_ = instance.UnsafeHandle;
            var ret = g_type_check_instance(instance_);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* */
        static extern IntPtr g_type_check_instance_cast(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType ifaceType);

        public static TypeInstance CheckInstanceCast(TypeInstance instance, GType ifaceType)
        {
            var instance_ = instance.UnsafeHandle;
            var ret_ = g_type_check_instance_cast(instance_, ifaceType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInstance>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_instance_is_a(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType ifaceType);

        public static bool CheckInstanceIsA(TypeInstance instance, GType ifaceType)
        {
            var instance_ = instance.UnsafeHandle;
            var ret = g_type_check_instance_is_a(instance_, ifaceType);
            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_instance_is_fundamentally_a(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType fundamentalType);

        public static bool CheckInstanceIsFundamentallyA(TypeInstance instance, GType fundamentalType)
        {
            var instance_ = instance.UnsafeHandle;
            var ret = g_type_check_instance_is_fundamentally_a(instance_, fundamentalType);
            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_value(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public static bool CheckValue(Value value)
        {
            var value_ = value.UnsafeHandle;
            var ret = g_type_check_value(value_);
            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_check_value_holds(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        public static bool CheckValueHolds(Value value, GType type)
        {
            var value_ = value.UnsafeHandle;
            var ret = g_type_check_value_holds(value_, type);
            return ret;
        }

        /// <summary>
        /// Creates and initializes an instance of @type if @type is valid and
        /// can be instantiated. The type system only performs basic allocation
        /// and structure setups for instances: actual instance creation should
        /// happen through functions supplied by the type's fundamental type
        /// implementation.  So use of g_type_create_instance() is reserved for
        /// implementators of fundamental types only. E.g. instances of the
        /// #GObject hierarchy should be created via g_object_new() and never
        /// directly through g_type_create_instance() which doesn't handle things
        /// like singleton objects or object construction.
        /// </summary>
        /// <remarks>
        /// The extended members of the returned instance are guaranteed to be filled
        /// with zeros.
        ///
        /// Note: Do not use this function, unless you're implementing a
        /// fundamental type. Also language bindings should not use this
        /// function, but g_object_new() instead.
        /// </remarks>
        /// <param name="type">
        /// an instantiatable type to create an instance for
        /// </param>
        /// <returns>
        /// an allocated and initialized instance, subject to further
        ///     treatment by the fundamental type implementation
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* */
        static extern IntPtr g_type_create_instance(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Creates and initializes an instance of @type if @type is valid and
        /// can be instantiated. The type system only performs basic allocation
        /// and structure setups for instances: actual instance creation should
        /// happen through functions supplied by the type's fundamental type
        /// implementation.  So use of g_type_create_instance() is reserved for
        /// implementators of fundamental types only. E.g. instances of the
        /// #GObject hierarchy should be created via g_object_new() and never
        /// directly through g_type_create_instance() which doesn't handle things
        /// like singleton objects or object construction.
        /// </summary>
        /// <remarks>
        /// The extended members of the returned instance are guaranteed to be filled
        /// with zeros.
        ///
        /// Note: Do not use this function, unless you're implementing a
        /// fundamental type. Also language bindings should not use this
        /// function, but g_object_new() instead.
        /// </remarks>
        /// <param name="type">
        /// an instantiatable type to create an instance for
        /// </param>
        /// <returns>
        /// an allocated and initialized instance, subject to further
        ///     treatment by the fundamental type implementation
        /// </returns>
        public static TypeInstance CreateInstance(GType type)
        {
            var ret_ = g_type_create_instance(type);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInstance>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        /// <summary>
        /// Returns the length of the ancestry of the passed in type. This
        /// includes the type itself, so that e.g. a fundamental type has depth 1.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the depth of @type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_type_depth(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the length of the ancestry of the passed in type. This
        /// includes the type itself, so that e.g. a fundamental type has depth 1.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the depth of @type
        /// </returns>
        public static uint Depth(GType type)
        {
            var ret = g_type_depth(type);
            return ret;
        }

        /// <summary>
        /// Ensures that the indicated @type has been registered with the
        /// type system, and its _class_init() method has been run.
        /// </summary>
        /// <remarks>
        /// In theory, simply calling the type's _get_type() method (or using
        /// the corresponding macro) is supposed take care of this. However,
        /// _get_type() methods are often marked %G_GNUC_CONST for performance
        /// reasons, even though this is technically incorrect (since
        /// %G_GNUC_CONST requires that the function not have side effects,
        /// which _get_type() methods do on the first call). As a result, if
        /// you write a bare call to a _get_type() macro, it may get optimized
        /// out by the compiler. Using g_type_ensure() guarantees that the
        /// type's _get_type() method is called.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        [Since ("2.34")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_ensure(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Ensures that the indicated @type has been registered with the
        /// type system, and its _class_init() method has been run.
        /// </summary>
        /// <remarks>
        /// In theory, simply calling the type's _get_type() method (or using
        /// the corresponding macro) is supposed take care of this. However,
        /// _get_type() methods are often marked %G_GNUC_CONST for performance
        /// reasons, even though this is technically incorrect (since
        /// %G_GNUC_CONST requires that the function not have side effects,
        /// which _get_type() methods do on the first call). As a result, if
        /// you write a bare call to a _get_type() macro, it may get optimized
        /// out by the compiler. Using g_type_ensure() guarantees that the
        /// type's _get_type() method is called.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        [Since ("2.34")]
        public static void Ensure(GType type)
        {
            g_type_ensure(type);
        }

        /// <summary>
        /// Frees an instance of a type, returning it to the instance pool for
        /// the type, if there is one.
        /// </summary>
        /// <remarks>
        /// Like g_type_create_instance(), this function is reserved for
        /// implementors of fundamental types.
        /// </remarks>
        /// <param name="instance">
        /// an instance of a type
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_free_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        /// <summary>
        /// Frees an instance of a type, returning it to the instance pool for
        /// the type, if there is one.
        /// </summary>
        /// <remarks>
        /// Like g_type_create_instance(), this function is reserved for
        /// implementors of fundamental types.
        /// </remarks>
        /// <param name="instance">
        /// an instance of a type
        /// </param>
        public static void FreeInstance(TypeInstance instance)
        {
            var instance_ = instance.UnsafeHandle;
            g_type_free_instance(instance_);
        }

        /// <summary>
        /// Returns the next free fundamental type id which can be used to
        /// register a new fundamental type with g_type_register_fundamental().
        /// The returned type ID represents the highest currently registered
        /// fundamental type identifier.
        /// </summary>
        /// <returns>
        /// the next available fundamental type ID to be registered,
        ///     or 0 if the type system ran out of fundamental type IDs
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_fundamental_next();

        /// <summary>
        /// Returns the next free fundamental type id which can be used to
        /// register a new fundamental type with g_type_register_fundamental().
        /// The returned type ID represents the highest currently registered
        /// fundamental type identifier.
        /// </summary>
        /// <returns>
        /// the next available fundamental type ID to be registered,
        ///     or 0 if the type system ran out of fundamental type IDs
        /// </returns>
        public static GType FundamentalNext()
        {
            var ret = g_type_fundamental_next();
            return ret;
        }

        /// <summary>
        /// Returns the number of instances allocated of the particular type;
        /// this is only available if GLib is built with debugging support and
        /// the instance_count debug flag is set (by setting the GOBJECT_DEBUG
        /// variable to include instance-count).
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the number of instances allocated of the given type;
        ///   if instance counts are not available, returns 0.
        /// </returns>
        [Since ("2.44")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="int" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_type_get_instance_count(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the number of instances allocated of the particular type;
        /// this is only available if GLib is built with debugging support and
        /// the instance_count debug flag is set (by setting the GOBJECT_DEBUG
        /// variable to include instance-count).
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the number of instances allocated of the given type;
        ///   if instance counts are not available, returns 0.
        /// </returns>
        [Since ("2.44")]
        public static int GetInstanceCount(GType type)
        {
            var ret = g_type_get_instance_count(type);
            return ret;
        }

        /// <summary>
        /// Returns the #GTypePlugin structure for @type.
        /// </summary>
        /// <param name="type">
        /// #GType to retrieve the plugin for
        /// </param>
        /// <returns>
        /// the corresponding plugin
        ///     if @type is a dynamic type, %NULL otherwise
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_get_plugin(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the #GTypePlugin structure for @type.
        /// </summary>
        /// <param name="type">
        /// #GType to retrieve the plugin for
        /// </param>
        /// <returns>
        /// the corresponding plugin
        ///     if @type is a dynamic type, %NULL otherwise
        /// </returns>
        public static TypePlugin GetPlugin(GType type)
        {
            var ret_ = g_type_get_plugin(type);
            var ret = default(TypePlugin);
            throw new System.NotImplementedException();
            return ret;
        }

        /// <summary>
        /// Returns an opaque serial number that represents the state of the set
        /// of registered types. Any time a type is registered this serial changes,
        /// which means you can cache information based on type lookups (such as
        /// g_type_from_name()) and know if the cache is still valid at a later
        /// time by comparing the current serial with the one at the type lookup.
        /// </summary>
        /// <returns>
        /// An unsigned int, representing the state of type registrations
        /// </returns>
        [Since ("2.36")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_type_get_type_registration_serial();

        /// <summary>
        /// Returns an opaque serial number that represents the state of the set
        /// of registered types. Any time a type is registered this serial changes,
        /// which means you can cache information based on type lookups (such as
        /// g_type_from_name()) and know if the cache is still valid at a later
        /// time by comparing the current serial with the one at the type lookup.
        /// </summary>
        /// <returns>
        /// An unsigned int, representing the state of type registrations
        /// </returns>
        [Since ("2.36")]
        public static uint TypeRegistrationSerial
        {
            get
            {
                var ret = g_type_get_type_registration_serial();
                return ret;
            }
        }

        /// <summary>
        /// This function used to initialise the type system.  Since GLib 2.36,
        /// the type system is initialised automatically and this function does
        /// nothing.
        /// </summary>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_init();

        /// <summary>
        /// This function used to initialise the type system.  Since GLib 2.36,
        /// the type system is initialised automatically and this function does
        /// nothing.
        /// </summary>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        public static void Init()
        {
            g_type_init();
        }

        /// <summary>
        /// This function used to initialise the type system with debugging
        /// flags.  Since GLib 2.36, the type system is initialised automatically
        /// and this function does nothing.
        /// </summary>
        /// <remarks>
        /// If you need to enable debugging features, use the GOBJECT_DEBUG
        /// environment variable.
        /// </remarks>
        /// <param name="debugFlags">
        /// bitwise combination of #GTypeDebugFlags values for
        ///     debugging purposes
        /// </param>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_init_with_debug_flags(
            /* <type name="TypeDebugFlags" type="GTypeDebugFlags" managed-name="TypeDebugFlags" /> */
            /* transfer-ownership:none */
            TypeDebugFlags debugFlags);

        /// <summary>
        /// This function used to initialise the type system with debugging
        /// flags.  Since GLib 2.36, the type system is initialised automatically
        /// and this function does nothing.
        /// </summary>
        /// <remarks>
        /// If you need to enable debugging features, use the GOBJECT_DEBUG
        /// environment variable.
        /// </remarks>
        /// <param name="debugFlags">
        /// bitwise combination of #GTypeDebugFlags values for
        ///     debugging purposes
        /// </param>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        public static void InitWithDebugFlags(TypeDebugFlags debugFlags)
        {
            g_type_init_with_debug_flags(debugFlags);
        }

        /// <summary>
        /// Return a newly allocated and 0-terminated array of type IDs, listing
        /// the interface types that @type conforms to.
        /// </summary>
        /// <param name="type">
        /// the type to list interface types for
        /// </param>
        /// <param name="nInterfaces">
        /// location to store the length of
        ///     the returned array, or %NULL
        /// </param>
        /// <returns>
        /// Newly allocated
        ///     and 0-terminated array of interface types, free with g_free()
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
         *   <type name="GType" type="GType" managed-name="GType" />
         * </array> */
        /* transfer-ownership:full */
        static extern IntPtr g_type_interfaces(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            uint* nInterfaces);

        /// <summary>
        /// Return a newly allocated and 0-terminated array of type IDs, listing
        /// the interface types that @type conforms to.
        /// </summary>
        /// <param name="type">
        /// the type to list interface types for
        /// </param>
        /// <returns>
        /// Array of interface types
        /// </returns>
        public static ReadOnlyMemory<GType> Interfaces(GType type)
        {
            uint nInterfaces_;
            var ret_ = g_type_interfaces(type, &nInterfaces_);
            var ret = new ReadOnlyMemory<GType>(ret_, (int)nInterfaces_, Transfer.Full);
            return ret.Memory;
        }

        /// <summary>
        /// If @is_a_type is a derivable type, check whether @type is a
        /// descendant of @is_a_type. If @is_a_type is an interface, check
        /// whether @type conforms to it.
        /// </summary>
        /// <param name="type">
        /// type to check ancestry for
        /// </param>
        /// <param name="isAType">
        /// possible ancestor of @type or interface that @type
        ///     could conform to
        /// </param>
        /// <returns>
        /// %TRUE if @type is a @is_a_type
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_type_is_a(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        /// <summary>
        /// If @is_a_type is a derivable type, check whether @type is a
        /// descendant of @is_a_type. If @is_a_type is an interface, check
        /// whether @type conforms to it.
        /// </summary>
        /// <param name="type">
        /// type to check ancestry for
        /// </param>
        /// <param name="isAType">
        /// possible ancestor of @type or interface that @type
        ///     could conform to
        /// </param>
        /// <returns>
        /// %TRUE if @type is a @is_a_type
        /// </returns>
        public static bool IsA(GType type, GType isAType)
        {
            var ret = g_type_is_a(type, isAType);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_class(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        public static UnownedUtf8 NameFromClass(TypeClass gClass)
        {
            var gClass_ = gClass.UnsafeHandle;
            var ret_ = g_type_name_from_class(gClass_);
            var ret = new UnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        public static UnownedUtf8 NameFromInstance(TypeInstance instance)
        {
            var instance_ = instance.UnsafeHandle;
            var ret_ = g_type_name_from_instance(instance_);
            var ret = new UnownedUtf8(ret_, -1);
            return ret;
        }

        /// <summary>
        /// Given a @leaf_type and a @root_type which is contained in its
        /// anchestry, return the type that @root_type is the immediate parent
        /// of. In other words, this function determines the type that is
        /// derived directly from @root_type which is also a base class of
        /// @leaf_type.  Given a root type and a leaf type, this function can
        /// be used to determine the types and order in which the leaf type is
        /// descended from the root type.
        /// </summary>
        /// <param name="leafType">
        /// descendant of @root_type and the type to be returned
        /// </param>
        /// <param name="rootType">
        /// immediate parent of the returned type
        /// </param>
        /// <returns>
        /// immediate child of @root_type and anchestor of @leaf_type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_next_base(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType leafType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType rootType);

        /// <summary>
        /// Given a @leaf_type and a @root_type which is contained in its
        /// anchestry, return the type that @root_type is the immediate parent
        /// of. In other words, this function determines the type that is
        /// derived directly from @root_type which is also a base class of
        /// @leaf_type.  Given a root type and a leaf type, this function can
        /// be used to determine the types and order in which the leaf type is
        /// descended from the root type.
        /// </summary>
        /// <param name="leafType">
        /// descendant of @root_type and the type to be returned
        /// </param>
        /// <param name="rootType">
        /// immediate parent of the returned type
        /// </param>
        /// <returns>
        /// immediate child of @root_type and anchestor of @leaf_type
        /// </returns>
        public static GType NextBase(GType leafType, GType rootType)
        {
            var ret = g_type_next_base(leafType, rootType);
            return ret;
        }

        /// <summary>
        /// Get the corresponding quark of the type IDs name.
        /// </summary>
        /// <param name="type">
        /// type to return quark of type name for
        /// </param>
        /// <returns>
        /// the type names quark or 0
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_type_qname(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Get the corresponding quark of the type IDs name.
        /// </summary>
        /// <param name="type">
        /// type to return quark of type name for
        /// </param>
        /// <returns>
        /// the type names quark or 0
        /// </returns>
        public static Quark Qname(GType type)
        {
            var ret = g_type_qname(type);
            return ret;
        }

        /// <summary>
        /// Registers @type_name as the name of a new dynamic type derived from
        /// @parent_type.  The type system uses the information contained in the
        /// #GTypePlugin structure pointed to by @plugin to manage the type and its
        /// instances (if not abstract).  The value of @flags determines the nature
        /// (e.g. abstract or not) of the type.
        /// </summary>
        /// <param name="parentType">
        /// type from which this type will be derived
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GTypeInfo from
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the new type identifier or #G_TYPE_INVALID if registration failed
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_register_dynamic(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType parentType,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeName,
            /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
            /* transfer-ownership:none */
            IntPtr plugin,
            /* <type name="TypeFlags" type="GTypeFlags" managed-name="TypeFlags" /> */
            /* transfer-ownership:none */
            TypeFlags flags);

        /// <summary>
        /// Registers @type_name as the name of a new dynamic type derived from
        /// @parent_type.  The type system uses the information contained in the
        /// #GTypePlugin structure pointed to by @plugin to manage the type and its
        /// instances (if not abstract).  The value of @flags determines the nature
        /// (e.g. abstract or not) of the type.
        /// </summary>
        /// <param name="parentType">
        /// type from which this type will be derived
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GTypeInfo from
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the new type identifier or #G_TYPE_INVALID if registration failed
        /// </returns>
        public static GType RegisterDynamic(GType parentType, UnownedUtf8 typeName, TypePlugin plugin, TypeFlags flags)
        {
            var typeName_ = typeName.UnsafeHandle;
            var plugin_ = plugin.UnsafeHandle;
            var ret = g_type_register_dynamic(parentType, typeName_, plugin_, flags);
            return ret;
        }

        /// <summary>
        /// Registers @type_id as the predefined identifier and @type_name as the
        /// name of a fundamental type. If @type_id is already registered, or a
        /// type named @type_name is already registered, the behaviour is undefined.
        /// The type system uses the information contained in the #GTypeInfo structure
        /// pointed to by @info and the #GTypeFundamentalInfo structure pointed to by
        /// @finfo to manage the type and its instances. The value of @flags determines
        /// additional characteristics of the fundamental type.
        /// </summary>
        /// <param name="typeId">
        /// a predefined type identifier
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="info">
        /// #GTypeInfo structure for this type
        /// </param>
        /// <param name="finfo">
        /// #GTypeFundamentalInfo structure for this type
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the predefined type identifier
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_register_fundamental(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType typeId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeName,
            /* <type name="TypeInfo" type="const GTypeInfo*" managed-name="TypeInfo" /> */
            /* transfer-ownership:none */
            TypeInfo info,
            /* <type name="TypeFundamentalInfo" type="const GTypeFundamentalInfo*" managed-name="TypeFundamentalInfo" /> */
            /* transfer-ownership:none */
            TypeFundamentalInfo finfo,
            /* <type name="TypeFlags" type="GTypeFlags" managed-name="TypeFlags" /> */
            /* transfer-ownership:none */
            TypeFlags flags);

        /// <summary>
        /// Registers @type_id as the predefined identifier and @type_name as the
        /// name of a fundamental type. If @type_id is already registered, or a
        /// type named @type_name is already registered, the behaviour is undefined.
        /// The type system uses the information contained in the #GTypeInfo structure
        /// pointed to by @info and the #GTypeFundamentalInfo structure pointed to by
        /// @finfo to manage the type and its instances. The value of @flags determines
        /// additional characteristics of the fundamental type.
        /// </summary>
        /// <param name="typeId">
        /// a predefined type identifier
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="info">
        /// #GTypeInfo structure for this type
        /// </param>
        /// <param name="finfo">
        /// #GTypeFundamentalInfo structure for this type
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the predefined type identifier
        /// </returns>
        public static GType RegisterFundamental(GType typeId, UnownedUtf8 typeName, TypeInfo info, TypeFundamentalInfo finfo, TypeFlags flags)
        {
            var typeName_ = typeName.UnsafeHandle;
            var ret = g_type_register_fundamental(typeId, typeName_, info, finfo, flags);
            return ret;
        }

        /// <summary>
        /// Removes a previously installed #GTypeClassCacheFunc. The cache
        /// maintained by @cache_func has to be empty when calling
        /// g_type_remove_class_cache_func() to avoid leaks.
        /// </summary>
        /// <param name="cacheData">
        /// data that was given when adding @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeClassCacheFunc cacheFunc);

        /// <summary>
        /// Removes a previously installed #GTypeClassCacheFunc. The cache
        /// maintained by @cache_func has to be empty when calling
        /// g_type_remove_class_cache_func() to avoid leaks.
        /// </summary>
        /// <param name="cacheData">
        /// data that was given when adding @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        public static void RemoveClassCacheFunc(IntPtr cacheData, TypeClassCacheFunc cacheFunc)
        {
            var cacheFunc_ = UnmanagedTypeClassCacheFuncFactory.Create(cacheFunc, false);
            g_type_remove_class_cache_func(cacheData, cacheFunc_);
        }

        /// <summary>
        /// Removes an interface check function added with
        /// g_type_add_interface_check().
        /// </summary>
        /// <param name="checkData">
        /// callback data passed to g_type_add_interface_check()
        /// </param>
        /// <param name="checkFunc">
        /// callback function passed to g_type_add_interface_check()
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            IntPtr checkFunc);


        private class RemoveInterfaceCheck : IDisposable
        {
            private readonly IntPtr checkFunc_;
            private readonly IntPtr destroy_;
            private readonly IntPtr checkData_;

            public RemoveInterfaceCheck(IntPtr checkFunc_, IntPtr destroy_, IntPtr checkData_)
            {
                this.checkFunc_ = checkFunc_;
                this.destroy_ = destroy_;
                this.checkData_ = checkData_;
            }

            public void Dispose()
            {
                g_type_remove_interface_check(checkData_, checkFunc_);
                var destroy = Marshal.GetDelegateForFunctionPointer<UnmanagedDestroyNotify>(destroy_);
                destroy(checkData_);
            }
        }
#endif

        /// <summary>
        /// Gets the managed type for a the GType class.
        /// </summary>
        public static Type GetGTypeStruct(this Type type)
        {
            Type gtypeStructType;
            var gtypeStructAttr = type.GetCustomAttribute<GTypeStructAttribute>(true);
            if (gtypeStructAttr is null) {
                if (type.IsEnum) {
                    // GTypeStructAttribute is not needed on Enums/Flags
                    var flagsAttr = type.GetCustomAttribute<FlagsAttribute>();
                    if (flagsAttr is null) {
                        gtypeStructType = typeof(EnumClass);
                    }
                    else {
                        gtypeStructType = typeof(FlagsClass);
                    }
                }
                else {
                    var message = $"Type '{type.FullName}' does not have have GTypeStructAttribute";
                    throw new ArgumentException(message, nameof(type));
                }
            }
            else {
                gtypeStructType = gtypeStructAttr.GTypeStruct;
            }

            if (gtypeStructType is null) {
                throw new ArgumentException($"Type '{type.FullName}' does not specify GTypeStruct", nameof(type));
            }

            return gtypeStructType;
        }

        /// <summary>
        /// Gets the managed type for a the GType class.
        /// </summary>
        public static Type GetGTypeStruct(this GType type)
        {
            return type.ToType().GetGTypeStruct();
        }

        /// <summary>
        /// Gets the <see cref="GType"/> for the managed type.
        /// </summary>
        /// <returns>
        /// The <see cref="GType"/> or <see cref="GType.Invalid"/> if the type
        /// is not registered.
        /// </returns>
        /// <param name="type">Type.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="type"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static GType ToGType(this Type type)
        {
            return FromType(type);
        }

        /// <summary>
        /// Gets the <see cref="GType"/> for the managed objcet.
        /// </summary>
        /// <returns>
        /// The <see cref="GType"/> or <see cref="GType.Invalid"/> if the type
        /// is not registered.
        /// </returns>
        /// <param name="obj">Type.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the Type of <paramref name="obj"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static GType GetGType(this object obj)
        {
            return FromType(obj.GetType());
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_default_interface_peek(GType type);
    }
}
