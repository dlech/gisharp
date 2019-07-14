// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
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
            public System.IntPtr HasAction;
            public System.IntPtr ListActions;
            public System.IntPtr GetActionEnabled;
            public System.IntPtr GetActionParameterType;
            public System.IntPtr GetActionStateType;
            public System.IntPtr GetActionStateHint;
            public System.IntPtr GetActionState;
            public System.IntPtr ChangeActionState;
            public System.IntPtr ActivateAction;
            public System.IntPtr ActionAdded;
            public System.IntPtr ActionRemoved;
            public System.IntPtr ActionEnabledChanged;
            public System.IntPtr ActionStateChanged;
            public System.IntPtr QueryAction;
#pragma warning restore CS0649
        }

        static ActionGroupInterface()
        {
            System.Int32 hasActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.HasAction));
            RegisterVirtualMethod(hasActionOffset, HasActionMarshal.Create);
            System.Int32 listActionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ListActions));
            RegisterVirtualMethod(listActionsOffset, ListActionsMarshal.Create);
            System.Int32 getActionEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionEnabled));
            RegisterVirtualMethod(getActionEnabledOffset, GetActionEnabledMarshal.Create);
            System.Int32 getActionParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionParameterType));
            RegisterVirtualMethod(getActionParameterTypeOffset, GetActionParameterTypeMarshal.Create);
            System.Int32 getActionStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionStateType));
            RegisterVirtualMethod(getActionStateTypeOffset, GetActionStateTypeMarshal.Create);
            System.Int32 getActionStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionStateHint));
            RegisterVirtualMethod(getActionStateHintOffset, GetActionStateHintMarshal.Create);
            System.Int32 getActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetActionState));
            RegisterVirtualMethod(getActionStateOffset, GetActionStateMarshal.Create);
            System.Int32 changeActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ChangeActionState));
            RegisterVirtualMethod(changeActionStateOffset, ChangeActionStateMarshal.Create);
            System.Int32 activateActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActivateAction));
            RegisterVirtualMethod(activateActionOffset, ActivateActionMarshal.Create);
            System.Int32 actionAddedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionAdded));
            RegisterVirtualMethod(actionAddedOffset, ActionAddedMarshal.Create);
            System.Int32 actionRemovedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionRemoved));
            RegisterVirtualMethod(actionRemovedOffset, ActionRemovedMarshal.Create);
            System.Int32 actionEnabledChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionEnabledChanged));
            RegisterVirtualMethod(actionEnabledChangedOffset, ActionEnabledChangedMarshal.Create);
            System.Int32 actionStateChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ActionStateChanged));
            RegisterVirtualMethod(actionStateChangedOffset, ActionStateChangedMarshal.Create);
        }

        public delegate System.Boolean HasAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedHasAction(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Class for marshalling <see cref="HasAction"/> methods.
        /// </summary>
        public static class HasActionMarshal
        {
            public static unsafe UnmanagedHasAction Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedHasAction(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doHasAction = (HasAction)methodInfo.CreateDelegate(typeof(HasAction), actionGroup);
                        var ret = doHasAction(actionName);
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedHasAction;
            }
        }

        public delegate GISharp.Lib.GLib.Strv ListActions();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" name="GLib.Strv" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedListActions(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup);

        /// <summary>
        /// Class for marshalling <see cref="ListActions"/> methods.
        /// </summary>
        public static class ListActionsMarshal
        {
            public static unsafe UnmanagedListActions Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedListActions(System.IntPtr actionGroup_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var doListActions = (ListActions)methodInfo.CreateDelegate(typeof(ListActions), actionGroup);
                        var ret = doListActions();
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedListActions;
            }
        }

        public delegate System.Boolean GetActionEnabled(GISharp.Lib.GLib.UnownedUtf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedGetActionEnabled(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Class for marshalling <see cref="GetActionEnabled"/> methods.
        /// </summary>
        public static class GetActionEnabledMarshal
        {
            public static unsafe UnmanagedGetActionEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedGetActionEnabled(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doGetActionEnabled = (GetActionEnabled)methodInfo.CreateDelegate(typeof(GetActionEnabled), actionGroup);
                        var ret = doGetActionEnabled(actionName);
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedGetActionEnabled;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType? GetActionParameterType(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="GetActionParameterType"/> methods.
        /// </summary>
        public static class GetActionParameterTypeMarshal
        {
            public static unsafe UnmanagedGetActionParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetActionParameterType(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
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

                return unmanagedGetActionParameterType;
            }
        }

        public delegate GISharp.Lib.GLib.VariantType? GetActionStateType(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="GetActionStateType"/> methods.
        /// </summary>
        public static class GetActionStateTypeMarshal
        {
            public static unsafe UnmanagedGetActionStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetActionStateType(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
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

                return unmanagedGetActionStateType;
            }
        }

        public delegate GISharp.Lib.GLib.Variant? GetActionStateHint(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="GetActionStateHint"/> methods.
        /// </summary>
        public static class GetActionStateHintMarshal
        {
            public static unsafe UnmanagedGetActionStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetActionStateHint(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
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

                return unmanagedGetActionStateHint;
            }
        }

        public delegate GISharp.Lib.GLib.Variant? GetActionState(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="GetActionState"/> methods.
        /// </summary>
        public static class GetActionStateMarshal
        {
            public static unsafe UnmanagedGetActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetActionState(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
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

                return unmanagedGetActionState;
            }
        }

        public delegate void ChangeActionState(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant value);

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
        /// Class for marshalling <see cref="ChangeActionState"/> methods.
        /// </summary>
        public static class ChangeActionStateMarshal
        {
            public static unsafe UnmanagedChangeActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedChangeActionState(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr value_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(value_, GISharp.Runtime.Transfer.None)!;
                        var doChangeActionState = (ChangeActionState)methodInfo.CreateDelegate(typeof(ChangeActionState), actionGroup);
                        doChangeActionState(actionName, value);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedChangeActionState;
            }
        }

        public delegate void ActivateAction(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant? parameter);

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
        /// Class for marshalling <see cref="ActivateAction"/> methods.
        /// </summary>
        public static class ActivateActionMarshal
        {
            public static unsafe UnmanagedActivateAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivateAction(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr parameter_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                        var doActivateAction = (ActivateAction)methodInfo.CreateDelegate(typeof(ActivateAction), actionGroup);
                        doActivateAction(actionName, parameter);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedActivateAction;
            }
        }

        public delegate void ActionAdded(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="ActionAdded"/> methods.
        /// </summary>
        public static class ActionAddedMarshal
        {
            public static unsafe UnmanagedActionAdded Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionAdded(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doActionAdded = (ActionAdded)methodInfo.CreateDelegate(typeof(ActionAdded), actionGroup);
                        doActionAdded(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedActionAdded;
            }
        }

        public delegate void ActionRemoved(GISharp.Lib.GLib.UnownedUtf8 actionName);

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
        /// Class for marshalling <see cref="ActionRemoved"/> methods.
        /// </summary>
        public static class ActionRemovedMarshal
        {
            public static unsafe UnmanagedActionRemoved Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionRemoved(System.IntPtr actionGroup_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doActionRemoved = (ActionRemoved)methodInfo.CreateDelegate(typeof(ActionRemoved), actionGroup);
                        doActionRemoved(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedActionRemoved;
            }
        }

        public delegate void ActionEnabledChanged(GISharp.Lib.GLib.UnownedUtf8 actionName, System.Boolean enabled);

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
GISharp.Runtime.Boolean enabled);

        /// <summary>
        /// Class for marshalling <see cref="ActionEnabledChanged"/> methods.
        /// </summary>
        public static class ActionEnabledChangedMarshal
        {
            public static unsafe UnmanagedActionEnabledChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionEnabledChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, GISharp.Runtime.Boolean enabled_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var enabled = (System.Boolean)enabled_;
                        var doActionEnabledChanged = (ActionEnabledChanged)methodInfo.CreateDelegate(typeof(ActionEnabledChanged), actionGroup);
                        doActionEnabledChanged(actionName, enabled);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedActionEnabledChanged;
            }
        }

        public delegate void ActionStateChanged(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant state);

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
        /// Class for marshalling <see cref="ActionStateChanged"/> methods.
        /// </summary>
        public static class ActionStateChangedMarshal
        {
            public static unsafe UnmanagedActionStateChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionStateChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr state_)
                {
                    try
                    {
                        var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var state = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(state_, GISharp.Runtime.Transfer.None)!;
                        var doActionStateChanged = (ActionStateChanged)methodInfo.CreateDelegate(typeof(ActionStateChanged), actionGroup);
                        doActionStateChanged(actionName, state);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedActionStateChanged;
            }
        }

        public ActionGroupInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}