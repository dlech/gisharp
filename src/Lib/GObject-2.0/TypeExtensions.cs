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
    unsafe partial class TypeExtensions
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

        /// <summary>
        /// Registers <paramref name="typeName"/> as the name of a new static
        /// type derived from <paramref name="parentType"/>.
        /// </summary>
        /// <returns>The new type identifier.</returns>
        /// <param name="parentType">Type from which this type will be derived.</param>
        /// <param name="typeName">The name of the new type.</param>
        /// <param name="info"><see cref="TypeInfo"/> structure for this type.</param>
        /// <param name="flags">Bitwise combination of <see cref="TypeFlags"/> values.</param>
        static GType RegisterStatic(GType parentType, string typeName, TypeInfo info, TypeFlags flags)
        {
            using var typeNameUtf8 = typeName.ToUtf8();
            var typeName_ = (byte*)typeNameUtf8.UnsafeHandle;
            // making a copy of info in unmanged memory that will never be freed
            var info_ = (TypeInfo*)Marshal.AllocCoTaskMem(Marshal.SizeOf<TypeInfo>());
            Marshal.StructureToPtr(info, (IntPtr)info_, false);
            var ret = g_type_register_static(parentType, typeName_, info_, flags);
            GMarshal.PopUnhandledException();

            return ret;
        }

        static void MapPropertyInfo(GType gtype, Type type)
        {
            // type registration has not been completed here, so have to get the
            // object class the hard way by not using our nice wrapper class
            var @class = (ObjectClass.UnmanagedStruct*)TypeClass.g_type_class_ref(gtype);
            GMarshal.PopUnhandledException();
            try {
                foreach (var pspec in ObjectClass.ListProperties(@class)) {
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
                TypeClass.g_type_class_unref(&@class->GTypeClass);
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
                        using var prereqs = TypeInterface.Prerequisites(ifaceGType);
                        foreach (var p in prereqs) {
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
                        var gtypeValues = new Span<EnumValue>(
                            (void*)Marshal.AllocCoTaskMem(sizeof(EnumValue) * (values.Length + 1)),
                            values.Length + 1);
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
                        // zero termination
                        gtypeValues[values.Length] = default;
                        var gtype = Enum.RegisterStatic(gtypeName, gtypeValues);
                        if (gtype == GType.Invalid) {
                            throw new InvalidOperationException("Something bad happend while registering enum.");
                        }

                        Add(gtype, type);

                        return gtype;
                    }
                    else {
                        var gtypeValues = new Span<FlagsValue>(
                            (void*)Marshal.AllocCoTaskMem(sizeof(FlagsValue) * (values.Length + 1)),
                            values.Length + 1);
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
                        // zero termination
                        gtypeValues[values.Length] = default;
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
                GMarshal.PopUnhandledException();

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
            var info_ = (InterfaceInfo*)Marshal.AllocCoTaskMem(Marshal.SizeOf<InterfaceInfo>());
            Marshal.StructureToPtr(info, (IntPtr)info_, false);

            g_type_add_interface_static(instanceType, interfaceType, info_);
            GMarshal.PopUnhandledException();
        }

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
    }
}
