// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='ApplicationCommandLineClass']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public class ApplicationCommandLineClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='ParentClass']/*" />
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='PrintLiteral']/*" />
            public System.IntPtr PrintLiteral;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='PrinterrLiteral']/*" />
            public System.IntPtr PrinterrLiteral;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='GetStdin']/*" />
            public System.IntPtr GetStdin;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='Padding']/*" />
            public System.IntPtr* Padding;
#pragma warning restore CS0649
        }

        static ApplicationCommandLineClass()
        {
            System.Int32 printLiteralOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.PrintLiteral));
            RegisterVirtualMethod(printLiteralOffset, PrintLiteralMarshal.Create);
            System.Int32 printerrLiteralOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.PrinterrLiteral));
            RegisterVirtualMethod(printerrLiteralOffset, PrinterrLiteralMarshal.Create);
            System.Int32 getStdinOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetStdin));
            RegisterVirtualMethod(getStdinOffset, GetStdinMarshal.Create);
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='PrintLiteral']/*" />
        public delegate void PrintLiteral(GISharp.Lib.GLib.UnownedUtf8 message);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedPrintLiteral(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr cmdline,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr message);

        /// <summary>
        /// Class for marshalling <see cref="PrintLiteral"/> methods.
        /// </summary>
        public static class PrintLiteralMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedPrintLiteral Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedPrintLiteral(System.IntPtr cmdline_, System.IntPtr message_)
                {
                    try
                    {
                        var cmdline = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>(cmdline_, GISharp.Runtime.Transfer.None)!;
                        var message = new GISharp.Lib.GLib.UnownedUtf8(message_, -1);
                        var doPrintLiteral = (PrintLiteral)methodInfo.CreateDelegate(typeof(PrintLiteral), cmdline);
                        doPrintLiteral(message);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedPrintLiteral;
            }
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='PrinterrLiteral']/*" />
        public delegate void PrinterrLiteral(GISharp.Lib.GLib.UnownedUtf8 message);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedPrinterrLiteral(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr cmdline,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr message);

        /// <summary>
        /// Class for marshalling <see cref="PrinterrLiteral"/> methods.
        /// </summary>
        public static class PrinterrLiteralMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedPrinterrLiteral Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedPrinterrLiteral(System.IntPtr cmdline_, System.IntPtr message_)
                {
                    try
                    {
                        var cmdline = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>(cmdline_, GISharp.Runtime.Transfer.None)!;
                        var message = new GISharp.Lib.GLib.UnownedUtf8(message_, -1);
                        var doPrinterrLiteral = (PrinterrLiteral)methodInfo.CreateDelegate(typeof(PrinterrLiteral), cmdline);
                        doPrinterrLiteral(message);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedPrinterrLiteral;
            }
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='GetStdin']/*" />
        public delegate GISharp.Lib.Gio.InputStream GetStdin();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetStdin(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr cmdline);

        /// <summary>
        /// Class for marshalling <see cref="GetStdin"/> methods.
        /// </summary>
        public static class GetStdinMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetStdin Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetStdin(System.IntPtr cmdline_)
                {
                    try
                    {
                        var cmdline = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>(cmdline_, GISharp.Runtime.Transfer.None)!;
                        var doGetStdin = (GetStdin)methodInfo.CreateDelegate(typeof(GetStdin), cmdline);
                        var ret = doGetStdin();
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedGetStdin;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public ApplicationCommandLineClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}