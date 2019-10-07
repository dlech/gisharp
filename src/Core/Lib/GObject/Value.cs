using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;
using System.Collections.Generic;
using GISharp.Lib.GLib;
using System.Reflection;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// An opaque structure used to hold different types of values.
    /// </summary>
    [GType("GValue", IsProxyForUnmanagedType = true)]
    [DebuggerDisplay("{ToString ()}")]
    public ref struct Value
    {
        GType type;

#pragma warning disable 414
        // this should never be accessed directly
        //[MarshalAs (UnmanagedType.ByValArray, SizeConst = 2)]
        //ValueDataUnion[] data;

        // using explicit values instead of array so we can use .NET marshaler
        ValueDataUnion data0;
        ValueDataUnion data1;

        [StructLayout(LayoutKind.Explicit)]
        ref struct ValueDataUnion
        {
            [FieldOffset(0)]
            int vInt;

            [FieldOffset(0)]
            uint vUInt;

            [FieldOffset(0)]
            clong vLong;

            [FieldOffset(0)]
            culong vULong;

            [FieldOffset(0)]
            long vInt64;

            [FieldOffset(0)]
            ulong vUInt64;

            [FieldOffset(0)]
            float vFloat;

            [FieldOffset(0)]
            double vDouble;

            [FieldOffset(0)]
            IntPtr vPointer;
        }
#pragma warning restore 414

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

        static readonly Dictionary<Tuple<GType, GType>, GCHandle> transformFuncMap
            = new Dictionary<Tuple<GType, GType>, GCHandle>();
        static readonly object transformFuncMapLock = new object();

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
                return String.Copy();
            }
            if (gtype == GType.Variant) {
                return Variant;
            }
            // TODO: Need more specific exception
            throw new Exception("unhandled GType");
        }

        public void Set(object? obj)
        {
            AssertInitialized();
            var gtype = type.Fundamental;
            try {
                if (gtype == GType.Boolean) {
                    Boolean = (bool)obj!;
                }
                else if (gtype == GType.Boxed) {
                    Boxed = (Boxed?)obj;
                }
                else if (gtype == GType.Char) {
                    Char = (sbyte)obj!;
                }
                else if (gtype == GType.UChar) {
                    UChar = (byte)obj!;
                }
                else if (gtype == GType.Double) {
                    Double = (double)obj!;
                }
                else if (gtype == GType.Float) {
                    Float = (float)obj!;
                }
                else if (gtype == GType.Enum) {
                    Enum = (int)obj!;
                }
                else if (gtype == GType.Flags) {
                    Flags = (uint)(int)obj!;
                }
                else if (gtype == GType.Int) {
                    Int = (int)obj!;
                }
                else if (gtype == GType.UInt) {
                    UInt = (uint)obj!;
                }
                else if (gtype == GType.Int64) {
                    Int64 = (long)obj!;
                }
                else if (gtype == GType.UInt64) {
                    UInt64 = (ulong)obj!;
                }
                else if (gtype == GType.Long) {
                    Long = (clong)obj!;
                }
                else if (gtype == GType.ULong) {
                    ULong = (culong)obj!;
                }
                else if (gtype == GType.Object) {
                    Object = (Object?)obj;
                }
                else if (gtype == GType.Param) {
                    Param = (ParamSpec?)obj;
                }
                else if (ValueGType == GType.Type) {
                    // GType has fundamental type of void, so this check must
                    // be before Pointer and not check the fundamental GType
                    GType = (GType)obj!;
                }
                else if (gtype == GType.Pointer) {
                    Pointer = (IntPtr)obj!;
                }
                else if (gtype == GType.String) {
                    if (obj is string str) {
                        obj = new Utf8(str);
                    }
                    if (obj is Utf8 utf8) {
                        String = new NullableUnownedUtf8(utf8.Handle, -1);
                    }
                    else if (obj?.GetType() == typeof(UnownedUtf8)) {
                        // It is not possible to cast to UnownedUtf8 since it
                        // is a ref struct. Reflection got us into this situation,
                        // so reflection is the only way out.
                        var utf8_ = (IntPtr)unownedUtf8HandleProperty.GetValue(obj);
                        g_value_set_string(ref this, utf8_);
                    }
                    else if (obj?.GetType() == typeof(NullableUnownedUtf8)) {
                        // It is not possible to cast to NullableUnownedUtf8 since it
                        // is a ref struct. Reflection got us into this situation,
                        // so reflection is the only way out.
                        var utf8_ = (IntPtr)nullableUnownedUtf8HandleProperty.GetValue(obj);
                        g_value_set_string(ref this, utf8_);
                    }
                    else {
                        throw new InvalidCastException();
                    }
                }
                else if (gtype == GType.Variant) {
                    Variant = (Variant?)obj;
                }
                else {
                    // TODO: Need more specific exception
                    throw new Exception("unhandled GType");
                }
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException("Wrong type", nameof(obj), ex);
            }
        }

        static readonly PropertyInfo unownedUtf8HandleProperty =
            typeof(UnownedUtf8).GetProperty(nameof(UnownedUtf8.Handle));

        static readonly PropertyInfo nullableUnownedUtf8HandleProperty =
            typeof(NullableUnownedUtf8).GetProperty(nameof(NullableUnownedUtf8.Handle));

        /// <summary>
        /// Gets the GType of the stored value.
        /// </summary>
        /// <value>The value's GType.</value>
        public GType ValueGType {
            get {
                return type;
            }
        }

        public static explicit operator bool(Value value)
        {
            try {
                return value.Boolean;
            }
            catch (Exception ex) {
                throw new InvalidCastException("", ex);
            }
        }

        public static explicit operator Value(bool value)
        {
            return new Value(GType.Boolean, value);
        }

        public static explicit operator sbyte(Value value)
        {
            try {
                return value.Char;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to sbyte", ex);
            }
        }

        public static explicit operator Value(sbyte value)
        {
            return new Value(GType.Char, value);
        }

        public static explicit operator byte(Value value)
        {
            try {
                return value.UChar;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to byte", ex);
            }
        }

        public static explicit operator Value(byte value)
        {
            return new Value(GType.UChar, value);
        }

        public static explicit operator int(Value value)
        {
            try {
                return value.Int;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to int", ex);
            }
        }

        public static explicit operator Value(int value)
        {
            return new Value(GType.Int, value);
        }

        public static explicit operator uint(Value value)
        {
            try {
                return value.UInt;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to uint", ex);
            }
        }

        public static explicit operator Value(uint value)
        {
            return new Value(GType.UInt, value);
        }

        public static explicit operator long(Value value)
        {
            try {
                return value.Int64;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to long", ex);
            }
        }

        public static explicit operator Value(long value)
        {
            return new Value(GType.Int64, value);
        }

        public static explicit operator ulong(Value value)
        {
            try {
                return value.UInt64;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ulong", ex);
            }
        }

        public static explicit operator Value(ulong value)
        {
            return new Value(GType.UInt64, value);
        }

        public static explicit operator clong(Value value)
        {
            try {
                return value.Long;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to clong", ex);
            }
        }

        public static explicit operator Value(clong value)
        {
            return new Value(GType.Long, value);
        }

        public static explicit operator culong(Value value)
        {
            try {
                return value.ULong;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to culong", ex);
            }
        }

        public static explicit operator Value(culong value)
        {
            return new Value(GType.ULong, value);
        }

        public static explicit operator float(Value value)
        {
            try {
                return value.Float;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to float", ex);
            }
        }

        public static explicit operator Value(float value)
        {
            return new Value(GType.Float, value);
        }

        public static explicit operator double(Value value)
        {
            try {
                return value.Double;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to double", ex);
            }
        }

        public static explicit operator Value(double value)
        {
            return new Value(GType.Double, value);
        }

        public static explicit operator IntPtr(Value value)
        {
            try {
                return value.Pointer;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to IntPtr", ex);
            }
        }

        public static explicit operator Value(IntPtr value)
        {
            return new Value(GType.Pointer, value);
        }

        public static explicit operator Object?(Value value)
        {
            try {
                return value.Object;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to GObject", ex);
            }
        }

        public static explicit operator Value(Object value)
        {
            return new Value(GType.Of(value.GetType()), value);
        }

        public static explicit operator string?(Value value)
        {
            try {
                return value.String;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to string", ex);
            }
        }

        public static explicit operator Value(string? value)
        {
            return new Value(GType.String, value);
        }

        public static explicit operator ParamSpec?(Value value)
        {
            try {
                return value.Param;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ParamSpec", ex);
            }
        }

        public static explicit operator Value(ParamSpec value)
        {
            return new Value(GType.Of(value.GetType()), value);
        }

        public static explicit operator Boxed?(Value value)
        {
            try {
                return value.Boxed;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to ParamSpec", ex);
            }
        }

        public static explicit operator Value(Boxed value)
        {
            return new Value(GType.Of(value.GetType()), value);
        }

        public static explicit operator GType(Value value)
        {
            try {
                return value.GType;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to GType", ex);
            }
        }

        public static explicit operator Value(GType value)
        {
            return new Value(GType.Type, value);
        }

        public static explicit operator Variant?(Value value)
        {
            try {
                return value.Variant;
            }
            catch (Exception ex) {
                throw new InvalidCastException("Cannot cast to Variant", ex);
            }
        }

        public static explicit operator Value(Variant? value)
        {
            return new Value(GType.Variant, value);
        }

        /// <summary>
        /// Registers a value transformation function for use in g_value_transform().
        /// A previously registered transformation function for @src_type and @dest_type
        /// will be replaced.
        /// </summary>
        /// <param name="srcType">
        /// Source type.
        /// </param>
        /// <param name="destType">
        /// Target type.
        /// </param>
        /// <param name="transformFunc">
        /// a function which transforms values of type @src_type
        ///  into value of type @dest_type
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_register_transform_func(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType srcType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType destType,
            /* <type name="ValueTransform" type="GValueTransform" managed-name="ValueTransform" /> */
            /* transfer-ownership:none */
            ValueTransform transformFunc);

        /// <summary>
        /// Registers a value transformation function for use in <see cref="TryTransform"/>.
        /// </summary>
        /// <param name="srcType">
        /// Source type.
        /// </param>
        /// <param name="destType">
        /// Target type.
        /// </param>
        /// <param name="transformFunc">
        /// a function which transforms values of type <paramref name="srcType"/>
        ///  into value of type <paramref name="destType"/>
        /// </param>
        /// <remarks>
        /// A previously registered transformation function for <paramref name="srcType"/>
        /// and <paramref name="destType"/> will be replaced.
        /// </remarks>
        public static void RegisterTransformFunc(GType srcType, GType destType, ValueTransform transformFunc)
        {
            lock (transformFuncMapLock) {
                var key = new Tuple<GType, GType>(srcType, destType);
                if (transformFuncMap.ContainsKey(key)) {
                    transformFuncMap[key].Free();
                }
                g_value_register_transform_func(srcType, destType, transformFunc);
                transformFuncMap[key] = GCHandle.Alloc(transformFunc);
            }
        }

        /// <summary>
        /// Returns whether a #GValue of type @src_type can be copied into
        /// a #GValue of type @dest_type.
        /// </summary>
        /// <param name="srcType">
        /// source type to be copied.
        /// </param>
        /// <param name="destType">
        /// destination type for copying.
        /// </param>
        /// <returns>
        /// %TRUE if g_value_copy() is possible with @src_type and @dest_type.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_value_type_compatible(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType srcType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType destType);

        /// <summary>
        /// Returns whether a #GValue of type @src_type can be copied into
        /// a #GValue of type @dest_type.
        /// </summary>
        /// <param name="srcType">
        /// source type to be copied.
        /// </param>
        /// <param name="destType">
        /// destination type for copying.
        /// </param>
        /// <returns>
        /// %TRUE if g_value_copy() is possible with @src_type and @dest_type.
        /// </returns>
        public static bool TypeCompatible(GType srcType, GType destType)
        {
            var ret = g_value_type_compatible(srcType, destType);
            return ret;
        }

        /// <summary>
        /// Check whether g_value_transform() is able to transform values
        /// of type @src_type into values of type @dest_type. Note that for
        /// the types to be transformable, they must be compatible and a
        /// transform function must be registered.
        /// </summary>
        /// <param name="srcType">
        /// Source type.
        /// </param>
        /// <param name="destType">
        /// Target type.
        /// </param>
        /// <returns>
        /// %TRUE if the transformation is possible, %FALSE otherwise.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_value_type_transformable(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType srcType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType destType);

        /// <summary>
        /// Check whether g_value_transform() is able to transform values
        /// of type @src_type into values of type @dest_type. Note that for
        /// the types to be transformable, they must be compatible and a
        /// transform function must be registered.
        /// </summary>
        /// <param name="srcType">
        /// Source type.
        /// </param>
        /// <param name="destType">
        /// Target type.
        /// </param>
        /// <returns>
        /// %TRUE if the transformation is possible, %FALSE otherwise.
        /// </returns>
        public static bool TypeTransformable(GType srcType, GType destType)
        {
            var ret = g_value_type_transformable(srcType, destType);
            return ret;
        }

        /// <summary>
        /// Copies the value of @src_value into @dest_value.
        /// </summary>
        /// <param name="srcValue">
        /// An initialized #GValue structure.
        /// </param>
        /// <param name="destValue">
        /// An initialized #GValue structure of the same type as @src_value.
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_copy(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            out Value destValue);

        /// <summary>
        /// Copies the value of @src_value into @dest_value.
        /// </summary>
        /// <param name="destValue">
        /// An initialized #GValue structure of the same type as @src_value.
        /// </param>
        public void Copy(out Value destValue)
        {
            AssertInitialized();
            g_value_copy(in this, out destValue);
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.  Upon getting,
        /// the boxed value is duplicated and needs to be later freed with
        /// g_boxed_free(), e.g. like: g_boxed_free (G_VALUE_TYPE (@value),
        /// return_value);
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_value_dup_boxed(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.  Upon getting,
        /// the boxed value is duplicated and needs to be later freed with
        /// g_boxed_free(), e.g. like: g_boxed_free (G_VALUE_TYPE (@value),
        /// return_value);
        /// </summary>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        IntPtr DupBoxed()
        {
            AssertInitialized();
            var ret = g_value_dup_boxed(in this);
            return ret;
        }

#if THIS_CODE_IS_NOT_COMPILED
        /// <summary>
        /// Get the contents of a %G_TYPE_OBJECT derived #GValue, increasing
        /// its reference count. If the contents of the #GValue are %NULL, then
        /// %NULL will be returned.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_OBJECT
        /// </param>
        /// <returns>
        /// object content of @value,
        ///          should be unreferenced when no longer needed.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_dup_object (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_OBJECT derived #GValue, increasing
        /// its reference count. If the contents of the #GValue are %NULL, then
        /// %NULL will be returned.
        /// </summary>
        /// <returns>
        /// object content of @value,
        ///          should be unreferenced when no longer needed.
        /// </returns>
        public Object DupObject()
        {
            AssertInitialized ();
            var ret_ = g_value_dup_object(Handle);
            var ret = Object.GetInstance(ret_, Transfer.All);
            return ret;
        }


        /// <summary>
        /// Get the contents of a %G_TYPE_PARAM #GValue, increasing its
        /// reference count.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_PARAM
        /// </param>
        /// <returns>
        /// #GParamSpec content of @value, should be unreferenced when
        ///          no longer needed.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* */
        static extern IntPtr g_value_dup_param (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_PARAM #GValue, increasing its
        /// reference count.
        /// </summary>
        /// <returns>
        /// #GParamSpec content of @value, should be unreferenced when
        ///          no longer needed.
        /// </returns>
        public ParamSpec DupParam()
        {
            AssertInitialized ();
            var ret_ = g_value_dup_param(Handle);
            var ret = ParamSpec.GetInstance(ret_, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Get the contents of a variant #GValue, increasing its refcount.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_VARIANT
        /// </param>
        /// <returns>
        /// variant contents of @value, should be unrefed using
        ///   g_variant_unref() when no longer needed
        /// </returns>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_dup_variant (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a variant #GValue, increasing its refcount.
        /// </summary>
        /// <returns>
        /// variant contents of @value, should be unrefed using
        ///   g_variant_unref() when no longer needed
        /// </returns>
        //[Since("2.26")]
        public GISharp.Lib.GLib.Variant DupVariant()
        {
            AssertInitialized ();
            var ret_ = g_value_dup_variant(Handle);
            var ret = Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Determines if @value will fit inside the size of a pointer value.
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// An initialized #GValue structure.
        /// </param>
        /// <returns>
        /// %TRUE if @value will fit inside a pointer value.
        /// </returns>
        [DllImport "gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_value_fits_pointer(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Determines if @value will fit inside the size of a pointer value.
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <returns>
        /// %TRUE if @value will fit inside a pointer value.
        /// </returns>
        public bool FitsPointer ()
        {
            AssertInitialized ();
            var ret = g_value_fits_pointer (Handle);
            return ret;
        }
#endif

        /// <summary>
        /// Get the contents of a %G_TYPE_BOOLEAN #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_BOOLEAN
        /// </param>
        /// <returns>
        /// boolean contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_value_get_boolean(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_BOOLEAN #GValue.
        /// </summary>
        /// <returns>
        /// boolean contents of @value
        /// </returns>
        bool Boolean {
            get {
                AssertType(GType.Boolean);
                var ret = g_value_get_boolean(in this);
                return ret;
            }

            set {
                AssertType(GType.Boolean);
                g_value_set_boolean(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_boxed(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

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
                var ret_ = g_value_get_boxed(in this);
                return (Boxed?)Opaque.GetInstance(managedType, ret_, Transfer.None);
            }
            set {
                AssertType(GType.Boxed);
                var boxed_ = value?.Handle ?? IntPtr.Zero;
                g_value_set_boxed(ref this, boxed_);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_DOUBLE #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_DOUBLE
        /// </param>
        /// <returns>
        /// double contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
        /* transfer-ownership:none */
        static extern double g_value_get_double(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_DOUBLE #GValue.
        /// </summary>
        /// <returns>
        /// double contents of @value
        /// </returns>
        double Double {
            get {
                AssertType(GType.Double);
                var ret = g_value_get_double(in this);
                return ret;
            }

            set {
                AssertType(GType.Double);
                g_value_set_double(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_ENUM #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_ENUM
        /// </param>
        /// <returns>
        /// enum contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_value_get_enum(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_ENUM #GValue.
        /// </summary>
        /// <returns>
        /// enum contents of @value
        /// </returns>
        int Enum {
            get {
                AssertType(GType.Enum);
                var ret = g_value_get_enum(in this);
                return ret;
            }

            set {
                AssertType(GType.Enum);
                g_value_set_enum(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_FLAGS #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_FLAGS
        /// </param>
        /// <returns>
        /// flags contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_value_get_flags(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_FLAGS #GValue.
        /// </summary>
        /// <returns>
        /// flags contents of @value
        /// </returns>
        uint Flags {
            get {
                AssertType(GType.Flags);
                var ret = g_value_get_flags(in this);
                return ret;
            }

            set {
                AssertType(GType.Flags);

                g_value_set_flags(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_FLOAT #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_FLOAT
        /// </param>
        /// <returns>
        /// float contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gfloat" type="gfloat" managed-name="Gfloat" /> */
        /* transfer-ownership:none */
        static extern float g_value_get_float(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_FLOAT #GValue.
        /// </summary>
        /// <returns>
        /// float contents of @value
        /// </returns>
        float Float {
            get {
                AssertType(GType.Float);
                var ret = g_value_get_float(in this);
                return ret;
            }

            set {
                AssertType(GType.Float);
                g_value_set_float(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_GTYPE #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_GTYPE
        /// </param>
        /// <returns>
        /// the #GType stored in @value
        /// </returns>
        [Since("2.12")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_value_get_gtype(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_GTYPE #GValue.
        /// </summary>
        /// <returns>
        /// the #GType stored in @value
        /// </returns>
        [Since("2.12")]
        GType GType {
            get {
                AssertType(GType.Type);
                var ret = g_value_get_gtype(in this);
                return ret;
            }

            set {
                AssertType(GType.Type);
                g_value_set_gtype(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_INT #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_INT
        /// </param>
        /// <returns>
        /// integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_value_get_int(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_INT #GValue.
        /// </summary>
        /// <returns>
        /// integer contents of @value
        /// </returns>
        int Int {
            get {
                AssertType(GType.Int);
                var ret = g_value_get_int(in this);
                return ret;
            }

            set {
                AssertType(GType.Int);
                g_value_set_int(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_INT64 #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_INT64
        /// </param>
        /// <returns>
        /// 64bit integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern long g_value_get_int64(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_INT64 #GValue.
        /// </summary>
        /// <returns>
        /// 64bit integer contents of @value
        /// </returns>
        long Int64 {
            get {
                AssertType(GType.Int64);
                var ret = g_value_get_int64(in this);
                return ret;
            }

            set {
                AssertType(GType.Int64);
                g_value_set_int64(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_LONG #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_LONG
        /// </param>
        /// <returns>
        /// long integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern clong g_value_get_long(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_LONG #GValue.
        /// </summary>
        /// <returns>
        /// long integer contents of @value
        /// </returns>
        clong Long {
            get {
                AssertType(GType.Long);
                var ret = g_value_get_long(in this);
                return ret;
            }

            set {
                AssertType(GType.Long);
                g_value_set_long(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_OBJECT derived #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_OBJECT derived type
        /// </param>
        /// <returns>
        /// object contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_object(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_OBJECT derived #GValue.
        /// </summary>
        /// <returns>
        /// object contents of @value
        /// </returns>
        Object? Object {
            get {
                AssertType(GType.Object);
                var ret_ = g_value_get_object(in this);
                var ret = Object.GetInstance(ret_, Transfer.None);
                return ret;
            }

            set {
                AssertType(GType.Object);
                g_value_set_object(ref this, value?.Handle ?? IntPtr.Zero);
                GC.KeepAlive(value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_PARAM #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_PARAM
        /// </param>
        /// <returns>
        /// #GParamSpec content of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_param(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_PARAM #GValue.
        /// </summary>
        /// <returns>
        /// #GParamSpec content of @value
        /// </returns>
        ParamSpec? Param {
            get {
                AssertType(GType.Param);
                var ret_ = g_value_get_param(in this);
                var ret = ParamSpec.GetInstance(ret_, Transfer.None);
                return ret;
            }

            set {
                AssertType(GType.Param);
                g_value_set_param(ref this, value?.Handle ?? IntPtr.Zero);
                GC.KeepAlive(value);
            }
        }

        /// <summary>
        /// Get the contents of a pointer #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_POINTER
        /// </param>
        /// <returns>
        /// pointer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_pointer(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a pointer #GValue.
        /// </summary>
        /// <returns>
        /// pointer contents of @value
        /// </returns>
        IntPtr Pointer {
            get {
                AssertType(GType.Pointer);
                var ret = g_value_get_pointer(in this);
                return ret;
            }

            set {
                AssertType(GType.Pointer);
                g_value_set_pointer(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_CHAR #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_CHAR
        /// </param>
        /// <returns>
        /// signed 8 bit integer contents of @value
        /// </returns>
        [Since("2.32")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint8" type="gint8" managed-name="Gint8" /> */
        /* transfer-ownership:none */
        static extern sbyte g_value_get_schar(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_CHAR #GValue.
        /// </summary>
        /// <returns>
        /// signed 8 bit integer contents of @value
        /// </returns>
        [Since("2.32")]
        sbyte Char {
            get {
                AssertType(GType.Char);
                var ret = g_value_get_schar(in this);
                return ret;
            }

            set {
                AssertType(GType.Char);
                g_value_set_schar(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_STRING #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_STRING
        /// </param>
        /// <returns>
        /// string content of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_string(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_STRING #GValue.
        /// </summary>
        /// <returns>
        /// string content of @value
        /// </returns>
        NullableUnownedUtf8 String {
            get {
                AssertType(GType.String);
                var ret_ = g_value_get_string(in this);
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }

            set {
                AssertType(GType.String);
                g_value_set_string(ref this, value.Handle);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_UCHAR #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UCHAR
        /// </param>
        /// <returns>
        /// unsigned character contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint8" type="guchar" managed-name="Guint8" /> */
        /* transfer-ownership:none */
        static extern byte g_value_get_uchar(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UCHAR #GValue.
        /// </summary>
        /// <returns>
        /// unsigned character contents of @value
        /// </returns>
        byte UChar {
            get {
                AssertType(GType.UChar);
                var ret = g_value_get_uchar(in this);
                return ret;
            }

            set {
                AssertType(GType.UChar);
                g_value_set_uchar(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UINT
        /// </param>
        /// <returns>
        /// unsigned integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_value_get_uint(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT #GValue.
        /// </summary>
        /// <returns>
        /// unsigned integer contents of @value
        /// </returns>
        uint UInt {
            get {
                AssertType(GType.UInt);
                var ret = g_value_get_uint(in this);
                return ret;
            }

            set {
                AssertType(GType.UInt);
                g_value_set_uint(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT64 #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UINT64
        /// </param>
        /// <returns>
        /// unsigned 64bit integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
        /* transfer-ownership:none */
        static extern ulong g_value_get_uint64(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT64 #GValue.
        /// </summary>
        /// <returns>
        /// unsigned 64bit integer contents of @value
        /// </returns>
        ulong UInt64 {
            get {
                AssertType(GType.UInt64);
                var ret = g_value_get_uint64(in this);
                return ret;
            }

            set {
                AssertType(GType.UInt64);
                g_value_set_uint64(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a %G_TYPE_ULONG #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_ULONG
        /// </param>
        /// <returns>
        /// unsigned long integer contents of @value
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        static extern culong g_value_get_ulong(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a %G_TYPE_ULONG #GValue.
        /// </summary>
        /// <returns>
        /// unsigned long integer contents of @value
        /// </returns>
        culong ULong {
            get {
                AssertType(GType.ULong);
                var ret = g_value_get_ulong(in this);
                return ret;
            }

            set {
                AssertType(GType.ULong);
                g_value_set_ulong(ref this, value);
            }
        }

        /// <summary>
        /// Get the contents of a variant #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_VARIANT
        /// </param>
        /// <returns>
        /// variant contents of @value
        /// </returns>
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_get_variant(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        /// <summary>
        /// Get the contents of a variant #GValue.
        /// </summary>
        /// <returns>
        /// variant contents of @value
        /// </returns>
        [Since("2.26")]
        Variant? Variant {
            get {
                AssertType(GType.Variant);
                var ret_ = g_value_get_variant(in this);
                var ret = Opaque.GetInstance<Variant>(ret_, Transfer.None);
                return ret;
            }
            set {
                AssertType(GType.Variant);
                g_value_set_variant(ref this, value?.Handle ?? IntPtr.Zero);
                GC.KeepAlive(value);
            }
        }

        /// <summary>
        /// Initializes @value with the default value of @type.
        /// </summary>
        /// <param name="value">
        /// A zero-filled (uninitialized) #GValue structure.
        /// </param>
        /// <param name="gType">
        /// Type the #GValue should hold values of.
        /// </param>
        /// <returns>
        /// the #GValue structure that has been passed in
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_init(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gType);

        /// <summary>
        /// Initializes @value with the default value of @type.
        /// </summary>
        /// <param name="gType">
        /// Type the #GValue should hold values of.
        /// </param>
        /// <returns>
        /// the #GValue structure that has been passed in
        /// </returns>
        public void Init(GType gType)
        {
            if (gType == GType.Invalid) {
                var message = "Cannot initialize using GType.Invalid.";
                throw new ArgumentException(message, nameof(gType));
            }
            if (gType.IsAbstract) {
                var message = $"Cannot initialize using abstract GType '{gType.Name}'.";
                throw new ArgumentException(message, nameof(gType));
            }
            g_value_init(ref this, gType);
        }

        /// <summary>
        /// Initializes and sets @value from an instantiatable type via the
        /// value_table's collect_value() function.
        /// </summary>
        /// <remarks>
        /// Note: The @value will be initialised with the exact type of
        /// @instance.  If you wish to set the @value's type to a different GType
        /// (such as a parent class GType), you need to manually call
        /// g_value_init() and g_value_set_instance().
        /// </remarks>
        /// <param name="value">
        /// An uninitialized #GValue structure.
        /// </param>
        /// <param name="instance">
        /// the instance
        /// </param>
        [Since("2.42")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_init_from_instance(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        ///// <summary>
        ///// Initializes and sets @value from an instantiatable type via the
        ///// value_table's collect_value() function.
        ///// </summary>
        ///// <remarks>
        ///// Note: The @value will be initialised with the exact type of
        ///// @instance.  If you wish to set the @value's type to a different GType
        ///// (such as a parent class GType), you need to manually call
        ///// g_value_init() and g_value_set_instance().
        ///// </remarks>
        ///// <param name="instance">
        ///// the instance
        ///// </param>
        //[Since ("2.42")]
        //public void InitFromInstance (IntPtr instance)
        //{
        //    g_value_init_from_instance (ref this, instance);
        //}

        /// <summary>
        /// Returns the value contents as pointer. This function asserts that
        /// g_value_fits_pointer() returned %TRUE for the passed in value.
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// An initialized #GValue structure
        /// </param>
        /// <returns>
        /// the value contents as pointer
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_peek_pointer(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value value);

        ///// <summary>
        ///// Returns the value contents as pointer. This function asserts that
        ///// g_value_fits_pointer() returned %TRUE for the passed in value.
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <returns>
        ///// the value contents as pointer
        ///// </returns>
        //public IntPtr PeekPointer ()
        //{
        //    AssertInitialized ();
        //    var ret = g_value_peek_pointer (ref this);
        //    return ret;
        //}

        /// <summary>
        /// Clears the current value in @value and resets it to the default value
        /// (as if the value had just been initialized).
        /// </summary>
        /// <param name="value">
        /// An initialized #GValue structure.
        /// </param>
        /// <returns>
        /// the #GValue structure that has been passed in
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_reset(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value);

        /// <summary>
        /// Clears the current value in @value and resets it to the default value
        /// (as if the value had just been initialized).
        /// </summary>
        public void Reset()
        {
            AssertInitialized();
            g_value_reset(ref this);
        }

        /// <summary>
        /// Set the contents of a %G_TYPE_BOOLEAN #GValue to @v_boolean.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_BOOLEAN
        /// </param>
        /// <param name="vBoolean">
        /// boolean value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_boolean(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool vBoolean);

        /// <summary>
        /// Set the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <param name="vBoxed">
        /// boxed value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_boxed(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vBoxed);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of %G_TYPE_BOXED derived type
        ///// </param>
        ///// <param name="vBoxed">
        ///// duplicated unowned boxed value to be set
        ///// </param>
        ////[Obsolete ("Use g_value_take_boxed() instead.")]
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_boxed_take_ownership (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    ref Value value,
        //    /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vBoxed);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="vBoxed">
        ///// duplicated unowned boxed value to be set
        ///// </param>
        //[Obsolete ("Use g_value_take_boxed() instead.")]
        //public void SetBoxedTakeOwnership (IntPtr vBoxed)
        //{
        //    AssertInitialized ();
        //    g_value_set_boxed_take_ownership (Handle, vBoxed);
        //}

        ///// <summary>
        ///// Set the contents of a %G_TYPE_CHAR #GValue to @v_char.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of type %G_TYPE_CHAR
        ///// </param>
        ///// <param name="vChar">
        ///// character value to be set
        ///// </param>
        ////[Obsolete ("This function's input type is broken, see g_value_set_schar()")]
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_char (
        ///* <type name="Value" type="GValue*" managed-name="Value" /> */
        ///* transfer-ownership:none */
        //ref Value value,
        ///* <type name="gchar" type="gchar" managed-name="Gchar" /> */
        ///* transfer-ownership:none */
        //sbyte vChar);

        /// <summary>
        /// Set the contents of a %G_TYPE_DOUBLE #GValue to @v_double.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_DOUBLE
        /// </param>
        /// <param name="vDouble">
        /// double value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_double(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
            /* transfer-ownership:none */
            double vDouble);

        /// <summary>
        /// Set the contents of a %G_TYPE_ENUM #GValue to @v_enum.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_ENUM
        /// </param>
        /// <param name="vEnum">
        /// enum value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_enum(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int vEnum);

        /// <summary>
        /// Set the contents of a %G_TYPE_FLAGS #GValue to @v_flags.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue whose type is derived from %G_TYPE_FLAGS
        /// </param>
        /// <param name="vFlags">
        /// flags value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_flags(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint vFlags);

        /// <summary>
        /// Set the contents of a %G_TYPE_FLOAT #GValue to @v_float.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_FLOAT
        /// </param>
        /// <param name="vFloat">
        /// float value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_float(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gfloat" type="gfloat" managed-name="Gfloat" /> */
            /* transfer-ownership:none */
            float vFloat);

        /// <summary>
        /// Set the contents of a %G_TYPE_GTYPE #GValue to @v_gtype.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_GTYPE
        /// </param>
        /// <param name="vGType">
        /// #GType to be set
        /// </param>
        [Since("2.12")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_gtype(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType vGType);

        /// <summary>
        /// Sets @value from an instantiatable type via the
        /// value_table's collect_value() function.
        /// </summary>
        /// <param name="value">
        /// An initialized #GValue structure.
        /// </param>
        /// <param name="instance">
        /// the instance
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_instance(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr instance);

        ///// <summary>
        ///// Sets @value from an instantiatable type via the
        ///// value_table's collect_value() function.
        ///// </summary>
        ///// <param name="instance">
        ///// the instance
        ///// </param>
        //public void SetInstance (IntPtr instance)
        //{
        //    AssertInitialized ();
        //    g_value_set_instance (Handle, instance);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_INT #GValue to @v_int.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_INT
        /// </param>
        /// <param name="vInt">
        /// integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_int(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int vInt);

        /// <summary>
        /// Set the contents of a %G_TYPE_INT64 #GValue to @v_int64.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_INT64
        /// </param>
        /// <param name="vInt64">
        /// 64bit integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_int64(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
            /* transfer-ownership:none */
            long vInt64);

        /// <summary>
        /// Set the contents of a %G_TYPE_LONG #GValue to @v_long.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_LONG
        /// </param>
        /// <param name="vLong">
        /// long integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_long(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong vLong);

        /// <summary>
        /// Set the contents of a %G_TYPE_OBJECT derived #GValue to @v_object.
        /// </summary>
        /// <remarks>
        /// g_value_set_object() increases the reference count of @v_object
        /// (the #GValue holds a reference to @v_object).  If you do not wish
        /// to increase the reference count of the object (i.e. you wish to
        /// pass your current reference to the #GValue because you no longer
        /// need it), use g_value_take_object() instead.
        ///
        /// It is important that your #GValue holds a reference to @v_object (either its
        /// own, or one it has taken) to ensure that the object won't be destroyed while
        /// the #GValue still exists).
        /// </remarks>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_OBJECT derived type
        /// </param>
        /// <param name="vObject">
        /// object value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_object(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vObject);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of %G_TYPE_OBJECT derived type
        ///// </param>
        ///// <param name="vObject">
        ///// object value to be set
        ///// </param>
        ////[Obsolete ("Use g_value_take_object() instead.")]
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_object_take_ownership (
        ///* <type name="Value" type="GValue*" managed-name="Value" /> */
        ///* transfer-ownership:none */
        //ref Value value,
        ///* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        ///* transfer-ownership:none nullable:1 allow-none:1 */
        //IntPtr vObject);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="vObject">
        ///// object value to be set
        ///// </param>
        //[Obsolete ("Use g_value_take_object() instead.")]
        //public void SetObjectTakeOwnership (IntPtr vObject)
        //{
        //    AssertInitialized ();
        //    g_value_set_object_take_ownership (Handle, vObject);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_PARAM #GValue to @param.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_PARAM
        /// </param>
        /// <param name="param">
        /// the #GParamSpec to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_param(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr param);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of type %G_TYPE_PARAM
        ///// </param>
        ///// <param name="param">
        ///// the #GParamSpec to be set
        ///// </param>
        ////[Obsolete ("Use g_value_take_param() instead.")]
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_param_take_ownership (
        ///* <type name="Value" type="GValue*" managed-name="Value" /> */
        ///* transfer-ownership:none */
        //ref Value value,
        ///* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        ///* transfer-ownership:none nullable:1 allow-none:1 */
        //IntPtr param);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="param">
        ///// the #GParamSpec to be set
        ///// </param>
        ////[Obsolete ("Use g_value_take_param() instead.")]
        //public void SetParamTakeOwnership(ParamSpec param)
        //{
        //    AssertInitialized ();
        //    var param_ = param == null ? IntPtr.Zero : param.Handle;
        //    g_value_set_param_take_ownership(Handle, param_);
        //}

        /// <summary>
        /// Set the contents of a pointer #GValue to @v_pointer.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_POINTER
        /// </param>
        /// <param name="vPointer">
        /// pointer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_pointer(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr vPointer);

        /// <summary>
        /// Set the contents of a %G_TYPE_CHAR #GValue to @v_char.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_CHAR
        /// </param>
        /// <param name="vChar">
        /// signed 8 bit integer to be set
        /// </param>
        [Since("2.32")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_schar(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gint8" type="gint8" managed-name="Gint8" /> */
            /* transfer-ownership:none */
            sbyte vChar);

        ///// <summary>
        ///// Set the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed.
        ///// The boxed value is assumed to be static, and is thus not duplicated
        ///// when setting the #GValue.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of %G_TYPE_BOXED derived type
        ///// </param>
        ///// <param name="vBoxed">
        ///// static boxed value to be set
        ///// </param>
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_static_boxed (
        ///* <type name="Value" type="GValue*" managed-name="Value" /> */
        ///* transfer-ownership:none */
        //ref Value value,
        ///* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
        ///* transfer-ownership:none nullable:1 allow-none:1 */
        //IntPtr vBoxed);

        /// <summary>
        /// Set the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed.
        /// The boxed value is assumed to be static, and is thus not duplicated
        /// when setting the #GValue.
        /// </summary>
        /// <param name="vBoxed">
        /// static boxed value to be set
        /// </param>
        //public void SetStaticBoxed (IntPtr vBoxed)
        //{
        //    AssertInitialized ();
        //    g_value_set_static_boxed (Handle, vBoxed);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_STRING #GValue to @v_string.
        /// The string is assumed to be static, and is thus not duplicated
        /// when setting the #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_STRING
        /// </param>
        /// <param name="vString">
        /// static string to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_static_string(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        ///// <summary>
        ///// Set the contents of a %G_TYPE_STRING #GValue to @v_string.
        ///// The string is assumed to be static, and is thus not duplicated
        ///// when setting the #GValue.
        ///// </summary>
        ///// <param name="vString">
        ///// static string to be set
        ///// </param>
        //public void SetStaticString (string vString)
        //{
        //    AssertInitialized ();
        //    var vString_ = MarshalG.StringToUtf8Ptr (vString);
        //    g_value_set_static_string (Handle, vString_);
        //    MarshalG.Free (vString_);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_STRING #GValue to @v_string.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_STRING
        /// </param>
        /// <param name="vString">
        /// caller-owned string to be duplicated for the #GValue
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_string(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="value">
        ///// a valid #GValue of type %G_TYPE_STRING
        ///// </param>
        ///// <param name="vString">
        ///// duplicated unowned string to be set
        ///// </param>
        ////[Obsolete ("Use g_value_take_string() instead.")]
        ////[DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /////* <type name="none" type="void" managed-name="None" /> */
        /////* transfer-ownership:none */
        //static extern void g_value_set_string_take_ownership(
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    ref Value value,
        //    /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vString);

        ///// <summary>
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </summary>
        ///// <param name="vString">
        ///// duplicated unowned string to be set
        ///// </param>
        //[Obsolete ("Use g_value_take_string() instead.")]
        //public void SetStringTakeOwnership(string vString)
        //{
        //    AssertInitialized ();
        //    var vString_ = MarshalG.StringToUtf8Ptr(vString);
        //    g_value_set_string_take_ownership(Handle, vString_);
        //    MarshalG.Free(vString_);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_UCHAR #GValue to @v_uchar.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UCHAR
        /// </param>
        /// <param name="vUchar">
        /// unsigned character value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uchar(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="guint8" type="guchar" managed-name="Guint8" /> */
            /* transfer-ownership:none */
            byte vUchar);

        /// <summary>
        /// Set the contents of a %G_TYPE_UINT #GValue to @v_uint.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UINT
        /// </param>
        /// <param name="vUint">
        /// unsigned integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uint(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint vUint);

        /// <summary>
        /// Set the contents of a %G_TYPE_UINT64 #GValue to @v_uint64.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_UINT64
        /// </param>
        /// <param name="vUint64">
        /// unsigned 64bit integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uint64(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
            /* transfer-ownership:none */
            ulong vUint64);

        /// <summary>
        /// Set the contents of a %G_TYPE_ULONG #GValue to @v_ulong.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_ULONG
        /// </param>
        /// <param name="vUlong">
        /// unsigned long integer value to be set
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_ulong(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
            /* transfer-ownership:none */
            culong vUlong);

        /// <summary>
        /// Set the contents of a variant #GValue to @variant.
        /// If the variant is floating, it is consumed.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_VARIANT
        /// </param>
        /// <param name="variant">
        /// a #GVariant, or %NULL
        /// </param>
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_variant(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr variant);

        /// <summary>
        /// Sets the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed
        /// and takes over the ownership of the callers reference to @v_boxed;
        /// the caller doesn't have to unref it any more.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <param name="vBoxed">
        /// duplicated unowned boxed value to be set
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_boxed(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vBoxed);

        ///// <summary>
        ///// Sets the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed
        ///// and takes over the ownership of the callers reference to @v_boxed;
        ///// the caller doesn't have to unref it any more.
        ///// </summary>
        ///// <param name="vBoxed">
        ///// duplicated unowned boxed value to be set
        ///// </param>
        //[Since ("2.4")]
        //public void TakeBoxed (IntPtr vBoxed)
        //{
        //    AssertInitialized ();
        //    g_value_take_boxed (Handle, vBoxed);
        //}

        /// <summary>
        /// Sets the contents of a %G_TYPE_OBJECT derived #GValue to @v_object
        /// and takes over the ownership of the callers reference to @v_object;
        /// the caller doesn't have to unref it any more (i.e. the reference
        /// count of the object is not increased).
        /// </summary>
        /// <remarks>
        /// If you want the #GValue to hold its own reference to @v_object, use
        /// g_value_set_object() instead.
        /// </remarks>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_OBJECT derived type
        /// </param>
        /// <param name="vObject">
        /// object value to be set
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_object(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vObject);

        ///// <summary>
        ///// Sets the contents of a %G_TYPE_OBJECT derived #GValue to @v_object
        ///// and takes over the ownership of the callers reference to @v_object;
        ///// the caller doesn't have to unref it any more (i.e. the reference
        ///// count of the object is not increased).
        ///// </summary>
        ///// <remarks>
        ///// If you want the #GValue to hold its own reference to @v_object, use
        ///// g_value_set_object() instead.
        ///// </remarks>
        ///// <param name="vObject">
        ///// object value to be set
        ///// </param>
        //[Since ("2.4")]
        //public void TakeObject (IntPtr vObject)
        //{
        //    AssertInitialized ();
        //    g_value_take_object (Handle, vObject);
        //}

        /// <summary>
        /// Sets the contents of a %G_TYPE_PARAM #GValue to @param and takes
        /// over the ownership of the callers reference to @param; the caller
        /// doesn't have to unref it any more.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_PARAM
        /// </param>
        /// <param name="param">
        /// the #GParamSpec to be set
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_param(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr param);

        ///// <summary>
        ///// Sets the contents of a %G_TYPE_PARAM #GValue to @param and takes
        ///// over the ownership of the callers reference to @param; the caller
        ///// doesn't have to unref it any more.
        ///// </summary>
        ///// <param name="param">
        ///// the #GParamSpec to be set
        ///// </param>
        //[Since("2.4")]
        //public void TakeParam(ParamSpec param)
        //{
        //    AssertInitialized ();
        //    var param_ = param == null ? IntPtr.Zero : param.Handle;
        //    g_value_take_param(Handle, param_);
        //}

        /// <summary>
        /// Sets the contents of a %G_TYPE_STRING #GValue to @v_string.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_STRING
        /// </param>
        /// <param name="vString">
        /// string to take ownership of
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_string(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        ///// <summary>
        ///// Sets the contents of a %G_TYPE_STRING #GValue to @v_string.
        ///// </summary>
        ///// <param name="vString">
        ///// string to take ownership of
        ///// </param>
        //[Since ("2.4")]
        //public void TakeString (string vString)
        //{
        //    AssertInitialized ();
        //    var vString_ = MarshalG.StringToUtf8Ptr (vString);
        //    g_value_take_string (Handle, vString_);
        //    MarshalG.Free (vString_);
        //}

        /// <summary>
        /// Set the contents of a variant #GValue to @variant, and takes over
        /// the ownership of the caller's reference to @variant;
        /// the caller doesn't have to unref it any more (i.e. the reference
        /// count of the variant is not increased).
        /// </summary>
        /// <remarks>
        /// If @variant was floating then its floating reference is converted to
        /// a hard reference.
        ///
        /// If you want the #GValue to hold its own reference to @variant, use
        /// g_value_set_variant() instead.
        ///
        /// This is an internal function introduced mainly for C marshallers.
        /// </remarks>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_VARIANT
        /// </param>
        /// <param name="variant">
        /// a #GVariant, or %NULL
        /// </param>
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_variant(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value,
            /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr variant);

        ///// <summary>
        ///// Set the contents of a variant #GValue to @variant, and takes over
        ///// the ownership of the caller's reference to @variant;
        ///// the caller doesn't have to unref it any more (i.e. the reference
        ///// count of the variant is not increased).
        ///// </summary>
        ///// <remarks>
        ///// If @variant was floating then its floating reference is converted to
        ///// a hard reference.
        /////
        ///// If you want the #GValue to hold its own reference to @variant, use
        ///// g_value_set_variant() instead.
        /////
        ///// This is an internal function introduced mainly for C marshallers.
        ///// </remarks>
        ///// <param name="variant">
        ///// a #GVariant, or %NULL
        ///// </param>
        //[Since("2.26")]
        //public void TakeVariant(GISharp.Lib.GLib.Variant variant)
        //{
        //    AssertInitialized ();
        //    var variant_ = variant == null ? IntPtr.Zero : variant.Handle;
        //    g_value_take_variant(Handle, variant_);
        //}

        /// <summary>
        /// Tries to cast the contents of @src_value into a type appropriate
        /// to store in @dest_value, e.g. to transform a %G_TYPE_INT value
        /// into a %G_TYPE_FLOAT value. Performing transformations between
        /// value types might incur precision lossage. Especially
        /// transformations into strings might reveal seemingly arbitrary
        /// results and shouldn't be relied upon for production code (such
        /// as rcfile value or object property serialization).
        /// </summary>
        /// <param name="srcValue">
        /// Source value.
        /// </param>
        /// <param name="destValue">
        /// Target value.
        /// </param>
        /// <returns>
        /// Whether a transformation rule was found and could be applied.
        ///  Upon failing transformations, @dest_value is left untouched.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_value_transform(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            in Value srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value destValue);

        /// <summary>
        /// Tries to cast the contents of this Value into a type appropriate
        /// to store in <paramref name="destValue"/>, e.g. to transform a
        /// <see cref="GType.Int"/> value into a <see cref="GType.Float"/> value.
        /// </summary>
        /// <param name="destValue">
        /// Target value.
        /// </param>
        /// <returns>
        /// Whether a transformation rule was found and could be applied.
        ///  Upon failing transformations, <paramref name="destValue"/> is left untouched.
        /// </returns>
        /// <remarks>
        /// Performing transformations between
        /// value types might incur precision lossage. Especially
        /// transformations into strings might reveal seemingly arbitrary
        /// results and shouldn't be relied upon for production code (such
        /// as rcfile value or object property serialization).
        /// </remarks>
        public bool TryTransform(ref Value destValue)
        {
            AssertInitialized();
            var ret = g_value_transform(in this, ref destValue);

            return ret;
        }

        /// <summary>
        /// Tries to cast the contents of this Value into a type appropriate
        /// to store in <paramref name="destValue"/>, e.g. to transform a
        /// <see cref="GType.Int"/> value into a <see cref="GType.Float"/> value.
        /// </summary>
        /// <param name="destValue">
        /// Target value.
        /// </param>
        /// <exception cref="InvalidCastException">
        /// If a transformation rule was not found and or could not be applied.
        ///  Upon failing transformations, <paramref name="destValue"/> is left untouched.
        /// </exception>
        /// <remarks>
        /// Performing transformations between
        /// value types might incur precision lossage. Especially
        /// transformations into strings might reveal seemingly arbitrary
        /// results and shouldn't be relied upon for production code (such
        /// as rcfile value or object property serialization).
        /// </remarks>
        public void Transform(ref Value destValue)
        {
            if (!TryTransform(ref destValue)) {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Clears the current value in @value and "unsets" the type,
        /// this releases all resources associated with this GValue.
        /// An unset value is the same as an uninitialized (zero-filled)
        /// #GValue structure.
        /// </summary>
        /// <param name="value">
        /// An initialized #GValue structure.
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_unset(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value);

        /// <summary>
        /// Clears the current value in @value and "unsets" the type,
        /// this releases all resources associated with this GValue.
        /// An unset value is the same as an uninitialized (zero-filled)
        /// #GValue structure.
        /// </summary>
        public void Unset()
        {
            AssertInitialized();
            g_value_unset(ref this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Value"/> class.
        /// </summary>
        public Value(GType type)
        {
            this.type = GType.Invalid;
            data0 = default;
            data1 = default;

            Init(type);
            if (ValueGType == GType.Invalid) {
                var message = $"{type.Name} cannot be used as Value.";
                throw new ArgumentException(message, nameof(type));
            }
        }

        public Value(GType type, object? value) : this(type)
        {
            Set(value);
        }

        public Value(Type type, object? value) : this(type.GetGType())
        {
            Set(value);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_value_get_type();

        static readonly GType _GType = g_value_get_type();

        void AssertType(GType type)
        {
            AssertInitialized();
            if (!this.type.IsA(type)) {
                var message = $"Expecting {type.Name} but have {this.type.Name}";
                throw new InvalidOperationException(message);
            }
        }

        void AssertInitialized()
        {
            if (type == GType.Invalid) {
                throw new InvalidOperationException("Value type has not been initialized.");
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_strdup_value_contents(in Value value);

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
            var ret_ = g_strdup_value_contents(in this);
            using var ret = new Utf8(ret_, Transfer.Full);
            return $"{ValueGType.Name}: {ret}";
        }
    }

    /// <summary>
    /// The type of value transformation functions which can be registered with
    /// g_value_register_transform_func().
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ValueTransform(
    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
    /* transfer-ownership:none */
        in Value srcValue,
    /* <type name="Value" type="GValue*" managed-name="Value" /> */
    /* transfer-ownership:none */
        ref Value destValue);
}
