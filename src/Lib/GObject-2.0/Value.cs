// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Diagnostics;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;
using GISharp.Lib.GLib;
using System.Reflection;

namespace GISharp.Lib.GObject
{
    [DebuggerDisplay("{ToString()}")]
    unsafe partial struct Value
    {
        /// <summary>
        /// The maximum number of #GTypeCValues which can be collected for a
        /// single #GValue.
        /// </summary>
        const int CollectFormatMaxLength = 8;

        /// <summary>
        /// If passed to G_VALUE_COLLECT(), allocated data won't be copied
        /// but used verbatim. This does not affect ref-counted types like
        /// objects.
        /// </summary>
        const int NocopyContents = 134217728;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public object? Get()
        {
            AssertInitialized();
            var gtype = ValueGType.Fundamental;
            if (gtype == GType.Boolean) {
                return Boolean;
            }
            if (gtype == GType.Boxed) {
                return Boxed;
            }
            if (gtype == GType.Char) {
                return Char;
            }
            if (gtype == GType.UChar) {
                return UChar;
            }
            if (gtype == GType.Double) {
                return Double;
            }
            if (gtype == GType.Float) {
                return Float;
            }
            if (gtype == GType.Enum) {
                var enumType = ValueGType.ToType();
                return System.Enum.ToObject(enumType, Enum);
            }
            if (gtype == GType.Flags) {
                var enumType = ValueGType.ToType();
                return System.Enum.ToObject(enumType, Flags);
            }
            if (gtype == GType.Int) {
                return Int;
            }
            if (gtype == GType.UInt) {
                return UInt;
            }
            if (gtype == GType.Int64) {
                return Int64;
            }
            if (gtype == GType.UInt64) {
                return UInt64;
            }
            if (gtype == GType.Long) {
                return Long;
            }
            if (gtype == GType.ULong) {
                return ULong;
            }
            if (gtype == GType.Object) {
                return Object;
            }
            if (gtype == GType.Param) {
                return Param;
            }
            if (ValueGType == GType.Type) {
                // GType has fundamental type of void, so we can't check the
                // fundamental type here and also the check has to be before
                // Pointer (which is void)
                return GType;
            }
            if (gtype == GType.Pointer) {
                return Pointer;
            }
            if (gtype == GType.String) {
                return (Utf8?)String;
            }
            if (gtype == GType.Variant) {
                return Variant;
            }
            throw new GTypeException($"unhandled GType: {ValueGType}");
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public void Set(object? obj)
        {
            AssertInitialized();
            var fundamentalType = gType.Fundamental;
            try {
                if (fundamentalType == GType.Boolean) {
                    Boolean = (bool)obj!;
                }
                else if (fundamentalType == GType.Boxed) {
                    Boxed = (Boxed?)obj;
                }
                else if (fundamentalType == GType.Char) {
                    Char = (sbyte)obj!;
                }
                else if (fundamentalType == GType.UChar) {
                    UChar = (byte)obj!;
                }
                else if (fundamentalType == GType.Double) {
                    Double = (double)obj!;
                }
                else if (fundamentalType == GType.Float) {
                    Float = (float)obj!;
                }
                else if (fundamentalType == GType.Enum) {
                    Enum = (int)obj!;
                }
                else if (fundamentalType == GType.Flags) {
                    Flags = (uint)(int)obj!;
                }
                else if (fundamentalType == GType.Int) {
                    Int = (int)obj!;
                }
                else if (fundamentalType == GType.UInt) {
                    UInt = (uint)obj!;
                }
                else if (fundamentalType == GType.Int64) {
                    Int64 = (long)obj!;
                }
                else if (fundamentalType == GType.UInt64) {
                    UInt64 = (ulong)obj!;
                }
                else if (fundamentalType == GType.Long) {
                    Long = (clong)obj!;
                }
                else if (fundamentalType == GType.ULong) {
                    ULong = (culong)obj!;
                }
                else if (fundamentalType == GType.Object) {
                    Object = (Object?)obj;
                }
                else if (fundamentalType == GType.Param) {
                    Param = (ParamSpec?)obj;
                }
                else if (ValueGType == GType.Type) {
                    // GType has fundamental type of void, so this check must
                    // be before Pointer and not check the fundamental GType
                    GType = (GType)obj!;
                }
                else if (fundamentalType == GType.Pointer) {
                    Pointer = (IntPtr)obj!;
                }
                else if (fundamentalType == GType.String) {
                    if (obj is string str) {
                        obj = new Utf8(str);
                    }
                    if (obj is Utf8 utf8) {
                        String = new UnownedUtf8(utf8.UnsafeHandle, -1);
                    }
                    else if (obj?.GetType() == typeof(UnownedUtf8)) {
                        // It is not possible to cast to UnownedUtf8 since it
                        // is a ref struct. Reflection got us into this situation,
                        // so reflection is the only way out.
                        var utf8_ = (byte*)(IntPtr)unownedUtf8HandleProperty.GetValue(obj)!;
                        fixed (Value* value_ = &this) {
                            g_value_set_string(value_, utf8_);
                            GMarshal.PopUnhandledException();
                        }
                    }
                    else if (obj?.GetType() == typeof(NullableUnownedUtf8)) {
                        // It is not possible to cast to NullableUnownedUtf8 since it
                        // is a ref struct. Reflection got us into this situation,
                        // so reflection is the only way out.
                        var utf8_ = (byte*)(IntPtr)nullableUnownedUtf8HandleProperty.GetValue(obj)!;
                        fixed (Value* value_ = &this) {
                            g_value_set_string(value_, utf8_);
                            GMarshal.PopUnhandledException();
                        }
                    }
                    else {
                        throw new InvalidCastException();
                    }
                }
                else if (fundamentalType == GType.Variant) {
                    Variant = (Variant?)obj;
                }
                else {
                    throw new GTypeException($"unhandled GType: {gType}");
                }
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException("Wrong type", nameof(obj), ex);
            }
        }

        static readonly PropertyInfo unownedUtf8HandleProperty =
            typeof(UnownedUtf8).GetProperty(nameof(UnownedUtf8.UnsafeHandle))!;

        static readonly PropertyInfo nullableUnownedUtf8HandleProperty =
            typeof(NullableUnownedUtf8).GetProperty(nameof(NullableUnownedUtf8.UnsafeHandle))!;

        /// <summary>
        /// Gets the GType of the stored value.
        /// </summary>
        /// <value>The value's GType.</value>
        public GType ValueGType => gType;

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="bool"/>.
        /// </summary>
        public static explicit operator bool(Value value)
        {
            try {
                return value.Boolean;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to bool", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="bool"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(bool value)
        {
            return new Value(GType.Boolean, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="sbyte"/>.
        /// </summary>
        public static explicit operator sbyte(Value value)
        {
            try {
                return value.Char;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to sbyte", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="sbyte"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(sbyte value)
        {
            return new Value(GType.Char, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="byte"/>.
        /// </summary>
        public static explicit operator byte(Value value)
        {
            try {
                return value.UChar;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to byte", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="byte"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(byte value)
        {
            return new Value(GType.UChar, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="int"/>.
        /// </summary>
        public static explicit operator int(Value value)
        {
            try {
                return value.Int;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to int", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="int"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(int value)
        {
            return new Value(GType.Int, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="uint"/>.
        /// </summary>
        public static explicit operator uint(Value value)
        {
            try {
                return value.UInt;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to uint", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="uint"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(uint value)
        {
            return new Value(GType.UInt, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="long"/>.
        /// </summary>
        public static explicit operator long(Value value)
        {
            try {
                return value.Int64;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to long", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="long"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(long value)
        {
            return new Value(GType.Int64, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="ulong"/>.
        /// </summary>
        public static explicit operator ulong(Value value)
        {
            try {
                return value.UInt64;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ulong", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(ulong value)
        {
            return new Value(GType.UInt64, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="clong"/>.
        /// </summary>
        public static explicit operator clong(Value value)
        {
            try {
                return value.Long;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to clong", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="clong"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(clong value)
        {
            return new Value(GType.Long, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="culong"/>.
        /// </summary>
        public static explicit operator culong(Value value)
        {
            try {
                return value.ULong;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to culong", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="culong"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(culong value)
        {
            return new Value(GType.ULong, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="float"/>.
        /// </summary>
        public static explicit operator float(Value value)
        {
            try {
                return value.Float;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to float", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="float"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(float value)
        {
            return new Value(GType.Float, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="double"/>.
        /// </summary>
        public static explicit operator double(Value value)
        {
            try {
                return value.Double;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to double", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="double"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(double value)
        {
            return new Value(GType.Double, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="IntPtr"/>.
        /// </summary>
        public static explicit operator IntPtr(Value value)
        {
            try {
                return value.Pointer;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to IntPtr", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="IntPtr"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(IntPtr value)
        {
            return new Value(GType.Pointer, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="Object"/>.
        /// </summary>
        public static explicit operator Object?(Value value)
        {
            try {
                return value.Object;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to GObject", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="Object"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(Object value)
        {
            return new Value(value.GetGType(), value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="string"/>.
        /// </summary>
        public static explicit operator string?(Value value)
        {
            try {
                return value.String;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to string", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(string? value)
        {
            return new Value(GType.String, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="ParamSpec"/>.
        /// </summary>
        public static explicit operator ParamSpec?(Value value)
        {
            try {
                return value.Param;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ParamSpec", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="ParamSpec"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(ParamSpec value)
        {
            return new Value(value.GetGType(), value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="Boxed"/>.
        /// </summary>
        public static explicit operator Boxed?(Value value)
        {
            try {
                return value.Boxed;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ParamSpec", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="Boxed"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(Boxed value)
        {
            return new Value(value.GetGType(), value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="GType"/>.
        /// </summary>
        public static explicit operator GType(Value value)
        {
            try {
                return value.GType;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to GType", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="GType"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(GType value)
        {
            return new Value(GType.Type, value);
        }

        /// <summary>
        /// Converts a <see cref="Value"/> to a <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant?(Value value)
        {
            try {
                return value.Variant;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to Variant", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="Variant"/> to a <see cref="Value"/>.
        /// </summary>
        public static explicit operator Value(Variant? value)
        {
            return new Value(GType.Variant, value);
        }

        partial void CheckGetBooleanArgs()
        {
            AssertType(GType.Boolean);
        }

        partial void CheckSetBooleanArgs(bool vBoolean)
        {
            AssertType(GType.Boolean);
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.
        /// </summary>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        Boxed? Boxed {
            get {
                AssertType(GType.Boxed);
                var managedType = ValueGType.ToType();
                fixed (Value* value_ = &this) {
                    var ret_ = g_value_get_boxed(value_);
                    GMarshal.PopUnhandledException();
                    return (Boxed?)Opaque.GetInstance(managedType, ret_, Transfer.None);
                }
            }
            set {
                AssertType(GType.Boxed);
                var boxed_ = value?.UnsafeHandle ?? IntPtr.Zero;
                fixed (Value* value_ = &this) {
                    g_value_set_boxed(value_, boxed_);
                    GMarshal.PopUnhandledException();
                }
            }
        }

        partial void CheckGetDoubleArgs()
        {
            AssertType(GType.Double);
        }

        partial void CheckSetDoubleArgs(double vDouble)
        {
            AssertType(GType.Double);
        }

        partial void CheckGetEnumArgs()
        {
            AssertType(GType.Enum);
        }

        partial void CheckSetEnumArgs(int vEnum)
        {
            AssertType(GType.Enum);
        }

        partial void CheckGetFlagsArgs()
        {
            AssertType(GType.Flags);
        }

        partial void CheckSetFlagsArgs(uint vFlags)
        {
            AssertType(GType.Flags);
        }

        partial void CheckGetFloatArgs()
        {
            AssertType(GType.Float);
        }

        partial void CheckSetFloatArgs(float vFloat)
        {
            AssertType(GType.Float);
        }

        partial void CheckGetGTypeArgs()
        {
            AssertType(GType.Type);
        }

        partial void CheckSetGTypeArgs(GType vGType)
        {
            AssertType(GType.Type);
        }

        partial void CheckGetIntArgs()
        {
            AssertType(GType.Int);
        }

        partial void CheckSetIntArgs(int vInt)
        {
            AssertType(GType.Int);
        }

        partial void CheckGetInt64Args()
        {
            AssertType(GType.Int64);
        }

        partial void CheckSetInt64Args(long vInt64)
        {
            AssertType(GType.Int64);
        }

        partial void CheckGetLongArgs()
        {
            AssertType(GType.Long);
        }

        partial void CheckSetLongArgs(clong vLong)
        {
            AssertType(GType.Long);
        }

        partial void CheckGetObjectArgs()
        {
            AssertType(GType.Object);
        }

        partial void CheckSetObjectArgs(Object? vObject)
        {
            AssertType(GType.Object);
        }

        partial void CheckGetParamArgs()
        {
            AssertType(GType.Param);
        }

        partial void CheckSetParamArgs(ParamSpec? vParam)
        {
            AssertType(GType.Param);
        }

        partial void CheckGetPointerArgs()
        {
            AssertType(GType.Pointer);
        }

        partial void CheckSetPointerArgs(IntPtr vPointer)
        {
            AssertType(GType.Pointer);
        }

        partial void CheckGetCharArgs()
        {
            AssertType(GType.Char);
        }

        partial void CheckSetCharArgs(sbyte vChar)
        {
            AssertType(GType.Char);
        }

        partial void CheckGetStringArgs()
        {
            AssertType(GType.String);
        }

        partial void CheckSetStringArgs(NullableUnownedUtf8 vString)
        {
            AssertType(GType.String);
        }

        partial void CheckGetUCharArgs()
        {
            AssertType(GType.UChar);
        }

        partial void CheckSetUCharArgs(byte vUchar)
        {
            AssertType(GType.UChar);
        }

        partial void CheckGetUIntArgs()
        {
            AssertType(GType.UInt);
        }

        partial void CheckSetUIntArgs(uint vUint)
        {
            AssertType(GType.UInt);
        }

        partial void CheckGetUInt64Args()
        {
            AssertType(GType.UInt64);
        }

        partial void CheckSetUInt64Args(ulong vUint64)
        {
            AssertType(GType.UInt64);
        }

        partial void CheckGetULongArgs()
        {
            AssertType(GType.ULong);
        }

        partial void CheckSetULongArgs(culong vULong)
        {
            AssertType(GType.ULong);
        }

        partial void CheckGetVariantArgs()
        {
            AssertType(GType.Variant);
        }

        partial void CheckSetVariantArgs(Variant? vVariant)
        {
            AssertType(GType.Variant);
        }

        partial void CheckInitArgs(GType gType)
        {
            if (gType == GType.Invalid) {
                var message = "Cannot initialize using GType.Invalid.";
                throw new ArgumentException(message, nameof(gType));
            }
            if (gType.IsAbstract) {
                var message = $"Cannot initialize using abstract GType '{gType.Name}'.";
                throw new ArgumentException(message, nameof(gType));
            }
        }

        partial void CheckResetArgs()
        {
            AssertInitialized();
        }

        partial void CheckSetArgs(TypeInstance? instance)
        {
            AssertInitialized();
            if (instance is not null && g_value_type_compatible(instance.GetGType(), gType).IsFalse()) {
                throw new ArgumentException("instance type is not compatible", nameof(instance));
            }
        }

        partial void CheckTransformArgs(ref Value destValue)
        {
            AssertInitialized();
        }

        partial void CheckUnsetArgs()
        {
            AssertInitialized();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Value"/> class.
        /// </summary>
        public Value(GType type)
        {
            gType = GType.Invalid;
            data0 = default;
            data1 = default;

            Init(type);
            if (ValueGType == GType.Invalid) {
                var message = $"{type.Name} cannot be used as Value.";
                throw new ArgumentException(message, nameof(type));
            }
        }

        /// <summary>
        /// Creates a new <see cref="Value"/> instance.
        /// </summary>
        /// <param name="type">
        /// A GObject type.
        /// </param>
        /// <param name="value">
        /// The value to assign.
        /// </param>
        public Value(GType type, object? value) : this(type)
        {
            Set(value);
        }

        /// <summary>
        /// Creates a new <see cref="Value"/> instance.
        /// </summary>
        /// <param name="type">
        /// A managed type.
        /// </param>
        /// <param name="value">
        /// The value to assign.
        /// </param>
        public Value(Type type, object? value) : this(type.ToGType())
        {
            Set(value);
        }

        void AssertType(GType type)
        {
            AssertInitialized();
            if (!gType.IsA(type)) {
                var message = $"Expecting {type.Name} but have {gType.Name}";
                throw new InvalidOperationException(message);
            }
        }

        void AssertInitialized()
        {
            if (gType == GType.Invalid) {
                throw new InvalidOperationException("Value type has not been initialized.");
            }
        }

        /// <summary>
        /// Return a string that describes the contents of this value.
        /// </summary>
        /// <value>The contents.</value>
        /// <remarks>
        /// The main purpose of this function is to describe GValue contents for
        /// debugging output, the way in which the contents are described may
        /// change between different GLib versions.
        /// </remarks>
        public override string ToString()
        {
            AssertInitialized();
            fixed (Value* value_ = &this) {
                var ret_ = g_strdup_value_contents(value_);
                GMarshal.PopUnhandledException();
                using var ret = new Utf8((IntPtr)ret_, Transfer.Full);
                return $"{ValueGType.Name}: {ret}";
            }
        }
    }
}
