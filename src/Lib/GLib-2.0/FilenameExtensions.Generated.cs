// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions']/*" />
    public static unsafe partial class FilenameExtensions
    {
        /// <summary>
        /// Creates a filename from a vector of elements using the correct
        /// separator for the current platform.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function behaves exactly like g_build_filename(), but takes the path
        /// elements as a string array, instead of varargs. This function is mainly
        /// meant for language bindings.
        /// </para>
        /// <para>
        /// If you are building a path programmatically you may want to use
        /// #GPathBuf instead.
        /// </para>
        /// </remarks>
        /// <param name="args">
        /// %NULL-terminated
        ///   array of strings containing the path elements.
        /// </param>
        /// <returns>
        /// the newly allocated path
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.8")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_build_filenamev(
        /* <array type="gchar**" zero-terminated="1" is-pointer="1">
*   <type name="filename" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        byte** args);
        static partial void CheckBuildArgs(GISharp.Runtime.UnownedZeroTerminatedCPtrArray<GISharp.Runtime.Filename> args);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.Build(GISharp.Runtime.UnownedZeroTerminatedCPtrArray&lt;GISharp.Runtime.Filename&gt;)']/*" />
        [GISharp.Runtime.SinceAttribute("2.8")]
        public static GISharp.Runtime.Filename Build(GISharp.Runtime.UnownedZeroTerminatedCPtrArray<GISharp.Runtime.Filename> args)
        {
            fixed (System.IntPtr* argsData_ = args)
            {
                CheckBuildArgs(args);
                var args_ = (byte**)argsData_;
                var ret_ = g_build_filenamev(args_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.Filename.GetInstance<GISharp.Runtime.Filename>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
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
        /// Location to store hostname for the URI.
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_from_uri(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* uri,
        /* <type name="utf8" type="gchar**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full nullable:1 optional:1 allow-none:1 */
        byte** hostname,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        static partial void CheckFromUriArgs(GISharp.Runtime.UnownedUtf8 uri);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.FromUri(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.Utf8?)']/*" />
        public static GISharp.Runtime.Filename FromUri(GISharp.Runtime.UnownedUtf8 uri, out GISharp.Runtime.Utf8? hostname)
        {
            CheckFromUriArgs(uri);
            var uri_ = (byte*)uri.UnsafeHandle;
            byte* hostname_;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_filename_from_uri(uri_,&hostname_,&error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            hostname = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)hostname_, GISharp.Runtime.Transfer.Full);
            var ret = GISharp.Runtime.Filename.GetInstance<GISharp.Runtime.Filename>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Converts a string from UTF-8 to the encoding GLib uses for
        /// filenames. Note that on Windows GLib uses UTF-8 for filenames;
        /// on other platforms, this function indirectly depends on the
        /// [current locale][setlocale].
        /// </summary>
        /// <remarks>
        /// <para>
        /// The input string shall not contain nul characters even if the @len
        /// argument is positive. A nul character found inside the string will result
        /// in error %G_CONVERT_ERROR_ILLEGAL_SEQUENCE. If the filename encoding is
        /// not UTF-8 and the conversion output contains a nul character, the error
        /// %G_CONVERT_ERROR_EMBEDDED_NUL is set and the function returns %NULL.
        /// </para>
        /// </remarks>
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
        ///                 %G_CONVERT_ERROR_ILLEGAL_SEQUENCE occurs, the value
        ///                 stored will be the byte offset after the last valid
        ///                 input sequence.
        /// </param>
        /// <param name="bytesWritten">
        /// the number of bytes stored in
        ///                 the output buffer (not including the terminating nul).
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///               The converted string, or %NULL on an error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_from_utf8(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* utf8string,
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        nint len,
        /* <type name="gsize" type="gsize*" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        nuint* bytesRead,
        /* <type name="gsize" type="gsize*" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        nuint* bytesWritten,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        static partial void CheckFromUtf8Args(GISharp.Runtime.UnownedUtf8 utf8string, int len);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.FromUtf8(GISharp.Runtime.UnownedUtf8,int,int,int)']/*" />
        public static GISharp.Runtime.Filename FromUtf8(GISharp.Runtime.UnownedUtf8 utf8string, int len, out int bytesRead, out int bytesWritten)
        {
            CheckFromUtf8Args(utf8string, len);
            var utf8string_ = (byte*)utf8string.UnsafeHandle;
            var len_ = (nint)len;
            nuint bytesRead_;
            nuint bytesWritten_;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_filename_from_utf8(utf8string_,len_,&bytesRead_,&bytesWritten_,&error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            bytesRead = (int)bytesRead_;
            bytesWritten = (int)bytesWritten_;
            var ret = GISharp.Runtime.Filename.GetInstance<GISharp.Runtime.Filename>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Determines the preferred character sets used for filenames.
        /// The first character set from the @charsets is the filename encoding, the
        /// subsequent character sets are used when trying to generate a displayable
        /// representation of a filename, see g_filename_display_name().
        /// </summary>
        /// <remarks>
        /// <para>
        /// On Unix, the character sets are determined by consulting the
        /// environment variables `G_FILENAME_ENCODING` and `G_BROKEN_FILENAMES`.
        /// On Windows, the character set used in the GLib API is always UTF-8
        /// and said environment variables have no effect.
        /// </para>
        /// <para>
        /// `G_FILENAME_ENCODING` may be set to a comma-separated list of
        /// character set names. The special token "\@locale" is taken
        /// to  mean the character set for the [current locale][setlocale].
        /// If `G_FILENAME_ENCODING` is not set, but `G_BROKEN_FILENAMES` is,
        /// the character set of the current locale is taken as the filename
        /// encoding. If neither environment variable  is set, UTF-8 is taken
        /// as the filename encoding, but the character set of the current locale
        /// is also put in the list of encodings.
        /// </para>
        /// <para>
        /// The returned @charsets belong to GLib and must not be freed.
        /// </para>
        /// <para>
        /// Note that on Unix, regardless of the locale character set or
        /// `G_FILENAME_ENCODING` value, the actual file names present
        /// on a system might be in any random encoding or just gibberish.
        /// </para>
        /// </remarks>
        /// <param name="filenameCharsets">
        /// 
        ///    return location for the %NULL-terminated list of encoding names
        /// </param>
        /// <returns>
        /// %TRUE if the filename encoding is UTF-8.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_get_filename_charsets(
        /* <array type="const gchar***" zero-terminated="1" is-pointer="1">
*   <type name="utf8" type="gchar**" is-pointer="1" />
* </array> */
        /* direction:out caller-allocates:0 transfer-ownership:none */
        byte*** filenameCharsets);
        static partial void CheckTryGetCharsetsArgs();

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.TryGetCharsets(GISharp.Runtime.UnownedZeroTerminatedCPtrArray&lt;GISharp.Runtime.Utf8&gt;)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static bool TryGetCharsets(out GISharp.Runtime.UnownedZeroTerminatedCPtrArray<GISharp.Runtime.Utf8> filenameCharsets)
        {
            CheckTryGetCharsetsArgs();
            byte** filenameCharsets_;
            var ret_ = g_get_filename_charsets(&filenameCharsets_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            filenameCharsets = new GISharp.Runtime.UnownedZeroTerminatedCPtrArray<GISharp.Runtime.Utf8>(filenameCharsets_, -1);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Gets the canonical file name from @filename. All triple slashes are turned into
        /// single slashes, and all `..` and `.`s resolved against @relative_to.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Symlinks are not followed, and the returned path is guaranteed to be absolute.
        /// </para>
        /// <para>
        /// If @filename is an absolute path, @relative_to is ignored. Otherwise,
        /// @relative_to will be prepended to @filename to make it absolute. @relative_to
        /// must be an absolute path, or %NULL. If @relative_to is %NULL, it'll fallback
        /// to g_get_current_dir().
        /// </para>
        /// <para>
        /// This function never fails, and will canonicalize file paths even if they don't
        /// exist.
        /// </para>
        /// <para>
        /// No file system I/O is done.
        /// </para>
        /// </remarks>
        /// <param name="filename">
        /// the name of the file
        /// </param>
        /// <param name="relativeTo">
        /// the relative directory, or %NULL
        /// to use the current working directory
        /// </param>
        /// <returns>
        /// a newly allocated string with the
        ///   canonical file path
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.58")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_canonicalize_filename(
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* filename,
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* relativeTo);
        static partial void CheckCanonicalizeArgs(this GISharp.Runtime.Filename filename, GISharp.Runtime.Filename? relativeTo = default);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.Canonicalize(GISharp.Runtime.Filename,GISharp.Runtime.Filename?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.58")]
        public static GISharp.Runtime.Filename Canonicalize(this GISharp.Runtime.Filename filename, GISharp.Runtime.Filename? relativeTo = default)
        {
            CheckCanonicalizeArgs(filename, relativeTo);
            var filename_ = (byte*)filename.UnsafeHandle;
            var relativeTo_ = (byte*)(relativeTo?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_canonicalize_filename(filename_,relativeTo_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Filename.GetInstance<GISharp.Runtime.Filename>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Returns the display basename for the particular filename, guaranteed
        /// to be valid UTF-8. The display name might not be identical to the filename,
        /// for instance there might be problems converting it to UTF-8, and some files
        /// can be translated in the display.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// </para>
        /// <para>
        /// You must pass the whole absolute pathname to this functions so that
        /// translation of well known locations can be done.
        /// </para>
        /// <para>
        /// This function is preferred over g_filename_display_name() if you know the
        /// whole path, as it allows translation.
        /// </para>
        /// </remarks>
        /// <param name="filename">
        /// an absolute pathname in the
        ///     GLib file name encoding
        /// </param>
        /// <returns>
        /// a newly allocated string containing
        ///   a rendition of the basename of the filename in valid UTF-8
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_display_basename(
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* filename);
        static partial void CheckDisplayBasenameArgs(this GISharp.Runtime.Filename filename);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.DisplayBasename(GISharp.Runtime.Filename)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static GISharp.Runtime.Utf8 DisplayBasename(this GISharp.Runtime.Filename filename)
        {
            CheckDisplayBasenameArgs(filename);
            var filename_ = (byte*)filename.UnsafeHandle;
            var ret_ = g_filename_display_basename(filename_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Converts a filename into a valid UTF-8 string. The conversion is
        /// not necessarily reversible, so you should keep the original around
        /// and use the return value of this function only for display purposes.
        /// Unlike g_filename_to_utf8(), the result is guaranteed to be non-%NULL
        /// even if the filename actually isn't in the GLib file name encoding.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If GLib cannot make sense of the encoding of @filename, as a last resort it
        /// replaces unknown characters with U+FFFD, the Unicode replacement character.
        /// You can search the result for the UTF-8 encoding of this character (which is
        /// "\357\277\275" in octal notation) to find out if @filename was in an invalid
        /// encoding.
        /// </para>
        /// <para>
        /// If you know the whole pathname of the file you should use
        /// g_filename_display_basename(), since that allows location-based
        /// translation of filenames.
        /// </para>
        /// </remarks>
        /// <param name="filename">
        /// a pathname hopefully in the
        ///     GLib file name encoding
        /// </param>
        /// <returns>
        /// a newly allocated string containing
        ///   a rendition of the filename in valid UTF-8
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_display_name(
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* filename);
        static partial void CheckDisplayNameArgs(this GISharp.Runtime.Filename filename);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.DisplayName(GISharp.Runtime.Filename)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static GISharp.Runtime.Utf8 DisplayName(this GISharp.Runtime.Filename filename)
        {
            CheckDisplayNameArgs(filename);
            var filename_ = (byte*)filename.UnsafeHandle;
            var ret_ = g_filename_display_name(filename_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Converts an absolute filename to an escaped ASCII-encoded URI, with the path
        /// component following Section 3.3. of RFC 2396.
        /// </summary>
        /// <param name="filename">
        /// an absolute filename specified in the GLib file
        ///     name encoding, which is the on-disk file name bytes on Unix, and UTF-8
        ///     on Windows
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_to_uri(
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* filename,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* hostname,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        static partial void CheckToUriArgs(this GISharp.Runtime.Filename filename, GISharp.Runtime.NullableUnownedUtf8 hostname = default);

        /// <include file="FilenameExtensions.xmldoc" path="declaration/member[@name='FilenameExtensions.ToUri(GISharp.Runtime.Filename,GISharp.Runtime.NullableUnownedUtf8)']/*" />
        public static GISharp.Runtime.Utf8 ToUri(this GISharp.Runtime.Filename filename, GISharp.Runtime.NullableUnownedUtf8 hostname = default)
        {
            CheckToUriArgs(filename, hostname);
            var filename_ = (byte*)filename.UnsafeHandle;
            var hostname_ = (byte*)hostname.UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_filename_to_uri(filename_,hostname_,&error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Converts a string which is in the encoding used by GLib for
        /// filenames into a UTF-8 string. Note that on Windows GLib uses UTF-8
        /// for filenames; on other platforms, this function indirectly depends on
        /// the [current locale][setlocale].
        /// </summary>
        /// <remarks>
        /// <para>
        /// The input string shall not contain nul characters even if the @len
        /// argument is positive. A nul character found inside the string will result
        /// in error %G_CONVERT_ERROR_ILLEGAL_SEQUENCE.
        /// If the source encoding is not UTF-8 and the conversion output contains a
        /// nul character, the error %G_CONVERT_ERROR_EMBEDDED_NUL is set and the
        /// function returns %NULL. Use g_convert() to produce output that
        /// may contain embedded nul characters.
        /// </para>
        /// </remarks>
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
        ///                 %G_CONVERT_ERROR_ILLEGAL_SEQUENCE occurs, the value
        ///                 stored will be the byte offset after the last valid
        ///                 input sequence.
        /// </param>
        /// <param name="bytesWritten">
        /// the number of bytes stored in the output
        ///                 buffer (not including the terminating nul).
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// The converted string, or %NULL on an error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_filename_to_utf8(
        /* <type name="filename" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* opsysstring,
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        nint len,
        /* <type name="gsize" type="gsize*" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        nuint* bytesRead,
        /* <type name="gsize" type="gsize*" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        nuint* bytesWritten,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
    }
}