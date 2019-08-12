using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// using GNetworkMonitor for testing since it is in gio, which is likely to
// be installed and it has methods, properties and a signal as well as having
// GInitable as a prerequisite.
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

using Object = GISharp.Lib.GObject.Object;
using Boolean = GISharp.Runtime.Boolean;

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
            public IntPtr Init;
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
                        var initable = (IInitable)Object.GetInstance(initable_, Transfer.None)!;
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

        [EditorBrowsable(EditorBrowsableState.Never)]
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
            var ret = Object.GetInstance(ret_, Transfer.Full)!;

            return ret;
        }

        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_initable_init(IntPtr initable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool Init (this IInitable initable)
        {
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
        Task<bool> DoCanReachAsync(IntPtr connectable, IntPtr cancellable);

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
            public IntPtr NetworkChanged;
            public IntPtr CanReach;
            public IntPtr CanReachAsync;
            public IntPtr CanReachAsyncFinish;
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
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None)!;
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
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None)!;
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

        public delegate Task<bool> CanReachAsync(IntPtr connectable, IntPtr cancellable);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedCanReachAsync(IntPtr monitor, IntPtr connectable, IntPtr cancellable, UnmanagedAsyncReadyCallback callback, IntPtr userData);

        public static class CanReachAsyncFactory
        {
            public static UnmanagedCanReachAsync Create(MethodInfo methodInfo)
            {
                void canReachAsync(IntPtr monitor_, IntPtr connectable_, IntPtr cancellable_, UnmanagedAsyncReadyCallback callback_, IntPtr userData_)
                {
                    try {
                        var task_ = GTask.g_task_new(monitor_, cancellable_, callback_, userData_);
                        var monitor = Object.GetInstance(monitor_, Transfer.None);
                        var doCanReachAsync = (CanReachAsync)methodInfo.CreateDelegate(typeof(CanReachAsync), monitor);
                        var task = doCanReachAsync(connectable_, cancellable_);
                        task.ContinueWith(x => {
                            GTask.g_task_return_boolean(task_, x.Result);
                        });
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException ();
                    }
                }

                return canReachAsync;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool UnmanagedCanReachAsyncFinish(IntPtr monitor, IntPtr result, ref IntPtr error);

        public static class CanReachAsyncFinishFactory
        {
            public static UnmanagedCanReachAsyncFinish Create(MethodInfo methodInfo)
            {
                bool canReachAsyncFinish(IntPtr monitor_, IntPtr result_, ref IntPtr error_)
                {
                    try {
                        var monitor = (INetworkMonitor)Object.GetInstance(monitor_, Transfer.None)!;
                        var result = Object.GetInstance<GTask>(result_, Transfer.None)!;
                        return result.PropagateBoolean();
                    } catch (GErrorException ex) {
                        GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (Exception ex) {
                        // FIXME: convert managed exception to GError
                        ex.LogUnhandledException ();
                    }

                    return default(bool);
                }

                return canReachAsyncFinish;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        static extern Boolean g_network_monitor_get_network_available (IntPtr monitor);

        public static bool GetNetworkAvailable (this INetworkMonitor monitor)
        {
            var instance = (Object)monitor;
            var ret = g_network_monitor_get_network_available (instance.Handle);
            GC.KeepAlive (instance);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_network_monitor_get_network_metered (IntPtr monitor);

        public static bool GetNetworkMetered (this INetworkMonitor monitor)
        {
            var instance = (Object)monitor;
            var ret = g_network_monitor_get_network_metered (instance.Handle);
            GC.KeepAlive (instance);

            return ret;
        }

        [DllImport ("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_network_monitor_can_reach (IntPtr monitor, IntPtr connectable, IntPtr cancellable, out IntPtr errorPtr);

        public static bool CanReach (this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            var instance = (Object)monitor;
            var ret = g_network_monitor_can_reach (instance.Handle, connectable, cancellable, out var errorPtr);
            GC.KeepAlive (instance);
            if (errorPtr != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error> (errorPtr, Transfer.Full);
                throw new GErrorException (error);
            }

            return ret;
        }

        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_network_monitor_can_reach_async(IntPtr monitor, IntPtr connectable, IntPtr cancellable, UnmanagedAsyncReadyCallback callback, IntPtr userData);

        public static Task<bool> CanReachAsync(this INetworkMonitor monitor, IntPtr connectable, IntPtr cancellable = default(IntPtr))
        {
            var completion = new TaskCompletionSource<bool>();
            var this_ = monitor.Handle;
            var callback_ = CanReachAsyncFinishDelegate;
            var userData_ = (IntPtr)GCHandle.Alloc(completion);
            g_network_monitor_can_reach_async(this_, connectable, cancellable, callback_, userData_);

            return completion.Task;
        }

        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_network_monitor_can_reach_finish(IntPtr monitor, IntPtr result, ref IntPtr errorPtr);

        static void CanReachAsyncFinish(IntPtr sourceObject_, IntPtr result_, IntPtr userData_)
        {
            try {
                var userData = (GCHandle)userData_;
                var completion = (TaskCompletionSource<bool>)userData.Target!;
                userData.Free();
    
                var error_ = IntPtr.Zero;
                var ret = g_network_monitor_can_reach_finish(sourceObject_, result_, ref error_);
                if (error_ != IntPtr.Zero) {
                    var error = Opaque.GetInstance<Error>(error_, Transfer.Full);
                    completion.SetException(new GErrorException(error));
                } else {
                    completion.SetResult(ret);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static readonly UnmanagedAsyncReadyCallback CanReachAsyncFinishDelegate = CanReachAsyncFinish;
    }

    [GType("GAsyncResult", IsProxyForUnmanagedType = true)]
    [GTypeStruct(typeof(AsyncResultIface))]
    interface IAsyncResult : GInterface<Object>
    {
        [GVirtualMethod(typeof(AsyncResultIface.UnmanagedGetUserData))]
        IntPtr GetUserData();

        [GVirtualMethod(typeof(AsyncResultIface.UnmanagedGetSourceObject))]
        Object GetSourceObject();
        
        [GVirtualMethod(typeof(AsyncResultIface.UnmanagedIsTagged))]
        IntPtr IsTagged(IntPtr sourceTag);
    }

    static class AsyncResult
    {
        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_async_result_get_type();

        static GType _GType = g_async_result_get_type();
    }

    delegate void AsyncReadyCallback(Object sourceObject, IAsyncResult res);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void UnmanagedAsyncReadyCallback(IntPtr sourceObject, IntPtr res, IntPtr userData);

    static class AsyncReadyCallbackFactory
    {
        public static (UnmanagedAsyncReadyCallback callback, IntPtr userData) Create(AsyncReadyCallback callback)
        {
            void unmanagedCallback(IntPtr sourceObject_, IntPtr res_, IntPtr userData_)
            {
                try {
                    GCHandle.FromIntPtr(userData_).Free();
                    var sourceObject = Object.GetInstance(sourceObject_, Transfer.None)!;
                    var res = (IAsyncResult)Object.GetInstance(res_, Transfer.None)!;
                    callback(sourceObject, res);
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                }
            }

            var unmanagedCallback_ = (UnmanagedAsyncReadyCallback)unmanagedCallback;

            var userData = GCHandle.Alloc(unmanagedCallback_);

            return (unmanagedCallback, (IntPtr)userData);
        }
    }

    sealed class AsyncResultIface : TypeInterface
    {
        new struct Struct
        {
            #pragma warning disable CS0649
            #pragma warning disable CS0169
            TypeInterface.Struct gIface;
            #pragma warning restore CS0169
            public IntPtr GetUserData;
            public IntPtr GetSourceObject;
            public IntPtr IsTagged;
            #pragma warning restore CS0649
        }

        static AsyncResultIface()
        {
            var getUserDataOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.GetUserData));
            RegisterVirtualMethod(getUserDataOffset, GetUserDataFactory.Create);
            var getSourceObjectOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.GetSourceObject));
            RegisterVirtualMethod(getSourceObjectOffset, GetSourceObjectFactory.Create);
            var isTaggedOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.IsTagged));
            RegisterVirtualMethod(isTaggedOffset, IsTaggedFactory.Create);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AsyncResultIface(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public delegate IntPtr GetUserData();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr UnmanagedGetUserData(IntPtr res);

        public static class GetUserDataFactory
        {
            public static UnmanagedGetUserData Create(MethodInfo methodInfo)
            {
                IntPtr getUserData(IntPtr res_)
                {
                    try {
                        var res = Object.GetInstance(res_, Transfer.None);
                        var doGetUserData = (GetUserData)methodInfo.CreateDelegate(typeof(GetUserData), res);
                        var ret = doGetUserData();
                        return ret;
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException();
                    }
                    return default(IntPtr);
                }

                return getUserData;
            }
        }

        public delegate Object GetSourceObject();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr UnmanagedGetSourceObject(IntPtr res);

        public static class GetSourceObjectFactory
        {
            public static UnmanagedGetSourceObject Create(MethodInfo methodInfo)
            {
                IntPtr getSourceObject(IntPtr res_)
                {
                    try {
                        var res = Object.GetInstance(res_, Transfer.None);
                        var doGetSourceObject = (GetSourceObject)methodInfo.CreateDelegate(typeof(GetSourceObject), res);
                        var ret = doGetSourceObject();
                        var ret_ = ret?.Take() ?? IntPtr.Zero;
                        return ret_;
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException();
                    }
                    return default(IntPtr);
                }

                return getSourceObject;
            }
        }

        public delegate bool IsTagged(IntPtr sourceTag);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool UnmanagedIsTagged(IntPtr res, IntPtr sourceTag);

        public static class IsTaggedFactory
        {
            public static UnmanagedIsTagged Create(MethodInfo methodInfo)
            {
                bool isTagged(IntPtr res_, IntPtr sourceTag_)
                {
                    try {
                        var res = Object.GetInstance(res_, Transfer.None);
                        var doIsTagged = (IsTagged)methodInfo.CreateDelegate(typeof(IsTagged), res);
                        var ret = doIsTagged(sourceTag_);
                        return ret;
                    }
                    catch (Exception ex) {
                        ex.LogUnhandledException();
                    }
                    return default(bool);
                }

                return isTagged;
            }
        }
    }

    [GType("GTask", IsProxyForUnmanagedType = true)]
    sealed class GTask : Object
    {
        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_task_get_type();

        static GType _GType = g_task_get_type();

        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_task_new(
            IntPtr sourceObject,
            IntPtr cancellable,
            UnmanagedAsyncReadyCallback callback,
            IntPtr callbackData);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public GTask(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_task_return_boolean(
            IntPtr task, 
            Boolean result);
 
        [DllImport("gio-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_task_propagate_boolean(IntPtr task, ref IntPtr error);

        public bool PropagateBoolean()
        {
            var error_ = IntPtr.Zero;
            var ret = g_task_propagate_boolean(Handle, ref error_);
            if (error_ != IntPtr.Zero) {
                var error = Opaque.GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            return ret;
        }
    }
}
