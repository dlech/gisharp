using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The <see cref="UnicodeScript"/> enumeration identifies different writing
    /// systems. The values correspond to the names as defined in the
    /// Unicode standard. The enumeration has been added in GLib 2.14,
    /// and is interchangeable with #PangoScript.
    /// </summary>
    /// <remarks>
    /// Note that new types may be added in the future. Applications
    /// should be ready to handle unknown values.
    /// </remarks>
    /// <seealso>
    /// <see href="http://www.unicode.org/reports/tr24/">Unicode Standard Annex #24: Script names</see>
    /// </seealso>
    public enum UnicodeScript
    {
        /// <summary>
        /// a value never returned from <see cref="Unichar.Script"/>
        /// </summary>
        InvalidCode = -1,

        /// <summary>
        /// a character used by multiple different scripts
        /// </summary>
        Common = 0,

        /// <summary>
        /// a mark glyph that takes its script from the
        /// base glyph to which it is attached
        /// </summary>
        Inherited = 1,

        /// <summary>
        /// Arabic
        /// </summary>
        Arabic = 2,

        /// <summary>
        /// Armenian
        /// </summary>
        Armenian = 3,

        /// <summary>
        /// Bengali
        /// </summary>
        Bengali = 4,

        /// <summary>
        /// Bopomofo
        /// </summary>
        Bopomofo = 5,

        /// <summary>
        /// Cherokee
        /// </summary>
        Cherokee = 6,

        /// <summary>
        /// Coptic
        /// </summary>
        Coptic = 7,

        /// <summary>
        /// Cyrillic
        /// </summary>
        Cyrillic = 8,

        /// <summary>
        /// Deseret
        /// </summary>
        Deseret = 9,

        /// <summary>
        /// Devanagari
        /// </summary>
        Devanagari = 10,

        /// <summary>
        /// Ethiopic
        /// </summary>
        Ethiopic = 11,

        /// <summary>
        /// Georgian
        /// </summary>
        Georgian = 12,

        /// <summary>
        /// Gothic
        /// </summary>
        Gothic = 13,

        /// <summary>
        /// Greek
        /// </summary>
        Greek = 14,

        /// <summary>
        /// Gujarati
        /// </summary>
        Gujarati = 15,

        /// <summary>
        /// Gurmukhi
        /// </summary>
        Gurmukhi = 16,

        /// <summary>
        /// Han
        /// </summary>
        Han = 17,

        /// <summary>
        /// Hangul
        /// </summary>
        Hangul = 18,

        /// <summary>
        /// Hebrew
        /// </summary>
        Hebrew = 19,

        /// <summary>
        /// Hiragana
        /// </summary>
        Hiragana = 20,

        /// <summary>
        /// Kannada
        /// </summary>
        Kannada = 21,

        /// <summary>
        /// Katakana
        /// </summary>
        Katakana = 22,

        /// <summary>
        /// Khmer
        /// </summary>
        Khmer = 23,

        /// <summary>
        /// Lao
        /// </summary>
        Lao = 24,

        /// <summary>
        /// Latin
        /// </summary>
        Latin = 25,

        /// <summary>
        /// Malayalam
        /// </summary>
        Malayalam = 26,

        /// <summary>
        /// Mongolian
        /// </summary>
        Mongolian = 27,

        /// <summary>
        /// Myanmar
        /// </summary>
        Myanmar = 28,

        /// <summary>
        /// Ogham
        /// </summary>
        Ogham = 29,

        /// <summary>
        /// Old Italic
        /// </summary>
        OldItalic = 30,

        /// <summary>
        /// Oriya
        /// </summary>
        Oriya = 31,

        /// <summary>
        /// Runic
        /// </summary>
        Runic = 32,

        /// <summary>
        /// Sinhala
        /// </summary>
        Sinhala = 33,

        /// <summary>
        /// Syriac
        /// </summary>
        Syriac = 34,

        /// <summary>
        /// Tamil
        /// </summary>
        Tamil = 35,

        /// <summary>
        /// Telugu
        /// </summary>
        Telugu = 36,

        /// <summary>
        /// Thaana
        /// </summary>
        Thaana = 37,

        /// <summary>
        /// Thai
        /// </summary>
        Thai = 38,

        /// <summary>
        /// Tibetan
        /// </summary>
        Tibetan = 39,

        /// <summary>
        /// Canadian Aboriginal
        /// </summary>
        CanadianAboriginal = 40,

        /// <summary>
        /// Yi
        /// </summary>
        Yi = 41,

        /// <summary>
        /// Tagalog
        /// </summary>
        Tagalog = 42,

        /// <summary>
        /// Hanunoo
        /// </summary>
        Hanunoo = 43,

        /// <summary>
        /// Buhid
        /// </summary>
        Buhid = 44,

        /// <summary>
        /// Tagbanwa
        /// </summary>
        Tagbanwa = 45,

        /// <summary>
        /// Braille
        /// </summary>
        Braille = 46,

        /// <summary>
        /// Cypriot
        /// </summary>
        Cypriot = 47,

        /// <summary>
        /// Limbu
        /// </summary>
        Limbu = 48,

        /// <summary>
        /// Osmanya
        /// </summary>
        Osmanya = 49,

        /// <summary>
        /// Shavian
        /// </summary>
        Shavian = 50,

        /// <summary>
        /// Linear B
        /// </summary>
        LinearB = 51,

        /// <summary>
        /// Tai Le
        /// </summary>
        TaiLe = 52,

        /// <summary>
        /// Ugaritic
        /// </summary>
        Ugaritic = 53,

        /// <summary>
        /// New Tai Lue
        /// </summary>
        NewTaiLue = 54,

        /// <summary>
        /// Buginese
        /// </summary>
        Buginese = 55,

        /// <summary>
        /// Glagolitic
        /// </summary>
        Glagolitic = 56,

        /// <summary>
        /// Tifinagh
        /// </summary>
        Tifinagh = 57,

        /// <summary>
        /// Syloti Nagri
        /// </summary>
        SylotiNagri = 58,

        /// <summary>
        /// Old Persian
        /// </summary>
        OldPersian = 59,

        /// <summary>
        /// Kharoshthi
        /// </summary>
        Kharoshthi = 60,

        /// <summary>
        /// an unassigned code point
        /// </summary>
        Unknown = 61,

        /// <summary>
        /// Balinese
        /// </summary>
        Balinese = 62,

        /// <summary>
        /// Cuneiform
        /// </summary>
        Cuneiform = 63,

        /// <summary>
        /// Phoenician
        /// </summary>
        Phoenician = 64,

        /// <summary>
        /// Phags-pa
        /// </summary>
        PhagsPa = 65,

        /// <summary>
        /// N'Ko
        /// </summary>
        Nko = 66,

        /// <summary>
        /// Kayah Li. Since 2.16.3
        /// </summary>
        KayahLi = 67,

        /// <summary>
        /// Lepcha. Since 2.16.3
        /// </summary>
        Lepcha = 68,

        /// <summary>
        /// Rejang. Since 2.16.3
        /// </summary>
        Rejang = 69,

        /// <summary>
        /// Sundanese. Since 2.16.3
        /// </summary>
        Sundanese = 70,

        /// <summary>
        /// Saurashtra. Since 2.16.3
        /// </summary>
        Saurashtra = 71,

        /// <summary>
        /// Cham. Since 2.16.3
        /// </summary>
        Cham = 72,

        /// <summary>
        /// Ol Chiki. Since 2.16.3
        /// </summary>
        OlChiki = 73,

        /// <summary>
        /// Vai. Since 2.16.3
        /// </summary>
        Vai = 74,

        /// <summary>
        /// Carian. Since 2.16.3
        /// </summary>
        Carian = 75,

        /// <summary>
        /// Lycian. Since 2.16.3
        /// </summary>
        Lycian = 76,

        /// <summary>
        /// Lydian. Since 2.16.3
        /// </summary>
        Lydian = 77,

        /// <summary>
        /// Avestan.
        /// </summary>
        [Since("2.26")]
        Avestan = 78,

        /// <summary>
        /// Bamum.
        /// </summary>
        [Since("2.26")]
        Bamum = 79,

        /// <summary>
        /// Egyptian Hieroglpyhs.
        /// </summary>
        [Since("2.26")]
        EgyptianHieroglyphs = 80,

        /// <summary>
        /// Imperial Aramaic.
        /// </summary>
        [Since("2.26")]
        ImperialAramaic = 81,

        /// <summary>
        /// Inscriptional Pahlavi.
        /// </summary>
        [Since("2.26")]
        InscriptionalPahlavi = 82,

        /// <summary>
        /// Inscriptional Parthian.
        /// </summary>
        [Since("2.26")]
        InscriptionalParthian = 83,

        /// <summary>
        /// Javanese.
        /// </summary>
        [Since("2.26")]
        Javanese = 84,

        /// <summary>
        /// Kaithi.
        /// </summary>
        [Since("2.26")]
        Kaithi = 85,

        /// <summary>
        /// Lisu.
        /// </summary>
        [Since("2.26")]
        Lisu = 86,

        /// <summary>
        /// Meetei Mayek.
        /// </summary>
        [Since("2.26")]
        MeeteiMayek = 87,

        /// <summary>
        /// Old South Arabian.
        /// </summary>
        [Since("2.26")]
        OldSouthArabian = 88,

        /// <summary>
        /// Old Turkic.
        /// </summary>
        [Since("2.28")]
        OldTurkic = 89,

        /// <summary>
        /// Samaritan.
        /// </summary>
        [Since("2.26")]
        Samaritan = 90,

        /// <summary>
        /// Tai Tham.
        /// </summary>
        [Since("2.26")]
        TaiTham = 91,

        /// <summary>
        /// Tai Viet.
        /// </summary>
        [Since("2.26")]
        TaiViet = 92,

        /// <summary>
        /// Batak.
        /// </summary>
        [Since("2.28")]
        Batak = 93,

        /// <summary>
        /// Brahmi.
        /// </summary>
        [Since("2.28")]
        Brahmi = 94,

        /// <summary>
        /// Mandaic.
        /// </summary>
        [Since("2.28")]
        Mandaic = 95,

        /// <summary>
        /// Chakma.
        /// </summary>
        [Since("2.32")]
        Chakma = 96,

        /// <summary>
        /// Meroitic Cursive.
        /// </summary>
        [Since("2.32")]
        MeroiticCursive = 97,

        /// <summary>
        /// Meroitic Hieroglyphs.
        /// </summary>
        [Since("2.32")]
        MeroiticHieroglyphs = 98,

        /// <summary>
        /// Miao.
        /// </summary>
        [Since("2.32")]
        Miao = 99,

        /// <summary>
        /// Sharada.
        /// </summary>
        [Since("2.32")]
        Sharada = 100,

        /// <summary>
        /// Sora Sompeng.
        /// </summary>
        [Since("2.32")]
        SoraSompeng = 101,

        /// <summary>
        /// Takri.
        /// </summary>
        [Since("2.32")]
        Takri = 102,

        /// <summary>
        /// Bassa.
        /// </summary>
        [Since("2.42")]
        BassaVah = 103,

        /// <summary>
        /// Caucasian Albanian.
        /// </summary>
        [Since("2.42")]
        CaucasianAlbanian = 104,

        /// <summary>
        /// Duployan.
        /// </summary>
        [Since("2.42")]
        Duployan = 105,

        /// <summary>
        /// Elbasan.
        /// </summary>
        [Since("2.42")]
        Elbasan = 106,

        /// <summary>
        /// Grantha.
        /// </summary>
        [Since("2.42")]
        Grantha = 107,

        /// <summary>
        /// Kjohki.
        /// </summary>
        [Since("2.42")]
        Khojki = 108,

        /// <summary>
        /// Khudawadi, Sindhi.
        /// </summary>
        [Since("2.42")]
        Khudawadi = 109,

        /// <summary>
        /// Linear A.
        /// </summary>
        [Since("2.42")]
        LinearA = 110,

        /// <summary>
        /// Mahajani.
        /// </summary>
        [Since("2.42")]
        Mahajani = 111,

        /// <summary>
        /// Manichaean.
        /// </summary>
        [Since("2.42")]
        Manichaean = 112,

        /// <summary>
        /// Mende Kikakui.
        /// </summary>
        [Since("2.42")]
        MendeKikakui = 113,

        /// <summary>
        /// Modi.
        /// </summary>
        [Since("2.42")]
        Modi = 114,

        /// <summary>
        /// Mro.
        /// </summary>
        [Since("2.42")]
        Mro = 115,

        /// <summary>
        /// Nabataean.
        /// </summary>
        [Since("2.42")]
        Nabataean = 116,

        /// <summary>
        /// Old North Arabian.
        /// </summary>
        [Since("2.42")]
        OldNorthArabian = 117,

        /// <summary>
        /// Old Permic.
        /// </summary>
        [Since("2.42")]
        OldPermic = 118,

        /// <summary>
        /// Pahawh Hmong.
        /// </summary>
        [Since("2.42")]
        PahawhHmong = 119,

        /// <summary>
        /// Palmyrene.
        /// </summary>
        [Since("2.42")]
        Palmyrene = 120,

        /// <summary>
        /// Pau Cin Hau.
        /// </summary>
        [Since("2.42")]
        PauCinHau = 121,

        /// <summary>
        /// Psalter Pahlavi.
        /// </summary>
        [Since("2.42")]
        PsalterPahlavi = 122,

        /// <summary>
        /// Siddham.
        /// </summary>
        [Since("2.42")]
        Siddham = 123,

        /// <summary>
        /// Tirhuta.
        /// </summary>
        [Since("2.42")]
        Tirhuta = 124,

        /// <summary>
        /// Warang Citi.
        /// </summary>
        [Since("2.42")]
        WarangCiti = 125,

        /// <summary>
        /// Ahom.
        /// </summary>
        [Since("2.48")]
        Ahom = 126,

        /// <summary>
        /// Anatolian Hieroglyphs.
        /// </summary>
        [Since("2.48")]
        AnatolianHieroglyphs = 127,

        /// <summary>
        /// Hatran.
        /// </summary>
        [Since("2.48")]
        Hatran = 128,

        /// <summary>
        /// Multani.
        /// </summary>
        [Since("2.48")]
        Multani = 129,

        /// <summary>
        /// Old Hungarian.
        /// </summary>
        [Since("2.48")]
        OldHungarian = 130,

        /// <summary>
        /// Signwriting.
        /// </summary>
        [Since("2.48")]
        Signwriting = 131
    }
}
