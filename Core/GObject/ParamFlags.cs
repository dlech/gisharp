using System;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// Through the #GParamFlags flag values, certain aspects of parameters
    /// can be configured. See also #G_PARAM_STATIC_STRINGS.
    /// </summary>
    [Flags]
    public enum ParamFlags
    {
        /// <summary>
        /// the parameter is readable
        /// </summary>
        Readable = 1,

        /// <summary>
        /// the parameter is writable
        /// </summary>
        Writable = 2,

        /// <summary>
        /// alias for <see cref="Readable"/> | <see cref="Writable"/>
        /// </summary>
        Readwrite = 3,

        /// <summary>
        /// the parameter will be set upon object construction
        /// </summary>
        Construct = 4,

        /// <summary>
        /// the parameter can only be set upon object construction
        /// </summary>
        ConstructOnly = 8,

        /// <summary>
        /// upon parameter conversion (see g_param_value_convert())
        ///  strict validation is not required
        /// </summary>
        LaxValidation = 16,

        /// <summary>
        /// the string used as name when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticName = 32,

        ///// <summary>
        ///// internal
        ///// </summary>
        //Private = 32,
        /// <summary>
        /// the string used as nick when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticNick = 64,

        /// <summary>
        /// the string used as blurb when constructing the
        ///  parameter is guaranteed to remain valid and
        ///  unmodified for the lifetime of the parameter.
        /// </summary>
        [Since ("2.8")]
        StaticBlurb = 128,

        /// <summary>
        /// calls to g_object_set_property() for this
        ///   property will not automatically result in a "notify" signal being
        ///   emitted: the implementation must call g_object_notify() themselves
        ///   in case the property actually changes.
        /// </summary>
        [Since ("2.42")]
        ExplicitNotify = 1073741824,

        /// <summary>
        /// the parameter is deprecated and will be removed
        ///  in a future version. A warning will be generated if it is used
        ///  while running with G_ENABLE_DIAGNOSTIC=1.
        /// </summary>
        [Since ("2.26")]
        Deprecated = -2147483648,

        /// <summary>
        /// Mask containing the bits of #GParamSpec.flags which are reserved for GLib.
        /// </summary>
        ParamMask = 255,

        /// <summary>
        /// #GParamFlags value alias for %G_PARAM_STATIC_NAME | %G_PARAM_STATIC_NICK | %G_PARAM_STATIC_BLURB.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [Since ("2.13")]
        ParamStaticStrings = 0,

        /// <summary>
        /// Minimum shift count to be used for user defined flags, to be stored in
        /// #GParamSpec.flags. The maximum allowed is 10.
        /// </summary>
        ParamUserShift = 8
    }
}
