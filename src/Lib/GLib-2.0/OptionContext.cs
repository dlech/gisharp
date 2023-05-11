// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class OptionContext
    {
        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// The @parameter_string can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the #GOptionContext, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the @arg_description of the corresponding #GOptionEntry in
        /// the usage summary.
        ///
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use g_option_context_set_summary().
        ///
        /// Note that the @parameter_string is translated using the
        /// function set with g_option_context_set_translate_func(), so
        /// it should normally be passed untranslated.
        /// </remarks>
        /// <param name="parameterString">
        /// a string which is displayed in
        /// the first line of `--help` output, after the usage summary
        /// `programname [OPTION...]`
        /// </param>
        public OptionContext(NullableUnownedUtf8 parameterString)
            : base((IntPtr)New(parameterString), Transfer.Full) { }

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        public OptionContext()
            : this(default) { }
    }
}
