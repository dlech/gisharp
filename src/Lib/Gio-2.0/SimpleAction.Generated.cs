// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction']/*" />
    [GISharp.Runtime.GTypeAttribute("GSimpleAction", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class SimpleAction : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IAction
    {
        private static readonly GISharp.Runtime.GType _GType = g_simple_action_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.Enabled']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        public bool Enabled { get => (bool)GetProperty("enabled")!; set => SetProperty("enabled", value); }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.Name']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Runtime.Utf8? Name { get => (GISharp.Runtime.Utf8?)GetProperty("name")!; set => SetProperty("name", value); }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.ParameterType']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.VariantType? ParameterType { get => (GISharp.Lib.GLib.VariantType?)GetProperty("parameter-type")!; set => SetProperty("parameter-type", value); }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.State']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state", Construct = GISharp.Runtime.GPropertyConstruct.Yes)]
        public GISharp.Lib.GLib.Variant? State { get => (GISharp.Lib.GLib.Variant?)GetProperty("state")!; set => SetProperty("state", value); }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.StateType']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        public GISharp.Lib.GLib.VariantType? StateType { get => (GISharp.Lib.GLib.VariantType?)GetProperty("state-type")!; }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SimpleAction(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The created action is stateless. See g_simple_action_new_stateful() to create
        /// an action that has state.
        /// </para>
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter that will be passed to
        ///   handlers for the #GSimpleAction::activate signal, or %NULL for no parameter
        /// </param>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SimpleAction" type="GSimpleAction*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* g_simple_action_new(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.VariantType.UnmanagedStruct* parameterType);
        static partial void CheckNewArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType);

        [GISharp.Runtime.SinceAttribute("2.28")]
        static GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* New(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType)
        {
            CheckNewArgs(name, parameterType);
            var name_ = (byte*)name.UnsafeHandle;
            var parameterType_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(parameterType?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_simple_action_new(name_,parameterType_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.SimpleAction(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GLib.VariantType?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType) : this((System.IntPtr)New(name, parameterType), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// All future state values must have the same #GVariantType as the initial
        /// @state.
        /// </para>
        /// <para>
        /// If the @state #GVariant is floating, it is consumed.
        /// </para>
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter that will be passed to
        ///   handlers for the #GSimpleAction::activate signal, or %NULL for no parameter
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SimpleAction" type="GSimpleAction*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* g_simple_action_new_stateful(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name,
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.VariantType.UnmanagedStruct* parameterType,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* state);
        static partial void CheckNewStatefulArgs(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state);

        [GISharp.Runtime.SinceAttribute("2.28")]
        static GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* NewStateful(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state)
        {
            CheckNewStatefulArgs(name, parameterType, state);
            var name_ = (byte*)name.UnsafeHandle;
            var parameterType_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(parameterType?.UnsafeHandle ?? System.IntPtr.Zero);
            var state_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)state.UnsafeHandle;
            var ret_ = g_simple_action_new_stateful(name_,parameterType_,state_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.SimpleAction(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GLib.VariantType?,GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Runtime.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state) : this((System.IntPtr)NewStateful(name, parameterType, state), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='ActivateSignalHandler']/*" />
        public delegate void ActivateSignalHandler(GISharp.Lib.Gio.SimpleAction simpleAction, GISharp.Lib.GLib.Variant? parameter);

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.ActivateSignal']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("activate", When = GISharp.Runtime.EmissionStage.Last)]
        public event ActivateSignalHandler ActivateSignal { add => AddEventSignalHandler("activate", value); remove => RemoveEventSignalHandler("activate", value); }

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void ManagedActivateSignalHandler(GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* simpleAction_, GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter_, System.IntPtr userData_)
        {
            try
            {
                var simpleAction = GISharp.Lib.Gio.SimpleAction.GetInstance<GISharp.Lib.Gio.SimpleAction>((System.IntPtr)simpleAction_, GISharp.Runtime.Transfer.None)!;
                var parameter = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)parameter_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (GISharp.Runtime.CClosureData)gcHandle.Target!;
                ((ActivateSignalHandler)userData.Callback)(simpleAction, parameter);
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='ChangeStateSignalHandler']/*" />
        public delegate void ChangeStateSignalHandler(GISharp.Lib.Gio.SimpleAction simpleAction, GISharp.Lib.GLib.Variant? value);

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.ChangeStateSignal']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        [GISharp.Runtime.GSignalAttribute("change-state", When = GISharp.Runtime.EmissionStage.Last)]
        public event ChangeStateSignalHandler ChangeStateSignal { add => AddEventSignalHandler("change-state", value); remove => RemoveEventSignalHandler("change-state", value); }

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void ManagedChangeStateSignalHandler(GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* simpleAction_, GISharp.Lib.GLib.Variant.UnmanagedStruct* value_, System.IntPtr userData_)
        {
            try
            {
                var simpleAction = GISharp.Lib.Gio.SimpleAction.GetInstance<GISharp.Lib.Gio.SimpleAction>((System.IntPtr)simpleAction_, GISharp.Runtime.Transfer.None)!;
                var value = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)value_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (GISharp.Runtime.CClosureData)gcHandle.Target!;
                ((ChangeStateSignalHandler)userData.Callback)(simpleAction, value);
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_simple_action_get_type();

        /// <summary>
        /// Sets the action as enabled or not.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </para>
        /// <para>
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to modify its enabled flag.
        /// </para>
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="enabled">
        /// whether the action is enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_simple_action_set_enabled(
        /* <type name="SimpleAction" type="GSimpleAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* simple,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean enabled);
        partial void CheckSetEnabledArgs(bool enabled);

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.SetEnabled(bool)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public void SetEnabled(bool enabled)
        {
            CheckSetEnabledArgs(enabled);
            var simple_ = (GISharp.Lib.Gio.SimpleAction.UnmanagedStruct*)UnsafeHandle;
            var enabled_ = GISharp.Runtime.BooleanExtensions.ToBoolean(enabled);
            g_simple_action_set_enabled(simple_, enabled_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the state of the action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This directly updates the 'state' property to the given value.
        /// </para>
        /// <para>
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to directly modify the 'state'
        /// property.  Instead, they should call g_action_change_state() to
        /// request the change.
        /// </para>
        /// <para>
        /// If the @value GVariant is floating, it is consumed.
        /// </para>
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="value">
        /// the new #GVariant for the state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_simple_action_set_state(
        /* <type name="SimpleAction" type="GSimpleAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* simple,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        partial void CheckSetStateArgs(GISharp.Lib.GLib.Variant value);

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.SetState(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        public void SetState(GISharp.Lib.GLib.Variant value)
        {
            CheckSetStateArgs(value);
            var simple_ = (GISharp.Lib.Gio.SimpleAction.UnmanagedStruct*)UnsafeHandle;
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
            g_simple_action_set_state(simple_, value_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the state hint for the action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See g_action_get_state_hint() for more information about
        /// action state hints.
        /// </para>
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="stateHint">
        /// a #GVariant representing the state hint
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_simple_action_set_state_hint(
        /* <type name="SimpleAction" type="GSimpleAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.SimpleAction.UnmanagedStruct* simple,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* stateHint);
        partial void CheckSetStateHintArgs(GISharp.Lib.GLib.Variant? stateHint);

        /// <include file="SimpleAction.xmldoc" path="declaration/member[@name='SimpleAction.SetStateHint(GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.44")]
        public void SetStateHint(GISharp.Lib.GLib.Variant? stateHint)
        {
            CheckSetStateHintArgs(stateHint);
            var simple_ = (GISharp.Lib.Gio.SimpleAction.UnmanagedStruct*)UnsafeHandle;
            var stateHint_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(stateHint?.UnsafeHandle ?? System.IntPtr.Zero);
            g_simple_action_set_state_hint(simple_, stateHint_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        void GISharp.Lib.Gio.IAction.DoActivate(GISharp.Lib.GLib.Variant? parameter)
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.IAction.DoChangeState(GISharp.Lib.GLib.Variant value)
        {
            throw new System.NotImplementedException();
        }

        bool GISharp.Lib.Gio.IAction.DoGetEnabled()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Runtime.UnownedUtf8 GISharp.Lib.Gio.IAction.DoGetName()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType? GISharp.Lib.Gio.IAction.DoGetParameterType()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant? GISharp.Lib.Gio.IAction.DoGetState()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant? GISharp.Lib.Gio.IAction.DoGetStateHint()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType? GISharp.Lib.Gio.IAction.DoGetStateType()
        {
            throw new System.NotImplementedException();
        }
    }
}