using GISharp.Runtime;

namespace GISharp.Lib.GLib
{

    /// <summary>
    /// These are the possible line break classifications.
    /// </summary>
    /// <remarks>
    /// Since new unicode versions may add new types here, applications should be ready
    /// to handle unknown values. They may be regarded as <see cref="UnicodeBreakType.Unknown"/>.
    /// </remarks>
    /// <seealso><see href="http://www.unicode.org/unicode/reports/tr14/">http://www.unicode.org/unicode/reports/tr14/</see></seealso>
    public enum UnicodeBreakType
    {
        /// <summary>
        /// Mandatory Break (BK)
        /// </summary>
        Mandatory = 0,

        /// <summary>
        /// Carriage Return (CR)
        /// </summary>
        CarriageReturn = 1,

        /// <summary>
        /// Line Feed (LF)
        /// </summary>
        LineFeed = 2,

        /// <summary>
        /// Attached Characters and Combining Marks (CM)
        /// </summary>
        CombiningMark = 3,

        /// <summary>
        /// Surrogates (SG)
        /// </summary>
        Surrogate = 4,

        /// <summary>
        /// Zero Width Space (ZW)
        /// </summary>
        ZeroWidthSpace = 5,

        /// <summary>
        /// Inseparable (IN)
        /// </summary>
        Inseparable = 6,

        /// <summary>
        /// Non-breaking ("Glue") (GL)
        /// </summary>
        NonBreakingGlue = 7,

        /// <summary>
        /// Contingent Break Opportunity (CB)
        /// </summary>
        Contingent = 8,

        /// <summary>
        /// Space (SP)
        /// </summary>
        Space = 9,

        /// <summary>
        /// Break Opportunity After (BA)
        /// </summary>
        After = 10,

        /// <summary>
        /// Break Opportunity Before (BB)
        /// </summary>
        Before = 11,

        /// <summary>
        /// Break Opportunity Before and After (B2)
        /// </summary>
        BeforeAndAfter = 12,

        /// <summary>
        /// Hyphen (HY)
        /// </summary>
        Hyphen = 13,

        /// <summary>
        /// Nonstarter (NS)
        /// </summary>
        NonStarter = 14,

        /// <summary>
        /// Opening Punctuation (OP)
        /// </summary>
        OpenPunctuation = 15,

        /// <summary>
        /// Closing Punctuation (CL)
        /// </summary>
        ClosePunctuation = 16,

        /// <summary>
        /// Ambiguous Quotation (QU)
        /// </summary>
        Quotation = 17,

        /// <summary>
        /// Exclamation/Interrogation (EX)
        /// </summary>
        Exclamation = 18,

        /// <summary>
        /// Ideographic (ID)
        /// </summary>
        Ideographic = 19,

        /// <summary>
        /// Numeric (NU)
        /// </summary>
        Numeric = 20,

        /// <summary>
        /// Infix Separator (Numeric) (IS)
        /// </summary>
        InfixSeparator = 21,

        /// <summary>
        /// Symbols Allowing Break After (SY)
        /// </summary>
        Symbol = 22,

        /// <summary>
        /// Ordinary Alphabetic and Symbol Characters (AL)
        /// </summary>
        Alphabetic = 23,

        /// <summary>
        /// Prefix (Numeric) (PR)
        /// </summary>
        Prefix = 24,

        /// <summary>
        /// Postfix (Numeric) (PO)
        /// </summary>
        Postfix = 25,

        /// <summary>
        /// Complex Content Dependent (South East Asian) (SA)
        /// </summary>
        ComplexContext = 26,

        /// <summary>
        /// Ambiguous (Alphabetic or Ideographic) (AI)
        /// </summary>
        Ambiguous = 27,

        /// <summary>
        /// Unknown (XX)
        /// </summary>
        Unknown = 28,

        /// <summary>
        /// Next Line (NL)
        /// </summary>
        NextLine = 29,

        /// <summary>
        /// Word Joiner (WJ)
        /// </summary>
        WordJoiner = 30,

        /// <summary>
        /// Hangul L Jamo (JL)
        /// </summary>
        HangulLJamo = 31,

        /// <summary>
        /// Hangul V Jamo (JV)
        /// </summary>
        HangulVJamo = 32,

        /// <summary>
        /// Hangul T Jamo (JT)
        /// </summary>
        HangulTJamo = 33,

        /// <summary>
        /// Hangul LV Syllable (H2)
        /// </summary>
        HangulLvSyllable = 34,

        /// <summary>
        /// Hangul LVT Syllable (H3)
        /// </summary>
        HangulLvtSyllable = 35,

        /// <summary>
        /// Closing Parenthesis (CP).
        /// </summary>
        [Since("2.28")]
        CloseParanthesis = 36,

        /// <summary>
        /// Conditional Japanese Starter (CJ).
        /// </summary>
        [Since("2.32")]
        ConditionalJapaneseStarter = 37,

        /// <summary>
        /// Hebrew Letter (HL).
        /// </summary>
        [Since("2.32")]
        HebrewLetter = 38,

        /// <summary>
        /// Regional Indicator (RI).
        /// </summary>
        [Since("2.36")]
        RegionalIndicator = 39
    }
}
