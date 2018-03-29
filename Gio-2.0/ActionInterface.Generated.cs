namespace GISharp.Lib.Gio
{
    /// <summary>
    /// The virtual function table for <see cref="IAction"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionInterface : GISharp.Lib.GObject.TypeInterface
    {
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedGetName GetName;
            public UnmanagedGetParameterType GetParameterType;
            public UnmanagedGetStateType GetStateType;
            public UnmanagedGetStateHint GetStateHint;
            public UnmanagedGetEnabled GetEnabled;
            public UnmanagedGetState GetState;
            public UnmanagedChangeState ChangeState;
            public UnmanagedActivate Activate;
#pragma warning restore CS0649
        }

        static ActionInterface()
        {
            System.Int32 getNameOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetName));
            RegisterVirtualMethod(getNameOffset, GetNameFactory.Create);
            System.Int32 getParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetParameterType));
            RegisterVirtualMethod(getParameterTypeOffset, GetParameterTypeFactory.Create);
            System.Int32 getStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetStateType));
            RegisterVirtualMethod(getStateTypeOffset, GetStateTypeFactory.Create);
            System.Int32 getStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetStateHint));
            RegisterVirtualMethod(getStateHintOffset, GetStateHintFactory.Create);
            System.Int32 getEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetEnabled));
            RegisterVirtualMethod(getEnabledOffset, GetEnabledFactory.Create);
            System.Int32 getStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetState));
            RegisterVirtualMethod(getStateOffset, GetStateFactory.Create);
            System.Int32 changeStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ChangeState));
            RegisterVirtualMethod(changeStateOffset, ChangeStateFactory.Create);
            System.Int32 activateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateFactory.Create);
        }

        public delegate GISharp.Lib.GLib.Utf8 GetName();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetName(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetName"/> methods.
        /// </summary>
        public static class GetNameFactory
        {
            public static unsafe UnmanagedGetName Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getName(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetName = (GetName)methodInfo.CreateDelegate(typeof(GetName), action);
                        var ret = doGetName();
                        var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getName;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType GetParameterType();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetParameterType"/> methods.
        /// </summary>
        public static class GetParameterTypeFactory
        {
            public static unsafe UnmanagedGetParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getParameterType(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetParameterType = (GetParameterType)methodInfo.CreateDelegate(typeof(GetParameterType), action);
                        var ret = doGetParameterType();
                        var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getParameterType;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType GetStateType();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetStateType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetStateType"/> methods.
        /// </summary>
        public static class GetStateTypeFactory
        {
            public static unsafe UnmanagedGetStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getStateType(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetStateType = (GetStateType)methodInfo.CreateDelegate(typeof(GetStateType), action);
                        var ret = doGetStateType();
                        var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getStateType;
            }
        }

        public delegate GISharp.Lib.GLib.Variant GetStateHint();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetStateHint"/> methods.
        /// </summary>
        public static class GetStateHintFactory
        {
            public static unsafe UnmanagedGetStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getStateHint(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetStateHint = (GetStateHint)methodInfo.CreateDelegate(typeof(GetStateHint), action);
                        var ret = doGetStateHint();
                        var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getStateHint;
            }
        }

        public delegate System.Boolean GetEnabled();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetEnabled"/> methods.
        /// </summary>
        public static class GetEnabledFactory
        {
            public static unsafe UnmanagedGetEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean getEnabled(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetEnabled = (GetEnabled)methodInfo.CreateDelegate(typeof(GetEnabled), action);
                        var ret = doGetEnabled();
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return getEnabled;
            }
        }

        public delegate GISharp.Lib.GLib.Variant GetState();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetState"/> methods.
        /// </summary>
        public static class GetStateFactory
        {
            public static unsafe UnmanagedGetState Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getState(System.IntPtr action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doGetState = (GetState)methodInfo.CreateDelegate(typeof(GetState), action);
                        var ret = doGetState();
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getState;
            }
        }

        public delegate void ChangeState(GISharp.Lib.GLib.Variant value);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedChangeState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr value);

        /// <summary>
        /// Factory for creating <see cref="ChangeState"/> methods.
        /// </summary>
        public static class ChangeStateFactory
        {
            public static unsafe UnmanagedChangeState Create(System.Reflection.MethodInfo methodInfo)
            {
                void changeState(System.IntPtr action_, System.IntPtr value_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(value_, GISharp.Runtime.Transfer.None);
                        var doChangeState = (ChangeState)methodInfo.CreateDelegate(typeof(ChangeState), action);
                        doChangeState(value);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return changeState;
            }
        }

        public delegate void Activate(GISharp.Lib.GLib.Variant parameter);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr parameter);

        /// <summary>
        /// Factory for creating <see cref="Activate"/> methods.
        /// </summary>
        public static class ActivateFactory
        {
            public static unsafe UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void activate(System.IntPtr action_, System.IntPtr parameter_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                        var doActivate = (Activate)methodInfo.CreateDelegate(typeof(Activate), action);
                        doActivate(parameter);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return activate;
            }
        }

        public ActionInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}