// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// A <see cref="SimpleAction"/> is the obvious simple implementation of the <see cref="IAction"/>
    /// interface. This is the easiest way to create an action for purposes of
    /// adding it to a <see cref="SimpleAction"/>Group.
    /// </summary>
    /// <remarks>
    /// See also #GtkAction.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GSimpleAction", IsProxyForUnmanagedType = true)]
    public sealed partial class SimpleAction : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IAction
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_simple_action_get_type();

        /// <summary>
        /// If <paramref name="action"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// If the action is disabled then calls to <see cref="Action.Activate"/> and
        /// <see cref="Action.ChangeState"/> have no effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        public System.Boolean Enabled { get => (System.Boolean)GetProperty("enabled")!; set => SetProperty("enabled", value); }

        /// <summary>
        /// The name of the action. This is mostly meaningful for identifying
        /// the action once it has been added to a #GSimpleActionGroup.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8? Name { get => (GISharp.Lib.GLib.Utf8?)GetProperty("name")!; set => SetProperty("name", value); }

        /// <summary>
        /// The type of the parameter that must be given when activating the
        /// action.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.VariantType? ParameterType { get => (GISharp.Lib.GLib.VariantType?)GetProperty("parameter-type")!; set => SetProperty("parameter-type", value); }

        /// <summary>
        /// The state of the action, or <c>null</c> if the action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state", Construct = GISharp.Runtime.GPropertyConstruct.Yes)]
        public GISharp.Lib.GLib.Variant? State { get => (GISharp.Lib.GLib.Variant?)GetProperty("state")!; set => SetProperty("state", value); }

        /// <summary>
        /// The #GVariantType of the state that the action has, or <c>null</c> if the
        /// action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        public GISharp.Lib.GLib.VariantType? StateType { get => (GISharp.Lib.GLib.VariantType?)GetProperty("state-type")!; }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SimpleAction(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless. See g_simple_action_new_stateful() to create
        /// an action that has state.
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
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_simple_action_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterType);

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless. See <see cref="SimpleAction.NewStateful"/> to create
        /// an action that has state.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType)
        {
            var name_ = name.Handle;
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_simple_action_new(name_,parameterType_);
            return ret_;
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless. See <see cref="SimpleAction.NewStateful"/> to create
        /// an action that has state.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType) : this(New(name, parameterType), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless. See <see cref="SimpleAction.NewStateful"/> to create
        /// an action that has state.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static unsafe System.IntPtr New(System.String name, GISharp.Lib.GLib.VariantType? parameterType)
        {
            using var nameUtf8 = new GISharp.Lib.GLib.Utf8(name);
            return New((GISharp.Lib.GLib.UnownedUtf8)nameUtf8, parameterType);
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless. See <see cref="SimpleAction.NewStateful"/> to create
        /// an action that has state.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(System.String name, GISharp.Lib.GLib.VariantType? parameterType) : this(New(name, parameterType), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// All future state values must have the same #GVariantType as the initial
        /// @state.
        /// 
        /// If the @state #GVariant is floating, it is consumed.
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
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_simple_action_new_stateful(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterType,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr state);

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// All future state values must have the same #GVariantType as the initial
        /// <paramref name="state"/>.
        /// 
        /// If the <paramref name="state"/> #GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static unsafe System.IntPtr NewStateful(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state)
        {
            var name_ = name.Handle;
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var state_ = state.Handle;
            var ret_ = g_simple_action_new_stateful(name_,parameterType_,state_);
            return ret_;
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// All future state values must have the same #GVariantType as the initial
        /// <paramref name="state"/>.
        /// 
        /// If the <paramref name="state"/> #GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state) : this(NewStateful(name, parameterType, state), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// All future state values must have the same #GVariantType as the initial
        /// <paramref name="state"/>.
        /// 
        /// If the <paramref name="state"/> #GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static unsafe System.IntPtr NewStateful(System.String name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state)
        {
            using var nameUtf8 = new GISharp.Lib.GLib.Utf8(name);
            return NewStateful((GISharp.Lib.GLib.UnownedUtf8)nameUtf8, parameterType, state);
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// All future state values must have the same #GVariantType as the initial
        /// <paramref name="state"/>.
        /// 
        /// If the <paramref name="state"/> #GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter that will be passed to
        ///   handlers for the <see cref="SimpleAction"/>::activate signal, or <c>null</c> for no parameter
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(System.String name, GISharp.Lib.GLib.VariantType? parameterType, GISharp.Lib.GLib.Variant state) : this(NewStateful(name, parameterType, state), GISharp.Runtime.Transfer.Full)
        {
        }

        public sealed class ActivatedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly System.Object[] args;

            public GISharp.Lib.GLib.Variant Parameter => (GISharp.Lib.GLib.Variant)args[1];

            public ActivatedEventArgs(params System.Object[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<ActivatedEventArgs> activatedSignalManager = new GISharp.Runtime.GSignalManager<ActivatedEventArgs>("activate", _GType);

        /// <summary>
        /// Indicates that the action was just activated.
        /// </summary>
        /// <remarks>
        /// <paramref name="parameter"/> will always be of the expected type, i.e. the parameter type
        /// specified when the action was created. If an incorrect type is given when
        /// activating the action, this signal is not emitted.
        /// 
        /// Since GLib 2.40, if no handler is connected to this signal then the
        /// default behaviour for boolean-stated actions with a <c>null</c> parameter
        /// type is to toggle them via the <see cref="SimpleAction"/>::change-state signal.
        /// For stateful actions where the state type is equal to the parameter
        /// type, the default is to forward them directly to
        /// <see cref="SimpleAction"/>::change-state.  This should allow almost all users
        /// of <see cref="SimpleAction"/> to connect only one handler or the other.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("activate", When = GISharp.Runtime.EmissionStage.Last)]
        public event System.EventHandler<ActivatedEventArgs> Activated { add => activatedSignalManager.Add(this, value); remove => activatedSignalManager.Remove(value); }

        public sealed class ChangedStateEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly System.Object[] args;

            public GISharp.Lib.GLib.Variant Value => (GISharp.Lib.GLib.Variant)args[1];

            public ChangedStateEventArgs(params System.Object[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<ChangedStateEventArgs> changedStateSignalManager = new GISharp.Runtime.GSignalManager<ChangedStateEventArgs>("change-state", _GType);

        /// <summary>
        /// Indicates that the action just received a request to change its
        /// state.
        /// </summary>
        /// <remarks>
        /// <paramref name="value"/> will always be of the correct state type, i.e. the type of the
        /// initial state passed to <see cref="SimpleAction.NewStateful"/>. If an incorrect
        /// type is given when requesting to change the state, this signal is not
        /// emitted.
        /// 
        /// If no handler is connected to this signal then the default
        /// behaviour is to call <see cref="SimpleAction.SetState"/> to set the state
        /// to the requested value. If you connect a signal handler then no
        /// default action is taken. If the state should change then you must
        /// call <see cref="SimpleAction.SetState"/> from the handler.
        /// 
        /// An example of a 'change-state' handler:
        /// |[&lt;!-- language="C" --&gt;
        /// static void
        /// change_volume_state (GSimpleAction *action,
        ///                      GVariant      *value,
        ///                      gpointer       user_data)
        /// {
        ///   gint requested;
        /// 
        ///   requested = g_variant_get_int32 (value);
        /// 
        ///   // Volume only goes from 0 to 10
        ///   if (0 &lt;= requested &amp;&amp; requested &lt;= 10)
        ///     g_simple_action_set_state (action, value);
        /// }
        /// ]|
        /// 
        /// The handler need not set the state to the requested value.
        /// It could set it to any value at all, or take some other action.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [GISharp.Runtime.GSignalAttribute("change-state", When = GISharp.Runtime.EmissionStage.Last)]
        public event System.EventHandler<ChangedStateEventArgs> ChangedState { add => changedStateSignalManager.Add(this, value); remove => changedStateSignalManager.Remove(value); }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_simple_action_get_type();

        /// <summary>
        /// Sets the action as enabled or not.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// 
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to modify its enabled flag.
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="enabled">
        /// whether the action is enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_simple_action_set_enabled(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean enabled);

        /// <summary>
        /// Sets the action as enabled or not.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// 
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to modify its enabled flag.
        /// </remarks>
        /// <param name="enabled">
        /// whether the action is enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public unsafe void SetEnabled(System.Boolean enabled)
        {
            var simple_ = Handle;
            var enabled_ = (GISharp.Runtime.Boolean)enabled;
            g_simple_action_set_enabled(simple_, enabled_);
        }

        /// <summary>
        /// Sets the state of the action.
        /// </summary>
        /// <remarks>
        /// This directly updates the 'state' property to the given value.
        /// 
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to directly modify the 'state'
        /// property.  Instead, they should call g_action_change_state() to
        /// request the change.
        /// 
        /// If the @value GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="value">
        /// the new #GVariant for the state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_simple_action_set_state(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Sets the state of the action.
        /// </summary>
        /// <remarks>
        /// This directly updates the 'state' property to the given value.
        /// 
        /// This should only be called by the implementor of the action.  Users
        /// of the action should not attempt to directly modify the 'state'
        /// property.  Instead, they should call <see cref="Action.ChangeState"/> to
        /// request the change.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="value">
        /// the new #GVariant for the state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        public unsafe void SetState(GISharp.Lib.GLib.Variant value)
        {
            var simple_ = Handle;
            var value_ = value.Handle;
            g_simple_action_set_state(simple_, value_);
        }

        /// <summary>
        /// Sets the state hint for the action.
        /// </summary>
        /// <remarks>
        /// See g_action_get_state_hint() for more information about
        /// action state hints.
        /// </remarks>
        /// <param name="simple">
        /// a #GSimpleAction
        /// </param>
        /// <param name="stateHint">
        /// a #GVariant representing the state hint
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_simple_action_set_state_hint(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr stateHint);

        /// <summary>
        /// Sets the state hint for the action.
        /// </summary>
        /// <remarks>
        /// See <see cref="Action.GetStateHint"/> for more information about
        /// action state hints.
        /// </remarks>
        /// <param name="stateHint">
        /// a #GVariant representing the state hint
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public unsafe void SetStateHint(GISharp.Lib.GLib.Variant? stateHint)
        {
            var simple_ = Handle;
            var stateHint_ = stateHint?.Handle ?? System.IntPtr.Zero;
            g_simple_action_set_state_hint(simple_, stateHint_);
        }

        void GISharp.Lib.Gio.IAction.DoActivate(GISharp.Lib.GLib.Variant? parameter)
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.IAction.DoChangeState(GISharp.Lib.GLib.Variant value)
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.IAction.DoGetEnabled()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.UnownedUtf8 GISharp.Lib.Gio.IAction.DoGetName()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType? GISharp.Lib.Gio.IAction.DoGetParameterType()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IAction.DoGetState()
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