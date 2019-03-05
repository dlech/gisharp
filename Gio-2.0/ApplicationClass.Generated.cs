// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Virtual function table for <see cref="Application"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public class ApplicationClass : GISharp.Lib.GObject.ObjectClass
    {
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public System.IntPtr Startup;
            public System.IntPtr Activate;
            public System.IntPtr Open;
            public System.IntPtr CommandLine;
            public System.IntPtr LocalCommandLine;
            public System.IntPtr BeforeEmit;
            public System.IntPtr AfterEmit;
            public System.IntPtr AddPlatformData;
            public System.IntPtr QuitMainloop;
            public System.IntPtr RunMainloop;
            public System.IntPtr Shutdown;
            public System.IntPtr DbusRegister;
            public System.IntPtr DbusUnregister;
            public System.IntPtr HandleLocalOptions;
            public System.IntPtr Padding;
#pragma warning restore CS0649
        }

        static ApplicationClass()
        {
            System.Int32 startupOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Startup));
            RegisterVirtualMethod(startupOffset, StartupFactory.Create);
            System.Int32 activateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateFactory.Create);
            System.Int32 openOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Open));
            RegisterVirtualMethod(openOffset, OpenFactory.Create);
            System.Int32 commandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CommandLine));
            RegisterVirtualMethod(commandLineOffset, CommandLineFactory.Create);
            System.Int32 localCommandLineOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.LocalCommandLine));
            RegisterVirtualMethod(localCommandLineOffset, TryLocalCommandLineFactory.Create);
            System.Int32 beforeEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.BeforeEmit));
            RegisterVirtualMethod(beforeEmitOffset, BeforeEmitFactory.Create);
            System.Int32 afterEmitOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.AfterEmit));
            RegisterVirtualMethod(afterEmitOffset, AfterEmitFactory.Create);
            System.Int32 addPlatformDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.AddPlatformData));
            RegisterVirtualMethod(addPlatformDataOffset, AddPlatformDataFactory.Create);
            System.Int32 quitMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QuitMainloop));
            RegisterVirtualMethod(quitMainloopOffset, QuitMainloopFactory.Create);
            System.Int32 runMainloopOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.RunMainloop));
            RegisterVirtualMethod(runMainloopOffset, RunMainloopFactory.Create);
            System.Int32 shutdownOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Shutdown));
            RegisterVirtualMethod(shutdownOffset, ShutdownFactory.Create);
            System.Int32 handleLocalOptionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.HandleLocalOptions));
            RegisterVirtualMethod(handleLocalOptionsOffset, HandleLocalOptionsFactory.Create);
        }

        public delegate void Startup();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedStartup(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Factory for creating <see cref="Startup"/> methods.
        /// </summary>
        public static class StartupFactory
        {
            public static unsafe UnmanagedStartup Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedStartup(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
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

        public delegate void Activate();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Factory for creating <see cref="Activate"/> methods.
        /// </summary>
        public static class ActivateFactory
        {
            public static unsafe UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivate(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
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

        public delegate void Open(GISharp.Runtime.IArray<GISharp.Lib.Gio.IFile> files, GISharp.Lib.GLib.UnownedUtf8 hint);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedOpen(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <array length="2" zero-terminated="0" type="GFile**" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="File" type="GFile*" managed-name="File" />
* </array> */
/* transfer-ownership:none direction:in */
System.IntPtr files,
/* <type name="gint" type="gint" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 nFiles,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr hint);

        /// <summary>
        /// Factory for creating <see cref="Open"/> methods.
        /// </summary>
        public static class OpenFactory
        {
            public static unsafe UnmanagedOpen Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedOpen(System.IntPtr application_, System.IntPtr files_, System.Int32 nFiles_, System.IntPtr hint_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var files = GISharp.Runtime.CPtrArray.GetInstance<GISharp.Lib.Gio.IFile>(files_, (int)nFiles_, GISharp.Runtime.Transfer.None);
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

        public delegate System.Int32 CommandLine(GISharp.Lib.Gio.ApplicationCommandLine commandLine);

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
        /// Factory for creating <see cref="CommandLine"/> methods.
        /// </summary>
        public static class CommandLineFactory
        {
            public static unsafe UnmanagedCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedCommandLine(System.IntPtr application_, System.IntPtr commandLine_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var commandLine = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.ApplicationCommandLine>(commandLine_, GISharp.Runtime.Transfer.None);
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

        public delegate System.Boolean TryLocalCommandLine(ref GISharp.Lib.GLib.Strv arguments, out System.Int32 exitStatus);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedTryLocalCommandLine(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application,
/* <array type="gchar***" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" type="gchar**" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
/* direction:inout caller-allocates:0 transfer-ownership:full */
System.IntPtr* arguments,
/* <type name="gint" type="int*" managed-name="System.Int32" is-pointer="1" /> */
/* direction:out caller-allocates:0 transfer-ownership:full */
System.Int32* exitStatus);

        /// <summary>
        /// Factory for creating <see cref="TryLocalCommandLine"/> methods.
        /// </summary>
        public static class TryLocalCommandLineFactory
        {
            public static unsafe UnmanagedTryLocalCommandLine Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean unmanagedTryLocalCommandLine(System.IntPtr application_, System.IntPtr* arguments_, System.Int32* exitStatus_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var arguments = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(*arguments_, GISharp.Runtime.Transfer.Full);
                        var doTryLocalCommandLine = (TryLocalCommandLine)methodInfo.CreateDelegate(typeof(TryLocalCommandLine), application);
                        var ret = doTryLocalCommandLine(ref arguments,out var exitStatus);
                        *arguments_ = arguments?.Take() ?? throw new System.ArgumentNullException(nameof(arguments));
                        *exitStatus_ = (System.Int32)exitStatus;
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return unmanagedTryLocalCommandLine;
            }
        }

        public delegate void BeforeEmit(GISharp.Lib.GLib.Variant platformData);

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
        /// Factory for creating <see cref="BeforeEmit"/> methods.
        /// </summary>
        public static class BeforeEmitFactory
        {
            public static unsafe UnmanagedBeforeEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedBeforeEmit(System.IntPtr application_, System.IntPtr platformData_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(platformData_, GISharp.Runtime.Transfer.None);
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

        public delegate void AfterEmit(GISharp.Lib.GLib.Variant platformData);

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
        /// Factory for creating <see cref="AfterEmit"/> methods.
        /// </summary>
        public static class AfterEmitFactory
        {
            public static unsafe UnmanagedAfterEmit Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAfterEmit(System.IntPtr application_, System.IntPtr platformData_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var platformData = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(platformData_, GISharp.Runtime.Transfer.None);
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

        public delegate void AddPlatformData(GISharp.Lib.GLib.VariantBuilder builder);

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
        /// Factory for creating <see cref="AddPlatformData"/> methods.
        /// </summary>
        public static class AddPlatformDataFactory
        {
            public static unsafe UnmanagedAddPlatformData Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAddPlatformData(System.IntPtr application_, System.IntPtr builder_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var builder = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantBuilder>(builder_, GISharp.Runtime.Transfer.None);
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

        public delegate void QuitMainloop();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedQuitMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Factory for creating <see cref="QuitMainloop"/> methods.
        /// </summary>
        public static class QuitMainloopFactory
        {
            public static unsafe UnmanagedQuitMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedQuitMainloop(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
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

        public delegate void RunMainloop();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedRunMainloop(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Factory for creating <see cref="RunMainloop"/> methods.
        /// </summary>
        public static class RunMainloopFactory
        {
            public static unsafe UnmanagedRunMainloop Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedRunMainloop(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
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

        public delegate void Shutdown();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedShutdown(
/* <type name="Application" type="GApplication*" managed-name="Application" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr application);

        /// <summary>
        /// Factory for creating <see cref="Shutdown"/> methods.
        /// </summary>
        public static class ShutdownFactory
        {
            public static unsafe UnmanagedShutdown Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedShutdown(System.IntPtr application_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
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

        public delegate System.Int32 HandleLocalOptions(GISharp.Lib.GLib.VariantDict options);

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
        /// Factory for creating <see cref="HandleLocalOptions"/> methods.
        /// </summary>
        public static class HandleLocalOptionsFactory
        {
            public static unsafe UnmanagedHandleLocalOptions Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int32 unmanagedHandleLocalOptions(System.IntPtr application_, System.IntPtr options_)
                {
                    try
                    {
                        var application = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Application>(application_, GISharp.Runtime.Transfer.None);
                        var options = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantDict>(options_, GISharp.Runtime.Transfer.None);
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

        public ApplicationClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}