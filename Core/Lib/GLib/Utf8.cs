using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;

namespace GISharp.Lib.GLib
{
    public unsafe ref struct UnownedUtf8
    {
        byte* handle;
        int length;
        string managedValue;
        Utf8 unmanagedValue;

        public IntPtr Handle => (IntPtr)handle;

        public bool IsNull => handle == null;

        public int Length {
            get {
                if (handle == null) {
                    throw new NullReferenceException();
                }
                if (length < 0) {
                    length = unmanagedValue?.Length ?? (int)strlen(handle);
                }
                return length;
            }
        }

        public UnownedUtf8(IntPtr handle, int length)
        {
            this.handle = (byte*)handle;
            this.length = length;
            managedValue = null;
            unmanagedValue = null;
        }

        public UnownedUtf8(Utf8 utf8)
        {
            this.handle = (byte*)utf8?.Handle;
            this.length = utf8 == null ? 0 : -1;
            this.managedValue = null;
            this.unmanagedValue = utf8;
        }

        [DllImport("c")]
        static extern UIntPtr strlen(byte* s);

        public ReadOnlySpan<byte> AsReadOnlySpan()
        {
            if (handle == null) {
                throw new NullReferenceException();
            }
            return new ReadOnlySpan<byte>(handle, Length);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_strdup(byte* str);

        public Utf8 Copy()
        {
            if (handle == null) {
                throw new NullReferenceException();
            }
            var ret_ = g_strdup(handle);
            var ret = new Utf8(ret_, Transfer.Full);
            return ret;
        }

        public override string ToString()
        {
            if (handle == null) {
                throw new NullReferenceException();
            }
            if (managedValue == null) {
                managedValue = unmanagedValue?.ToString() ?? Encoding.UTF8.GetString(handle, Length);
            }
            return managedValue;
        }

        public static implicit operator string(UnownedUtf8 utf8)
        {
            if (utf8.handle == null) {
                return null;
            }
            return utf8.ToString();
        }

        public static implicit operator UnownedUtf8(string str)
        {
            if (str == null) {
                return default(UnownedUtf8);
            }
            return new UnownedUtf8(new Utf8(str));
        }

        public static implicit operator UnownedUtf8(Utf8 owned)
        {
            return new UnownedUtf8(owned);
        }
    }

    /// <summary>
    /// Unmanaged, null-terminated UTF8 string
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public sealed class Utf8 : Opaque, IEnumerable<Unichar>, IEnumerable, IComparable, IComparable<Utf8>, IComparable<String>, IConvertible, IEquatable<Utf8>, IEquatable<String>
    {

        /// <summary>
        /// Convince property for <c>default(UnownedUtf8)</c> or
        /// <c>new UnownedUtf8(null)</c>
        /// </summary>
        public static UnownedUtf8 Null => default(UnownedUtf8);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_utf16_to_utf8(
            [MarshalAs(UnmanagedType.LPWStr)]string str,
            nlong len,
            IntPtr itemsRead,
            IntPtr itemsWritten,
            out IntPtr error);

        static IntPtr New(string value)
        {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }
            var ret = g_utf16_to_utf8(value, value.Length, IntPtr.Zero, IntPtr.Zero, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            return ret;
        }

        public Utf8(string value) : this(New(value), Transfer.Full)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Utf8(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership != Transfer.Full) {
                this.handle = IntPtr.Zero;
                GC.SuppressFinalize(this);
                throw new ArgumentException("Must own unmanaged memory");
            }
            _Value = new Lazy<string>(GetValue);
        }

        public override IntPtr Take()
        {
            var this_ = Handle;
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
            return this_;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_free(IntPtr ptr);

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_free(handle);
            }
            base.Dispose(disposing);
        }

        public string Value => _Value.Value;
        readonly Lazy<string> _Value;

        public override string ToString()
        {
            return Value;
        }
        
        string GetValue()
        {
            // TODO: replace this with Marshal.PtrToStringUTF8() when it
            // becomes part of netstandard
            var ret_ = g_utf8_to_utf16(Handle, -1, IntPtr.Zero, IntPtr.Zero, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            var ret = Marshal.PtrToStringUni(ret_);
            g_free(ret_);
            return ret;
        }

        /// <summary>
        /// Converts a string into a form that is independent of case. The
        /// result will not correspond to any particular case, but can be
        /// compared for equality or ordered with the results of calling
        /// g_utf8_casefold() on other strings.
        /// </summary>
        /// <remarks>
        /// Note that calling g_utf8_casefold() followed by g_utf8_collate() is
        /// only an approximation to the correct linguistic case insensitive
        /// ordering, though it is a fairly good one. Getting this exactly
        /// right would require a more sophisticated collation function that
        /// takes case sensitivity into account. GLib does not currently
        /// provide such a function.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is a
        ///   case independent form of @str.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_casefold(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a form that is independent of case. The
        /// result will not correspond to any particular case, but can be
        /// compared for equality or ordered with the results of calling
        /// <see cref="CaseFold"/> on other strings.
        /// </summary>
        /// <remarks>
        /// Note that calling <see cref="CaseFold"/> followed by <see cref="Collate"/> is
        /// only an approximation to the correct linguistic case insensitive
        /// ordering, though it is a fairly good one. Getting this exactly
        /// right would require a more sophisticated collation function that
        /// takes case sensitivity into account. GLib does not currently
        /// provide such a function.
        /// </remarks>
        /// <returns>
        /// a newly allocated string, that is a
        /// case independent form of this string.
        /// </returns>
        public Utf8 CaseFold()
        {
            var ret_ = g_utf8_casefold(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Compares two strings for ordering using the linguistically
        /// correct rules for the [current locale][setlocale].
        /// When sorting a large number of strings, it will be significantly
        /// faster to obtain collation keys with g_utf8_collate_key() and
        /// compare the keys with strcmp() when sorting instead of sorting
        /// the original strings.
        /// </summary>
        /// <param name="str1">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="str2">
        /// a UTF-8 encoded string
        /// </param>
        /// <returns>
        /// &lt; 0 if @str1 compares before @str2,
        ///   0 if they compare equal, &gt; 0 if @str1 compares after @str2.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_utf8_collate(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str1,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str2);

        /// <summary>
        /// Compares two strings for ordering using the linguistically
        /// correct rules for the [current locale][setlocale].
        /// When sorting a large number of strings, it will be significantly
        /// faster to obtain collation keys with <see cref="CollateKey"/> and
        /// compare the keys with <see cref="Compare"/> when sorting instead of sorting
        /// the original strings.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="str"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// &lt; 0 if this string compares before <paramref name="str"/>,
        /// 0 if they compare equal, &gt; 0 if this string compares after
        /// <paramref name="str"/>.
        /// </returns>
        public int Collate(Utf8 str)
        {
            var this_ = Handle;
            var str_ = str?.Handle ?? throw new ArgumentNullException(nameof(str));
            var ret = g_utf8_collate(this_, str_);
            return ret;
        }

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// strcmp().
        /// </summary>
        /// <remarks>
        /// The results of comparing the collation keys of two strings
        /// with strcmp() will always be the same as comparing the two
        /// original keys with g_utf8_collate().
        /// 
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string. This string should
        ///   be freed with g_free() when you are done with it.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_collate_key(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// <see cref="Compare"/>
        /// </summary>
        /// <remarks>
        /// The results of comparing the collation keys of two strings
        /// with <see cref="Compare"/> will always be the same as comparing the two
        /// original keys with <see cref="Collate"/>.
        /// 
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <returns>
        /// a newly allocated string.
        /// </returns>
        public Utf8 CollateKey()
        {
            var ret_ = g_utf8_collate_key(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using strcmp().
        /// </summary>
        /// <remarks>
        /// In order to sort filenames correctly, this function treats the dot '.'
        /// as a special case. Most dictionary orderings seem to consider it
        /// insignificant, thus producing the ordering "event.c" "eventgenerator.c"
        /// "event.h" instead of "event.c" "event.h" "eventgenerator.c". Also, we
        /// would like to treat numbers intelligently so that "file1" "file10" "file5"
        /// is sorted as "file1" "file5" "file10".
        /// 
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string. This string should
        ///   be freed with g_free() when you are done with it.
        /// </returns>
        [Since("2.8")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_collate_key_for_filename(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// <see cref="Compare"/>.
        /// </summary>
        /// <remarks>
        /// In order to sort filenames correctly, this function treats the dot '.'
        /// as a special case. Most dictionary orderings seem to consider it
        /// insignificant, thus producing the ordering "event.c" "eventgenerator.c"
        /// "event.h" instead of "event.c" "event.h" "eventgenerator.c". Also, we
        /// would like to treat numbers intelligently so that "file1" "file10" "file5"
        /// is sorted as "file1" "file5" "file10".
        /// 
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <returns>
        /// a newly allocated string.
        /// </returns>
        [Since("2.8")]
        public Utf8 CollateKeyForFilename()
        {
            var ret_ = g_utf8_collate_key_for_filename(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Finds the start of the next UTF-8 character in the string after @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte.
        /// </remarks>
        /// <param name="p">
        /// a pointer to a position within a UTF-8 encoded string
        /// </param>
        /// <param name="end">
        /// a pointer to the byte following the end of the string,
        ///     or %NULL to indicate that the string is nul-terminated
        /// </param>
        /// <returns>
        /// a pointer to the found character or %NULL
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_find_next_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr end);

        /// <summary>
        /// Given a position @p with a UTF-8 encoded string @str, find the start
        /// of the previous UTF-8 character starting before @p. Returns %NULL if no
        /// UTF-8 characters are present in @str before @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte.
        /// </remarks>
        /// <param name="str">
        /// pointer to the beginning of a UTF-8 encoded string
        /// </param>
        /// <param name="p">
        /// pointer to some position within @str
        /// </param>
        /// <returns>
        /// a pointer to the found character or %NULL.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_find_prev_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

        /// <summary>
        /// Converts a sequence of bytes encoded as UTF-8 to a Unicode character.
        /// </summary>
        /// <remarks>
        /// If @p does not point to a valid UTF-8 encoded character, results
        /// are undefined. If you are not sure that the bytes are complete
        /// valid Unicode characters, you should use g_utf8_get_char_validated()
        /// instead.
        /// </remarks>
        /// <param name="p">
        /// a pointer to Unicode character encoded as UTF-8
        /// </param>
        /// <returns>
        /// the resulting character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_utf8_get_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

        /// <summary>
        /// Convert a sequence of bytes encoded as UTF-8 to a Unicode character.
        /// This function checks for incomplete characters, for invalid characters
        /// such as characters that are out of the range of Unicode, and for
        /// overlong encodings of valid characters.
        /// </summary>
        /// <param name="p">
        /// a pointer to Unicode character encoded as UTF-8
        /// </param>
        /// <param name="maxLen">
        /// the maximum number of bytes to read, or -1, for no maximum or
        ///     if @p is nul-terminated
        /// </param>
        /// <returns>
        /// the resulting character. If @p points to a partial
        ///     sequence at the end of a string that could begin a valid
        ///     character (or if @max_len is zero), returns (gunichar)-2;
        ///     otherwise, if @p does not point to a valid UTF-8 encoded
        ///     Unicode character, returns (gunichar)-1.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_utf8_get_char_validated(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr maxLen);

        IEnumerator<Unichar> GetEnumerator()
        {
            for (var ptr = Handle; ptr != IntPtr.Zero; ptr = g_utf8_find_next_char(ptr, IntPtr.Zero)) {
                var ret = g_utf8_get_char(ptr);
                if (ret == default(Unichar)) {
                    // don't return the null terminator
                    yield break;
                }
                yield return ret;
            }
        }

        IEnumerator<Unichar> IEnumerable<Unichar>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Converts a string into canonical form, standardizing
        /// such issues as whether a character with an accent
        /// is represented as a base character and combining
        /// accent or as a single precomposed character. The
        /// string has to be valid UTF-8, otherwise %NULL is
        /// returned. You should generally call g_utf8_normalize()
        /// before comparing two Unicode strings.
        /// </summary>
        /// <remarks>
        /// The normalization mode %G_NORMALIZE_DEFAULT only
        /// standardizes differences that do not affect the
        /// text content, such as the above-mentioned accent
        /// representation. %G_NORMALIZE_ALL also standardizes
        /// the "compatibility" characters in Unicode, such
        /// as SUPERSCRIPT THREE to the standard forms
        /// (in this case DIGIT THREE). Formatting information
        /// may be lost but for most text operations such
        /// characters should be considered the same.
        /// 
        /// %G_NORMALIZE_DEFAULT_COMPOSE and %G_NORMALIZE_ALL_COMPOSE
        /// are like %G_NORMALIZE_DEFAULT and %G_NORMALIZE_ALL,
        /// but returned a result with composed forms rather
        /// than a maximally decomposed form. This is often
        /// useful if you intend to convert the string to
        /// a legacy encoding or pass it to a system with
        /// less capable Unicode handling.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <param name="mode">
        /// the type of normalization to perform.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is the
        ///   normalized form of @str, or %NULL if @str is not
        ///   valid UTF-8.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_normalize(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="NormalizeMode" type="GNormalizeMode" managed-name="NormalizeMode" /> */
            /* transfer-ownership:none */
            NormalizeMode mode);

        /// <summary>
        /// Converts a string into canonical form, standardizing
        /// such issues as whether a character with an accent
        /// is represented as a base character and combining
        /// accent or as a single precomposed character. The
        /// string has to be valid UTF-8, otherwise <c>null</c> is
        /// returned. You should generally call <see cref="Normalize"/>
        /// before comparing two Unicode strings.
        /// </summary>
        /// <remarks>
        /// The normalization mode <see cref="NormalizeMode.Default"/> only
        /// standardizes differences that do not affect the
        /// text content, such as the above-mentioned accent
        /// representation. <see cref="NormalizeMode.All"/> also standardizes
        /// the "compatibility" characters in Unicode, such
        /// as SUPERSCRIPT THREE to the standard forms
        /// (in this case DIGIT THREE). Formatting information
        /// may be lost but for most text operations such
        /// characters should be considered the same.
        /// 
        /// <see cref="NormalizeMode.DefaultCompose"/> and <see cref="NormalizeMode.AllCompose"/>
        /// are like <see cref="NormalizeMode.Default"/> and <see cref="NormalizeMode.All"/>,
        /// but returned a result with composed forms rather
        /// than a maximally decomposed form. This is often
        /// useful if you intend to convert the string to
        /// a legacy encoding or pass it to a system with
        /// less capable Unicode handling.
        /// </remarks>
        /// <param name="mode">
        /// the type of normalization to perform.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is the
        /// normalized form of this string, or <c>null</c> if this string is not
        /// valid UTF-8.
        /// </returns>
        public Utf8 Normalize(NormalizeMode mode = NormalizeMode.Default)
        {
            var ret_ = g_utf8_normalize(Handle, IntPtr.Zero, mode);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts from an integer character offset to a pointer to a position
        /// within the string.
        /// </summary>
        /// <remarks>
        /// Since 2.10, this function allows to pass a negative @offset to
        /// step backwards. It is usually worth stepping backwards from the end
        /// instead of forwards if @offset is in the last fourth of the string,
        /// since moving forward is about 3 times faster than moving backward.
        /// 
        /// Note that this function doesn't abort when reaching the end of @str.
        /// Therefore you should be sure that @offset is within string boundaries
        /// before calling that function. Call g_utf8_strlen() when unsure.
        /// This limitation exists as this function is called frequently during
        /// text rendering and therefore has to be as fast as possible.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="offset">
        /// a character offset within @str
        /// </param>
        /// <returns>
        /// the resulting pointer
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_offset_to_pointer(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong offset);

        // /// <summary>
        // /// Converts from an integer character offset to a pointer to a position
        // /// within the string.
        // /// </summary>
        // /// <remarks>
        // /// Since 2.10, this function allows to pass a negative @offset to
        // /// step backwards. It is usually worth stepping backwards from the end
        // /// instead of forwards if @offset is in the last fourth of the string,
        // /// since moving forward is about 3 times faster than moving backward.
        // /// 
        // /// Note that this function doesn't abort when reaching the end of @str.
        // /// Therefore you should be sure that @offset is within string boundaries
        // /// before calling that function. Call g_utf8_strlen() when unsure.
        // /// This limitation exists as this function is called frequently during
        // /// text rendering and therefore has to be as fast as possible.
        // /// </remarks>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="str"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="offset">
        // /// a character offset within @str
        // /// </param>
        // /// <returns>
        // /// the resulting pointer
        // /// </returns>
        // public static Utf8 Utf8OffsetToPointer(Utf8 str, nlong offset)
        // {
        //     if (str == null)
        //     {
        //         throw new ArgumentNullException(nameof(str));
        //     }
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var ret_ = g_utf8_offset_to_pointer(str_, offset);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Converts from a pointer to position within a string to a integer
        /// character offset.
        /// </summary>
        /// <remarks>
        /// Since 2.10, this function allows @pos to be before @str, and returns
        /// a negative offset in this case.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="pos">
        /// a pointer to a position within @str
        /// </param>
        /// <returns>
        /// the resulting character offset
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern nlong g_utf8_pointer_to_offset(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr pos);

        // /// <summary>
        // /// Converts from a pointer to position within a string to a integer
        // /// character offset.
        // /// </summary>
        // /// <remarks>
        // /// Since 2.10, this function allows @pos to be before @str, and returns
        // /// a negative offset in this case.
        // /// </remarks>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="str"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="pos">
        // /// a pointer to a position within @str
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="pos"/> is <c>null</c>.
        // ///</exception>
        // /// <returns>
        // /// the resulting character offset
        // /// </returns>
        // public static nlong Utf8PointerToOffset(Utf8 str, Utf8 pos)
        // {
        //     if (str == null)
        //     {
        //         throw new ArgumentNullException(nameof(str));
        //     }
        //     if (pos == null)
        //     {
        //         throw new ArgumentNullException(nameof(pos));
        //     }
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var pos_ = GMarshal.StringToUtf8Ptr(pos);
        //     var ret = g_utf8_pointer_to_offset(str_, pos_);
        //     try
        //     {
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //         GMarshal.Free(pos_);
        //     }
        // }

        /// <summary>
        /// Finds the previous UTF-8 character in the string before @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte. If @p might be the first
        /// character of the string, you must use g_utf8_find_prev_char() instead.
        /// </remarks>
        /// <param name="p">
        /// a pointer to a position within a UTF-8 encoded string
        /// </param>
        /// <returns>
        /// a pointer to the found character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_prev_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

        // /// <summary>
        // /// Finds the previous UTF-8 character in the string before @p.
        // /// </summary>
        // /// <remarks>
        // /// @p does not have to be at the beginning of a UTF-8 character. No check
        // /// is made to see if the character found is actually valid other than
        // /// it starts with an appropriate byte. If @p might be the first
        // /// character of the string, you must use g_utf8_find_prev_char() instead.
        // /// </remarks>
        // /// <param name="p">
        // /// a pointer to a position within a UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="p"/> is <c>null</c>.
        // ///</exception>
        // /// <returns>
        // /// a pointer to the found character
        // /// </returns>
        // public static Utf8 Utf8PrevChar(Utf8 p)
        // {
        //     if (p == null)
        //     {
        //         throw new ArgumentNullException(nameof(p));
        //     }
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_prev_char(p_);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Finds the leftmost occurrence of the given Unicode character
        /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        /// If @len is -1, allow unbounded search.
        /// </summary>
        /// <param name="p">
        /// a nul-terminated UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @p
        /// </param>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %NULL if the string does not contain the character,
        ///     otherwise, a pointer to the start of the leftmost occurrence
        ///     of the character in the string.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strchr(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        // /// <summary>
        // /// Finds the leftmost occurrence of the given Unicode character
        // /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        // /// If @len is -1, allow unbounded search.
        // /// </summary>
        // /// <param name="p">
        // /// a nul-terminated UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="p"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="len">
        // /// the maximum length of @p
        // /// </param>
        // /// <param name="c">
        // /// a Unicode character
        // /// </param>
        // /// <returns>
        // /// %NULL if the string does not contain the character,
        // ///     otherwise, a pointer to the start of the leftmost occurrence
        // ///     of the character in the string.
        // /// </returns>
        // public static Utf8 Utf8Strchr(Utf8 p, IntPtr len, int c)
        // {
        //     if (p == null)
        //     {
        //         throw new ArgumentNullException(nameof(p));
        //     }
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_strchr(p_, len, c);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to lowercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string changing.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, with all characters
        ///    converted to lowercase.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strdown(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to lowercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string changing.
        /// </summary>
        /// <returns>
        /// a newly allocated string, with all characters
        /// converted to lowercase.
        /// </returns>
        public Utf8 ToLower()
        {
            var ret_ = g_utf8_strdown(handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Computes the length of the string in characters, not including
        /// the terminating nul character. If the @max'th byte falls in the
        /// middle of a character, the last (partial) character is not counted.
        /// </summary>
        /// <param name="p">
        /// pointer to the start of a UTF-8 encoded string
        /// </param>
        /// <param name="max">
        /// the maximum number of bytes to examine. If @max
        ///       is less than 0, then the string is assumed to be
        ///       nul-terminated. If @max is 0, @p will not be examined and
        ///       may be %NULL. If @max is greater than 0, up to @max
        ///       bytes are examined
        /// </param>
        /// <returns>
        /// the length of the string in characters
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern nlong g_utf8_strlen(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr max);

        /// <summary>
        /// Gets the length of the string in characters.
        /// </summary>
        public int Length {
            get {
                var ret = g_utf8_strlen(Handle, new IntPtr(-1));
                return (int)ret;
            }
        }

        /// <summary>
        /// Like the standard C strncpy() function, but copies a given number
        /// of characters instead of a given number of bytes. The @src string
        /// must be valid UTF-8 encoded text. (Use g_utf8_validate() on all
        /// text before trying to use UTF-8 utility functions with it.)
        /// </summary>
        /// <param name="dest">
        /// buffer to fill with characters from @src
        /// </param>
        /// <param name="src">
        /// UTF-8 encoded string
        /// </param>
        /// <param name="n">
        /// character count
        /// </param>
        /// <returns>
        /// @dest
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strncpy(
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr dest,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr src,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr n);

        // /// <summary>
        // /// Like the standard C strncpy() function, but copies a given number
        // /// of characters instead of a given number of bytes. The @src string
        // /// must be valid UTF-8 encoded text. (Use g_utf8_validate() on all
        // /// text before trying to use UTF-8 utility functions with it.)
        // /// </summary>
        // /// <param name="dest">
        // /// buffer to fill with characters from @src
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="dest"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="src">
        // /// UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="src"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="n">
        // /// character count
        // /// </param>
        // /// <returns>
        // /// @dest
        // /// </returns>
        // public static Utf8 Utf8Strncpy(Utf8 dest, Utf8 src, UIntPtr n)
        // {
        //     if (dest == null)
        //     {
        //         throw new ArgumentNullException(nameof(dest));
        //     }
        //     if (src == null)
        //     {
        //         throw new ArgumentNullException(nameof(src));
        //     }
        //     var dest_ = GMarshal.StringToUtf8Ptr(dest);
        //     var src_ = GMarshal.StringToUtf8Ptr(src);
        //     var ret_ = g_utf8_strncpy(dest_, src_, n);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(dest_);
        //         GMarshal.Free(src_);
        //     }
        // }

        /// <summary>
        /// Find the rightmost occurrence of the given Unicode character
        /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        /// If @len is -1, allow unbounded search.
        /// </summary>
        /// <param name="p">
        /// a nul-terminated UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @p
        /// </param>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %NULL if the string does not contain the character,
        ///     otherwise, a pointer to the start of the rightmost occurrence
        ///     of the character in the string.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strrchr(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        // /// <summary>
        // /// Find the rightmost occurrence of the given Unicode character
        // /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        // /// If @len is -1, allow unbounded search.
        // /// </summary>
        // /// <param name="p">
        // /// a nul-terminated UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="p"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="len">
        // /// the maximum length of @p
        // /// </param>
        // /// <param name="c">
        // /// a Unicode character
        // /// </param>
        // /// <returns>
        // /// %NULL if the string does not contain the character,
        // ///     otherwise, a pointer to the start of the rightmost occurrence
        // ///     of the character in the string.
        // /// </returns>
        // public static Utf8 Utf8Strrchr(Utf8 p, IntPtr len, int c)
        // {
        //     if (p == null)
        //     {
        //         throw new ArgumentNullException(nameof(p));
        //     }
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_strrchr(p_, len, c);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Reverses a UTF-8 string. @str must be valid UTF-8 encoded text.
        /// (Use g_utf8_validate() on all text before trying to use UTF-8
        /// utility functions with it.)
        /// </summary>
        /// <remarks>
        /// This function is intended for programmatic uses of reversed strings.
        /// It pays no attention to decomposed characters, combining marks, byte
        /// order marks, directional indicators (LRM, LRO, etc) and similar
        /// characters which might need special handling when reversing a string
        /// for display purposes.
        /// 
        /// Note that unlike g_strreverse(), this function returns
        /// newly-allocated memory, which should be freed with g_free() when
        /// no longer needed.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly-allocated string which is the reverse of @str
        /// </returns>
        [Since("2.2")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strreverse(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Reverses a UTF-8 string.
        /// </summary>
        /// <remarks>
        /// This function is intended for programmatic uses of reversed strings.
        /// It pays no attention to decomposed characters, combining marks, byte
        /// order marks, directional indicators (LRM, LRO, etc) and similar
        /// characters which might need special handling when reversing a string
        /// for display purposes.
        /// </remarks>
        /// <returns>
        /// a newly-allocated string which is the reverse of this string
        /// </returns>
        [Since("2.2")]
        public Utf8 Reverse()
        {
            var ret_ = g_utf8_strreverse(Handle, IntPtr.Zero);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to uppercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string increasing. (For instance, the
        /// German ess-zet will be changed to SS.)
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, with all characters
        ///    converted to uppercase.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strup(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to uppercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string increasing. (For instance, the
        /// German ess-zet will be changed to SS.)
        /// </summary>
        /// <returns>
        /// a newly allocated string, with all characters
        /// converted to uppercase.
        /// </returns>
        public Utf8 ToUpper()
        {
            var ret_ = g_utf8_strup(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Copies a substring out of a UTF-8 encoded string.
        /// The substring will contain @end_pos - @start_pos characters.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="startPos">
        /// a character offset within @str
        /// </param>
        /// <param name="endPos">
        /// another character offset within @str
        /// </param>
        /// <returns>
        /// a newly allocated copy of the requested
        ///     substring. Free with g_free() when no longer needed.
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_substring(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong startPos,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong endPos);

        /// <summary>
        /// Copies a substring out of a UTF-8 encoded string.
        /// The substring will contain <paramref name="endPos"/> -
        /// <paramref name="startPos"/> characters.
        /// </summary>
        /// <param name="startPos">
        /// a character offset within this string
        /// </param>
        /// <param name="endPos">
        /// another character offset within this string
        /// </param>
        /// <returns>
        /// a newly allocated copy of the requested substring.
        /// </returns>
        [Since("2.30")]
        public Utf8 Substring(int startPos, int endPos)
        {
            var ret_ = g_utf8_substring(Handle, startPos, endPos);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Convert a string from UTF-8 to a 32-bit fixed width
        /// representation as UCS-4. A trailing 0 character will be added to the
        /// string after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <param name="itemsRead">
        /// location to store number of bytes read, or %NULL.
        ///     If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        ///     returned in case @str contains a trailing partial
        ///     character. If an error occurs then the index of the
        ///     invalid input is stored here.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store number of characters
        ///     written or %NULL. The value here stored does not include the
        ///     trailing 0 character.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UCS-4 string.
        ///     This value must be freed with g_free(). If an error occurs,
        ///     %NULL will be returned and @error set.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_ucs4(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            nlong itemsRead,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            nlong itemsWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        // /// <summary>
        // /// Convert a string from UTF-8 to a 32-bit fixed width
        // /// representation as UCS-4. A trailing 0 character will be added to the
        // /// string after the converted text.
        // /// </summary>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="str"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="len">
        // /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        // ///     then the string is nul-terminated.
        // /// </param>
        // /// <param name="itemsRead">
        // /// location to store number of bytes read, or %NULL.
        // ///     If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        // ///     returned in case @str contains a trailing partial
        // ///     character. If an error occurs then the index of the
        // ///     invalid input is stored here.
        // /// </param>
        // /// <param name="itemsWritten">
        // /// location to store number of characters
        // ///     written or %NULL. The value here stored does not include the
        // ///     trailing 0 character.
        // /// </param>
        // /// <returns>
        // /// a pointer to a newly allocated UCS-4 string.
        // ///     This value must be freed with g_free(). If an error occurs,
        // ///     %NULL will be returned and @error set.
        // /// </returns>
        // /// <exception name="GErrorException">
        // /// On error
        // /// </exception>
        // public static int Utf8ToUcs4(Utf8 str, nlong len, nlong itemsRead, nlong itemsWritten)
        // {
        //     if (str == null)
        //     {
        //         throw new ArgumentNullException(nameof(str));
        //     }
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     IntPtr error_;
        //     var ret = g_utf8_to_ucs4(handle, IntPtr.Zero, itemsRead, itemsWritten,out error_);
        //     try
        //     {
        //         if (error_ != IntPtr.Zero)
        //         {
        //             var error = GISharp.Runtime.Opaque.GetInstance<Error>(error_, GISharp.Runtime.Transfer.Full);
        //             throw new GErrorException(error);
        //         }

        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Convert a string from UTF-8 to a 32-bit fixed width
        /// representation as UCS-4, assuming valid UTF-8 input.
        /// This function is roughly twice as fast as g_utf8_to_ucs4()
        /// but does no error checking on the input. A trailing 0 character
        /// will be added to the string after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store the number of
        ///     characters in the result, or %NULL.
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UCS-4 string.
        ///     This value must be freed with g_free().
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_ucs4_fast(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            nlong itemsWritten);

        // /// <summary>
        // /// Convert a string from UTF-8 to a 32-bit fixed width
        // /// representation as UCS-4, assuming valid UTF-8 input.
        // /// This function is roughly twice as fast as g_utf8_to_ucs4()
        // /// but does no error checking on the input. A trailing 0 character
        // /// will be added to the string after the converted text.
        // /// </summary>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <exception name="ArgumentNullException">
        // /// If <paramref name="str"/> is <c>null</c>.
        // ///</exception>
        // /// <param name="len">
        // /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        // ///     then the string is nul-terminated.
        // /// </param>
        // /// <param name="itemsWritten">
        // /// location to store the number of
        // ///     characters in the result, or %NULL.
        // /// </param>
        // /// <returns>
        // /// a pointer to a newly allocated UCS-4 string.
        // ///     This value must be freed with g_free().
        // /// </returns>
        // public static int Utf8ToUcs4Fast(Utf8 str, nlong len, nlong itemsWritten)
        // {
        //     if (str == null)
        //     {
        //         throw new ArgumentNullException(nameof(str));
        //     }
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var ret = g_utf8_to_ucs4_fast(handle, IntPtr.Zero, itemsWritten);
        //     try
        //     {
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Convert a string from UTF-8 to UTF-16. A 0 character will be
        /// added to the result after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length (number of bytes) of @str to use.
        ///     If @len &lt; 0, then the string is nul-terminated.
        /// </param>
        /// <param name="itemsRead">
        /// location to store number of bytes read,
        ///     or %NULL. If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        ///     returned in case @str contains a trailing partial character. If
        ///     an error occurs then the index of the invalid input is stored here.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store number of #gunichar2
        ///     written, or %NULL. The value stored here does not include the
        ///     trailing 0.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UTF-16 string.
        ///     This value must be freed with g_free(). If an error occurs,
        ///     %NULL will be returned and @error set.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint16" type="gunichar2*" managed-name="Guint16" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_utf16(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            nlong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr itemsRead,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr itemsWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Validates UTF-8 encoded text. @str is the text to validate;
        /// if @str is nul-terminated, then @max_len can be -1, otherwise
        /// @max_len should be the number of bytes to validate.
        /// If @end is non-%NULL, then the end of the valid range
        /// will be stored there (i.e. the start of the first invalid
        /// character if some bytes were invalid, or the end of the text
        /// being validated otherwise).
        /// </summary>
        /// <remarks>
        /// Note that g_utf8_validate() returns %FALSE if @max_len is
        /// positive and any of the @max_len bytes are nul.
        /// 
        /// Returns %TRUE if all of @str was valid. Many GLib and GTK+
        /// routines require valid UTF-8 as input; so data read from a file
        /// or the network should be checked with g_utf8_validate() before
        /// doing anything else with it.
        /// </remarks>
        /// <param name="str">
        /// a pointer to character data
        /// </param>
        /// <param name="maxLen">
        /// max bytes to validate, or -1 to go until NUL
        /// </param>
        /// <param name="end">
        /// return location for end of valid data
        /// </param>
        /// <returns>
        /// %TRUE if the text was valid UTF-8
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern unsafe bool g_utf8_validate(
            /* <array length="1" zero-terminated="0" type="gchar*">
             *   <type name="guint8" managed-name="Guint8" />
             * </array> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr maxLen,
            /* <type name="utf8" type="const gchar**" managed-name="Utf8" /> */
            /* direction:out caller-allocates:0 transfer-ownership:none optional:1 allow-none:1 */
            IntPtr* end);

        /// <summary>
        /// Validates UTF-8 encoded text.
        /// </summary>
        /// <remarks>
        /// Note that <see cref="Validate"/> returns <c>false</c> if <paramref name="maxLen"/> is
        /// positive and any of the <paramref name="maxLen"/> bytes are nul.
        /// 
        /// Returns <c>true</c> if all of this string was valid. Many GLib and GTK+
        /// routines require valid UTF-8 as input; so data read from a file
        /// or the network should be checked with <see cref="Validate"/> before
        /// doing anything else with it.
        /// </remarks>
        /// <param name="maxLen">
        /// max bytes to validate, or -1 to validate the entire string
        /// </param>
        /// <returns>
        /// <c>true</c> if the text was valid UTF-8
        /// </returns>
        public unsafe bool Validate(int maxLen = -1)
        {
            var ret = g_utf8_validate(Handle, new IntPtr(maxLen), null);
            return ret;
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Utf8 other) {
                return ((IComparable<Utf8>)this).CompareTo(other);
            }
            return Value.CompareTo(obj);
        }

        int IComparable<Utf8>.CompareTo(Utf8 other) => Collate(other);

        int IComparable<string>.CompareTo(string other) => Value.CompareTo(other);

        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }

        public override bool Equals(object obj)
        {
            if (obj is Utf8 utf8) {
                return Equals(utf8);
            }
            if (obj is string str) {
                return Equals(str);
            }
            return base.Equals(obj);
        }

        public bool Equals(string other)
        {
            return Value.Equals(other);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_str_equal(IntPtr v1, IntPtr v2);

        public bool Equals(Utf8 other)
        {
            if (Object.Equals(other, null)) {
                return false;
            }
            var this_ = Handle;
            var other_ = other.Handle;
            var ret = g_str_equal(this_, other_);
            return ret;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(IntPtr v);

        public override int GetHashCode()
        {
            var ret = g_str_hash(Handle);
            return (int)ret;
        }

        public static implicit operator string(Utf8 utf8)
        {
            return utf8?.ToString();
        }

        public static implicit operator Utf8(string str)
        {
            if (str == null) {
                return null;
            }
            return new Utf8(str);
        }

        public static bool operator ==(Utf8 a, Utf8 b)
        {
            return a?.Equals(b) ?? b == null;
        }

        public static bool operator !=(Utf8 a, Utf8 b)
        {
            return !a?.Equals(b) ?? b != null;
        }
    }
}
