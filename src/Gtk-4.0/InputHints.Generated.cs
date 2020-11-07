// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkInputHints", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum InputHints
    {
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.Spellcheck']/*" />
        Spellcheck = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.NoSpellcheck']/*" />
        NoSpellcheck = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.WordCompletion']/*" />
        WordCompletion = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.Lowercase']/*" />
        Lowercase = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.UppercaseChars']/*" />
        UppercaseChars = 0b0000_0000_0000_0000_0000_0000_0001_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.UppercaseWords']/*" />
        UppercaseWords = 0b0000_0000_0000_0000_0000_0000_0010_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.UppercaseSentences']/*" />
        UppercaseSentences = 0b0000_0000_0000_0000_0000_0000_0100_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.InhibitOsk']/*" />
        InhibitOsk = 0b0000_0000_0000_0000_0000_0000_1000_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.VerticalWriting']/*" />
        VerticalWriting = 0b0000_0000_0000_0000_0000_0001_0000_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.Emoji']/*" />
        Emoji = 0b0000_0000_0000_0000_0000_0010_0000_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.NoEmoji']/*" />
        NoEmoji = 0b0000_0000_0000_0000_0000_0100_0000_0000,
        /// <include file="InputHints.xmldoc" path="declaration/member[@name='InputHints.Private']/*" />
        Private = 0b0000_0000_0000_0000_0000_1000_0000_0000
    }

    /// <summary>
    /// Extension methods for <see cref="InputHints"/>.
    /// </summary>
    public static partial class InputHintsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_input_hints_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_input_hints_get_type();
    }
}