// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='ApplicationClass']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public class ApplicationClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='ParentClass']/*" />
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Startup']/*" />
            public System.IntPtr Startup;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Activate']/*" />
            public System.IntPtr Activate;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Open']/*" />
            public System.IntPtr Open;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='CommandLine']/*" />
            public System.IntPtr CommandLine;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='LocalCommandLine']/*" />
            public System.IntPtr LocalCommandLine;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='BeforeEmit']/*" />
            public System.IntPtr BeforeEmit;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='AfterEmit']/*" />
            public System.IntPtr AfterEmit;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='AddPlatformData']/*" />
            public System.IntPtr AddPlatformData;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='QuitMainloop']/*" />
            public System.IntPtr QuitMainloop;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='RunMainloop']/*" />
            public System.IntPtr RunMainloop;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Shutdown']/*" />
            public System.IntPtr Shutdown;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='DbusRegister']/*" />
            public System.IntPtr DbusRegister;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='DbusUnregister']/*" />
            public System.IntPtr DbusUnregister;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='HandleLocalOptions']/*" />
            public System.IntPtr HandleLocalOptions;

            /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Padding']/*" />
            public System.IntPtr* Padding;
#pragma warning restore CS0649
        }

        static ApplicationClass()
        {
            System.Int32 startupOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Startup));
            RegisterVirtualMethod(startupOffset, StartupMarshal.Create);
            System.Int32 activateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateMarshal.Create);
            System.Int32 openOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Open));
            RegisterVirtualMethod(openOffset, OpenMarshal.Create);
            System.Int32 commandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CommandLine));
            RegisterVirtualMethod(commandLineOffset, CommandLineMarshal.Create);
            System.Int32 localCommandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.LocalCommandLine));
            RegisterVirtualMethod(localCommandLineOffset, TryLocalCommandLineMarshal.Create);
            System.Int32 beforeEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.BeforeEmit));
            RegisterVirtualMethod(beforeEmitOffset, BeforeEmitMarshal.Create);
            System.Int32 afterEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.AfterEmit));
            RegisterVirtualMethod(afterEmitOffset, AfterEmitMarshal.Create);
            System.Int32 addPlatformDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.AddPlatformData));
            RegisterVirtualMethod(addPlatformDataOffset, AddPlatformDataMarshal.Create);
            System.Int32 quitMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QuitMainloop));
            RegisterVirtualMethod(quitMainloopOffset, QuitMainloopMarshal.Create);
            System.Int32 runMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.RunMainloop));
            RegisterVirtualMethod(runMainloopOffset, RunMainloopMarshal.Create);
            System.Int32 shutdownOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Shutdown));
            RegisterVirtualMethod(shutdownOffset, ShutdownMarshal.Create);
            System.Int32 handleLocalOptionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.HandleLocalOptions));
            RegisterVirtualMethod(handleLocalOptionsOffset, HandleLocalOptionsMarshal.Create);
        }

        /// <include file="ApplicationClass.xmldoc" path="declaration/member[@name='Startup']/*" />
        public delegate void Startup();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedStartup(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Class for marshalling <see cref="Startup"/> methods.
        /// </summary>
        public static class StartupMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedStartup Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedStartup(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var doStartup = (Startup)methodInfo.CreateDelegate(typeof(Startup), application);
                        doStartup();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Class for marshalling <see cref="Activate"/> methods.
        /// </summary>
        public static class ActivateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivate(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var doActivate = (Activate)methodInfo.CreateDelegate(typeof(Activate), application);
                        doActivate();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedOpen(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <array length="2" zero-terminated="0" type="GFile**" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="File" type="GFile*" managed-name="File" />
* </array> */
/* transfer-ownership:none direction:in */
in System.IntPtr files,
/* <type name="gint" type="gint" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 nFiles,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr hint);

        /// <summary>
        /// Class for marshalling <see cref="Open"/> methods.
        /// </summary>
        public static class OpenMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedOpen Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedOpen(System.IntPtr application_, in System.IntPtr files_, System.Int32 nFiles_, System.IntPtr hint_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var files = new GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.Gio.IFile>((System.IntPtr)files_, (int)nFiles_, GISharp.Runtime.Transfer.None);
                        var hint = new GISharp.Lib.GLib.UnownedUtf8(hint_, -1);
                        var doOpen = (Open)methodInfo.CreateDelegate(typeof(Open), application);
                        doOpen(files, hint);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int32 UnmanagedCommandLine(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr commandLine);

        /// <summary>
        /// Class for marshalling <see cref="CommandLine"/> methods.
        /// </summary>
        public static class CommandLineMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedCommandLine(System.IntPtr application_, System.IntPtr commandLine_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var commandLine = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>(commandLine_, GISharp.Runtime.Transfer.None)!;
                        var doCommandLine = (CommandLine)methodInfo.CreateDelegate(typeof(CommandLine), application);
                        var ret = doCommandLine(commandLine);
                        var ret_ = (System.Int32)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Int32);
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTryLocalCommandLine(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <array type="gchar***" zero-terminated="1" name="GLib.Strv" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" type="gchar**" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
/* direction:inout caller-allocates:0 transfer-ownership:full */
ref System.IntPtr arguments,
/* <type name="gint" type="int*" managed-name="System.Int32" is-pointer="1" /> */
/* direction:out caller-allocates:0 transfer-ownership:full */
out System.Int32 exitStatus);

        /// <summary>
        /// Class for marshalling <see cref="TryLocalCommandLine"/> methods.
        /// </summary>
        public static class TryLocalCommandLineMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedTryLocalCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTryLocalCommandLine(System.IntPtr application_, ref System.IntPtr arguments_, out System.Int32 exitStatus_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var arguments = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(arguments_, GISharp.Runtime.Transfer.Full)!;
                        var doTryLocalCommandLine = (TryLocalCommandLine)methodInfo.CreateDelegate(typeof(TryLocalCommandLine), application);
                        var ret = doTryLocalCommandLine(ref arguments,out var exitStatus);
                        arguments_ = arguments.Take();
                        exitStatus_ = exitStatus;
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    exitStatus_ = default(System.Int32);
                    return default(GISharp.Runtime.Boolean);
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedBeforeEmit(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr platformData);

        /// <summary>
        /// Class for marshalling <see cref="BeforeEmit"/> methods.
        /// </summary>
        public static class BeforeEmitMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedBeforeEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedBeforeEmit(System.IntPtr application_, System.IntPtr platformData_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(platformData_, GISharp.Runtime.Transfer.None)!;
                        var doBeforeEmit = (BeforeEmit)methodInfo.CreateDelegate(typeof(BeforeEmit), application);
                        doBeforeEmit(platformData);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedAfterEmit(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr platformData);

        /// <summary>
        /// Class for marshalling <see cref="AfterEmit"/> methods.
        /// </summary>
        public static class AfterEmitMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedAfterEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAfterEmit(System.IntPtr application_, System.IntPtr platformData_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(platformData_, GISharp.Runtime.Transfer.None)!;
                        var doAfterEmit = (AfterEmit)methodInfo.CreateDelegate(typeof(AfterEmit), application);
                        doAfterEmit(platformData);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedAddPlatformData(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <type name="GLib.VariantBuilder" type="GVariantBuilder*" managed-name="GISharp.Lib.GLib.VariantBuilder" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr builder);

        /// <summary>
        /// Class for marshalling <see cref="AddPlatformData"/> methods.
        /// </summary>
        public static class AddPlatformDataMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedAddPlatformData Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAddPlatformData(System.IntPtr application_, System.IntPtr builder_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var builder = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantBuilder>(builder_, GISharp.Runtime.Transfer.None)!;
                        var doAddPlatformData = (AddPlatformData)methodInfo.CreateDelegate(typeof(AddPlatformData), application);
                        doAddPlatformData(builder);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedQuitMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Class for marshalling <see cref="QuitMainloop"/> methods.
        /// </summary>
        public static class QuitMainloopMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedQuitMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedQuitMainloop(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var doQuitMainloop = (QuitMainloop)methodInfo.CreateDelegate(typeof(QuitMainloop), application);
                        doQuitMainloop();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedRunMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Class for marshalling <see cref="RunMainloop"/> methods.
        /// </summary>
        public static class RunMainloopMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedRunMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedRunMainloop(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var doRunMainloop = (RunMainloop)methodInfo.CreateDelegate(typeof(RunMainloop), application);
                        doRunMainloop();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedShutdown(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Class for marshalling <see cref="Shutdown"/> methods.
        /// </summary>
        public static class ShutdownMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedShutdown Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedShutdown(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var doShutdown = (Shutdown)methodInfo.CreateDelegate(typeof(Shutdown), application);
                        doShutdown();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int32 UnmanagedHandleLocalOptions(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <type name="GLib.VariantDict" type="GVariantDict*" managed-name="GISharp.Lib.GLib.VariantDict" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr options);

        /// <summary>
        /// Class for marshalling <see cref="HandleLocalOptions"/> methods.
        /// </summary>
        public static class HandleLocalOptionsMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedHandleLocalOptions Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedHandleLocalOptions(System.IntPtr application_, System.IntPtr options_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None)!;
                        var options = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantDict>(options_, GISharp.Runtime.Transfer.None)!;
                        var doHandleLocalOptions = (HandleLocalOptions)methodInfo.CreateDelegate(typeof(HandleLocalOptions), application);
                        var ret = doHandleLocalOptions(options);
                        var ret_ = (System.Int32)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Int32);
                }

                return unmanagedHandleLocalOptions;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public ApplicationClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}