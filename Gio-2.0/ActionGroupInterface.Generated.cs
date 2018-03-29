namespace GISharp.Lib.Gio
{
    /// <summary>
    /// The virtual function table for <see cref="IActionGroup"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionGroupInterface : GISharp.Lib.GObject.TypeInterface
    {
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedHasAction HasAction;
            public UnmanagedListActions ListActions;
            public UnmanagedGetActionEnabled GetActionEnabled;
            public UnmanagedGetActionParameterType GetActionParameterType;
            public UnmanagedGetActionStateType GetActionStateType;
            public UnmanagedGetActionStateHint GetActionStateHint;
            public UnmanagedGetActionState GetActionState;
            public UnmanagedChangeActionState ChangeActionState;
            public UnmanagedActivateAction ActivateAction;
            public UnmanagedActionAdded ActionAdded;
            public UnmanagedActionRemoved ActionRemoved;
            public UnmanagedActionEnabledChanged ActionEnabledChanged;
            public UnmanagedActionStateChanged ActionStateChanged;
            public System.IntPtr QueryAction;
#pragma warning restore CS0649
        }

        static ActionGroupInterface()
        {
            System.Int32 hasActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.HasAction));
            RegisterVirtualMethod(hasActionOffset, HasActionFactory.Create);
            System.Int32 listActionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ListActions));
            RegisterVirtualMethod(listActionsOffset, ListActionsFactory.Create);
            System.Int32 getActionEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionEnabled));
            RegisterVirtualMethod(getActionEnabledOffset, GetActionEnabledFactory.Create);
            System.Int32 getActionParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionParameterType));
            RegisterVirtualMethod(getActionParameterTypeOffset, GetActionParameterTypeFactory.Create);
            System.Int32 getActionStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionStateType));
            RegisterVirtualMethod(getActionStateTypeOffset, GetActionStateTypeFactory.Create);
            System.Int32 getActionStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionStateHint));
            RegisterVirtualMethod(getActionStateHintOffset, GetActionStateHintFactory.Create);
            System.Int32 getActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionState));
            RegisterVirtualMethod(getActionStateOffset, GetActionStateFactory.Create);
            System.Int32 changeActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ChangeActionState));
            RegisterVirtualMethod(changeActionStateOffset, ChangeActionStateFactory.Create);
            System.Int32 activateActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActivateAction));
            RegisterVirtualMethod(activateActionOffset, ActivateActionFactory.Create);
            System.Int32 actionAddedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionAdded));
            RegisterVirtualMethod(actionAddedOffset, ActionAddedFactory.Create);
            System.Int32 actionRemovedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionRemoved));
            RegisterVirtualMethod(actionRemovedOffset, ActionRemovedFactory.Create);
            System.Int32 actionEnabledChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionEnabledChanged));
            RegisterVirtualMethod(actionEnabledChangedOffset, ActionEnabledChangedFactory.Create);
            System.Int32 actionStateChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionStateChanged));
            RegisterVirtualMethod(actionStateChangedOffset, ActionStateChangedFactory.Create);
        }

        public delegate System.Boolean HasAction(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedHasAction(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="HasAction"/> methods.
        /// </summary>
        public static class HasActionFactory
        {
            public static unsafe UnmanagedHasAction Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean hasAction(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doHasAction = (HasAction)methodInfo.CreateDelegate(typeof(HasAction), actionGroup);
                        var ret = doHasAction(actionName);
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return hasAction;
            }
        }

        public delegate GISharp.Lib.GLib.Strv ListActions();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedListActions(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup);

        /// <summary>
        /// Factory for creating <see cref="ListActions"/> methods.
        /// </summary>
        public static class ListActionsFactory
        {
            public static unsafe UnmanagedListActions Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr listActions(System.IntPtr actionGroup_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var doListActions = (ListActions)methodInfo.CreateDelegate(typeof(ListActions), actionGroup);
                        var ret = doListActions();
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return listActions;
            }
        }

        public delegate System.Boolean GetActionEnabled(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedGetActionEnabled(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="GetActionEnabled"/> methods.
        /// </summary>
        public static class GetActionEnabledFactory
        {
            public static unsafe UnmanagedGetActionEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean getActionEnabled(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doGetActionEnabled = (GetActionEnabled)methodInfo.CreateDelegate(typeof(GetActionEnabled), actionGroup);
                        var ret = doGetActionEnabled(actionName);
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return getActionEnabled;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType GetActionParameterType(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetActionParameterType(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="GetActionParameterType"/> methods.
        /// </summary>
        public static class GetActionParameterTypeFactory
        {
            public static unsafe UnmanagedGetActionParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getActionParameterType(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doGetActionParameterType = (GetActionParameterType)methodInfo.CreateDelegate(typeof(GetActionParameterType), actionGroup);
                        var ret = doGetActionParameterType(actionName);
                        var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getActionParameterType;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType GetActionStateType(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetActionStateType(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="GetActionStateType"/> methods.
        /// </summary>
        public static class GetActionStateTypeFactory
        {
            public static unsafe UnmanagedGetActionStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getActionStateType(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doGetActionStateType = (GetActionStateType)methodInfo.CreateDelegate(typeof(GetActionStateType), actionGroup);
                        var ret = doGetActionStateType(actionName);
                        var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getActionStateType;
            }
        }

        public delegate GISharp.Lib.GLib.Variant GetActionStateHint(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetActionStateHint(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="GetActionStateHint"/> methods.
        /// </summary>
        public static class GetActionStateHintFactory
        {
            public static unsafe UnmanagedGetActionStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getActionStateHint(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doGetActionStateHint = (GetActionStateHint)methodInfo.CreateDelegate(typeof(GetActionStateHint), actionGroup);
                        var ret = doGetActionStateHint(actionName);
                        var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getActionStateHint;
            }
        }

        public delegate GISharp.Lib.GLib.Variant GetActionState(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetActionState(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="GetActionState"/> methods.
        /// </summary>
        public static class GetActionStateFactory
        {
            public static unsafe UnmanagedGetActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getActionState(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doGetActionState = (GetActionState)methodInfo.CreateDelegate(typeof(GetActionState), actionGroup);
                        var ret = doGetActionState(actionName);
                        var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getActionState;
            }
        }

        public delegate void ChangeActionState(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant value);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedChangeActionState(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr value);

        /// <summary>
        /// Factory for creating <see cref="ChangeActionState"/> methods.
        /// </summary>
        public static class ChangeActionStateFactory
        {
            public static unsafe UnmanagedChangeActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                void changeActionState(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr value_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(value_, GISharp.Runtime.Transfer.None);
                        var doChangeActionState = (ChangeActionState)methodInfo.CreateDelegate(typeof(ChangeActionState), actionGroup);
                        doChangeActionState(actionName, value);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return changeActionState;
            }
        }

        public delegate void ActivateAction(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant parameter);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActivateAction(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr parameter);

        /// <summary>
        /// Factory for creating <see cref="ActivateAction"/> methods.
        /// </summary>
        public static class ActivateActionFactory
        {
            public static unsafe UnmanagedActivateAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void activateAction(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr parameter_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                        var doActivateAction = (ActivateAction)methodInfo.CreateDelegate(typeof(ActivateAction), actionGroup);
                        doActivateAction(actionName, parameter);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return activateAction;
            }
        }

        public delegate void ActionAdded(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActionAdded(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="ActionAdded"/> methods.
        /// </summary>
        public static class ActionAddedFactory
        {
            public static unsafe UnmanagedActionAdded Create(System.Reflection.MethodInfo methodInfo)
            {
                void actionAdded(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doActionAdded = (ActionAdded)methodInfo.CreateDelegate(typeof(ActionAdded), actionGroup);
                        doActionAdded(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return actionAdded;
            }
        }

        public delegate void ActionRemoved(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActionRemoved(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="ActionRemoved"/> methods.
        /// </summary>
        public static class ActionRemovedFactory
        {
            public static unsafe UnmanagedActionRemoved Create(System.Reflection.MethodInfo methodInfo)
            {
                void actionRemoved(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doActionRemoved = (ActionRemoved)methodInfo.CreateDelegate(typeof(ActionRemoved), actionGroup);
                        doActionRemoved(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return actionRemoved;
            }
        }

        public delegate void ActionEnabledChanged(GISharp.Lib.GLib.Utf8 actionName, System.Boolean enabled);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActionEnabledChanged(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
/* transfer-ownership:none direction:in */
System.Boolean enabled);

        /// <summary>
        /// Factory for creating <see cref="ActionEnabledChanged"/> methods.
        /// </summary>
        public static class ActionEnabledChangedFactory
        {
            public static unsafe UnmanagedActionEnabledChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void actionEnabledChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, System.Boolean enabled_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var enabled = (System.Boolean)enabled_;
                        var doActionEnabledChanged = (ActionEnabledChanged)methodInfo.CreateDelegate(typeof(ActionEnabledChanged), actionGroup);
                        doActionEnabledChanged(actionName, enabled);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return actionEnabledChanged;
            }
        }

        public delegate void ActionStateChanged(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant state);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedActionStateChanged(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr state);

        /// <summary>
        /// Factory for creating <see cref="ActionStateChanged"/> methods.
        /// </summary>
        public static class ActionStateChangedFactory
        {
            public static unsafe UnmanagedActionStateChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void actionStateChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr state_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var state = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(state_, GISharp.Runtime.Transfer.None);
                        var doActionStateChanged = (ActionStateChanged)methodInfo.CreateDelegate(typeof(ActionStateChanged), actionGroup);
                        doActionStateChanged(actionName, state);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return actionStateChanged;
            }
        }

        public ActionGroupInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}