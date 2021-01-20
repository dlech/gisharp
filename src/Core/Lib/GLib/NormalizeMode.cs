// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Defines how a Unicode string is transformed in a canonical
    /// form, standardizing such issues as whether a character with
    /// an accent is represented as a base character and combining
    /// accent or as a single precomposed character. Unicode strings
    /// should generally be normalized before comparing them.
    /// </summary>
    public enum NormalizeMode
    {
        /// <summary>
        /// standardize differences that do not affect the
        /// text content, such as the above-mentioned accent representation
        /// </summary>
        Default = 0,
        /// <summary>
        /// another name for <see cref="Default"/>
        /// </summary>
        NFD = 0,
        /// <summary>
        /// like <see cref="Default"/>, but with
        ///     composed forms rather than a maximally decomposed form
        /// </summary>
        DefaultCompose = 1,
        /// <summary>
        /// another name for <see cref="DefaultCompose"/>
        /// </summary>
        NFC = 1,
        /// <summary>
        /// beyond <see cref="Default"/> also standardize the
        /// "compatibility" characters in Unicode, such as SUPERSCRIPT THREE
        /// to the standard forms (in this case DIGIT THREE). Formatting
        /// information may be lost but for most text operations such
        /// characters should be considered the same
        /// </summary>
        All = 2,
        /// <summary>
        /// another name for <see cref="All"/>
        /// </summary>
        NFKD = 2,
        /// <summary>
        /// like <see cref="All"/>, but with composed
        /// forms rather than a maximally decomposed form
        /// </summary>
        AllCompose = 3,
        /// <summary>
        /// another name for <see cref="AllCompose"/>
        /// </summary>
        NFCK = 3
    }
}
