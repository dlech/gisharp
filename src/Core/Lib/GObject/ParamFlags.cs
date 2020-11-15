using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// Through the <see cref="ParamFlags"/> flag values, certain aspects of
    /// parameters can be configured.
    /// </summary>
    /// <seealso cref="StaticStrings"/>
    [Flags]
    public enum ParamFlags : uint
    {
        /// <summary>
        /// the parameter is readable
        /// </summary>
        Readable = 0x01,

        /// <summary>
        /// the parameter is writable
        /// </summary>
        Writable = 0x02,

        /// <summary>
        /// Alias for <c>Readable | Writable</c>
        /// </summary>
        Readwrite = Readable | Writable,

        /// <summary>
        /// The parameter will be set upon object construction
        /// </summary>
        Construct = 0x04,

        /// <summary>
        /// The parameter can only be set upon object construction
        /// </summary>
        ConstructOnly = 0x08,

        /// <summary>
        /// Upon parameter conversion (see g_param_value_convert())
        /// strict validation is not required
        /// </summary>
        LaxValidation = 0x10,

        /// <summary>
        /// the string used as name when constructing the
        /// parameter is guaranteed to remain valid and
        /// unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticName = 0x20,

        /// <summary>
        /// the string used as nick when constructing the
        /// parameter is guaranteed to remain valid and
        /// unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticNick = 0x40,

        /// <summary>
        /// The string used as blurb when constructing the
        /// parameter is guaranteed to remain valid and
        /// unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticBlurb = 0x80,

        /// <summary>
        /// Calls to <seealso cref="Object.SetProperty"/> for this
        /// property will not automatically result in a "notify" signal being
        /// emitted: the implementation must call <see cref="Object.Notify(GLib.UnownedUtf8)"/>
        /// themselves in case the property actually changes.
        /// </summary>
        [Since ("2.42")]
        ExplicitNotify = 0x40000000,

        /// <summary>
        /// The parameter is deprecated and will be removed
        /// in a future version. A warning will be generated if it is used
        /// while running with <c>G_ENABLE_DIAGNOSTIC=1</c>.
        /// </summary>
        [Since ("2.26")]
        Deprecated = 0x80000000,

        /// <summary>
        /// <see cref="ParamFlags"/> value alias for <c>StaticName | StaticNick
        /// | StaticBlurb</c>.
        /// </summary>
        [Since ("2.13")]
        StaticStrings = StaticName | StaticNick | StaticBlurb,
    }
}
