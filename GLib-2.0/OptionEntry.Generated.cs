// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A GOptionEntry struct defines a single option. To have an effect, they
    /// must be added to a <see cref="OptionGroup"/> with g_option_context_add_main_entries()
    /// or <see cref="OptionGroup.AddEntries"/>.
    /// </summary>
    public partial struct OptionEntry
    {
#pragma warning disable CS0649
        /// <summary>
        /// The long name of an option can be used to specify it
        ///     in a commandline as `--long_name`. Every option must have a
        ///     long name. To resolve conflicts if multiple option groups contain
        ///     the same long name, it is also possible to specify the option as
        ///     `--groupname-long_name`.
        /// </summary>
        public System.IntPtr LongName;

        /// <summary>
        /// If an option has a short name, it can be specified
        ///     `-short_name` in a commandline. <paramref name="shortName"/> must be  a printable
        ///     ASCII character different from '-', or zero if the option has no
        ///     short name.
        /// </summary>
        public System.SByte ShortName;

        /// <summary>
        /// Flags from <see cref="OptionFlags"/>
        /// </summary>
        public System.Int32 Flags;

        /// <summary>
        /// The type of the option, as a <see cref="OptionArg"/>
        /// </summary>
        public GISharp.Lib.GLib.OptionArg Arg;

        /// <summary>
        /// If the <paramref name="arg"/> type is <see cref="OptionArg.Callback"/>, then <paramref name="argData"/>
        ///     must point to a <see cref="OptionArgFunc"/> callback function, which will be
        ///     called to handle the extra argument. Otherwise, <paramref name="argData"/> is a
        ///     pointer to a location to store the value, the required type of
        ///     the location depends on the <paramref name="arg"/> type:
        ///     - <see cref="OptionArg.None"/>: %gboolean
        ///     - <see cref="OptionArg.String"/>: %gchar*
        ///     - <see cref="OptionArg.Int"/>: %gint
        ///     - <see cref="OptionArg.Filename"/>: %gchar*
        ///     - <see cref="OptionArg.StringArray"/>: %gchar**
        ///     - <see cref="OptionArg.FilenameArray"/>: %gchar**
        ///     - <see cref="OptionArg.Double"/>: %gdouble
        ///     If <paramref name="arg"/> type is <see cref="OptionArg.String"/> or <see cref="OptionArg.Filename"/>,
        ///     the location will contain a newly allocated string if the option
        ///     was given. That string needs to be freed by the callee using g_free().
        ///     Likewise if <paramref name="arg"/> type is <see cref="OptionArg.StringArray"/> or
        ///     <see cref="OptionArg.FilenameArray"/>, the data should be freed using g_strfreev().
        /// </summary>
        public System.IntPtr ArgData;

        /// <summary>
        /// the description for the option in `--help`
        ///     output. The <paramref name="description"/> is translated using the <paramref name="translateFunc"/>
        ///     of the group, see <see cref="OptionGroup.SetTranslationDomain"/>.
        /// </summary>
        public System.IntPtr Description;

        /// <summary>
        /// The placeholder to use for the extra argument parsed
        ///     by the option in `--help` output. The <paramref name="argDescription"/> is translated
        ///     using the <paramref name="translateFunc"/> of the group, see
        ///     <see cref="OptionGroup.SetTranslationDomain"/>.
        /// </summary>
        public System.IntPtr ArgDescription;
#pragma warning restore CS0649
    }
}