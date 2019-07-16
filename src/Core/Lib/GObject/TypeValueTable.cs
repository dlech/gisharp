using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The <see cref="TypeValueTable"/> provides the functions required by the <see cref="Value"/>
    /// implementation, to serve as a container for values of a type.
    /// </summary>
    public sealed class TypeValueTable : Opaque
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeValueTable(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        struct Struct
        {
            #pragma warning disable CS0649
            public UnmangedValueInit ValueInitImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void UnmangedValueInit(
                /* <type name="Value" type="GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                ref Value value);

            public UnmangedValueFree ValueFreeImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void UnmangedValueFree(
                /* <type name="Value" type="GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                ref Value value);

            public UnmangedValueCopy ValueCopyImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void UnmangedValueCopy(
                /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                ref Value srcValue,
                /* <type name="Value" type="GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                ref Value destValue);

            public UnmanagedValuePeekPointer ValuePeekPointerImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr UnmanagedValuePeekPointer(
                /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                /* transfer-ownership:none */
                ref Value value);

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

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public UnmanagedCollectValue CollectValueImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr UnmanagedCollectValue(
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

            public delegate string CollectValue(ref Value value, TypeCValue[] collectValues, uint collectFlags);

            /// <summary>
            /// Format description of the arguments to collect for @lcopy_value,
            /// analogous to @collect_format. Usually, @lcopy_format string consists
            /// only of 'p's to provide lcopy_value() with pointers to storage locations.
            /// </summary>
            public IntPtr LcopyFormat;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public UnmanagedLcopyValue LcopyValueImpl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr UnmanagedLcopyValue(
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

            public delegate string LcopyValue(ref Value value, TypeCValue[] collectValues, uint collectFlags);
            #pragma warning restore CS0649
        }

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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" /> */
        /* */
        static extern IntPtr g_type_value_table_peek(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the <see cref="TypeValueTable"/> associated with <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// Note that this function should only be used from source code
        /// that implements or has internal knowledge of the implementation of
        /// <paramref name="type"/>.
        /// </remarks>
        /// <param name="type">
        /// a <see cref="GType"/>
        /// </param>
        /// <returns>
        /// the <see cref="TypeValueTable"/> associated with <paramref name="type"/> or
        /// <c>null</c> if there is no <see cref="TypeValueTable"/> associated with <paramref name="type"/>
        /// </returns>
        public static TypeValueTable Peek(GType type)
        {
            var ret_ = g_type_value_table_peek(type);
            var ret = Opaque.GetInstance<TypeValueTable>(ret_, Transfer.None);
            return ret;
        }
    }
}
