using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;
using System.Collections.Generic;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used to hold different types of values.
    /// </summary>
    [GType ("GValue", IsWrappedNativeType = true)]
    [DebuggerDisplay ("{ToString ()}")]
    public sealed class Value : OwnedOpaque
    {
        internal struct Value_
        {
            public GType Type;
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 2)]
            public ValueDataUnion[] Data;
        }

        [StructLayout (LayoutKind.Explicit)]
        internal struct ValueDataUnion
        {
            [FieldOffset (0)]
            public int VInt;

            [FieldOffset (0)]
            public uint VUInt;

            [FieldOffset (0)]
            public nlong VLong;

            [FieldOffset (0)]
            public nulong VULong;

            [FieldOffset (0)]
            public long VInt64;

            [FieldOffset (0)]
            public ulong VUInt64;

            [FieldOffset (0)]
            public float VFloat;

            [FieldOffset (0)]
            public double VDouble;

            [FieldOffset (0)]
            public IntPtr VPointer;
        }

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
            = new Dictionary<Tuple<GType, GType>, GCHandle> ();
        static readonly object transformFuncMapLock = new object ();

        public object Get ()
        {
            AssertNotDisposed ();

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
                var enumType = GType.TypeOf (ValueGType);
                return System.Enum.ToObject (enumType, Enum);
            }
            if (gtype == GType.Flags) {
                var enumType = GType.TypeOf (ValueGType);
                return System.Enum.ToObject (enumType, Flags);
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
                return String;
            }
//                if (gtype == GType.Variant) {
//                    return Variant;
//                }
            // TODO: Need more specific exception
            throw new Exception ("unhandled GType");
        }

        public void Set (object obj)
        {
            AssertNotDisposed ();

            var gtype = ValueGType.Fundamental;
            try {
                if (gtype == GType.Boolean) {
                    Boolean = (bool)obj;
                } else if (gtype == GType.Boxed) {
                    Boxed = obj;
                } else if (gtype == GType.Char) {
                    Char = (sbyte)obj;
                } else if (gtype == GType.UChar) {
                    UChar = (byte)obj;
                } else if (gtype == GType.Double) {
                    Double = (double)obj;
                } else if (gtype == GType.Float) {
                    Float = (float)obj;
                } else if (gtype == GType.Enum) {
                    Enum = (int)obj;
                } else if (gtype == GType.Flags) {
                    Flags = (uint)(int)obj;
                } else if (gtype == GType.Int) {
                    Int = (int)obj;
                } else if (gtype == GType.UInt) {
                    UInt = (uint)obj;
                } else if (gtype == GType.Int64) {
                    Int64 = (long)obj;
                } else if (gtype == GType.UInt64) {
                    UInt64 = (ulong)obj;
                } else if (gtype == GType.Long) {
                    Long = (nlong)obj;
                } else if (gtype == GType.ULong) {
                    ULong = (nulong)obj;
                } else if (gtype == GType.Object) {
                    Object = (Object)obj;
                } else if (gtype == GType.Param) {
                    Param = (ParamSpec)obj;
                } else if (ValueGType == GType.Type) {
                    // GType has fundamental type of void, so this check must
                    // be before Pointer and not check the fundamental GType
                    GType = (GType)obj;
                } else if (gtype == GType.Pointer) {
                    Pointer = (IntPtr)obj;
                } else if (gtype == GType.String) {
                    String = (string)obj;
//            } else if (gtype == GType.Variant) {
//                Variant = (Variant)obj;
                } else {
                    // TODO: Need more specific exception
                    throw new Exception ("unhandled GType");
                }
            } catch (InvalidCastException ex) {
                throw new ArgumentException ("Wrong type", nameof (obj), ex);
            }
        }

        /// <summary>
        /// Gets the GType of the stored value.
        /// </summary>
        /// <value>The value's GType.</value>
        public GType ValueGType {
            get {
                AssertNotDisposed ();
                return Marshal.PtrToStructure<GType> (Handle);
            }
        }

        public static explicit operator bool (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Boolean;
            } catch (Exception ex) {
                throw new InvalidCastException ("", ex);
            }
        }

        public static explicit operator Value (bool value)
        {
            return new Value (GType.Boolean, value);
        }

        public static explicit operator sbyte (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Char;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to sbyte", ex);
            }
        }

        public static explicit operator Value (sbyte value)
        {
            return new Value (GType.Char, value);
        }

        public static explicit operator byte (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.UChar;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to byte", ex);
            }
        }

        public static explicit operator Value (byte value)
        {
            return new Value (GType.UChar, value);
        }

        public static explicit operator int (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Int;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to int", ex);
            }
        }

        public static explicit operator Value (int value)
        {
            return new Value (GType.Int, value);
        }

        public static explicit operator uint (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.UInt;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to uint", ex);
            }
        }

        public static explicit operator Value (uint value)
        {
            return new Value (GType.UInt, value);
        }

        public static explicit operator long (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Int64;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to long", ex);
            }
        }

        public static explicit operator Value (long value)
        {
            return new Value (GType.Int64, value);
        }

        public static explicit operator ulong (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.UInt64;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to ulong", ex);
            }
        }

        public static explicit operator Value (ulong value)
        {
            return new Value (GType.UInt64, value);
        }

        public static explicit operator nlong (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Long;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to nlong", ex);
            }
        }

        public static explicit operator Value (nlong value)
        {
            return new Value (GType.Long, value);
        }

        public static explicit operator nulong (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.ULong;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to nulong", ex);
            }
        }

        public static explicit operator Value (nulong value)
        {
            return new Value (GType.ULong, value);
        }

        public static explicit operator float (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Float;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to float", ex);
            }
        }

        public static explicit operator Value (float value)
        {
            return new Value (GType.Float, value);
        }

        public static explicit operator double (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Double;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to double", ex);
            }
        }

        public static explicit operator Value (double value)
        {
            return new Value (GType.Double, value);
        }

        public static explicit operator IntPtr (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Pointer;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to IntPtr", ex);
            }
        }

        public static explicit operator Value (IntPtr value)
        {
            return new Value (GType.Pointer, value);
        }

        public static explicit operator Object (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.Object;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to GObject", ex);
            }
        }

        public static explicit operator Value (Object value)
        {
            return new Value (GType.Object, value);
        }

        public static explicit operator string (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.String;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to string", ex);
            }
        }

        public static explicit operator Value (string value)
        {
            return new Value (GType.String, value);
        }

        public static explicit operator GType (Value value)
        {
            value.AssertNotDisposed ();
            try {
                return value.GType;
            } catch (Exception ex) {
                throw new InvalidCastException ("Cannot cast to GType", ex);
            }
        }

        public static explicit operator Value (GType value)
        {
            return new Value (GType.Type, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_register_transform_func (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType srcType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType destType,
            /* <type name="ValueTransform" type="GValueTransform" managed-name="ValueTransform" /> */
            /* transfer-ownership:none */
            NativeValueTransform transformFunc);

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
        public static void RegisterTransformFunc (GType srcType, GType destType, ValueTransform transformFunc)
        {
            if (transformFunc == null) {
                throw new ArgumentNullException (nameof (transformFunc));
            }
            lock (transformFuncMapLock) {
                var key = new Tuple<GType, GType> (srcType, destType);
                if (transformFuncMap.ContainsKey (key)) {
                    transformFuncMap[key].Free ();
                }
                var transformFunc_ = NativeValueTransformFactory.Create (transformFunc);
                g_value_register_transform_func (srcType, destType, transformFunc_);
                transformFuncMap[key] = GCHandle.Alloc (transformFunc);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_value_type_compatible (
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
        public static bool TypeCompatible (GType srcType, GType destType)
        {
            var ret = g_value_type_compatible (srcType, destType);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_value_type_transformable (
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
        public static bool TypeTransformable (GType srcType, GType destType)
        {
            var ret = g_value_type_transformable (srcType, destType);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_copy (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr destValue);

        /// <summary>
        /// Copies the value of @src_value into @dest_value.
        /// </summary>
        /// <param name="destValue">
        /// An initialized #GValue structure of the same type as @src_value.
        /// </param>
        public void Copy (Value destValue)
        {
            AssertNotDisposed ();
            if (destValue == null) {
                throw new ArgumentNullException (nameof (destValue));
            }
            var destValue_ = destValue == null ? IntPtr.Zero : destValue.Handle;
            g_value_copy (Handle, destValue_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_value_dup_boxed (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.  Upon getting,
        /// the boxed value is duplicated and needs to be later freed with
        /// g_boxed_free(), e.g. like: g_boxed_free (G_VALUE_TYPE (@value),
        /// return_value);
        /// </summary>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        public IntPtr DupBoxed ()
        {
            AssertNotDisposed ();
            var ret = g_value_dup_boxed (Handle);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_dup_object (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

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
            AssertNotDisposed();
            var ret_ = g_value_dup_object(Handle);
            var ret = Opaque.GetInstance<Object>(ret_, Transfer.All);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* */
        static extern IntPtr g_value_dup_param (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

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
            AssertNotDisposed();
            var ret_ = g_value_dup_param(Handle);
            var ret = Opaque.GetInstance<ParamSpec>(ret_, Transfer.All);
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
        [SinceAttribute ("2.26")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_dup_variant (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a variant #GValue, increasing its refcount.
        /// </summary>
        /// <returns>
        /// variant contents of @value, should be unrefed using
        ///   g_variant_unref() when no longer needed
        /// </returns>
        //[SinceAttribute("2.26")]
        public GISharp.GLib.Variant DupVariant()
        {
            AssertNotDisposed();
            var ret_ = g_value_dup_variant(Handle);
            var ret = Opaque.GetInstance<GISharp.GLib.Variant>(ret_, Transfer.All);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_value_fits_pointer (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Determines if @value will fit inside the size of a pointer value.
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <returns>
        /// %TRUE if @value will fit inside a pointer value.
        /// </returns>
        public bool FitsPointer ()
        {
            AssertNotDisposed ();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_value_get_boolean (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_BOOLEAN #GValue.
        /// </summary>
        /// <returns>
        /// boolean contents of @value
        /// </returns>
        bool Boolean {
            get {
                AssertType (GType.Boolean);
                var ret = g_value_get_boolean (Handle);
                return ret;
            }

            set {
                AssertType (GType.Boolean);
                g_value_set_boolean (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_boxed (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_BOXED derived #GValue.
        /// </summary>
        /// <returns>
        /// boxed contents of @value
        /// </returns>
        object Boxed {
            get {
                AssertType (GType.Boxed);
                var ret_ = g_value_get_boxed (Handle);
                var gchandle = GCHandle.FromIntPtr (ret_);
                if (gchandle.IsAllocated) {
                    return gchandle.Target;
                }

                return Opaque.GetInstance<Opaque> (ret_, Transfer.None);
            }

            set {
                AssertType (GType.Boxed);
                var gtype = value.GetGType ();
                if (!gtype.IsA (GType.Boxed)) {
                    throw new ArgumentException ("Requires a boxed type.", nameof (value));
                }
                if (value is Opaque) {
                    // if this is a wrapped native type, then we pass the native handle
                    g_value_set_boxed (Handle, ((Opaque)value).Handle);
                } else {
                    // otherwise, we create a GCHandle.
                    g_value_set_boxed (Handle, (GCHandle.ToIntPtr (GCHandle.Alloc (value))));
                }
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
        /* transfer-ownership:none */
        static extern double g_value_get_double (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_DOUBLE #GValue.
        /// </summary>
        /// <returns>
        /// double contents of @value
        /// </returns>
        double Double {
            get {
                AssertType (GType.Double);
                var ret = g_value_get_double (Handle);
                return ret;
            }

            set {
                AssertType (GType.Double);
                g_value_set_double (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_value_get_enum (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_ENUM #GValue.
        /// </summary>
        /// <returns>
        /// enum contents of @value
        /// </returns>
        int Enum {
            get {
                AssertType (GType.Enum);
                var ret = g_value_get_enum (Handle);
                return ret;
            }

            set {
                AssertType (GType.Enum);
                g_value_set_enum (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_value_get_flags (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_FLAGS #GValue.
        /// </summary>
        /// <returns>
        /// flags contents of @value
        /// </returns>
        uint Flags {
            get {
                AssertType (GType.Flags);
                var ret = g_value_get_flags (Handle);
                return ret;
            }

            set {
                AssertType (GType.Flags);

                g_value_set_flags (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gfloat" type="gfloat" managed-name="Gfloat" /> */
        /* transfer-ownership:none */
        static extern float g_value_get_float (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_FLOAT #GValue.
        /// </summary>
        /// <returns>
        /// float contents of @value
        /// </returns>
        float Float {
            get {
                AssertType (GType.Float);
                var ret = g_value_get_float (Handle);
                return ret;
            }

            set {
                AssertType (GType.Float);
                g_value_set_float (Handle, value);
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
        [SinceAttribute ("2.12")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_value_get_gtype (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_GTYPE #GValue.
        /// </summary>
        /// <returns>
        /// the #GType stored in @value
        /// </returns>
        [SinceAttribute ("2.12")]
        GType GType {
            get {
                AssertType (GType.Type);
                var ret = g_value_get_gtype (Handle);
                return ret;
            }

            set {
                AssertType (GType.Type);
                g_value_set_gtype (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_value_get_int (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_INT #GValue.
        /// </summary>
        /// <returns>
        /// integer contents of @value
        /// </returns>
        int Int {
            get {
                AssertType (GType.Int);
                var ret = g_value_get_int (Handle);
                return ret;
            }

            set {
                AssertType (GType.Int);
                g_value_set_int (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern long g_value_get_int64 (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_INT64 #GValue.
        /// </summary>
        /// <returns>
        /// 64bit integer contents of @value
        /// </returns>
        long Int64 {
            get {
                AssertType (GType.Int64);
                var ret = g_value_get_int64 (Handle);
                return ret;
            }

            set {
                AssertType (GType.Int64);
                g_value_set_int64 (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern nlong g_value_get_long (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_LONG #GValue.
        /// </summary>
        /// <returns>
        /// long integer contents of @value
        /// </returns>
        nlong Long {
            get {
                AssertType (GType.Long);
                var ret = g_value_get_long (Handle);
                return ret;
            }

            set {
                AssertType (GType.Long);
                g_value_set_long (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_object (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_OBJECT derived #GValue.
        /// </summary>
        /// <returns>
        /// object contents of @value
        /// </returns>
        Object Object {
            get {
                var ret_ = g_value_get_object (Handle);
                var ret = Opaque.GetInstance<Object> (ret_, Transfer.None);
                return ret;
            }

            set {
                var value_ = value == null ? IntPtr.Zero : value.Handle;
                g_value_set_object (Handle, value_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_param (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_PARAM #GValue.
        /// </summary>
        /// <returns>
        /// #GParamSpec content of @value
        /// </returns>
        ParamSpec Param {
            get {
                var ret_ = g_value_get_param (Handle);
                var ret = Opaque.GetInstance<ParamSpec> (ret_, Transfer.None);
                return ret;
            }

            set {
                var value_ = value == null ? IntPtr.Zero : value.Handle;
                g_value_set_param (Handle, value_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_pointer (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a pointer #GValue.
        /// </summary>
        /// <returns>
        /// pointer contents of @value
        /// </returns>
        IntPtr Pointer {
            get {
                AssertType (GType.Pointer);
                var ret = g_value_get_pointer (Handle);
                return ret;
            }

            set {
                AssertType (GType.Pointer);
                g_value_set_pointer (Handle, value);
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
        [SinceAttribute ("2.32")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint8" type="gint8" managed-name="Gint8" /> */
        /* transfer-ownership:none */
        static extern sbyte g_value_get_schar (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_CHAR #GValue.
        /// </summary>
        /// <returns>
        /// signed 8 bit integer contents of @value
        /// </returns>
        [SinceAttribute ("2.32")]
        sbyte Char {
            get {
                AssertType (GType.Char);
                var ret = g_value_get_schar (Handle);
                return ret;
            }

            set {
                AssertType (GType.Char);
                g_value_set_schar (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_get_string (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_STRING #GValue.
        /// </summary>
        /// <returns>
        /// string content of @value
        /// </returns>
        string String {
            get {
                AssertType (GType.String);
                var ret_ = g_value_get_string (Handle);
                var ret = MarshalG.Utf8PtrToString (ret_, false);
                return ret;
            }

            set {
                AssertType (GType.String);
                var value_ = MarshalG.StringToUtf8Ptr (value);
                g_value_set_string (Handle, value_);
                MarshalG.Free (value_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint8" type="guchar" managed-name="Guint8" /> */
        /* transfer-ownership:none */
        static extern byte g_value_get_uchar (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UCHAR #GValue.
        /// </summary>
        /// <returns>
        /// unsigned character contents of @value
        /// </returns>
        byte UChar {
            get {
                AssertType (GType.UChar);
                var ret = g_value_get_uchar (Handle);
                return ret;
            }

            set {
                AssertType (GType.UChar);
                g_value_set_uchar (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_value_get_uint (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT #GValue.
        /// </summary>
        /// <returns>
        /// unsigned integer contents of @value
        /// </returns>
        uint UInt {
            get {
                AssertType (GType.UInt);
                var ret = g_value_get_uint (Handle);
                return ret;
            }

            set {
                AssertType (GType.UInt);
                g_value_set_uint (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
        /* transfer-ownership:none */
        static extern ulong g_value_get_uint64 (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_UINT64 #GValue.
        /// </summary>
        /// <returns>
        /// unsigned 64bit integer contents of @value
        /// </returns>
        ulong UInt64 {
            get {
                AssertType (GType.UInt64);
                var ret = g_value_get_uint64 (Handle);
                return ret;
            }

            set {
                AssertType (GType.UInt64);
                g_value_set_uint64 (Handle, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none */
        static extern nulong g_value_get_ulong (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a %G_TYPE_ULONG #GValue.
        /// </summary>
        /// <returns>
        /// unsigned long integer contents of @value
        /// </returns>
        nulong ULong {
            get {
                AssertType (GType.ULong);
                var ret = g_value_get_ulong (Handle);
                return ret;
            }

            set {
                AssertType (GType.ULong);
                g_value_set_ulong (Handle, value);
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
        [SinceAttribute ("2.26")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_get_variant (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Get the contents of a variant #GValue.
        /// </summary>
        /// <returns>
        /// variant contents of @value
        /// </returns>
        //[SinceAttribute("2.26")]
        //GISharp.GLib.Variant Variant
        //{
        //    get
        //    {
        //        var ret_ = g_value_get_variant(Handle);
        //        var ret = Opaque.GetInstance<GISharp.GLib.Variant>(ret_, Transfer.All);
        //        return ret;
        //    }

        //    set
        //    {
        //        var value_ = value == null ? IntPtr.Zero : value.Handle;
        //        g_value_set_variant(Handle, value_);
        //    }
        //}

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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_init (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        public void Init (GType gType)
        {
            AssertNotDisposed ();
            g_value_init (Handle, gType);
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
        [SinceAttribute ("2.42")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_init_from_instance (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr instance);

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
        /// <param name="instance">
        /// the instance
        /// </param>
        [SinceAttribute ("2.42")]
        public void InitFromInstance (IntPtr instance)
        {
            AssertNotDisposed ();
            g_value_init_from_instance (Handle, instance);
        }

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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_value_peek_pointer (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Returns the value contents as pointer. This function asserts that
        /// g_value_fits_pointer() returned %TRUE for the passed in value.
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <returns>
        /// the value contents as pointer
        /// </returns>
        public IntPtr PeekPointer ()
        {
            AssertNotDisposed ();
            var ret = g_value_peek_pointer (Handle);
            return ret;
        }

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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_value_reset (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Clears the current value in @value and resets it to the default value
        /// (as if the value had just been initialized).
        /// </summary>
        /// <returns>
        /// the #GValue structure that has been passed in
        /// </returns>
        public Value Reset ()
        {
            AssertNotDisposed ();
            var ret_ = g_value_reset (Handle);
            var ret = Opaque.GetInstance<Value> (ret_, Transfer.All);
            return ret;
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_boolean (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_boxed (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vBoxed);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <param name="vBoxed">
        /// duplicated unowned boxed value to be set
        /// </param>
        //[Obsolete ("Use g_value_take_boxed() instead.")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_boxed_take_ownership (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vBoxed);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="vBoxed">
        /// duplicated unowned boxed value to be set
        /// </param>
        //[Obsolete ("Use g_value_take_boxed() instead.")]
        //public void SetBoxedTakeOwnership (IntPtr vBoxed)
        //{
        //    AssertNotDisposed ();
        //    g_value_set_boxed_take_ownership (Handle, vBoxed);
        //}

        /// <summary>
        /// Set the contents of a %G_TYPE_CHAR #GValue to @v_char.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_CHAR
        /// </param>
        /// <param name="vChar">
        /// character value to be set
        /// </param>
        //[Obsolete ("This function's input type is broken, see g_value_set_schar()")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_char (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="gchar" type="gchar" managed-name="Gchar" /> */
        //    /* transfer-ownership:none */
        //    sbyte vChar);

        /// <summary>
        /// Set the contents of a %G_TYPE_DOUBLE #GValue to @v_double.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_DOUBLE
        /// </param>
        /// <param name="vDouble">
        /// double value to be set
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_double (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_enum (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_flags (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_float (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [SinceAttribute ("2.12")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_gtype (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_instance (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr instance);

        /// <summary>
        /// Sets @value from an instantiatable type via the
        /// value_table's collect_value() function.
        /// </summary>
        /// <param name="instance">
        /// the instance
        /// </param>
        //        public void SetInstance (IntPtr instance)
        //        {
        //            AssertNotDisposed ();
        //            g_value_set_instance (Handle, instance);
        //        }

        /// <summary>
        /// Set the contents of a %G_TYPE_INT #GValue to @v_int.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_INT
        /// </param>
        /// <param name="vInt">
        /// integer value to be set
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_int (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_int64 (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_long (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong vLong);

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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_object (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vObject);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_OBJECT derived type
        /// </param>
        /// <param name="vObject">
        /// object value to be set
        /// </param>
        //[Obsolete ("Use g_value_take_object() instead.")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_object_take_ownership (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vObject);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="vObject">
        /// object value to be set
        /// </param>
        //[Obsolete ("Use g_value_take_object() instead.")]
        //public void SetObjectTakeOwnership (IntPtr vObject)
        //{
        //    AssertNotDisposed ();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_param (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr param);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_PARAM
        /// </param>
        /// <param name="param">
        /// the #GParamSpec to be set
        /// </param>
        //[Obsolete ("Use g_value_take_param() instead.")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_param_take_ownership (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr param);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="param">
        /// the #GParamSpec to be set
        /// </param>
        //[Obsolete ("Use g_value_take_param() instead.")]
        //public void SetParamTakeOwnership(ParamSpec param)
        //{
        //    AssertNotDisposed();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_pointer (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [SinceAttribute ("2.32")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_schar (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gint8" type="gint8" managed-name="Gint8" /> */
            /* transfer-ownership:none */
            sbyte vChar);

        /// <summary>
        /// Set the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed.
        /// The boxed value is assumed to be static, and is thus not duplicated
        /// when setting the #GValue.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of %G_TYPE_BOXED derived type
        /// </param>
        /// <param name="vBoxed">
        /// static boxed value to be set
        /// </param>
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_static_boxed (
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vBoxed);

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
        //    AssertNotDisposed ();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_static_string (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        /// <summary>
        /// Set the contents of a %G_TYPE_STRING #GValue to @v_string.
        /// The string is assumed to be static, and is thus not duplicated
        /// when setting the #GValue.
        /// </summary>
        /// <param name="vString">
        /// static string to be set
        /// </param>
        //public void SetStaticString (string vString)
        //{
        //    AssertNotDisposed ();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_string (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="value">
        /// a valid #GValue of type %G_TYPE_STRING
        /// </param>
        /// <param name="vString">
        /// duplicated unowned string to be set
        /// </param>
        //[Obsolete ("Use g_value_take_string() instead.")]
        //[DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        ///* <type name="none" type="void" managed-name="None" /> */
        ///* transfer-ownership:none */
        //static extern void g_value_set_string_take_ownership(
        //    /* <type name="Value" type="GValue*" managed-name="Value" /> */
        //    /* transfer-ownership:none */
        //    IntPtr value,
        //    /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        //    /* transfer-ownership:none nullable:1 allow-none:1 */
        //    IntPtr vString);

        /// <summary>
        /// This is an internal function introduced mainly for C marshallers.
        /// </summary>
        /// <param name="vString">
        /// duplicated unowned string to be set
        /// </param>
        //[Obsolete ("Use g_value_take_string() instead.")]
        //public void SetStringTakeOwnership(string vString)
        //{
        //    AssertNotDisposed();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uchar (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uint (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_uint64 (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_ulong (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
            /* transfer-ownership:none */
            nulong vUlong);

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
        [SinceAttribute ("2.26")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_set_variant (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
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
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_boxed (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vBoxed);

        /// <summary>
        /// Sets the contents of a %G_TYPE_BOXED derived #GValue to @v_boxed
        /// and takes over the ownership of the callers reference to @v_boxed;
        /// the caller doesn't have to unref it any more.
        /// </summary>
        /// <param name="vBoxed">
        /// duplicated unowned boxed value to be set
        /// </param>
        //        [SinceAttribute ("2.4")]
        //        public void TakeBoxed (IntPtr vBoxed)
        //        {
        //            AssertNotDisposed ();
        //            g_value_take_boxed (Handle, vBoxed);
        //        }

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
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_object (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vObject);

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
        /// <param name="vObject">
        /// object value to be set
        /// </param>
        //        [SinceAttribute ("2.4")]
        //        public void TakeObject (IntPtr vObject)
        //        {
        //            AssertNotDisposed ();
        //            g_value_take_object (Handle, vObject);
        //        }

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
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_param (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr param);

        /// <summary>
        /// Sets the contents of a %G_TYPE_PARAM #GValue to @param and takes
        /// over the ownership of the callers reference to @param; the caller
        /// doesn't have to unref it any more.
        /// </summary>
        /// <param name="param">
        /// the #GParamSpec to be set
        /// </param>
        //[SinceAttribute("2.4")]
        //public void TakeParam(ParamSpec param)
        //{
        //    AssertNotDisposed();
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
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_string (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr vString);

        /// <summary>
        /// Sets the contents of a %G_TYPE_STRING #GValue to @v_string.
        /// </summary>
        /// <param name="vString">
        /// string to take ownership of
        /// </param>
        //        [SinceAttribute ("2.4")]
        //        public void TakeString (string vString)
        //        {
        //            AssertNotDisposed ();
        //            var vString_ = MarshalG.StringToUtf8Ptr (vString);
        //            g_value_take_string (Handle, vString_);
        //            MarshalG.Free (vString_);
        //        }

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
        [SinceAttribute ("2.26")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_take_variant (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr variant);

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
        /// <param name="variant">
        /// a #GVariant, or %NULL
        /// </param>
        //[SinceAttribute("2.26")]
        //public void TakeVariant(GISharp.GLib.Variant variant)
        //{
        //    AssertNotDisposed();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_value_transform (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr destValue);

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
        public bool TryTransform (Value destValue)
        {
            AssertNotDisposed ();
            if (destValue == null) {
                throw new ArgumentNullException (nameof (destValue));
            }
            var ret = g_value_transform (Handle, destValue.Handle);

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
        /// <exception cref="InvalidOperationException">
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
        public void Transform (Value destValue)
        {
            if (!TryTransform (destValue)) {
                throw new InvalidOperationException ();
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_value_unset (
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Clears the current value in @value and "unsets" the type,
        /// this releases all resources associated with this GValue.
        /// An unset value is the same as an uninitialized (zero-filled)
        /// #GValue structure.
        /// </summary>
        void Unset ()
        {
            AssertNotDisposed ();
            g_value_unset (Handle);
        }

        static IntPtr Alloc ()
        {
            //struct _GValue
            //{
            //    /*< private >*/
            //    GType       g_type;
            //    /* public for GTypeValueTable methods */
            //    union {
            //        gint      v_int;
            //        guint     v_uint;
            //        glong     v_long;
            //        gulong    v_ulong;
            //        gint64    v_int64;
            //        guint64   v_uint64;
            //        gfloat    v_float;
            //        gdouble   v_double;
            //        gpointer  v_pointer;
            //    } data[2];
            //};
            var size = Marshal.SizeOf<Value_> ();
            var ret = MarshalG.Alloc (size);
            for (int i = 0; i < size; i++) {
                Marshal.WriteByte (ret, i, 0);
            }
            return ret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GISharp.Core.Value"/> class.
        /// </summary>
        public Value (GType type) : this (Alloc (), Transfer.All)
        {
            if (type == GType.Invalid) {
                Dispose ();
                var message = "Cannot initialize using GType.Invalid.";
                throw new ArgumentException (message, nameof (type));
            }
            if (type.IsAbstract) {
                Dispose ();
                var message = "Cannot initialize using abstract GType.";
                throw new ArgumentException (message, nameof (type));
            }
            Init (type);
            if (ValueGType == GType.Invalid) {
                Dispose ();
                var message = $"{type.Name} cannot be used as Value.";
                throw new ArgumentException (message, nameof (type));
            }
        }

        public Value (GType type, object value) : this (type)
        {
            Set (value);
        }

        public Value (Type type, object value) : this (type.GetGType ())
        {
            Set (value);
        }

        protected override void Free ()
        {
            // check to see if Value struct has been properly initalized
            if (ValueGType != GType.Invalid) {
                Unset ();
            }
            MarshalG.Free (Handle);
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_value_get_type ();

        static GType getGType () {
            return g_value_get_type ();
        }

        Value (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        void AssertType (GType type)
        {
            if (!ValueGType.IsA (type)) {
                var message = $"Expecting {type.Name} but have {ValueGType.Name}";
                throw new InvalidOperationException (message);
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_strdup_value_contents (IntPtr value);

        /// <summary>
        /// Return a string that describes the contents of this value.
        /// </summary>
        /// <value>The contents.</value>
        /// <remarks>
        /// The main purpose of this function is to describe GValue contents for
        /// debugging output, the way in which the contents are described may
        /// change between different GLib versions.
        /// </remarks>
        public override string ToString ()
        {
            AssertNotDisposed ();
            var ret_ = g_strdup_value_contents (Handle);
            var ret = MarshalG.Utf8PtrToString (ret_, freePtr: true);

            return $"{ValueGType.Name}: {ret}";
        }
    }

    /// <summary>
    /// The type of value transformation functions which can be registered with
    /// g_value_register_transform_func().
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeValueTransform (
    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
    /* transfer-ownership:none */
        IntPtr srcValue,
    /* <type name="Value" type="GValue*" managed-name="Value" /> */
    /* transfer-ownership:none */
        IntPtr destValue);

    /// <summary>
    /// The type of value transformation functions which can be registered with
    /// g_value_register_transform_func().
    /// </summary>
    public delegate void ValueTransform (Value srcValue, Value destValue);

    /// <summary>
    /// Factory for creating <see cref="NativeValueTransform"/> methods.
    /// </summary>
    static class NativeValueTransformFactory
    {
        /// <summary>
        /// Wraps <see cref="ValueTransform"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        public static NativeValueTransform Create (ValueTransform method)
        {
            NativeValueTransform nativeCallback = (
                /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                                                      IntPtr srcValue_,
                /* <type name="Value" type="GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                                                      IntPtr destValue_) => {
                var srcValue = Opaque.GetInstance<Value> (srcValue_, Transfer.None);
                var destValue = Opaque.GetInstance<Value> (destValue_, Transfer.None);
                method.Invoke (srcValue, destValue);
            };
            return nativeCallback;
        }
    }
}
