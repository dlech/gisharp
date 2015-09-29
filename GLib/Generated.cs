namespace GISharp.GLib
{
    /// <summary>
    /// Integer representing a day of the month; between 1 and 31.
    /// #G_DATE_BAD_DAY represents an invalid day of the month.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct DateDay
    {
        private System.Byte value;

        public static implicit operator DateDay(System.Byte value)
        {
            return new DateDay { value = value };
        }

        public static implicit operator System.Byte(DateDay value)
        {
            return value.value;
        }
    }

    /// <summary>
    /// Integer representing a year; #G_DATE_BAD_YEAR is the invalid
    /// value. The year must be 1 or higher; negative (BC) years are not
    /// allowed. The year is represented with four digits.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct DateYear
    {
        private System.UInt16 value;

        public static implicit operator DateYear(System.UInt16 value)
        {
            return new DateYear { value = value };
        }

        public static implicit operator System.UInt16(DateYear value)
        {
            return value.value;
        }
    }

    /// <summary>
    /// A GQuark is a non-zero integer which uniquely identifies a
    /// particular string. A GQuark value of zero is associated to %NULL.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Quark
    {
        private System.UInt32 value;

        public static implicit operator Quark(System.UInt32 value)
        {
            return new Quark { value = value };
        }

        public static implicit operator System.UInt32(Quark value)
        {
            return value.value;
        }

        /// <summary>
        /// Gets the #GQuark identifying the given string. If the string does
        /// not currently have an associated #GQuark, a new #GQuark is created,
        /// using a copy of the string.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark identifying the string, or 0 if @string is %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.Quark g_quark_from_string /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Gets the #GQuark identifying the given string. If the string does
        /// not currently have an associated #GQuark, a new #GQuark is created,
        /// using a copy of the string.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark identifying the string, or 0 if @string is %NULL
        /// </returns>
        public static GISharp.GLib.Quark FromString(
            System.String @string)
        {
            var @stringPtr = default(System.IntPtr);
            var ret = g_quark_from_string(@stringPtr);
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Gets the #GQuark associated with the given string, or 0 if string is
        /// %NULL or it has no associated #GQuark.
        /// </summary>
        /// <remarks>
        /// If you want the GQuark to be created if it doesn't already exist,
        /// use g_quark_from_string() or g_quark_from_static_string().
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark associated with the string, or 0 if @string is
        ///     %NULL or there is no #GQuark associated with it
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.Quark g_quark_try_string /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Gets the #GQuark associated with the given string, or 0 if string is
        /// %NULL or it has no associated #GQuark.
        /// </summary>
        /// <remarks>
        /// If you want the GQuark to be created if it doesn't already exist,
        /// use g_quark_from_string() or g_quark_from_static_string().
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark associated with the string, or 0 if @string is
        ///     %NULL or there is no #GQuark associated with it
        /// </returns>
        public static GISharp.GLib.Quark TryString(
            System.String @string)
        {
            var @stringPtr = default(System.IntPtr);
            var ret = g_quark_try_string(@stringPtr);
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [GISharp.Core.SinceAttribute("2.10")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_intern_string /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [GISharp.Core.SinceAttribute("2.10")]
        public static System.IntPtr InternString(
            System.String @string)
        {
            var @stringPtr = default(System.IntPtr);
            var ret = g_intern_string(@stringPtr);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_quark_to_string /* transfer-ownership:none */();

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        public override System.String ToString()
        {
            var retPtr = g_quark_to_string();
            return default(System.String);
        }
    }

    /// <summary>
    /// A C representable type name for #G_TYPE_STRV.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Strv
    {
        private System.IntPtr value;

        public static implicit operator Strv(System.IntPtr value)
        {
            return new Strv { value = value };
        }

        public static implicit operator System.IntPtr(Strv value)
        {
            return value.value;
        }
    }

    /// <summary>
    /// A value representing an interval of time, in microseconds.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TimeSpan
    {
        /// <summary>
        /// Evaluates to a time span of one day.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        public const System.Int64 Day = 86400000000L;

        /// <summary>
        /// Evaluates to a time span of one hour.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        public const System.Int64 Hour = 3600000000L;

        /// <summary>
        /// Evaluates to a time span of one millisecond.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        public const System.Int64 Millisecond = 1000L;

        /// <summary>
        /// Evaluates to a time span of one minute.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        public const System.Int64 Minute = 60000000L;

        /// <summary>
        /// Evaluates to a time span of one second.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        public const System.Int64 Second = 1000000L;
        private System.Int64 value;

        public static implicit operator TimeSpan(System.Int64 value)
        {
            return new TimeSpan { value = value };
        }

        public static implicit operator System.Int64(TimeSpan value)
        {
            return value.value;
        }
    }

    /// <summary>
    /// A simple refcounted data type representing an immutable sequence of zero or
    /// more bytes from an unspecified origin.
    /// </summary>
    /// <remarks>
    /// The purpose of a #GBytes is to keep the memory region that it holds
    /// alive for as long as anyone holds a reference to the bytes.  When
    /// the last reference count is dropped, the memory is released. Multiple
    /// unrelated callers can use byte data in the #GBytes without coordinating
    /// their activities, resting assured that the byte data will not change or
    /// move while they hold a reference.
    /// 
    /// A #GBytes can come from many different origins that may have
    /// different procedures for freeing the memory region.  Examples are
    /// memory from g_malloc(), from memory slices, from a #GMappedFile or
    /// memory from other allocators.
    /// 
    /// #GBytes work well as keys in #GHashTable. Use g_bytes_equal() and
    /// g_bytes_hash() as parameters to g_hash_table_new() or g_hash_table_new_full().
    /// #GBytes can also be used as keys in a #GTree by passing the g_bytes_compare()
    /// function to g_tree_new().
    /// 
    /// The data pointed to by this bytes must not be modified. For a mutable
    /// array of bytes see #GByteArray. Use g_bytes_unref_to_array() to create a
    /// mutable array for a #GBytes sequence. To create an immutable #GBytes from
    /// a mutable #GByteArray, use the g_byte_array_free_to_bytes() function.
    /// </remarks>
    [GISharp.Core.SinceAttribute("2.32")]
    public partial class Bytes : GISharp.Core.ReferenceCountedOpaque<Bytes>, System.IEquatable<Bytes>, System.IComparable<Bytes>
    {
        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// @data is copied. If @size is 0, @data may be %NULL.
        /// </remarks>
        /// <param name="data">
        /// 
        ///        the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new /* transfer-ownership:full */(
            System.IntPtr data /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.UInt64 size /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// @data is copied. If @size is 0, @data may be %NULL.
        /// </remarks>
        /// <param name="data">
        /// 
        ///        the data to be used for the bytes
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public Bytes(
            System.Byte[] data)
        {
            var dataPtr = default(System.IntPtr);
            var size = (System.UInt64)data.Length;
            Handle = g_bytes_new(dataPtr, size);
        }

        /// <summary>
        /// Creates a #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// When the last reference is dropped, @free_func will be called with the
        /// @user_data argument.
        /// 
        /// @data must not be modified after this call is made until @free_func has
        /// been called to indicate that the bytes is no longer in use.
        /// 
        /// @data may be %NULL if @size is 0.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="freeFunc">
        /// the function to call to release the data
        /// </param>
        /// <param name="userData">
        /// data to pass to @free_func
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new_with_free_func /* transfer-ownership:full */(
            System.IntPtr data /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.UInt64 size /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify freeFunc /* transfer-ownership:none scope:async */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if bytes2 is lesser, a positive value if bytes2 is
        ///          greater, and zero if bytes2 is equal to bytes1
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_bytes_compare /* transfer-ownership:none */(
            System.IntPtr bytes1 /* transfer-ownership:none */,
            System.IntPtr bytes2 /* transfer-ownership:none */);

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if bytes2 is lesser, a positive value if bytes2 is
        ///          greater, and zero if bytes2 is equal to bytes1
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public System.Int32 CompareTo(
            GISharp.GLib.Bytes bytes2)
        {
            if (bytes2 == null)
            {
                throw new System.ArgumentNullException("bytes2");
            }
            var bytes2Ptr = default(System.IntPtr);
            var ret = g_bytes_compare(Handle, bytes2Ptr);
            return default(System.Int32);
        }

        public static bool operator >=(Bytes one, Bytes two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Bytes one, Bytes two)
        {
            return one.CompareTo(two) > 0;
        }

        public static bool operator <(Bytes one, Bytes two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Bytes one, Bytes two)
        {
            return one.CompareTo(two) <= 0;
        }

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_bytes_equal /* transfer-ownership:none */(
            System.IntPtr bytes1 /* transfer-ownership:none */,
            System.IntPtr bytes2 /* transfer-ownership:none */);

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public System.Boolean Equals(
            GISharp.GLib.Bytes bytes2)
        {
            if (bytes2 == null)
            {
                throw new System.ArgumentNullException("bytes2");
            }
            var bytes2Ptr = default(System.IntPtr);
            var ret = g_bytes_equal(Handle, bytes2Ptr);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Bytes);
        }

        public static bool operator ==(Bytes one, Bytes two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(Bytes one, Bytes two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Get the byte data in the #GBytes. This data should not be modified.
        /// </summary>
        /// <remarks>
        /// This function will always return the same pointer for a given #GBytes.
        /// 
        /// %NULL may be returned if @size is 0. This is not guaranteed, as the #GBytes
        /// may represent an empty string with @data non-%NULL and @size as 0. %NULL will
        /// not be returned if @size is non-zero.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to return size of byte data
        /// </param>
        /// <returns>
        /// a pointer to the
        ///          byte data, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_get_data /* transfer-ownership:none */(
            System.IntPtr bytes /* transfer-ownership:none */,
            out System.UInt64 size /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Get the byte data in the #GBytes. This data should not be modified.
        /// </summary>
        /// <remarks>
        /// This function will always return the same pointer for a given #GBytes.
        /// 
        /// %NULL may be returned if @size is 0. This is not guaranteed, as the #GBytes
        /// may represent an empty string with @data non-%NULL and @size as 0. %NULL will
        /// not be returned if @size is non-zero.
        /// </remarks>
        /// <returns>
        /// a pointer to the
        ///          byte data, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public System.Byte[] Data
        {
            get
            {
                System.UInt64 size;
                var retPtr = g_bytes_get_data(Handle,out size);
                return default(System.Byte[]);
            }
        }

        /// <summary>
        /// Get the size of the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given #GBytes.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the size
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_bytes_get_size /* transfer-ownership:none */(
            System.IntPtr bytes /* transfer-ownership:none */);

        /// <summary>
        /// Get the size of the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given #GBytes.
        /// </remarks>
        /// <returns>
        /// the size
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public System.UInt64 Size
        {
            get
            {
                var ret = g_bytes_get_size(Handle);
                return default(System.UInt64);
            }
        }

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes">
        /// a pointer to a #GBytes key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_bytes_hash /* transfer-ownership:none */(
            System.IntPtr bytes /* transfer-ownership:none */);

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        protected System.UInt32 Hash()
        {
            var ret = g_bytes_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new_from_bytes /* transfer-ownership:full */(
            System.IntPtr bytes /* transfer-ownership:none */,
            System.UInt64 offset /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// </remarks>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public GISharp.GLib.Bytes NewFromBytes(
            System.UInt64 offset,
            System.UInt64 length)
        {
            var retPtr = g_bytes_new_from_bytes(Handle, offset, length);
            return default(GISharp.GLib.Bytes);
        }

        /// <summary>
        /// Increase the reference count on @bytes.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the #GBytes
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr bytes /* transfer-ownership:none */);

        /// <summary>
        /// Increase the reference count on @bytes.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        protected override void Ref()
        {
            g_bytes_ref(Handle);
        }

        /// <summary>
        /// Releases a reference on @bytes.  This may result in the bytes being
        /// freed.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_bytes_unref /* transfer-ownership:none */(
            System.IntPtr bytes /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Releases a reference on @bytes.  This may result in the bytes being
        /// freed.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        protected override void Unref()
        {
            g_bytes_unref(Handle);
        }

        /// <summary>
        /// Unreferences the bytes, and returns a new mutable #GByteArray containing
        /// the same byte data.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is transferred to the array without copying
        /// if this was the last reference to bytes and bytes was created with
        /// g_bytes_new(), g_bytes_new_take() or g_byte_array_free_to_bytes(). In all
        /// other cases the data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// a new mutable #GByteArray containing the same byte data
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_unref_to_array /* transfer-ownership:full */(
            System.IntPtr bytes /* transfer-ownership:full */);

        /// <summary>
        /// Unreferences the bytes, and returns a new mutable #GByteArray containing
        /// the same byte data.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is transferred to the array without copying
        /// if this was the last reference to bytes and bytes was created with
        /// g_bytes_new(), g_bytes_new_take() or g_byte_array_free_to_bytes(). In all
        /// other cases the data is copied.
        /// </remarks>
        /// <returns>
        /// a new mutable #GByteArray containing the same byte data
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public GISharp.Core.ByteArray UnrefToArray()
        {
            var retPtr = g_bytes_unref_to_array(Handle);
            return default(GISharp.Core.ByteArray);
        }

        /// <summary>
        /// Unreferences the bytes, and returns a pointer the same byte data
        /// contents.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is returned without copying if this was
        /// the last reference to bytes and bytes was created with g_bytes_new(),
        /// g_bytes_new_take() or g_byte_array_free_to_bytes(). In all other cases the
        /// data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to place the length of the returned data
        /// </param>
        /// <returns>
        /// a pointer to the same byte data, which should
        ///          be freed with g_free()
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_unref_to_data /* transfer-ownership:full */(
            System.IntPtr bytes /* transfer-ownership:full */,
            System.UInt64 size /* transfer-ownership:none */);

        /// <summary>
        /// Unreferences the bytes, and returns a pointer the same byte data
        /// contents.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is returned without copying if this was
        /// the last reference to bytes and bytes was created with g_bytes_new(),
        /// g_bytes_new_take() or g_byte_array_free_to_bytes(). In all other cases the
        /// data is copied.
        /// </remarks>
        /// <param name="size">
        /// location to place the length of the returned data
        /// </param>
        /// <returns>
        /// a pointer to the same byte data, which should
        ///          be freed with g_free()
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public System.IntPtr UnrefToData(
            System.UInt64 size)
        {
            var ret = g_bytes_unref_to_data(Handle, size);
            return default(System.IntPtr);
        }
    }

    /// <summary>
    /// The #GData struct is an opaque data structure to represent a
    /// [Keyed Data List][glib-Keyed-Data-Lists]. It should only be
    /// accessed via the following functions.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Data
    {
    }

    /// <summary>
    /// Specifies the type of function passed to g_dataset_foreach(). It is
    /// called with each #GQuark id and associated data element, together
    /// with the @user_data parameter supplied to g_dataset_foreach().
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void DataForeachFunc(
        GISharp.GLib.Quark keyId /* transfer-ownership:none */,
        System.IntPtr data /* transfer-ownership:none */,
        System.IntPtr userData /* transfer-ownership:none closure:2 */);

    /// <summary>
    /// Specifies the type of function passed to g_dataset_foreach(). It is
    /// called with each #GQuark id and associated data element, together
    /// with the @user_data parameter supplied to g_dataset_foreach().
    /// </summary>
    public delegate void DataForeachFuncCallback(
        GISharp.GLib.Quark keyId,
        System.IntPtr data);

    /// <summary>
    /// Represents a day between January 1, Year 1 and a few thousand years in
    /// the future. None of its members should be accessed directly.
    /// </summary>
    /// <remarks>
    /// If the #GDate-struct is obtained from g_date_new(), it will be safe
    /// to mutate but invalid and thus not safe for calendrical computations.
    /// 
    /// If it's declared on the stack, it will contain garbage so must be
    /// initialized with g_date_clear(). g_date_clear() makes the date invalid
    /// but sane. An invalid date doesn't represent a day, it's "empty." A date
    /// becomes valid after you set it to a Julian day or you set a day, month,
    /// and year.
    /// </remarks>
    public partial class Date : GISharp.Core.OwnedOpaque<Date>, System.IComparable<Date>
    {
        /// <summary>
        /// Represents an invalid #GDateDay.
        /// </summary>
        public const System.Byte BadDay = 0;

        /// <summary>
        /// Represents an invalid Julian day number.
        /// </summary>
        public const System.Int32 BadJulian = 0;

        /// <summary>
        /// Represents an invalid year.
        /// </summary>
        public const System.UInt16 BadYear = 0;

        /// <summary>
        /// Allocates a #GDate and initializes
        /// it to a sane state. The new date will
        /// be cleared (as if you'd called g_date_clear()) but invalid (it won't
        /// represent an existing day). Free the return value with g_date_free().
        /// </summary>
        /// <returns>
        /// a newly-allocated #GDate
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new /* transfer-ownership:full */();

        /// <summary>
        /// Allocates a #GDate and initializes
        /// it to a sane state. The new date will
        /// be cleared (as if you'd called g_date_clear()) but invalid (it won't
        /// represent an existing day). Free the return value with g_date_free().
        /// </summary>
        /// <returns>
        /// a newly-allocated #GDate
        /// </returns>
        public Date()
        {
            Handle = g_date_new();
        }

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// day-month-year triplet you pass in represents an existing day, the
        /// returned date will be valid.
        /// </summary>
        /// <param name="day">
        /// day of the month
        /// </param>
        /// <param name="month">
        /// month of the year
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @day, @month, and @year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new_dmy /* transfer-ownership:full */(
            GISharp.GLib.DateDay day /* transfer-ownership:none */,
            GISharp.GLib.DateMonth month /* transfer-ownership:none */,
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// day-month-year triplet you pass in represents an existing day, the
        /// returned date will be valid.
        /// </summary>
        /// <param name="day">
        /// day of the month
        /// </param>
        /// <param name="month">
        /// month of the year
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @day, @month, and @year
        /// </returns>
        public Date(
            GISharp.GLib.DateDay day,
            GISharp.GLib.DateMonth month,
            GISharp.GLib.DateYear year)
        {
            Handle = g_date_new_dmy(day, month, year);
        }

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// Julian day number you pass in is valid (greater than 0, less than an
        /// unreasonably large number), the returned date will be valid.
        /// </summary>
        /// <param name="julianDay">
        /// days since January 1, Year 1
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @julian_day
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new_julian /* transfer-ownership:full */(
            System.UInt32 julianDay /* transfer-ownership:none */);

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// Julian day number you pass in is valid (greater than 0, less than an
        /// unreasonably large number), the returned date will be valid.
        /// </summary>
        /// <param name="julianDay">
        /// days since January 1, Year 1
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @julian_day
        /// </returns>
        public Date(
            System.UInt32 julianDay)
        {
            Handle = g_date_new_julian(julianDay);
        }

        /// <summary>
        /// Returns the number of days in a month, taking leap
        /// years into account.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// number of days in @month during the @year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_days_in_month /* transfer-ownership:none */(
            GISharp.GLib.DateMonth month /* transfer-ownership:none */,
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns the number of days in a month, taking leap
        /// years into account.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// number of days in @month during the @year
        /// </returns>
        public static System.Byte GetDaysInMonth(
            GISharp.GLib.DateMonth month,
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_days_in_month(month, year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Monday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Mondays are in the year, i.e. there are 53 Mondays if
        /// one of the extra days happens to be a Monday.)
        /// </summary>
        /// <param name="year">
        /// a year
        /// </param>
        /// <returns>
        /// number of Mondays in the year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_monday_weeks_in_year /* transfer-ownership:none */(
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Monday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Mondays are in the year, i.e. there are 53 Mondays if
        /// one of the extra days happens to be a Monday.)
        /// </summary>
        /// <param name="year">
        /// a year
        /// </param>
        /// <returns>
        /// number of Mondays in the year
        /// </returns>
        public static System.Byte GetMondayWeeksInYear(
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_monday_weeks_in_year(year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Sunday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Sundays are in the year, i.e. there are 53 Sundays if
        /// one of the extra days happens to be a Sunday.)
        /// </summary>
        /// <param name="year">
        /// year to count weeks in
        /// </param>
        /// <returns>
        /// the number of weeks in @year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_sunday_weeks_in_year /* transfer-ownership:none */(
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Sunday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Sundays are in the year, i.e. there are 53 Sundays if
        /// one of the extra days happens to be a Sunday.)
        /// </summary>
        /// <param name="year">
        /// year to count weeks in
        /// </param>
        /// <returns>
        /// the number of weeks in @year
        /// </returns>
        public static System.Byte GetSundayWeeksInYear(
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_sunday_weeks_in_year(year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns %TRUE if the year is a leap year.
        /// </summary>
        /// <remarks>
        /// For the purposes of this function, leap year is every year
        /// divisible by 4 unless that year is divisible by 100. If it
        /// is divisible by 100 it would be a leap year only if that year
        /// is also divisible by 400.
        /// </remarks>
        /// <param name="year">
        /// year to check
        /// </param>
        /// <returns>
        /// %TRUE if the year is a leap year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_leap_year /* transfer-ownership:none */(
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the year is a leap year.
        /// </summary>
        /// <remarks>
        /// For the purposes of this function, leap year is every year
        /// divisible by 4 unless that year is divisible by 100. If it
        /// is divisible by 100 it would be a leap year only if that year
        /// is also divisible by 400.
        /// </remarks>
        /// <param name="year">
        /// year to check
        /// </param>
        /// <returns>
        /// %TRUE if the year is a leap year
        /// </returns>
        public static System.Boolean IsLeapYear(
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_is_leap_year(year);
            return default(System.Boolean);
        }

        /// <summary>
        /// Generates a printed representation of the date, in a
        /// [locale][setlocale]-specific way.
        /// Works just like the platform's C library strftime() function,
        /// but only accepts date-related formats; time-related formats
        /// give undefined results. Date must be valid. Unlike strftime()
        /// (which uses the locale encoding), works on a UTF-8 format
        /// string and stores a UTF-8 result.
        /// </summary>
        /// <remarks>
        /// This function does not provide any conversion specifiers in
        /// addition to those implemented by the platform's C library.
        /// For example, don't expect that using g_date_strftime() would
        /// make the \%F provided by the C99 strftime() work on Windows
        /// where the C library only complies to C89.
        /// </remarks>
        /// <param name="s">
        /// destination buffer
        /// </param>
        /// <param name="slen">
        /// buffer size
        /// </param>
        /// <param name="format">
        /// format string
        /// </param>
        /// <param name="date">
        /// valid #GDate
        /// </param>
        /// <returns>
        /// number of characters written to the buffer, or 0 the buffer was too small
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_date_strftime /* transfer-ownership:none */(
            System.IntPtr s /* transfer-ownership:none */,
            System.UInt64 slen /* transfer-ownership:none */,
            System.IntPtr format /* transfer-ownership:none */,
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Generates a printed representation of the date, in a
        /// [locale][setlocale]-specific way.
        /// Works just like the platform's C library strftime() function,
        /// but only accepts date-related formats; time-related formats
        /// give undefined results. Date must be valid. Unlike strftime()
        /// (which uses the locale encoding), works on a UTF-8 format
        /// string and stores a UTF-8 result.
        /// </summary>
        /// <remarks>
        /// This function does not provide any conversion specifiers in
        /// addition to those implemented by the platform's C library.
        /// For example, don't expect that using g_date_strftime() would
        /// make the \%F provided by the C99 strftime() work on Windows
        /// where the C library only complies to C89.
        /// </remarks>
        /// <param name="s">
        /// destination buffer
        /// </param>
        /// <param name="slen">
        /// buffer size
        /// </param>
        /// <param name="format">
        /// format string
        /// </param>
        /// <param name="date">
        /// valid #GDate
        /// </param>
        /// <returns>
        /// number of characters written to the buffer, or 0 the buffer was too small
        /// </returns>
        public static System.UInt64 Strftime(
            System.String s,
            System.UInt64 slen,
            System.String format,
            GISharp.GLib.Date date)
        {
            if (s == null)
            {
                throw new System.ArgumentNullException("s");
            }
            if (format == null)
            {
                throw new System.ArgumentNullException("format");
            }
            if (date == null)
            {
                throw new System.ArgumentNullException("date");
            }
            var sPtr = default(System.IntPtr);
            var formatPtr = default(System.IntPtr);
            var datePtr = default(System.IntPtr);
            var ret = g_date_strftime(sPtr, slen, formatPtr, datePtr);
            return default(System.UInt64);
        }

        /// <summary>
        /// Returns %TRUE if the day of the month is valid (a day is valid if it's
        /// between 1 and 31 inclusive).
        /// </summary>
        /// <param name="day">
        /// day to check
        /// </param>
        /// <returns>
        /// %TRUE if the day is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_day /* transfer-ownership:none */(
            GISharp.GLib.DateDay day /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the day of the month is valid (a day is valid if it's
        /// between 1 and 31 inclusive).
        /// </summary>
        /// <param name="day">
        /// day to check
        /// </param>
        /// <returns>
        /// %TRUE if the day is valid
        /// </returns>
        public static System.Boolean ValidDay(
            GISharp.GLib.DateDay day)
        {
            var ret = g_date_valid_day(day);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the day-month-year triplet forms a valid, existing day
        /// in the range of days #GDate understands (Year 1 or later, no more than
        /// a few thousand years in the future).
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the date is a valid one
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_dmy /* transfer-ownership:none */(
            GISharp.GLib.DateDay day /* transfer-ownership:none */,
            GISharp.GLib.DateMonth month /* transfer-ownership:none */,
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the day-month-year triplet forms a valid, existing day
        /// in the range of days #GDate understands (Year 1 or later, no more than
        /// a few thousand years in the future).
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the date is a valid one
        /// </returns>
        public static System.Boolean ValidDmy(
            GISharp.GLib.DateDay day,
            GISharp.GLib.DateMonth month,
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_valid_dmy(day, month, year);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the Julian day is valid. Anything greater than zero
        /// is basically a valid Julian, though there is a 32-bit limit.
        /// </summary>
        /// <param name="julianDate">
        /// Julian day to check
        /// </param>
        /// <returns>
        /// %TRUE if the Julian day is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_julian /* transfer-ownership:none */(
            System.UInt32 julianDate /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the Julian day is valid. Anything greater than zero
        /// is basically a valid Julian, though there is a 32-bit limit.
        /// </summary>
        /// <param name="julianDate">
        /// Julian day to check
        /// </param>
        /// <returns>
        /// %TRUE if the Julian day is valid
        /// </returns>
        public static System.Boolean ValidJulian(
            System.UInt32 julianDate)
        {
            var ret = g_date_valid_julian(julianDate);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the month value is valid. The 12 #GDateMonth
        /// enumeration values are the only valid months.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <returns>
        /// %TRUE if the month is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_month /* transfer-ownership:none */(
            GISharp.GLib.DateMonth month /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the month value is valid. The 12 #GDateMonth
        /// enumeration values are the only valid months.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <returns>
        /// %TRUE if the month is valid
        /// </returns>
        public static System.Boolean ValidMonth(
            GISharp.GLib.DateMonth month)
        {
            var ret = g_date_valid_month(month);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the weekday is valid. The seven #GDateWeekday enumeration
        /// values are the only valid weekdays.
        /// </summary>
        /// <param name="weekday">
        /// weekday
        /// </param>
        /// <returns>
        /// %TRUE if the weekday is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_weekday /* transfer-ownership:none */(
            GISharp.GLib.DateWeekday weekday /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the weekday is valid. The seven #GDateWeekday enumeration
        /// values are the only valid weekdays.
        /// </summary>
        /// <param name="weekday">
        /// weekday
        /// </param>
        /// <returns>
        /// %TRUE if the weekday is valid
        /// </returns>
        public static System.Boolean ValidWeekday(
            GISharp.GLib.DateWeekday weekday)
        {
            var ret = g_date_valid_weekday(weekday);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the year is valid. Any year greater than 0 is valid,
        /// though there is a 16-bit limit to what #GDate will understand.
        /// </summary>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the year is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_year /* transfer-ownership:none */(
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the year is valid. Any year greater than 0 is valid,
        /// though there is a 16-bit limit to what #GDate will understand.
        /// </summary>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the year is valid
        /// </returns>
        public static System.Boolean ValidYear(
            GISharp.GLib.DateYear year)
        {
            var ret = g_date_valid_year(year);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increments a date some number of days.
        /// To move forward by weeks, add weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nDays">
        /// number of days to move the date forward
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_add_days /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nDays /* transfer-ownership:none */);

        /// <summary>
        /// Increments a date some number of days.
        /// To move forward by weeks, add weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="nDays">
        /// number of days to move the date forward
        /// </param>
        public void AddDays(
            System.UInt32 nDays)
        {
            g_date_add_days(Handle, nDays);
        }

        /// <summary>
        /// Increments a date by some number of months.
        /// If the day of the month is greater than 28,
        /// this routine may change the day of the month
        /// (because the destination month may not have
        /// the current day in it). The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nMonths">
        /// number of months to move forward
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_add_months /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nMonths /* transfer-ownership:none */);

        /// <summary>
        /// Increments a date by some number of months.
        /// If the day of the month is greater than 28,
        /// this routine may change the day of the month
        /// (because the destination month may not have
        /// the current day in it). The date must be valid.
        /// </summary>
        /// <param name="nMonths">
        /// number of months to move forward
        /// </param>
        public void AddMonths(
            System.UInt32 nMonths)
        {
            g_date_add_months(Handle, nMonths);
        }

        /// <summary>
        /// Increments a date by some number of years.
        /// If the date is February 29, and the destination
        /// year is not a leap year, the date will be changed
        /// to February 28. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nYears">
        /// number of years to move forward
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_add_years /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nYears /* transfer-ownership:none */);

        /// <summary>
        /// Increments a date by some number of years.
        /// If the date is February 29, and the destination
        /// year is not a leap year, the date will be changed
        /// to February 28. The date must be valid.
        /// </summary>
        /// <param name="nYears">
        /// number of years to move forward
        /// </param>
        public void AddYears(
            System.UInt32 nYears)
        {
            g_date_add_years(Handle, nYears);
        }

        /// <summary>
        /// If @date is prior to @min_date, sets @date equal to @min_date.
        /// If @date falls after @max_date, sets @date equal to @max_date.
        /// Otherwise, @date is unchanged.
        /// Either of @min_date and @max_date may be %NULL.
        /// All non-%NULL dates must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to clamp
        /// </param>
        /// <param name="minDate">
        /// minimum accepted value for @date
        /// </param>
        /// <param name="maxDate">
        /// maximum accepted value for @date
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_clamp /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.IntPtr minDate /* transfer-ownership:none */,
            System.IntPtr maxDate /* transfer-ownership:none */);

        /// <summary>
        /// If @date is prior to @min_date, sets @date equal to @min_date.
        /// If @date falls after @max_date, sets @date equal to @max_date.
        /// Otherwise, @date is unchanged.
        /// Either of @min_date and @max_date may be %NULL.
        /// All non-%NULL dates must be valid.
        /// </summary>
        /// <param name="minDate">
        /// minimum accepted value for @date
        /// </param>
        /// <param name="maxDate">
        /// maximum accepted value for @date
        /// </param>
        public void Clamp(
            GISharp.GLib.Date minDate,
            GISharp.GLib.Date maxDate)
        {
            if (minDate == null)
            {
                throw new System.ArgumentNullException("minDate");
            }
            if (maxDate == null)
            {
                throw new System.ArgumentNullException("maxDate");
            }
            var minDatePtr = default(System.IntPtr);
            var maxDatePtr = default(System.IntPtr);
            g_date_clamp(Handle, minDatePtr, maxDatePtr);
        }

        /// <summary>
        /// Initializes one or more #GDate structs to a sane but invalid
        /// state. The cleared dates will not represent an existing date, but will
        /// not contain garbage. Useful to init a date declared on the stack.
        /// Validity can be tested with g_date_valid().
        /// </summary>
        /// <param name="date">
        /// pointer to one or more dates to clear
        /// </param>
        /// <param name="nDates">
        /// number of dates to clear
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_clear /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nDates /* transfer-ownership:none */);

        /// <summary>
        /// Initializes one or more #GDate structs to a sane but invalid
        /// state. The cleared dates will not represent an existing date, but will
        /// not contain garbage. Useful to init a date declared on the stack.
        /// Validity can be tested with g_date_valid().
        /// </summary>
        /// <param name="nDates">
        /// number of dates to clear
        /// </param>
        public void Clear(
            System.UInt32 nDates)
        {
            g_date_clear(Handle, nDates);
        }

        /// <summary>
        /// qsort()-style comparison function for dates.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="lhs">
        /// first date to compare
        /// </param>
        /// <param name="rhs">
        /// second date to compare
        /// </param>
        /// <returns>
        /// 0 for equal, less than zero if @lhs is less than @rhs,
        ///     greater than zero if @lhs is greater than @rhs
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_compare /* transfer-ownership:none */(
            System.IntPtr lhs /* transfer-ownership:none */,
            System.IntPtr rhs /* transfer-ownership:none */);

        /// <summary>
        /// qsort()-style comparison function for dates.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="rhs">
        /// second date to compare
        /// </param>
        /// <returns>
        /// 0 for equal, less than zero if @lhs is less than @rhs,
        ///     greater than zero if @lhs is greater than @rhs
        /// </returns>
        public System.Int32 CompareTo(
            GISharp.GLib.Date rhs)
        {
            if (rhs == null)
            {
                throw new System.ArgumentNullException("rhs");
            }
            var rhsPtr = default(System.IntPtr);
            var ret = g_date_compare(Handle, rhsPtr);
            return default(System.Int32);
        }

        public static bool operator >=(Date one, Date two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Date one, Date two)
        {
            return one.CompareTo(two) > 0;
        }

        public static bool operator <(Date one, Date two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Date one, Date two)
        {
            return one.CompareTo(two) <= 0;
        }

        /// <summary>
        /// Computes the number of days between two dates.
        /// If @date2 is prior to @date1, the returned value is negative.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="date1">
        /// the first date
        /// </param>
        /// <param name="date2">
        /// the second date
        /// </param>
        /// <returns>
        /// the number of days between @date1 and @date2
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_days_between /* transfer-ownership:none */(
            System.IntPtr date1 /* transfer-ownership:none */,
            System.IntPtr date2 /* transfer-ownership:none */);

        /// <summary>
        /// Computes the number of days between two dates.
        /// If @date2 is prior to @date1, the returned value is negative.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="date2">
        /// the second date
        /// </param>
        /// <returns>
        /// the number of days between @date1 and @date2
        /// </returns>
        public System.Int32 DaysBetween(
            GISharp.GLib.Date date2)
        {
            if (date2 == null)
            {
                throw new System.ArgumentNullException("date2");
            }
            var date2Ptr = default(System.IntPtr);
            var ret = g_date_days_between(Handle, date2Ptr);
            return default(System.Int32);
        }

        /// <summary>
        /// Frees a #GDate returned from g_date_new().
        /// </summary>
        /// <param name="date">
        /// a #GDate to free
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_free /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Frees a #GDate returned from g_date_new().
        /// </summary>
        protected override void Free()
        {
            g_date_free(Handle);
        }

        /// <summary>
        /// Returns the day of the month. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract the day of the month from
        /// </param>
        /// <returns>
        /// day of the month
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.DateDay g_date_get_day /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the day of the month. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the month
        /// </returns>
        public GISharp.GLib.DateDay Day
        {
            get
            {
                var ret = g_date_get_day(Handle);
                return default(GISharp.GLib.DateDay);
            }

            set
            {
                g_date_set_day(Handle, value);
            }
        }

        /// <summary>
        /// Returns the day of the year, where Jan 1 is the first day of the
        /// year. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract day of year from
        /// </param>
        /// <returns>
        /// day of the year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_day_of_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the day of the year, where Jan 1 is the first day of the
        /// year. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the year
        /// </returns>
        public System.UInt32 DayOfYear
        {
            get
            {
                var ret = g_date_get_day_of_year(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Returns the week of the year, where weeks are interpreted according
        /// to ISO 8601.
        /// </summary>
        /// <param name="date">
        /// a valid #GDate
        /// </param>
        /// <returns>
        /// ISO 8601 week number of the year.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_iso8601_week_of_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the week of the year, where weeks are interpreted according
        /// to ISO 8601.
        /// </summary>
        /// <returns>
        /// ISO 8601 week number of the year.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.UInt32 Iso8601WeekOfYear
        {
            get
            {
                var ret = g_date_get_iso8601_week_of_year(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Returns the Julian day or "serial number" of the #GDate. The
        /// Julian day is simply the number of days since January 1, Year 1; i.e.,
        /// January 1, Year 1 is Julian day 1; January 2, Year 1 is Julian day 2,
        /// etc. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract the Julian day from
        /// </param>
        /// <returns>
        /// Julian day
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_julian /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the Julian day or "serial number" of the #GDate. The
        /// Julian day is simply the number of days since January 1, Year 1; i.e.,
        /// January 1, Year 1 is Julian day 1; January 2, Year 1 is Julian day 2,
        /// etc. The date must be valid.
        /// </summary>
        /// <returns>
        /// Julian day
        /// </returns>
        public System.UInt32 Julian
        {
            get
            {
                var ret = g_date_get_julian(Handle);
                return default(System.UInt32);
            }

            set
            {
                g_date_set_julian(Handle, value);
            }
        }

        /// <summary>
        /// Returns the week of the year, where weeks are understood to start on
        /// Monday. If the date is before the first Monday of the year, return
        /// 0. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// week of the year
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_monday_week_of_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the week of the year, where weeks are understood to start on
        /// Monday. If the date is before the first Monday of the year, return
        /// 0. The date must be valid.
        /// </summary>
        /// <returns>
        /// week of the year
        /// </returns>
        public System.UInt32 MondayWeekOfYear
        {
            get
            {
                var ret = g_date_get_monday_week_of_year(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Returns the month of the year. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to get the month from
        /// </param>
        /// <returns>
        /// month of the year as a #GDateMonth
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.DateMonth g_date_get_month /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the month of the year. The date must be valid.
        /// </summary>
        /// <returns>
        /// month of the year as a #GDateMonth
        /// </returns>
        public GISharp.GLib.DateMonth Month
        {
            get
            {
                var ret = g_date_get_month(Handle);
                return default(GISharp.GLib.DateMonth);
            }

            set
            {
                g_date_set_month(Handle, value);
            }
        }

        /// <summary>
        /// Returns the week of the year during which this date falls, if weeks
        /// are understood to being on Sunday. The date must be valid. Can return
        /// 0 if the day is before the first Sunday of the year.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// week number
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_sunday_week_of_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the week of the year during which this date falls, if weeks
        /// are understood to being on Sunday. The date must be valid. Can return
        /// 0 if the day is before the first Sunday of the year.
        /// </summary>
        /// <returns>
        /// week number
        /// </returns>
        public System.UInt32 SundayWeekOfYear
        {
            get
            {
                var ret = g_date_get_sunday_week_of_year(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Returns the day of the week for a #GDate. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// day of the week as a #GDateWeekday.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.DateWeekday g_date_get_weekday /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the day of the week for a #GDate. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the week as a #GDateWeekday.
        /// </returns>
        public GISharp.GLib.DateWeekday Weekday
        {
            get
            {
                var ret = g_date_get_weekday(Handle);
                return default(GISharp.GLib.DateWeekday);
            }
        }

        /// <summary>
        /// Returns the year of a #GDate. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// year in which the date falls
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.DateYear g_date_get_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns the year of a #GDate. The date must be valid.
        /// </summary>
        /// <returns>
        /// year in which the date falls
        /// </returns>
        public GISharp.GLib.DateYear Year
        {
            get
            {
                var ret = g_date_get_year(Handle);
                return default(GISharp.GLib.DateYear);
            }

            set
            {
                g_date_set_year(Handle, value);
            }
        }

        /// <summary>
        /// Returns %TRUE if the date is on the first of a month.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// %TRUE if the date is the first of the month
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_first_of_month /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the date is on the first of a month.
        /// The date must be valid.
        /// </summary>
        /// <returns>
        /// %TRUE if the date is the first of the month
        /// </returns>
        public System.Boolean IsFirstOfMonth
        {
            get
            {
                var ret = g_date_is_first_of_month(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Returns %TRUE if the date is the last day of the month.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// %TRUE if the date is the last day of the month
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_last_of_month /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the date is the last day of the month.
        /// The date must be valid.
        /// </summary>
        /// <returns>
        /// %TRUE if the date is the last day of the month
        /// </returns>
        public System.Boolean IsLastOfMonth
        {
            get
            {
                var ret = g_date_is_last_of_month(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Checks if @date1 is less than or equal to @date2,
        /// and swap the values if this is not the case.
        /// </summary>
        /// <param name="date1">
        /// the first date
        /// </param>
        /// <param name="date2">
        /// the second date
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_order /* transfer-ownership:none */(
            System.IntPtr date1 /* transfer-ownership:none */,
            System.IntPtr date2 /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @date1 is less than or equal to @date2,
        /// and swap the values if this is not the case.
        /// </summary>
        /// <param name="date2">
        /// the second date
        /// </param>
        public void Order(
            GISharp.GLib.Date date2)
        {
            if (date2 == null)
            {
                throw new System.ArgumentNullException("date2");
            }
            var date2Ptr = default(System.IntPtr);
            g_date_order(Handle, date2Ptr);
        }

        /// <summary>
        /// Sets the day of the month for a #GDate. If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="day">
        /// day to set
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_day /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            GISharp.GLib.DateDay day /* transfer-ownership:none */);

        /// <summary>
        /// Sets the value of a #GDate from a day, month, and year.
        /// The day-month-year triplet must be valid; if you aren't
        /// sure it is, call g_date_valid_dmy() to check before you
        /// set it.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="y">
        /// year
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_dmy /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            GISharp.GLib.DateDay day /* transfer-ownership:none */,
            GISharp.GLib.DateMonth month /* transfer-ownership:none */,
            GISharp.GLib.DateYear y /* transfer-ownership:none */);

        /// <summary>
        /// Sets the value of a #GDate from a day, month, and year.
        /// The day-month-year triplet must be valid; if you aren't
        /// sure it is, call g_date_valid_dmy() to check before you
        /// set it.
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="y">
        /// year
        /// </param>
        public void SetDmy(
            GISharp.GLib.DateDay day,
            GISharp.GLib.DateMonth month,
            GISharp.GLib.DateYear y)
        {
            g_date_set_dmy(Handle, day, month, y);
        }

        /// <summary>
        /// Sets the value of a #GDate from a Julian day number.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="julianDate">
        /// Julian day number (days since January 1, Year 1)
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_julian /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 julianDate /* transfer-ownership:none */);

        /// <summary>
        /// Sets the month of the year for a #GDate.  If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="month">
        /// month to set
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_month /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            GISharp.GLib.DateMonth month /* transfer-ownership:none */);

        /// <summary>
        /// Parses a user-inputted string @str, and try to figure out what date it
        /// represents, taking the [current locale][setlocale] into account. If the
        /// string is successfully parsed, the date will be valid after the call.
        /// Otherwise, it will be invalid. You should check using g_date_valid()
        /// to see whether the parsing succeeded.
        /// </summary>
        /// <remarks>
        /// This function is not appropriate for file formats and the like; it
        /// isn't very precise, and its exact behavior varies with the locale.
        /// It's intended to be a heuristic routine that guesses what the user
        /// means by a given string (and it does work pretty well in that
        /// capacity).
        /// </remarks>
        /// <param name="date">
        /// a #GDate to fill in
        /// </param>
        /// <param name="str">
        /// string to parse
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_parse /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.IntPtr str /* transfer-ownership:none */);

        /// <summary>
        /// Parses a user-inputted string @str, and try to figure out what date it
        /// represents, taking the [current locale][setlocale] into account. If the
        /// string is successfully parsed, the date will be valid after the call.
        /// Otherwise, it will be invalid. You should check using g_date_valid()
        /// to see whether the parsing succeeded.
        /// </summary>
        /// <remarks>
        /// This function is not appropriate for file formats and the like; it
        /// isn't very precise, and its exact behavior varies with the locale.
        /// It's intended to be a heuristic routine that guesses what the user
        /// means by a given string (and it does work pretty well in that
        /// capacity).
        /// </remarks>
        /// <param name="str">
        /// string to parse
        /// </param>
        public void SetParse(
            System.String str)
        {
            if (str == null)
            {
                throw new System.ArgumentNullException("str");
            }
            var strPtr = default(System.IntPtr);
            g_date_set_parse(Handle, strPtr);
        }

        /// <summary>
        /// Sets the year for a #GDate. If the resulting day-month-year
        /// triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="year">
        /// year to set
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_set_year /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            GISharp.GLib.DateYear year /* transfer-ownership:none */);

        /// <summary>
        /// Moves a date some number of days into the past.
        /// To move by weeks, just move by weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nDays">
        /// number of days to move
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_subtract_days /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nDays /* transfer-ownership:none */);

        /// <summary>
        /// Moves a date some number of days into the past.
        /// To move by weeks, just move by weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="nDays">
        /// number of days to move
        /// </param>
        public void SubtractDays(
            System.UInt32 nDays)
        {
            g_date_subtract_days(Handle, nDays);
        }

        /// <summary>
        /// Moves a date some number of months into the past.
        /// If the current day of the month doesn't exist in
        /// the destination month, the day of the month
        /// may change. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nMonths">
        /// number of months to move
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_subtract_months /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nMonths /* transfer-ownership:none */);

        /// <summary>
        /// Moves a date some number of months into the past.
        /// If the current day of the month doesn't exist in
        /// the destination month, the day of the month
        /// may change. The date must be valid.
        /// </summary>
        /// <param name="nMonths">
        /// number of months to move
        /// </param>
        public void SubtractMonths(
            System.UInt32 nMonths)
        {
            g_date_subtract_months(Handle, nMonths);
        }

        /// <summary>
        /// Moves a date some number of years into the past.
        /// If the current day doesn't exist in the destination
        /// year (i.e. it's February 29 and you move to a non-leap-year)
        /// then the day is changed to February 29. The date
        /// must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nYears">
        /// number of years to move
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_subtract_years /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.UInt32 nYears /* transfer-ownership:none */);

        /// <summary>
        /// Moves a date some number of years into the past.
        /// If the current day doesn't exist in the destination
        /// year (i.e. it's February 29 and you move to a non-leap-year)
        /// then the day is changed to February 29. The date
        /// must be valid.
        /// </summary>
        /// <param name="nYears">
        /// number of years to move
        /// </param>
        public void SubtractYears(
            System.UInt32 nYears)
        {
            g_date_subtract_years(Handle, nYears);
        }

        /// <summary>
        /// Fills in the date-related bits of a struct tm using the @date value.
        /// Initializes the non-date parts with something sane but meaningless.
        /// </summary>
        /// <param name="date">
        /// a #GDate to set the struct tm from
        /// </param>
        /// <param name="tm">
        /// struct tm to fill
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_to_struct_tm /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */,
            System.IntPtr tm /* transfer-ownership:none */);

        /// <summary>
        /// Fills in the date-related bits of a struct tm using the @date value.
        /// Initializes the non-date parts with something sane but meaningless.
        /// </summary>
        /// <param name="tm">
        /// struct tm to fill
        /// </param>
        public void ToStructTm(
            System.IntPtr tm)
        {
            g_date_to_struct_tm(Handle, tm);
        }

        /// <summary>
        /// Returns %TRUE if the #GDate represents an existing day. The date must not
        /// contain garbage; it should have been initialized with g_date_clear()
        /// if it wasn't allocated by one of the g_date_new() variants.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// Whether the date is valid
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid /* transfer-ownership:none */(
            System.IntPtr date /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if the #GDate represents an existing day. The date must not
        /// contain garbage; it should have been initialized with g_date_clear()
        /// if it wasn't allocated by one of the g_date_new() variants.
        /// </summary>
        /// <returns>
        /// Whether the date is valid
        /// </returns>
        public System.Boolean Valid()
        {
            var ret = g_date_valid(Handle);
            return default(System.Boolean);
        }
    }

    /// <summary>
    /// This enumeration isn't used in the API, but may be useful if you need
    /// to mark a number as a day, month, or year.
    /// </summary>
    public enum DateDMY
    {
        /// <summary>
        /// a day
        /// </summary>
        Day = 0,
        /// <summary>
        /// a month
        /// </summary>
        Month = 1,
        /// <summary>
        /// a year
        /// </summary>
        Year = 2
    }

    /// <summary>
    /// Enumeration representing a month; values are #G_DATE_JANUARY,
    /// #G_DATE_FEBRUARY, etc. #G_DATE_BAD_MONTH is the invalid value.
    /// </summary>
    public enum DateMonth
    {
        /// <summary>
        /// invalid value
        /// </summary>
        BadMonth = 0,
        /// <summary>
        /// January
        /// </summary>
        January = 1,
        /// <summary>
        /// February
        /// </summary>
        February = 2,
        /// <summary>
        /// March
        /// </summary>
        March = 3,
        /// <summary>
        /// April
        /// </summary>
        April = 4,
        /// <summary>
        /// May
        /// </summary>
        May = 5,
        /// <summary>
        /// June
        /// </summary>
        June = 6,
        /// <summary>
        /// July
        /// </summary>
        July = 7,
        /// <summary>
        /// August
        /// </summary>
        August = 8,
        /// <summary>
        /// September
        /// </summary>
        September = 9,
        /// <summary>
        /// October
        /// </summary>
        October = 10,
        /// <summary>
        /// November
        /// </summary>
        November = 11,
        /// <summary>
        /// December
        /// </summary>
        December = 12
    }

    /// <summary>
    /// `GDateTime` is an opaque structure whose members
    /// cannot be accessed directly.
    /// </summary>
    [GISharp.Core.SinceAttribute("2.26")]
    public partial class DateTime : GISharp.Core.ReferenceCountedOpaque<DateTime>
    {
        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The @year must be between 1 and 9999, @month between 1 and 12 and @day
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// @hour must be between 0 and 23 and @minute must be between 0 and 59.
        /// 
        /// @seconds must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return %NULL.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new /* transfer-ownership:full */(
            System.IntPtr tz /* transfer-ownership:none */,
            System.Int32 year /* transfer-ownership:none */,
            System.Int32 month /* transfer-ownership:none */,
            System.Int32 day /* transfer-ownership:none */,
            System.Int32 hour /* transfer-ownership:none */,
            System.Int32 minute /* transfer-ownership:none */,
            System.Double seconds /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The @year must be between 1 and 9999, @month between 1 and 12 and @day
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// @hour must be between 0 and 23 and @minute must be between 0 and 59.
        /// 
        /// @seconds must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return %NULL.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public DateTime(
            GISharp.GLib.TimeZone tz,
            System.Int32 year,
            System.Int32 month,
            System.Int32 day,
            System.Int32 hour,
            System.Int32 minute,
            System.Double seconds)
        {
            if (tz == null)
            {
                throw new System.ArgumentNullException("tz");
            }
            var tzPtr = default(System.IntPtr);
            Handle = g_date_time_new(tzPtr, year, month, day, hour, minute, seconds);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_unix_local /* transfer-ownership:full */(
            System.Int64 t /* transfer-ownership:none */);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime FromUnixLocal(
            System.Int64 t)
        {
            var retPtr = g_date_time_new_from_unix_local(t);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_unix_utc /* transfer-ownership:full */(
            System.Int64 t /* transfer-ownership:none */);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime FromUnixUtc(
            System.Int64 t)
        {
            var retPtr = g_date_time_new_from_unix_utc(t);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_local /* transfer-ownership:full */(
            System.Int32 year /* transfer-ownership:none */,
            System.Int32 month /* transfer-ownership:none */,
            System.Int32 day /* transfer-ownership:none */,
            System.Int32 hour /* transfer-ownership:none */,
            System.Int32 minute /* transfer-ownership:none */,
            System.Double seconds /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime Local(
            System.Int32 year,
            System.Int32 month,
            System.Int32 day,
            System.Int32 hour,
            System.Int32 minute,
            System.Double seconds)
        {
            var retPtr = g_date_time_new_local(year, month, day, hour, minute, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the given
        /// time zone @tz.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now /* transfer-ownership:full */(
            System.IntPtr tz /* transfer-ownership:none */);

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the given
        /// time zone @tz.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime Now(
            GISharp.GLib.TimeZone tz)
        {
            if (tz == null)
            {
                throw new System.ArgumentNullException("tz");
            }
            var tzPtr = default(System.IntPtr);
            var retPtr = g_date_time_new_now(tzPtr);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now_local /* transfer-ownership:full */();

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime NowLocal()
        {
            var retPtr = g_date_time_new_now_local();
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now_utc /* transfer-ownership:full */();

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime NowUtc()
        {
            var retPtr = g_date_time_new_now_utc();
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_utc /* transfer-ownership:full */(
            System.Int32 year /* transfer-ownership:none */,
            System.Int32 month /* transfer-ownership:none */,
            System.Int32 day /* transfer-ownership:none */,
            System.Int32 hour /* transfer-ownership:none */,
            System.Int32 minute /* transfer-ownership:none */,
            System.Double seconds /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.DateTime Utc(
            System.Int32 year,
            System.Int32 month,
            System.Int32 day,
            System.Int32 hour,
            System.Int32 minute,
            System.Double seconds)
        {
            var retPtr = g_date_time_new_utc(year, month, day, hour, minute, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-%NULL.
        /// </summary>
        /// <param name="dt1">
        /// first #GDateTime to compare
        /// </param>
        /// <param name="dt2">
        /// second #GDateTime to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if @dt1 is less than, equal to or greater
        ///   than @dt2.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_compare /* transfer-ownership:none */(
            System.IntPtr dt1 /* transfer-ownership:none */,
            System.IntPtr dt2 /* transfer-ownership:none */);

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-%NULL.
        /// </summary>
        /// <param name="dt1">
        /// first #GDateTime to compare
        /// </param>
        /// <param name="dt2">
        /// second #GDateTime to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if @dt1 is less than, equal to or greater
        ///   than @dt2.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static System.Int32 Compare(
            System.IntPtr dt1,
            System.IntPtr dt2)
        {
            var ret = g_date_time_compare(dt1, dt2);
            return default(System.Int32);
        }

        /// <summary>
        /// Checks to see if @dt1 and @dt2 are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt1">
        /// a #GDateTime
        /// </param>
        /// <param name="dt2">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if @dt1 and @dt2 are equal
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_time_equal /* transfer-ownership:none */(
            System.IntPtr dt1 /* transfer-ownership:none */,
            System.IntPtr dt2 /* transfer-ownership:none */);

        /// <summary>
        /// Checks to see if @dt1 and @dt2 are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt1">
        /// a #GDateTime
        /// </param>
        /// <param name="dt2">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if @dt1 and @dt2 are equal
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static System.Boolean Equal(
            System.IntPtr dt1,
            System.IntPtr dt2)
        {
            var ret = g_date_time_equal(dt1, dt2);
            return default(System.Boolean);
        }

        /// <summary>
        /// Hashes @datetime into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_time_hash /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Hashes @datetime into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static System.UInt32 Hash(
            System.IntPtr datetime)
        {
            var ret = g_date_time_hash(datetime);
            return default(System.UInt32);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="timespan">
        /// a #GTimeSpan
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            GISharp.GLib.TimeSpan timespan /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="timespan">
        /// a #GTimeSpan
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime Add(
            GISharp.GLib.TimeSpan timespan)
        {
            var retPtr = g_date_time_add(Handle, timespan);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_days /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 days /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddDays(
            System.Int32 days)
        {
            var retPtr = g_date_time_add_days(Handle, days);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime adding the specified values to the current date and
        /// time in @datetime. Add negative values to subtract.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime that should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_full /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 years /* transfer-ownership:none */,
            System.Int32 months /* transfer-ownership:none */,
            System.Int32 days /* transfer-ownership:none */,
            System.Int32 hours /* transfer-ownership:none */,
            System.Int32 minutes /* transfer-ownership:none */,
            System.Double seconds /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime adding the specified values to the current date and
        /// time in @datetime. Add negative values to subtract.
        /// </summary>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime that should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddFull(
            System.Int32 years,
            System.Int32 months,
            System.Int32 days,
            System.Int32 hours,
            System.Int32 minutes,
            System.Double seconds)
        {
            var retPtr = g_date_time_add_full(Handle, years, months, days, hours, minutes, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_hours /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 hours /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddHours(
            System.Int32 hours)
        {
            var retPtr = g_date_time_add_hours(Handle, hours);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_minutes /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 minutes /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddMinutes(
            System.Int32 minutes)
        {
            var retPtr = g_date_time_add_minutes(Handle, minutes);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_months /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 months /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddMonths(
            System.Int32 months)
        {
            var retPtr = g_date_time_add_months(Handle, months);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_seconds /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Double seconds /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddSeconds(
            System.Double seconds)
        {
            var retPtr = g_date_time_add_seconds(Handle, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_weeks /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 weeks /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddWeeks(
            System.Int32 weeks)
        {
            var retPtr = g_date_time_add_weeks(Handle, weeks);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_years /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.Int32 years /* transfer-ownership:none */);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime AddYears(
            System.Int32 years)
        {
            var retPtr = g_date_time_add_years(Handle, years);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Calculates the difference in time between @end and @begin.  The
        /// #GTimeSpan that is returned is effectively @end - @begin (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="end">
        /// a #GDateTime
        /// </param>
        /// <param name="begin">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the difference between the two #GDateTime, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.TimeSpan g_date_time_difference /* transfer-ownership:none */(
            System.IntPtr end /* transfer-ownership:none */,
            System.IntPtr begin /* transfer-ownership:none */);

        /// <summary>
        /// Calculates the difference in time between @end and @begin.  The
        /// #GTimeSpan that is returned is effectively @end - @begin (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="begin">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the difference between the two #GDateTime, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.TimeSpan Difference(
            GISharp.GLib.DateTime begin)
        {
            if (begin == null)
            {
                throw new System.ArgumentNullException("begin");
            }
            var beginPtr = default(System.IntPtr);
            var ret = g_date_time_difference(Handle, beginPtr);
            return default(GISharp.GLib.TimeSpan);
        }

        /// <summary>
        /// Creates a newly allocated string representing the requested @format.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the  preferred date and time rpresentation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See g_date_time_get_week_of_year().
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// </remarks>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          #GDateTime
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or %NULL in the case that there was an error. The string
        ///     should be freed with g_free().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_format /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.IntPtr format /* transfer-ownership:none */);

        /// <summary>
        /// Creates a newly allocated string representing the requested @format.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the  preferred date and time rpresentation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See g_date_time_get_week_of_year().
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// </remarks>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          #GDateTime
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or %NULL in the case that there was an error. The string
        ///     should be freed with g_free().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.String Format(
            System.String format)
        {
            if (format == null)
            {
                throw new System.ArgumentNullException("format");
            }
            var formatPtr = default(System.IntPtr);
            var retPtr = g_date_time_format(Handle, formatPtr);
            return default(System.String);
        }

        /// <summary>
        /// Retrieves the day of the month represented by @datetime in the gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the month
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_month /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the day of the month represented by @datetime in the gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the month
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 DayOfMonth
        {
            get
            {
                var ret = g_date_time_get_day_of_month(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which @datetime falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the week
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_week /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which @datetime falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <returns>
        /// the day of the week
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 DayOfWeek
        {
            get
            {
                var ret = g_date_time_get_day_of_week(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the day of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the year
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_year /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the day of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the year
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 DayOfYear
        {
            get
            {
                var ret = g_date_time_get_day_of_year(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the hour of the day represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_hour /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the hour of the day represented by @datetime
        /// </summary>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Hour
        {
            get
            {
                var ret = g_date_time_get_hour(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the microsecond of the date represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_microsecond /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the microsecond of the date represented by @datetime
        /// </summary>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Microsecond
        {
            get
            {
                var ret = g_date_time_get_microsecond(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the minute of the hour represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_minute /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the minute of the hour represented by @datetime
        /// </summary>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Minute
        {
            get
            {
                var ret = g_date_time_get_minute(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the month of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the month represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_month /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the month of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the month represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Month
        {
            get
            {
                var ret = g_date_time_get_month(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the second of the minute represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the second represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_second /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the second of the minute represented by @datetime
        /// </summary>
        /// <returns>
        /// the second represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Second
        {
            get
            {
                var ret = g_date_time_get_second(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Double g_date_time_get_seconds /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Double Seconds
        {
            get
            {
                var ret = g_date_time_get_seconds(Handle);
                return default(System.Double);
            }
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the #GDateTime and it should not be
        ///          modified or freed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_get_timezone_abbreviation /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the #GDateTime and it should not be
        ///          modified or freed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.String TimezoneAbbreviation
        {
            get
            {
                var retPtr = g_date_time_get_timezone_abbreviation(Handle);
                return default(System.String);
            }
        }

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of @datetime.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If @datetime represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.TimeSpan g_date_time_get_utc_offset /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of @datetime.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If @datetime represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.TimeSpan UtcOffset
        {
            get
            {
                var ret = g_date_time_get_utc_offset(Handle);
                return default(GISharp.GLib.TimeSpan);
            }
        }

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// @datetime falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with g_date_time_get_week_of_year() and
        /// g_date_time_get_day_of_week() can be used to determine the full ISO
        /// week date on which @datetime falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// g_date_time_get_year()), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturaday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week-numbering year for @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_week_numbering_year /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// @datetime falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with g_date_time_get_week_of_year() and
        /// g_date_time_get_day_of_week() can be used to determine the full ISO
        /// week date on which @datetime falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// g_date_time_get_year()), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturaday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week-numbering year for @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 WeekNumberingYear
        {
            get
            {
                var ret = g_date_time_get_week_numbering_year(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing @datetime.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week number for @datetime.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_week_of_year /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing @datetime.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week number for @datetime.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 WeekOfYear
        {
            get
            {
                var ret = g_date_time_get_week_of_year(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the year represented by @datetime in the Gregorian calendar.
        /// </summary>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <returns>
        /// the year represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_year /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Retrieves the year represented by @datetime in the Gregorian calendar.
        /// </summary>
        /// <returns>
        /// the year represented by @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 Year
        {
            get
            {
                var ret = g_date_time_get_year(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given #GDateTime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime.
        /// </param>
        /// <param name="year">
        /// the return location for the gregorian year, or %NULL.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or %NULL.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or %NULL.
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_time_get_ymd /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */,
            out System.Int32 year /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.Int32 month /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.Int32 day /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given #GDateTime.
        /// </summary>
        /// <param name="year">
        /// the return location for the gregorian year, or %NULL.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or %NULL.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or %NULL.
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        public void GetYmd(
            out System.Int32 year,
            out System.Int32 month,
            out System.Int32 day)
        {
            g_date_time_get_ymd(Handle,out year,out month,out day);
            year = default(System.Int32); month = default(System.Int32); day = default(System.Int32);
        }

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_date_time_is_daylight_savings /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Boolean IsDaylightSavings
        {
            get
            {
                var ret = g_date_time_is_daylight_savings(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Atomically increments the reference count of @datetime by one.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the #GDateTime with the reference count increased
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Atomically increments the reference count of @datetime by one.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        protected override void Ref()
        {
            g_date_time_ref(Handle);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_local /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime ToLocal()
        {
            var retPtr = g_date_time_to_local(Handle);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Create a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="tz">
        /// the new #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_timezone /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */,
            System.IntPtr tz /* transfer-ownership:none */);

        /// <summary>
        /// Create a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// the new #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime ToTimezone(
            GISharp.GLib.TimeZone tz)
        {
            if (tz == null)
            {
                throw new System.ArgumentNullException("tz");
            }
            var tzPtr = default(System.IntPtr);
            var retPtr = g_date_time_to_timezone(Handle, tzPtr);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Gives the Unix time corresponding to @datetime, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with @datetime.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the Unix time corresponding to @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int64 g_date_time_to_unix /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Gives the Unix time corresponding to @datetime, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with @datetime.
        /// </remarks>
        /// <returns>
        /// the Unix time corresponding to @datetime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int64 ToUnix()
        {
            var ret = g_date_time_to_unix(Handle);
            return default(System.Int64);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_utc /* transfer-ownership:full */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public GISharp.GLib.DateTime ToUtc()
        {
            var retPtr = g_date_time_to_utc(Handle);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Atomically decrements the reference count of @datetime by one.
        /// </summary>
        /// <remarks>
        /// When the reference count reaches zero, the resources allocated by
        /// @datetime are freed
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_date_time_unref /* transfer-ownership:none */(
            System.IntPtr datetime /* transfer-ownership:none */);

        /// <summary>
        /// Atomically decrements the reference count of @datetime by one.
        /// </summary>
        /// <remarks>
        /// When the reference count reaches zero, the resources allocated by
        /// @datetime are freed
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.26")]
        protected override void Unref()
        {
            g_date_time_unref(Handle);
        }
    }

    /// <summary>
    /// Enumeration representing a day of the week; #G_DATE_MONDAY,
    /// #G_DATE_TUESDAY, etc. #G_DATE_BAD_WEEKDAY is an invalid weekday.
    /// </summary>
    public enum DateWeekday
    {
        /// <summary>
        /// invalid value
        /// </summary>
        BadWeekday = 0,
        /// <summary>
        /// Monday
        /// </summary>
        Monday = 1,
        /// <summary>
        /// Tuesday
        /// </summary>
        Tuesday = 2,
        /// <summary>
        /// Wednesday
        /// </summary>
        Wednesday = 3,
        /// <summary>
        /// Thursday
        /// </summary>
        Thursday = 4,
        /// <summary>
        /// Friday
        /// </summary>
        Friday = 5,
        /// <summary>
        /// Saturday
        /// </summary>
        Saturday = 6,
        /// <summary>
        /// Sunday
        /// </summary>
        Sunday = 7
    }

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void DestroyNotify(
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    public delegate void DestroyNotifyCallback(
        System.IntPtr data);

    /// <summary>
    /// The type of functions that are used to 'duplicate' an object.
    /// What this means depends on the context, it could just be
    /// incrementing the reference count, if @data is a ref-counted
    /// object.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.IntPtr DuplicateFunc(
        System.IntPtr data /* transfer-ownership:none */,
        System.IntPtr userData /* transfer-ownership:none closure:1 */);

    /// <summary>
    /// The type of functions that are used to 'duplicate' an object.
    /// What this means depends on the context, it could just be
    /// incrementing the reference count, if @data is a ref-counted
    /// object.
    /// </summary>
    public delegate System.IntPtr DuplicateFuncCallback(
        System.IntPtr data);

    /// <summary>
    /// The `GError` structure contains information about
    /// an error that has occurred.
    /// </summary>
    public partial class Error : GISharp.Core.OwnedOpaque<Error>
    {
        /// <summary>
        /// Creates a new #GError; unlike g_error_new(), @message is
        /// not a printf()-style format string. Use this function if
        /// @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_new_literal /* transfer-ownership:full */(
            GISharp.GLib.Quark domain /* transfer-ownership:none */,
            System.Int32 code /* transfer-ownership:none */,
            System.IntPtr message /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GError; unlike g_error_new(), @message is
        /// not a printf()-style format string. Use this function if
        /// @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        public Error(
            GISharp.GLib.Quark domain,
            System.Int32 code,
            System.String message)
        {
            if (message == null)
            {
                throw new System.ArgumentNullException("message");
            }
            var messagePtr = default(System.IntPtr);
            Handle = g_error_new_literal(domain, code, messagePtr);
        }

        /// <summary>
        /// Creates a new #GError with the given @domain and @code,
        /// and a message formatted with @format.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="format">
        /// printf()-style format for error message
        /// </param>
        /// <param name="args">
        /// #va_list of parameters for the message format
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [GISharp.Core.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_new_valist /* transfer-ownership:full */(
            GISharp.GLib.Quark domain /* transfer-ownership:none */,
            System.Int32 code /* transfer-ownership:none */,
            System.IntPtr format /* transfer-ownership:none */,
            System.IntPtr args /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GError with the given @domain and @code,
        /// and a message formatted with @format.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="format">
        /// printf()-style format for error message
        /// </param>
        /// <param name="args">
        /// #va_list of parameters for the message format
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [GISharp.Core.SinceAttribute("2.22")]
        public Error(
            GISharp.GLib.Quark domain,
            System.Int32 code,
            System.String format,
            System.Object[] args)
        {
            if (format == null)
            {
                throw new System.ArgumentNullException("format");
            }
            if (args == null)
            {
                throw new System.ArgumentNullException("args");
            }
            var formatPtr = default(System.IntPtr);
            var argsPtr = default(System.IntPtr);
            Handle = g_error_new_valist(domain, code, formatPtr, argsPtr);
        }

        /// <summary>
        /// Does nothing if @err is %NULL; if @err is non-%NULL, then *@err
        /// must be %NULL. A new #GError is created and assigned to *@err.
        /// Unlike g_set_error(), @message is not a printf()-style format string.
        /// Use this function if @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="err">
        /// a return location for a #GError, or %NULL
        /// </param>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        [GISharp.Core.SinceAttribute("2.18")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_set_error_literal /* transfer-ownership:none */(
            System.IntPtr err /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.Quark domain /* transfer-ownership:none */,
            System.Int32 code /* transfer-ownership:none */,
            System.IntPtr message /* transfer-ownership:none */);

        /// <summary>
        /// Does nothing if @err is %NULL; if @err is non-%NULL, then *@err
        /// must be %NULL. A new #GError is created and assigned to *@err.
        /// Unlike g_set_error(), @message is not a printf()-style format string.
        /// Use this function if @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="err">
        /// a return location for a #GError, or %NULL
        /// </param>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        [GISharp.Core.SinceAttribute("2.18")]
        public static void SetErrorLiteral(
            GISharp.GLib.Error err,
            GISharp.GLib.Quark domain,
            System.Int32 code,
            System.String message)
        {
            if (message == null)
            {
                throw new System.ArgumentNullException("message");
            }
            var errPtr = default(System.IntPtr);
            var messagePtr = default(System.IntPtr);
            g_set_error_literal(errPtr, domain, code, messagePtr);
        }

        /// <summary>
        /// If @dest is %NULL, free @src; otherwise, moves @src into *@dest.
        /// The error variable @dest points to must be %NULL.
        /// </summary>
        /// <param name="dest">
        /// error return location
        /// </param>
        /// <param name="src">
        /// error to move into the return location
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_propagate_error /* transfer-ownership:none */(
            System.IntPtr dest /* transfer-ownership:none */,
            System.IntPtr src /* transfer-ownership:none */);

        /// <summary>
        /// If @dest is %NULL, free @src; otherwise, moves @src into *@dest.
        /// The error variable @dest points to must be %NULL.
        /// </summary>
        /// <param name="dest">
        /// error return location
        /// </param>
        /// <param name="src">
        /// error to move into the return location
        /// </param>
        public static void PropagateError(
            GISharp.GLib.Error dest,
            GISharp.GLib.Error src)
        {
            if (dest == null)
            {
                throw new System.ArgumentNullException("dest");
            }
            if (src == null)
            {
                throw new System.ArgumentNullException("src");
            }
            var destPtr = default(System.IntPtr);
            var srcPtr = default(System.IntPtr);
            g_propagate_error(destPtr, srcPtr);
        }

        /// <summary>
        /// If @err is %NULL, does nothing. If @err is non-%NULL,
        /// calls g_error_free() on *@err and sets *@err to %NULL.
        /// </summary>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_clear_error /* transfer-ownership:none */(
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// If @err is %NULL, does nothing. If @err is non-%NULL,
        /// calls g_error_free() on *@err and sets *@err to %NULL.
        /// </summary>
        public static void ClearError()
        {
            System.IntPtr error;
            g_clear_error(out error);
        }

        /// <summary>
        /// Makes a copy of @error.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_copy /* transfer-ownership:full */(
            System.IntPtr error /* transfer-ownership:none */);

        /// <summary>
        /// Makes a copy of @error.
        /// </summary>
        /// <returns>
        /// a new #GError
        /// </returns>
        public override GISharp.GLib.Error Copy()
        {
            var retPtr = g_error_copy(Handle);
            return default(GISharp.GLib.Error);
        }

        /// <summary>
        /// Frees a #GError and associated resources.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_error_free /* transfer-ownership:none */(
            System.IntPtr error /* transfer-ownership:none */);

        /// <summary>
        /// Frees a #GError and associated resources.
        /// </summary>
        protected override void Free()
        {
            g_error_free(Handle);
        }

        /// <summary>
        /// Returns %TRUE if @error matches @domain and @code, %FALSE
        /// otherwise. In particular, when @error is %NULL, %FALSE will
        /// be returned.
        /// </summary>
        /// <remarks>
        /// If @domain contains a `FAILED` (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should
        /// instead treat any not-explicitly-recognized error code as being
        /// equilalent to the `FAILED` code. This way, if the domain is
        /// extended in the future to provide a more specific error code for
        /// a certain case, your code will still work.
        /// </remarks>
        /// <param name="error">
        /// a #GError or %NULL
        /// </param>
        /// <param name="domain">
        /// an error domain
        /// </param>
        /// <param name="code">
        /// an error code
        /// </param>
        /// <returns>
        /// whether @error has @domain and @code
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_error_matches /* transfer-ownership:none */(
            System.IntPtr error /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.Quark domain /* transfer-ownership:none */,
            System.Int32 code /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if @error matches @domain and @code, %FALSE
        /// otherwise. In particular, when @error is %NULL, %FALSE will
        /// be returned.
        /// </summary>
        /// <remarks>
        /// If @domain contains a `FAILED` (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should
        /// instead treat any not-explicitly-recognized error code as being
        /// equilalent to the `FAILED` code. This way, if the domain is
        /// extended in the future to provide a more specific error code for
        /// a certain case, your code will still work.
        /// </remarks>
        /// <param name="domain">
        /// an error domain
        /// </param>
        /// <param name="code">
        /// an error code
        /// </param>
        /// <returns>
        /// whether @error has @domain and @code
        /// </returns>
        public System.Boolean Matches(
            GISharp.GLib.Quark domain,
            System.Int32 code)
        {
            var ret = g_error_matches(Handle, domain, code);
            return default(System.Boolean);
        }
    }

    /// <summary>
    /// The possible errors, used in the @v_error field
    /// of #GTokenValue, when the token is a %G_TOKEN_ERROR.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// unknown error
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// unexpected end of file
        /// </summary>
        UnexpEof = 1,
        /// <summary>
        /// unterminated string constant
        /// </summary>
        UnexpEofInString = 2,
        /// <summary>
        /// unterminated comment
        /// </summary>
        UnexpEofInComment = 3,
        /// <summary>
        /// non-digit character in a number
        /// </summary>
        NonDigitInConst = 4,
        /// <summary>
        /// digit beyond radix in a number
        /// </summary>
        DigitRadix = 5,
        /// <summary>
        /// non-decimal floating point number
        /// </summary>
        FloatRadix = 6,
        /// <summary>
        /// malformed floating point number
        /// </summary>
        FloatMalformed = 7
    }

    /// <summary>
    /// Declares a type of function which takes an arbitrary
    /// data pointer argument and has no return value. It is
    /// not currently used in GLib or GTK+.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void FreeFunc(
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// Declares a type of function which takes an arbitrary
    /// data pointer argument and has no return value. It is
    /// not currently used in GLib or GTK+.
    /// </summary>
    public delegate void FreeFuncCallback(
        System.IntPtr data);

    /// <summary>
    /// The GKeyFile struct contains only private data
    /// and should not be accessed directly.
    /// </summary>
    public partial class KeyFile : GISharp.Core.ReferenceCountedOpaque<KeyFile>
    {
        /// <summary>
        /// The name of the main group of a desktop entry file, as defined in the
        /// [Desktop Entry Specification](http://freedesktop.org/Standards/desktop-entry-spec).
        /// Consult the specification for more
        /// details about the meanings of the keys below.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopGroup = "Desktop Entry";
        public const System.String DesktopKeyActions = "Actions";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the categories in which the desktop entry
        /// should be shown in a menu.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyCategories = "Categories";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the tooltip for the desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyComment = "Comment";
        public const System.String DesktopKeyDbusActivatable = "DBusActivatable";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the command line to execute. It is only valid for desktop
        /// entries with the `Application` type.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyExec = "Exec";
        public const System.String DesktopKeyFullname = "X-GNOME-FullName";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the generic name of the desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyGenericName = "GenericName";
        public const System.String DesktopKeyGettextDomain = "X-GNOME-Gettext-Domain";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry has been deleted by the user.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyHidden = "Hidden";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the name of the icon to be displayed for the desktop
        /// entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyIcon = "Icon";
        public const System.String DesktopKeyKeywords = "Keywords";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the MIME types supported by this desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyMimeType = "MimeType";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the specific name of the desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyName = "Name";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should not display the
        /// desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyNotShowIn = "NotShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry should be shown in menus.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyNoDisplay = "NoDisplay";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should display the
        /// desktop entry.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyOnlyShowIn = "OnlyShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// containing the working directory to run the program in. It is only
        /// valid for desktop entries with the `Application` type.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyPath = "Path";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the application supports the
        /// [Startup Notification Protocol Specification](http://www.freedesktop.org/Standards/startup-notification-spec).
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupNotify = "StartupNotify";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is string
        /// identifying the WM class or name hint of a window that the application
        /// will create, which can be used to emulate Startup Notification with
        /// older applications.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupWmClass = "StartupWMClass";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the program should be run in a terminal window.
        /// It is only valid for desktop entries with the
        /// `Application` type.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyTerminal = "Terminal";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the file name of a binary on disk used to determine if the
        /// program is actually installed. It is only valid for desktop entries
        /// with the `Application` type.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyTryExec = "TryExec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the type of the desktop entry. Usually
        /// #G_KEY_FILE_DESKTOP_TYPE_APPLICATION,
        /// #G_KEY_FILE_DESKTOP_TYPE_LINK, or
        /// #G_KEY_FILE_DESKTOP_TYPE_DIRECTORY.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyType = "Type";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the URL to access. It is only valid for desktop entries
        /// with the `Link` type.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyUrl = "URL";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the version of the Desktop Entry Specification used for
        /// the desktop entry file.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopKeyVersion = "Version";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing applications.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopTypeApplication = "Application";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing directories.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopTypeDirectory = "Directory";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing links to documents.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.14")]
        public const System.String DesktopTypeLink = "Link";

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_new /* transfer-ownership:full */();

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public KeyFile()
        {
            Handle = g_key_file_new();
        }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.Quark g_key_file_error_quark /* transfer-ownership:none */();

        public static GISharp.GLib.Quark ErrorQuark()
        {
            var ret = g_key_file_error_quark();
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_get_boolean /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean GetBoolean(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_get_boolean(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of booleans returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_boolean_list /* transfer-ownership:container */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean[] GetBooleanList(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            System.UInt64 length;
            var retPtr = g_key_file_get_boolean_list(Handle, groupNamePtr, keyPtr,out length,out error);
            return default(System.Boolean[]);
        }

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_comment /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String GetComment(
            System.String groupName,
            System.String key)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_key_file_get_comment(Handle, groupNamePtr, keyPtr,out error);
            return default(System.String);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Double g_key_file_get_double /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        public System.Double GetDouble(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_get_double(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Double);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of doubles returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_double_list /* transfer-ownership:container */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        public System.Double[] GetDoubleList(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            System.UInt64 length;
            var retPtr = g_key_file_get_double_list(Handle, groupNamePtr, keyPtr,out length,out error);
            return default(System.Double[]);
        }

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_groups /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String[] GetGroups(
            out System.UInt64 length)
        {
            var retPtr = g_key_file_get_groups(Handle,out length);
            length = default(System.UInt64); return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int64 g_key_file_get_int64 /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int64 GetInt64(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_get_int64(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Int64);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_key_file_get_integer /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Int32 GetInteger(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_get_integer(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of integers returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_integer_list /* transfer-ownership:container */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Int32[] GetIntegerList(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            System.UInt64 length;
            var retPtr = g_key_file_get_integer_list(Handle, groupNamePtr, keyPtr,out length,out error);
            return default(System.Int32[]);
        }

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_keys /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String[] GetKeys(
            System.String groupName,
            out System.UInt64 length)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            var groupNamePtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_key_file_get_keys(Handle, groupNamePtr,out length,out error);
            length = default(System.UInt64); return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_locale_string /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr locale /* transfer-ownership:none nullable:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String GetLocaleString(
            System.String groupName,
            System.String key,
            System.String locale)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var localePtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_key_file_get_locale_string(Handle, groupNamePtr, keyPtr, localePtr,out error);
            return default(System.String);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_locale_string_list /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr locale /* transfer-ownership:none nullable:1 allow-none:1 */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String[] GetLocaleStringList(
            System.String groupName,
            System.String key,
            System.String locale)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var localePtr = default(System.IntPtr);
            System.IntPtr error;
            System.UInt64 length;
            var retPtr = g_key_file_get_locale_string_list(Handle, groupNamePtr, keyPtr, localePtr,out length,out error);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_start_group /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */);

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String StartGroup
        {
            get
            {
                var retPtr = g_key_file_get_start_group(Handle);
                return default(System.String);
            }
        }

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_string /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String GetString(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_key_file_get_string(Handle, groupNamePtr, keyPtr,out error);
            return default(System.String);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_string_list /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String[] GetStringList(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            System.UInt64 length;
            var retPtr = g_key_file_get_string_list(Handle, groupNamePtr, keyPtr,out length,out error);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_key_file_get_uint64 /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.UInt64 GetUint64(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_get_uint64(Handle, groupNamePtr, keyPtr,out error);
            return default(System.UInt64);
        }

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_value /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String GetValue(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_key_file_get_value(Handle, groupNamePtr, keyPtr,out error);
            return default(System.String);
        }

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_has_group /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */);

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean HasGroup(
            System.String groupName)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            var groupNamePtr = default(System.IntPtr);
            var ret = g_key_file_has_group(Handle, groupNamePtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Looks whether the key file has the key @key in the group
        /// @group_name.
        /// </summary>
        /// <remarks>
        /// Note that this function does not follow the rules for #GError strictly;
        /// the return value both carries meaning and signals an error.  To use
        /// this function, you must pass a #GError pointer in @error, and check
        /// whether it is not %NULL to see if an error occurred.
        /// 
        /// Language bindings should use g_key_file_get_value() to test whether
        /// or not a key exists.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if @key is a part of @group_name, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_has_key /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Looks whether the key file has the key @key in the group
        /// @group_name.
        /// </summary>
        /// <remarks>
        /// Note that this function does not follow the rules for #GError strictly;
        /// the return value both carries meaning and signals an error.  To use
        /// this function, you must pass a #GError pointer in @error, and check
        /// whether it is not %NULL to see if an error occurred.
        /// 
        /// Language bindings should use g_key_file_get_value() to test whether
        /// or not a key exists.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name
        /// </param>
        /// <returns>
        /// %TRUE if @key is a part of @group_name, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean HasKey(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_has_key(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_data /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */,
            GISharp.GLib.KeyFileFlags flags /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean LoadFromData(
            System.String data,
            System.UInt64 length,
            GISharp.GLib.KeyFileFlags flags)
        {
            if (data == null)
            {
                throw new System.ArgumentNullException("data");
            }
            var dataPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_load_from_data(Handle, dataPtr, length, flags,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_data_dirs /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr file /* transfer-ownership:none */,
            out System.IntPtr fullPath /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            GISharp.GLib.KeyFileFlags flags /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean LoadFromDataDirs(
            System.String file,
            out System.String fullPath,
            GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new System.ArgumentNullException("file");
            }
            var filePtr = default(System.IntPtr);
            var fullPathPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_load_from_data_dirs(Handle, filePtr,out fullPathPtr, flags,out error);
            fullPath = default(System.String); return default(System.Boolean);
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.  If the file could not
        /// be loaded then an %error is set to either a #GFileError or
        /// #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_dirs /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr file /* transfer-ownership:none */,
            System.IntPtr searchDirs /* transfer-ownership:none */,
            out System.IntPtr fullPath /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            GISharp.GLib.KeyFileFlags flags /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.  If the file could not
        /// be loaded then an %error is set to either a #GFileError or
        /// #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        public System.Boolean LoadFromDirs(
            System.String file,
            System.String[] searchDirs,
            out System.String fullPath,
            GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new System.ArgumentNullException("file");
            }
            if (searchDirs == null)
            {
                throw new System.ArgumentNullException("searchDirs");
            }
            var filePtr = default(System.IntPtr);
            var searchDirsPtr = default(System.IntPtr);
            var fullPathPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_load_from_dirs(Handle, filePtr, searchDirsPtr,out fullPathPtr, flags,out error);
            fullPath = default(System.String); return default(System.Boolean);
        }

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// If the file could not be loaded then @error is set to
        /// either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_file /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr file /* transfer-ownership:none */,
            GISharp.GLib.KeyFileFlags flags /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// If the file could not be loaded then @error is set to
        /// either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean LoadFromFile(
            System.String file,
            GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new System.ArgumentNullException("file");
            }
            var filePtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_load_from_file(Handle, filePtr, flags,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increases the reference count of @key_file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// the same @key_file.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr keyFile /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count of @key_file.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        protected override void Ref()
        {
            g_key_file_ref(Handle);
        }

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_comment /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr key /* transfer-ownership:none nullable:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean RemoveComment(
            System.String groupName,
            System.String key)
        {
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_remove_comment(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_group /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean RemoveGroup(
            System.String groupName)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            var groupNamePtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_remove_group(Handle, groupNamePtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_key /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean RemoveKey(
            System.String groupName,
            System.String key)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_remove_key(Handle, groupNamePtr, keyPtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_save_to_file /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr filename /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public System.Boolean SaveToFile(
            System.String filename)
        {
            if (filename == null)
            {
                throw new System.ArgumentNullException("filename");
            }
            var filenamePtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_save_to_file(Handle, filenamePtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_boolean /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.Boolean value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetBoolean(
            System.String groupName,
            System.String key,
            System.Boolean value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            g_key_file_set_boolean(Handle, groupNamePtr, keyPtr, value);
        }

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        /// <param name="length">
        /// length of @list
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_boolean_list /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr list /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetBooleanList(
            System.String groupName,
            System.String key,
            System.Boolean[] list)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var listPtr = default(System.IntPtr);
            var length = (System.UInt64)list.Length;
            g_key_file_set_boolean_list(Handle, groupNamePtr, keyPtr, listPtr, length);
        }

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_set_comment /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr key /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr comment /* transfer-ownership:none */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.Boolean SetComment(
            System.String groupName,
            System.String key,
            System.String comment)
        {
            if (comment == null)
            {
                throw new System.ArgumentNullException("comment");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var commentPtr = default(System.IntPtr);
            System.IntPtr error;
            var ret = g_key_file_set_comment(Handle, groupNamePtr, keyPtr, commentPtr,out error);
            return default(System.Boolean);
        }

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_double /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.Double value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        public void SetDouble(
            System.String groupName,
            System.String key,
            System.Double value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            g_key_file_set_double(Handle, groupNamePtr, keyPtr, value);
        }

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        /// <param name="length">
        /// number of double values in @list
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_double_list /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr list /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        public void SetDoubleList(
            System.String groupName,
            System.String key,
            System.Double[] list)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var listPtr = default(System.IntPtr);
            var length = (System.UInt64)list.Length;
            g_key_file_set_double_list(Handle, groupNamePtr, keyPtr, listPtr, length);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_int64 /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.Int64 value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        public void SetInt64(
            System.String groupName,
            System.String key,
            System.Int64 value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            g_key_file_set_int64(Handle, groupNamePtr, keyPtr, value);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_integer /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.Int32 value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetInteger(
            System.String groupName,
            System.String key,
            System.Int32 value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            g_key_file_set_integer(Handle, groupNamePtr, keyPtr, value);
        }

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        /// <param name="length">
        /// number of integer values in @list
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_integer_list /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr list /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetIntegerList(
            System.String groupName,
            System.String key,
            System.Int32[] list)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var listPtr = default(System.IntPtr);
            var length = (System.UInt64)list.Length;
            g_key_file_set_integer_list(Handle, groupNamePtr, keyPtr, listPtr, length);
        }

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_list_separator /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.SByte separator /* transfer-ownership:none */);

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetListSeparator(
            System.SByte separator)
        {
            g_key_file_set_list_separator(Handle, separator);
        }

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_locale_string /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr locale /* transfer-ownership:none */,
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetLocaleString(
            System.String groupName,
            System.String key,
            System.String locale,
            System.String @string)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (locale == null)
            {
                throw new System.ArgumentNullException("locale");
            }
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var localePtr = default(System.IntPtr);
            var @stringPtr = default(System.IntPtr);
            g_key_file_set_locale_string(Handle, groupNamePtr, keyPtr, localePtr, @stringPtr);
        }

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        /// <param name="length">
        /// the length of @list
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_locale_string_list /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr locale /* transfer-ownership:none */,
            System.IntPtr list /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetLocaleStringList(
            System.String groupName,
            System.String key,
            System.String locale,
            System.String[] list)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (locale == null)
            {
                throw new System.ArgumentNullException("locale");
            }
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var localePtr = default(System.IntPtr);
            var listPtr = default(System.IntPtr);
            var length = (System.UInt64)list.Length;
            g_key_file_set_locale_string_list(Handle, groupNamePtr, keyPtr, localePtr, listPtr, length);
        }

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_string /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetString(
            System.String groupName,
            System.String key,
            System.String @string)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var @stringPtr = default(System.IntPtr);
            g_key_file_set_string(Handle, groupNamePtr, keyPtr, @stringPtr);
        }

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <param name="length">
        /// number of string values in @list
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_string_list /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr list /* transfer-ownership:none */,
            System.UInt64 length /* transfer-ownership:none */);

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetStringList(
            System.String groupName,
            System.String key,
            System.String[] list)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var listPtr = default(System.IntPtr);
            var length = (System.UInt64)list.Length;
            g_key_file_set_string_list(Handle, groupNamePtr, keyPtr, listPtr, length);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_uint64 /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.UInt64 value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        public void SetUint64(
            System.String groupName,
            System.String key,
            System.UInt64 value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            g_key_file_set_uint64(Handle, groupNamePtr, keyPtr, value);
        }

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_set_value /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            System.IntPtr groupName /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Core.SinceAttribute("2.6")]
        public void SetValue(
            System.String groupName,
            System.String key,
            System.String value)
        {
            if (groupName == null)
            {
                throw new System.ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var groupNamePtr = default(System.IntPtr);
            var keyPtr = default(System.IntPtr);
            var valuePtr = default(System.IntPtr);
            g_key_file_set_value(Handle, groupNamePtr, keyPtr, valuePtr);
        }

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_to_data /* transfer-ownership:full */(
            System.IntPtr keyFile /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public System.String ToData(
            out System.UInt64 length)
        {
            System.IntPtr error;
            var retPtr = g_key_file_to_data(Handle,out length,out error);
            length = default(System.UInt64); return default(System.String);
        }

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_key_file_unref /* transfer-ownership:none */(
            System.IntPtr keyFile /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        protected override void Unref()
        {
            g_key_file_unref(Handle);
        }
    }

    /// <summary>
    /// Error codes returned by key file parsing.
    /// </summary>
    [GISharp.Core.ErrorDomainAttribute("g-key-file-error-quark")]
    public enum KeyFileError
    {
        /// <summary>
        /// the text being parsed was in
        ///     an unknown encoding
        /// </summary>
        UnknownEncoding = 0,
        /// <summary>
        /// document was ill-formed
        /// </summary>
        Parse = 1,
        /// <summary>
        /// the file was not found
        /// </summary>
        NotFound = 2,
        /// <summary>
        /// a requested key was not found
        /// </summary>
        KeyNotFound = 3,
        /// <summary>
        /// a requested group was not found
        /// </summary>
        GroupNotFound = 4,
        /// <summary>
        /// a value could not be parsed
        /// </summary>
        InvalidValue = 5
    }

    /// <summary>
    /// Flags which influence the parsing.
    /// </summary>
    [System.FlagsAttribute]
    public enum KeyFileFlags
    {
        /// <summary>
        /// No flags, default behaviour
        /// </summary>
        None = 0,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise all comments will be lost when the key file is
        ///     written back.
        /// </summary>
        KeepComments = 1,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise only the translations for the current language will be
        ///     written back.
        /// </summary>
        KeepTranslations = 2
    }

    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    /// </remarks>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void LogFunc(
        System.IntPtr logDomain /* transfer-ownership:none */,
        GISharp.GLib.LogLevelFlags logLevel /* transfer-ownership:none */,
        System.IntPtr message /* transfer-ownership:none */,
        System.IntPtr userData /* transfer-ownership:none closure:3 */);

    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    /// </remarks>
    public delegate void LogFuncCallback(
        System.String logDomain,
        GISharp.GLib.LogLevelFlags logLevel,
        System.String message);

    /// <summary>
    /// Flags specifying the level of log messages.
    /// </summary>
    /// <remarks>
    /// It is possible to change how GLib treats messages of the various
    /// levels using g_log_set_handler() and g_log_set_fatal_mask().
    /// </remarks>
    [System.FlagsAttribute]
    public enum LogLevelFlags
    {
        /// <summary>
        /// internal flag
        /// </summary>
        FlagRecursion = 1,
        /// <summary>
        /// internal flag
        /// </summary>
        FlagFatal = 2,
        /// <summary>
        /// log level for errors, see g_error().
        ///     This level is also used for messages produced by g_assert().
        /// </summary>
        LevelError = 4,
        /// <summary>
        /// log level for critical messages, see g_critical().
        ///     This level is also used for messages produced by g_return_if_fail()
        ///     and g_return_val_if_fail().
        /// </summary>
        LevelCritical = 8,
        /// <summary>
        /// log level for warnings, see g_warning()
        /// </summary>
        LevelWarning = 16,
        /// <summary>
        /// log level for messages, see g_message()
        /// </summary>
        LevelMessage = 32,
        /// <summary>
        /// log level for informational messages, see g_info()
        /// </summary>
        LevelInfo = 64,
        /// <summary>
        /// log level for debug messages, see g_debug()
        /// </summary>
        LevelDebug = 128,
        /// <summary>
        /// a mask including all log levels
        /// </summary>
        LevelMask = -4
    }

    /// <summary>
    /// The `GMainContext` struct is an opaque data
    /// type representing a set of sources to be handled in a main loop.
    /// </summary>
    public partial class MainContext : GISharp.Core.ReferenceCountedOpaque<MainContext>
    {
        /// <summary>
        /// Creates a new #GMainContext structure.
        /// </summary>
        /// <returns>
        /// the new #GMainContext
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_new /* transfer-ownership:full */();

        /// <summary>
        /// Creates a new #GMainContext structure.
        /// </summary>
        /// <returns>
        /// the new #GMainContext
        /// </returns>
        public MainContext()
        {
            Handle = g_main_context_new();
        }

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop. See also
        /// g_main_context_get_thread_default().
        /// </summary>
        /// <returns>
        /// the global default main context.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_default /* transfer-ownership:none */();

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop. See also
        /// g_main_context_get_thread_default().
        /// </summary>
        /// <returns>
        /// the global default main context.
        /// </returns>
        public static GISharp.GLib.MainContext Default
        {
            get
            {
                var retPtr = g_main_context_default();
                return default(GISharp.GLib.MainContext);
            }
        }

        /// <summary>
        /// Gets the thread-default #GMainContext for this thread, as with
        /// g_main_context_get_thread_default(), but also adds a reference to
        /// it with g_main_context_ref(). In addition, unlike
        /// g_main_context_get_thread_default(), if the thread-default context
        /// is the global default context, this will return that #GMainContext
        /// (with a ref added to it) rather than returning %NULL.
        /// </summary>
        /// <returns>
        /// the thread-default #GMainContext. Unref
        ///     with g_main_context_unref() when you are done with it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_ref_thread_default /* transfer-ownership:full */();

        /// <summary>
        /// Gets the thread-default #GMainContext for this thread, as with
        /// g_main_context_get_thread_default(), but also adds a reference to
        /// it with g_main_context_ref(). In addition, unlike
        /// g_main_context_get_thread_default(), if the thread-default context
        /// is the global default context, this will return that #GMainContext
        /// (with a ref added to it) rather than returning %NULL.
        /// </summary>
        /// <returns>
        /// the thread-default #GMainContext. Unref
        ///     with g_main_context_unref() when you are done with it.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public static GISharp.GLib.MainContext RefThreadDefault()
        {
            var retPtr = g_main_context_ref_thread_default();
            return default(GISharp.GLib.MainContext);
        }

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// g_main_context_dispatch() on any #GMainContext in the current thread.
        ///  That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from g_main_context_iteration()
        /// (or g_main_loop_run(), etc.) it returns 1. When called from within
        /// a callback to a recursive call to g_main_context_iteration(),
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using g_main_depth()
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use g_main_depth() to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if g_main_depth() returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_main_depth /* transfer-ownership:none */();

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// g_main_context_dispatch() on any #GMainContext in the current thread.
        ///  That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from g_main_context_iteration()
        /// (or g_main_loop_run(), etc.) it returns 1. When called from within
        /// a callback to a recursive call to g_main_context_iteration(),
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using g_main_depth()
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use g_main_depth() to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if g_main_depth() returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        public static System.Int32 MainDepth()
        {
            var ret = g_main_depth();
            return default(System.Int32);
        }

        /// <summary>
        /// Polls @fds, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by #GMainContext, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of @fds is a #GPollFD describing a single file
        /// descriptor to poll. The %fd field indicates the file descriptor,
        /// and the %events field indicates the events to poll for. On return,
        /// the %revents fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in @fds can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// #GPollFDs with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="nfds">
        /// the number of file descriptors in @fds
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in @fds whose %revents fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_poll /* transfer-ownership:none */(
            GISharp.GLib.PollFD fds /* transfer-ownership:none */,
            System.UInt32 nfds /* transfer-ownership:none */,
            System.Int32 timeout /* transfer-ownership:none */);

        /// <summary>
        /// Polls @fds, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by #GMainContext, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of @fds is a #GPollFD describing a single file
        /// descriptor to poll. The %fd field indicates the file descriptor,
        /// and the %events field indicates the events to poll for. On return,
        /// the %revents fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in @fds can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// #GPollFDs with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="nfds">
        /// the number of file descriptors in @fds
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in @fds whose %revents fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.20")]
        public static System.Int32 Poll(
            GISharp.GLib.PollFD fds,
            System.UInt32 nfds,
            System.Int32 timeout)
        {
            var ret = g_poll(fds, nfds, timeout);
            return default(System.Int32);
        }

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns %FALSE immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when g_main_context_release()
        /// is called as many times as g_main_context_acquire().
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call g_main_context_prepare(), g_main_context_query(),
        /// g_main_context_check(), g_main_context_dispatch().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if the operation succeeded, and
        ///   this thread is now the owner of @context.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_acquire /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns %FALSE immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when g_main_context_release()
        /// is called as many times as g_main_context_acquire().
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call g_main_context_prepare(), g_main_context_query(),
        /// g_main_context_check(), g_main_context_dispatch().
        /// </remarks>
        /// <returns>
        /// %TRUE if the operation succeeded, and
        ///   this thread is now the owner of @context.
        /// </returns>
        public System.Boolean Acquire()
        {
            var ret = g_main_context_acquire(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use g_source_add_unix_fd() instead.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (or %NULL for the default context)
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        ///      the same as the priority used for g_source_attach() to ensure that the
        ///      file descriptor is polled whenever the results may be needed.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_add_poll /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.PollFD fd /* transfer-ownership:none */,
            System.Int32 priority /* transfer-ownership:none */);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use g_source_add_unix_fd() instead.
        /// </summary>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        ///      the same as the priority used for g_source_attach() to ensure that the
        ///      file descriptor is polled whenever the results may be needed.
        /// </param>
        public void AddPoll(
            GISharp.GLib.PollFD fd,
            System.Int32 priority)
        {
            g_main_context_add_poll(Handle, fd, priority);
        }

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of #GPollFD's that was passed to
        ///       the last call to g_main_context_query()
        /// </param>
        /// <param name="nFds">
        /// return value of g_main_context_query()
        /// </param>
        /// <returns>
        /// %TRUE if some sources are ready to be dispatched.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_main_context_check /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            System.Int32 maxPriority /* transfer-ownership:none */,
            System.IntPtr fds /* transfer-ownership:none */,
            System.Int32 nFds /* transfer-ownership:none */);

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of #GPollFD's that was passed to
        ///       the last call to g_main_context_query()
        /// </param>
        /// <returns>
        /// %TRUE if some sources are ready to be dispatched.
        /// </returns>
        public System.Int32 Check(
            System.Int32 maxPriority,
            GISharp.GLib.PollFD[] fds)
        {
            if (fds == null)
            {
                throw new System.ArgumentNullException("fds");
            }
            var fdsPtr = default(System.IntPtr);
            var nFds = (System.Int32)fds.Length;
            var ret = g_main_context_check(Handle, maxPriority, fdsPtr, nFds);
            return default(System.Int32);
        }

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_dispatch /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        public void Dispatch()
        {
            g_main_context_dispatch(Handle);
        }

        /// <summary>
        /// Finds a source with the given source functions and user data.  If
        /// multiple sources exist with the same source function and user data,
        /// the first one found will be returned.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used).
        /// </param>
        /// <param name="funcs">
        /// the @source_funcs passed to g_source_new().
        /// </param>
        /// <param name="userData">
        /// the user data from the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_funcs_user_data /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.SourceFuncs funcs /* transfer-ownership:none */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Finds a source with the given source functions and user data.  If
        /// multiple sources exist with the same source function and user data,
        /// the first one found will be returned.
        /// </summary>
        /// <param name="funcs">
        /// the @source_funcs passed to g_source_new().
        /// </param>
        /// <param name="userData">
        /// the user data from the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        public GISharp.GLib.Source FindSourceByFuncsUserData(
            GISharp.GLib.SourceFuncs funcs,
            System.IntPtr userData)
        {
            var retPtr = g_main_context_find_source_by_funcs_user_data(Handle, funcs, userData);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Finds a #GSource given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="sourceId">
        /// the source ID, as returned by g_source_get_id().
        /// </param>
        /// <returns>
        /// the #GSource
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_id /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.UInt32 sourceId /* transfer-ownership:none */);

        /// <summary>
        /// Finds a #GSource given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="sourceId">
        /// the source ID, as returned by g_source_get_id().
        /// </param>
        /// <returns>
        /// the #GSource
        /// </returns>
        public GISharp.GLib.Source FindSourceById(
            System.UInt32 sourceId)
        {
            var retPtr = g_main_context_find_source_by_id(Handle, sourceId);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Finds a source with the given user data for the callback.  If
        /// multiple sources exist with the same user data, the first
        /// one found will be returned.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_user_data /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Finds a source with the given user data for the callback.  If
        /// multiple sources exist with the same user data, the first
        /// one found will be returned.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        public GISharp.GLib.Source FindSourceByUserData(
            System.IntPtr userData)
        {
            var retPtr = g_main_context_find_source_by_user_data(Handle, userData);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Gets the poll function set by g_main_context_set_poll_func().
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// the poll function
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.PollFunc g_main_context_get_poll_func /* */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Gets the poll function set by g_main_context_set_poll_func().
        /// </summary>
        /// <returns>
        /// the poll function
        /// </returns>
        public GISharp.GLib.PollFuncCallback PollFunc
        {
            get
            {
                var retPtr = g_main_context_get_poll_func(Handle);
                return default(GISharp.GLib.PollFuncCallback);
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }
                var valueNative = default(GISharp.GLib.PollFunc);
                g_main_context_set_poll_func(Handle, valueNative);
            }
        }

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// If @context is %NULL then the global default main context — as
        /// returned by g_main_context_default() — is used.
        /// 
        /// If @context is owned by the current thread, @function is called
        /// directly.  Otherwise, if @context is the thread-default main context
        /// of the current thread and g_main_context_acquire() succeeds, then
        /// @function is called and g_main_context_release() is called
        /// afterwards.
        /// 
        /// In any other case, an idle source is created to call @function and
        /// that source is attached to @context (presumably to be run in another
        /// thread).  The idle source is attached with #G_PRIORITY_DEFAULT
        /// priority.  If you want a different priority, use
        /// g_main_context_invoke_full().
        /// 
        /// Note that, as with normal idle functions, @function should probably
        /// return %FALSE.  If it returns %TRUE, it will be continuously run in a
        /// loop (and may prevent this call from returning).
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_invoke /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.SourceFunc function /* transfer-ownership:none closure:1 */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// If @context is %NULL then the global default main context — as
        /// returned by g_main_context_default() — is used.
        /// 
        /// If @context is owned by the current thread, @function is called
        /// directly.  Otherwise, if @context is the thread-default main context
        /// of the current thread and g_main_context_acquire() succeeds, then
        /// @function is called and g_main_context_release() is called
        /// afterwards.
        /// 
        /// In any other case, an idle source is created to call @function and
        /// that source is attached to @context (presumably to be run in another
        /// thread).  The idle source is attached with #G_PRIORITY_DEFAULT
        /// priority.  If you want a different priority, use
        /// g_main_context_invoke_full().
        /// 
        /// Note that, as with normal idle functions, @function should probably
        /// return %FALSE.  If it returns %TRUE, it will be continuously run in a
        /// loop (and may prevent this call from returning).
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        public void Invoke(
            GISharp.GLib.SourceFuncCallback function)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }
            var data = default(System.IntPtr);
            var functionNative = default(GISharp.GLib.SourceFunc);
            g_main_context_invoke(Handle, functionNative, data);
        }

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// This function is the same as g_main_context_invoke() except that it
        /// lets you specify the priority incase @function ends up being
        /// scheduled as an idle and also lets you give a #GDestroyNotify for @data.
        /// 
        /// @notify should not assume that it is called from any particular
        /// thread or with any particular context acquired.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL
        /// </param>
        /// <param name="priority">
        /// the priority at which to run @function
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_invoke_full /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.Int32 priority /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc function /* transfer-ownership:none scope:notified closure:2 destroy:3 */,
            System.IntPtr data /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none nullable:1 allow-none:1 scope:async */);

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// This function is the same as g_main_context_invoke() except that it
        /// lets you specify the priority incase @function ends up being
        /// scheduled as an idle and also lets you give a #GDestroyNotify for @data.
        /// 
        /// @notify should not assume that it is called from any particular
        /// thread or with any particular context acquired.
        /// </remarks>
        /// <param name="priority">
        /// the priority at which to run @function
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        public void InvokeFull(
            System.Int32 priority,
            GISharp.GLib.SourceFuncCallback function)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var data = default(System.IntPtr);
            var functionNative = default(GISharp.GLib.SourceFunc);
            g_main_context_invoke_full(Handle, priority, functionNative, data, notifyNative);
        }

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this #GMainContext. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of @context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if current thread is owner of @context.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.10")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_is_owner /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this #GMainContext. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of @context.
        /// </summary>
        /// <returns>
        /// %TRUE if current thread is owner of @context.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.10")]
        public System.Boolean IsOwner
        {
            get
            {
                var ret = g_main_context_is_owner(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and @may_block is %TRUE, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if @may_block is %FALSE
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when @may_block is %TRUE, it is still possible for
        /// g_main_context_iteration() to return %FALSE, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// %TRUE if events were dispatched.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_iteration /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.Boolean mayBlock /* transfer-ownership:none */);

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and @may_block is %TRUE, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if @may_block is %FALSE
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when @may_block is %TRUE, it is still possible for
        /// g_main_context_iteration() to return %FALSE, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// %TRUE if events were dispatched.
        /// </returns>
        public System.Boolean Iteration(
            System.Boolean mayBlock)
        {
            var ret = g_main_context_iteration(Handle, mayBlock);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// %TRUE if events are pending.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_pending /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <returns>
        /// %TRUE if events are pending.
        /// </returns>
        public System.Boolean Pending()
        {
            var ret = g_main_context_pending(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Pops @context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        /// <param name="context">
        /// a #GMainContext object, or %NULL
        /// </param>
        [GISharp.Core.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_pop_thread_default /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Pops @context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        [GISharp.Core.SinceAttribute("2.22")]
        public void PopThreadDefault()
        {
            g_main_context_pop_thread_default(Handle);
        }

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling g_main_context_query ().
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="priority">
        /// location to store priority of highest priority
        ///            source already ready.
        /// </param>
        /// <returns>
        /// %TRUE if some source is ready to be dispatched
        ///               prior to polling.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_prepare /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            System.Int32 priority /* transfer-ownership:none */);

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling g_main_context_query ().
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="priority">
        /// location to store priority of highest priority
        ///            source already ready.
        /// </param>
        /// <returns>
        /// %TRUE if some source is ready to be dispatched
        ///               prior to polling.
        /// </returns>
        public System.Boolean Prepare(
            System.Int32 priority)
        {
            var ret = g_main_context_prepare(Handle, priority);
            return default(System.Boolean);
        }

        /// <summary>
        /// Acquires @context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under @context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by g_main_context_get_thread_default(),
        /// not the one returned by g_main_context_default(), so it does not affect
        /// the context used by functions like g_idle_add().
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a #GMainContext which will be run by a
        /// #GMainLoop in that thread, to set a new default context for all
        /// async operations in that thread. (In this case, you don't need to
        /// ever call g_main_context_pop_thread_default().) In some cases
        /// however, you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// g_main_context_push_thread_default() /
        /// g_main_context_pop_thread_default() pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL for the global default context
        /// </param>
        [GISharp.Core.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_push_thread_default /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Acquires @context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under @context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by g_main_context_get_thread_default(),
        /// not the one returned by g_main_context_default(), so it does not affect
        /// the context used by functions like g_idle_add().
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a #GMainContext which will be run by a
        /// #GMainLoop in that thread, to set a new default context for all
        /// async operations in that thread. (In this case, you don't need to
        /// ever call g_main_context_pop_thread_default().) In some cases
        /// however, you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// g_main_context_push_thread_default() /
        /// g_main_context_pop_thread_default() pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.22")]
        public void PushThreadDefault()
        {
            g_main_context_push_thread_default(Handle);
        }

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        ///       store #GPollFD records that need to be polled.
        /// </param>
        /// <param name="nFds">
        /// length of @fds.
        /// </param>
        /// <returns>
        /// the number of records actually stored in @fds,
        ///   or, if more than @n_fds records need to be stored, the number
        ///   of records that need to be stored.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_main_context_query /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            System.Int32 maxPriority /* transfer-ownership:none */,
            out System.Int32 timeout /* direction:out caller-allocates:0 transfer-ownership:full */,
            ref System.IntPtr fds /* direction:out caller-allocates:1 transfer-ownership:none */,
            System.Int32 nFds /* direction:in caller-allocates:0 transfer-ownership:full */);

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        ///       store #GPollFD records that need to be polled.
        /// </param>
        /// <returns>
        /// the number of records actually stored in @fds,
        ///   or, if more than @n_fds records need to be stored, the number
        ///   of records that need to be stored.
        /// </returns>
        public System.Int32 Query(
            System.Int32 maxPriority,
            out System.Int32 timeout,
            ref GISharp.GLib.PollFD[] fds)
        {
            var fdsPtr = default(System.IntPtr);
            var nFds = (System.Int32)fds.Length;
            var ret = g_main_context_query(Handle, maxPriority,out timeout,ref fdsPtr, nFds);
            timeout = default(System.Int32); fds = default(GISharp.GLib.PollFD[]); return default(System.Int32);
        }

        /// <summary>
        /// Increases the reference count on a #GMainContext object by one.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// the @context that was passed in (since 2.6)
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on a #GMainContext object by one.
        /// </summary>
        protected override void Ref()
        {
            g_main_context_ref(Handle);
        }

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with g_main_context_acquire(). If the context was acquired multiple
        /// times, the ownership will be released only when g_main_context_release()
        /// is called as many times as it was acquired.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_release /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with g_main_context_acquire(). If the context was acquired multiple
        /// times, the ownership will be released only when g_main_context_release()
        /// is called as many times as it was acquired.
        /// </summary>
        public void Release()
        {
            g_main_context_release(Handle);
        }

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="fd">
        /// a #GPollFD descriptor previously added with g_main_context_add_poll()
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_remove_poll /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            GISharp.GLib.PollFD fd /* transfer-ownership:none */);

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="fd">
        /// a #GPollFD descriptor previously added with g_main_context_add_poll()
        /// </param>
        public void RemovePoll(
            GISharp.GLib.PollFD fd)
        {
            g_main_context_remove_poll(Handle, fd);
        }

        /// <summary>
        /// Sets the function to use to handle polling of file descriptors. It
        /// will be used instead of the poll() system call
        /// (or GLib's replacement function, which is used where
        /// poll() isn't available).
        /// </summary>
        /// <remarks>
        /// This function could possibly be used to integrate the GLib event
        /// loop with an external event loop.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="func">
        /// the function to call to poll all file descriptors
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_set_poll_func /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */,
            GISharp.GLib.PollFunc func /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count on a #GMainContext object by one. If
        /// the result is zero, free the context and free all associated memory.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_unref /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count on a #GMainContext object by one. If
        /// the result is zero, free the context and free all associated memory.
        /// </summary>
        protected override void Unref()
        {
            g_main_context_unref(Handle);
        }

        /// <summary>
        /// If @context is currently blocking in g_main_context_iteration()
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// g_main_context_iteration() to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over #GMainContext; for
        /// example, integrating it with main loop implementations such as
        /// #GMainLoop.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_context_wakeup /* transfer-ownership:none */(
            System.IntPtr context /* transfer-ownership:none */);

        /// <summary>
        /// If @context is currently blocking in g_main_context_iteration()
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// g_main_context_iteration() to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over #GMainContext; for
        /// example, integrating it with main loop implementations such as
        /// #GMainLoop.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        public void Wakeup()
        {
            g_main_context_wakeup(Handle);
        }
    }

    /// <summary>
    /// The `GMainLoop` struct is an opaque data type
    /// representing the main event loop of a GLib or GTK+ application.
    /// </summary>
    public partial class MainLoop : GISharp.Core.ReferenceCountedOpaque<MainLoop>
    {
        /// <summary>
        /// Creates a new #GMainLoop structure.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext  (if %NULL, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to %TRUE to indicate that the loop is running. This
        /// is not very important since calling g_main_loop_run() will set this to
        /// %TRUE anyway.
        /// </param>
        /// <returns>
        /// a new #GMainLoop.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_new /* transfer-ownership:full */(
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.Boolean isRunning /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GMainLoop structure.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext  (if %NULL, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to %TRUE to indicate that the loop is running. This
        /// is not very important since calling g_main_loop_run() will set this to
        /// %TRUE anyway.
        /// </param>
        /// <returns>
        /// a new #GMainLoop.
        /// </returns>
        public MainLoop(
            GISharp.GLib.MainContext context = null,
            System.Boolean isRunning = false)
        {
            var contextPtr = default(System.IntPtr);
            Handle = g_main_loop_new(contextPtr, isRunning);
        }

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_get_context /* transfer-ownership:none */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        public GISharp.GLib.MainContext Context
        {
            get
            {
                var retPtr = g_main_loop_get_context(Handle);
                return default(GISharp.GLib.MainContext);
            }
        }

        /// <summary>
        /// Checks to see if the main loop is currently being run via g_main_loop_run().
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// %TRUE if the mainloop is currently being run.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_main_loop_is_running /* transfer-ownership:none */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Checks to see if the main loop is currently being run via g_main_loop_run().
        /// </summary>
        /// <returns>
        /// %TRUE if the mainloop is currently being run.
        /// </returns>
        public System.Boolean IsRunning
        {
            get
            {
                var ret = g_main_loop_is_running(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </remarks>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_loop_quit /* transfer-ownership:none */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </remarks>
        public void Quit()
        {
            g_main_loop_quit(Handle);
        }

        /// <summary>
        /// Increases the reference count on a #GMainLoop object by one.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        /// <returns>
        /// @loop
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on a #GMainLoop object by one.
        /// </summary>
        protected override void Ref()
        {
            g_main_loop_ref(Handle);
        }

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_loop_run /* transfer-ownership:none */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        public void Run()
        {
            g_main_loop_run(Handle);
        }

        /// <summary>
        /// Decreases the reference count on a #GMainLoop object by one. If
        /// the result is zero, free the loop and free all associated memory.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_main_loop_unref /* transfer-ownership:none */(
            System.IntPtr loop /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count on a #GMainLoop object by one. If
        /// the result is zero, free the loop and free all associated memory.
        /// </summary>
        protected override void Unref()
        {
            g_main_loop_unref(Handle);
        }
    }

    /// <summary>
    /// The #GNode struct represents one node in a [n-ary tree][glib-N-ary-Trees].
    /// </summary>
    public partial class Node : GISharp.Core.OwnedOpaque<Node>
    {
        /// <summary>
        /// Creates a new #GNode containing the given data.
        /// Used to create the first node in a tree.
        /// </summary>
        /// <param name="data">
        /// the data of the new node
        /// </param>
        /// <returns>
        /// a new #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_new /* */(
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GNode containing the given data.
        /// Used to create the first node in a tree.
        /// </summary>
        /// <param name="data">
        /// the data of the new node
        /// </param>
        /// <returns>
        /// a new #GNode
        /// </returns>
        public static GISharp.GLib.Node New(
            System.IntPtr data)
        {
            var retPtr = g_node_new(data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the position of the first child of a #GNode
        /// which contains the given data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the child of @node which contains
        ///     @data, or -1 if the data is not found
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_node_child_index /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Gets the position of the first child of a #GNode
        /// which contains the given data.
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the child of @node which contains
        ///     @data, or -1 if the data is not found
        /// </returns>
        public System.Int32 ChildIndex(
            System.IntPtr data)
        {
            var ret = g_node_child_index(Handle, data);
            return default(System.Int32);
        }

        /// <summary>
        /// Gets the position of a #GNode with respect to its siblings.
        /// @child must be a child of @node. The first child is numbered 0,
        /// the second 1, and so on.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="child">
        /// a child of @node
        /// </param>
        /// <returns>
        /// the position of @child with respect to its siblings
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_node_child_position /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */,
            System.IntPtr child /* transfer-ownership:none */);

        /// <summary>
        /// Gets the position of a #GNode with respect to its siblings.
        /// @child must be a child of @node. The first child is numbered 0,
        /// the second 1, and so on.
        /// </summary>
        /// <param name="child">
        /// a child of @node
        /// </param>
        /// <returns>
        /// the position of @child with respect to its siblings
        /// </returns>
        public System.Int32 ChildPosition(
            GISharp.GLib.Node child)
        {
            if (child == null)
            {
                throw new System.ArgumentNullException("child");
            }
            var childPtr = default(System.IntPtr);
            var ret = g_node_child_position(Handle, childPtr);
            return default(System.Int32);
        }

        /// <summary>
        /// Calls a function for each of the children of a #GNode.
        /// Note that it doesn't descend beneath the child nodes.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="func">
        /// the function to call for each visited node
        /// </param>
        /// <param name="data">
        /// user data to pass to the function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_node_children_foreach /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */,
            GISharp.GLib.TraverseFlags flags /* transfer-ownership:none */,
            GISharp.GLib.NodeForeachFunc func /* transfer-ownership:none closure:2 */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Calls a function for each of the children of a #GNode.
        /// Note that it doesn't descend beneath the child nodes.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="func">
        /// the function to call for each visited node
        /// </param>
        public void ChildrenForeach(
            GISharp.GLib.TraverseFlags flags,
            GISharp.GLib.NodeForeachFuncCallback func)
        {
            if (func == null)
            {
                throw new System.ArgumentNullException("func");
            }
            var data = default(System.IntPtr);
            var funcNative = default(GISharp.GLib.NodeForeachFunc);
            g_node_children_foreach(Handle, flags, funcNative, data);
        }

        /// <summary>
        /// Recursively copies a #GNode (but does not deep-copy the data inside the
        /// nodes, see g_node_copy_deep() if you need that).
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// a new #GNode containing the same data pointers
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_copy /* */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Recursively copies a #GNode (but does not deep-copy the data inside the
        /// nodes, see g_node_copy_deep() if you need that).
        /// </summary>
        /// <returns>
        /// a new #GNode containing the same data pointers
        /// </returns>
        public override GISharp.GLib.Node Copy()
        {
            var retPtr = g_node_copy(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Recursively copies a #GNode and its data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="copyFunc">
        /// the function which is called to copy the data inside each node,
        ///   or %NULL to use the original data.
        /// </param>
        /// <param name="data">
        /// data to pass to @copy_func
        /// </param>
        /// <returns>
        /// a new #GNode containing copies of the data in @node.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_copy_deep /* */(
            System.IntPtr node /* transfer-ownership:none */,
            GISharp.Core.CopyFunc copyFunc /* transfer-ownership:none closure:1 */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Gets the depth of a #GNode.
        /// </summary>
        /// <remarks>
        /// If @node is %NULL the depth is 0. The root node has a depth of 1.
        /// For the children of the root node the depth is 2. And so on.
        /// </remarks>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the depth of the #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_depth /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the depth of a #GNode.
        /// </summary>
        /// <remarks>
        /// If @node is %NULL the depth is 0. The root node has a depth of 1.
        /// For the children of the root node the depth is 2. And so on.
        /// </remarks>
        /// <returns>
        /// the depth of the #GNode
        /// </returns>
        public System.UInt32 Depth()
        {
            var ret = g_node_depth(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes @root and its children from the tree, freeing any memory
        /// allocated.
        /// </summary>
        /// <param name="root">
        /// the root of the tree/subtree to destroy
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_node_destroy /* transfer-ownership:none */(
            System.IntPtr root /* transfer-ownership:none */);

        /// <summary>
        /// Removes @root and its children from the tree, freeing any memory
        /// allocated.
        /// </summary>
        protected override void Free()
        {
            g_node_destroy(Handle);
        }

        /// <summary>
        /// Finds a #GNode in a tree.
        /// </summary>
        /// <param name="root">
        /// the root #GNode of the tree to search
        /// </param>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found #GNode, or %NULL if the data is not found
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_find /* */(
            System.IntPtr root /* transfer-ownership:none */,
            GISharp.GLib.TraverseType order /* transfer-ownership:none */,
            GISharp.GLib.TraverseFlags flags /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Finds a #GNode in a tree.
        /// </summary>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found #GNode, or %NULL if the data is not found
        /// </returns>
        public GISharp.GLib.Node Find(
            GISharp.GLib.TraverseType order,
            GISharp.GLib.TraverseFlags flags,
            System.IntPtr data)
        {
            var retPtr = g_node_find(Handle, order, flags, data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Finds the first child of a #GNode with the given data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found child #GNode, or %NULL if the data is not found
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_find_child /* */(
            System.IntPtr node /* transfer-ownership:none */,
            GISharp.GLib.TraverseFlags flags /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Finds the first child of a #GNode with the given data.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found child #GNode, or %NULL if the data is not found
        /// </returns>
        public GISharp.GLib.Node FindChild(
            GISharp.GLib.TraverseFlags flags,
            System.IntPtr data)
        {
            var retPtr = g_node_find_child(Handle, flags, data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the first sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the first sibling of @node
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_first_sibling /* */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the first sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <returns>
        /// the first sibling of @node
        /// </returns>
        public GISharp.GLib.Node FirstSibling()
        {
            var retPtr = g_node_first_sibling(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the root of a tree.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the root of the tree
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_get_root /* */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the root of a tree.
        /// </summary>
        /// <returns>
        /// the root of the tree
        /// </returns>
        public GISharp.GLib.Node Root
        {
            get
            {
                var retPtr = g_node_get_root(Handle);
                return default(GISharp.GLib.Node);
            }
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent at the given position.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="position">
        /// the position to place @node at, with respect to its siblings
        ///     If position is -1, @node is inserted as the last child of @parent
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert /* */(
            System.IntPtr parent /* transfer-ownership:none */,
            System.Int32 position /* transfer-ownership:none */,
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Inserts a #GNode beneath the parent at the given position.
        /// </summary>
        /// <param name="position">
        /// the position to place @node at, with respect to its siblings
        ///     If position is -1, @node is inserted as the last child of @parent
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node Insert(
            System.Int32 position,
            GISharp.GLib.Node node)
        {
            if (node == null)
            {
                throw new System.ArgumentNullException("node");
            }
            var nodePtr = default(System.IntPtr);
            var retPtr = g_node_insert(Handle, position, nodePtr);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent after the given sibling.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="sibling">
        /// the sibling #GNode to place @node after.
        ///     If sibling is %NULL, the node is inserted as the first child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert_after /* */(
            System.IntPtr parent /* transfer-ownership:none */,
            System.IntPtr sibling /* transfer-ownership:none */,
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Inserts a #GNode beneath the parent after the given sibling.
        /// </summary>
        /// <param name="sibling">
        /// the sibling #GNode to place @node after.
        ///     If sibling is %NULL, the node is inserted as the first child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node InsertAfter(
            GISharp.GLib.Node sibling,
            GISharp.GLib.Node node)
        {
            if (sibling == null)
            {
                throw new System.ArgumentNullException("sibling");
            }
            if (node == null)
            {
                throw new System.ArgumentNullException("node");
            }
            var siblingPtr = default(System.IntPtr);
            var nodePtr = default(System.IntPtr);
            var retPtr = g_node_insert_after(Handle, siblingPtr, nodePtr);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent before the given sibling.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="sibling">
        /// the sibling #GNode to place @node before.
        ///     If sibling is %NULL, the node is inserted as the last child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert_before /* */(
            System.IntPtr parent /* transfer-ownership:none */,
            System.IntPtr sibling /* transfer-ownership:none */,
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Inserts a #GNode beneath the parent before the given sibling.
        /// </summary>
        /// <param name="sibling">
        /// the sibling #GNode to place @node before.
        ///     If sibling is %NULL, the node is inserted as the last child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node InsertBefore(
            GISharp.GLib.Node sibling,
            GISharp.GLib.Node node)
        {
            if (sibling == null)
            {
                throw new System.ArgumentNullException("sibling");
            }
            if (node == null)
            {
                throw new System.ArgumentNullException("node");
            }
            var siblingPtr = default(System.IntPtr);
            var nodePtr = default(System.IntPtr);
            var retPtr = g_node_insert_before(Handle, siblingPtr, nodePtr);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Returns %TRUE if @node is an ancestor of @descendant.
        /// This is true if node is the parent of @descendant,
        /// or if node is the grandparent of @descendant etc.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="descendant">
        /// a #GNode
        /// </param>
        /// <returns>
        /// %TRUE if @node is an ancestor of @descendant
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_node_is_ancestor /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */,
            System.IntPtr descendant /* transfer-ownership:none */);

        /// <summary>
        /// Returns %TRUE if @node is an ancestor of @descendant.
        /// This is true if node is the parent of @descendant,
        /// or if node is the grandparent of @descendant etc.
        /// </summary>
        /// <param name="descendant">
        /// a #GNode
        /// </param>
        /// <returns>
        /// %TRUE if @node is an ancestor of @descendant
        /// </returns>
        public System.Boolean IsAncestor(
            GISharp.GLib.Node descendant)
        {
            if (descendant == null)
            {
                throw new System.ArgumentNullException("descendant");
            }
            var descendantPtr = default(System.IntPtr);
            var ret = g_node_is_ancestor(Handle, descendantPtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Gets the last child of a #GNode.
        /// </summary>
        /// <param name="node">
        /// a #GNode (must not be %NULL)
        /// </param>
        /// <returns>
        /// the last child of @node, or %NULL if @node has no children
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_last_child /* */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the last child of a #GNode.
        /// </summary>
        /// <returns>
        /// the last child of @node, or %NULL if @node has no children
        /// </returns>
        public GISharp.GLib.Node LastChild()
        {
            var retPtr = g_node_last_child(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the last sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the last sibling of @node
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_last_sibling /* */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the last sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <returns>
        /// the last sibling of @node
        /// </returns>
        public GISharp.GLib.Node LastSibling()
        {
            var retPtr = g_node_last_sibling(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the maximum height of all branches beneath a #GNode.
        /// This is the maximum distance from the #GNode to all leaf nodes.
        /// </summary>
        /// <remarks>
        /// If @root is %NULL, 0 is returned. If @root has no children,
        /// 1 is returned. If @root has children, 2 is returned. And so on.
        /// </remarks>
        /// <param name="root">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the maximum height of the tree beneath @root
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_max_height /* transfer-ownership:none */(
            System.IntPtr root /* transfer-ownership:none */);

        /// <summary>
        /// Gets the maximum height of all branches beneath a #GNode.
        /// This is the maximum distance from the #GNode to all leaf nodes.
        /// </summary>
        /// <remarks>
        /// If @root is %NULL, 0 is returned. If @root has no children,
        /// 1 is returned. If @root has children, 2 is returned. And so on.
        /// </remarks>
        /// <returns>
        /// the maximum height of the tree beneath @root
        /// </returns>
        public System.UInt32 MaxHeight()
        {
            var ret = g_node_max_height(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets the number of children of a #GNode.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the number of children of @node
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_n_children /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Gets the number of children of a #GNode.
        /// </summary>
        /// <returns>
        /// the number of children of @node
        /// </returns>
        public System.UInt32 NChildren()
        {
            var ret = g_node_n_children(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets the number of nodes in a tree.
        /// </summary>
        /// <param name="root">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be counted, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <returns>
        /// the number of nodes in the tree
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_n_nodes /* transfer-ownership:none */(
            System.IntPtr root /* transfer-ownership:none */,
            GISharp.GLib.TraverseFlags flags /* transfer-ownership:none */);

        /// <summary>
        /// Gets the number of nodes in a tree.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be counted, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <returns>
        /// the number of nodes in the tree
        /// </returns>
        public System.UInt32 NNodes(
            GISharp.GLib.TraverseFlags flags)
        {
            var ret = g_node_n_nodes(Handle, flags);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets a child of a #GNode, using the given index.
        /// The first child is at index 0. If the index is
        /// too big, %NULL is returned.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="n">
        /// the index of the desired child
        /// </param>
        /// <returns>
        /// the child of @node at index @n
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_nth_child /* */(
            System.IntPtr node /* transfer-ownership:none */,
            System.UInt32 n /* transfer-ownership:none */);

        /// <summary>
        /// Gets a child of a #GNode, using the given index.
        /// The first child is at index 0. If the index is
        /// too big, %NULL is returned.
        /// </summary>
        /// <param name="n">
        /// the index of the desired child
        /// </param>
        /// <returns>
        /// the child of @node at index @n
        /// </returns>
        public GISharp.GLib.Node NthChild(
            System.UInt32 n)
        {
            var retPtr = g_node_nth_child(Handle, n);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode as the first child of the given parent.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place the new #GNode under
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_prepend /* */(
            System.IntPtr parent /* transfer-ownership:none */,
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Inserts a #GNode as the first child of the given parent.
        /// </summary>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node Prepend(
            GISharp.GLib.Node node)
        {
            if (node == null)
            {
                throw new System.ArgumentNullException("node");
            }
            var nodePtr = default(System.IntPtr);
            var retPtr = g_node_prepend(Handle, nodePtr);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Reverses the order of the children of a #GNode.
        /// (It doesn't change the order of the grandchildren.)
        /// </summary>
        /// <param name="node">
        /// a #GNode.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_node_reverse_children /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Reverses the order of the children of a #GNode.
        /// (It doesn't change the order of the grandchildren.)
        /// </summary>
        public void ReverseChildren()
        {
            g_node_reverse_children(Handle);
        }

        /// <summary>
        /// Traverses a tree starting at the given root #GNode.
        /// It calls the given function for each node visited.
        /// The traversal can be halted at any point by returning %TRUE from @func.
        /// </summary>
        /// <param name="root">
        /// the root #GNode of the tree to traverse
        /// </param>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER.
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="maxDepth">
        /// the maximum depth of the traversal. Nodes below this
        ///     depth will not be visited. If max_depth is -1 all nodes in
        ///     the tree are visited. If depth is 1, only the root is visited.
        ///     If depth is 2, the root and its children are visited. And so on.
        /// </param>
        /// <param name="func">
        /// the function to call for each visited #GNode
        /// </param>
        /// <param name="data">
        /// user data to pass to the function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_node_traverse /* transfer-ownership:none */(
            System.IntPtr root /* transfer-ownership:none */,
            GISharp.GLib.TraverseType order /* transfer-ownership:none */,
            GISharp.GLib.TraverseFlags flags /* transfer-ownership:none */,
            System.Int32 maxDepth /* transfer-ownership:none */,
            GISharp.GLib.NodeTraverseFunc func /* transfer-ownership:none closure:4 */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Traverses a tree starting at the given root #GNode.
        /// It calls the given function for each node visited.
        /// The traversal can be halted at any point by returning %TRUE from @func.
        /// </summary>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER.
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="maxDepth">
        /// the maximum depth of the traversal. Nodes below this
        ///     depth will not be visited. If max_depth is -1 all nodes in
        ///     the tree are visited. If depth is 1, only the root is visited.
        ///     If depth is 2, the root and its children are visited. And so on.
        /// </param>
        /// <param name="func">
        /// the function to call for each visited #GNode
        /// </param>
        public void Traverse(
            GISharp.GLib.TraverseType order,
            GISharp.GLib.TraverseFlags flags,
            System.Int32 maxDepth,
            GISharp.GLib.NodeTraverseFuncCallback func)
        {
            if (func == null)
            {
                throw new System.ArgumentNullException("func");
            }
            var data = default(System.IntPtr);
            var funcNative = default(GISharp.GLib.NodeTraverseFunc);
            g_node_traverse(Handle, order, flags, maxDepth, funcNative, data);
        }

        /// <summary>
        /// Unlinks a #GNode from a tree, resulting in two separate trees.
        /// </summary>
        /// <param name="node">
        /// the #GNode to unlink, which becomes the root of a new tree
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_node_unlink /* transfer-ownership:none */(
            System.IntPtr node /* transfer-ownership:none */);

        /// <summary>
        /// Unlinks a #GNode from a tree, resulting in two separate trees.
        /// </summary>
        public void Unlink()
        {
            g_node_unlink(Handle);
        }
    }

    /// <summary>
    /// Specifies the type of function passed to g_node_children_foreach().
    /// The function is called with each child node, together with the user
    /// data passed to g_node_children_foreach().
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void NodeForeachFunc(
        System.IntPtr node /* transfer-ownership:none */,
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// Specifies the type of function passed to g_node_children_foreach().
    /// The function is called with each child node, together with the user
    /// data passed to g_node_children_foreach().
    /// </summary>
    public delegate void NodeForeachFuncCallback(
        GISharp.GLib.Node node,
        System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_node_traverse(). The
    /// function is called with each of the nodes visited, together with the
    /// user data passed to g_node_traverse(). If the function returns
    /// %TRUE, then the traversal is stopped.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.Boolean NodeTraverseFunc(
        System.IntPtr node /* transfer-ownership:none */,
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// Specifies the type of function passed to g_node_traverse(). The
    /// function is called with each of the nodes visited, together with the
    /// user data passed to g_node_traverse(). If the function returns
    /// %TRUE, then the traversal is stopped.
    /// </summary>
    public delegate System.Boolean NodeTraverseFuncCallback(
        GISharp.GLib.Node node,
        System.IntPtr data);

    /// <summary>
    /// Represents a file descriptor, which events to poll for, and which events
    /// occurred.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct PollFD
    {
        /// <summary>
        /// the file descriptor to poll (or a HANDLE on Win32)
        /// </summary>
        public System.Int32 Fd;

        /// <summary>
        /// a bitwise combination from #GIOCondition, specifying which
        ///     events should be polled for. Typically for reading from a file
        ///     descriptor you would use %G_IO_IN | %G_IO_HUP | %G_IO_ERR, and
        ///     for writing you would use %G_IO_OUT | %G_IO_ERR.
        /// </summary>
        public System.UInt16 Events;

        /// <summary>
        /// a bitwise combination of flags from #GIOCondition, returned
        ///     from the poll() function to indicate which events occurred.
        /// </summary>
        public System.UInt16 Revents;
    }

    /// <summary>
    /// Specifies the type of function passed to g_main_context_set_poll_func().
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.Int32 PollFunc(
        GISharp.GLib.PollFD ufds /* transfer-ownership:none */,
        System.UInt32 nfsd /* transfer-ownership:none */,
        System.Int32 timeout /* transfer-ownership:none */);

    /// <summary>
    /// Specifies the type of function passed to g_main_context_set_poll_func().
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    public delegate System.Int32 PollFuncCallback(
        GISharp.GLib.PollFD ufds,
        System.UInt32 nfsd,
        System.Int32 timeout);

    /// <summary>
    /// An enumeration specifying the base position for a
    /// g_io_channel_seek_position() operation.
    /// </summary>
    public enum SeekType
    {
        /// <summary>
        /// the current position in the file.
        /// </summary>
        Cur = 0,
        /// <summary>
        /// the start of the file.
        /// </summary>
        Set = 1,
        /// <summary>
        /// the end of the file.
        /// </summary>
        End = 2
    }

    /// <summary>
    /// The `GSource` struct is an opaque data type
    /// representing an event source.
    /// </summary>
    public partial class Source : GISharp.Core.ReferenceCountedOpaque<Source>
    {
        /// <summary>
        /// Use this macro as the return value of a #GSourceFunc to leave
        /// the #GSource in the main loop.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        public const System.Boolean Continue = true;

        /// <summary>
        /// Use this macro as the return value of a #GSourceFunc to remove
        /// the #GSource from the main loop.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.32")]
        public const System.Boolean Remove = false;

        /// <summary>
        /// Creates a new #GSource structure. The size is specified to
        /// allow creating structures derived from #GSource that contain
        /// additional data. The size passed in must be at least
        /// `sizeof (GSource)`.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement
        ///                the sources behavior.
        /// </param>
        /// <param name="structSize">
        /// size of the #GSource structure to create.
        /// </param>
        /// <returns>
        /// the newly-created #GSource.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_new /* transfer-ownership:full */(
            GISharp.GLib.SourceFuncs sourceFuncs /* transfer-ownership:none */,
            System.UInt32 structSize /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GSource structure. The size is specified to
        /// allow creating structures derived from #GSource that contain
        /// additional data. The size passed in must be at least
        /// `sizeof (GSource)`.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement
        ///                the sources behavior.
        /// </param>
        /// <param name="structSize">
        /// size of the #GSource structure to create.
        /// </param>
        /// <returns>
        /// the newly-created #GSource.
        /// </returns>
        public Source(
            GISharp.GLib.SourceFuncs sourceFuncs,
            System.UInt32 structSize)
        {
            Handle = g_source_new(sourceFuncs, structSize);
        }

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a #GSource is given by g_source_get_id(), or will be
        /// returned by the functions g_source_attach(), g_idle_add(),
        /// g_idle_add_full(), g_timeout_add(), g_timeout_add_full(),
        /// g_child_watch_add(), g_child_watch_add_full(), g_io_add_watch(), and
        /// g_io_add_watch_full().
        /// 
        /// See also g_source_destroy(). You must use g_source_destroy() for sources
        /// added to a non-default main context.
        /// 
        /// It is a programmer error to attempt to remove a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// the ID of the source to remove.
        /// </param>
        /// <returns>
        /// For historical reasons, this function always returns %TRUE
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove /* transfer-ownership:none */(
            System.UInt32 tag /* transfer-ownership:none */);

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a #GSource is given by g_source_get_id(), or will be
        /// returned by the functions g_source_attach(), g_idle_add(),
        /// g_idle_add_full(), g_timeout_add(), g_timeout_add_full(),
        /// g_child_watch_add(), g_child_watch_add_full(), g_io_add_watch(), and
        /// g_io_add_watch_full().
        /// 
        /// See also g_source_destroy(). You must use g_source_destroy() for sources
        /// added to a non-default main context.
        /// 
        /// It is a programmer error to attempt to remove a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// the ID of the source to remove.
        /// </param>
        /// <returns>
        /// For historical reasons, this function always returns %TRUE
        /// </returns>
        public static System.Boolean RemoveByTag(
            System.UInt32 tag)
        {
            var ret = g_source_remove(tag);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes a source from the default main loop context given the
        /// source functions and user data. If multiple sources exist with the
        /// same source functions and user data, only one will be destroyed.
        /// </summary>
        /// <param name="funcs">
        /// The @source_funcs passed to g_source_new()
        /// </param>
        /// <param name="userData">
        /// the user data for the callback
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove_by_funcs_user_data /* transfer-ownership:none */(
            GISharp.GLib.SourceFuncs funcs /* transfer-ownership:none */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Removes a source from the default main loop context given the
        /// source functions and user data. If multiple sources exist with the
        /// same source functions and user data, only one will be destroyed.
        /// </summary>
        /// <param name="funcs">
        /// The @source_funcs passed to g_source_new()
        /// </param>
        /// <param name="userData">
        /// the user data for the callback
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByFuncsUserData(
            GISharp.GLib.SourceFuncs funcs,
            System.IntPtr userData)
        {
            var ret = g_source_remove_by_funcs_user_data(funcs, userData);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes a source from the default main loop context given the user
        /// data for the callback. If multiple sources exist with the same user
        /// data, only one will be destroyed.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove_by_user_data /* transfer-ownership:none */(
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Removes a source from the default main loop context given the user
        /// data for the callback. If multiple sources exist with the same user
        /// data, only one will be destroyed.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByUserData(
            System.IntPtr userData)
        {
            var ret = g_source_remove_by_user_data(userData);
            return default(System.Boolean);
        }

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of g_idle_add(), g_timeout_add(), etc.
        /// 
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a #GSource ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_name_by_id /* transfer-ownership:none */(
            System.UInt32 tag /* transfer-ownership:none */,
            System.IntPtr name /* transfer-ownership:none */);

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of g_idle_add(), g_timeout_add(), etc.
        /// 
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a #GSource ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        public static void SetNameById(
            System.UInt32 tag,
            System.String name)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name");
            }
            var namePtr = default(System.IntPtr);
            g_source_set_name_by_id(tag, namePtr);
        }

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or %NULL.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_current_source /* transfer-ownership:none */();

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or %NULL.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        public static GISharp.GLib.Source MainCurrentSource()
        {
            var retPtr = g_main_current_source();
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Adds @child_source to @source as a "polled" source; when @source is
        /// added to a #GMainContext, @child_source will be automatically added
        /// with the same priority, when @child_source is triggered, it will
        /// cause @source to dispatch (in addition to calling its own
        /// callback), and when @source is destroyed, it will destroy
        /// @child_source as well. (@source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need @child_source to do anything on its own when it
        /// triggers, you can call g_source_set_dummy_callback() on it to set a
        /// callback that does nothing (except return %TRUE if appropriate).
        /// 
        /// @source will hold a reference on @child_source while @child_source
        /// is attached to it.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a second #GSource that @source should "poll"
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_add_child_source /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr childSource /* transfer-ownership:none */);

        /// <summary>
        /// Adds @child_source to @source as a "polled" source; when @source is
        /// added to a #GMainContext, @child_source will be automatically added
        /// with the same priority, when @child_source is triggered, it will
        /// cause @source to dispatch (in addition to calling its own
        /// callback), and when @source is destroyed, it will destroy
        /// @child_source as well. (@source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need @child_source to do anything on its own when it
        /// triggers, you can call g_source_set_dummy_callback() on it to set a
        /// callback that does nothing (except return %TRUE if appropriate).
        /// 
        /// @source will hold a reference on @child_source while @child_source
        /// is attached to it.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a second #GSource that @source should "poll"
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        public void AddChildSource(
            GISharp.GLib.Source childSource)
        {
            if (childSource == null)
            {
                throw new System.ArgumentNullException("childSource");
            }
            var childSourcePtr = default(System.IntPtr);
            g_source_add_child_source(Handle, childSourcePtr);
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with g_source_new() to add an
        /// event source. The event source's check function will typically test
        /// the @revents field in the #GPollFD struct and return %TRUE if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// g_source_add_unix_fd() instead of this API.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_add_poll /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            GISharp.GLib.PollFD fd /* transfer-ownership:none */);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with g_source_new() to add an
        /// event source. The event source's check function will typically test
        /// the @revents field in the #GPollFD struct and return %TRUE if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// g_source_add_unix_fd() instead of this API.
        /// </remarks>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        public void AddPoll(
            GISharp.GLib.PollFD fd)
        {
            g_source_add_poll(Handle, fd);
        }

        /// <summary>
        /// Adds a #GSource to a @context so that it will be executed within
        /// that context. Remove it by calling g_source_destroy().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        ///   #GMainContext.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_source_attach /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr context /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Adds a #GSource to a @context so that it will be executed within
        /// that context. Remove it by calling g_source_destroy().
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        ///   #GMainContext.
        /// </returns>
        public System.UInt32 Attach(
            GISharp.GLib.MainContext context)
        {
            var contextPtr = default(System.IntPtr);
            var ret = g_source_attach(Handle, contextPtr);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_destroy /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        public void Destroy()
        {
            g_source_destroy(Handle);
        }

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_source_get_can_recurse /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        public System.Boolean CanRecurse
        {
            get
            {
                var ret = g_source_get_can_recurse(Handle);
                return default(System.Boolean);
            }

            set
            {
                g_source_set_can_recurse(Handle, value);
            }
        }

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_get_context /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        public GISharp.GLib.MainContext Context
        {
            get
            {
                var retPtr = g_source_get_context(Handle);
                return default(GISharp.GLib.MainContext);
            }
        }

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by g_main_context_find_source_by_id().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_source_get_id /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by g_main_context_find_source_by_id().
        /// </summary>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        public System.UInt32 Id
        {
            get
            {
                var ret = g_source_get_id(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the name of the source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_get_name /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <returns>
        /// the name of the source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.String Name
        {
            get
            {
                var retPtr = g_source_get_name(Handle);
                return default(System.String);
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }
                var valuePtr = default(System.IntPtr);
                g_source_set_name(Handle, valuePtr);
            }
        }

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the priority of the source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_source_get_priority /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <returns>
        /// the priority of the source
        /// </returns>
        public System.Int32 Priority
        {
            get
            {
                var ret = g_source_get_priority(Handle);
                return default(System.Int32);
            }

            set
            {
                g_source_set_priority(Handle, value);
            }
        }

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int64 g_source_get_ready_time /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        public System.Int64 ReadyTime
        {
            get
            {
                var ret = g_source_get_ready_time(Handle);
                return default(System.Int64);
            }

            set
            {
                g_source_set_ready_time(Handle, value);
            }
        }

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int64 g_source_get_time /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [GISharp.Core.SinceAttribute("2.28")]
        public System.Int64 Time
        {
            get
            {
                var ret = g_source_get_time(Handle);
                return default(System.Int64);
            }
        }

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///    
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///    
        ///   return G_SOURCE_REMOVE;
        /// }
        ///  
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///  
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///    
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///    
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        /// 
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///   
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///   
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_source_is_destroyed /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///    
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///    
        ///   return G_SOURCE_REMOVE;
        /// }
        ///  
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///  
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///    
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///    
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        /// 
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///   
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///   
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.12")]
        public System.Boolean IsDestroyed
        {
            get
            {
                var ret = g_source_is_destroyed(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Increases the reference count on a source by one.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// @source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on a source by one.
        /// </summary>
        protected override void Ref()
        {
            g_source_ref(Handle);
        }

        /// <summary>
        /// Detaches @child_source from @source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a #GSource previously passed to
        ///     g_source_add_child_source().
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_remove_child_source /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr childSource /* transfer-ownership:none */);

        /// <summary>
        /// Detaches @child_source from @source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a #GSource previously passed to
        ///     g_source_add_child_source().
        /// </param>
        [GISharp.Core.SinceAttribute("2.28")]
        public void RemoveChildSource(
            GISharp.GLib.Source childSource)
        {
            if (childSource == null)
            {
                throw new System.ArgumentNullException("childSource");
            }
            var childSourcePtr = default(System.IntPtr);
            g_source_remove_child_source(Handle, childSourcePtr);
        }

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_remove_poll /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            GISharp.GLib.PollFD fd /* transfer-ownership:none */);

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        public void RemovePoll(
            GISharp.GLib.PollFD fd)
        {
            g_source_remove_poll(Handle, fd);
        }

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [GISharp.Core.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_remove_unix_fd /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr tag /* transfer-ownership:none */);

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [GISharp.Core.SinceAttribute("2.36")]
        public void RemoveUnixFd(
            System.IntPtr tag)
        {
            g_source_remove_unix_fd(Handle, tag);
        }

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        /// 
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="func">
        /// a callback function
        /// </param>
        /// <param name="data">
        /// the data to pass to callback function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_callback /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc func /* transfer-ownership:none scope:notified closure:1 destroy:2 */,
            System.IntPtr data /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none nullable:1 allow-none:1 scope:async */);

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        /// 
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="func">
        /// a callback function
        /// </param>
        public void SetCallback(
            GISharp.GLib.SourceFuncCallback func)
        {
            if (func == null)
            {
                throw new System.ArgumentNullException("func");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var data = default(System.IntPtr);
            var funcNative = default(GISharp.GLib.SourceFunc);
            g_source_set_callback(Handle, funcNative, data, notifyNative);
        }

        /// <summary>
        /// Sets the callback function storing the data as a refcounted callback
        /// "object". This is used internally. Note that calling
        /// g_source_set_callback_indirect() assumes
        /// an initial reference count on @callback_data, and thus
        /// @callback_funcs-&gt;unref will eventually be called once more
        /// than @callback_funcs-&gt;ref.
        /// </summary>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="callbackData">
        /// pointer to callback data "object"
        /// </param>
        /// <param name="callbackFuncs">
        /// functions for reference counting @callback_data
        ///                  and getting the callback and data
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_callback_indirect /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr callbackData /* transfer-ownership:none */,
            GISharp.GLib.SourceCallbackFuncs callbackFuncs /* transfer-ownership:none */);

        /// <summary>
        /// Sets the callback function storing the data as a refcounted callback
        /// "object". This is used internally. Note that calling
        /// g_source_set_callback_indirect() assumes
        /// an initial reference count on @callback_data, and thus
        /// @callback_funcs-&gt;unref will eventually be called once more
        /// than @callback_funcs-&gt;ref.
        /// </summary>
        /// <param name="callbackData">
        /// pointer to callback data "object"
        /// </param>
        /// <param name="callbackFuncs">
        /// functions for reference counting @callback_data
        ///                  and getting the callback and data
        /// </param>
        public void SetCallbackIndirect(
            System.IntPtr callbackData,
            GISharp.GLib.SourceCallbackFuncs callbackFuncs)
        {
            g_source_set_callback_indirect(Handle, callbackData, callbackFuncs);
        }

        /// <summary>
        /// Sets whether a source can be called recursively. If @can_recurse is
        /// %TRUE, then while the source is being dispatched then this source
        /// will be processed normally. Otherwise, all processing of this
        /// source is blocked until the dispatch function returns.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="canRecurse">
        /// whether recursion is allowed for this source
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_can_recurse /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.Boolean canRecurse /* transfer-ownership:none */);

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_funcs /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            GISharp.GLib.SourceFuncs funcs /* transfer-ownership:none */);

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [GISharp.Core.SinceAttribute("2.12")]
        public void SetFuncs(
            GISharp.GLib.SourceFuncs funcs)
        {
            g_source_set_funcs(Handle, funcs);
        }

        /// <summary>
        /// Sets a name for the source, used in debugging and profiling.
        /// The name defaults to #NULL.
        /// </summary>
        /// <remarks>
        /// The source name should describe in a human-readable way
        /// what the source does. For example, "X11 event queue"
        /// or "GTK+ repaint idle handler" or whatever it is.
        /// 
        /// It is permitted to call this function multiple times, but is not
        /// recommended due to the potential performance impact.  For example,
        /// one could change the name in the "check" function of a #GSourceFuncs
        /// to include details like the event type in the source name.
        /// 
        /// Use caution if changing the name while another thread may be
        /// accessing it with g_source_get_name(); that function does not copy
        /// the value, and changing the value will free it while the other thread
        /// may be attempting to use it.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_name /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.IntPtr name /* transfer-ownership:none */);

        /// <summary>
        /// Sets the priority of a source. While the main loop is being run, a
        /// source will be dispatched if it is ready to be dispatched and no
        /// sources at a higher (numerically smaller) priority are ready to be
        /// dispatched.
        /// </summary>
        /// <remarks>
        /// A child source always has the same priority as its parent.  It is not
        /// permitted to change the priority of a source once it has been added
        /// as a child of another source.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="priority">
        /// the new priority.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_priority /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.Int32 priority /* transfer-ownership:none */);

        /// <summary>
        /// Sets a #GSource to be dispatched when the given monotonic time is
        /// reached (or passed).  If the monotonic time is in the past (as it
        /// always will be if @ready_time is 0) then the source will be
        /// dispatched immediately.
        /// </summary>
        /// <remarks>
        /// If @ready_time is -1 then the source is never woken up on the basis
        /// of the passage of time.
        /// 
        /// Dispatching the source does not reset the ready time.  You should do
        /// so yourself, from the source dispatch function.
        /// 
        /// Note that if you have a pair of sources where the ready time of one
        /// suggests that it will be delivered first but the priority for the
        /// other suggests that it would be delivered first, and the ready time
        /// for both sources is reached during the same main context iteration
        /// then the order of dispatch is undefined.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="readyTime">
        /// the monotonic time at which the source will be ready,
        ///              0 for "immediately", -1 for "never"
        /// </param>
        [GISharp.Core.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_set_ready_time /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */,
            System.Int64 readyTime /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count of a source by one. If the
        /// resulting reference count is zero the source and associated
        /// memory will be destroyed.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_source_unref /* transfer-ownership:none */(
            System.IntPtr source /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count of a source by one. If the
        /// resulting reference count is zero the source and associated
        /// memory will be destroyed.
        /// </summary>
        protected override void Unref()
        {
            g_source_unref(Handle);
        }
    }

    /// <summary>
    /// The `GSourceCallbackFuncs` struct contains
    /// functions for managing callback objects.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct SourceCallbackFuncs
    {
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void RefCallback(
System.IntPtr cbData /* transfer-ownership:none */);

        public delegate void RefCallbackCallback(
System.IntPtr cbData);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public RefCallback Ref;

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void UnrefCallback(
System.IntPtr cbData /* transfer-ownership:none */);

        public delegate void UnrefCallbackCallback(
System.IntPtr cbData);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public UnrefCallback Unref;

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void GetCallback(
System.IntPtr cbData /* transfer-ownership:none */,
System.IntPtr source /* transfer-ownership:none */,
GISharp.GLib.SourceFunc func /* transfer-ownership:none closure:3 */,
System.IntPtr data /* transfer-ownership:none */);

        public delegate void GetCallbackCallback(
System.IntPtr cbData,
GISharp.GLib.Source source,
GISharp.GLib.SourceFuncCallback func);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public GetCallback Get;
    }

    /// <summary>
    /// This is just a placeholder for #GClosureMarshal,
    /// which cannot be used here for dependency reasons.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void SourceDummyMarshal();

    /// <summary>
    /// This is just a placeholder for #GClosureMarshal,
    /// which cannot be used here for dependency reasons.
    /// </summary>
    public delegate void SourceDummyMarshalCallback();

    /// <summary>
    /// Specifies the type of function passed to g_timeout_add(),
    /// g_timeout_add_full(), g_idle_add(), and g_idle_add_full().
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.Boolean SourceFunc(
        System.IntPtr userData /* transfer-ownership:none closure:0 */);

    /// <summary>
    /// Specifies the type of function passed to g_timeout_add(),
    /// g_timeout_add_full(), g_idle_add(), and g_idle_add_full().
    /// </summary>
    public delegate System.Boolean SourceFuncCallback();

    /// <summary>
    /// The `GSourceFuncs` struct contains a table of
    /// functions used to handle event sources in a generic manner.
    /// </summary>
    /// <remarks>
    /// For idle sources, the prepare and check functions always return %TRUE
    /// to indicate that the source is always ready to be processed. The prepare
    /// function also returns a timeout value of 0 to ensure that the poll() call
    /// doesn't block (since that would be time wasted which could have been spent
    /// running the idle function).
    /// 
    /// For timeout sources, the prepare and check functions both return %TRUE
    /// if the timeout interval has expired. The prepare function also returns
    /// a timeout value to ensure that the poll() call doesn't block too long
    /// and miss the next timeout.
    /// 
    /// For file descriptor sources, the prepare function typically returns %FALSE,
    /// since it must wait until poll() has been called before it knows whether
    /// any events need to be processed. It sets the returned timeout to -1 to
    /// indicate that it doesn't mind how long the poll() call blocks. In the
    /// check function, it tests the results of the poll() call to see if the
    /// required condition has been met, and returns %TRUE if so.
    /// </remarks>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct SourceFuncs
    {
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.Boolean PrepareCallback(
System.IntPtr source /* transfer-ownership:none */,
System.Int32 timeout /* transfer-ownership:none */);

        public delegate System.Boolean PrepareCallbackCallback(
GISharp.GLib.Source source,
System.Int32 timeout);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public PrepareCallback Prepare;

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.Boolean CheckCallback(
System.IntPtr source /* transfer-ownership:none */);

        public delegate System.Boolean CheckCallbackCallback(
GISharp.GLib.Source source);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public CheckCallback Check;

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.Boolean DispatchCallback(
System.IntPtr source /* transfer-ownership:none */,
GISharp.GLib.SourceFunc callback /* transfer-ownership:none closure:2 */,
System.IntPtr userData /* transfer-ownership:none closure:2 */);

        public delegate System.Boolean DispatchCallbackCallback(
GISharp.GLib.Source source,
GISharp.GLib.SourceFuncCallback callback);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public DispatchCallback Dispatch;

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void FinalizeCallback(
System.IntPtr source /* transfer-ownership:none */);

        public delegate void FinalizeCallbackCallback(
GISharp.GLib.Source source);

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)]
        public FinalizeCallback Finalize;
        public GISharp.GLib.SourceFunc ClosureCallback;
        public GISharp.GLib.SourceDummyMarshal ClosureMarshal;
    }

    /// <summary>
    /// Disambiguates a given time in two ways.
    /// </summary>
    /// <remarks>
    /// First, specifies if the given time is in universal or local time.
    /// 
    /// Second, if the time is in local time, specifies if it is local
    /// standard time or local daylight time.  This is important for the case
    /// where the same local time occurs twice (during daylight savings time
    /// transitions, for example).
    /// </remarks>
    public enum TimeType
    {
        /// <summary>
        /// the time is in local standard time
        /// </summary>
        Standard = 0,
        /// <summary>
        /// the time is in local daylight time
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// the time is in UTC
        /// </summary>
        Universal = 2
    }

    /// <summary>
    /// #GTimeZone is an opaque structure whose members cannot be accessed
    /// directly.
    /// </summary>
    [GISharp.Core.SinceAttribute("2.26")]
    public partial class TimeZone : GISharp.Core.ReferenceCountedOpaque<TimeZone>
    {
        /// <summary>
        /// Creates a #GTimeZone corresponding to @identifier.
        /// </summary>
        /// <remarks>
        /// @identifier can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including %NULL).
        /// 
        /// In Windows, @identifier can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// g_time_zone_new_local() calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if @identifier is %NULL then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new /* transfer-ownership:full */(
            System.IntPtr identifier /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Creates a #GTimeZone corresponding to @identifier.
        /// </summary>
        /// <remarks>
        /// @identifier can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including %NULL).
        /// 
        /// In Windows, @identifier can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// g_time_zone_new_local() calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if @identifier is %NULL then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public TimeZone(
            System.String identifier)
        {
            var identifierPtr = default(System.IntPtr);
            Handle = g_time_zone_new(identifierPtr);
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with the value of
        /// the `TZ` environment variable (including the possibility of %NULL).
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new_local /* transfer-ownership:full */();

        /// <summary>
        /// Creates a #GTimeZone corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with the value of
        /// the `TZ` environment variable (including the possibility of %NULL).
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.TimeZone Local()
        {
            var retPtr = g_time_zone_new_local();
            return default(GISharp.GLib.TimeZone);
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new_utc /* transfer-ownership:full */();

        /// <summary>
        /// Creates a #GTimeZone corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public static GISharp.GLib.TimeZone Utc()
        {
            var retPtr = g_time_zone_new_utc();
            return default(GISharp.GLib.TimeZone);
        }

        /// <summary>
        /// Finds an interval within @tz that corresponds to the given @time_,
        /// possibly adjusting @time_ if required to fit into an interval.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_time_zone_find_interval(), with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where g_time_zone_find_interval() succeeds then
        /// this function returns the same value, without modifying @time_.
        /// 
        /// This function may, however, modify @time_ in order to deal with
        /// non-existent times.  If the non-existent local @time_ of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust @time_ to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, never -1
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_adjust_time /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */,
            GISharp.GLib.TimeType type /* transfer-ownership:none */,
            System.Int64 time /* transfer-ownership:none */);

        /// <summary>
        /// Finds an interval within @tz that corresponds to the given @time_,
        /// possibly adjusting @time_ if required to fit into an interval.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_time_zone_find_interval(), with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where g_time_zone_find_interval() succeeds then
        /// this function returns the same value, without modifying @time_.
        /// 
        /// This function may, however, modify @time_ in order to deal with
        /// non-existent times.  If the non-existent local @time_ of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust @time_ to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, never -1
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 AdjustTime(
            GISharp.GLib.TimeType type,
            System.Int64 time)
        {
            var ret = g_time_zone_adjust_time(Handle, type, time);
            return default(System.Int32);
        }

        /// <summary>
        /// Finds an the interval within @tz that corresponds to the given @time_.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// If @type is %G_TIME_TYPE_UNIVERSAL then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise @time_ is treated as local time.  The distinction between
        /// %G_TIME_TYPE_STANDARD and %G_TIME_TYPE_DAYLIGHT is ignored except in
        /// the case that the given @time_ is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of @type would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, or -1 in case of failure
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_find_interval /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */,
            GISharp.GLib.TimeType type /* transfer-ownership:none */,
            System.Int64 time /* transfer-ownership:none */);

        /// <summary>
        /// Finds an the interval within @tz that corresponds to the given @time_.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// If @type is %G_TIME_TYPE_UNIVERSAL then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise @time_ is treated as local time.  The distinction between
        /// %G_TIME_TYPE_STANDARD and %G_TIME_TYPE_DAYLIGHT is ignored except in
        /// the case that the given @time_ is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of @type would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, or -1 in case of failure
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 FindInterval(
            GISharp.GLib.TimeType type,
            System.Int64 time)
        {
            var ret = g_time_zone_find_interval(Handle, type, time);
            return default(System.Int32);
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to @tz
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_get_abbreviation /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */,
            System.Int32 interval /* transfer-ownership:none */);

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to @tz
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.String GetAbbreviation(
            System.Int32 interval)
        {
            var retPtr = g_time_zone_get_abbreviation(Handle, interval);
            return default(System.String);
        }

        /// <summary>
        /// Determines the offset to UTC in effect during a particular @interval
        /// of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for @tz (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in @tz
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_get_offset /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */,
            System.Int32 interval /* transfer-ownership:none */);

        /// <summary>
        /// Determines the offset to UTC in effect during a particular @interval
        /// of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for @tz (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in @tz
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 GetOffset(
            System.Int32 interval)
        {
            var ret = g_time_zone_get_offset(Handle, interval);
            return default(System.Int32);
        }

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_time_zone_is_dst /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */,
            System.Int32 interval /* transfer-ownership:none */);

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Boolean IsDst(
            System.Int32 interval)
        {
            var ret = g_time_zone_is_dst(Handle, interval);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new reference to @tz.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr tz /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on @tz.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        protected override void Ref()
        {
            g_time_zone_ref(Handle);
        }

        /// <summary>
        /// Decreases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_time_zone_unref /* transfer-ownership:none */(
            System.IntPtr tz /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count on @tz.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.26")]
        protected override void Unref()
        {
            g_time_zone_unref(Handle);
        }
    }

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.String TranslateFunc(
        System.IntPtr str /* transfer-ownership:none */,
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    public delegate System.String TranslateFuncCallback(
        System.String str,
        System.IntPtr data);

    /// <summary>
    /// Specifies which nodes are visited during several of the tree
    /// functions, including g_node_traverse() and g_node_find().
    /// </summary>
    [System.FlagsAttribute]
    public enum TraverseFlags
    {
        /// <summary>
        /// only leaf nodes should be visited. This name has
        ///                     been introduced in 2.6, for older version use
        ///                     %G_TRAVERSE_LEAFS.
        /// </summary>
        Leaves = 1,
        /// <summary>
        /// only non-leaf nodes should be visited. This
        ///                         name has been introduced in 2.6, for older
        ///                         version use %G_TRAVERSE_NON_LEAFS.
        /// </summary>
        NonLeaves = 2,
        /// <summary>
        /// all nodes should be visited.
        /// </summary>
        All = 3,
        /// <summary>
        /// a mask of all traverse flags.
        /// </summary>
        Mask = 3,
        /// <summary>
        /// identical to %G_TRAVERSE_LEAVES.
        /// </summary>
        Leafs = 1,
        /// <summary>
        /// identical to %G_TRAVERSE_NON_LEAVES.
        /// </summary>
        NonLeafs = 2
    }

    /// <summary>
    /// Specifies the type of function passed to g_tree_traverse(). It is
    /// passed the key and value of each node, together with the @user_data
    /// parameter passed to g_tree_traverse(). If the function returns
    /// %TRUE, the traversal is stopped.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.Boolean TraverseFunc(
        System.IntPtr key /* transfer-ownership:none */,
        System.IntPtr value /* transfer-ownership:none */,
        System.IntPtr data /* transfer-ownership:none */);

    /// <summary>
    /// Specifies the type of function passed to g_tree_traverse(). It is
    /// passed the key and value of each node, together with the @user_data
    /// parameter passed to g_tree_traverse(). If the function returns
    /// %TRUE, the traversal is stopped.
    /// </summary>
    public delegate System.Boolean TraverseFuncCallback(
        System.IntPtr key,
        System.IntPtr value,
        System.IntPtr data);

    /// <summary>
    /// Specifies the type of traveral performed by g_tree_traverse(),
    /// g_node_traverse() and g_node_find(). The different orders are
    /// illustrated here:
    /// - In order: A, B, C, D, E, F, G, H, I
    ///   ![](Sorted_binary_tree_inorder.svg)
    /// - Pre order: F, B, A, D, C, E, G, I, H
    ///   ![](Sorted_binary_tree_preorder.svg)
    /// - Post order: A, C, E, D, B, H, I, G, F
    ///   ![](Sorted_binary_tree_postorder.svg)
    /// - Level order: F, B, G, A, D, I, C, E, H
    ///   ![](Sorted_binary_tree_breadth-first_traversal.svg)
    /// </summary>
    public enum TraverseType
    {
        /// <summary>
        /// vists a node's left child first, then the node itself,
        ///              then its right child. This is the one to use if you
        ///              want the output sorted according to the compare
        ///              function.
        /// </summary>
        InOrder = 0,
        /// <summary>
        /// visits a node, then its children.
        /// </summary>
        PreOrder = 1,
        /// <summary>
        /// visits the node's children, then the node itself.
        /// </summary>
        PostOrder = 2,
        /// <summary>
        /// is not implemented for
        ///              [balanced binary trees][glib-Balanced-Binary-Trees].
        ///              For [n-ary trees][glib-N-ary-Trees], it
        ///              vists the root node first, then its children, then
        ///              its grandchildren, and so on. Note that this is less
        ///              efficient than the other orders.
        /// </summary>
        LevelOrder = 3
    }

    /// <summary>
    /// #GVariant is a variant datatype; it stores a value along with
    /// information about the type of that value.  The range of possible
    /// values is determined by the type.  The type system used by #GVariant
    /// is #GVariantType.
    /// </summary>
    /// <remarks>
    /// #GVariant instances always have a type and a value (which are given
    /// at construction time).  The type and value of a #GVariant instance
    /// can never change other than by the #GVariant itself being
    /// destroyed.  A #GVariant cannot contain a pointer.
    /// 
    /// #GVariant is reference counted using g_variant_ref() and
    /// g_variant_unref().  #GVariant also has floating reference counts --
    /// see g_variant_ref_sink().
    /// 
    /// #GVariant is completely threadsafe.  A #GVariant instance can be
    /// concurrently accessed in any way from any number of threads without
    /// problems.
    /// 
    /// #GVariant is heavily optimised for dealing with data in serialised
    /// form.  It works particularly well with data located in memory-mapped
    /// files.  It can perform nearly all deserialisation operations in a
    /// small constant time, usually touching only a single memory page.
    /// Serialised #GVariant data can also be sent over the network.
    /// 
    /// #GVariant is largely compatible with D-Bus.  Almost all types of
    /// #GVariant instances can be sent over D-Bus.  See #GVariantType for
    /// exceptions.  (However, #GVariant's serialisation format is not the same
    /// as the serialisation format of a D-Bus message body: use #GDBusMessage,
    /// in the gio library, for those.)
    /// 
    /// For space-efficiency, the #GVariant serialisation format does not
    /// automatically include the variant's length, type or endianness,
    /// which must either be implied from context (such as knowledge that a
    /// particular file format always contains a little-endian
    /// %G_VARIANT_TYPE_VARIANT which occupies the whole length of the file)
    /// or supplied out-of-band (for instance, a length, type and/or endianness
    /// indicator could be placed at the beginning of a file, network message
    /// or network stream).
    /// 
    /// A #GVariant's size is limited mainly by any lower level operating
    /// system constraints, such as the number of bits in #gsize.  For
    /// example, it is reasonable to have a 2GB file mapped into memory
    /// with #GMappedFile, and call g_variant_new_from_data() on it.
    /// 
    /// For convenience to C programmers, #GVariant features powerful
    /// varargs-based value construction and destruction.  This feature is
    /// designed to be embedded in other libraries.
    /// 
    /// There is a Python-inspired text language for describing #GVariant
    /// values.  #GVariant includes a printer for this language and a parser
    /// with type inferencing.
    /// 
    /// ## Memory Use
    /// 
    /// #GVariant tries to be quite efficient with respect to memory use.
    /// This section gives a rough idea of how much memory is used by the
    /// current implementation.  The information here is subject to change
    /// in the future.
    /// 
    /// The memory allocated by #GVariant can be grouped into 4 broad
    /// purposes: memory for serialised data, memory for the type
    /// information cache, buffer management memory and memory for the
    /// #GVariant structure itself.
    /// 
    /// ## Serialised Data Memory
    /// 
    /// This is the memory that is used for storing GVariant data in
    /// serialised form.  This is what would be sent over the network or
    /// what would end up on disk, not counting any indicator of the
    /// endianness, or of the length or type of the top-level variant.
    /// 
    /// The amount of memory required to store a boolean is 1 byte. 16,
    /// 32 and 64 bit integers and double precision floating point numbers
    /// use their "natural" size.  Strings (including object path and
    /// signature strings) are stored with a nul terminator, and as such
    /// use the length of the string plus 1 byte.
    /// 
    /// Maybe types use no space at all to represent the null value and
    /// use the same amount of space (sometimes plus one byte) as the
    /// equivalent non-maybe-typed value to represent the non-null case.
    /// 
    /// Arrays use the amount of space required to store each of their
    /// members, concatenated.  Additionally, if the items stored in an
    /// array are not of a fixed-size (ie: strings, other arrays, etc)
    /// then an additional framing offset is stored for each item.  The
    /// size of this offset is either 1, 2 or 4 bytes depending on the
    /// overall size of the container.  Additionally, extra padding bytes
    /// are added as required for alignment of child values.
    /// 
    /// Tuples (including dictionary entries) use the amount of space
    /// required to store each of their members, concatenated, plus one
    /// framing offset (as per arrays) for each non-fixed-sized item in
    /// the tuple, except for the last one.  Additionally, extra padding
    /// bytes are added as required for alignment of child values.
    /// 
    /// Variants use the same amount of space as the item inside of the
    /// variant, plus 1 byte, plus the length of the type string for the
    /// item inside the variant.
    /// 
    /// As an example, consider a dictionary mapping strings to variants.
    /// In the case that the dictionary is empty, 0 bytes are required for
    /// the serialisation.
    /// 
    /// If we add an item "width" that maps to the int32 value of 500 then
    /// we will use 4 byte to store the int32 (so 6 for the variant
    /// containing it) and 6 bytes for the string.  The variant must be
    /// aligned to 8 after the 6 bytes of the string, so that's 2 extra
    /// bytes.  6 (string) + 2 (padding) + 6 (variant) is 14 bytes used
    /// for the dictionary entry.  An additional 1 byte is added to the
    /// array as a framing offset making a total of 15 bytes.
    /// 
    /// If we add another entry, "title" that maps to a nullable string
    /// that happens to have a value of null, then we use 0 bytes for the
    /// null value (and 3 bytes for the variant to contain it along with
    /// its type string) plus 6 bytes for the string.  Again, we need 2
    /// padding bytes.  That makes a total of 6 + 2 + 3 = 11 bytes.
    /// 
    /// We now require extra padding between the two items in the array.
    /// After the 14 bytes of the first item, that's 2 bytes required.
    /// We now require 2 framing offsets for an extra two
    /// bytes. 14 + 2 + 11 + 2 = 29 bytes to encode the entire two-item
    /// dictionary.
    /// 
    /// ## Type Information Cache
    /// 
    /// For each GVariant type that currently exists in the program a type
    /// information structure is kept in the type information cache.  The
    /// type information structure is required for rapid deserialisation.
    /// 
    /// Continuing with the above example, if a #GVariant exists with the
    /// type "a{sv}" then a type information struct will exist for
    /// "a{sv}", "{sv}", "s", and "v".  Multiple uses of the same type
    /// will share the same type information.  Additionally, all
    /// single-digit types are stored in read-only static memory and do
    /// not contribute to the writable memory footprint of a program using
    /// #GVariant.
    /// 
    /// Aside from the type information structures stored in read-only
    /// memory, there are two forms of type information.  One is used for
    /// container types where there is a single element type: arrays and
    /// maybe types.  The other is used for container types where there
    /// are multiple element types: tuples and dictionary entries.
    /// 
    /// Array type info structures are 6 * sizeof (void *), plus the
    /// memory required to store the type string itself.  This means that
    /// on 32-bit systems, the cache entry for "a{sv}" would require 30
    /// bytes of memory (plus malloc overhead).
    /// 
    /// Tuple type info structures are 6 * sizeof (void *), plus 4 *
    /// sizeof (void *) for each item in the tuple, plus the memory
    /// required to store the type string itself.  A 2-item tuple, for
    /// example, would have a type information structure that consumed
    /// writable memory in the size of 14 * sizeof (void *) (plus type
    /// string)  This means that on 32-bit systems, the cache entry for
    /// "{sv}" would require 61 bytes of memory (plus malloc overhead).
    /// 
    /// This means that in total, for our "a{sv}" example, 91 bytes of
    /// type information would be allocated.
    /// 
    /// The type information cache, additionally, uses a #GHashTable to
    /// store and lookup the cached items and stores a pointer to this
    /// hash table in static storage.  The hash table is freed when there
    /// are zero items in the type cache.
    /// 
    /// Although these sizes may seem large it is important to remember
    /// that a program will probably only have a very small number of
    /// different types of values in it and that only one type information
    /// structure is required for many different values of the same type.
    /// 
    /// ## Buffer Management Memory
    /// 
    /// #GVariant uses an internal buffer management structure to deal
    /// with the various different possible sources of serialised data
    /// that it uses.  The buffer is responsible for ensuring that the
    /// correct call is made when the data is no longer in use by
    /// #GVariant.  This may involve a g_free() or a g_slice_free() or
    /// even g_mapped_file_unref().
    /// 
    /// One buffer management structure is used for each chunk of
    /// serialised data.  The size of the buffer management structure
    /// is 4 * (void *).  On 32-bit systems, that's 16 bytes.
    /// 
    /// ## GVariant structure
    /// 
    /// The size of a #GVariant structure is 6 * (void *).  On 32-bit
    /// systems, that's 24 bytes.
    /// 
    /// #GVariant structures only exist if they are explicitly created
    /// with API calls.  For example, if a #GVariant is constructed out of
    /// serialised data for the example given above (with the dictionary)
    /// then although there are 9 individual values that comprise the
    /// entire dictionary (two keys, two values, two variants containing
    /// the values, two dictionary entries, plus the dictionary itself),
    /// only 1 #GVariant instance exists -- the one referring to the
    /// dictionary.
    /// 
    /// If calls are made to start accessing the other values then
    /// #GVariant instances will exist for those values only for as long
    /// as they are in use (ie: until you call g_variant_unref()).  The
    /// type information is shared.  The serialised data and the buffer
    /// management structure for that serialised data is shared by the
    /// child.
    /// 
    /// ## Summary
    /// 
    /// To put the entire example together, for our dictionary mapping
    /// strings to variants (with two entries, as given above), we are
    /// using 91 bytes of memory for type information, 29 byes of memory
    /// for the serialised data, 16 bytes for buffer management and 24
    /// bytes for the #GVariant instance, or a total of 160 bytes, plus
    /// malloc overhead.  If we were to use g_variant_get_child_value() to
    /// access the two dictionary entries, we would use an additional 48
    /// bytes.  If we were to have other dictionaries of the same type, we
    /// would use more memory for the serialised data and buffer
    /// management for those dictionaries, but the type information would
    /// be shared.
    /// </remarks>
    [GISharp.Core.SinceAttribute("2.24")]
    public partial class Variant : GISharp.Core.ReferenceCountedOpaque<Variant>, System.IEquatable<Variant>, System.IComparable<Variant>
    {
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
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_array /* transfer-ownership:none */(
            System.IntPtr childType /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr children /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.UInt64 nChildren /* transfer-ownership:none */);

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
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            GISharp.GLib.VariantType childType,
            GISharp.GLib.Variant[] children)
        {
            var childTypePtr = default(System.IntPtr);
            var childrenPtr = default(System.IntPtr);
            var nChildren = (System.UInt64)children.Length;
            Handle = g_variant_new_array(childTypePtr, childrenPtr, nChildren);
        }

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_boolean /* transfer-ownership:none */(
            System.Boolean value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Boolean value)
        {
            Handle = g_variant_new_boolean(value);
        }

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_byte /* transfer-ownership:none */(
            System.Byte value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Byte value)
        {
            Handle = g_variant_new_byte(value);
        }

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid utf8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_bytestring /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid utf8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public Variant(
            System.Byte[] @string)
        {
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var @stringPtr = default(System.IntPtr);
            Handle = g_variant_new_bytestring(@stringPtr);
        }

        /// <summary>
        /// Constructs an array of bytestring #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_bytestring_array /* transfer-ownership:none */(
            System.IntPtr strv /* transfer-ownership:none */,
            System.Int64 length /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_dict_entry /* transfer-ownership:none */(
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            GISharp.GLib.Variant key,
            GISharp.GLib.Variant value)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var keyPtr = default(System.IntPtr);
            var valuePtr = default(System.IntPtr);
            Handle = g_variant_new_dict_entry(keyPtr, valuePtr);
        }

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_double /* transfer-ownership:none */(
            System.Double value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Double value)
        {
            Handle = g_variant_new_double(value);
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <param name="nElements">
        /// the number of elements
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_fixed_array /* transfer-ownership:none */(
            System.IntPtr elementType /* transfer-ownership:none */,
            System.IntPtr elements /* transfer-ownership:none */,
            System.UInt64 nElements /* transfer-ownership:none */,
            System.UInt64 elementSize /* transfer-ownership:none */);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <param name="nElements">
        /// the number of elements
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.32")]
        public Variant(
            GISharp.GLib.VariantType elementType,
            System.IntPtr elements,
            System.UInt64 nElements,
            System.UInt64 elementSize)
        {
            if (elementType == null)
            {
                throw new System.ArgumentNullException("elementType");
            }
            var elementTypePtr = default(System.IntPtr);
            Handle = g_variant_new_fixed_array(elementTypePtr, elements, nElements, elementSize);
        }

        /// <summary>
        /// Constructs a new serialised-mode #GVariant instance.  This is the
        /// inner interface for creation of new serialised values that gets
        /// called from various functions in gvariant.c.
        /// </summary>
        /// <remarks>
        /// A reference is taken on @bytes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="trusted">
        /// if the contents of @bytes are trusted
        /// </param>
        /// <returns>
        /// a new #GVariant with a floating reference
        /// </returns>
        [GISharp.Core.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_from_bytes /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */,
            System.IntPtr bytes /* transfer-ownership:none */,
            System.Boolean trusted /* transfer-ownership:none */);

        /// <summary>
        /// Constructs a new serialised-mode #GVariant instance.  This is the
        /// inner interface for creation of new serialised values that gets
        /// called from various functions in gvariant.c.
        /// </summary>
        /// <remarks>
        /// A reference is taken on @bytes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="trusted">
        /// if the contents of @bytes are trusted
        /// </param>
        /// <returns>
        /// a new #GVariant with a floating reference
        /// </returns>
        [GISharp.Core.SinceAttribute("2.36")]
        public Variant(
            GISharp.GLib.VariantType type,
            GISharp.GLib.Bytes bytes,
            System.Boolean trusted)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException("type");
            }
            if (bytes == null)
            {
                throw new System.ArgumentNullException("bytes");
            }
            var typePtr = default(System.IntPtr);
            var bytesPtr = default(System.IntPtr);
            Handle = g_variant_new_from_bytes(typePtr, bytesPtr, trusted);
        }

        /// <summary>
        /// Creates a new #GVariant instance from serialised data.
        /// </summary>
        /// <remarks>
        /// @type is the type of #GVariant instance that will be constructed.
        /// The interpretation of @data depends on knowing the type.
        /// 
        /// @data is not modified by this function and must remain valid with an
        /// unchanging value until such a time as @notify is called with
        /// @user_data.  If the contents of @data change before that time then
        /// the result is undefined.
        /// 
        /// If @data is trusted to be serialised data in normal form then
        /// @trusted should be %TRUE.  This applies to serialised data created
        /// within this process or read from a trusted location on the disk (such
        /// as a file installed in /usr/lib alongside your application).  You
        /// should set trusted to %FALSE if @data is read from the network, a
        /// file in the user's home directory, etc.
        /// 
        /// If @data was not stored in this machine's native endianness, any multi-byte
        /// numeric values in the returned variant will also be in non-native
        /// endianness. g_variant_byteswap() can be used to recover the original values.
        /// 
        /// @notify will be called with @user_data when @data is no longer
        /// needed.  The exact time of this call is unspecified and might even be
        /// before this function returns.
        /// </remarks>
        /// <param name="type">
        /// a definite #GVariantType
        /// </param>
        /// <param name="data">
        /// the serialised data
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="trusted">
        /// %TRUE if @data is definitely in normal form
        /// </param>
        /// <param name="notify">
        /// function to call when @data is no longer needed
        /// </param>
        /// <param name="userData">
        /// data for @notify
        /// </param>
        /// <returns>
        /// a new floating #GVariant of type @type
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_from_data /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */,
            System.UInt64 size /* transfer-ownership:none */,
            System.Boolean trusted /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none scope:async */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new handle #GVariant instance.
        /// </summary>
        /// <remarks>
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new handle #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_handle /* transfer-ownership:none */(
            System.Int32 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int16 /* transfer-ownership:none */(
            System.Int16 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Int16 value)
        {
            Handle = g_variant_new_int16(value);
        }

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int32 /* transfer-ownership:none */(
            System.Int32 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Int32 value)
        {
            Handle = g_variant_new_int32(value);
        }

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int64 /* transfer-ownership:none */(
            System.Int64 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.Int64 value)
        {
            Handle = g_variant_new_int64(value);
        }

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        /// 
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_maybe /* transfer-ownership:none */(
            System.IntPtr childType /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr child /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        /// 
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            GISharp.GLib.VariantType childType,
            GISharp.GLib.Variant child)
        {
            var childTypePtr = default(System.IntPtr);
            var childPtr = default(System.IntPtr);
            Handle = g_variant_new_maybe(childTypePtr, childPtr);
        }

        /// <summary>
        /// Creates a D-Bus object path #GVariant with the contents of @string.
        /// @string must be a valid D-Bus object path.  Use
        /// g_variant_is_object_path() if you're not sure.
        /// </summary>
        /// <param name="objectPath">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new object path #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_object_path /* transfer-ownership:none */(
            System.IntPtr objectPath /* transfer-ownership:none */);

        /// <summary>
        /// Constructs an array of object paths #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// Each string must be a valid #GVariant object path; see
        /// g_variant_is_object_path().
        /// 
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_objv /* transfer-ownership:none */(
            System.IntPtr strv /* transfer-ownership:none */,
            System.Int64 length /* transfer-ownership:none */);

        /// <summary>
        /// Parses @format and returns the result.
        /// </summary>
        /// <remarks>
        /// This is the version of g_variant_new_parsed() intended to be used
        /// from libraries.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance.  In the case that @format simply specified the collection
        /// of a #GVariant pointer (eg: @format was "%*") then the collected
        /// #GVariant pointer will be returned unmodified, without adding any
        /// additional references.
        /// 
        /// Note that the arguments in @app must be of the correct width for their types
        /// specified in @format when collected into the #va_list. See
        /// the [GVariant varargs documentation][gvariant-varargs].
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="format">
        /// a text format #GVariant
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_parsed_va /* transfer-ownership:full */(
            System.IntPtr format /* transfer-ownership:none */,
            System.IntPtr app /* transfer-ownership:none */);

        /// <summary>
        /// Parses @format and returns the result.
        /// </summary>
        /// <remarks>
        /// This is the version of g_variant_new_parsed() intended to be used
        /// from libraries.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance.  In the case that @format simply specified the collection
        /// of a #GVariant pointer (eg: @format was "%*") then the collected
        /// #GVariant pointer will be returned unmodified, without adding any
        /// additional references.
        /// 
        /// Note that the arguments in @app must be of the correct width for their types
        /// specified in @format when collected into the #va_list. See
        /// the [GVariant varargs documentation][gvariant-varargs].
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="format">
        /// a text format #GVariant
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        public Variant(
            System.String format,
            System.Object[] app)
        {
            if (format == null)
            {
                throw new System.ArgumentNullException("format");
            }
            if (app == null)
            {
                throw new System.ArgumentNullException("app");
            }
            var formatPtr = default(System.IntPtr);
            var appPtr = default(System.IntPtr);
            Handle = g_variant_new_parsed_va(formatPtr, appPtr);
        }

        /// <summary>
        /// Creates a D-Bus type signature #GVariant with the contents of
        /// @string.  @string must be a valid D-Bus type signature.  Use
        /// g_variant_is_signature() if you're not sure.
        /// </summary>
        /// <param name="signature">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new signature #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_signature /* transfer-ownership:none */(
            System.IntPtr signature /* transfer-ownership:none */);

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
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_strv /* transfer-ownership:none */(
            System.IntPtr strv /* transfer-ownership:none */,
            System.Int64 length /* transfer-ownership:none */);

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
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.String[] strv)
        {
            if (strv == null)
            {
                throw new System.ArgumentNullException("strv");
            }
            var strvPtr = default(System.IntPtr);
            var length = (System.Int64)strv.Length;
            Handle = g_variant_new_strv(strvPtr, length);
        }

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid utf8.
        /// 
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        /// 
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal utf8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_take_string /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid utf8.
        /// 
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        /// 
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal utf8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.38")]
        public Variant(
            System.String @string)
        {
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var @stringPtr = default(System.IntPtr);
            Handle = g_variant_new_take_string(@stringPtr);
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
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_tuple /* transfer-ownership:none */(
            System.IntPtr children /* transfer-ownership:none */,
            System.UInt64 nChildren /* transfer-ownership:none */);

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
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            GISharp.GLib.Variant[] children)
        {
            if (children == null)
            {
                throw new System.ArgumentNullException("children");
            }
            var childrenPtr = default(System.IntPtr);
            var nChildren = (System.UInt64)children.Length;
            Handle = g_variant_new_tuple(childrenPtr, nChildren);
        }

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint16 /* transfer-ownership:none */(
            System.UInt16 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.UInt16 value)
        {
            Handle = g_variant_new_uint16(value);
        }

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint32 /* transfer-ownership:none */(
            System.UInt32 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.UInt32 value)
        {
            Handle = g_variant_new_uint32(value);
        }

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint64 /* transfer-ownership:none */(
            System.UInt64 value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.UInt64 value)
        {
            Handle = g_variant_new_uint64(value);
        }

        /// <summary>
        /// This function is intended to be used by libraries based on
        /// #GVariant that want to provide g_variant_new()-like functionality
        /// to their users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_new() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// needs to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// Note that the arguments in @app must be of the correct width for their
        /// types specified in @format_string when collected into the #va_list.
        /// See the [GVariant varargs documentation][gvariant-varargs.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance (for example, if the format string was "(ii)").  In the case
        /// that the format_string was '*', '?', 'r', or a format starting with
        /// '@' then the collected #GVariant pointer will be returned unmodified,
        /// without adding any additional references.
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_va /* transfer-ownership:full */(
            System.IntPtr formatString /* transfer-ownership:none */,
            System.IntPtr endptr /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr app /* transfer-ownership:none */);

        /// <summary>
        /// This function is intended to be used by libraries based on
        /// #GVariant that want to provide g_variant_new()-like functionality
        /// to their users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_new() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// needs to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// Note that the arguments in @app must be of the correct width for their
        /// types specified in @format_string when collected into the #va_list.
        /// See the [GVariant varargs documentation][gvariant-varargs.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance (for example, if the format string was "(ii)").  In the case
        /// that the format_string was '*', '?', 'r', or a format starting with
        /// '@' then the collected #GVariant pointer will be returned unmodified,
        /// without adding any additional references.
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            System.String formatString,
            System.String endptr,
            System.Object[] app)
        {
            if (formatString == null)
            {
                throw new System.ArgumentNullException("formatString");
            }
            if (app == null)
            {
                throw new System.ArgumentNullException("app");
            }
            var formatStringPtr = default(System.IntPtr);
            var endptrPtr = default(System.IntPtr);
            var appPtr = default(System.IntPtr);
            Handle = g_variant_new_va(formatStringPtr, endptrPtr, appPtr);
        }

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_variant /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public Variant(
            GISharp.GLib.Variant value)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var valuePtr = default(System.IntPtr);
            Handle = g_variant_new_variant(valuePtr);
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_object_path /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public static System.Boolean IsObjectPath(
            System.String @string)
        {
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var @stringPtr = default(System.IntPtr);
            var ret = g_variant_is_object_path(@stringPtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_signature /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none */);

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public static System.Boolean IsSignature(
            System.String @string)
        {
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var @stringPtr = default(System.IntPtr);
            var ret = g_variant_is_signature(@stringPtr);
            return default(System.Boolean);
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
        /// is returned.
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
        /// <param name="limit">
        /// a pointer to the end of @text, or %NULL
        /// </param>
        /// <param name="endptr">
        /// a location to store the end pointer, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a reference to a #GVariant, or %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parse /* transfer-ownership:full */(
            System.IntPtr type /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr text /* transfer-ownership:none */,
            System.IntPtr limit /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr endptr /* transfer-ownership:none nullable:1 allow-none:1 */,
            out System.IntPtr error /* direction:out */);

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
        /// is returned.
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
        /// <param name="limit">
        /// a pointer to the end of @text, or %NULL
        /// </param>
        /// <param name="endptr">
        /// a location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// a reference to a #GVariant, or %NULL
        /// </returns>
        public static GISharp.GLib.Variant Parse(
            GISharp.GLib.VariantType type,
            System.String text,
            System.String limit,
            System.String endptr)
        {
            if (text == null)
            {
                throw new System.ArgumentNullException("text");
            }
            var typePtr = default(System.IntPtr);
            var textPtr = default(System.IntPtr);
            var limitPtr = default(System.IntPtr);
            var endptrPtr = default(System.IntPtr);
            System.IntPtr error;
            var retPtr = g_variant_parse(typePtr, textPtr, limitPtr, endptrPtr,out error);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Pretty-prints a message showing the context of a #GVariant parse
        /// error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// 
        /// The message will typically look something like one of the following:
        /// 
        /// |[
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// ]|
        /// 
        /// or
        /// 
        /// |[
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// ]|
        /// 
        /// The format of the message may change in a future version.
        /// 
        /// @error must have come from a failed attempt to g_variant_parse() and
        /// @source_str must be exactly the same string that caused the error.
        /// If @source_str was not nul-terminated when you passed it to
        /// g_variant_parse() then you must add nul termination before using this
        /// function.
        /// </remarks>
        /// <param name="error">
        /// a #GError from the #GVariantParseError domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parse_error_print_context /* transfer-ownership:full */(
            System.IntPtr error /* transfer-ownership:none */,
            System.IntPtr sourceStr /* transfer-ownership:none */);

        /// <summary>
        /// Pretty-prints a message showing the context of a #GVariant parse
        /// error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// 
        /// The message will typically look something like one of the following:
        /// 
        /// |[
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// ]|
        /// 
        /// or
        /// 
        /// |[
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// ]|
        /// 
        /// The format of the message may change in a future version.
        /// 
        /// @error must have come from a failed attempt to g_variant_parse() and
        /// @source_str must be exactly the same string that caused the error.
        /// If @source_str was not nul-terminated when you passed it to
        /// g_variant_parse() then you must add nul termination before using this
        /// function.
        /// </remarks>
        /// <param name="error">
        /// a #GError from the #GVariantParseError domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public static System.String ParseErrorPrintContext(
            GISharp.GLib.Error error,
            System.String sourceStr)
        {
            if (error == null)
            {
                throw new System.ArgumentNullException("error");
            }
            if (sourceStr == null)
            {
                throw new System.ArgumentNullException("sourceStr");
            }
            var errorPtr = default(System.IntPtr);
            var sourceStrPtr = default(System.IntPtr);
            var retPtr = g_variant_parse_error_print_context(errorPtr, sourceStrPtr);
            return default(System.String);
        }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.Quark g_variant_parse_error_quark /* transfer-ownership:none */();

        public static GISharp.GLib.Quark ParseErrorQuark()
        {
            var ret = g_variant_parse_error_quark();
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Same as g_variant_error_quark().
        /// </summary>
        [System.ObsoleteAttribute("Use g_variant_parse_error_quark() instead.")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.Quark g_variant_parser_get_error_quark /* transfer-ownership:none */();

        /// <summary>
        /// Same as g_variant_error_quark().
        /// </summary>
        [System.ObsoleteAttribute("Use g_variant_parse_error_quark() instead.")]
        public static GISharp.GLib.Quark ParserGetErrorQuark()
        {
            var ret = g_variant_parser_get_error_quark();
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        /// 
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_byteswap /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        /// 
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant Byteswap()
        {
            var retPtr = g_variant_byteswap(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        /// 
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [GISharp.Core.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_check_format_string /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            System.IntPtr formatString /* transfer-ownership:none */,
            System.Boolean copyOnly /* transfer-ownership:none */);

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        /// 
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [GISharp.Core.SinceAttribute("2.34")]
        public System.Boolean CheckFormatString(
            System.String formatString,
            System.Boolean copyOnly)
        {
            if (formatString == null)
            {
                throw new System.ArgumentNullException("formatString");
            }
            var formatStringPtr = default(System.IntPtr);
            var ret = g_variant_check_format_string(Handle, formatStringPtr, copyOnly);
            return default(System.Boolean);
        }

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.VariantClass g_variant_classify /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.VariantClass Classify()
        {
            var ret = g_variant_classify(Handle);
            return default(GISharp.GLib.VariantClass);
        }

        /// <summary>
        /// Compares @one and @two.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        /// 
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, %FALSE is less than %TRUE.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        /// 
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        /// 
        /// If you only require an equality comparison, g_variant_equal() is more
        /// general.
        /// </remarks>
        /// <param name="one">
        /// a basic-typed #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance of the same type
        /// </param>
        /// <returns>
        /// negative value if a &lt; b;
        ///          zero if a = b;
        ///          positive value if a &gt; b.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_compare /* transfer-ownership:none */(
            System.IntPtr one /* transfer-ownership:none */,
            System.IntPtr two /* transfer-ownership:none */);

        /// <summary>
        /// Compares @one and @two.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        /// 
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, %FALSE is less than %TRUE.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        /// 
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        /// 
        /// If you only require an equality comparison, g_variant_equal() is more
        /// general.
        /// </remarks>
        /// <param name="two">
        /// a #GVariant instance of the same type
        /// </param>
        /// <returns>
        /// negative value if a &lt; b;
        ///          zero if a = b;
        ///          positive value if a &gt; b.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Int32 CompareTo(
            GISharp.GLib.Variant two)
        {
            if (two == null)
            {
                throw new System.ArgumentNullException("two");
            }
            var twoPtr = default(System.IntPtr);
            var ret = g_variant_compare(Handle, twoPtr);
            return default(System.Int32);
        }

        public static bool operator >=(Variant one, Variant two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Variant one, Variant two)
        {
            return one.CompareTo(two) > 0;
        }

        public static bool operator <(Variant one, Variant two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Variant one, Variant two)
        {
            return one.CompareTo(two) <= 0;
        }

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="one">
        /// a #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_equal /* transfer-ownership:none */(
            System.IntPtr one /* transfer-ownership:none */,
            System.IntPtr two /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="two">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Boolean Equals(
            GISharp.GLib.Variant two)
        {
            if (two == null)
            {
                throw new System.ArgumentNullException("two");
            }
            var twoPtr = default(System.IntPtr);
            var ret = g_variant_equal(Handle, twoPtr);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Variant);
        }

        public static bool operator ==(Variant one, Variant two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(Variant one, Variant two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <param name="value">
        /// a boolean #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_get_boolean /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Boolean Boolean
        {
            get
            {
                var ret = g_variant_get_boolean(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <param name="value">
        /// a byte #GVariant instance
        /// </param>
        /// <returns>
        /// a #guchar
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Byte g_variant_get_byte /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <returns>
        /// a #guchar
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Byte Byte
        {
            get
            {
                var ret = g_variant_get_byte(Handle);
                return default(System.Byte);
            }
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        /// 
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        /// 
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// an array-of-bytes #GVariant instance
        /// </param>
        /// <returns>
        /// 
        ///          the constant string
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_bytestring /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        /// 
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        /// 
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <returns>
        /// 
        ///          the constant string
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        public System.Byte[] Bytestring
        {
            get
            {
                var retPtr = g_variant_get_bytestring(Handle);
                return default(System.Byte[]);
            }
        }

        /// <summary>
        /// Gets the contents of an array of array of bytes #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result is
        /// stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of array of bytes #GVariant ('aay')
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [GISharp.Core.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_bytestring_array /* transfer-ownership:container */(
            System.IntPtr value /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        /// 
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_child_value /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */,
            System.UInt64 index /* transfer-ownership:none */);

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        /// 
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant GetChildValue(
            System.UInt64 index)
        {
            var retPtr = g_variant_get_child_value(Handle, index);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        /// 
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        /// 
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_data /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        /// 
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        /// 
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.IntPtr Data
        {
            get
            {
                var ret = g_variant_get_data(Handle);
                return default(System.IntPtr);
            }
        }

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The semantics of this function are exactly the same as
        /// g_variant_get_data(), except that the returned #GBytes holds
        /// a reference to the variant data.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// A new #GBytes representing the variant data
        /// </returns>
        [GISharp.Core.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_data_as_bytes /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The semantics of this function are exactly the same as
        /// g_variant_get_data(), except that the returned #GBytes holds
        /// a reference to the variant data.
        /// </summary>
        /// <returns>
        /// A new #GBytes representing the variant data
        /// </returns>
        [GISharp.Core.SinceAttribute("2.36")]
        public GISharp.GLib.Bytes DataAsBytes
        {
            get
            {
                var retPtr = g_variant_get_data_as_bytes(Handle);
                return default(GISharp.GLib.Bytes);
            }
        }

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <param name="value">
        /// a double #GVariant instance
        /// </param>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Double g_variant_get_double /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Double Double
        {
            get
            {
                var ret = g_variant_get_double(Handle);
                return default(System.Double);
            }
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        /// 
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        /// 
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant array with fixed-sized elements
        /// </param>
        /// <param name="nElements">
        /// a pointer to the location to store the number of items
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a pointer to
        ///     the fixed array
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_fixed_array /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            out System.UInt64 nElements /* direction:out caller-allocates:0 transfer-ownership:full */,
            System.UInt64 elementSize /* transfer-ownership:none */);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        /// 
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        /// 
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a pointer to
        ///     the fixed array
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.IntPtr[] GetFixedArray(
            System.UInt64 elementSize)
        {
            System.UInt64 nElements;
            var retPtr = g_variant_get_fixed_array(Handle,out nElements, elementSize);
            return default(System.IntPtr[]);
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        /// 
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a handle #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_get_handle /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        /// 
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Int32 DBusHandle
        {
            get
            {
                var ret = g_variant_get_handle(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <param name="value">
        /// a int16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint16
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int16 g_variant_get_int16 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <returns>
        /// a #gint16
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Int16 Int16
        {
            get
            {
                var ret = g_variant_get_int16(Handle);
                return default(System.Int16);
            }
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <param name="value">
        /// a int32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_get_int32 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Int32 Int32
        {
            get
            {
                var ret = g_variant_get_int32(Handle);
                return default(System.Int32);
            }
        }

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <param name="value">
        /// a int64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint64
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Int64 g_variant_get_int64 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <returns>
        /// a #gint64
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Int64 Int64
        {
            get
            {
                var ret = g_variant_get_int64(Handle);
                return default(System.Int64);
            }
        }

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <param name="value">
        /// a maybe-typed value
        /// </param>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_maybe /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant Maybe
        {
            get
            {
                var retPtr = g_variant_get_maybe(Handle);
                return default(GISharp.GLib.Variant);
            }
        }

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        /// 
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        /// 
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        /// 
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_normal_form /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        /// 
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        /// 
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        /// 
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant NormalForm
        {
            get
            {
                var retPtr = g_variant_get_normal_form(Handle);
                return default(GISharp.GLib.Variant);
            }
        }

        /// <summary>
        /// Gets the contents of an array of object paths #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of object paths #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_objv /* transfer-ownership:container */(
            System.IntPtr value /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Determines the number of bytes that would be required to store @value
        /// with g_variant_store().
        /// </summary>
        /// <remarks>
        /// If @value has a fixed-sized type then this function always returned
        /// that fixed size.
        /// 
        /// In the case that @value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised size of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_get_size /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Determines the number of bytes that would be required to store @value
        /// with g_variant_store().
        /// </summary>
        /// <remarks>
        /// If @value has a fixed-sized type then this function always returned
        /// that fixed size.
        /// 
        /// In the case that @value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <returns>
        /// the serialised size of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt64 Size
        {
            get
            {
                var ret = g_variant_get_size(Handle);
                return default(System.UInt64);
            }
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <remarks>
        /// The string will always be utf8 encoded.
        /// 
        /// If @length is non-%NULL then the length of the string (in bytes) is
        /// returned there.  For trusted values, this information is already
        /// known.  For untrusted values, a strlen() will be performed.
        /// 
        /// It is an error to call this function with a @value of any type
        /// other than those three.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// a string #GVariant instance
        /// </param>
        /// <param name="length">
        /// a pointer to a #gsize,
        ///          to store the length
        /// </param>
        /// <returns>
        /// the constant string, utf8 encoded
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_string /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <remarks>
        /// The string will always be utf8 encoded.
        /// 
        /// If @length is non-%NULL then the length of the string (in bytes) is
        /// returned there.  For trusted values, this information is already
        /// known.  For untrusted values, a strlen() will be performed.
        /// 
        /// It is an error to call this function with a @value of any type
        /// other than those three.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="length">
        /// a pointer to a #gsize,
        ///          to store the length
        /// </param>
        /// <returns>
        /// the constant string, utf8 encoded
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.String GetString(
            out System.UInt64 length)
        {
            var retPtr = g_variant_get_string(Handle,out length);
            length = default(System.UInt64); return default(System.String);
        }

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of strings #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_strv /* transfer-ownership:container */(
            System.IntPtr value /* transfer-ownership:none */,
            out System.UInt64 length /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.String[] Strv
        {
            get
            {
                System.UInt64 length;
                var retPtr = g_variant_get_strv(Handle,out length);
                return default(System.String[]);
            }
        }

        /// <summary>
        /// Determines the type of @value.
        /// </summary>
        /// <remarks>
        /// The return value is valid for the lifetime of @value and must not
        /// be freed.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a #GVariantType
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_type /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Determines the type of @value.
        /// </summary>
        /// <remarks>
        /// The return value is valid for the lifetime of @value and must not
        /// be freed.
        /// </remarks>
        /// <returns>
        /// a #GVariantType
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.VariantType VariantType
        {
            get
            {
                var retPtr = g_variant_get_type(Handle);
                return default(GISharp.GLib.VariantType);
            }
        }

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_type_string /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.String TypeString
        {
            get
            {
                var retPtr = g_variant_get_type_string(Handle);
                return default(System.String);
            }
        }

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <param name="value">
        /// a uint16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint16
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt16 g_variant_get_uint16 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <returns>
        /// a #guint16
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt16 Uint16
        {
            get
            {
                var ret = g_variant_get_uint16(Handle);
                return default(System.UInt16);
            }
        }

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <param name="value">
        /// a uint32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_get_uint32 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <returns>
        /// a #guint32
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt32 Uint32
        {
            get
            {
                var ret = g_variant_get_uint32(Handle);
                return default(System.UInt32);
            }
        }

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <param name="value">
        /// a uint64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint64
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_get_uint64 /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <returns>
        /// a #guint64
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt64 Uint64
        {
            get
            {
                var ret = g_variant_get_uint64(Handle);
                return default(System.UInt64);
            }
        }

        /// <summary>
        /// This function is intended to be used by libraries based on #GVariant
        /// that want to provide g_variant_get()-like functionality to their
        /// users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_get() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// need to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// @format_string determines the C types that are used for unpacking
        /// the values and also determines if the values are copied or borrowed,
        /// see the section on
        /// [GVariant format strings][gvariant-format-strings-pointers].
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_get_va /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            System.IntPtr formatString /* transfer-ownership:none */,
            System.IntPtr endptr /* transfer-ownership:none nullable:1 allow-none:1 */,
            System.IntPtr app /* transfer-ownership:none */);

        /// <summary>
        /// This function is intended to be used by libraries based on #GVariant
        /// that want to provide g_variant_get()-like functionality to their
        /// users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_get() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// need to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// @format_string determines the C types that are used for unpacking
        /// the values and also determines if the values are copied or borrowed,
        /// see the section on
        /// [GVariant format strings][gvariant-format-strings-pointers].
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        public void GetVa(
            System.String formatString,
            System.String endptr,
            System.Object[] app)
        {
            if (formatString == null)
            {
                throw new System.ArgumentNullException("formatString");
            }
            if (app == null)
            {
                throw new System.ArgumentNullException("app");
            }
            var formatStringPtr = default(System.IntPtr);
            var endptrPtr = default(System.IntPtr);
            var appPtr = default(System.IntPtr);
            g_variant_get_va(Handle, formatStringPtr, endptrPtr, appPtr);
        }

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <param name="value">
        /// a variant #GVariant instance
        /// </param>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_variant /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant BoxedVariant
        {
            get
            {
                var retPtr = g_variant_get_variant(Handle);
                return default(GISharp.GLib.Variant);
            }
        }

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        /// 
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <param name="value">
        /// a basic #GVariant value as a #gconstpointer
        /// </param>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_hash /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        /// 
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        protected System.UInt32 Hash()
        {
            var ret = g_variant_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_container /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Boolean IsContainer
        {
            get
            {
                var ret = g_variant_is_container(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        /// 
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_normal_form /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        /// 
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Boolean IsNormalForm
        {
            get
            {
                var ret = g_variant_is_normal_form(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_of_type /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.Boolean IsOfType(
            GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException("type");
            }
            var typePtr = default(System.IntPtr);
            var ret = g_variant_is_of_type(Handle, typePtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Creates a heap-allocated #GVariantIter for iterating over the items
        /// in @value.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to @value and will be released only when
        /// g_variant_iter_free() is called.
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_new /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Creates a heap-allocated #GVariantIter for iterating over the items
        /// in @value.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to @value and will be released only when
        /// g_variant_iter_free() is called.
        /// </remarks>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.VariantIter IterNew()
        {
            var retPtr = g_variant_iter_new(Handle);
            return default(GISharp.GLib.VariantIter);
        }

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        /// 
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        /// 
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// 
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="dictionary">
        /// a dictionary #GVariant
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_lookup_value /* transfer-ownership:full */(
            System.IntPtr dictionary /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr expectedType /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        /// 
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        /// 
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// 
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.28")]
        public GISharp.GLib.Variant LookupValue(
            System.String key,
            GISharp.GLib.VariantType expectedType)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var keyPtr = default(System.IntPtr);
            var expectedTypePtr = default(System.IntPtr);
            var retPtr = g_variant_lookup_value(Handle, keyPtr, expectedTypePtr);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_n_children /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt64 NChildren()
        {
            var ret = g_variant_n_children(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        /// 
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_print /* transfer-ownership:full */(
            System.IntPtr value /* transfer-ownership:none */,
            System.Boolean typeAnnotate /* transfer-ownership:none */);

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        /// 
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.String Print(
            System.Boolean typeAnnotate)
        {
            var retPtr = g_variant_print(Handle, typeAnnotate);
            return default(System.String);
        }

        /// <summary>
        /// #GVariant uses a floating reference count system.  All functions with
        /// names starting with `g_variant_new_` return floating
        /// references.
        /// </summary>
        /// <remarks>
        /// Calling g_variant_ref_sink() on a #GVariant with a floating reference
        /// will convert the floating reference into a full reference.  Calling
        /// g_variant_ref_sink() on a non-floating #GVariant results in an
        /// additional normal reference being added.
        /// 
        /// In other words, if the @value is floating, then this call "assumes
        /// ownership" of the floating reference, converting it to a normal
        /// reference.  If the @value is not floating, then this call adds a
        /// new normal reference increasing the reference count by one.
        /// 
        /// All calls that result in a #GVariant instance being inserted into a
        /// container will call g_variant_ref_sink() on the instance.  This means
        /// that if the value was just created (and has only its floating
        /// reference) then the container will assume sole ownership of the value
        /// at that point and the caller will not need to unreference it.  This
        /// makes certain common styles of programming much easier while still
        /// maintaining normal refcounting semantics in situations where values
        /// are not floating.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the same @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_ref_sink /* transfer-ownership:full skip:1 */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// #GVariant uses a floating reference count system.  All functions with
        /// names starting with `g_variant_new_` return floating
        /// references.
        /// </summary>
        /// <remarks>
        /// Calling g_variant_ref_sink() on a #GVariant with a floating reference
        /// will convert the floating reference into a full reference.  Calling
        /// g_variant_ref_sink() on a non-floating #GVariant results in an
        /// additional normal reference being added.
        /// 
        /// In other words, if the @value is floating, then this call "assumes
        /// ownership" of the floating reference, converting it to a normal
        /// reference.  If the @value is not floating, then this call adds a
        /// new normal reference increasing the reference count by one.
        /// 
        /// All calls that result in a #GVariant instance being inserted into a
        /// container will call g_variant_ref_sink() on the instance.  This means
        /// that if the value was just created (and has only its floating
        /// reference) then the container will assume sole ownership of the value
        /// at that point and the caller will not need to unreference it.  This
        /// makes certain common styles of programming much easier while still
        /// maintaining normal refcounting semantics in situations where values
        /// are not floating.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.24")]
        protected override void Ref()
        {
            g_variant_ref_sink(Handle);
        }

        /// <summary>
        /// Stores the serialised form of @value at @data.  @data should be
        /// large enough.  See g_variant_get_size().
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// g_variant_get_normal_form() for a solution.
        /// 
        /// As with g_variant_get_data(), to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        /// 
        /// This function is approximately O(n) in the size of @data.
        /// </remarks>
        /// <param name="value">
        /// the #GVariant to store
        /// </param>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_store /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */,
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Stores the serialised form of @value at @data.  @data should be
        /// large enough.  See g_variant_get_size().
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// g_variant_get_normal_form() for a solution.
        /// 
        /// As with g_variant_get_data(), to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        /// 
        /// This function is approximately O(n) in the size of @data.
        /// </remarks>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        public void Store(
            System.IntPtr data)
        {
            g_variant_store(Handle, data);
        }

        /// <summary>
        /// Decreases the reference count of @value.  When its reference count
        /// drops to 0, the memory used by the variant is freed.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_unref /* transfer-ownership:none */(
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Decreases the reference count of @value.  When its reference count
        /// drops to 0, the memory used by the variant is freed.
        /// </summary>
        [GISharp.Core.SinceAttribute("2.24")]
        protected override void Unref()
        {
            g_variant_unref(Handle);
        }
    }

    /// <summary>
    /// A utility type for constructing container-type #GVariant instances.
    /// </summary>
    /// <remarks>
    /// This is an opaque structure and may only be accessed using the
    /// following functions.
    /// 
    /// #GVariantBuilder is not threadsafe in any way.  Do not attempt to
    /// access it from more than one thread.
    /// </remarks>
    public partial class VariantBuilder : GISharp.Core.ReferenceCountedOpaque<VariantBuilder>
    {
        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_new /* transfer-ownership:full */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public VariantBuilder(
            GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException("type");
            }
            var typePtr = default(System.IntPtr);
            Handle = g_variant_builder_new(typePtr);
        }

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_add_value /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        public void AddValue(
            GISharp.GLib.Variant value)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var valuePtr = default(System.IntPtr);
            g_variant_builder_add_value(Handle, valuePtr);
        }

        /// <summary>
        /// Releases all memory associated with a #GVariantBuilder without
        /// freeing the #GVariantBuilder structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantBuilder if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_builder_end() and it also doesn't need to be called on
        /// builders allocated with g_variant_builder_new (see
        /// g_variant_builder_unref() for that).
        /// 
        /// This function leaves the #GVariantBuilder structure set to all-zeros.
        /// It is valid to call this function on either an initialised
        /// #GVariantBuilder or one that is set to all-zeros but it is not valid
        /// to call this function on uninitialised memory.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_clear /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */);

        /// <summary>
        /// Releases all memory associated with a #GVariantBuilder without
        /// freeing the #GVariantBuilder structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantBuilder if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_builder_end() and it also doesn't need to be called on
        /// builders allocated with g_variant_builder_new (see
        /// g_variant_builder_unref() for that).
        /// 
        /// This function leaves the #GVariantBuilder structure set to all-zeros.
        /// It is valid to call this function on either an initialised
        /// #GVariantBuilder or one that is set to all-zeros but it is not valid
        /// to call this function on uninitialised memory.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.24")]
        public void Clear()
        {
            g_variant_builder_clear(Handle);
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_close /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */);

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.24")]
        public void Close()
        {
            g_variant_builder_close(Handle);
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated).
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_end /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */);

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated).
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant End()
        {
            var retPtr = g_variant_builder_end(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Initialises a #GVariantBuilder structure.
        /// </summary>
        /// <remarks>
        /// @type must be non-%NULL.  It specifies the type of container to
        /// construct.  It can be an indefinite type such as
        /// %G_VARIANT_TYPE_ARRAY or a definite type such as "as" or "(ii)".
        /// Maybe, array, tuple, dictionary entry and variant-typed values may be
        /// constructed.
        /// 
        /// After the builder is initialised, values are added using
        /// g_variant_builder_add_value() or g_variant_builder_add().
        /// 
        /// After all the child values are added, g_variant_builder_end() frees
        /// the memory associated with the builder and returns the #GVariant that
        /// was created.
        /// 
        /// This function completely ignores the previous contents of @builder.
        /// On one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantBuilder you need to
        /// first call g_variant_builder_clear() in order to avoid leaking
        /// memory.
        /// 
        /// You must not call g_variant_builder_ref() or
        /// g_variant_builder_unref() on a #GVariantBuilder that was initialised
        /// with this function.  If you ever pass a reference to a
        /// #GVariantBuilder outside of the control of your own code then you
        /// should assume that the person receiving that reference may try to use
        /// reference counting; you should use g_variant_builder_new() instead of
        /// this function.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// a container type
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_init /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */,
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Initialises a #GVariantBuilder structure.
        /// </summary>
        /// <remarks>
        /// @type must be non-%NULL.  It specifies the type of container to
        /// construct.  It can be an indefinite type such as
        /// %G_VARIANT_TYPE_ARRAY or a definite type such as "as" or "(ii)".
        /// Maybe, array, tuple, dictionary entry and variant-typed values may be
        /// constructed.
        /// 
        /// After the builder is initialised, values are added using
        /// g_variant_builder_add_value() or g_variant_builder_add().
        /// 
        /// After all the child values are added, g_variant_builder_end() frees
        /// the memory associated with the builder and returns the #GVariant that
        /// was created.
        /// 
        /// This function completely ignores the previous contents of @builder.
        /// On one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantBuilder you need to
        /// first call g_variant_builder_clear() in order to avoid leaking
        /// memory.
        /// 
        /// You must not call g_variant_builder_ref() or
        /// g_variant_builder_unref() on a #GVariantBuilder that was initialised
        /// with this function.  If you ever pass a reference to a
        /// #GVariantBuilder outside of the control of your own code then you
        /// should assume that the person receiving that reference may try to use
        /// reference counting; you should use g_variant_builder_new() instead of
        /// this function.
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        public void Init(
            GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException("type");
            }
            var typePtr = default(System.IntPtr);
            g_variant_builder_init(Handle, typePtr);
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_open /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:none */,
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        public void Open(
            GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException("type");
            }
            var typePtr = default(System.IntPtr);
            g_variant_builder_open(Handle, typePtr);
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr builder /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.24")]
        protected override void Ref()
        {
            g_variant_builder_ref(Handle);
        }

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_builder_unref /* transfer-ownership:none */(
            System.IntPtr builder /* transfer-ownership:full */);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.24")]
        protected override void Unref()
        {
            g_variant_builder_unref(Handle);
        }
    }

    /// <summary>
    /// The range of possible top-level types of #GVariant instances.
    /// </summary>
    [GISharp.Core.SinceAttribute("2.24")]
    public enum VariantClass
    {
        /// <summary>
        /// The #GVariant is a boolean.
        /// </summary>
        Boolean = 98,
        /// <summary>
        /// The #GVariant is a byte.
        /// </summary>
        Byte = 121,
        /// <summary>
        /// The #GVariant is a signed 16 bit integer.
        /// </summary>
        Int16 = 110,
        /// <summary>
        /// The #GVariant is an unsigned 16 bit integer.
        /// </summary>
        Uint16 = 113,
        /// <summary>
        /// The #GVariant is a signed 32 bit integer.
        /// </summary>
        Int32 = 105,
        /// <summary>
        /// The #GVariant is an unsigned 32 bit integer.
        /// </summary>
        Uint32 = 117,
        /// <summary>
        /// The #GVariant is a signed 64 bit integer.
        /// </summary>
        Int64 = 120,
        /// <summary>
        /// The #GVariant is an unsigned 64 bit integer.
        /// </summary>
        Uint64 = 116,
        /// <summary>
        /// The #GVariant is a file handle index.
        /// </summary>
        Handle = 104,
        /// <summary>
        /// The #GVariant is a double precision floating
        ///                          point value.
        /// </summary>
        Double = 100,
        /// <summary>
        /// The #GVariant is a normal string.
        /// </summary>
        String = 115,
        /// <summary>
        /// The #GVariant is a D-Bus object path
        ///                               string.
        /// </summary>
        ObjectPath = 111,
        /// <summary>
        /// The #GVariant is a D-Bus signature string.
        /// </summary>
        Signature = 103,
        /// <summary>
        /// The #GVariant is a variant.
        /// </summary>
        Variant = 118,
        /// <summary>
        /// The #GVariant is a maybe-typed value.
        /// </summary>
        Maybe = 109,
        /// <summary>
        /// The #GVariant is an array.
        /// </summary>
        Array = 97,
        /// <summary>
        /// The #GVariant is a tuple.
        /// </summary>
        Tuple = 40,
        /// <summary>
        /// The #GVariant is a dictionary entry.
        /// </summary>
        DictEntry = 123
    }

    /// <summary>
    /// #GVariantDict is a mutable interface to #GVariant dictionaries.
    /// </summary>
    /// <remarks>
    /// It can be used for doing a sequence of dictionary lookups in an
    /// efficient way on an existing #GVariant dictionary or it can be used
    /// to construct new dictionaries with a hashtable-like interface.  It
    /// can also be used for taking existing dictionaries and modifying them
    /// in order to create new ones.
    /// 
    /// #GVariantDict can only be used with %G_VARIANT_TYPE_VARDICT
    /// dictionaries.
    /// 
    /// It is possible to use #GVariantDict allocated on the stack or on the
    /// heap.  When using a stack-allocated #GVariantDict, you begin with a
    /// call to g_variant_dict_init() and free the resources with a call to
    /// g_variant_dict_clear().
    /// 
    /// Heap-allocated #GVariantDict follows normal refcounting rules: you
    /// allocate it with g_variant_dict_new() and use g_variant_dict_ref()
    /// and g_variant_dict_unref().
    /// 
    /// g_variant_dict_end() is used to convert the #GVariantDict back into a
    /// dictionary-type #GVariant.  When used with stack-allocated instances,
    /// this also implicitly frees all associated memory, but for
    /// heap-allocated instances, you must still call g_variant_dict_unref()
    /// afterwards.
    /// 
    /// You will typically want to use a heap-allocated #GVariantDict when
    /// you expose it as part of an API.  For most other uses, the
    /// stack-allocated form will be more convenient.
    /// 
    /// Consider the following two examples that do the same thing in each
    /// style: take an existing dictionary and look up the "count" uint32
    /// key, adding 1 to it if it is found, or returning an error if the
    /// key is not found.  Each returns the new dictionary as a floating
    /// #GVariant.
    /// 
    /// ## Using a stack-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict dict;
    ///     guint32 count;
    /// 
    ///     g_variant_dict_init (&amp;dict, orig);
    ///     if (!g_variant_dict_lookup (&amp;dict, "count", "u", &amp;count))
    ///       {
    ///         g_set_error (...);
    ///         g_variant_dict_clear (&amp;dict);
    ///         return NULL;
    ///       }
    /// 
    ///     g_variant_dict_insert (&amp;dict, "count", "u", count + 1);
    /// 
    ///     return g_variant_dict_end (&amp;dict);
    ///   }
    /// ]|
    /// 
    /// ## Using heap-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict *dict;
    ///     GVariant *result;
    ///     guint32 count;
    /// 
    ///     dict = g_variant_dict_new (orig);
    /// 
    ///     if (g_variant_dict_lookup (dict, "count", "u", &amp;count))
    ///       {
    ///         g_variant_dict_insert (dict, "count", "u", count + 1);
    ///         result = g_variant_dict_end (dict);
    ///       }
    ///     else
    ///       {
    ///         g_set_error (...);
    ///         result = NULL;
    ///       }
    /// 
    ///     g_variant_dict_unref (dict);
    /// 
    ///     return result;
    ///   }
    /// ]|
    /// </remarks>
    [GISharp.Core.SinceAttribute("2.40")]
    public partial class VariantDict : GISharp.Core.ReferenceCountedOpaque<VariantDict>
    {
        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_new /* transfer-ownership:full */(
            System.IntPtr fromAsv /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public VariantDict(
            GISharp.GLib.Variant fromAsv)
        {
            var fromAsvPtr = default(System.IntPtr);
            Handle = g_variant_dict_new(fromAsvPtr);
        }

        /// <summary>
        /// Releases all memory associated with a #GVariantDict without freeing
        /// the #GVariantDict structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantDict if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_dict_end() and it also doesn't need to be called on dicts
        /// allocated with g_variant_dict_new (see g_variant_dict_unref() for
        /// that).
        /// 
        /// It is valid to call this function on either an initialised
        /// #GVariantDict or one that was previously cleared by an earlier call
        /// to g_variant_dict_clear() but it is not valid to call this function
        /// on uninitialised memory.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_dict_clear /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */);

        /// <summary>
        /// Releases all memory associated with a #GVariantDict without freeing
        /// the #GVariantDict structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantDict if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_dict_end() and it also doesn't need to be called on dicts
        /// allocated with g_variant_dict_new (see g_variant_dict_unref() for
        /// that).
        /// 
        /// It is valid to call this function on either an initialised
        /// #GVariantDict or one that was previously cleared by an earlier call
        /// to g_variant_dict_clear() but it is not valid to call this function
        /// on uninitialised memory.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.40")]
        public void Clear()
        {
            g_variant_dict_clear(Handle);
        }

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_dict_contains /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public System.Boolean Contains(
            System.String key)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var keyPtr = default(System.IntPtr);
            var ret = g_variant_dict_contains(Handle, keyPtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_end /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */);

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public GISharp.GLib.Variant End()
        {
            var retPtr = g_variant_dict_end(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Initialises a #GVariantDict structure.
        /// </summary>
        /// <remarks>
        /// If @from_asv is given, it is used to initialise the dictionary.
        /// 
        /// This function completely ignores the previous contents of @dict.  On
        /// one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantDict you need to first
        /// call g_variant_dict_clear() in order to avoid leaking memory.
        /// 
        /// You must not call g_variant_dict_ref() or g_variant_dict_unref() on a
        /// #GVariantDict that was initialised with this function.  If you ever
        /// pass a reference to a #GVariantDict outside of the control of your
        /// own code then you should assume that the person receiving that
        /// reference may try to use reference counting; you should use
        /// g_variant_dict_new() instead of this function.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="fromAsv">
        /// the initial value for @dict
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_dict_init /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */,
            System.IntPtr fromAsv /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Initialises a #GVariantDict structure.
        /// </summary>
        /// <remarks>
        /// If @from_asv is given, it is used to initialise the dictionary.
        /// 
        /// This function completely ignores the previous contents of @dict.  On
        /// one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantDict you need to first
        /// call g_variant_dict_clear() in order to avoid leaking memory.
        /// 
        /// You must not call g_variant_dict_ref() or g_variant_dict_unref() on a
        /// #GVariantDict that was initialised with this function.  If you ever
        /// pass a reference to a #GVariantDict outside of the control of your
        /// own code then you should assume that the person receiving that
        /// reference may try to use reference counting; you should use
        /// g_variant_dict_new() instead of this function.
        /// </remarks>
        /// <param name="fromAsv">
        /// the initial value for @dict
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        public void Init(
            GISharp.GLib.Variant fromAsv)
        {
            var fromAsvPtr = default(System.IntPtr);
            g_variant_dict_init(Handle, fromAsvPtr);
        }

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_dict_insert_value /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        public void InsertValue(
            System.String key,
            GISharp.GLib.Variant value)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var keyPtr = default(System.IntPtr);
            var valuePtr = default(System.IntPtr);
            g_variant_dict_insert_value(Handle, keyPtr, valuePtr);
        }

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_lookup_value /* transfer-ownership:full */(
            System.IntPtr dict /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr expectedType /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public GISharp.GLib.Variant LookupValue(
            System.String key,
            GISharp.GLib.VariantType expectedType)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var keyPtr = default(System.IntPtr);
            var expectedTypePtr = default(System.IntPtr);
            var retPtr = g_variant_dict_lookup_value(Handle, keyPtr, expectedTypePtr);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_ref /* transfer-ownership:full skip:1 */(
            System.IntPtr dict /* transfer-ownership:none */);

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.40")]
        protected override void Ref()
        {
            g_variant_dict_ref(Handle);
        }

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_dict_remove /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:none */,
            System.IntPtr key /* transfer-ownership:none */);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Core.SinceAttribute("2.40")]
        public System.Boolean Remove(
            System.String key)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            var keyPtr = default(System.IntPtr);
            var ret = g_variant_dict_remove(Handle, keyPtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        [GISharp.Core.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_dict_unref /* transfer-ownership:none */(
            System.IntPtr dict /* transfer-ownership:full */);

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.40")]
        protected override void Unref()
        {
            g_variant_dict_unref(Handle);
        }
    }

    /// <summary>
    /// #GVariantIter is an opaque data structure and can only be accessed
    /// using the following functions.
    /// </summary>
    public partial class VariantIter : GISharp.Core.OwnedOpaque<VariantIter>
    {
        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_copy /* transfer-ownership:full */(
            System.IntPtr iter /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public override GISharp.GLib.VariantIter Copy()
        {
            var retPtr = g_variant_iter_copy(Handle);
            return default(GISharp.GLib.VariantIter);
        }

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        /// <param name="iter">
        /// a heap-allocated #GVariantIter
        /// </param>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_iter_free /* transfer-ownership:none */(
            System.IntPtr iter /* transfer-ownership:full */);

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        [GISharp.Core.SinceAttribute("2.24")]
        protected override void Free()
        {
            g_variant_iter_free(Handle);
        }

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="iter">
        /// a pointer to a #GVariantIter
        /// </param>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_iter_init /* transfer-ownership:none */(
            System.IntPtr iter /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt64 Init(
            GISharp.GLib.Variant value)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var valuePtr = default(System.IntPtr);
            var ret = g_variant_iter_init(Handle, valuePtr);
            return default(System.UInt64);
        }

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_iter_n_children /* transfer-ownership:none */(
            System.IntPtr iter /* transfer-ownership:none */);

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public System.UInt64 NChildren()
        {
            var ret = g_variant_iter_n_children(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        /// 
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        /// 
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        /// 
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        /// 
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_next_value /* transfer-ownership:full */(
            System.IntPtr iter /* transfer-ownership:none */);

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        /// 
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        /// 
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        /// 
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        /// 
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public GISharp.GLib.Variant NextValue()
        {
            var retPtr = g_variant_iter_next_value(Handle);
            return default(GISharp.GLib.Variant);
        }
    }

    /// <summary>
    /// Error codes returned by parsing text-format GVariants.
    /// </summary>
    [GISharp.Core.ErrorDomainAttribute("g-variant-parse-error-quark")]
    public enum VariantParseError
    {
        /// <summary>
        /// generic error (unused)
        /// </summary>
        Failed = 0,
        /// <summary>
        /// a non-basic #GVariantType was given where a basic type was expected
        /// </summary>
        BasicTypeExpected = 1,
        /// <summary>
        /// cannot infer the #GVariantType
        /// </summary>
        CannotInferType = 2,
        /// <summary>
        /// an indefinite #GVariantType was given where a definite type was expected
        /// </summary>
        DefiniteTypeExpected = 3,
        /// <summary>
        /// extra data after parsing finished
        /// </summary>
        InputNotAtEnd = 4,
        /// <summary>
        /// invalid character in number or unicode escape
        /// </summary>
        InvalidCharacter = 5,
        /// <summary>
        /// not a valid #GVariant format string
        /// </summary>
        InvalidFormatString = 6,
        /// <summary>
        /// not a valid object path
        /// </summary>
        InvalidObjectPath = 7,
        /// <summary>
        /// not a valid type signature
        /// </summary>
        InvalidSignature = 8,
        /// <summary>
        /// not a valid #GVariant type string
        /// </summary>
        InvalidTypeString = 9,
        /// <summary>
        /// could not find a common type for array entries
        /// </summary>
        NoCommonType = 10,
        /// <summary>
        /// the numerical value is out of range of the given type
        /// </summary>
        NumberOutOfRange = 11,
        /// <summary>
        /// the numerical value is out of range for any type
        /// </summary>
        NumberTooBig = 12,
        /// <summary>
        /// cannot parse as variant of the specified type
        /// </summary>
        TypeError = 13,
        /// <summary>
        /// an unexpected token was encountered
        /// </summary>
        UnexpectedToken = 14,
        /// <summary>
        /// an unknown keyword was encountered
        /// </summary>
        UnknownKeyword = 15,
        /// <summary>
        /// unterminated string constant
        /// </summary>
        UnterminatedStringConstant = 16,
        /// <summary>
        /// no value given
        /// </summary>
        ValueExpected = 17
    }

    /// <summary>
    /// This section introduces the GVariant type system. It is based, in
    /// large part, on the D-Bus type system, with two major changes and
    /// some minor lifting of restrictions. The
    /// [D-Bus specification](http://dbus.freedesktop.org/doc/dbus-specification.html),
    /// therefore, provides a significant amount of
    /// information that is useful when working with GVariant.
    /// </summary>
    /// <remarks>
    /// The first major change with respect to the D-Bus type system is the
    /// introduction of maybe (or "nullable") types.  Any type in GVariant can be
    /// converted to a maybe type, in which case, "nothing" (or "null") becomes a
    /// valid value.  Maybe types have been added by introducing the
    /// character "m" to type strings.
    /// 
    /// The second major change is that the GVariant type system supports the
    /// concept of "indefinite types" -- types that are less specific than
    /// the normal types found in D-Bus.  For example, it is possible to speak
    /// of "an array of any type" in GVariant, where the D-Bus type system
    /// would require you to speak of "an array of integers" or "an array of
    /// strings".  Indefinite types have been added by introducing the
    /// characters "*", "?" and "r" to type strings.
    /// 
    /// Finally, all arbitrary restrictions relating to the complexity of
    /// types are lifted along with the restriction that dictionary entries
    /// may only appear nested inside of arrays.
    /// 
    /// Just as in D-Bus, GVariant types are described with strings ("type
    /// strings").  Subject to the differences mentioned above, these strings
    /// are of the same form as those found in DBus.  Note, however: D-Bus
    /// always works in terms of messages and therefore individual type
    /// strings appear nowhere in its interface.  Instead, "signatures"
    /// are a concatenation of the strings of the type of each argument in a
    /// message.  GVariant deals with single values directly so GVariant type
    /// strings always describe the type of exactly one value.  This means
    /// that a D-Bus signature string is generally not a valid GVariant type
    /// string -- except in the case that it is the signature of a message
    /// containing exactly one argument.
    /// 
    /// An indefinite type is similar in spirit to what may be called an
    /// abstract type in other type systems.  No value can exist that has an
    /// indefinite type as its type, but values can exist that have types
    /// that are subtypes of indefinite types.  That is to say,
    /// g_variant_get_type() will never return an indefinite type, but
    /// calling g_variant_is_of_type() with an indefinite type may return
    /// %TRUE.  For example, you cannot have a value that represents "an
    /// array of no particular type", but you can have an "array of integers"
    /// which certainly matches the type of "an array of no particular type",
    /// since "array of integers" is a subtype of "array of no particular
    /// type".
    /// 
    /// This is similar to how instances of abstract classes may not
    /// directly exist in other type systems, but instances of their
    /// non-abstract subtypes may.  For example, in GTK, no object that has
    /// the type of #GtkBin can exist (since #GtkBin is an abstract class),
    /// but a #GtkWindow can certainly be instantiated, and you would say
    /// that the #GtkWindow is a #GtkBin (since #GtkWindow is a subclass of
    /// #GtkBin).
    /// 
    /// ## GVariant Type Strings
    /// 
    /// A GVariant type string can be any of the following:
    /// 
    /// - any basic type string (listed below)
    /// 
    /// - "v", "r" or "*"
    /// 
    /// - one of the characters 'a' or 'm', followed by another type string
    /// 
    /// - the character '(', followed by a concatenation of zero or more other
    ///   type strings, followed by the character ')'
    /// 
    /// - the character '{', followed by a basic type string (see below),
    ///   followed by another type string, followed by the character '}'
    /// 
    /// A basic type string describes a basic type (as per
    /// g_variant_type_is_basic()) and is always a single character in length.
    /// The valid basic type strings are "b", "y", "n", "q", "i", "u", "x", "t",
    /// "h", "d", "s", "o", "g" and "?".
    /// 
    /// The above definition is recursive to arbitrary depth. "aaaaai" and
    /// "(ui(nq((y)))s)" are both valid type strings, as is
    /// "a(aa(ui)(qna{ya(yd)}))".
    /// 
    /// The meaning of each of the characters is as follows:
    /// - `b`: the type string of %G_VARIANT_TYPE_BOOLEAN; a boolean value.
    /// - `y`: the type string of %G_VARIANT_TYPE_BYTE; a byte.
    /// - `n`: the type string of %G_VARIANT_TYPE_INT16; a signed 16 bit integer.
    /// - `q`: the type string of %G_VARIANT_TYPE_UINT16; an unsigned 16 bit integer.
    /// - `i`: the type string of %G_VARIANT_TYPE_INT32; a signed 32 bit integer.
    /// - `u`: the type string of %G_VARIANT_TYPE_UINT32; an unsigned 32 bit integer.
    /// - `x`: the type string of %G_VARIANT_TYPE_INT64; a signed 64 bit integer.
    /// - `t`: the type string of %G_VARIANT_TYPE_UINT64; an unsigned 64 bit integer.
    /// - `h`: the type string of %G_VARIANT_TYPE_HANDLE; a signed 32 bit value
    ///   that, by convention, is used as an index into an array of file
    ///   descriptors that are sent alongside a D-Bus message.
    /// - `d`: the type string of %G_VARIANT_TYPE_DOUBLE; a double precision
    ///   floating point value.
    /// - `s`: the type string of %G_VARIANT_TYPE_STRING; a string.
    /// - `o`: the type string of %G_VARIANT_TYPE_OBJECT_PATH; a string in the form
    ///   of a D-Bus object path.
    /// - `g`: the type string of %G_VARIANT_TYPE_STRING; a string in the form of
    ///   a D-Bus type signature.
    /// - `?`: the type string of %G_VARIANT_TYPE_BASIC; an indefinite type that
    ///   is a supertype of any of the basic types.
    /// - `v`: the type string of %G_VARIANT_TYPE_VARIANT; a container type that
    ///   contain any other type of value.
    /// - `a`: used as a prefix on another type string to mean an array of that
    ///   type; the type string "ai", for example, is the type of an array of
    ///   signed 32-bit integers.
    /// - `m`: used as a prefix on another type string to mean a "maybe", or
    ///   "nullable", version of that type; the type string "ms", for example,
    ///   is the type of a value that maybe contains a string, or maybe contains
    ///   nothing.
    /// - `()`: used to enclose zero or more other concatenated type strings to
    ///   create a tuple type; the type string "(is)", for example, is the type of
    ///   a pair of an integer and a string.
    /// - `r`: the type string of %G_VARIANT_TYPE_TUPLE; an indefinite type that is
    ///   a supertype of any tuple type, regardless of the number of items.
    /// - `{}`: used to enclose a basic type string concatenated with another type
    ///   string to create a dictionary entry type, which usually appears inside of
    ///   an array to form a dictionary; the type string "a{sd}", for example, is
    ///   the type of a dictionary that maps strings to double precision floating
    ///   point values.
    /// 
    ///   The first type (the basic type) is the key type and the second type is
    ///   the value type. The reason that the first type is restricted to being a
    ///   basic type is so that it can easily be hashed.
    /// - `*`: the type string of %G_VARIANT_TYPE_ANY; the indefinite type that is
    ///   a supertype of all types.  Note that, as with all type strings, this
    ///   character represents exactly one type. It cannot be used inside of tuples
    ///   to mean "any number of items".
    /// 
    /// Any type string of a container that contains an indefinite type is,
    /// itself, an indefinite type. For example, the type string "a*"
    /// (corresponding to %G_VARIANT_TYPE_ARRAY) is an indefinite type
    /// that is a supertype of every array type. "(*s)" is a supertype
    /// of all tuples that contain exactly two items where the second
    /// item is a string.
    /// 
    /// "a{?*}" is an indefinite type that is a supertype of all arrays
    /// containing dictionary entries where the key is any basic type and
    /// the value is any type at all.  This is, by definition, a dictionary,
    /// so this type string corresponds to %G_VARIANT_TYPE_DICTIONARY. Note
    /// that, due to the restriction that the key of a dictionary entry must
    /// be a basic type, "{**}" is not a valid type string.
    /// </remarks>
    public partial class VariantType : GISharp.Core.OwnedOpaque<VariantType>, System.IEquatable<VariantType>
    {
        /// <summary>
        /// Creates a new #GVariantType corresponding to the type string given
        /// by @type_string.  It is appropriate to call g_variant_type_free() on
        /// the return value.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to call this function with an invalid type
        /// string.  Use g_variant_type_string_is_valid() if you are unsure.
        /// </remarks>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new /* transfer-ownership:full */(
            System.IntPtr typeString /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new #GVariantType corresponding to the type string given
        /// by @type_string.  It is appropriate to call g_variant_type_free() on
        /// the return value.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to call this function with an invalid type
        /// string.  Use g_variant_type_string_is_valid() if you are unsure.
        /// </remarks>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public VariantType(
            System.String typeString)
        {
            if (typeString == null)
            {
                throw new System.ArgumentNullException("typeString");
            }
            var typeStringPtr = default(System.IntPtr);
            Handle = g_variant_type_new(typeStringPtr);
        }

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type @type.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new array #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_array /* transfer-ownership:full */(
            System.IntPtr element /* transfer-ownership:none */);

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type @type.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new array #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewArray(
            GISharp.GLib.VariantType element)
        {
            if (element == null)
            {
                throw new System.ArgumentNullException("element");
            }
            var elementPtr = default(System.IntPtr);
            var retPtr = g_variant_type_new_array(elementPtr);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type @key and a value of type @value.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariantType
        /// </param>
        /// <param name="value">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new dictionary entry #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_dict_entry /* transfer-ownership:full */(
            System.IntPtr key /* transfer-ownership:none */,
            System.IntPtr value /* transfer-ownership:none */);

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type @key and a value of type @value.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariantType
        /// </param>
        /// <param name="value">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new dictionary entry #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewDictEntry(
            GISharp.GLib.VariantType key,
            GISharp.GLib.VariantType value)
        {
            if (key == null)
            {
                throw new System.ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            var keyPtr = default(System.IntPtr);
            var valuePtr = default(System.IntPtr);
            var retPtr = g_variant_type_new_dict_entry(keyPtr, valuePtr);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type @type or Nothing.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new maybe #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_maybe /* transfer-ownership:full */(
            System.IntPtr element /* transfer-ownership:none */);

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type @type or Nothing.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new maybe #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewMaybe(
            GISharp.GLib.VariantType element)
        {
            if (element == null)
            {
                throw new System.ArgumentNullException("element");
            }
            var elementPtr = default(System.IntPtr);
            var retPtr = g_variant_type_new_maybe(elementPtr);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs a new tuple type, from @items.
        /// </summary>
        /// <remarks>
        /// @length is the number of items in @items, or -1 to indicate that
        /// @items is %NULL-terminated.
        /// 
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="items">
        /// an array of #GVariantTypes, one for each item
        /// </param>
        /// <param name="length">
        /// the length of @items, or -1
        /// </param>
        /// <returns>
        /// a new tuple #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_tuple /* transfer-ownership:full */(
            System.IntPtr items /* transfer-ownership:none */,
            System.Int32 length /* transfer-ownership:none */);

        /// <summary>
        /// Constructs a new tuple type, from @items.
        /// </summary>
        /// <remarks>
        /// @length is the number of items in @items, or -1 to indicate that
        /// @items is %NULL-terminated.
        /// 
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="items">
        /// an array of #GVariantTypes, one for each item
        /// </param>
        /// <returns>
        /// a new tuple #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewTuple(
            GISharp.GLib.VariantType[] items)
        {
            if (items == null)
            {
                throw new System.ArgumentNullException("items");
            }
            var itemsPtr = default(System.IntPtr);
            var length = (System.Int32)items.Length;
            var retPtr = g_variant_type_new_tuple(itemsPtr, length);
            return default(GISharp.GLib.VariantType);
        }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_checked_ /* transfer-ownership:none */(
System.IntPtr arg0 /* transfer-ownership:none */);

        public static GISharp.GLib.VariantType Checked(
System.String arg0)
        {
            if (arg0 == null)
            {
                throw new System.ArgumentNullException("arg0");
            }
            var arg0Ptr = default(System.IntPtr);
            var retPtr = g_variant_type_checked_(arg0Ptr);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Checks if @type_string is a valid GVariant type string.  This call is
        /// equivalent to calling g_variant_type_string_scan() and confirming
        /// that the following character is a nul terminator.
        /// </summary>
        /// <param name="typeString">
        /// a pointer to any string
        /// </param>
        /// <returns>
        /// %TRUE if @type_string is exactly one valid type string
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_string_is_valid /* transfer-ownership:none */(
            System.IntPtr typeString /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @type_string is a valid GVariant type string.  This call is
        /// equivalent to calling g_variant_type_string_scan() and confirming
        /// that the following character is a nul terminator.
        /// </summary>
        /// <param name="typeString">
        /// a pointer to any string
        /// </param>
        /// <returns>
        /// %TRUE if @type_string is exactly one valid type string
        /// 
        /// Since 2.24
        /// </returns>
        public static System.Boolean StringIsValid(
            System.String typeString)
        {
            if (typeString == null)
            {
                throw new System.ArgumentNullException("typeString");
            }
            var typeStringPtr = default(System.IntPtr);
            var ret = g_variant_type_string_is_valid(typeStringPtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Scan for a single complete and valid GVariant type string in @string.
        /// The memory pointed to by @limit (or bytes beyond it) is never
        /// accessed.
        /// </summary>
        /// <remarks>
        /// If a valid type string is found, @endptr is updated to point to the
        /// first character past the end of the string that was found and %TRUE
        /// is returned.
        /// 
        /// If there is no valid type string starting at @string, or if the type
        /// string does not end before @limit then %FALSE is returned.
        /// 
        /// For the simple case of checking if a string is a valid type string,
        /// see g_variant_type_string_is_valid().
        /// </remarks>
        /// <param name="string">
        /// a pointer to any string
        /// </param>
        /// <param name="limit">
        /// the end of @string, or %NULL
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if a valid type string was found
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_string_scan /* transfer-ownership:none */(
            System.IntPtr @string /* transfer-ownership:none */,
            System.IntPtr limit /* transfer-ownership:none nullable:1 allow-none:1 */,
            out System.IntPtr endptr /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */);

        /// <summary>
        /// Scan for a single complete and valid GVariant type string in @string.
        /// The memory pointed to by @limit (or bytes beyond it) is never
        /// accessed.
        /// </summary>
        /// <remarks>
        /// If a valid type string is found, @endptr is updated to point to the
        /// first character past the end of the string that was found and %TRUE
        /// is returned.
        /// 
        /// If there is no valid type string starting at @string, or if the type
        /// string does not end before @limit then %FALSE is returned.
        /// 
        /// For the simple case of checking if a string is a valid type string,
        /// see g_variant_type_string_is_valid().
        /// </remarks>
        /// <param name="string">
        /// a pointer to any string
        /// </param>
        /// <param name="limit">
        /// the end of @string, or %NULL
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if a valid type string was found
        /// </returns>
        [GISharp.Core.SinceAttribute("2.24")]
        public static System.Boolean StringScan(
            System.String @string,
            System.String limit,
            out System.String endptr)
        {
            if (@string == null)
            {
                throw new System.ArgumentNullException("@string");
            }
            var @stringPtr = default(System.IntPtr);
            var limitPtr = default(System.IntPtr);
            var endptrPtr = default(System.IntPtr);
            var ret = g_variant_type_string_scan(@stringPtr, limitPtr,out endptrPtr);
            endptr = default(System.String); return default(System.Boolean);
        }

        /// <summary>
        /// Makes a copy of a #GVariantType.  It is appropriate to call
        /// g_variant_type_free() on the return value.  @type may not be %NULL.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_copy /* transfer-ownership:full */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Makes a copy of a #GVariantType.  It is appropriate to call
        /// g_variant_type_free() on the return value.  @type may not be %NULL.
        /// </summary>
        /// <returns>
        /// a new #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public override GISharp.GLib.VariantType Copy()
        {
            var retPtr = g_variant_type_copy(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_dup_string /* transfer-ownership:full */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <returns>
        /// the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        public override System.String ToString()
        {
            var retPtr = g_variant_type_dup_string(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <param name="type">
        /// an array or maybe #GVariantType
        /// </param>
        /// <returns>
        /// the element type of @type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_element /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <returns>
        /// the element type of @type
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Element()
        {
            var retPtr = g_variant_type_element(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Compares @type1 and @type2 for equality.
        /// </summary>
        /// <remarks>
        /// Only returns %TRUE if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, %FALSE will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use g_variant_type_is_subtype_of().
        /// 
        /// The argument types of @type1 and @type2 are only #gconstpointer to
        /// allow use with #GHashTable without function pointer casting.  For
        /// both arguments, a valid #GVariantType must be provided.
        /// </remarks>
        /// <param name="type1">
        /// a #GVariantType
        /// </param>
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_equal /* transfer-ownership:none */(
            System.IntPtr type1 /* transfer-ownership:none */,
            System.IntPtr type2 /* transfer-ownership:none */);

        /// <summary>
        /// Compares @type1 and @type2 for equality.
        /// </summary>
        /// <remarks>
        /// Only returns %TRUE if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, %FALSE will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use g_variant_type_is_subtype_of().
        /// 
        /// The argument types of @type1 and @type2 are only #gconstpointer to
        /// allow use with #GHashTable without function pointer casting.  For
        /// both arguments, a valid #GVariantType must be provided.
        /// </remarks>
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean Equals(
            GISharp.GLib.VariantType type2)
        {
            if (type2 == null)
            {
                throw new System.ArgumentNullException("type2");
            }
            var type2Ptr = default(System.IntPtr);
            var ret = g_variant_type_equal(Handle, type2Ptr);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as VariantType);
        }

        public static bool operator ==(VariantType one, VariantType two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(VariantType one, VariantType two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Determines the first item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        /// 
        /// %NULL is returned in case of @type being %G_VARIANT_TYPE_UNIT.
        /// 
        /// This call, together with g_variant_type_next() provides an iterator
        /// interface over tuple and dictionary entry types.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the first item type of @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_first /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the first item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        /// 
        /// %NULL is returned in case of @type being %G_VARIANT_TYPE_UNIT.
        /// 
        /// This call, together with g_variant_type_next() provides an iterator
        /// interface over tuple and dictionary entry types.
        /// </remarks>
        /// <returns>
        /// the first item type of @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType First()
        {
            var retPtr = g_variant_type_first(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Frees a #GVariantType that was allocated with
        /// g_variant_type_copy(), g_variant_type_new() or one of the container
        /// type constructor functions.
        /// </summary>
        /// <remarks>
        /// In the case that @type is %NULL, this function does nothing.
        /// 
        /// Since 2.24
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_variant_type_free /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none nullable:1 allow-none:1 */);

        /// <summary>
        /// Frees a #GVariantType that was allocated with
        /// g_variant_type_copy(), g_variant_type_new() or one of the container
        /// type constructor functions.
        /// </summary>
        /// <remarks>
        /// In the case that @type is %NULL, this function does nothing.
        /// 
        /// Since 2.24
        /// </remarks>
        protected override void Free()
        {
            g_variant_type_free(Handle);
        }

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the length of the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_type_get_string_length /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <returns>
        /// the length of the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        public System.UInt64 StringLength
        {
            get
            {
                var ret = g_variant_type_get_string_length(Handle);
                return default(System.UInt64);
            }
        }

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the hash value
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_type_hash /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <returns>
        /// the hash value
        /// 
        /// Since 2.24
        /// </returns>
        protected System.UInt32 Hash()
        {
            var ret = g_variant_type_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is an array type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_array /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is an array type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsArray
        {
            get
            {
                var ret = g_variant_type_is_array(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        /// 
        /// Only a basic type may be used as the key of a dictionary entry.
        /// 
        /// This function returns %FALSE for all indefinite types except
        /// %G_VARIANT_TYPE_BASIC.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a basic type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_basic /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        /// 
        /// Only a basic type may be used as the key of a dictionary entry.
        /// 
        /// This function returns %FALSE for all indefinite types except
        /// %G_VARIANT_TYPE_BASIC.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a basic type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsBasic
        {
            get
            {
                var ret = g_variant_type_is_basic(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        /// 
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a container -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a container type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_container /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        /// 
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a container -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a container type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsContainer
        {
            get
            {
                var ret = g_variant_type_is_container(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is definite (ie: not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        /// 
        /// A #GVariant instance may not have an indefinite type, so calling
        /// this function on the result of g_variant_get_type() will always
        /// result in %TRUE being returned.  Calling this function on an
        /// indefinite type like %G_VARIANT_TYPE_ARRAY, however, will result in
        /// %FALSE being returned.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is definite
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_definite /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is definite (ie: not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        /// 
        /// A #GVariant instance may not have an indefinite type, so calling
        /// this function on the result of g_variant_get_type() will always
        /// result in %TRUE being returned.  Calling this function on an
        /// indefinite type like %G_VARIANT_TYPE_ARRAY, however, will result in
        /// %FALSE being returned.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is definite
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsDefinite
        {
            get
            {
                var ret = g_variant_type_is_definite(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_dict_entry /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsDictEntry
        {
            get
            {
                var ret = g_variant_type_is_dict_entry(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a maybe type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_maybe /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a maybe type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsMaybe
        {
            get
            {
                var ret = g_variant_type_is_maybe(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_subtype_of /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */,
            System.IntPtr supertype /* transfer-ownership:none */);

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsSubtypeOf(
            GISharp.GLib.VariantType supertype)
        {
            if (supertype == null)
            {
                throw new System.ArgumentNullException("supertype");
            }
            var supertypePtr = default(System.IntPtr);
            var ret = g_variant_type_is_subtype_of(Handle, supertypePtr);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a tuple type.  This is true if the
        /// type string for @type starts with a '(' or if @type is
        /// %G_VARIANT_TYPE_TUPLE.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a tuple type -- %G_VARIANT_TYPE_TUPLE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a tuple type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_tuple /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is a tuple type.  This is true if the
        /// type string for @type starts with a '(' or if @type is
        /// %G_VARIANT_TYPE_TUPLE.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a tuple type -- %G_VARIANT_TYPE_TUPLE, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a tuple type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsTuple
        {
            get
            {
                var ret = g_variant_type_is_tuple(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is the variant type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_variant /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <returns>
        /// %TRUE if @type is the variant type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsVariant
        {
            get
            {
                var ret = g_variant_type_is_variant(Handle);
                return default(System.Boolean);
            }
        }

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the key type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_key /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <returns>
        /// the key type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Key()
        {
            var retPtr = g_variant_type_key(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the number of items in @type
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_type_n_items /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <returns>
        /// the number of items in @type
        /// 
        /// Since 2.24
        /// </returns>
        public System.UInt64 NItems()
        {
            var ret = g_variant_type_n_items(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Determines the next item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// @type must be the result of a previous call to
        /// g_variant_type_first() or g_variant_type_next().
        /// 
        /// If called on the key type of a dictionary entry then this call
        /// returns the value type.  If called on the value type of a dictionary
        /// entry then this call returns %NULL.
        /// 
        /// For tuples, %NULL is returned when @type is the last item in a tuple.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType from a previous call
        /// </param>
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_next /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the next item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// @type must be the result of a previous call to
        /// g_variant_type_first() or g_variant_type_next().
        /// 
        /// If called on the key type of a dictionary entry then this call
        /// returns the value type.  If called on the value type of a dictionary
        /// entry then this call returns %NULL.
        /// 
        /// For tuples, %NULL is returned when @type is the last item in a tuple.
        /// </remarks>
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Next()
        {
            var retPtr = g_variant_type_next(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_peek_string /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        /// 
        /// Since 2.24
        /// </returns>
        public System.String PeekString()
        {
            var retPtr = g_variant_type_peek_string(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the value type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_value /* transfer-ownership:none */(
            System.IntPtr type /* transfer-ownership:none */);

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <returns>
        /// the value type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Value()
        {
            var retPtr = g_variant_type_value(Handle);
            return default(GISharp.GLib.VariantType);
        }
    }

    /// <summary>
    /// Declares a type of function which takes no arguments
    /// and has no return value. It is used to specify the type
    /// function passed to g_atexit().
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void VoidFunc();

    /// <summary>
    /// Declares a type of function which takes no arguments
    /// and has no return value. It is used to specify the type
    /// function passed to g_atexit().
    /// </summary>
    public delegate void VoidFuncCallback();

    public static partial class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the main loop context using g_source_attach().
        /// You can do these steps manually if you need greater control.
        /// </remarks>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        ///            range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the idle is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_idle_add_full /* transfer-ownership:none */(
            System.Int32 priority /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc function /* transfer-ownership:none scope:notified closure:2 destroy:3 */,
            System.IntPtr data /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none nullable:1 allow-none:1 scope:async */);

        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the main loop context using g_source_attach().
        /// You can do these steps manually if you need greater control.
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        ///            range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        public static System.UInt32 Add(
            GISharp.GLib.SourceFuncCallback function,
            System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var data = default(System.IntPtr);
            var functionNative = default(GISharp.GLib.SourceFunc);
            var ret = g_idle_add_full(priority, functionNative, data, notifyNative);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes the idle function with the given data.
        /// </summary>
        /// <param name="data">
        /// the data for the idle source's callback.
        /// </param>
        /// <returns>
        /// %TRUE if an idle source was found and removed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.Boolean g_idle_remove_by_data /* transfer-ownership:none */(
            System.IntPtr data /* transfer-ownership:none */);

        /// <summary>
        /// Removes the idle function with the given data.
        /// </summary>
        /// <param name="data">
        /// the data for the idle source's callback.
        /// </param>
        /// <returns>
        /// %TRUE if an idle source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByData(
            System.IntPtr data)
        {
            var ret = g_idle_remove_by_data(data);
            return default(System.Boolean);
        }

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_idle_source_new /* transfer-ownership:full */();

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        public static GISharp.GLib.Source SourceNew()
        {
            var retPtr = g_idle_source_new();
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class Log
    {
        /// <summary>
        /// Defines the log domain.
        /// </summary>
        /// <remarks>
        /// For applications, this is typically left as the default %NULL
        /// (or "") domain. Libraries should define this so that any messages
        /// which they log can be differentiated from messages from other
        /// libraries and application code. But be careful not to define
        /// it in any public header files.
        /// 
        /// For example, GTK+ uses this in its Makefile.am:
        /// |[
        /// INCLUDES = -DG_LOG_DOMAIN=\"Gtk\"
        /// ]|
        /// </remarks>
        public const System.SByte Domain = 0;

        /// <summary>
        /// GLib log levels that are considered fatal by default.
        /// </summary>
        public const System.Int32 FatalMask = 0;

        /// <summary>
        /// Log levels below 1&lt;&lt;G_LOG_LEVEL_USER_SHIFT are used by GLib.
        /// Higher bits can be used for user-defined log levels.
        /// </summary>
        public const System.Int32 LevelUserShift = 8;

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   aplication.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        /// <param name="unusedData">
        /// data passed from g_log() which is unused
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_log_default_handler /* transfer-ownership:none */(
            System.IntPtr logDomain /* transfer-ownership:none */,
            GISharp.GLib.LogLevelFlags logLevel /* transfer-ownership:none */,
            System.IntPtr message /* transfer-ownership:none */,
            System.IntPtr unusedData /* transfer-ownership:none */);

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   aplication.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        /// <param name="unusedData">
        /// data passed from g_log() which is unused
        /// </param>
        public static void DefaultHandler(
            System.String logDomain,
            GISharp.GLib.LogLevelFlags logLevel,
            System.String message,
            System.IntPtr unusedData)
        {
            if (logDomain == null)
            {
                throw new System.ArgumentNullException("logDomain");
            }
            if (message == null)
            {
                throw new System.ArgumentNullException("message");
            }
            var logDomainPtr = default(System.IntPtr);
            var messagePtr = default(System.IntPtr);
            g_log_default_handler(logDomainPtr, logLevel, messagePtr, unusedData);
        }

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_log_remove_handler /* transfer-ownership:none */(
            System.IntPtr logDomain /* transfer-ownership:none */,
            System.UInt32 handlerId /* transfer-ownership:none */);

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        public static void RemoveHandler(
            System.String logDomain,
            System.UInt32 handlerId)
        {
            if (logDomain == null)
            {
                throw new System.ArgumentNullException("logDomain");
            }
            var logDomainPtr = default(System.IntPtr);
            g_log_remove_handler(logDomainPtr, handlerId);
        }

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.LogLevelFlags g_log_set_always_fatal /* transfer-ownership:none */(
            GISharp.GLib.LogLevelFlags fatalMask /* transfer-ownership:none */);

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        public static GISharp.GLib.LogLevelFlags SetAlwaysFatal(
            GISharp.GLib.LogLevelFlags fatalMask)
        {
            var ret = g_log_set_always_fatal(fatalMask);
            return default(GISharp.GLib.LogLevelFlags);
        }

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <returns>
        /// the previous default log handler
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.LogFunc g_log_set_default_handler /* */(
            GISharp.GLib.LogFunc logFunc /* transfer-ownership:none closure:1 */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <returns>
        /// the previous default log handler
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public static GISharp.GLib.LogFuncCallback SetDefaultHandler(
            GISharp.GLib.LogFuncCallback logFunc)
        {
            if (logFunc == null)
            {
                throw new System.ArgumentNullException("logFunc");
            }
            var userData = default(System.IntPtr);
            var logFuncNative = default(GISharp.GLib.LogFunc);
            var retPtr = g_log_set_default_handler(logFuncNative, userData);
            return default(GISharp.GLib.LogFuncCallback);
        }

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern GISharp.GLib.LogLevelFlags g_log_set_fatal_mask /* transfer-ownership:none */(
            System.IntPtr logDomain /* transfer-ownership:none */,
            GISharp.GLib.LogLevelFlags fatalMask /* transfer-ownership:none */);

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        public static GISharp.GLib.LogLevelFlags SetFatalMask(
            System.String logDomain,
            GISharp.GLib.LogLevelFlags fatalMask)
        {
            if (logDomain == null)
            {
                throw new System.ArgumentNullException("logDomain");
            }
            var logDomainPtr = default(System.IntPtr);
            var ret = g_log_set_fatal_mask(logDomainPtr, fatalMask);
            return default(GISharp.GLib.LogLevelFlags);
        }

        /// <summary>
        /// Sets the log handler for a domain and a set of log levels.
        /// To handle fatal and recursive messages the @log_levels parameter
        /// must be combined with the #G_LOG_FLAG_FATAL and #G_LOG_FLAG_RECURSION
        /// bit flags.
        /// </summary>
        /// <remarks>
        /// Note that since the #G_LOG_LEVEL_ERROR log level is always fatal, if
        /// you want to set a handler for this log level you must combine it with
        /// #G_LOG_FLAG_FATAL.
        /// 
        /// Here is an example for adding a log handler for all warning messages
        /// in the default domain:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler (NULL, G_LOG_LEVEL_WARNING | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all critical messages from GTK+:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("Gtk", G_LOG_LEVEL_CRITICAL | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all messages from GLib:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("GLib", G_LOG_LEVEL_MASK | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///     application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///     To handle fatal and recursive messages as well, combine
        ///     the log levels with the #G_LOG_FLAG_FATAL and
        ///     #G_LOG_FLAG_RECURSION bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_log_set_handler /* transfer-ownership:none */(
            System.IntPtr logDomain /* transfer-ownership:none nullable:1 allow-none:1 */,
            GISharp.GLib.LogLevelFlags logLevels /* transfer-ownership:none */,
            GISharp.GLib.LogFunc logFunc /* transfer-ownership:none closure:3 */,
            System.IntPtr userData /* transfer-ownership:none */);

        /// <summary>
        /// Sets the log handler for a domain and a set of log levels.
        /// To handle fatal and recursive messages the @log_levels parameter
        /// must be combined with the #G_LOG_FLAG_FATAL and #G_LOG_FLAG_RECURSION
        /// bit flags.
        /// </summary>
        /// <remarks>
        /// Note that since the #G_LOG_LEVEL_ERROR log level is always fatal, if
        /// you want to set a handler for this log level you must combine it with
        /// #G_LOG_FLAG_FATAL.
        /// 
        /// Here is an example for adding a log handler for all warning messages
        /// in the default domain:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler (NULL, G_LOG_LEVEL_WARNING | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all critical messages from GTK+:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("Gtk", G_LOG_LEVEL_CRITICAL | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all messages from GLib:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("GLib", G_LOG_LEVEL_MASK | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///     application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///     To handle fatal and recursive messages as well, combine
        ///     the log levels with the #G_LOG_FLAG_FATAL and
        ///     #G_LOG_FLAG_RECURSION bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        public static System.UInt32 SetHandler(
            System.String logDomain,
            GISharp.GLib.LogLevelFlags logLevels,
            GISharp.GLib.LogFuncCallback logFunc)
        {
            if (logFunc == null)
            {
                throw new System.ArgumentNullException("logFunc");
            }
            var userData = default(System.IntPtr);
            var logDomainPtr = default(System.IntPtr);
            var logFuncNative = default(GISharp.GLib.LogFunc);
            var ret = g_log_set_handler(logDomainPtr, logLevels, logFuncNative, userData);
            return default(System.UInt32);
        }

        /// <summary>
        /// Logs an error or debugging message.
        /// </summary>
        /// <remarks>
        /// If the log level has been set as fatal, the abort()
        /// function is called to terminate the program.
        /// 
        /// If g_log_default_handler() is used as the log handler function, a new-line
        /// character will automatically be appended to @..., and need not be entered
        /// manually.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="logLevel">
        /// the log level
        /// </param>
        /// <param name="format">
        /// the message format. See the printf() documentation
        /// </param>
        /// <param name="args">
        /// the parameters to insert into the format string
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern void g_logv /* transfer-ownership:none */(
            System.IntPtr logDomain /* transfer-ownership:none */,
            GISharp.GLib.LogLevelFlags logLevel /* transfer-ownership:none */,
            System.IntPtr format /* transfer-ownership:none */,
            System.IntPtr args /* transfer-ownership:none */);

        /// <summary>
        /// Logs an error or debugging message.
        /// </summary>
        /// <remarks>
        /// If the log level has been set as fatal, the abort()
        /// function is called to terminate the program.
        /// 
        /// If g_log_default_handler() is used as the log handler function, a new-line
        /// character will automatically be appended to @..., and need not be entered
        /// manually.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="logLevel">
        /// the log level
        /// </param>
        /// <param name="format">
        /// the message format. See the printf() documentation
        /// </param>
        /// <param name="args">
        /// the parameters to insert into the format string
        /// </param>
        public static void Logv(
            System.String logDomain,
            GISharp.GLib.LogLevelFlags logLevel,
            System.String format,
            System.Object[] args)
        {
            if (logDomain == null)
            {
                throw new System.ArgumentNullException("logDomain");
            }
            if (format == null)
            {
                throw new System.ArgumentNullException("format");
            }
            if (args == null)
            {
                throw new System.ArgumentNullException("args");
            }
            var logDomainPtr = default(System.IntPtr);
            var formatPtr = default(System.IntPtr);
            var argsPtr = default(System.IntPtr);
            g_logv(logDomainPtr, logLevel, formatPtr, argsPtr);
        }
    }

    public static partial class Priority
    {
        /// <summary>
        /// Use this for default priority event sources.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding timeout functions
        /// with g_timeout_add(). In GDK this priority is used for events
        /// from the X server.
        /// </remarks>
        public const System.Int32 Default = 0;

        /// <summary>
        /// Use this for default priority idle functions.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding idle functions with
        /// g_idle_add().
        /// </remarks>
        public const System.Int32 DefaultIdle = 200;

        /// <summary>
        /// Use this for high priority event sources.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const System.Int32 High = -100;

        /// <summary>
        /// Use this for high priority idle functions.
        /// </summary>
        /// <remarks>
        /// GTK+ uses #G_PRIORITY_HIGH_IDLE + 10 for resizing operations,
        /// and #G_PRIORITY_HIGH_IDLE + 20 for redrawing operations. (This is
        /// done to ensure that any pending resizes are processed before any
        /// pending redraws, so that widgets are not redrawn twice unnecessarily.)
        /// </remarks>
        public const System.Int32 HighIdle = 100;

        /// <summary>
        /// Use this for very low priority background tasks.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const System.Int32 Low = 300;
    }

    public static partial class Timeout
    {
        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// %FALSE, at which point the timeout is automatically destroyed and
        /// the function will not be called again.  The @notify function is
        /// called when the timeout is destroyed.  The first call to the
        /// function will be at the end of the first @interval.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// This internally creates a main loop source using g_timeout_source_new()
        /// and attaches it to the main loop context using g_source_attach(). You can
        /// do these steps manually if you need greater control.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in milliseconds
        ///             (1/1000ths of a second)
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_timeout_add_full /* transfer-ownership:none */(
            System.Int32 priority /* transfer-ownership:none */,
            System.UInt32 interval /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc function /* transfer-ownership:none scope:notified closure:3 destroy:4 */,
            System.IntPtr data /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none nullable:1 allow-none:1 scope:async */);

        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// %FALSE, at which point the timeout is automatically destroyed and
        /// the function will not be called again.  The @notify function is
        /// called when the timeout is destroyed.  The first call to the
        /// function will be at the end of the first @interval.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// This internally creates a main loop source using g_timeout_source_new()
        /// and attaches it to the main loop context using g_source_attach(). You can
        /// do these steps manually if you need greater control.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the time between calls to the function, in milliseconds
        ///             (1/1000ths of a second)
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        public static System.UInt32 Add(
            System.UInt32 interval,
            GISharp.GLib.SourceFuncCallback function,
            System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var data = default(System.IntPtr);
            var functionNative = default(GISharp.GLib.SourceFunc);
            var ret = g_timeout_add_full(priority, interval, functionNative, data, notifyNative);
            return default(System.UInt32);
        }

        /// <summary>
        /// Sets a function to be called at regular intervals, with @priority.
        /// The function is called repeatedly until it returns %FALSE, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike g_timeout_add(), this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the @interval to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given @interval
        /// 
        /// If you want timing more precise than whole seconds, use g_timeout_add()
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of g_timeout_add_seconds() is preferred over g_timeout_add().
        /// 
        /// This internally creates a main loop source using
        /// g_timeout_source_new_seconds() and attaches it to the main loop context
        /// using g_source_attach(). You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_timeout_add_seconds_full /* transfer-ownership:none */(
            System.Int32 priority /* transfer-ownership:none */,
            System.UInt32 interval /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc function /* transfer-ownership:none scope:notified closure:3 destroy:4 */,
            System.IntPtr data /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none nullable:1 allow-none:1 scope:async */);

        /// <summary>
        /// Sets a function to be called at regular intervals, with @priority.
        /// The function is called repeatedly until it returns %FALSE, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike g_timeout_add(), this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the @interval to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given @interval
        /// 
        /// If you want timing more precise than whole seconds, use g_timeout_add()
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of g_timeout_add_seconds() is preferred over g_timeout_add().
        /// 
        /// This internally creates a main loop source using
        /// g_timeout_source_new_seconds() and attaches it to the main loop context
        /// using g_source_attach(). You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        public static System.UInt32 AddSeconds(
            System.UInt32 interval,
            GISharp.GLib.SourceFuncCallback function,
            System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var data = default(System.IntPtr);
            var functionNative = default(GISharp.GLib.SourceFunc);
            var ret = g_timeout_add_seconds_full(priority, interval, functionNative, data, notifyNative);
            return default(System.UInt32);
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_timeout_source_new /* transfer-ownership:full */(
            System.UInt32 interval /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        public static GISharp.GLib.Source SourceNew(
            System.UInt32 interval)
        {
            var retPtr = g_timeout_source_new(interval);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_timeout_source_new_seconds /* transfer-ownership:full */(
            System.UInt32 interval /* transfer-ownership:none */);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.14")]
        public static GISharp.GLib.Source SourceNewSeconds(
            System.UInt32 interval)
        {
            var retPtr = g_timeout_source_new_seconds(interval);
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class UnixSignal
    {
        /// <summary>
        /// A convenience function for g_unix_signal_source_new(), which
        /// attaches to the default #GMainContext.  You can remove the watch
        /// using g_source_remove().
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <param name="userData">
        /// Data for @handler
        /// </param>
        /// <param name="notify">
        /// #GDestroyNotify for @handler
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.UInt32 g_unix_signal_add_full /* transfer-ownership:none */(
            System.Int32 priority /* transfer-ownership:none */,
            System.Int32 signum /* transfer-ownership:none */,
            GISharp.GLib.SourceFunc handler /* transfer-ownership:none scope:notified closure:3 destroy:4 */,
            System.IntPtr userData /* transfer-ownership:none */,
            GISharp.Core.DestroyNotify notify /* transfer-ownership:none scope:async */);

        /// <summary>
        /// A convenience function for g_unix_signal_source_new(), which
        /// attaches to the default #GMainContext.  You can remove the watch
        /// using g_source_remove().
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        public static System.UInt32 Add(
            System.Int32 priority,
            System.Int32 signum,
            GISharp.GLib.SourceFuncCallback handler)
        {
            if (handler == null)
            {
                throw new System.ArgumentNullException("handler");
            }
            var notifyNative = default(GISharp.Core.DestroyNotify);
            var userData = default(System.IntPtr);
            var handlerNative = default(GISharp.GLib.SourceFunc);
            var ret = g_unix_signal_add_full(priority, signum, handlerNative, userData, notifyNative);
            return default(System.UInt32);
        }

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr g_unix_signal_source_new /* transfer-ownership:full */(
            System.Int32 signum /* transfer-ownership:none */);

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [GISharp.Core.SinceAttribute("2.30")]
        public static GISharp.GLib.Source SourceNew(
            System.Int32 signum)
        {
            var retPtr = g_unix_signal_source_new(signum);
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class Version
    {
        /// <summary>
        /// The major version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #glib_major_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Major = 2;

        /// <summary>
        /// The micro version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_micro_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Micro = 1;

        /// <summary>
        /// The minor version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_minor_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Minor = 42;

        /// <summary>
        /// A macro that should be defined by the user prior to including
        /// the glib.h header.
        /// The definition should be one of the predefined GLib version
        /// macros: %GLIB_VERSION_2_26, %GLIB_VERSION_2_28,...
        /// </summary>
        /// <remarks>
        /// This macro defines the earliest version of GLib that the package is
        /// required to be able to compile against.
        /// 
        /// If the compiler is configured to warn about the use of deprecated
        /// functions, then using functions that were deprecated in version
        /// %GLIB_VERSION_MIN_REQUIRED or earlier will cause warnings (but
        /// using functions deprecated in later releases will not).
        /// </remarks>
        [GISharp.Core.SinceAttribute("2.32")]
        public const System.Int32 MinRequired = 2;

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern System.IntPtr glib_check_version /* transfer-ownership:none */(
            System.UInt32 requiredMajor /* transfer-ownership:none */,
            System.UInt32 requiredMinor /* transfer-ownership:none */,
            System.UInt32 requiredMicro /* transfer-ownership:none */);

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Core.SinceAttribute("2.6")]
        public static System.String Check(
            System.UInt32 requiredMajor,
            System.UInt32 requiredMinor,
            System.UInt32 requiredMicro)
        {
            var retPtr = glib_check_version(requiredMajor, requiredMinor, requiredMicro);
            return default(System.String);
        }
    }
}