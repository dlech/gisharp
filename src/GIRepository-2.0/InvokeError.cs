// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// An error occuring while invoking a function via <see cref="FunctionInfo.Invoke"/>
    /// </summary>
    [GErrorDomain ("g-invoke-error-quark")]
    public enum InvokeError
    {
        /// <summary>
        /// Invocation failed, unknown error.
        /// </summary>
        Failed,

        /// <summary>
        /// The symbol couldn't be found in any of the
        /// libraries associated with the typelib of the function.
        /// </summary>
        SymbolNotFound,

        /// <summary>
        /// The arguments provided didn't match
        /// the expected arguments for the functions type signature.
        /// </summary>
        ArgumentMismatch,
    }

    public static class InvokeErrorDomain
    {
        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Quark g_invoke_error_quark();

        public static Quark Quark {
            get {
                var ret = g_invoke_error_quark();
                return ret;
            }
        }
    }
}
