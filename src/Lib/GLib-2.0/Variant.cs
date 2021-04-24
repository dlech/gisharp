// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Variant : IEnumerable<Variant>
    {
        IndexedCollection<Variant>? childValues;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Variant(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                g_variant_ref_sink((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            else {
                g_variant_take_ref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
        }

        [PtrArrayCopyFunc]
        static IntPtr Copy(IntPtr value) => (IntPtr)g_variant_ref((UnmanagedStruct*)value);

        [PtrArrayFreeFunc]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "g_variant_unref")]
        static extern void Free(UnmanagedStruct* value);

        /// <summary>
        /// Reads a child item out of a container <see cref="Variant"/> instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// <see cref="Variant"/>.
        /// </summary>
        public IndexedCollection<Variant> ChildValues {
            get {
                if (childValues is null) {
                    if (!Type.IsContainer) {
                        throw new InvalidOperationException("Variant must be a container type");
                    }
                    childValues = new(NChildren, GetChildValue);
                }
                return childValues;
            }
        }

        private UnownedUtf8 GetString()
        {
            if (!IsOfType(VariantType.String)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_get_string(value_, &length_);
            GMarshal.PopUnhandledException();
            return new UnownedUtf8((IntPtr)ret_, (int)length_);
        }

        private DBusObjectPath DupDBusObjectPath()
        {
            if (!IsOfType(VariantType.DBusObjectPath)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_dup_string(value_, &length_);
            GMarshal.PopUnhandledException();
            return new DBusObjectPath((IntPtr)ret_, (int)length_, Transfer.Full);
        }

        private DBusSignature DupDBusSignature()
        {
            if (!IsOfType(VariantType.DBusSignature)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_dup_string(value_, &length_);
            GMarshal.PopUnhandledException();
            return new DBusSignature((IntPtr)ret_, (int)length_, Transfer.Full);
        }

        // explicit cast operators

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="bool"/>.
        /// </summary>
        public static explicit operator bool(Variant value)
        {
            if (value.Type != VariantType.Boolean) {
                throw new InvalidCastException();
            }
            return value.Boolean;
        }

        /// <summary>
        /// Coverts <see cref="bool"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(bool value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="byte"/>.
        /// </summary>
        public static explicit operator byte(Variant v)
        {
            if (v.Type != VariantType.Byte) {
                throw new InvalidCastException();
            }
            return v.Byte;
        }

        /// <summary>
        /// Coverts <see cref="byte"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(byte value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="byte"/> array.
        /// </summary>
        public static explicit operator ByteString(Variant v)
        {
            if (v.Type != VariantType.ByteString) {
                throw new InvalidCastException();
            }
            return v.Bytestring;
        }

        /// <summary>
        /// Coverts <see cref="byte"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ByteString value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/>.
        /// </summary>
        public static explicit operator WeakZeroTerminatedCPtrArray<ByteString>?(Variant v)
        {
            if (v.Type != VariantType.ByteStringArray) {
                throw new InvalidCastException();
            }
            return v.GetBytestringArray();
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="Strv{T}"/> of <see cref="ByteString"/>.
        /// </summary>
        public static explicit operator Strv<ByteString>?(Variant v)
        {
            if (v.Type != VariantType.ByteStringArray) {
                throw new InvalidCastException();
            }
            return v.DupBytestringArray();
        }

        /// <summary>
        /// Coverts <see cref="Strv{T}"/> of <see cref="ByteString"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(Strv<ByteString> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(WeakZeroTerminatedCPtrArray<ByteString> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="UnownedZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(UnownedZeroTerminatedCPtrArray<ByteString> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="double"/>.
        /// </summary>
        public static explicit operator double(Variant v)
        {
            if (v.Type != VariantType.Double) {
                throw new InvalidCastException();
            }
            return v.Double;
        }

        /// <summary>
        /// Coverts <see cref="double"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(double value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusHandle"/>.
        /// </summary>

        public static explicit operator DBusHandle(Variant v)
        {
            if (v.Type != VariantType.DBusHandle) {
                throw new InvalidCastException();
            }
            return v.Handle;
        }

        /// <summary>
        /// Coverts <see cref="DBusHandle"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusHandle value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="short"/>.
        /// </summary>
        public static explicit operator short(Variant v)
        {
            if (v.Type != VariantType.Int16) {
                throw new InvalidCastException();
            }
            return v.Int16;
        }

        /// <summary>
        /// Coverts <see cref="short"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(short value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="int"/>.
        /// </summary>
        public static explicit operator int(Variant v)
        {
            if (v.Type != VariantType.Int32) {
                throw new InvalidCastException();
            }
            return v.Int32;
        }

        /// <summary>
        /// Coverts <see cref="int"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(int value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="long"/>.
        /// </summary>
        public static explicit operator long(Variant v)
        {
            if (v.Type != VariantType.Int64) {
                throw new InvalidCastException();
            }
            return v.Int64;
        }

        /// <summary>
        /// Coverts <see cref="long"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(long value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusObjectPath"/>.
        /// </summary>
        public static explicit operator DBusObjectPath(Variant v)
        {
            if (v.Type != VariantType.DBusObjectPath) {
                throw new InvalidCastException();
            }
            return v.DupDBusObjectPath();
        }

        /// <summary>
        /// Coverts <see cref="DBusObjectPath"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusObjectPath value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusSignature"/>.
        /// </summary>
        public static explicit operator DBusSignature(Variant v)
        {
            if (v.Type != VariantType.DBusSignature) {
                throw new InvalidCastException();
            }
            return v.DupDBusSignature();
        }

        /// <summary>
        /// Coverts <see cref="DBusSignature"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusSignature value)
        {
            return new Variant(value);
        }

        // TODO cast Maybe to nullable types

        /// <summary>
        /// Coverts <see cref="ValueTuple"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator ValueTuple(Variant value)
        {
            if (!value.IsOfType(VariantType.Unit)) {
                throw new InvalidCastException();
            }
            return default;
        }

        /// <summary>
        /// Coverts <see cref="ValueTuple"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ValueTuple value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusObjectPath"/> array.
        /// </summary>
        public static explicit operator WeakZeroTerminatedCPtrArray<DBusObjectPath>(Variant v)
        {
            if (v.Type != VariantType.DBusObjectPathArray) {
                throw new InvalidCastException();
            }
            return v.Objv;
        }

        /// <summary>
        /// Coverts <see cref="DBusObjectPath"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(WeakCPtrArray<DBusObjectPath> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="DBusObjectPath"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(UnownedCPtrArray<DBusObjectPath> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="string"/>.
        /// </summary>
        public static explicit operator string(Variant v)
        {
            if (v.Type != VariantType.String) {
                throw new InvalidCastException();
            }
            return v.GetString();
        }

        /// <summary>
        /// Coverts <see cref="string"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(string value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="Utf8"/>.
        /// </summary>
        public static explicit operator WeakZeroTerminatedCPtrArray<Utf8>?(Variant v)
        {
            if (v.Type != VariantType.StringArray) {
                throw new InvalidCastException();
            }
            return v.Strv;
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="Strv{T}"/> of <see cref="Utf8"/>.
        /// </summary>
        public static explicit operator Strv<Utf8>?(Variant v)
        {
            if (v.Type != VariantType.StringArray) {
                throw new InvalidCastException();
            }
            return v.DupStrv();
        }

        /// <summary>
        /// Coverts <see cref="Strv{T}"/> of <see cref="Utf8"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(Strv<Utf8> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="ushort"/>.
        /// </summary>
        public static explicit operator ushort(Variant v)
        {
            if (v.Type != VariantType.UInt16) {
                throw new InvalidCastException();
            }
            return v.Uint16;
        }

        /// <summary>
        /// Coverts <see cref="ushort"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ushort value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="uint"/>.
        /// </summary>
        public static explicit operator uint(Variant v)
        {
            if (v.Type != VariantType.UInt32) {
                throw new InvalidCastException();
            }
            return v.Uint32;
        }

        /// <summary>
        /// Coverts <see cref="uint"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(uint value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="ulong"/>.
        /// </summary>
        public static explicit operator ulong(Variant v)
        {
            if (v.Type != VariantType.UInt64) {
                throw new InvalidCastException();
            }
            return v.Uint64;
        }

        /// <summary>
        /// Coverts <see cref="ulong"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ulong value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="KeyValuePair{K,V}"/>.
        /// </summary>
        public static explicit operator KeyValuePair<Variant, Variant>(Variant v)
        {
            if (!v.Type.IsDictEntry) {
                throw new InvalidCastException();
            }
            return new KeyValuePair<Variant, Variant>(v.ChildValues[0], v.ChildValues[1]);
        }

        /// <summary>
        /// Coverts <see cref="KeyValuePair{K,V}"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(KeyValuePair<Variant, Variant> value)
        {
            return new Variant(value.Key, value.Value);
        }

        static partial void CheckNewArrayArgs(VariantType? childType, UnownedCPtrArray<Variant> children)
        {
            if (childType is null && (children.Data.Length == 0)) {
                throw new ArgumentException("Must specify child type when no children", nameof(childType));
            }
            if (childType is null && children.Data.Length == 0) {
                throw new ArgumentException("childType and children cannot both be null");
            }
            if (children.Data.Length != 0) {
                var testChildType = childType ?? children[0].Type;
                foreach (var item in children) {
                    if (item is null) {
                        throw new ArgumentException("Array cannot have null elements", nameof(children));
                    }
                    if (item.Type != testChildType) {
                        throw new ArgumentException("All children must have the same variant type.", nameof(children));
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        ///
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        ///
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        [Since("2.24")]
        public static Variant CreateArray(VariantType? childType, params Variant[] children)
        {
            using var childrenArray = children.ToWeakCPtrArray();
            return new Variant(childType, childrenArray);
        }

        static UnmanagedStruct* NewBytestringArray(UnownedZeroTerminatedCPtrArray<ByteString> value)
        {
            var strv_ = (byte**)value.UnsafeHandle;
            var ret_ = g_variant_new_bytestring_array(strv_, -1);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Constructs an array of bytestring <see cref="Variant"/> from the given array of
        /// strings.
        /// </summary>
        public Variant(UnownedZeroTerminatedCPtrArray<ByteString> value)
            : this((IntPtr)NewBytestringArray(value), Transfer.None)
        {
        }

        static partial void CheckNewDictEntryArgs(Variant key, Variant value)
        {
            if (!key.Type.IsBasic) {
                throw new ArgumentException("Key must be a basic variant type.", nameof(key));
            }
        }

        /// <summary>
        /// Creates a new dictionary entry <see cref="Variant"/>. <c>TKey</c>
        /// and <c>TValue</c> must be non-null. key must be a value of a basic
        /// type (ie: not a container).
        /// </summary>
        [Since("2.24")]
        public Variant(KeyValuePair<Variant, Variant> value)
            : this(value.Key, value.Value)
        {
        }

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewStrv(Strv<Utf8> strv)
        {
            var strv_ = (byte**)strv.UnsafeHandle;
            var ret = g_variant_new_strv(strv_, -1);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        [Since("2.24")]
        public Variant(Strv<Utf8> strv) : this((IntPtr)NewStrv(strv), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewTuple(ITuple children)
        {
            var children_ = stackalloc UnmanagedStruct*[children.Length];
            var nChildren_ = (nuint)children.Length;

            for (var i = 0; i < children.Length; i++) {
                var child = (Variant?)children[i];

                if (child is null) {
                    throw new ArgumentException("Tuple cannot have null elements", nameof(children));
                }

                children_[i] = (UnmanagedStruct*)child.UnsafeHandle;
            }

            var ret = g_variant_new_tuple(children_, nChildren_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        [Since("2.24")]
        public Variant(ITuple children) : this((IntPtr)NewTuple(children), Transfer.None)
        {
        }

        /// <summary>
        /// Parses a #GVariant from a text representation.
        /// </summary>
        /// <remarks>
        /// A single #GVariant is parsed from the content of @text.
        ///
        /// The format is described [here][gvariant-text].
        ///
        /// The memory at @limit will never be accessed and the parser behaves as
        /// if the character at @limit is the nul terminator.  This has the
        /// effect of bounding @text.
        ///
        /// If @endptr is non-%NULL then @text is permitted to contain data
        /// following the value that this function parses and @endptr will be
        /// updated to point to the first character past the end of the text
        /// parsed by this function.  If @endptr is %NULL and there is extra data
        /// then an error is returned.
        ///
        /// If @type is non-%NULL then the value will be parsed to have that
        /// type.  This may result in additional parse errors (in the case that
        /// the parsed value doesn't fit the type) but may also result in fewer
        /// errors (in the case that the type would have been ambiguous, such as
        /// with empty arrays).
        ///
        /// In the event that the parsing is successful, the resulting #GVariant
        /// is returned. It is never floating, and must be freed with
        /// g_variant_unref().
        ///
        /// In case of any error, %NULL will be returned.  If @error is non-%NULL
        /// then it will be set to reflect the error that occurred.
        ///
        /// Officially, the language understood by the parser is "any string
        /// produced by g_variant_print()".
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <param name="text">
        /// a string containing a GVariant in text form
        /// </param>
        /// <returns>
        /// a non-floating reference to a #GVariant, or %NULL
        /// </returns>
        public static Variant Parse(VariantType? type, UnownedUtf8 text)
        {
            var type_ = (VariantType.UnmanagedStruct*)(type?.UnsafeHandle ?? IntPtr.Zero);
            var text_ = (byte*)text.UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret = g_variant_parse(type_, text_, null, null, &error_);
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new Error.Exception(error);
            }
            return new Variant((IntPtr)ret, Transfer.Full);
        }

        static partial void CheckCompareArgs(Variant one, Variant two)
        {
            if (one.Type != two.Type) {
                var message = $"Variant types must match but have '{one.Type}' and '{two.Type}'";
                throw new InvalidOperationException(message);
            }
        }

        partial void CheckGetBooleanArgs()
        {
            if (!IsOfType(VariantType.Boolean)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetByteArgs()
        {
            if (!IsOfType(VariantType.Byte)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetBytestringArgs()
        {
            if (!IsOfType(VariantType.ByteString)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetBytestringArrayArgs()
        {
            if (!IsOfType(VariantType.ByteStringArray)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckDupBytestringArrayArgs()
        {
            if (!IsOfType(VariantType.ByteStringArray)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetChildValueArgs(int index)
        {
            if (!IsContainer) {
                throw new InvalidOperationException();
            }
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        partial void CheckGetDoubleArgs()
        {
            if (!IsOfType(VariantType.Double)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetHandleArgs()
        {
            if (!IsOfType(VariantType.DBusHandle)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetInt16Args()
        {
            if (!IsOfType(VariantType.Int16)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetInt32Args()
        {
            if (!IsOfType(VariantType.Int32)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetInt64Args()
        {
            if (!IsOfType(VariantType.Int64)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetMaybeArgs()
        {
            if (!IsOfType(VariantType.Maybe)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetObjvArgs()
        {
            if (!IsOfType(VariantType.DBusObjectPathArray)) {
                throw new InvalidOperationException();
            }
        }
        partial void CheckGetStringArgs()
        {
            if (!IsOfType(VariantType.String) && !IsOfType(VariantType.DBusObjectPath) && !IsOfType(VariantType.DBusSignature)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetStrvArgs()
        {
            if (!IsOfType(VariantType.StringArray)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckDupStrvArgs()
        {
            if (!IsOfType(VariantType.StringArray)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetUint16Args()
        {
            if (!IsOfType(VariantType.UInt16)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetUint32Args()
        {
            if (!IsOfType(VariantType.UInt32)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetUint64Args()
        {
            if (!IsOfType(VariantType.UInt64)) {
                throw new InvalidOperationException();
            }
        }

        partial void CheckGetBoxedVariantArgs()
        {
            if (!IsOfType(VariantType.Variant)) {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Stores the serialised form of this value value in <paramref name="data" />.
        /// <paramref name="data" /> should be large enough. See <see cref="Size" />.
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// <see cref="NormalForm" /> for a solution.
        ///
        /// As with <see cref="Data" />, to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        ///
        /// This function is approximately O(n) in the size of <paramref name="data" />.
        /// </remarks>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [Since("2.24")]
        public void Store(Span<byte> data)
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            if (data.Length < Size) {
                throw new ArgumentException("Not large enough", nameof(data));
            }
            fixed (void* data_ = data) {
                g_variant_store(value_, (IntPtr)data_);
                GMarshal.PopUnhandledException();
            }
        }

        private IEnumerator<Variant> GetEnumerator() => new VariantIter(this);
        IEnumerator<Variant> IEnumerable<Variant>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6, out Variant v7)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
            v7 = ChildValues[6];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6, out Variant v7, out Variant v8)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
            v7 = ChildValues[6];
            v8 = ChildValues[7];
        }
    }
}
