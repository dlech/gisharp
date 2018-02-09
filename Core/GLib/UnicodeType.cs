
namespace GISharp.GLib
{
    /// <summary>
    /// These are the possible character classifications from the
    /// Unicode specification.
    /// </summary>
    /// <seealso><see href="http://www.unicode.org/Public/UNIDATA/UnicodeData.html">http://www.unicode.org/Public/UNIDATA/UnicodeData.html</see></seealso>
    public enum UnicodeType
    {
        /// <summary>
        /// General category "Other, Control" (Cc)
        /// </summary>
        Control = 0,

        /// <summary>
        /// General category "Other, Format" (Cf)
        /// </summary>
        Format = 1,

        /// <summary>
        /// General category "Other, Not Assigned" (Cn)
        /// </summary>
        Unassigned = 2,

        /// <summary>
        /// General category "Other, Private Use" (Co)
        /// </summary>
        PrivateUse = 3,

        /// <summary>
        /// General category "Other, Surrogate" (Cs)
        /// </summary>
        Surrogate = 4,

        /// <summary>
        /// General category "Letter, Lowercase" (Ll)
        /// </summary>
        LowercaseLetter = 5,

        /// <summary>
        /// General category "Letter, Modifier" (Lm)
        /// </summary>
        ModifierLetter = 6,

        /// <summary>
        /// General category "Letter, Other" (Lo)
        /// </summary>
        OtherLetter = 7,

        /// <summary>
        /// General category "Letter, Titlecase" (Lt)
        /// </summary>
        TitlecaseLetter = 8,

        /// <summary>
        /// General category "Letter, Uppercase" (Lu)
        /// </summary>
        UppercaseLetter = 9,

        /// <summary>
        /// General category "Mark, Spacing" (Mc)
        /// </summary>
        SpacingMark = 10,

        /// <summary>
        /// General category "Mark, Enclosing" (Me)
        /// </summary>
        EnclosingMark = 11,

        /// <summary>
        /// General category "Mark, Nonspacing" (Mn)
        /// </summary>
        NonSpacingMark = 12,

        /// <summary>
        /// General category "Number, Decimal Digit" (Nd)
        /// </summary>
        DecimalNumber = 13,

        /// <summary>
        /// General category "Number, Letter" (Nl)
        /// </summary>
        LetterNumber = 14,

        /// <summary>
        /// General category "Number, Other" (No)
        /// </summary>
        OtherNumber = 15,

        /// <summary>
        /// General category "Punctuation, Connector" (Pc)
        /// </summary>
        ConnectPunctuation = 16,

        /// <summary>
        /// General category "Punctuation, Dash" (Pd)
        /// </summary>
        DashPunctuation = 17,

        /// <summary>
        /// General category "Punctuation, Close" (Pe)
        /// </summary>
        ClosePunctuation = 18,

        /// <summary>
        /// General category "Punctuation, Final quote" (Pf)
        /// </summary>
        FinalPunctuation = 19,

        /// <summary>
        /// General category "Punctuation, Initial quote" (Pi)
        /// </summary>
        InitialPunctuation = 20,

        /// <summary>
        /// General category "Punctuation, Other" (Po)
        /// </summary>
        OtherPunctuation = 21,

        /// <summary>
        /// General category "Punctuation, Open" (Ps)
        /// </summary>
        OpenPunctuation = 22,

        /// <summary>
        /// General category "Symbol, Currency" (Sc)
        /// </summary>
        CurrencySymbol = 23,

        /// <summary>
        /// General category "Symbol, Modifier" (Sk)
        /// </summary>
        ModifierSymbol = 24,

        /// <summary>
        /// General category "Symbol, Math" (Sm)
        /// </summary>
        MathSymbol = 25,

        /// <summary>
        /// General category "Symbol, Other" (So)
        /// </summary>
        OtherSymbol = 26,

        /// <summary>
        /// General category "Separator, Line" (Zl)
        /// </summary>
        LineSeparator = 27,

        /// <summary>
        /// General category "Separator, Paragraph" (Zp)
        /// </summary>
        ParagraphSeparator = 28,

        /// <summary>
        /// General category "Separator, Space" (Zs)
        /// </summary>
        SpaceSeparator = 29
    }
}
