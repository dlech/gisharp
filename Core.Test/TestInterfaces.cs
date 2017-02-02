using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;
using System.Threading.Tasks;

// using GNetworkMonitor for testing since it is in gio, which is likely to
// be installed and it has methods, properties and a signal as well as having
// GInitable as a prerequsite.
using GISharp.GLib;

namespace GISharp.Core.Test
{
    [GType ("GInitable", IsWrappedNativeType = true)]
    [GTypeStruct (typeof(InitableIface))]
    public interface IInitable : IObject
    {
        bool Init (IntPtr cancellable);
    }

    sealed class InitableIface : TypeInterface
    {
        public abstract class SafeInitableIfaceHandle : SafeTypeInterfaceHandle
        {
            internal struct InitableIfaceStruct
            {
                #pragma warning disable CS0649
                TypeInterfaceStruct GIface;
                public NativeInit Init;
                #pragma warning restore CS0649

                public delegate bool NativeInit (IntPtr initablePtr, IntPtr cancellablePtr, ref IntPtr errorPtr);
            }
        }

        public override Type StructType {
            get {
                return typeof(SafeInitableIfaceHandle.InitableIfaceStruct);
            }
        }

        static void InterfaceInit (IntPtr gIface, IntPtr userData)
        {
            var offset = Marshal.OffsetOf<SafeInitableIfaceHandle.InitableIfaceStruct> (nameof (SafeInitableIfaceHandle.InitableIfaceStruct.Init));
            var initPtr = Marshal.GetFunctionPointerForDelegate<SafeInitableIfaceHandle.InitableIfaceStruct.NativeInit> (NativeInit);
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

        static bool NativeInit (IntPtr initablePtr, IntPtr cancellablePtr, ref IntPtr errorPtr)
        {
            var initable = (IInitable)GetInstance<GISharp.GObject.Object> (initablePtr, Transfer.None);
            try {
                var ret = initable.Init (cancellablePtr);
                return ret;
            } catch (GErrorException ex) {
                GMarshal.PropagateError (errorPtr, ex.Error);
            }
            return false;
        }

        public InitableIface (SafeInitableIfaceHandle handle) : base (handle)
        {
        }
    }

    public static class Initable
    {
        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initable_get_type ();

        static GType getGType ()
        {
            return g_initable_get_type ();
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_initable_newv (GType objectType, uint nParameters, IntPtr parameters, IntPtr cancellable, out IntPtr errorPtr);

        public static GISharp.GObject.Object New (GType objectType, params object[] parameters)
        {
            IntPtr errorPtr;
            var ret_ = g_initable_newv (objectType, 0, IntPtr.Zero, IntPtr.Zero, out errorPtr);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }
            var ret = Opaque.GetInstance<GISharp.GObject.Object> (ret_, Transfer.Full);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_initable_init (GISharp.GObject.Object.SafeObjectHandle intitable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool Init (this IInitable intitable)
        {
            IntPtr errorPtr;
            var ret = g_initable_init (intitable.Handle, IntPtr.Zero, out errorPtr);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }
            return ret;
        }
    }

    [GType ("GNetworkMonitor", IsWrappedNativeType = true)]
    [GTypeStruct (typeof(NetworkMonitorInterface))]
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
        public abstract class SafeNetworkMonitorInterfaceHandle : SafeTypeInterfaceHandle
        {
            internal struct NetworkMonitorInterfaceStruct
            {
#pragma warning disable CS0649
                TypeInterfaceStruct GIface;
                public NativeNetworkChanged NetworkChanged;
                public NativeCanReach CanReach;
                public NativeCanReachAsync CanReachAsync;
                public NativeCanReachAsyncFinish CanReachAsyncFinish;
#pragma warning restore CS0649

                [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
                public delegate void NativeNetworkChanged (IntPtr monitorPtr, bool availible);
                [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
                public delegate bool NativeCanReach (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, ref IntPtr errorPtr);
                [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
                public delegate void NativeCanReachAsync (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);
                [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
                public delegate void NativeCanReachAsyncFinish (IntPtr monitorPtr, IntPtr result, ref IntPtr errorPtr);
            }
        }

        public override Type StructType {
            get {
                return typeof(SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct);
            }
        }

        static void InterfaceInit (IntPtr gIface, IntPtr userData)
        {
            var networkChangedOffset = Marshal.OffsetOf<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct> (nameof (SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.NetworkChanged));
            var networkChangedPtr = Marshal.GetFunctionPointerForDelegate<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.NativeNetworkChanged> (NativeNetworkChanged);
            Marshal.WriteIntPtr (gIface, (int)networkChangedOffset, networkChangedPtr);
            var canReachOffset = Marshal.OffsetOf<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct> (nameof (SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.CanReach));
            var canReachPtr = Marshal.GetFunctionPointerForDelegate<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.NativeCanReach> (NativeCanReach);
            Marshal.WriteIntPtr (gIface, (int)canReachOffset, canReachPtr);
            var canReachAsyncOffset = Marshal.OffsetOf<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct> (nameof (SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.CanReachAsync));
            var canReachAsyncPtr = Marshal.GetFunctionPointerForDelegate<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.NativeCanReachAsync> (NativeCanReachAsync);
            Marshal.WriteIntPtr (gIface, (int)canReachAsyncOffset, canReachAsyncPtr);
            var canReachAsyncFinishOffset = Marshal.OffsetOf<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct> (nameof (SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.CanReachAsyncFinish));
            var canReachAsyncFinishPtr = Marshal.GetFunctionPointerForDelegate<SafeNetworkMonitorInterfaceHandle.NetworkMonitorInterfaceStruct.NativeCanReachAsyncFinish> (NativeCanReachAsyncFinish);
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

        static bool NativeCanReach (IntPtr monitorPtr, IntPtr connectablePtr, IntPtr cancellablePtr, ref IntPtr errorPtr)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            try {
                var ret = monitor.CanReach (connectablePtr, cancellablePtr);
                return ret;
            } catch (GErrorException ex) {
                GMarshal.PropagateError (errorPtr, ex.Error);
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

        static void NativeCanReachAsyncFinish (IntPtr monitorPtr, IntPtr result, ref IntPtr errorPtr)
        {
            var monitor = (INetworkMonitor)Opaque.GetInstance<GISharp.GObject.Object> (monitorPtr, Transfer.None);
            try {
                monitor.CanReachFinish (result);
            } catch (GErrorException ex) {
                GMarshal.PropagateError (errorPtr, ex.Error);
            }
        }

        public NetworkMonitorInterface (SafeNetworkMonitorInterfaceHandle handle) : base (handle)
        {
        }
    }

    public static class NetworkMonitor
    {
        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_network_monitor_get_type ();

        static GType getGType ()
        {
            return g_network_monitor_get_type ();
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_available (GISharp.GObject.Object.SafeObjectHandle monitor);

        public static bool GetNetworkAvailible (this INetworkMonitor monitor)
        {
            var ret = g_network_monitor_get_network_available (monitor.Handle);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_metered (GISharp.GObject.Object.SafeObjectHandle monitor);

        public static bool GetNetworkMetered (this INetworkMonitor monitor)
        {
            var ret = g_network_monitor_get_network_metered (monitor.Handle);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach (GISharp.GObject.Object.SafeObjectHandle monitor, IntPtr connectable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool CanReach (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            IntPtr errorPtr;
            var ret = g_network_monitor_can_reach (monitor.Handle, connectable, cancellable, out errorPtr);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_network_monitor_can_reach_async (GISharp.GObject.Object.SafeObjectHandle monitor, IntPtr connectable, IntPtr cancellable, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach_async_finish (IntPtr monitor, IntPtr result, out IntPtr errorPtr);

        public static Task<bool> CanReachAsync (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            var completion = new TaskCompletionSource<bool> ();
            Action<IntPtr, IntPtr, IntPtr> nativeCallback = (sourceObjectPtr, resultPtr, userDataPtr) => {
                IntPtr errorPtr;
                var ret = g_network_monitor_can_reach_async_finish (sourceObjectPtr, resultPtr, out errorPtr);
                if (errorPtr != IntPtr.Zero) {
                    var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                    completion.SetException (new GErrorException (error));
                } else {
                    completion.SetResult (ret);
                }
                GCHandle.FromIntPtr (userDataPtr).Free ();
            };
            var callbackGCHandle = GCHandle.Alloc (nativeCallback);
            g_network_monitor_can_reach_async (monitor.Handle, connectable, cancellable, nativeCallback, GCHandle.ToIntPtr (callbackGCHandle));

            return completion.Task;
        }
    }
}
