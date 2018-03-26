using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    public sealed class Filename : Opaque
    {
        bool owned;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Filename(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership != Transfer.None) {
                owned = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero && owned) {
                owned = false;
                GMarshal.Free(handle);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Behaves exactly like g_build_filename(), but takes the path elements
        /// as a string array, instead of varargs. This function is mainly
        /// meant for language bindings.
        /// </summary>
        /// <param name="args">
        /// %NULL-terminated array of strings containing the path elements.
        /// </param>
        /// <returns>
        /// a newly-allocated string that must be freed with g_free().
        /// </returns>
        [Since("2.8")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_build_filenamev(
            /* <array type="gchar**">
            *   <type name="utf8" type="gchar*" managed-name="Utf8" />
            * </array> */
            /* transfer-ownership:none */
            IntPtr args);

        /// <summary>
        /// Behaves exactly like g_build_filename(), but takes the path elements
        /// as a string array, instead of varargs. This function is mainly
        /// meant for language bindings.
        /// </summary>
        /// <param name="args">
        /// %NULL-terminated array of strings containing the path elements.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="args"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a newly-allocated string that must be freed with g_free().
        /// </returns>
        [Since("2.8")]
        static IntPtr BuildFilename(Strv args)
        {
            var args_ = args?.Handle ?? throw new ArgumentNullException(nameof(args));
            var ret_ = g_build_filenamev(args_);
            return ret_;
        }

        public Filename(Strv args) : this(BuildFilename(args), Transfer.Full)
        {
        }

        public Filename(params string[] args) : this(new Strv(args))
        {
        }

        /// <summary>
        /// Returns the display basename for the particular filename, guaranteed
        /// to be valid UTF-8. The display name might not be identical to the filename,
        /// for instance there might be problems converting it to UTF-8, and some files
        /// can be translated in the display.
        /// </summary>
        /// <remarks>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// 
        /// You must pass the whole absolute pathname to this functions so that
        /// translation of well known locations can be done.
        /// 
        /// This function is preferred over g_filename_display_name() if you know the
        /// whole path, as it allows translation.
        /// </remarks>
        /// <param name="filename">
        /// an absolute pathname in the GLib file name encoding
        /// </param>
        /// <returns>
        /// a newly allocated string containing
        ///   a rendition of the basename of the filename in valid UTF-8
        /// </returns>
        [Since("2.6")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_filename_display_basename(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr filename);

        /// <summary>
        /// Returns the display basename for the particular filename, guaranteed
        /// to be valid UTF-8. The display name might not be identical to the filename,
        /// for instance there might be problems converting it to UTF-8, and some files
        /// can be translated in the display.
        /// </summary>
        /// <remarks>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// 
        /// You must pass the whole absolute pathname to this functions so that
        /// translation of well known locations can be done.
        /// 
        /// This function is preferred over <see cref="DisplayName"/> if you know the
        /// whole path, as it allows translation.
        /// </remarks>
        /// <returns>
        /// a rendition of the basename of the filename in valid UTF-8
        /// </returns>
        [Since("2.6")]
        public Utf8 DisplayBasename {
            get {
                var filename_ = Handle;
                var ret_ = g_filename_display_basename(filename_);
                var ret = GetInstance<Utf8>(ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Converts a filename into a valid UTF-8 string. The conversion is
        /// not necessarily reversible, so you should keep the original around
        /// and use the return value of this function only for display purposes.
        /// Unlike g_filename_to_utf8(), the result is guaranteed to be non-%NULL
        /// even if the filename actually isn't in the GLib file name encoding.
        /// </summary>
        /// <remarks>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// 
        /// If you know the whole pathname of the file you should use
        /// g_filename_display_basename(), since that allows location-based
        /// translation of filenames.
        /// </remarks>
        /// <param name="filename">
        /// a pathname hopefully in the GLib file name encoding
        /// </param>
        /// <returns>
        /// a newly allocated string containing
        ///   a rendition of the filename in valid UTF-8
        /// </returns>
        [Since("2.6")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_filename_display_name(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr filename);

        /// <summary>
        /// Converts a filename into a valid UTF-8 string. The conversion is
        /// not necessarily reversible, so you should keep the original around
        /// and use the return value of this function only for display purposes.
        /// Unlike g_filename_to_utf8(), the result is guaranteed to be non-%NULL
        /// even if the filename actually isn't in the GLib file name encoding.
        /// </summary>
        /// <remarks>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// 
        /// If you know the whole pathname of the file you should use
        /// <see cref="DisplayBasename"/>, since that allows location-based
        /// translation of filenames.
        /// </remarks>
        /// <returns>
        /// a rendition of the filename in valid UTF-8
        /// </returns>
        [Since("2.6")]
        public Utf8 DisplayName {
            get {
                var filename_ = Handle;
                var ret_ = g_filename_display_name(filename_);
                var ret = GetInstance<Utf8>(ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Converts an escaped ASCII-encoded URI to a local filename in the
        /// encoding used for filenames.
        /// </summary>
        /// <param name="uri">
        /// a uri describing a filename (escaped, encoded in ASCII).
        /// </param>
        /// <param name="hostname">
        /// Location to store hostname for the URI, or %NULL.
        ///            If there is no hostname in the URI, %NULL will be
        ///            stored in this location.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly-allocated string holding
        ///               the resulting filename, or %NULL on an error.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="filename" type="gchar*" managed-name="Filename" /> */
        /* transfer-ownership:full */
        static extern unsafe IntPtr g_filename_from_uri(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr uri,
            /* <type name="utf8" type="gchar**" managed-name="Utf8" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            IntPtr* hostname,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Converts an escaped ASCII-encoded URI to a local filename in the
        /// encoding used for filenames.
        /// </summary>
        /// <param name="uri">
        /// a uri describing a filename (escaped, encoded in ASCII).
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="uri"/> is <c>null</c>.
        ///</exception>
        /// <param name="hostname">
        /// hostname for the URI
        /// </param>
        /// <returns>
        /// the resulting filename
        /// </returns>
        /// <exception name="GErrorException">
        /// On error
        /// </exception>
        public static unsafe Filename FromUri(Utf8 uri, out Utf8 hostname)
        {
            var uri_ = uri?.Handle ?? throw new ArgumentNullException(nameof(uri));
            IntPtr hostname_;
            var ret_ = g_filename_from_uri(uri_, &hostname_, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            hostname = GetInstance<Utf8>(hostname_, Transfer.Full);
            var ret = GetInstance<Filename>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts an escaped ASCII-encoded URI to a local filename in the
        /// encoding used for filenames.
        /// </summary>
        /// <param name="uri">
        /// a uri describing a filename (escaped, encoded in ASCII).
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="uri"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the resulting filename
        /// </returns>
        /// <exception name="GErrorException">
        /// On error
        /// </exception>
        public static unsafe Filename FromUri(Utf8 uri)
        {
            var uri_ = uri?.Handle ?? throw new ArgumentNullException(nameof(uri));
            var ret_ = g_filename_from_uri(uri_, null, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            var ret = GetInstance<Filename>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string from UTF-8 to the encoding GLib uses for
        /// filenames. Note that on Windows GLib uses UTF-8 for filenames;
        /// on other platforms, this function indirectly depends on the
        /// [current locale][setlocale].
        /// </summary>
        /// <param name="utf8string">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// the length of the string, or -1 if the string is
        ///                 nul-terminated.
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes in
        ///                 the input string that were successfully converted, or %NULL.
        ///                 Even if the conversion was successful, this may be
        ///                 less than @len if there were partial characters
        ///                 at the end of the input. If the error
        ///                 #G_CONVERT_ERROR_ILLEGAL_SEQUENCE occurs, the value
        ///                 stored will the byte offset after the last valid
        ///                 input sequence.
        /// </param>
        /// <param name="bytesWritten">
        /// the number of bytes stored in the output buffer (not
        ///                 including the terminating nul).
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///               The converted string, or %NULL on an error.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="3" zero-terminated="0" type="gchar*">
         *   <type name="guint8" managed-name="Guint8" />
         * </array> */
        /* transfer-ownership:full */
        static extern unsafe IntPtr g_filename_from_utf8(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr utf8string,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            UIntPtr* bytesRead,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            UIntPtr* bytesWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Converts a string from UTF-8 to the encoding GLib uses for
        /// filenames. Note that on Windows GLib uses UTF-8 for filenames;
        /// on other platforms, this function indirectly depends on the
        /// [current locale][setlocale].
        /// </summary>
        /// <param name="utf8string">
        /// a UTF-8 encoded string.
        /// </param>
        /// <returns>
        /// The converted string
        /// </returns>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="utf8string"/> is <c>null</c>.
        ///</exception>
        /// <exception name="GErrorException">
        /// On error
        /// </exception>
        public static unsafe Filename FromUtf8(Utf8 utf8string)
        {
            var utf8string_ = utf8string?.Handle ?? throw new ArgumentNullException(nameof(utf8string));
            UIntPtr bytesWritten_;
            var ret_ = g_filename_from_utf8(utf8string_, new IntPtr(-1), null, &bytesWritten_, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            var ret = Opaque.GetInstance<Filename>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts an absolute filename to an escaped ASCII-encoded URI, with the path
        /// component following Section 3.3. of RFC 2396.
        /// </summary>
        /// <param name="filename">
        /// an absolute filename specified in the GLib file name encoding,
        ///            which is the on-disk file name bytes on Unix, and UTF-8 on
        ///            Windows
        /// </param>
        /// <param name="hostname">
        /// A UTF-8 encoded hostname, or %NULL for none.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the resulting
        ///               URI, or %NULL on an error.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_filename_to_uri(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr filename,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr hostname,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Converts an absolute filename to an escaped ASCII-encoded URI, with the path
        /// component following Section 3.3. of RFC 2396.
        /// </summary>
        /// <param name="hostname">
        /// A UTF-8 encoded hostname, or <c>null</c> for none.
        /// </param>
        /// <returns>
        /// the resulting URI
        /// </returns>
        /// <exception name="GErrorException">
        /// On error
        /// </exception>
        public Utf8 ToUri(Utf8 hostname)
        {
            var filename_ = Handle;
            var hostname_ = hostname?.Handle ?? IntPtr.Zero;
            var ret_ = g_filename_to_uri(filename_, hostname_, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }

            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string which is in the encoding used by GLib for
        /// filenames into a UTF-8 string. Note that on Windows GLib uses UTF-8
        /// for filenames; on other platforms, this function indirectly depends on
        /// the [current locale][setlocale].
        /// </summary>
        /// <param name="opsysstring">
        /// a string in the encoding for filenames
        /// </param>
        /// <param name="len">
        /// the length of the string, or -1 if the string is
        ///                 nul-terminated (Note that some encodings may allow nul
        ///                 bytes to occur inside strings. In that case, using -1
        ///                 for the @len parameter is unsafe)
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes in the
        ///                 input string that were successfully converted, or %NULL.
        ///                 Even if the conversion was successful, this may be
        ///                 less than @len if there were partial characters
        ///                 at the end of the input. If the error
        ///                 #G_CONVERT_ERROR_ILLEGAL_SEQUENCE occurs, the value
        ///                 stored will the byte offset after the last valid
        ///                 input sequence.
        /// </param>
        /// <param name="bytesWritten">
        /// the number of bytes stored in the output buffer (not
        ///                 including the terminating nul).
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// The converted string, or %NULL on an error.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern unsafe IntPtr g_filename_to_utf8(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr opsysstring,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            IntPtr bytesRead,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr* bytesWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Converts a string which is in the encoding used by GLib for
        /// filenames into a UTF-8 string. Note that on Windows GLib uses UTF-8
        /// for filenames; on other platforms, this function indirectly depends on
        /// the [current locale][setlocale].
        /// </summary>
        /// <returns>
        /// The converted string.
        /// </returns>
        /// <exception name="GErrorException">
        /// On error
        /// </exception>
        public unsafe Utf8 ToUtf8()
        {
            var opsysstring_ = Handle;
            UIntPtr bytesWritten_;
            var ret_ = g_filename_to_utf8(opsysstring_, new IntPtr(-1), IntPtr.Zero, &bytesWritten_, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }

            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }
    }
}
