// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='ActionGroupInterface']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed unsafe partial class ActionGroupInterface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.HasAction']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Runtime.Boolean> HasAction;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ListActions']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte**> ListActions;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetActionEnabled']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Runtime.Boolean> GetActionEnabled;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetActionParameterType']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.VariantType.UnmanagedStruct*> GetActionParameterType;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetActionStateType']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.VariantType.UnmanagedStruct*> GetActionStateType;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetActionStateHint']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.Variant.UnmanagedStruct*> GetActionStateHint;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetActionState']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.Variant.UnmanagedStruct*> GetActionState;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ChangeActionState']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.Variant.UnmanagedStruct*, void> ChangeActionState;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ActivateAction']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.Variant.UnmanagedStruct*, void> ActivateAction;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ActionAdded']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, void> ActionAdded;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ActionRemoved']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, void> ActionRemoved;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ActionEnabledChanged']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Runtime.Boolean, void> ActionEnabledChanged;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ActionStateChanged']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.ActionGroup.UnmanagedStruct*, byte*, GISharp.Lib.GLib.Variant.UnmanagedStruct*, void> ActionStateChanged;

            /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryAction']/*" />
            public readonly System.IntPtr QueryAction;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static ActionGroupInterface()
        {
            int hasActionOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.HasAction));
            RegisterVirtualMethod(hasActionOffset, HasActionMarshal.Create);
            int listActionsOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ListActions));
            RegisterVirtualMethod(listActionsOffset, ListActionsMarshal.Create);
            int getActionEnabledOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetActionEnabled));
            RegisterVirtualMethod(getActionEnabledOffset, GetActionEnabledMarshal.Create);
            int getActionParameterTypeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetActionParameterType));
            RegisterVirtualMethod(getActionParameterTypeOffset, GetActionParameterTypeMarshal.Create);
            int getActionStateTypeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetActionStateType));
            RegisterVirtualMethod(getActionStateTypeOffset, GetActionStateTypeMarshal.Create);
            int getActionStateHintOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetActionStateHint));
            RegisterVirtualMethod(getActionStateHintOffset, GetActionStateHintMarshal.Create);
            int getActionStateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetActionState));
            RegisterVirtualMethod(getActionStateOffset, GetActionStateMarshal.Create);
            int changeActionStateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ChangeActionState));
            RegisterVirtualMethod(changeActionStateOffset, ChangeActionStateMarshal.Create);
            int activateActionOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ActivateAction));
            RegisterVirtualMethod(activateActionOffset, ActivateActionMarshal.Create);
            int actionAddedOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ActionAdded));
            RegisterVirtualMethod(actionAddedOffset, ActionAddedMarshal.Create);
            int actionRemovedOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ActionRemoved));
            RegisterVirtualMethod(actionRemovedOffset, ActionRemovedMarshal.Create);
            int actionEnabledChangedOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ActionEnabledChanged));
            RegisterVirtualMethod(actionEnabledChangedOffset, ActionEnabledChangedMarshal.Create);
            int actionStateChangedOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ActionStateChanged));
            RegisterVirtualMethod(actionStateChangedOffset, ActionStateChangedMarshal.Create);
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_HasAction']/*" />
        public delegate bool _HasAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedHasAction(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_HasAction"/> methods.
        /// </summary>
        public static unsafe class HasActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedHasAction Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedHasAction(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doHasAction = (_HasAction)methodInfo.CreateDelegate(typeof(_HasAction), actionGroup); var ret = doHasAction(actionName); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedHasAction;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ListActions']/*" />
        public delegate GISharp.Lib.GLib.Strv _ListActions();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" name="GLib.Strv" is-pointer="1">
*   <type name="utf8" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate byte** UnmanagedListActions(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup);

        /// <summary>
        /// Class for marshalling <see cref="_ListActions"/> methods.
        /// </summary>
        public static unsafe class ListActionsMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedListActions Create(System.Reflection.MethodInfo methodInfo)
            {
                byte** unmanagedListActions(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var doListActions = (_ListActions)methodInfo.CreateDelegate(typeof(_ListActions), actionGroup); var ret = doListActions(); var ret_ = (byte**)ret.Take(); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(byte**); }

                return unmanagedListActions;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_GetActionEnabled']/*" />
        public delegate bool _GetActionEnabled(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedGetActionEnabled(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_GetActionEnabled"/> methods.
        /// </summary>
        public static unsafe class GetActionEnabledMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetActionEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedGetActionEnabled(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doGetActionEnabled = (_GetActionEnabled)methodInfo.CreateDelegate(typeof(_GetActionEnabled), actionGroup); var ret = doGetActionEnabled(actionName); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedGetActionEnabled;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_GetActionParameterType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? _GetActionParameterType(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetActionParameterType(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_GetActionParameterType"/> methods.
        /// </summary>
        public static unsafe class GetActionParameterTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetActionParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetActionParameterType(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doGetActionParameterType = (_GetActionParameterType)methodInfo.CreateDelegate(typeof(_GetActionParameterType), actionGroup); var ret = doGetActionParameterType(actionName); var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*); }

                return unmanagedGetActionParameterType;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_GetActionStateType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? _GetActionStateType(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetActionStateType(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_GetActionStateType"/> methods.
        /// </summary>
        public static unsafe class GetActionStateTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetActionStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetActionStateType(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doGetActionStateType = (_GetActionStateType)methodInfo.CreateDelegate(typeof(_GetActionStateType), actionGroup); var ret = doGetActionStateType(actionName); var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*); }

                return unmanagedGetActionStateType;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_GetActionStateHint']/*" />
        public delegate GISharp.Lib.GLib.Variant? _GetActionStateHint(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetActionStateHint(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_GetActionStateHint"/> methods.
        /// </summary>
        public static unsafe class GetActionStateHintMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetActionStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetActionStateHint(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doGetActionStateHint = (_GetActionStateHint)methodInfo.CreateDelegate(typeof(_GetActionStateHint), actionGroup); var ret = doGetActionStateHint(actionName); var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*); }

                return unmanagedGetActionStateHint;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_GetActionState']/*" />
        public delegate GISharp.Lib.GLib.Variant? _GetActionState(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetActionState(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_GetActionState"/> methods.
        /// </summary>
        public static unsafe class GetActionStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetActionState(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doGetActionState = (_GetActionState)methodInfo.CreateDelegate(typeof(_GetActionState), actionGroup); var ret = doGetActionState(actionName); var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*); }

                return unmanagedGetActionState;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ChangeActionState']/*" />
        public delegate void _ChangeActionState(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedChangeActionState(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName,
/* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* value);

        /// <summary>
        /// Class for marshalling <see cref="_ChangeActionState"/> methods.
        /// </summary>
        public static unsafe class ChangeActionStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedChangeActionState Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedChangeActionState(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_, GISharp.Lib.GLib.Variant.UnmanagedStruct* value_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var value = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)value_, GISharp.Runtime.Transfer.None)!; var doChangeActionState = (_ChangeActionState)methodInfo.CreateDelegate(typeof(_ChangeActionState), actionGroup); doChangeActionState(actionName, value); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedChangeActionState;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ActivateAction']/*" />
        public delegate void _ActivateAction(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant? parameter);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActivateAction(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName,
/* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter);

        /// <summary>
        /// Class for marshalling <see cref="_ActivateAction"/> methods.
        /// </summary>
        public static unsafe class ActivateActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActivateAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivateAction(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_, GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var parameter = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)parameter_, GISharp.Runtime.Transfer.None); var doActivateAction = (_ActivateAction)methodInfo.CreateDelegate(typeof(_ActivateAction), actionGroup); doActivateAction(actionName, parameter); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedActivateAction;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ActionAdded']/*" />
        public delegate void _ActionAdded(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActionAdded(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_ActionAdded"/> methods.
        /// </summary>
        public static unsafe class ActionAddedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActionAdded Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionAdded(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doActionAdded = (_ActionAdded)methodInfo.CreateDelegate(typeof(_ActionAdded), actionGroup); doActionAdded(actionName); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedActionAdded;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ActionRemoved']/*" />
        public delegate void _ActionRemoved(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActionRemoved(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="_ActionRemoved"/> methods.
        /// </summary>
        public static unsafe class ActionRemovedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActionRemoved Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionRemoved(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doActionRemoved = (_ActionRemoved)methodInfo.CreateDelegate(typeof(_ActionRemoved), actionGroup); doActionRemoved(actionName); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedActionRemoved;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ActionEnabledChanged']/*" />
        public delegate void _ActionEnabledChanged(GISharp.Lib.GLib.UnownedUtf8 actionName, bool enabled);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActionEnabledChanged(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName,
/* <type name="gboolean" type="gboolean" /> */
/* transfer-ownership:none direction:in */
GISharp.Runtime.Boolean enabled);

        /// <summary>
        /// Class for marshalling <see cref="_ActionEnabledChanged"/> methods.
        /// </summary>
        public static unsafe class ActionEnabledChangedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActionEnabledChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionEnabledChanged(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_, GISharp.Runtime.Boolean enabled_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var enabled = GISharp.Runtime.BooleanExtensions.IsTrue(enabled_); var doActionEnabledChanged = (_ActionEnabledChanged)methodInfo.CreateDelegate(typeof(_ActionEnabledChanged), actionGroup); doActionEnabledChanged(actionName, enabled); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedActionEnabledChanged;
            }
        }

        /// <include file="ActionGroupInterface.xmldoc" path="declaration/member[@name='_ActionStateChanged']/*" />
        public delegate void _ActionStateChanged(GISharp.Lib.GLib.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant state);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActionStateChanged(
/* <type name="ActionGroup" type="GActionGroup*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName,
/* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* state);

        /// <summary>
        /// Class for marshalling <see cref="_ActionStateChanged"/> methods.
        /// </summary>
        public static unsafe class ActionStateChangedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActionStateChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActionStateChanged(GISharp.Lib.Gio.ActionGroup.UnmanagedStruct* actionGroup_, byte* actionName_, GISharp.Lib.GLib.Variant.UnmanagedStruct* state_) { try { var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionGroup_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var state = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)state_, GISharp.Runtime.Transfer.None)!; var doActionStateChanged = (_ActionStateChanged)methodInfo.CreateDelegate(typeof(_ActionStateChanged), actionGroup); doActionStateChanged(actionName, state); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedActionStateChanged;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ActionGroupInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}