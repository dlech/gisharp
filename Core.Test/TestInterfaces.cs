﻿using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;
using System.Threading.Tasks;

// using GNetworkMonitor for testing since it is in gio, which is likely to
// be installed and it has methods, properties and a signal as well as having
// GInitable as a prerequsite.

namespace GISharp.Core.Test
{
    [GType ("GInitable", IsWrappedNativeType = true, GTypeStruct = typeof(InitableIface))]
    public interface IInitable
    {
        bool Init (IntPtr cancellable);
    }

    sealed class InitableIface : TypeInterface
    {
        struct InitableIfaceStruct
        {
            public TypeInterface.TypeInterfaceStruct GIface;
            public NativeInit Init;

            public delegate bool NativeInit (IntPtr initablePtr, IntPtr cancellablePtr, IntPtr errorPtr);
        }

        public override Type StructType {
            get {
                return typeof(InitableIfaceStruct);
            }
        }

        static void InterfaceInit (IntPtr gIface, IntPtr userData)
        {
            var offset = Marshal.OffsetOf<InitableIfaceStruct> (nameof (InitableIfaceStruct.Init));
            var initPtr = Marshal.GetFunctionPointerForDelegate<InitableIfaceStruct.NativeInit> (NativeInit);
            Marshal.WriteIntPtr (gIface, (int)offset, initPtr);
        }

        static void InterfaceFinalize (IntPtr gIface, IntPtr userData)
        {
        }

        public override InterfaceInfo CreateInterfaceInfo (Type instanceType)
        {
            var ret = new InterfaceInfo {
                InterfaceInit = InterfaceInit,
                InterfaceFinalize = InterfaceFinalize,
            };

            return ret;
        }

        static bool NativeInit (IntPtr initablePtr, IntPtr cancellablePtr, IntPtr errorPtr)
        {
            var initable = (IInitable)Opaque.GetInstance<GISharp.GObject.Object> (initablePtr, Transfer.None);
            try {
                var ret = initable.Init (cancellablePtr);
                return ret;
            } catch (GErrorException ex) {
                if (errorPtr != IntPtr.Zero) {
                    Marshal.WriteIntPtr (errorPtr, ex.Handle);
                }
            }
            return false;
        }

        public InitableIface (IntPtr handle, bool ownsRef) : base (handle, ownsRef)
        {
        }
    }

    public static class IInitableExtensions
    {
        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initable_get_type ();

        static GType getGType ()
        {
            return g_initable_get_type ();
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_initable_newv (GType objectType, uint nParameters, IntPtr parameters, IntPtr cancellable, IntPtr errorPtr);

        public static GISharp.GObject.Object New (GType objectType, params object[] parameters)
        {
            IntPtr errorPtr = MarshalG.Alloc0 (IntPtr.Size);
            try {
                var ret_ = g_initable_newv (objectType, 0, IntPtr.Zero, IntPtr.Zero, errorPtr);
                var error = Marshal.ReadIntPtr (errorPtr);
                if (error != IntPtr.Zero) {
                    throw new GErrorException (error);
                }
                var ret = Opaque.GetInstance<GISharp.GObject.Object> (ret_, Transfer.All);

                return ret;
            } finally {
                MarshalG.Free (errorPtr);
            }
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_initable_init (IntPtr intitable, IntPtr cancellable, IntPtr errorPtr);

        public static bool Init (this IInitable intitable)
        {
            IntPtr errorPtr = MarshalG.Alloc0 (IntPtr.Size);
            try {
                var ret = g_initable_init (((GISharp.GObject.Object)intitable).Handle, IntPtr.Zero, errorPtr);
                var error = Marshal.ReadIntPtr (errorPtr);
                if (error != IntPtr.Zero) {
                    throw new GErrorException (error);
                }
                return ret;
            } finally {
                MarshalG.Free (errorPtr);
            }
        }
    }

    [GType ("GNetworkMonitor", IsWrappedNativeType = true, GTypeStruct = typeof(NetworkMonitorInterface))]
    public interface INetworkMonitor : IInitable
    {
        bool CanReach (IntPtr connectable, IntPtr cancellable);
        void CanReachAsync (IntPtr connectable, IntPtr cancellable, Action<IntPtr> callback);
        bool CanReachFinish (IntPtr result);
        void OnNetworkChanged (bool availible);

        [Property ("connectivity")]
        int Connectivity { get; }
        [Property ("network-available")]
        bool NetworkAvailable { get; }
        [Property ("network-metered")]
        bool NetworkMetered { get; }

        [Signal ("network-changed")]
        event Action<bool> NetworkChanged;
    }

    sealed class NetworkMonitorInterface : TypeInterface
    {
        struct NetworkMonitorInterfaceStruct
        {
            public TypeInterface.TypeInterfaceStruct GIface;
            public NativeNetworkChanged NetworkChanged;
            public NativeCanReach CanReach;
            public NativeCanReachAsync CanReachAsync;
            public NativeCanReachAsyncFinish CanReachAsyncFinish;

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeNetworkChanged (IntPtr monitorPtr, bool availible);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate bool NativeCanReach (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, IntPtr errorPtr);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeCanReachAsync (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeCanReachAsyncFinish (IntPtr monitorPtr, IntPtr result, IntPtr errorPtr);
        }

        public override Type StructType {
            get {
                return typeof(NetworkMonitorInterfaceStruct);
            }
        }

        static void InterfaceInit (IntPtr gIface, IntPtr userData)
        {
            var networkChangedOffset = Marshal.OffsetOf<NetworkMonitorInterfaceStruct> (nameof (NetworkMonitorInterfaceStruct.NetworkChanged));
            var networkChangedPtr = Marshal.GetFunctionPointerForDelegate<NetworkMonitorInterfaceStruct.NativeNetworkChanged> (NativeNetworkChanged);
            Marshal.WriteIntPtr (gIface, (int)networkChangedOffset, networkChangedPtr);
            var canReachOffset = Marshal.OffsetOf<NetworkMonitorInterfaceStruct> (nameof (NetworkMonitorInterfaceStruct.CanReach));
            var canReachPtr = Marshal.GetFunctionPointerForDelegate<NetworkMonitorInterfaceStruct.NativeCanReach> (NativeCanReach);
            Marshal.WriteIntPtr (gIface, (int)canReachOffset, canReachPtr);
            var canReachAsyncOffset = Marshal.OffsetOf<NetworkMonitorInterfaceStruct> (nameof (NetworkMonitorInterfaceStruct.CanReachAsync));
            var canReachAsyncPtr = Marshal.GetFunctionPointerForDelegate<NetworkMonitorInterfaceStruct.NativeCanReachAsync> (NativeCanReachAsync);
            Marshal.WriteIntPtr (gIface, (int)canReachAsyncOffset, canReachAsyncPtr);
            var canReachAsyncFinishOffset = Marshal.OffsetOf<NetworkMonitorInterfaceStruct> (nameof (NetworkMonitorInterfaceStruct.CanReachAsyncFinish));
            var canReachAsyncFinishPtr = Marshal.GetFunctionPointerForDelegate<NetworkMonitorInterfaceStruct.NativeCanReachAsyncFinish> (NativeCanReachAsyncFinish);
            Marshal.WriteIntPtr (gIface, (int)canReachAsyncFinishOffset, canReachAsyncFinishPtr);
        }

        static void InterfaceFinalize (IntPtr gIface, IntPtr userData)
        {
        }

        public override InterfaceInfo CreateInterfaceInfo (Type instanceType)
        {
            var ret = new InterfaceInfo {
                InterfaceInit = InterfaceInit,
                InterfaceFinalize = InterfaceFinalize,
            };

            return ret;
        }

        static void NativeNetworkChanged (IntPtr monitorPtr, bool availible)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            monitor.OnNetworkChanged (availible);
        }

        static bool NativeCanReach (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, IntPtr errorPtr)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            try {
                var ret = monitor.CanReach (connectablePtr, cancellablePtr);
                return ret;
            } catch (GErrorException ex) {
                if (errorPtr != IntPtr.Zero) {
                    Marshal.WriteIntPtr (errorPtr, ex.Handle);
                }
            }
            return false;
        }

        static void NativeCanReachAsync (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            Action<IntPtr> managedCallback = (result) => {
                callback (monitorPtr, result, userData);
            };
            monitor.CanReachAsync (connectablePtr, cancellablePtr, managedCallback);
        }

        static void NativeCanReachAsyncFinish (IntPtr monitorPtr, IntPtr result, IntPtr errorPtr)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            try {
                monitor.CanReachFinish (result);
            } catch (GErrorException ex) {
                if (errorPtr != IntPtr.Zero) {
                    Marshal.WriteIntPtr (errorPtr, ex.Handle);
                }
            }
        }

        public NetworkMonitorInterface (IntPtr handle, bool ownsRef)
            : base (handle, ownsRef)
        {
        }
    }

    public static class INetworkMonitorExtensions
    {
        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_network_monitor_get_type ();

        static GType getGType ()
        {
            return g_network_monitor_get_type ();
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_available (IntPtr monitor);

        public static bool GetNetworkAvailible (this INetworkMonitor monitor)
        {
            var ret = g_network_monitor_get_network_available (((GISharp.GObject.Object)monitor).Handle);

            return ret;
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_metered (IntPtr monitor);

        public static bool GetNetworkMetered (this INetworkMonitor monitor)
        {
            var ret = g_network_monitor_get_network_metered (((GISharp.GObject.Object)monitor).Handle);

            return ret;
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach (IntPtr monitor, IntPtr connectable, IntPtr cancellable, IntPtr errorPtr);

        public static bool CanReach (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            IntPtr errorPtr = MarshalG.Alloc0 (IntPtr.Size);
            try {
                var ret = g_network_monitor_can_reach (((GISharp.GObject.Object)monitor).Handle, connectable, cancellable, errorPtr);
                var error = Marshal.ReadIntPtr (errorPtr);
                if (error != IntPtr.Zero) {
                    throw new GErrorException (error);
                }

                return ret;
            } finally {
                MarshalG.Free (errorPtr);
            }
        }

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_network_monitor_can_reach_async (IntPtr monitor, IntPtr connectable, IntPtr cancellable, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);

        [DllImport ("gio-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach_async_finish (IntPtr monitor, IntPtr result, IntPtr errorPtr);

        public static Task<bool> CanReachAsync (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            var completion = new TaskCompletionSource<bool> ();
            Action<IntPtr, IntPtr, IntPtr> nativeCallback = (sourceObjectPtr, resultPtr, userDataPtr) => {
                IntPtr errorPtr = MarshalG.Alloc0 (IntPtr.Size);
                var ret = g_network_monitor_can_reach_async_finish (sourceObjectPtr, resultPtr, errorPtr);
                var error = Marshal.ReadIntPtr (errorPtr);
                if (error != IntPtr.Zero) {
                    completion.SetException (new GErrorException (error));
                } else {
                    completion.SetResult (ret);
                }
                MarshalG.Free (errorPtr);
                GCHandle.FromIntPtr (userDataPtr).Free ();
            };
            var callbackGCHandle = GCHandle.Alloc (nativeCallback);
            g_network_monitor_can_reach_async (((GISharp.GObject.Object)monitor).Handle, connectable, cancellable, nativeCallback, GCHandle.ToIntPtr (callbackGCHandle));

            return completion.Task;
        }
    }
}
