// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='ApplicationClass']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public unsafe class ApplicationClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            private readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct ParentClass;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Startup']/*" />
            public readonly System.IntPtr Startup;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Activate']/*" />
            public readonly System.IntPtr Activate;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Open']/*" />
            public readonly System.IntPtr Open;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CommandLine']/*" />
            public readonly System.IntPtr CommandLine;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.LocalCommandLine']/*" />
            public readonly System.IntPtr LocalCommandLine;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.BeforeEmit']/*" />
            public readonly System.IntPtr BeforeEmit;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.AfterEmit']/*" />
            public readonly System.IntPtr AfterEmit;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.AddPlatformData']/*" />
            public readonly System.IntPtr AddPlatformData;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QuitMainloop']/*" />
            public readonly System.IntPtr QuitMainloop;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.RunMainloop']/*" />
            public readonly System.IntPtr RunMainloop;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Shutdown']/*" />
            public readonly System.IntPtr Shutdown;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.DbusRegister']/*" />
            public readonly System.IntPtr DbusRegister;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.DbusUnregister']/*" />
            public readonly System.IntPtr DbusUnregister;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.HandleLocalOptions']/*" />
            public readonly System.IntPtr HandleLocalOptions;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.NameLost']/*" />
            public readonly System.IntPtr NameLost;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Padding']/*" />
            private fixed System.Int64 Padding[7];
#pragma warning restore CS0169, CS0649
        }

        static ApplicationClass()
        {
            System.Int32 startupOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Startup));
            RegisterVirtualMethod(startupOffset, StartupMarshal.Create);
            System.Int32 activateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateMarshal.Create);
            System.Int32 openOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Open));
            RegisterVirtualMethod(openOffset, OpenMarshal.Create);
            System.Int32 commandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CommandLine));
            RegisterVirtualMethod(commandLineOffset, CommandLineMarshal.Create);
            System.Int32 localCommandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.LocalCommandLine));
            RegisterVirtualMethod(localCommandLineOffset, TryLocalCommandLineMarshal.Create);
            System.Int32 beforeEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.BeforeEmit));
            RegisterVirtualMethod(beforeEmitOffset, BeforeEmitMarshal.Create);
            System.Int32 afterEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.AfterEmit));
            RegisterVirtualMethod(afterEmitOffset, AfterEmitMarshal.Create);
            System.Int32 addPlatformDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.AddPlatformData));
            RegisterVirtualMethod(addPlatformDataOffset, AddPlatformDataMarshal.Create);
            System.Int32 quitMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.QuitMainloop));
            RegisterVirtualMethod(quitMainloopOffset, QuitMainloopMarshal.Create);
            System.Int32 runMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.RunMainloop));
            RegisterVirtualMethod(runMainloopOffset, RunMainloopMarshal.Create);
            System.Int32 shutdownOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Shutdown));
            RegisterVirtualMethod(shutdownOffset, ShutdownMarshal.Create);
            System.Int32 handleLocalOptionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.HandleLocalOptions));
            RegisterVirtualMethod(handleLocalOptionsOffset, HandleLocalOptionsMarshal.Create);
            System.Int32 nameLostOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.NameLost));
            RegisterVirtualMethod(nameLostOffset, NameLostMarshal.Create);
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Startup']/*" />
        public delegate void Startup();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedStartup(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="Startup"/> methods.
        /// </summary>
        public static unsafe class StartupMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedStartup Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedStartup(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doStartup = (Startup)methodInfo.CreateDelegate(typeof(Startup), application); doStartup(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedStartup;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Activate']/*" />
        public delegate void Activate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="Activate"/> methods.
        /// </summary>
        public static unsafe class ActivateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivate(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doActivate = (Activate)methodInfo.CreateDelegate(typeof(Activate), application); doActivate(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedActivate;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Open']/*" />
        public delegate void Open(GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.Gio.IFile> files, GISharp.Lib.GLib.UnownedUtf8 hint);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedOpen(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <array length="2" zero-terminated="0" type="GFile**" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="File" type="GFile*" managed-name="File" is-pointer="1" />
* </array> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.File.UnmanagedStruct** files,
/* <type name="gint" type="gint" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 nFiles,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.Byte* hint);

        /// <summary>
        /// Class for marshalling <see cref="Open"/> methods.
        /// </summary>
        public static unsafe class OpenMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedOpen Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedOpen(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.Gio.File.UnmanagedStruct** files_, System.Int32 nFiles_, System.Byte* hint_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var files = new GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.Gio.IFile>(files_, (int)nFiles_); var hint = new GISharp.Lib.GLib.UnownedUtf8(hint_); var doOpen = (Open)methodInfo.CreateDelegate(typeof(Open), application); doOpen(files, hint); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedOpen;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='CommandLine']/*" />
        public delegate System.Int32 CommandLine(GISharp.Lib.Gio.ApplicationCommandLine commandLine);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate System.Int32 UnmanagedCommandLine(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* commandLine);

        /// <summary>
        /// Class for marshalling <see cref="CommandLine"/> methods.
        /// </summary>
        public static unsafe class CommandLineMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedCommandLine(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.Gio.ApplicationCommandLine.UnmanagedStruct* commandLine_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var commandLine = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>((System.IntPtr)commandLine_, GISharp.Runtime.Transfer.None)!; var doCommandLine = (CommandLine)methodInfo.CreateDelegate(typeof(CommandLine), application); var ret = doCommandLine(commandLine); var ret_ = (System.Int32)ret; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(System.Int32); }

                return unmanagedCommandLine;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='TryLocalCommandLine']/*" />
        public delegate System.Boolean TryLocalCommandLine(ref GISharp.Lib.GLib.Strv arguments, out System.Int32 exitStatus);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTryLocalCommandLine(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <array type="gchar***" zero-terminated="1" name="GLib.Strv" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" type="gchar**" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" />
* </array> */
/* direction:inout caller-allocates:0 transfer-ownership:full */
System.Byte*** arguments,
/* <type name="gint" type="int*" managed-name="System.Int32" /> */
/* direction:out caller-allocates:0 transfer-ownership:full */
System.Int32* exitStatus);

        /// <summary>
        /// Class for marshalling <see cref="TryLocalCommandLine"/> methods.
        /// </summary>
        public static unsafe class TryLocalCommandLineMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTryLocalCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTryLocalCommandLine(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, System.Byte*** arguments_, System.Int32* exitStatus_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var arguments = new GISharp.Lib.GLib.Strv((System.IntPtr)arguments_, -1, GISharp.Runtime.Transfer.Full); var doTryLocalCommandLine = (TryLocalCommandLine)methodInfo.CreateDelegate(typeof(TryLocalCommandLine), application); var ret = doTryLocalCommandLine(ref arguments,out var exitStatus); *arguments_ = (System.Byte**)arguments.Take(); *exitStatus_ = (System.Int32)exitStatus; var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedTryLocalCommandLine;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='BeforeEmit']/*" />
        public delegate void BeforeEmit(GISharp.Lib.GLib.Variant platformData);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedBeforeEmit(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* platformData);

        /// <summary>
        /// Class for marshalling <see cref="BeforeEmit"/> methods.
        /// </summary>
        public static unsafe class BeforeEmitMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedBeforeEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedBeforeEmit(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.GLib.Variant.UnmanagedStruct* platformData_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)platformData_, GISharp.Runtime.Transfer.None)!; var doBeforeEmit = (BeforeEmit)methodInfo.CreateDelegate(typeof(BeforeEmit), application); doBeforeEmit(platformData); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedBeforeEmit;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='AfterEmit']/*" />
        public delegate void AfterEmit(GISharp.Lib.GLib.Variant platformData);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedAfterEmit(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* platformData);

        /// <summary>
        /// Class for marshalling <see cref="AfterEmit"/> methods.
        /// </summary>
        public static unsafe class AfterEmitMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedAfterEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAfterEmit(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.GLib.Variant.UnmanagedStruct* platformData_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)platformData_, GISharp.Runtime.Transfer.None)!; var doAfterEmit = (AfterEmit)methodInfo.CreateDelegate(typeof(AfterEmit), application); doAfterEmit(platformData); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedAfterEmit;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='AddPlatformData']/*" />
        public delegate void AddPlatformData(GISharp.Lib.GLib.VariantBuilder builder);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedAddPlatformData(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <type name="GLib.VariantBuilder" type="GVariantBuilder*" managed-name="GISharp.Lib.GLib.VariantBuilder" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder);

        /// <summary>
        /// Class for marshalling <see cref="AddPlatformData"/> methods.
        /// </summary>
        public static unsafe class AddPlatformDataMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedAddPlatformData Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAddPlatformData(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var builder = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantBuilder>((System.IntPtr)builder_, GISharp.Runtime.Transfer.None)!; var doAddPlatformData = (AddPlatformData)methodInfo.CreateDelegate(typeof(AddPlatformData), application); doAddPlatformData(builder); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedAddPlatformData;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='QuitMainloop']/*" />
        public delegate void QuitMainloop();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedQuitMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="QuitMainloop"/> methods.
        /// </summary>
        public static unsafe class QuitMainloopMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedQuitMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedQuitMainloop(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doQuitMainloop = (QuitMainloop)methodInfo.CreateDelegate(typeof(QuitMainloop), application); doQuitMainloop(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedQuitMainloop;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='RunMainloop']/*" />
        public delegate void RunMainloop();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedRunMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="RunMainloop"/> methods.
        /// </summary>
        public static unsafe class RunMainloopMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedRunMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedRunMainloop(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doRunMainloop = (RunMainloop)methodInfo.CreateDelegate(typeof(RunMainloop), application); doRunMainloop(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedRunMainloop;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Shutdown']/*" />
        public delegate void Shutdown();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedShutdown(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="Shutdown"/> methods.
        /// </summary>
        public static unsafe class ShutdownMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedShutdown Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedShutdown(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doShutdown = (Shutdown)methodInfo.CreateDelegate(typeof(Shutdown), application); doShutdown(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedShutdown;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='HandleLocalOptions']/*" />
        public delegate System.Int32 HandleLocalOptions(GISharp.Lib.GLib.VariantDict options);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate System.Int32 UnmanagedHandleLocalOptions(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application,
/* <type name="GLib.VariantDict" type="GVariantDict*" managed-name="GISharp.Lib.GLib.VariantDict" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.VariantDict.UnmanagedStruct* options);

        /// <summary>
        /// Class for marshalling <see cref="HandleLocalOptions"/> methods.
        /// </summary>
        public static unsafe class HandleLocalOptionsMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedHandleLocalOptions Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedHandleLocalOptions(GISharp.Lib.Gio.Application.UnmanagedStruct* application_, GISharp.Lib.GLib.VariantDict.UnmanagedStruct* options_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var options = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantDict>((System.IntPtr)options_, GISharp.Runtime.Transfer.None)!; var doHandleLocalOptions = (HandleLocalOptions)methodInfo.CreateDelegate(typeof(HandleLocalOptions), application); var ret = doHandleLocalOptions(options); var ret_ = (System.Int32)ret; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(System.Int32); }

                return unmanagedHandleLocalOptions;
            }
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='NameLost']/*" />
        public delegate System.Boolean NameLost();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedNameLost(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Application.UnmanagedStruct* application);

        /// <summary>
        /// Class for marshalling <see cref="NameLost"/> methods.
        /// </summary>
        public static unsafe class NameLostMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedNameLost Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedNameLost(GISharp.Lib.Gio.Application.UnmanagedStruct* application_) { try { var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>((System.IntPtr)application_, GISharp.Runtime.Transfer.None)!; var doNameLost = (NameLost)methodInfo.CreateDelegate(typeof(NameLost), application); var ret = doNameLost(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedNameLost;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ApplicationClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}