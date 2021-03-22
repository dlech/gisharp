// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Writer function for log entries. A log entry is a collection of one or more
    /// #GLogFields, using the standard [field names from journal
    /// specification](https://www.freedesktop.org/software/systemd/man/systemd.journal-fields.html).
    /// See g_log_structured() for more information.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Writer functions must ignore fields which they do not recognise, unless they
    /// can write arbitrary binary output, as field values may be arbitrary binary.
    /// </para>
    /// <para>
    /// @log_level is guaranteed to be included in @fields as the `PRIORITY` field,
    /// but is provided separately for convenience of deciding whether or where to
    /// output the log entry.
    /// </para>
    /// <para>
    /// Writer functions should return %G_LOG_WRITER_HANDLED if they handled the log
    /// message successfully or if they deliberately ignored it. If there was an
    /// error handling the message (for example, if the writer function is meant to
    /// send messages to a remote logging server and there is a network error), it
    /// should return %G_LOG_WRITER_UNHANDLED. This allows writer functions to be
    /// chained and fall back to simpler handlers in case of failure.
    /// </para>
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.50")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="LogWriterOutput" type="GLogWriterOutput" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Lib.GLib.LogWriterOutput UnmanagedLogWriterFunc(
    /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.LogLevelFlags logLevel,
    /* <array length="2" zero-terminated="0" type="const GLogField*" is-pointer="1">
*   <type name="LogField" type="GLogField" />
* </array> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.LogField* fields,
    /* <type name="gsize" type="gsize" /> */
    /* transfer-ownership:none direction:in */
    nuint nFields,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:3 direction:in */
    System.IntPtr userData);

    /// <include file="LogWriterFunc.xmldoc" path="declaration/member[@name='LogWriterFunc']/*" />
    [GISharp.Runtime.SinceAttribute("2.50")]
    public delegate GISharp.Lib.GLib.LogWriterOutput LogWriterFunc(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields);

    /// <summary>
    /// Class for marshalling <see cref="LogWriterFunc"/> methods.
    /// </summary>
    public static unsafe class LogWriterFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="LogWriterFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.LogWriterFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GLib.LogLevelFlags, GISharp.Lib.GLib.LogField*, nuint, System.IntPtr, GISharp.Lib.GLib.LogWriterOutput> callback_, System.IntPtr userData_)
        {
            GISharp.Lib.GLib.LogWriterOutput managedCallback(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields)
            {
                fixed (GISharp.Lib.GLib.LogField* fieldsData_ = fields)
                {
                    var logLevel_ = (GISharp.Lib.GLib.LogLevelFlags)logLevel;
                    var fields_ = (GISharp.Lib.GLib.LogField*)fieldsData_;
                    var nFields_ = (nuint)fields.Length;
                    var ret_ = callback_(logLevel_,fields_,nFields_,userData_);
                    GISharp.Runtime.GMarshal.PopUnhandledException();
                    var ret = (GISharp.Lib.GLib.LogWriterOutput)ret_;
                    return ret;
                }
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Lib.GLib.LogWriterOutput Callback(GISharp.Lib.GLib.LogLevelFlags logLevel_, GISharp.Lib.GLib.LogField* fields_, nuint nFields_, System.IntPtr userData_)
        {
            try
            {
                var logLevel = (GISharp.Lib.GLib.LogLevelFlags)logLevel_;
                var fields = new System.ReadOnlySpan<GISharp.Lib.GLib.LogField>(fields_, (int)nFields_);
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((LogWriterFunc, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                var ret = userData.Invoke(logLevel, fields);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }

                var ret_ = (GISharp.Lib.GLib.LogWriterOutput)ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }

            return default(GISharp.Lib.GLib.LogWriterOutput);
        }
    }
}