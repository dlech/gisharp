using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using System.Threading.Tasks;

// using GNetworkMonitor for testing since it is in gio, which is likely to
// be installed and it has methods, properties and a signal as well as having
// GInitable as a prerequisite.
using GISharp.Lib.GLib;

using Object = GISharp.Lib.GObject.Object;
using System.Reflection;

namespace GISharp.Test.Core
{
    [GType ("GInitable", IsProxyForUnmanagedType = true)]
    [GTypeStruct (typeof(InitableIface))]
    public interface IInitable : GInterface<Object>
    {
        [GVirtualMethod(typeof(InitableIface.UnmanagedInit))]
        void DoInit(IntPtr cancellable);
    }

    sealed class InitableIface : TypeInterface
    {
        static InitableIface() {
            var initOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.Init));
            RegisterVirtualMethod(initOffset, InitFactory.Create);
        }
        
        new struct Struct
        {
            #pragma warning disable CS0649
            public TypeInterface.Struct GIface;
            public UnmanagedInit Init;
            #pragma warning restore CS0649
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool UnmanagedInit(IntPtr initable, IntPtr cancellable, ref IntPtr error);
        
        public delegate void Init(IntPtr cancellable);

        public static class InitFactory
        {
            public static UnmanagedInit Create(MethodInfo methodInfo)
            {
                bool init(IntPtr initable_, IntPtr cancellable_, ref IntPtr error_)
                {
                    try {
                        var initable = (IInitable)Object.GetInstance(initable_, Transfer.None);
                        var doInit = (Init)methodInfo.CreateDelegate(typeof(Init), initable);
                        doInit(cancellable_);
                        return true;
                    }
                    catch (GErrorException ex) {
                        GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (Exception ex) {
                        // FIXME: we should convert managed exception to GError
                        ex.LogUnhandledException ();
                    }
                    return false;
                }

                return init;
            }
        }

        public InitableIface (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }

    public static class Initable
    {
        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initable_get_type ();

        static readonly GType _GType = g_initable_get_type();

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_initable_newv (GType objectType, uint nParameters, IntPtr parameters, IntPtr cancellable, out IntPtr errorPtr);

        public static Object New(GType objectType, params object[] parameters)
        {
            IntPtr errorPtr;
            var ret_ = g_initable_newv (objectType, 0, IntPtr.Zero, IntPtr.Zero, out errorPtr);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }
            var ret = Object.GetInstance(ret_, Transfer.Full);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_initable_init (IntPtr initable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool Init (this IInitable initable)
        {
            if (initable == null) {
                throw new ArgumentNullException (nameof(initable));
            }
            var instance = (Object)initable;
            var ret = g_initable_init (instance.Handle, IntPtr.Zero, out var errorPtr);
            GC.KeepAlive (instance);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }
            return ret;
        }
    }

    [GType ("GNetworkMonitor", IsProxyForUnmanagedType = true)]
    [GTypeStruct (typeof(NetworkMonitorInterface))]
    public interface INetworkMonitor : IInitable, GInterface<Object>
    {
        [GProperty("connectivity")]
        NetworkConnectivity Connectivity { get; }
        [GProperty("network-available")]
        bool NetworkAvailable { get; }
        [GProperty("network-metered")]
        bool NetworkMetered { get; }

        [GSignal("network-changed", When = EmissionStage.Last)]
        [Since("2.32")]
        event Action<bool> NetworkChanged;

        [GVirtualMethod(typeof(NetworkMonitorInterface.UnmanagedCanReach))]
        bool DoCanReach(IntPtr connectable, IntPtr cancellable);

        [GVirtualMethod(typeof(NetworkMonitorInterface.UnmanagedCanReachAsync))]
        void DoCanReachAsync(IntPtr connectable, IntPtr cancellable, Action<IntPtr> callback);

        [GVirtualMethod(typeof(NetworkMonitorInterface.UnmanagedCanReachAsyncFinish))]
        bool DoCanReachFinish(IntPtr result);

        [GVirtualMethod(typeof(NetworkMonitorInterface.UnmanagedNetworkChanged))]
        void DoNetworkChanged(bool available);
    }

    [GType ("GNetworkConnectivity", IsProxyForUnmanagedType = true)]
    public enum NetworkConnectivity
    {
        Local = 1,
        Limited = 2,
        Portal = 3,
        Full = 4,
    }

    public static class NetworkConnectivityExtensions
    {
        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_network_connectivity_get_type();

        static readonly GType _GType = g_network_connectivity_get_type();
    }

    sealed class NetworkMonitorInterface : TypeInterface
    {
        static NetworkMonitorInterface() {
            var networkChangedOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.NetworkChanged));
            TypeClass.RegisterVirtualMethod(networkChangedOffset, NetworkChangedFactory.Create);
            var canReachOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.CanReach));
            TypeClass.RegisterVirtualMethod(canReachOffset, CanReachFactory.Create);
            var canReachAsyncOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.CanReachAsync));
            TypeClass.RegisterVirtualMethod(canReachAsyncOffset, CanReachAsyncFactory.Create);
            var canReachAsyncFinishOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.CanReachAsyncFinish));
            TypeClass.RegisterVirtualMethod(canReachAsyncFinishOffset, CanReachAsyncFinishFactory.Create);
        }

        new struct Struct
        {
            #pragma warning disable CS0649
            public TypeInterface.Struct GIface;
            public UnmanagedNetworkChanged NetworkChanged;
            public UnmanagedCanReach CanReach;
            public UnmanagedCanReachAsync CanReachAsync;
            public UnmanagedCanReachAsyncFinish CanReachAsyncFinish;
            #pragma warning restore CS0649
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedNetworkChanged(IntPtr monitorPtr, bool available);

        public delegate void NetworkChanged(bool available);

        public static class NetworkChangedFactory
        {
            public static UnmanagedNetworkChanged Create(MethodInfo methodInfo)
            {
                void networkChanged(IntPtr monitor_, bool available)
                {
                    try {
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None);
                        var doNetworkChanged = (NetworkChanged)methodInfo.CreateDelegate(typeof(NetworkChanged), monitor);
                        doNetworkChanged(available);
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException ();
                    }
                }

                return networkChanged;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool UnmanagedCanReach(IntPtr monitor, IntPtr connectable, IntPtr cancellable, ref IntPtr error);

        public delegate bool CanReach(IntPtr connectable, IntPtr cancellable);

        public static class CanReachFactory
        {
            public static UnmanagedCanReach Create(MethodInfo methodInfo)
            {
                bool canReach(IntPtr monitor_, IntPtr connectable_, IntPtr cancellable_, ref IntPtr error_)
                {
                    try {
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None);
                        var doCanReach = (CanReach)methodInfo.CreateDelegate(typeof(CanReach), monitor);
                        var ret = doCanReach(connectable_, cancellable_);
                        return ret;
                    }
                    catch (GErrorException ex) {
                        GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (Exception ex) {
                        // FIXME: convert managed exception to GError
                        ex.LogUnhandledException ();
                    }
                    return false;
                }

                return canReach;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedCanReachAsync(IntPtr monitor, IntPtr connectable, IntPtr cancellable, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);

        public delegate void CanReachAsync(IntPtr connectable, IntPtr cancellable, Action<IntPtr> callback);


        public static class CanReachAsyncFactory
        {
            public static UnmanagedCanReachAsync Create(MethodInfo methodInfo)
            {
                void canReachAsync(IntPtr monitor_, IntPtr connectable_, IntPtr cancellable_, Action<IntPtr, IntPtr, IntPtr> callback_, IntPtr userData_)
                {
                    try {
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None);
                        void callback(IntPtr result_) {
                            callback_(monitor_, result_, userData_);
                        };
                        var doCanReachAsync = (CanReachAsync)methodInfo.CreateDelegate(typeof(CanReachAsync), monitor);
                        doCanReachAsync(connectable_, cancellable_, callback);
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException ();
                    }
                }

                return canReachAsync;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedCanReachAsyncFinish(IntPtr monitor, IntPtr result, ref IntPtr error);

        public delegate void CanReachAsyncFinish(IntPtr result);

        public static class CanReachAsyncFinishFactory
        {
            public static UnmanagedCanReachAsyncFinish Create(MethodInfo methodInfo)
            {
                void canReachAsyncFinish(IntPtr monitor_, IntPtr result_, ref IntPtr error_)
                {
                    try {
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None);
                        var doCanReachAsyncFinish = (CanReachAsyncFinish)methodInfo.CreateDelegate(typeof(CanReachAsyncFinish), monitor);
                        doCanReachAsyncFinish(result_);
                    } catch (GErrorException ex) {
                        GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (Exception ex) {
                        // FIXME: convert managed exception to GError
                        ex.LogUnhandledException ();
                    }
                }

                return canReachAsyncFinish;
            }
        }

        public NetworkMonitorInterface (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }

    public static class NetworkMonitor
    {
        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_network_monitor_get_type ();

        static readonly GType _GType = g_network_monitor_get_type();

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_available (IntPtr monitor);

        public static bool GetNetworkAvailable (this INetworkMonitor monitor)
        {
            if (monitor == null) {
                throw new ArgumentNullException (nameof(monitor));
            }
            var instance = (Object)monitor;
            var ret = g_network_monitor_get_network_available (instance.Handle);
            GC.KeepAlive (instance);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_get_network_metered (IntPtr monitor);

        public static bool GetNetworkMetered (this INetworkMonitor monitor)
        {
            if (monitor == null) {
                throw new ArgumentNullException (nameof(monitor));
            }
            var instance = (Object)monitor;
            var ret = g_network_monitor_get_network_metered (instance.Handle);
            GC.KeepAlive (instance);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach (IntPtr monitor, IntPtr connectable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool CanReach (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            if (monitor == null) {
                throw new ArgumentNullException (nameof(monitor));
            }
            var instance = (Object)monitor;
            var ret = g_network_monitor_can_reach (instance.Handle, connectable, cancellable, out var errorPtr);
            GC.KeepAlive (instance);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_network_monitor_can_reach_async (IntPtr monitor, IntPtr connectable, IntPtr cancellable, Action<IntPtr, IntPtr, IntPtr> callback, IntPtr userData);

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_network_monitor_can_reach_async_finish (IntPtr monitor, IntPtr result, out IntPtr errorPtr);

        public static Task<bool> CanReachAsync (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            if (monitor == null) {
                throw new ArgumentNullException (nameof(monitor));
            }
            var instance = (Object)monitor;
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
            g_network_monitor_can_reach_async (instance.Handle, connectable, cancellable, nativeCallback, (IntPtr)callbackGCHandle);
            GC.KeepAlive (instance);

            return completion.Task;
        }
    }
}
