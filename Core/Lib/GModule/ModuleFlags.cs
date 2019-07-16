using System;
namespace GISharp.Lib.GModule
{
    /// <summary>
    /// Flags passed to <see cref="M:Module.#ctor"/>.
    /// </summary>
    /// <remarks>
    /// Note that these flags are not supported on all platforms.
    /// </remarks>
    [Flags]
    public enum ModuleFlags
    {
        /// <summary>
        /// Specifies that symbols are only resolved when needed. The default
        /// action is to bind all symbols when the module is loaded.
        /// </summary>
        BindLazy = 0x1,

        /// <summary>
        /// Specifies that symbols in the module should not be added to the
        /// global name space. The default action on most platforms is to place
        /// symbols in the module in the global name space, which may cause
        /// conflicts with existing symbols.
        /// </summary>
        BindLocal = 0x2,

        /// <summary>
        /// Mask for all flags.
        /// </summary>
        BindMask = 0x3,
    }
}
