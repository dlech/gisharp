namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Flags which modify individual options.
    /// </summary>
    [System.FlagsAttribute]
    public enum OptionFlags
    {
        /// <summary>
        /// No flags.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.42")]
        None = 0,
        /// <summary>
        /// The option doesn't appear in `--help` output.
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// The option appears in the main section of the
        ///     `--help` output, even if it is defined in a group.
        /// </summary>
        InMain = 2,
        /// <summary>
        /// For options of the <see cref="OptionArg.None"/> kind, this
        ///     flag indicates that the sense of the option is reversed.
        /// </summary>
        Reverse = 4,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/> kind,
        ///     this flag indicates that the callback does not take any argument
        ///     (like a <see cref="OptionArg.None"/> option).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        NoArg = 8,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/>
        ///     kind, this flag indicates that the argument should be passed to the
        ///     callback in the GLib filename encoding rather than UTF-8.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        Filename = 16,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/>
        ///     kind, this flag indicates that the argument supply is optional.
        ///     If no argument is given then data of %GOptionParseFunc will be
        ///     set to NULL.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        OptionalArg = 32,
        /// <summary>
        /// This flag turns off the automatic conflict
        ///     resolution which prefixes long option names with `groupname-` if
        ///     there is a conflict. This option should only be used in situations
        ///     where aliasing is necessary to model some legacy commandline interface.
        ///     It is not safe to use this option, unless all option groups are under
        ///     your direct control.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        NoAlias = 64
    }
}