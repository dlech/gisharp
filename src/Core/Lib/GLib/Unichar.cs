
using System;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    public struct Unichar : IEquatable<Unichar>
    {
        readonly int value;

        public Unichar(int value)
        {
            this.value = value;
        }

        public static explicit operator Unichar(int value)
        {
            return new Unichar(value);
        }

        public static explicit operator int(Unichar c)
        {
            return c.value;
        }

        public static bool operator ==(Unichar a, Unichar b)
        {
            return a.value == b.value;
        }

        public static bool operator !=(Unichar a, Unichar b)
        {
            return a.value != b.value;
        }

        public bool Equals(Unichar c) => value == c.value;

        public override bool Equals(object obj) => value.Equals(obj);

        public override int GetHashCode() => value.GetHashCode();

        public override string ToString()
        {
            return $"U+{value:X4}";
        }

        /// <summary>
        /// The maximum length (in codepoints) of a compatibility or canonical
        /// decomposition of a single Unicode character.
        /// </summary>
        /// <remarks>
        /// This is as defined by Unicode 6.1.
        /// </remarks>
        [Since("2.32")]
        public const int MaxDecompositionLength = 18;

        /// <summary>
        /// Determines the break type of @c. @c should be a Unicode character
        /// (to derive a character from UTF-8 encoded text, use
        /// g_utf8_get_char()). The break type is used to find word and line
        /// breaks ("text boundaries"), Pango implements the Unicode boundary
        /// resolution algorithms and normally you would use a function such
        /// as pango_break() instead of caring about break types yourself.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the break type of @c
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="UnicodeBreakType" type="GUnicodeBreakType" managed-name="UnicodeBreakType" /> */
        /* transfer-ownership:none */
        static extern UnicodeBreakType g_unichar_break_type(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines the break type of this character. This character should be a Unicode character
        /// (to derive a character from UTF-8 encoded text, use
        /// <see cref="Utf8.GetEnumerator"/>). The break type is used to find word and line
        /// breaks ("text boundaries"), Pango implements the Unicode boundary
        /// resolution algorithms and normally you would use a function such
        /// as pango_break() instead of caring about break types yourself.
        /// </summary>
        /// <returns>
        /// the break type of @c
        /// </returns>
        public UnicodeBreakType BreakType {
            get {
                var ret = g_unichar_break_type(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines the canonical combining class of a Unicode character.
        /// </summary>
        /// <param name="uc">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the combining class of the character
        /// </returns>
        [Since("2.14")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_unichar_combining_class(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar uc);

        /// <summary>
        /// Determines the canonical combining class of a Unicode character.
        /// </summary>
        /// <returns>
        /// the combining class of the character
        /// </returns>
        [Since("2.14")]
        public int CombiningClass {
            get {
                var ret = g_unichar_combining_class(this);
                return ret;
            }
        }

        /// <summary>
        /// Performs a single composition step of the
        /// Unicode canonical composition algorithm.
        /// </summary>
        /// <remarks>
        /// This function includes algorithmic Hangul Jamo composition,
        /// but it is not exactly the inverse of g_unichar_decompose().
        /// No composition can have either of @a or @b equal to zero.
        /// To be precise, this function composes if and only if
        /// there exists a Primary Composite P which is canonically
        /// equivalent to the sequence &lt;@a,@b&gt;.  See the Unicode
        /// Standard for the definition of Primary Composite.
        ///
        /// If @a and @b do not compose a new character, @ch is set to zero.
        ///
        /// See
        /// [UAX#15](http://unicode.org/reports/tr15/)
        /// for details.
        /// </remarks>
        /// <param name="a">
        /// a Unicode character
        /// </param>
        /// <param name="b">
        /// a Unicode character
        /// </param>
        /// <param name="ch">
        /// return location for the composed character
        /// </param>
        /// <returns>
        /// %TRUE if the characters could be composed
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern unsafe Runtime.Boolean g_unichar_compose(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar a,
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar b,
            /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            out Unichar ch);

        /// <summary>
        /// Performs a single composition step of the
        /// Unicode canonical composition algorithm.
        /// </summary>
        /// <remarks>
        /// This function includes algorithmic Hangul Jamo composition,
        /// but it is not exactly the inverse of <see cref="TryDecompose"/>.
        /// No composition can have either of <paramref name="a"/> or <paramref name="b"/> equal to zero.
        /// To be precise, this function composes if and only if
        /// there exists a Primary Composite P which is canonically
        /// equivalent to the sequence &lt;<paramref name="a"/>,<paramref name="b"/>&gt;.  See the Unicode
        /// Standard for the definition of Primary Composite.
        ///
        /// If <paramref name="a"/> and <paramref name="b"/> do not compose a
        /// new character, <paramref name="ch"/> is set to zero.
        ///
        /// See
        /// [UAX#15](http://unicode.org/reports/tr15/)
        /// for details.
        /// </remarks>
        /// <param name="a">
        /// a Unicode character
        /// </param>
        /// <param name="b">
        /// a Unicode character
        /// </param>
        /// <param name="ch">
        /// return location for the composed character
        /// </param>
        /// <returns>
        /// <c>true</c> if the characters could be composed
        /// </returns>
        [Since("2.30")]
        public static bool TryCompose(Unichar a, Unichar b, out Unichar ch)
        {
            var ret = g_unichar_compose(a, b, out ch);
            return ret;
        }

        /// <summary>
        /// Performs a single decomposition step of the
        /// Unicode canonical decomposition algorithm.
        /// </summary>
        /// <remarks>
        /// This function does not include compatibility
        /// decompositions. It does, however, include algorithmic
        /// Hangul Jamo decomposition, as well as 'singleton'
        /// decompositions which replace a character by a single
        /// other character. In the case of singletons *@b will
        /// be set to zero.
        ///
        /// If @ch is not decomposable, *@a is set to @ch and *@b
        /// is set to zero.
        ///
        /// Note that the way Unicode decomposition pairs are
        /// defined, it is guaranteed that @b would not decompose
        /// further, but @a may itself decompose.  To get the full
        /// canonical decomposition for @ch, one would need to
        /// recursively call this function on @a.  Or use
        /// g_unichar_fully_decompose().
        ///
        /// See
        /// [UAX#15](http://unicode.org/reports/tr15/)
        /// for details.
        /// </remarks>
        /// <param name="ch">
        /// a Unicode character
        /// </param>
        /// <param name="a">
        /// return location for the first component of @ch
        /// </param>
        /// <param name="b">
        /// return location for the second component of @ch
        /// </param>
        /// <returns>
        /// %TRUE if the character could be decomposed
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_decompose(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar ch,
            /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            out Unichar a,
            /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            out Unichar b);

        /// <summary>
        /// Performs a single decomposition step of the
        /// Unicode canonical decomposition algorithm.
        /// </summary>
        /// <remarks>
        /// This function does not include compatibility
        /// decompositions. It does, however, include algorithmic
        /// Hangul Jamo decomposition, as well as 'singleton'
        /// decompositions which replace a character by a single
        /// other character. In the case of singletons <paramref name="b"/> will
        /// be set to zero.
        ///
        /// If @ch is not decomposable, <paramref name="a"/> is set to
        /// this character and <paramref name="b"/>
        /// is set to zero.
        ///
        /// Note that the way Unicode decomposition pairs are
        /// defined, it is guaranteed that <paramref name="b"/> would not decompose
        /// further, but <paramref name="a"/> may itself decompose.  To get the full
        /// canonical decomposition for this character, one would need to
        /// recursively call this function on <paramref name="a"/>.  Or use
        /// <see cref="FullyDecompose"/>.
        ///
        /// See
        /// [UAX#15](http://unicode.org/reports/tr15/)
        /// for details.
        /// </remarks>
        /// <param name="a">
        /// return location for the first component of this character
        /// </param>
        /// <param name="b">
        /// return location for the second component of this character
        /// </param>
        /// <returns>
        /// <c>true</c> if the character could be decomposed
        /// </returns>
        [Since("2.30")]
        public bool TryDecompose(out Unichar a, out Unichar b)
        {
            var ret = g_unichar_decompose(this, out a, out b);
            return ret;
        }

        /// <summary>
        /// Determines the numeric value of a character as a decimal
        /// digit.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// If @c is a decimal digit (according to
        /// g_unichar_isdigit()), its numeric value. Otherwise, -1.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_unichar_digit_value(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines the numeric value of a character as a decimal
        /// digit.
        /// </summary>
        /// <returns>
        /// If this character is a decimal digit (according to
        /// <see cref="IsDigit"/>), its numeric value. Otherwise, <c>-1</c>.
        /// </returns>
        public int DigitValue {
            get {
                var ret = g_unichar_digit_value(this);
                return ret;
            }
        }

        /// <summary>
        /// Computes the canonical or compatibility decomposition of a
        /// Unicode character.  For compatibility decomposition,
        /// pass %TRUE for @compat; for canonical decomposition
        /// pass %FALSE for @compat.
        /// </summary>
        /// <remarks>
        /// The decomposed sequence is placed in @result.  Only up to
        /// @result_len characters are written into @result.  The length
        /// of the full decomposition (irrespective of @result_len) is
        /// returned by the function.  For canonical decomposition,
        /// currently all decompositions are of length at most 4, but
        /// this may change in the future (very unlikely though).
        /// At any rate, Unicode does guarantee that a buffer of length
        /// 18 is always enough for both compatibility and canonical
        /// decompositions, so that is the size recommended. This is provided
        /// as %G_UNICHAR_MAX_DECOMPOSITION_LENGTH.
        ///
        /// See
        /// [UAX#15](http://unicode.org/reports/tr15/)
        /// for details.
        /// </remarks>
        /// <param name="ch">
        /// a Unicode character.
        /// </param>
        /// <param name="compat">
        /// whether perform canonical or compatibility decomposition
        /// </param>
        /// <param name="result">
        /// location to store decomposed result, or %NULL
        /// </param>
        /// <param name="resultLen">
        /// length of @result
        /// </param>
        /// <returns>
        /// the length of the full decomposition.
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static unsafe extern UIntPtr g_unichar_fully_decompose(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar ch,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean compat,
            /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            Unichar* result,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr resultLen);

        /// <summary>
        /// Computes the canonical or compatibility decomposition of a
        /// Unicode character.  For compatibility decomposition,
        /// pass <c>true</c> for <paramref name="compat"/>; for canonical decomposition
        /// pass <c>false</c> for <paramref name="compat"/>;.
        /// </summary>
        /// <param name="compat">
        /// whether perform canonical or compatibility decomposition
        /// </param>
        /// <returns>
        /// the decomposed result
        /// </returns>
        [Since("2.30")]
        public unsafe Memory<Unichar> FullyDecompose(bool compat = false)
        {
            Memory<Unichar> result = new Unichar[MaxDecompositionLength];
            using var resultMemHandle = result.Pin();
            var result_ = (Unichar*)resultMemHandle.Pointer;
            var resultLen_ = (UIntPtr)MaxDecompositionLength;
            var ret = g_unichar_fully_decompose(this, compat, result_, resultLen_);
            return result.Slice(0, (int)ret);
        }

        /// <summary>
        /// In Unicode, some characters are "mirrored". This means that their
        /// images are mirrored horizontally in text that is laid out from right
        /// to left. For instance, "(" would become its mirror image, ")", in
        /// right-to-left text.
        /// </summary>
        /// <remarks>
        /// If @ch has the Unicode mirrored property and there is another unicode
        /// character that typically has a glyph that is the mirror image of @ch's
        /// glyph and @mirrored_ch is set, it puts that character in the address
        /// pointed to by @mirrored_ch.  Otherwise the original character is put.
        /// </remarks>
        /// <param name="ch">
        /// a Unicode character
        /// </param>
        /// <param name="mirroredCh">
        /// location to store the mirrored character
        /// </param>
        /// <returns>
        /// %TRUE if @ch has a mirrored character, %FALSE otherwise
        /// </returns>
        [Since("2.4")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_get_mirror_char(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar ch,
            /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            out Unichar mirroredCh);

        /// <summary>
        /// In Unicode, some characters are "mirrored". This means that their
        /// images are mirrored horizontally in text that is laid out from right
        /// to left. For instance, "(" would become its mirror image, ")", in
        /// right-to-left text.
        /// </summary>
        /// <remarks>
        /// If this character has the Unicode mirrored property and there is another unicode
        /// character that typically has a glyph that is the mirror image of this character's
        /// glyph and <paramref name="mirrored"/> is set, it puts that character in the address
        /// pointed to by <paramref name="mirrored"/>.  Otherwise the original character is put.
        /// </remarks>
        /// <param name="mirrored">
        /// location to store the mirrored character
        /// </param>
        /// <returns>
        /// <c>true</c> if this character has a mirrored character, <c>false</c> otherwise
        /// </returns>
        [Since("2.4")]
        public bool TryGetMirrorChar(out Unichar mirrored)
        {
            var ret = g_unichar_get_mirror_char(this, out mirrored);
            return ret;
        }

        /// <summary>
        /// Looks up the #GUnicodeScript for a particular character (as defined
        /// by Unicode Standard Annex \#24). No check is made for @ch being a
        /// valid Unicode character; if you pass in invalid character, the
        /// result is undefined.
        /// </summary>
        /// <remarks>
        /// This function is equivalent to pango_script_for_unichar() and the
        /// two are interchangeable.
        /// </remarks>
        /// <param name="ch">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the #GUnicodeScript for the character.
        /// </returns>
        [Since("2.14")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="UnicodeScript" type="GUnicodeScript" managed-name="UnicodeScript" /> */
        /* transfer-ownership:none */
        static extern UnicodeScript g_unichar_get_script(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar ch);

        /// <summary>
        /// Looks up the <see cref="UnicodeScript"/> for a particular character (as defined
        /// by Unicode Standard Annex \#24). No check is made for this character being a
        /// valid Unicode character; if this character is an invalid character, the
        /// result is undefined.
        /// </summary>
        /// <remarks>
        /// This function is equivalent to pango_script_for_unichar() and the
        /// two are interchangeable.
        /// </remarks>
        /// <returns>
        /// the <see cref="UnicodeScript"/> for the character.
        /// </returns>
        [Since("2.14")]
        public UnicodeScript Script {
            get {
                var ret = g_unichar_get_script(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is alphanumeric.
        /// Given some UTF-8 text, obtain a character value
        /// with g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is an alphanumeric character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isalnum(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is alphanumeric.
        /// Given some UTF-8 text, obtain a character value
        /// with <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is an alphanumeric character
        /// </returns>
        public bool IsAlphaNumeric {
            get {
                var ret = g_unichar_isalnum(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is alphabetic (i.e. a letter).
        /// Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is an alphabetic character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isalpha(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is alphabetic (i.e. a letter).
        /// Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is an alphabetic character
        /// </returns>
        public bool IsAlpha {
            get {
                var ret = g_unichar_isalpha(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is a control character.
        /// Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a control character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_iscntrl(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is a control character.
        /// Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is a control character
        /// </returns>
        public bool IsControl {
            get {
                var ret = g_unichar_iscntrl(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a given character is assigned in the Unicode
        /// standard.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if the character has an assigned value
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isdefined(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a given character is assigned in the Unicode
        /// standard.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the character has an assigned value
        /// </returns>
        public bool IsDefined {
            get {
                var ret = g_unichar_isdefined(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is numeric (i.e. a digit).  This
        /// covers ASCII 0-9 and also digits in other languages/scripts.  Given
        /// some UTF-8 text, obtain a character value with g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a digit
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isdigit(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is numeric (i.e. a digit).  This
        /// covers ASCII 0-9 and also digits in other languages/scripts.  Given
        /// some UTF-8 text, obtain a character value with <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is a digit
        /// </returns>
        public bool IsDigit {
            get {
                var ret = g_unichar_isdigit(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is printable and not a space
        /// (returns %FALSE for control characters, format characters, and
        /// spaces). g_unichar_isprint() is similar, but returns %TRUE for
        /// spaces. Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is printable unless it's a space
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isgraph(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is printable and not a space
        /// (returns <c>false</c> for control characters, format characters, and
        /// spaces). <see cref="IsPrintable"/> is similar, but returns <c>true</c> for
        /// spaces. Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is printable unless it's a space
        /// </returns>
        public bool IsGraph {
            get {
                var ret = g_unichar_isgraph(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is a lowercase letter.
        /// Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a lowercase letter
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_islower(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is a lowercase letter.
        /// Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is a lowercase letter
        /// </returns>
        public bool IsLowercase {
            get {
                var ret = g_unichar_islower(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is a mark (non-spacing mark,
        /// combining mark, or enclosing mark in Unicode speak).
        /// Given some UTF-8 text, obtain a character value
        /// with g_utf8_get_char().
        /// </summary>
        /// <remarks>
        /// Note: in most cases where isalpha characters are allowed,
        /// ismark characters should be allowed to as they are essential
        /// for writing most European languages as well as many non-Latin
        /// scripts.
        /// </remarks>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a mark character
        /// </returns>
        [Since("2.14")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_ismark(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is a mark (non-spacing mark,
        /// combining mark, or enclosing mark in Unicode speak).
        /// Given some UTF-8 text, obtain a character value
        /// with <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <remarks>
        /// Note: in most cases where <see cref="IsAlpha"/> characters are allowed,
        /// <see cref="IsMark"/> characters should be allowed to as they are essential
        /// for writing most European languages as well as many non-Latin
        /// scripts.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this character is a mark character
        /// </returns>
        [Since("2.14")]
        public bool IsMark {
            get {
                var ret = g_unichar_ismark(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is printable.
        /// Unlike g_unichar_isgraph(), returns %TRUE for spaces.
        /// Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is printable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isprint(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is printable.
        /// Unlike <see cref="IsGraph"/>, returns <c>true</c> for spaces.
        /// Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is printable
        /// </returns>
        public bool IsPrintable {
            get {
                var ret = g_unichar_isprint(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is punctuation or a symbol.
        /// Given some UTF-8 text, obtain a character value with
        /// g_utf8_get_char().
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a punctuation or symbol character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_ispunct(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is punctuation or a symbol.
        /// Given some UTF-8 text, obtain a character value with
        /// <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is a punctuation or symbol character
        /// </returns>
        public bool IsPunctuation {
            get {
                var ret = g_unichar_ispunct(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines whether a character is a space, tab, or line separator
        /// (newline, carriage return, etc.).  Given some UTF-8 text, obtain a
        /// character value with g_utf8_get_char().
        /// </summary>
        /// <remarks>
        /// (Note: don't use this to do word breaking; you have to use
        /// Pango or equivalent to get word breaking right, the algorithm
        /// is fairly complex.)
        /// </remarks>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is a space character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isspace(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines whether a character is a space, tab, or line separator
        /// (newline, carriage return, etc.).  Given some UTF-8 text, obtain a
        /// character value with <see cref="Utf8.GetEnumerator"/>.
        /// </summary>
        /// <remarks>
        /// (Note: don't use this to do word breaking; you have to use
        /// Pango or equivalent to get word breaking right, the algorithm
        /// is fairly complex.)
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this character is a space character
        /// </returns>
        public bool IsSpace {
            get {
                var ret = g_unichar_isspace(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a character is titlecase. Some characters in
        /// Unicode which are composites, such as the DZ digraph
        /// have three case variants instead of just two. The titlecase
        /// form is used at the beginning of a word where only the
        /// first letter is capitalized. The titlecase form of the DZ
        /// digraph is U+01F2 LATIN CAPITAL LETTTER D WITH SMALL LETTER Z.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if the character is titlecase
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_istitle(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a character is titlecase. Some characters in
        /// Unicode which are composites, such as the DZ digraph
        /// have three case variants instead of just two. The titlecase
        /// form is used at the beginning of a word where only the
        /// first letter is capitalized. The titlecase form of the DZ
        /// digraph is U+01F2 LATIN CAPITAL LETTTER D WITH SMALL LETTER Z.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the character is titlecase
        /// </returns>
        public bool IsTitlecase {
            get {
                var ret = g_unichar_istitle(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a character is uppercase.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @c is an uppercase character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isupper(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a character is uppercase.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is an uppercase character
        /// </returns>
        public bool IsUppercase {
            get {
                var ret = g_unichar_isupper(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a character is typically rendered in a double-width
        /// cell.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if the character is wide
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_iswide(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a character is typically rendered in a double-width
        /// cell.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the character is wide
        /// </returns>
        public bool IsWide {
            get {
                var ret = g_unichar_iswide(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a character is typically rendered in a double-width
        /// cell under legacy East Asian locales.  If a character is wide according to
        /// g_unichar_iswide(), then it is also reported wide with this function, but
        /// the converse is not necessarily true. See the
        /// [Unicode Standard Annex #11](http://www.unicode.org/reports/tr11/)
        /// for details.
        /// </summary>
        /// <remarks>
        /// If a character passes the g_unichar_iswide() test then it will also pass
        /// this test, but not the other way around.  Note that some characters may
        /// pass both this test and g_unichar_iszerowidth().
        /// </remarks>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if the character is wide in legacy East Asian locales
        /// </returns>
        [Since("2.12")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_iswide_cjk(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a character is typically rendered in a double-width
        /// cell under legacy East Asian locales.  If a character is wide according to
        /// <see cref="IsWide"/>, then it is also reported wide with this function, but
        /// the converse is not necessarily true. See the
        /// [Unicode Standard Annex #11](http://www.unicode.org/reports/tr11/)
        /// for details.
        /// </summary>
        /// <remarks>
        /// If a character passes the <see cref="IsWide"/> test then it will also pass
        /// this test, but not the other way around.  Note that some characters may
        /// pass both this test and <see cref="IsZeroWidth"/>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the character is wide in legacy East Asian locales
        /// </returns>
        [Since("2.12")]
        public bool IsWideCJK {
            get {
                var ret = g_unichar_iswide_cjk(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a character is a hexidecimal digit.
        /// </summary>
        /// <param name="c">
        /// a Unicode character.
        /// </param>
        /// <returns>
        /// %TRUE if the character is a hexadecimal digit
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_isxdigit(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a character is a hexadecimal digit.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the character is a hexadecimal digit
        /// </returns>
        public bool IsHexDigit {
            get {
                var ret = g_unichar_isxdigit(this);
                return ret;
            }
        }

        /// <summary>
        /// Determines if a given character typically takes zero width when rendered.
        /// The return value is %TRUE for all non-spacing and enclosing marks
        /// (e.g., combining accents), format characters, zero-width
        /// space, but not U+00AD SOFT HYPHEN.
        /// </summary>
        /// <remarks>
        /// A typical use of this function is with one of g_unichar_iswide() or
        /// g_unichar_iswide_cjk() to determine the number of cells a string occupies
        /// when displayed on a grid display (terminals).  However, note that not all
        /// terminals support zero-width rendering of zero-width marks.
        /// </remarks>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if the character has zero width
        /// </returns>
        [Since("2.14")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_iszerowidth(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines if a given character typically takes zero width when rendered.
        /// The return value is <c>true</c> for all non-spacing and enclosing marks
        /// (e.g., combining accents), format characters, zero-width
        /// space, but not U+00AD SOFT HYPHEN.
        /// </summary>
        /// <remarks>
        /// A typical use of this function is with one of <see cref="IsWide"/> or
        /// <see cref="IsWideCJK"/> to determine the number of cells a string occupies
        /// when displayed on a grid display (terminals).  However, note that not all
        /// terminals support zero-width rendering of zero-width marks.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the character has zero width
        /// </returns>
        [Since("2.14")]
        public bool IsZeroWidth {
            get {
                var ret = g_unichar_iszerowidth(this);
                return ret;
            }
        }

        /// <summary>
        /// Converts a single character to UTF-8.
        /// </summary>
        /// <param name="c">
        /// a Unicode character code
        /// </param>
        /// <param name="outbuf">
        /// output buffer, must have at least 6 bytes of space.
        ///       If %NULL, the length will be computed and returned
        ///       and nothing will be written to @outbuf.
        /// </param>
        /// <returns>
        /// number of bytes written
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_unichar_to_utf8(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c,
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr outbuf);

        /// <summary>
        /// Converts a single character to UTF-8.
        /// </summary>
        public Utf8 ToUtf8()
        {
            var outbuf_ = GMarshal.Alloc0(6);
            g_unichar_to_utf8(this, outbuf_);
            var outbuf = new Utf8(outbuf_, Transfer.Full);
            return outbuf;
        }

        /// <summary>
        /// Converts a character to lower case.
        /// </summary>
        /// <param name="c">
        /// a Unicode character.
        /// </param>
        /// <returns>
        /// the result of converting @c to lower case.
        ///               If @c is not an upperlower or titlecase character,
        ///               or has no lowercase equivalent @c is returned unchanged.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_unichar_tolower(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Converts a character to lower case.
        /// </summary>
        /// <returns>
        /// the result of converting this character to lower case.
        /// If this character is not an upperlower or titlecase character,
        /// or has no lowercase equivalent this character is returned unchanged.
        /// </returns>
        public Unichar ToLowercase()
        {
            var ret = g_unichar_tolower(this);
            return ret;
        }

        /// <summary>
        /// Converts a character to the titlecase.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the result of converting @c to titlecase.
        ///               If @c is not an uppercase or lowercase character,
        ///               @c is returned unchanged.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_unichar_totitle(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Converts a character to the titlecase.
        /// </summary>
        /// <returns>
        /// the result of converting this character to titlecase.
        /// If this character is not an uppercase or lowercase character,
        /// this character is returned unchanged.
        /// </returns>
        public Unichar ToTitlecase()
        {
            var ret = g_unichar_totitle(this);
            return ret;
        }

        /// <summary>
        /// Converts a character to uppercase.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the result of converting @c to uppercase.
        ///               If @c is not an lowercase or titlecase character,
        ///               or has no upper case equivalent @c is returned unchanged.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_unichar_toupper(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Converts a character to uppercase.
        /// </summary>
        /// <returns>
        /// the result of converting this character to uppercase.
        /// If this character is not an lowercase or titlecase character,
        /// or has no upper case equivalent this character is returned unchanged.
        /// </returns>
        public Unichar ToUppercase()
        {
            var ret = g_unichar_toupper(this);
            return ret;
        }

        /// <summary>
        /// Classifies a Unicode character by type.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// the type of the character.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="UnicodeType" type="GUnicodeType" managed-name="UnicodeType" /> */
        /* transfer-ownership:none */
        static extern UnicodeType g_unichar_type(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Classifies a Unicode character by type.
        /// </summary>
        /// <returns>
        /// the type of the character.
        /// </returns>
        public UnicodeType Type {
            get {
                var ret = g_unichar_type(this);
                return ret;
            }
        }

        /// <summary>
        /// Checks whether @ch is a valid Unicode character. Some possible
        /// integer values of @ch will not be valid. 0 is considered a valid
        /// character, though it's normally a string terminator.
        /// </summary>
        /// <param name="ch">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %TRUE if @ch is a valid Unicode character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_unichar_validate(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar ch);

        /// <summary>
        /// Checks whether this character is a valid Unicode character. Some possible
        /// integer values of this character will not be valid. 0 is considered a valid
        /// character, though it's normally a string terminator.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this character is a valid Unicode character
        /// </returns>
        public bool IsValid => g_unichar_validate(this);

        /// <summary>
        /// Determines the numeric value of a character as a hexidecimal
        /// digit.
        /// </summary>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// If @c is a hex digit (according to
        /// g_unichar_isxdigit()), its numeric value. Otherwise, -1.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_unichar_xdigit_value(
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        /// <summary>
        /// Determines the numeric value of a character as a hexadecimal
        /// digit.
        /// </summary>
        /// <returns>
        /// If this character is a hex digit (according to
        /// <see cref="IsHexDigit"/>), its numeric value. Otherwise, <c>-1</c>.
        /// </returns>
        public int HexDigitValue {
            get {
                var ret = g_unichar_xdigit_value(this);
                return ret;
            }
        }

        public static implicit operator Rune(Unichar unichar)
        {
            return new Rune(unichar.value);
        }

        public static implicit operator Unichar(Rune rune)
        {
            return new Unichar(rune.Value);
        }
    }
}
