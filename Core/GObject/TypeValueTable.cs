using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// The #GTypeValueTable provides the functions required by the #GValue
    /// implementation, to serve as a container for values of a type.
    /// </summary>
    public struct TypeValueTable
    {
        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueInit(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate void ValueInit(Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValueInit"/> methods.
        /// </summary>
        public static class NativeValueInitFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueInit"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueInit Create(ValueInit method, bool freeUserData)
            {
                NativeValueInit nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    method.Invoke(value);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueInit ValueInitImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueFree(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate void ValueFree(Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValueFree"/> methods.
        /// </summary>
        public static class NativeValueFreeFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueFree"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueFree Create(ValueFree method, bool freeUserData)
            {
                NativeValueFree nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    method.Invoke(value);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueFree ValueFreeImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueCopy(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr destValue);

        public delegate void ValueCopy(Value srcValue, Value destValue);

        /// <summary>
        /// Factory for creating <see cref="NativeValueCopy"/> methods.
        /// </summary>
        public static class NativeValueCopyFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueCopy"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueCopy Create(ValueCopy method, bool freeUserData)
            {
                NativeValueCopy nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr srcValue_,
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr destValue_) =>
                {
                    var srcValue = Opaque.GetInstance<Value>(srcValue_, Transfer.None);
                    var destValue = Opaque.GetInstance<Value>(destValue_, Transfer.None);
                    method.Invoke(srcValue, destValue);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueCopy ValueCopyImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeValuePeekPointer (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate IntPtr ValuePeekPointer (Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValuePeekPointer"/> methods.
        /// </summary>
        public static class NativeValuePeekPointerFactory
        {
            /// <summary>
            /// Wraps <see cref="ValuePeekPointer"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeValuePeekPointer Create(ValuePeekPointer method, bool freeUserData)
            {
                NativeValuePeekPointer nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var ret_ = method.Invoke(value);
                    return ret_;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValuePeekPointer ValuePeekPointerImpl;

        /// <summary>
        /// A string format describing how to collect the contents of
        ///  this value bit-by-bit. Each character in the format represents
        ///  an argument to be collected, and the characters themselves indicate
        ///  the type of the argument. Currently supported arguments are:
        ///  - 'i' - Integers. passed as collect_values[].v_int.
        ///  - 'l' - Longs. passed as collect_values[].v_long.
        ///  - 'd' - Doubles. passed as collect_values[].v_double.
        ///  - 'p' - Pointers. passed as collect_values[].v_pointer.
        ///  It should be noted that for variable argument list construction,
        ///  ANSI C promotes every type smaller than an integer to an int, and
        ///  floats to doubles. So for collection of short int or char, 'i'
        ///  needs to be used, and for collection of floats 'd'.
        /// </summary>
        public IntPtr CollectFormat;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeCollectValue(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nCollectValues,
            /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
            /* transfer-ownership:none */
            IntPtr collectValues,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint collectFlags);

        public delegate string CollectValue (Value value, TypeCValue[] collectValues, uint collectFlags);

        /// <summary>
        /// Factory for creating <see cref="NativeCollectValue"/> methods.
        /// </summary>
        public static class NativeCollectValueFactory
        {
            /// <summary>
            /// Wraps <see cref="CollectValue"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeCollectValue Create(CollectValue method, bool freeUserData)
            {
                NativeCollectValue nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                    IntPtr collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint collectFlags_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var collectValues = MarshalG.PtrToCArray<TypeCValue> (collectValues_, (int)nCollectValues_);
                    var ret = method.Invoke(value, collectValues, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr(ret);
                    return ret_;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeCollectValue CollectValueImpl;

        /// <summary>
        /// Format description of the arguments to collect for @lcopy_value,
        ///  analogous to @collect_format. Usually, @lcopy_format string consists
        ///  only of 'p's to provide lcopy_value() with pointers to storage locations.
        /// </summary>
        public IntPtr LcopyFormat;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeLcopyValue(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nCollectValues,
            /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
            /* transfer-ownership:none */
            TypeCValue collectValues,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint collectFlags);

        public delegate string LcopyValue(Value value, uint nCollectValues, TypeCValue collectValues, uint collectFlags);

        /// <summary>
        /// Factory for creating <see cref="NativeLcopyValue"/> methods.
        /// </summary>
        public static class NativeLcopyValueFactory
        {
            /// <summary>
            /// Wraps <see cref="LcopyValue"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/>
            /// parameter has no effect.
            /// </remarks>
            public static NativeLcopyValue Create(LcopyValue method, bool freeUserData)
            {
                NativeLcopyValue nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                    TypeCValue collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint collectFlags_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var ret = method.Invoke(value, nCollectValues_, collectValues_, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr(ret);
                    return ret_;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeLcopyValue LcopyValueImpl;

        /// <summary>
        /// Returns the location of the #GTypeValueTable associated with @type.
        /// </summary>
        /// <remarks>
        /// Note that this function should only be used from source code
        /// that implements or has internal knowledge of the implementation of
        /// @type.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// location of the #GTypeValueTable associated with @type or
        ///     %NULL if there is no #GTypeValueTable associated with @type
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention =  CallingConvention.Cdecl)]
        /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" /> */
        /* */
        static extern TypeValueTable g_type_value_table_peek(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the location of the #GTypeValueTable associated with @type.
        /// </summary>
        /// <remarks>
        /// Note that this function should only be used from source code
        /// that implements or has internal knowledge of the implementation of
        /// @type.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// location of the #GTypeValueTable associated with @type or
        ///     %NULL if there is no #GTypeValueTable associated with @type
        /// </returns>
        public static TypeValueTable Peek(GType type)
        {
            var ret = g_type_value_table_peek(type);
            return ret;
        }
    }
}
