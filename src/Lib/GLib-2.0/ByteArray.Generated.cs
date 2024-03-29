// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray']/*" />
    [GISharp.Runtime.GTypeAttribute("GByteArray", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class ByteArray : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Runtime.GType _GType = g_byte_array_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ByteArray.xmldoc" path="declaration/member[@name='UnmanagedStruct.Data']/*" />
            public readonly byte* Data;

            /// <include file="ByteArray.xmldoc" path="declaration/member[@name='UnmanagedStruct.Len']/*" />
            public readonly uint Len;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ByteArray(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_byte_array_ref((UnmanagedStruct*)handle);
            }
        }

        /// <summary>
        /// Creates a new #GByteArray with a reference count of 1.
        /// </summary>
        /// <returns>
        /// the new #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_new();
        static partial void CheckNewArgs();

        static GISharp.Lib.GLib.ByteArray.UnmanagedStruct* New()
        {
            CheckNewArgs();
            var ret_ = g_byte_array_new();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.ByteArray()']/*" />
        public ByteArray() : this((System.IntPtr)New(), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Create byte array containing the data. The data will be owned by the array
        /// and will be freed with g_free(), i.e. it could be allocated using g_strdup().
        /// </summary>
        /// <remarks>
        /// <para>
        /// Do not use it if @len is greater than %G_MAXUINT. #GByteArray
        /// stores the length of its data in #guint, which may be shorter than
        /// #gsize.
        /// </para>
        /// </remarks>
        /// <param name="data">
        /// byte data for the array
        /// </param>
        /// <param name="len">
        /// length of @data
        /// </param>
        /// <returns>
        /// a new #GByteArray
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_new_take(
        /* <array length="1" zero-terminated="0" type="guint8*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        byte* data,
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        nuint len);
        static partial void CheckNewTakeArgs(GISharp.Runtime.CArray<byte> data);

        [GISharp.Runtime.SinceAttribute("2.32")]
        static GISharp.Lib.GLib.ByteArray.UnmanagedStruct* NewTake(GISharp.Runtime.CArray<byte> data)
        {
            CheckNewTakeArgs(data);
            var (dataData_, dataLength_) = data.TakeData();
            var data_ = (byte*)dataData_;
            var len_ = (nuint)dataLength_;
            var ret_ = g_byte_array_new_take(data_,len_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.ByteArray(GISharp.Runtime.CArray&lt;byte&gt;)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public ByteArray(GISharp.Runtime.CArray<byte> data) : this((System.IntPtr)NewTake(data), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new #GByteArray with @reserved_size bytes preallocated.
        /// This avoids frequent reallocation, if you are going to add many
        /// bytes to the array. Note however that the size of the array is still
        /// 0.
        /// </summary>
        /// <param name="reservedSize">
        /// number of bytes preallocated
        /// </param>
        /// <returns>
        /// the new #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_sized_new(
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint reservedSize);
        static partial void CheckSizedNewArgs(uint reservedSize);

        static GISharp.Lib.GLib.ByteArray.UnmanagedStruct* SizedNew(uint reservedSize)
        {
            CheckSizedNewArgs(reservedSize);
            var reservedSize_ = (uint)reservedSize;
            var ret_ = g_byte_array_sized_new(reservedSize_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.ByteArray(uint)']/*" />
        public ByteArray(uint reservedSize) : this((System.IntPtr)SizedNew(reservedSize), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_byte_array_get_type();

        /// <summary>
        /// Adds the given bytes to the end of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        /// <param name="len">
        /// the number of bytes to add
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_append(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <array length="1" zero-terminated="0" type="const guint8*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        byte* data,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint len);
        partial void CheckAppendArgs(System.ReadOnlySpan<byte> data);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.Append(System.ReadOnlySpan&lt;byte&gt;)']/*" />
        public void Append(System.ReadOnlySpan<byte> data)
        {
            fixed (byte* dataData_ = data)
            {
                CheckAppendArgs(data);
                var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
                var data_ = (byte*)dataData_;
                var len_ = (uint)data.Length;
                g_byte_array_append(array_, data_, len_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Frees the memory allocated by the #GByteArray. If @free_segment is
        /// %TRUE it frees the actual byte data. If the reference count of
        /// @array is greater than one, the #GByteArray wrapper is preserved but
        /// the size of @array will be set to zero.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="freeSegment">
        /// if %TRUE the actual byte data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @free_segment is %FALSE, otherwise
        ///          %NULL.  The element data should be freed using g_free().
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint8" type="guint8*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_byte_array_free(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean freeSegment);
        partial void CheckFreeArgs(bool freeSegment);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.Free(bool)']/*" />
        public ref readonly byte Free(bool freeSegment)
        {
            CheckFreeArgs(freeSegment);
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
            var freeSegment_ = GISharp.Runtime.BooleanExtensions.ToBoolean(freeSegment);
            var ret_ = g_byte_array_free(array_,freeSegment_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            ref var ret = ref System.Runtime.CompilerServices.Unsafe.AsRef<byte>(ret_);
            return ref ret;
        }

        /// <summary>
        /// Transfers the data from the #GByteArray into a new immutable #GBytes.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The #GByteArray is freed unless the reference count of @array is greater
        /// than one, the #GByteArray wrapper is preserved but the size of @array
        /// will be set to zero.
        /// </para>
        /// <para>
        /// This is identical to using g_bytes_new_take() and g_byte_array_free()
        /// together.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <returns>
        /// a new immutable #GBytes representing same
        ///     byte data that was in the array
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_byte_array_free_to_bytes(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array);
        partial void CheckFreeToBytesArgs();

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.FreeToBytes()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public GISharp.Lib.GLib.Bytes FreeToBytes()
        {
            CheckFreeToBytesArgs();
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)Take();
            var ret_ = g_byte_array_free_to_bytes(array_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Bytes.GetInstance<GISharp.Lib.GLib.Bytes>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Adds the given data to the start of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        /// <param name="len">
        /// the number of bytes to add
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_prepend(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <array length="1" zero-terminated="0" type="const guint8*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        byte* data,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint len);
        partial void CheckPrependArgs(System.ReadOnlySpan<byte> data);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.Prepend(System.ReadOnlySpan&lt;byte&gt;)']/*" />
        public void Prepend(System.ReadOnlySpan<byte> data)
        {
            fixed (byte* dataData_ = data)
            {
                CheckPrependArgs(data);
                var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
                var data_ = (byte*)dataData_;
                var len_ = (uint)data.Length;
                g_byte_array_prepend(array_, data_, len_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Atomically increments the reference count of @array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// A #GByteArray
        /// </param>
        /// <returns>
        /// The passed in #GByteArray
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_ref(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_byte_array_ref((GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray.
        /// The following bytes are moved down one place.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_remove_index(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint index);
        partial void CheckRemoveIndexArgs(uint index);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.RemoveIndex(uint)']/*" />
        public void RemoveIndex(uint index)
        {
            CheckRemoveIndexArgs(index);
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
            var index_ = (uint)index;
            g_byte_array_remove_index(array_, index_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the #GByteArray. But it is faster
        /// than g_byte_array_remove_index().
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_remove_index_fast(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint index);
        partial void CheckRemoveIndexFastArgs(uint index);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.RemoveIndexFast(uint)']/*" />
        public void RemoveIndexFast(uint index)
        {
            CheckRemoveIndexFastArgs(index);
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
            var index_ = (uint)index;
            g_byte_array_remove_index_fast(array_, index_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Removes the given number of bytes starting at the given index from a
        /// #GByteArray.  The following elements are moved to close the gap.
        /// </summary>
        /// <param name="array">
        /// a @GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the first byte to remove
        /// </param>
        /// <param name="length">
        /// the number of bytes to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_remove_range(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint index,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint length);
        partial void CheckRemoveRangeArgs(uint index, uint length);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.RemoveRange(uint,uint)']/*" />
        [GISharp.Runtime.SinceAttribute("2.4")]
        public void RemoveRange(uint index, uint length)
        {
            CheckRemoveRangeArgs(index, length);
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
            var index_ = (uint)index;
            var length_ = (uint)length;
            g_byte_array_remove_range(array_, index_, length_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the size of the #GByteArray, expanding it if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="length">
        /// the new size of the #GByteArray
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* skip:1 transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_byte_array_set_size(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint length);
        partial void CheckSetSizeArgs(uint length);

        /// <include file="ByteArray.xmldoc" path="declaration/member[@name='ByteArray.SetSize(uint)']/*" />
        public void SetSize(uint length)
        {
            CheckSetSizeArgs(length);
            var array_ = (GISharp.Lib.GLib.ByteArray.UnmanagedStruct*)UnsafeHandle;
            var length_ = (uint)length;
            g_byte_array_set_size(array_, length_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sorts a byte array, using @compare_func which should be a
        /// qsort()-style comparison function (returns less than zero for first
        /// arg is less than second arg, zero for equal, greater than zero if
        /// first arg is greater than second arg).
        /// </summary>
        /// <remarks>
        /// <para>
        /// If two array elements compare equal, their order in the sorted array
        /// is undefined. If you want equal elements to keep their order (i.e.
        /// you want a stable sort) you can write a comparison function that,
        /// if two elements would otherwise compare equal, compares them by
        /// their addresses.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_byte_array_sort(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="CompareFunc" type="GCompareFunc" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, int> compareFunc);

        /// <summary>
        /// Like g_byte_array_sort(), but the comparison function takes an extra
        /// user data argument.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        /// <param name="userData">
        /// data to pass to @compare_func
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_byte_array_sort_with_data(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array,
        /* <type name="CompareDataFunc" type="GCompareDataFunc" /> */
        /* transfer-ownership:none closure:1 scope:call direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, System.IntPtr, int> compareFunc,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Atomically decrements the reference count of @array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is thread-safe and may be called from any
        /// thread.
        /// </summary>
        /// <param name="array">
        /// A #GByteArray
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_byte_array_unref(
        /* <array name="GLib.ByteArray" type="GByteArray*" is-pointer="1">
*   <type name="guint8" type="guint8" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.ByteArray.UnmanagedStruct* array);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_byte_array_unref((UnmanagedStruct*)handle);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            base.Dispose(disposing);
        }
    }
}