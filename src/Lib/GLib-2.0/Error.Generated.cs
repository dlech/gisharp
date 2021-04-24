// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Error.xmldoc" path="declaration/member[@name='Error']/*" />
    [GISharp.Runtime.GTypeAttribute("GError", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class Error : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Runtime.GType _GType = g_error_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="Error.xmldoc" path="declaration/member[@name='UnmanagedStruct.Domain']/*" />
            public readonly GISharp.Lib.GLib.Quark Domain;

            /// <include file="Error.xmldoc" path="declaration/member[@name='UnmanagedStruct.Code']/*" />
            public readonly int Code;

            /// <include file="Error.xmldoc" path="declaration/member[@name='UnmanagedStruct.Message']/*" />
            public readonly byte* Message;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Error(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_error_copy((UnmanagedStruct*)handle);
            }
        }

        /// <summary>
        /// Creates a new #GError; unlike g_error_new(), @message is
        /// not a printf()-style format string. Use this function if
        /// @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Error" type="GError*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Error.UnmanagedStruct* g_error_new_literal(
        /* <type name="Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark domain,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int code,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* message);
        static partial void CheckNewLiteralArgs(GISharp.Lib.GLib.Quark domain, int code, GISharp.Lib.GLib.UnownedUtf8 message);

        static GISharp.Lib.GLib.Error.UnmanagedStruct* NewLiteral(GISharp.Lib.GLib.Quark domain, int code, GISharp.Lib.GLib.UnownedUtf8 message)
        {
            CheckNewLiteralArgs(domain, code, message);
            var domain_ = (GISharp.Lib.GLib.Quark)domain;
            var code_ = (int)code;
            var message_ = (byte*)message.UnsafeHandle;
            var ret_ = g_error_new_literal(domain_,code_,message_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="Error.xmldoc" path="declaration/member[@name='Error.Error(GISharp.Lib.GLib.Quark,int,GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public Error(GISharp.Lib.GLib.Quark domain, int code, GISharp.Lib.GLib.UnownedUtf8 message) : this((System.IntPtr)NewLiteral(domain, code, message), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// If @dest is %NULL, free @src; otherwise, moves @src into *@dest.
        /// The error variable @dest points to must be %NULL.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @src must be non-%NULL.
        /// </para>
        /// <para>
        /// Note that @src is no longer valid after this call. If you want
        /// to keep using the same GError*, you need to set it to %NULL
        /// after calling this function on it.
        /// </para>
        /// </remarks>
        /// <param name="dest">
        /// error return location
        /// </param>
        /// <param name="src">
        /// error to move into the return location
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_propagate_error(
        /* <type name="Error" type="GError**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full nullable:1 optional:1 allow-none:1 */
        GISharp.Lib.GLib.Error.UnmanagedStruct** dest,
        /* <type name="Error" type="GError*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.Error.UnmanagedStruct* src);
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_error_get_type();

        /// <summary>
        /// Makes a copy of @error.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Error" type="GError*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Error.UnmanagedStruct* g_error_copy(
        /* <type name="Error" type="const GError*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Error.UnmanagedStruct* error);

        /// <summary>
        /// Frees a #GError and associated resources.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_error_free(
        /* <type name="Error" type="GError*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Error.UnmanagedStruct* error);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_error_free((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns %TRUE if @error matches @domain and @code, %FALSE
        /// otherwise. In particular, when @error is %NULL, %FALSE will
        /// be returned.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If @domain contains a `FAILED` (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should
        /// instead treat any not-explicitly-recognized error code as being
        /// equivalent to the `FAILED` code. This way, if the domain is
        /// extended in the future to provide a more specific error code for
        /// a certain case, your code will still work.
        /// </para>
        /// </remarks>
        /// <param name="error">
        /// a #GError
        /// </param>
        /// <param name="domain">
        /// an error domain
        /// </param>
        /// <param name="code">
        /// an error code
        /// </param>
        /// <returns>
        /// whether @error has @domain and @code
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_error_matches(
        /* <type name="Error" type="const GError*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Error.UnmanagedStruct* error,
        /* <type name="Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Quark domain,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int code);
        partial void CheckMatchesArgs(GISharp.Lib.GLib.Quark domain, int code);

        /// <include file="Error.xmldoc" path="declaration/member[@name='Error.Matches(GISharp.Lib.GLib.Quark,int)']/*" />
        public bool Matches(GISharp.Lib.GLib.Quark domain, int code)
        {
            CheckMatchesArgs(domain, code);
            var error_ = (GISharp.Lib.GLib.Error.UnmanagedStruct*)UnsafeHandle;
            var domain_ = (GISharp.Lib.GLib.Quark)domain;
            var code_ = (int)code;
            var ret_ = g_error_matches(error_,domain_,code_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}