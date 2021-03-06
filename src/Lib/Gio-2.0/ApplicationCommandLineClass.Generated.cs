// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='ApplicationCommandLineClass']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public unsafe partial class ApplicationCommandLineClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            internal readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct ParentClass;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.PrintLiteral']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct*, byte*, void> PrintLiteral;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.PrinterrLiteral']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct*, byte*, void> PrinterrLiteral;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetStdin']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct*, GISharp.Lib.Gio.InputStream.UnmanagedStruct*> GetStdin;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding0']/*" />
            internal readonly System.IntPtr Padding0;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding1']/*" />
            internal readonly System.IntPtr Padding1;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding2']/*" />
            internal readonly System.IntPtr Padding2;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding3']/*" />
            internal readonly System.IntPtr Padding3;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding4']/*" />
            internal readonly System.IntPtr Padding4;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding5']/*" />
            internal readonly System.IntPtr Padding5;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding6']/*" />
            internal readonly System.IntPtr Padding6;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding7']/*" />
            internal readonly System.IntPtr Padding7;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding8']/*" />
            internal readonly System.IntPtr Padding8;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding9']/*" />
            internal readonly System.IntPtr Padding9;

            /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding10']/*" />
            internal readonly System.IntPtr Padding10;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static ApplicationCommandLineClass()
        {
            int printLiteralOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.PrintLiteral));
            RegisterVirtualMethod(printLiteralOffset, PrintLiteralMarshal.Create);
            int printerrLiteralOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.PrinterrLiteral));
            RegisterVirtualMethod(printerrLiteralOffset, PrinterrLiteralMarshal.Create);
            int getStdinOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetStdin));
            RegisterVirtualMethod(getStdinOffset, GetStdinMarshal.Create);
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='_PrintLiteral']/*" />
        public delegate void _PrintLiteral(GISharp.Runtime.UnownedUtf8 message);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedPrintLiteral(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* message);

        /// <summary>
        /// Class for marshalling <see cref="_PrintLiteral"/> methods.
        /// </summary>
        public static unsafe class PrintLiteralMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedPrintLiteral Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedPrintLiteral(GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline_, byte* message_)
                {
                    try
                    {
                        var cmdline = GISharp.Lib.Gio.ApplicationCommandLine.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>((System.IntPtr)cmdline_, GISharp.Runtime.Transfer.None)!;
                        var message = new GISharp.Runtime.UnownedUtf8(message_);
                        var doPrintLiteral = (_PrintLiteral)methodInfo.CreateDelegate(typeof(_PrintLiteral), cmdline);
                        doPrintLiteral(message);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedPrintLiteral;
            }
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='_PrinterrLiteral']/*" />
        public delegate void _PrinterrLiteral(GISharp.Runtime.UnownedUtf8 message);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedPrinterrLiteral(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* message);

        /// <summary>
        /// Class for marshalling <see cref="_PrinterrLiteral"/> methods.
        /// </summary>
        public static unsafe class PrinterrLiteralMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedPrinterrLiteral Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedPrinterrLiteral(GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline_, byte* message_)
                {
                    try
                    {
                        var cmdline = GISharp.Lib.Gio.ApplicationCommandLine.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>((System.IntPtr)cmdline_, GISharp.Runtime.Transfer.None)!;
                        var message = new GISharp.Runtime.UnownedUtf8(message_);
                        var doPrinterrLiteral = (_PrinterrLiteral)methodInfo.CreateDelegate(typeof(_PrinterrLiteral), cmdline);
                        doPrinterrLiteral(message);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedPrinterrLiteral;
            }
        }

        /// <include file="ApplicationCommandLineClass.xmldoc" path="declaration/member[@name='_GetStdin']/*" />
        public delegate GISharp.Lib.Gio.InputStream? _GetStdin();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.Gio.InputStream.UnmanagedStruct* UnmanagedGetStdin(
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline);

        /// <summary>
        /// Class for marshalling <see cref="_GetStdin"/> methods.
        /// </summary>
        public static unsafe class GetStdinMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetStdin Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.InputStream.UnmanagedStruct* unmanagedGetStdin(GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* cmdline_)
                {
                    try
                    {
                        var cmdline = GISharp.Lib.Gio.ApplicationCommandLine.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>((System.IntPtr)cmdline_, GISharp.Runtime.Transfer.None)!;
                        var doGetStdin = (_GetStdin)methodInfo.CreateDelegate(typeof(_GetStdin), cmdline);
                        var ret = doGetStdin();
                        var ret_ = (GISharp.Lib.Gio.InputStream.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Lib.Gio.InputStream.UnmanagedStruct*);
                }

                return unmanagedGetStdin;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ApplicationCommandLineClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}