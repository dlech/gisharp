// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Stores an argument of varying type.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Argument
    {
        [FieldOffset(0)]
        public bool Boolean;
        [FieldOffset(0)]
        public sbyte Int8;
        [FieldOffset(0)]
        public byte UInt8;
        [FieldOffset(0)]
        public short Int16;
        [FieldOffset(0)]
        public ushort UInt16;
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(0)]
        public uint UInt32;
        [FieldOffset(0)]
        public long Int64;
        [FieldOffset(0)]
        public ulong UInt64;
        [FieldOffset(0)]
        public float Float;
        [FieldOffset(0)]
        public double Double;
        [FieldOffset(0)]
        public short Short;
        [FieldOffset(0)]
        public int Int;
        [FieldOffset(0)]
        public uint UInt;
        [FieldOffset(0)]
        public CLong Long;
        [FieldOffset(0)]
        public CULong ULong;
        [FieldOffset(0)]
        public IntPtr SSize;
        [FieldOffset(0)]
        public UIntPtr Size;

        [FieldOffset(0)]
        private IntPtr @string;

        public NullableUnownedUtf8 String {
            get => new NullableUnownedUtf8(@string, -1);
            set => @string = value.UnsafeHandle;
        }

        public NullableUnownedUtf8 GetString(int size)
        {
            return new NullableUnownedUtf8(@string, size);
        }

        [FieldOffset(0)]
        private IntPtr pointer;

        public IntPtr Pointer {
            get => pointer;
            set => pointer = value;
        }
    }
}
