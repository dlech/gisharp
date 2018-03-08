// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System.Runtime.InteropServices;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Scope type.
    /// </summary>
    /// <remarks>
    /// Scope type of a <see cref="ArgInfo"/> representing callback, determines
    /// how the callback is invoked and is used to decided when the invoke
    /// structs can be freed.
    /// </remarks>
    public enum ScopeType
    {
        /// <summary>
        /// The argument is not of callback type.
        /// </summary>
        Invalid,

        /// <summary>
        /// The callback and associated user_data is only used during the call
        /// to this function.
        /// </summary>
        Call,

        /// <summary>
        /// The callback and associated user_data is only used until the callback
        /// is invoked, and the callback. is invoked always exactly once.
        /// </summary>
        Async,

        /// <summary>
        /// The callback and and associated user_data is used until the caller
        /// is notfied via the destroy_notify.
        /// </summary>
        Notified,
    }
}
