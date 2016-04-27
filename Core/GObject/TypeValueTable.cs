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
        public ValueInit ValueInitImpl;
        public ValueFree ValueFreeImpl;
        public ValueCopy ValueCopyImpl;
        public ValuePeekPointer ValuePeekPointerImpl;
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
        public delegate void ValueInit (
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value value);


        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void ValueFree (
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value value);

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void ValueCopy (
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value srcValue,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value destValue);

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr ValuePeekPointer (
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value value);

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeCollectValue (
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value value,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
            uint nCollectValues,
        /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
        /* transfer-ownership:none */
            IntPtr collectValues,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
            uint collectFlags);

        public delegate string CollectValue (ref Value value, TypeCValue[] collectValues, uint collectFlags);

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
            public static NativeCollectValue Create (CollectValue method, bool freeUserData)
            {
                NativeCollectValue nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    ref
                                                        Value value,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                                                        uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                                                        IntPtr collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                                                        uint collectFlags_) => {
                    var collectValues = MarshalG.PtrToCArray<TypeCValue> (collectValues_, (int)nCollectValues_);
                    var ret = method.Invoke (ref value, collectValues, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr (ret);
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
        public delegate IntPtr NativeLcopyValue (
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
            ref Value value,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
            uint nCollectValues,
        /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
        /* transfer-ownership:none */
            IntPtr collectValues,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
            uint collectFlags);

        public delegate string LcopyValue (ref Value value, TypeCValue[] collectValues, uint collectFlags);

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
            public static NativeLcopyValue Create (LcopyValue method, bool freeUserData)
            {
                NativeLcopyValue nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    ref
                                                      Value value,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                                                      uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                                                      IntPtr collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                                                      uint collectFlags_) => {
                    var collectValue = MarshalG.PtrToCArray<TypeCValue> (collectValues_, (int)nCollectValues_);
                    var ret = method.Invoke (ref value, collectValue, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr (ret);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" /> */
        /* */
        static extern TypeValueTable g_type_value_table_peek (
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
        public static TypeValueTable Peek (GType type)
        {
            var ret = g_type_value_table_peek (type);
            return ret;
        }
    }
}
