namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The <see cref="OptionArg"/> enum values determine which type of extra argument the
    /// options expect to find. If an option expects an extra argument, it can
    /// be specified in several ways; with a short option: `-x arg`, with a long
    /// option: `--name arg` or combined in a single argument: `--name=arg`.
    /// </summary>
    public enum OptionArg
    {
        /// <summary>
        /// No extra argument. This is useful for simple flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// The option takes a string argument.
        /// </summary>
        String = 1,
        /// <summary>
        /// The option takes an integer argument.
        /// </summary>
        Int = 2,
        /// <summary>
        /// The option provides a callback (of type
        ///     <see cref="OptionArgFunc"/>) to parse the extra argument.
        /// </summary>
        Callback = 3,
        /// <summary>
        /// The option takes a filename as argument.
        /// </summary>
        Filename = 4,
        /// <summary>
        /// The option takes a string argument, multiple
        ///     uses of the option are collected into an array of strings.
        /// </summary>
        StringArray = 5,
        /// <summary>
        /// The option takes a filename as argument,
        ///     multiple uses of the option are collected into an array of strings.
        /// </summary>
        FilenameArray = 6,
        /// <summary>
        /// The option takes a double argument. The argument
        ///     can be formatted either for the user's locale or for the "C" locale.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        Double = 7,
        /// <summary>
        /// The option takes a 64-bit integer. Like
        ///     <see cref="OptionArg.Int"/> but for larger numbers. The number can be in
        ///     decimal base, or in hexadecimal (when prefixed with `0x`, for
        ///     example, `0xffffffff`).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        Int64 = 8
    }
}