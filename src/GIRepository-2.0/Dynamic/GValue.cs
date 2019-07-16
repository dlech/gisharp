using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository.Dynamic
{
    ref struct GValue
    {
        UIntPtr type;

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
            CLong vLong;

            [FieldOffset(0)]
            CULong vULong;

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

        const int fundamentalShift = 2;

        // Fundamental GTypes
        const uint invalid = 0;
        const uint none = 1 << fundamentalShift;
        const uint @interface = 2 << fundamentalShift;
        const uint @char = 3 << fundamentalShift;
        const uint uchar = 4 << fundamentalShift;
        const uint boolean = 5 << fundamentalShift;
        const uint @int = 6 << fundamentalShift;
        const uint @uint = 7 << fundamentalShift;
        const uint @long = 8 << fundamentalShift;
        const uint @ulong = 9 << fundamentalShift;
        const uint int64 = 10 << fundamentalShift;
        const uint uint64 = 11 << fundamentalShift;
        const uint @enum = 12 << fundamentalShift;
        const uint flags = 13 << fundamentalShift;
        const uint @float = 14 << fundamentalShift;
        const uint @double = 15 << fundamentalShift;
        const uint @string = 16 << fundamentalShift;
        const uint pointer = 17 << fundamentalShift;
        const uint boxed = 18 << fundamentalShift;
        const uint param = 19 << fundamentalShift;
        const uint @object = 20 << fundamentalShift;
        const uint variant = 21 << fundamentalShift;


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_value_init(ref GValue value, UIntPtr gType);

        public GValue(UIntPtr valueType)
        {
            this = default;
            g_value_init(ref this, valueType);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_value_set_boolean(in GValue value, bool vBoolean);

        public void Set(object? value)
        {
            switch (g_type_fundamental(type).ToUInt32()) {
            case boolean:
                g_value_set_boolean(in this, (bool)value!);
                break;
            default:
                throw new NotSupportedException($"Unsupported type: {GTypeName(type)}");
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_value_get_boolean(in GValue value);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_value_get_object(in GValue value);

        internal object? Get()
        {
            switch (g_type_fundamental(type).ToUInt32()) {
            case boolean:
                return g_value_get_boolean(in this);
            case @object:
                var object_ = g_value_get_object(in this);
                if (object_ == IntPtr.Zero) {
                    return null;
                }
                return new DynamicGObject(object_);
            case variant:
                return null; // FIXME
            default:
                throw new NotSupportedException($"Unsupported type: {GTypeName(type)}");
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_type_fundamental(UIntPtr type);


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_name(UIntPtr type);

        static string? GTypeName(UIntPtr type)
        {
            return new NullableUnownedUtf8(g_type_name(type), -1);
        }
    }
}
