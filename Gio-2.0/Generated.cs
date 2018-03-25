namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="IAction"/> represents a single named action.
    /// </summary>
    /// <remarks>
    /// The main interface to an action is that it can be activated with
    /// <see cref="Activate"/>.  This results in the 'activate' signal being
    /// emitted.  An activation has a #GVariant parameter (which may be
    /// <c>null</c>).  The correct type for the parameter is determined by a static
    /// parameter type (which is given at construction time).
    /// 
    /// An action may optionally have a state, in which case the state may be
    /// set with <see cref="ChangeState"/>.  This call takes a #GVariant.  The
    /// correct type for the state is determined by a static state type
    /// (which is given at construction time).
    /// 
    /// The state may have a hint associated with it, specifying its valid
    /// range.
    /// 
    /// <see cref="IAction"/> is merely the interface to the concept of an action, as
    /// described above.  Various implementations of actions exist, including
    /// <see cref="SimpleAction"/>.
    /// 
    /// In all cases, the implementing class is responsible for storing the
    /// name of the action, the parameter type, the enabled state, the
    /// optional state type and the state and emitting the appropriate
    /// signals when these change.  The implementor is responsible for filtering
    /// calls to <see cref="Activate"/> and <see cref="ChangeState"/> for type
    /// safety and for the state being enabled.
    /// 
    /// Probably the only useful thing to do with a <see cref="IAction"/> is to put it
    /// inside of a <see cref="SimpleAction"/>Group.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GAction", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ActionInterface))]
    public partial interface IAction : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// If <paramref name="action"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// If the action is disabled then calls to <see cref="Activate"/> and
        /// <see cref="ChangeState"/> have no effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        System.Boolean Enabled { get; }

        /// <summary>
        /// The name of the action.  This is mostly meaningful for identifying
        /// the action once it has been added to a <see cref="IActionGroup"/>. It is immutable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name")]
        GISharp.Lib.GLib.Utf8 Name { get; }

        /// <summary>
        /// The type of the parameter that must be given when activating the
        /// action. This is immutable, and may be <c>null</c> if no parameter is needed when
        /// activating the action.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type")]
        GISharp.Lib.GLib.VariantType ParameterType { get; }

        /// <summary>
        /// The state of the action, or <c>null</c> if the action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state")]
        GISharp.Lib.GLib.Variant State { get; }

        /// <summary>
        /// The #GVariantType of the state that the action has, or <c>null</c> if the
        /// action is stateless. This is immutable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        GISharp.Lib.GLib.VariantType StateType { get; }

        /// <summary>
        /// Activates the action.
        /// </summary>
        /// <remarks>
        /// <paramref name="parameter"/> must be the correct type of parameter for the action (ie:
        /// the parameter type given at construction time).  If the parameter
        /// type was <c>null</c> then <paramref name="parameter"/> must also be <c>null</c>.
        /// 
        /// If the <paramref name="parameter"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedActivate))]
        void DoActivate(GISharp.Lib.GLib.Variant parameter);

        /// <summary>
        /// Request for the state of <paramref name="action"/> to be changed to <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and <paramref name="value"/> must be of the correct type.
        /// See <see cref="GetStateType"/>.
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than <paramref name="value"/>.
        /// See <see cref="GetStateHint"/>.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedChangeState))]
        void DoChangeState(GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Checks if <paramref name="action"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetEnabled))]
        System.Boolean DoGetEnabled();

        /// <summary>
        /// Queries the name of <paramref name="action"/>.
        /// </summary>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetName))]
        GISharp.Lib.GLib.Utf8 DoGetName();

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// When activating the action using <see cref="Activate"/>, the #GVariant
        /// given to that function must be of the type returned by this function.
        /// 
        /// In the case that this function returns <c>null</c>, you must not give any
        /// #GVariant, but <c>null</c> instead.
        /// </remarks>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetParameterType))]
        GISharp.Lib.GLib.VariantType DoGetParameterType();

        /// <summary>
        /// Queries the current state of <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then <c>null</c> will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by <see cref="GetStateType"/>.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetState))]
        GISharp.Lib.GLib.Variant DoGetState();

        /// <summary>
        /// Requests a hint about the valid range of values for the state of
        /// <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c> is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetStateHint))]
        GISharp.Lib.GLib.Variant DoGetStateHint();

        /// <summary>
        /// Queries the type of the state of <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If the action is stateful (e.g. created with
        /// <see cref="NewStateful"/>) then this function returns the
        /// #GVariantType of the state.  This is the type of the initial value
        /// given as the state. All calls to <see cref="ChangeState"/> must give a
        /// #GVariant of this type and <see cref="GetState"/> will return a
        /// #GVariant of the same type.
        /// 
        /// If the action is not stateful (e.g. created with <see cref="New"/>)
        /// then this function will return <c>null</c>. In that case, <see cref="GetState"/>
        /// will return <c>null</c> and you must not call <see cref="ChangeState"/>.
        /// </remarks>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetStateType))]
        GISharp.Lib.GLib.VariantType DoGetStateType();
    }

    public static class Action
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_action_get_type();

        /// <summary>
        /// Checks if @action_name is valid.
        /// </summary>
        /// <remarks>
        /// @action_name is valid if it consists only of alphanumeric characters,
        /// plus '-' and '.'.  The empty string is not a valid action name.
        /// 
        /// It is an error to call this function with a non-utf8 @action_name.
        /// @action_name must not be %NULL.
        /// </remarks>
        /// <param name="actionName">
        /// an potential action name
        /// </param>
        /// <returns>
        /// %TRUE if @action_name is valid
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_name_is_valid(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Checks if <paramref name="actionName"/> is valid.
        /// </summary>
        /// <remarks>
        /// <paramref name="actionName"/> is valid if it consists only of alphanumeric characters,
        /// plus '-' and '.'.  The empty string is not a valid action name.
        /// 
        /// It is an error to call this function with a non-utf8 <paramref name="actionName"/>.
        /// <paramref name="actionName"/> must not be <c>null</c>.
        /// </remarks>
        /// <param name="actionName">
        /// an potential action name
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="actionName"/> is valid
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static System.Boolean NameIsValid(GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_name_is_valid(actionName_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Parses a detailed action name into its separate name and target
        /// components.
        /// </summary>
        /// <remarks>
        /// Detailed action names can have three formats.
        /// 
        /// The first format is used to represent an action name with no target
        /// value and consists of just an action name containing no whitespace
        /// nor the characters ':', '(' or ')'.  For example: "app.action".
        /// 
        /// The second format is used to represent an action with a target value
        /// that is a non-empty string consisting only of alphanumerics, plus '-'
        /// and '.'.  In that case, the action name and target value are
        /// separated by a double colon ("::").  For example:
        /// "app.action::target".
        /// 
        /// The third format is used to represent an action with any type of
        /// target value, including strings.  The target value follows the action
        /// name, surrounded in parens.  For example: "app.action(42)".  The
        /// target value is parsed using g_variant_parse().  If a tuple-typed
        /// value is desired, it must be specified in the same way, resulting in
        /// two sets of parens, for example: "app.action((1,2,3))".  A string
        /// target can be specified this way as well: "app.action('target')".
        /// For strings, this third format must be used if * target value is
        /// empty or contains characters other than alphanumerics, '-' and '.'.
        /// </remarks>
        /// <param name="detailedName">
        /// a detailed action name
        /// </param>
        /// <param name="actionName">
        /// the action name
        /// </param>
        /// <param name="targetValue">
        /// the target value, or %NULL for no target
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_action_parse_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr detailedName,
        /* <type name="utf8" type="gchar**" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr targetValue,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Parses a detailed action name into its separate name and target
        /// components.
        /// </summary>
        /// <remarks>
        /// Detailed action names can have three formats.
        /// 
        /// The first format is used to represent an action name with no target
        /// value and consists of just an action name containing no whitespace
        /// nor the characters ':', '(' or ')'.  For example: "app.action".
        /// 
        /// The second format is used to represent an action with a target value
        /// that is a non-empty string consisting only of alphanumerics, plus '-'
        /// and '.'.  In that case, the action name and target value are
        /// separated by a double colon ("::").  For example:
        /// "app.action::target".
        /// 
        /// The third format is used to represent an action with any type of
        /// target value, including strings.  The target value follows the action
        /// name, surrounded in parens.  For example: "app.action(42)".  The
        /// target value is parsed using g_variant_parse().  If a tuple-typed
        /// value is desired, it must be specified in the same way, resulting in
        /// two sets of parens, for example: "app.action((1,2,3))".  A string
        /// target can be specified this way as well: "app.action('target')".
        /// For strings, this third format must be used if * target value is
        /// empty or contains characters other than alphanumerics, '-' and '.'.
        /// </remarks>
        /// <param name="detailedName">
        /// a detailed action name
        /// </param>
        /// <param name="actionName">
        /// the action name
        /// </param>
        /// <param name="targetValue">
        /// the target value, or <c>null</c> for no target
        /// </param>
        /// <returns>
        /// <c>true</c> if successful, else <c>false</c> with <paramref name="error"/> set
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static void ParseDetailedName(GISharp.Lib.GLib.Utf8 detailedName, out GISharp.Lib.GLib.Utf8 actionName, out GISharp.Lib.GLib.Variant targetValue)
        {
            var detailedName_ = detailedName?.Handle ?? throw new System.ArgumentNullException(nameof(detailedName));
            var error_ = System.IntPtr.Zero;
            g_action_parse_detailed_name(detailedName_,out var actionName_,out var targetValue_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.Full);
            targetValue = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(targetValue_, GISharp.Runtime.Transfer.Full);
        }

        /// <summary>
        /// Formats a detailed action name from @action_name and @target_value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with an invalid action name.
        /// 
        /// This function is the opposite of g_action_parse_detailed_name().
        /// It will produce a string that can be parsed back to the @action_name
        /// and @target_value by that function.
        /// 
        /// See that function for the types of strings that will be printed by
        /// this function.
        /// </remarks>
        /// <param name="actionName">
        /// a valid action name
        /// </param>
        /// <param name="targetValue">
        /// a #GVariant target value, or %NULL
        /// </param>
        /// <returns>
        /// a detailed format string
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_print_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr targetValue);

        /// <summary>
        /// Formats a detailed action name from <paramref name="actionName"/> and <paramref name="targetValue"/>.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with an invalid action name.
        /// 
        /// This function is the opposite of <see cref="ParseDetailedName"/>.
        /// It will produce a string that can be parsed back to the <paramref name="actionName"/>
        /// and <paramref name="targetValue"/> by that function.
        /// 
        /// See that function for the types of strings that will be printed by
        /// this function.
        /// </remarks>
        /// <param name="actionName">
        /// a valid action name
        /// </param>
        /// <param name="targetValue">
        /// a #GVariant target value, or <c>null</c>
        /// </param>
        /// <returns>
        /// a detailed format string
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Lib.GLib.Utf8 PrintDetailedName(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant targetValue)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var targetValue_ = targetValue?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_action_print_detailed_name(actionName_,targetValue_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_action_get_type();

        /// <summary>
        /// Activates the action.
        /// </summary>
        /// <remarks>
        /// @parameter must be the correct type of parameter for the action (ie:
        /// the parameter type given at construction time).  If the parameter
        /// type was %NULL then @parameter must also be %NULL.
        /// 
        /// If the @parameter GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_activate(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameter);

        /// <summary>
        /// Activates the action.
        /// </summary>
        /// <remarks>
        /// <paramref name="parameter"/> must be the correct type of parameter for the action (ie:
        /// the parameter type given at construction time).  If the parameter
        /// type was <c>null</c> then <paramref name="parameter"/> must also be <c>null</c>.
        /// 
        /// If the <paramref name="parameter"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void Activate(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant parameter)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var parameter_ = parameter?.Handle ?? System.IntPtr.Zero;
            g_action_activate(action_, parameter_);
        }

        /// <summary>
        /// Request for the state of @action to be changed to @value.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and @value must be of the correct type.
        /// See g_action_get_state_type().
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than @value.
        /// See g_action_get_state_hint().
        /// 
        /// If the @value GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_change_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Request for the state of <paramref name="action"/> to be changed to <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and <paramref name="value"/> must be of the correct type.
        /// See <see cref="GetStateType"/>.
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than <paramref name="value"/>.
        /// See <see cref="GetStateHint"/>.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        public static void ChangeState(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant value)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_action_change_state(action_, value_);
        }

        /// <summary>
        /// Checks if @action is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_get_enabled(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Checks if <paramref name="action"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static System.Boolean GetEnabled(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_enabled(action_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Queries the name of @action.
        /// </summary>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_action_get_name(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Queries the name of <paramref name="action"/>.
        /// </summary>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Utf8 GetName(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_name(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// @action.
        /// </summary>
        /// <remarks>
        /// When activating the action using g_action_activate(), the #GVariant
        /// given to that function must be of the type returned by this function.
        /// 
        /// In the case that this function returns %NULL, you must not give any
        /// #GVariant, but %NULL instead.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_get_parameter_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// When activating the action using <see cref="Activate"/>, the #GVariant
        /// given to that function must be of the type returned by this function.
        /// 
        /// In the case that this function returns <c>null</c>, you must not give any
        /// #GVariant, but <c>null</c> instead.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType GetParameterType(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_parameter_type(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Queries the current state of @action.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then %NULL will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by g_action_get_state_type().
        /// 
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_get_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Queries the current state of <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then <c>null</c> will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by <see cref="GetStateType"/>.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant GetState(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Requests a hint about the valid range of values for the state of
        /// @action.
        /// </summary>
        /// <remarks>
        /// If %NULL is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_get_state_hint(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Requests a hint about the valid range of values for the state of
        /// <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c> is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant GetStateHint(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state_hint(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries the type of the state of @action.
        /// </summary>
        /// <remarks>
        /// If the action is stateful (e.g. created with
        /// g_simple_action_new_stateful()) then this function returns the
        /// #GVariantType of the state.  This is the type of the initial value
        /// given as the state. All calls to g_action_change_state() must give a
        /// #GVariant of this type and g_action_get_state() will return a
        /// #GVariant of the same type.
        /// 
        /// If the action is not stateful (e.g. created with g_simple_action_new())
        /// then this function will return %NULL. In that case, g_action_get_state()
        /// will return %NULL and you must not call g_action_change_state().
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_get_state_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Queries the type of the state of <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If the action is stateful (e.g. created with
        /// <see cref="NewStateful"/>) then this function returns the
        /// #GVariantType of the state.  This is the type of the initial value
        /// given as the state. All calls to <see cref="ChangeState"/> must give a
        /// #GVariant of this type and <see cref="GetState"/> will return a
        /// #GVariant of the same type.
        /// 
        /// If the action is not stateful (e.g. created with <see cref="New"/>)
        /// then this function will return <c>null</c>. In that case, <see cref="GetState"/>
        /// will return <c>null</c> and you must not call <see cref="ChangeState"/>.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType GetStateType(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state_type(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }

    /// <summary>
    /// <see cref="IActionGroup"/> represents a group of actions. Actions can be used to
    /// expose functionality in a structured way, either from one part of a
    /// program to another, or to the outside world. Action groups are often
    /// used together with a #GMenuModel that provides additional
    /// representation data for displaying the actions to the user, e.g. in
    /// a menu.
    /// </summary>
    /// <remarks>
    /// The main way to interact with the actions in a GActionGroup is to
    /// activate them with <see cref="ActivateAction"/>. Activating an
    /// action may require a #GVariant parameter. The required type of the
    /// parameter can be inquired with <see cref="GetActionParameterType"/>.
    /// Actions may be disabled, see <see cref="GetActionEnabled"/>.
    /// Activating a disabled action has no effect.
    /// 
    /// Actions may optionally have a state in the form of a #GVariant. The
    /// current state of an action can be inquired with
    /// <see cref="GetActionState"/>. Activating a stateful action may
    /// change its state, but it is also possible to set the state by calling
    /// <see cref="ChangeActionState"/>.
    /// 
    /// As typical example, consider a text editing application which has an
    /// option to change the current font to 'bold'. A good way to represent
    /// this would be a stateful action, with a boolean state. Activating the
    /// action would toggle the state.
    /// 
    /// Each action in the group has a unique name (which is a string).  All
    /// method calls, except <see cref="ListActions"/> take the name of
    /// an action as an argument.
    /// 
    /// The <see cref="IActionGroup"/> API is meant to be the 'public' API to the action
    /// group.  The calls here are exactly the interaction that 'external
    /// forces' (eg: UI, incoming D-Bus messages, etc.) are supposed to have
    /// with actions.  'Internal' APIs (ie: ones meant only to be accessed by
    /// the action group implementation) are found on subclasses.  This is
    /// why you will find - for example - <see cref="GetActionEnabled"/>
    /// but not an equivalent set() call.
    /// 
    /// Signals are emitted on the action group in response to state changes
    /// on individual actions.
    /// 
    /// Implementations of <see cref="IActionGroup"/> should provide implementations for
    /// the virtual functions <see cref="ListActions"/> and
    /// <see cref="TryQueryAction"/>.  The other virtual functions should
    /// not be implemented - their "wrappers" are actually implemented with
    /// calls to <see cref="TryQueryAction"/>.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GActionGroup", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ActionGroupInterface))]
    public partial interface IActionGroup : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Signals that a new action was just added to the group.
        /// This signal is emitted after the action has been added
        /// and is now visible.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-added", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<ActionGroup.ActionAddedEventArgs> ActionAdded;

        /// <summary>
        /// Signals that the enabled status of the named action has changed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-enabled-changed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<ActionGroup.ActionEnabledChangedEventArgs> ActionEnabledChanged;

        /// <summary>
        /// Signals that an action is just about to be removed from the group.
        /// This signal is emitted before the action is removed, so the action
        /// is still visible and can be queried from the signal handler.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-removed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<ActionGroup.ActionRemovedEventArgs> ActionRemoved;

        /// <summary>
        /// Signals that the state of the named action has changed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-state-changed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<ActionGroup.ActionStateChangedEventArgs> ActionStateChanged;

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-added signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedActionAdded))]
        void DoActionAdded(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-enabled-changed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// whether or not the action is now enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedActionEnabledChanged))]
        void DoActionEnabledChanged(GISharp.Lib.GLib.Utf8 actionName, System.Boolean enabled);

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-removed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedActionRemoved))]
        void DoActionRemoved(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-state-changed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="state">
        /// the new state of the named action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedActionStateChanged))]
        void DoActionStateChanged(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant state);

        /// <summary>
        /// Activate the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is expecting a parameter, then the correct type of
        /// parameter must be given as <paramref name="parameter"/>.  If the action is expecting no
        /// parameters then <paramref name="parameter"/> must be <c>null</c>.  See
        /// <see cref="GetActionParameterType"/>.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to activate
        /// </param>
        /// <param name="parameter">
        /// parameters to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedActivateAction))]
        void DoActivateAction(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant parameter);

        /// <summary>
        /// Request for the state of the named action within <paramref name="actionGroup"/> to be
        /// changed to <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and <paramref name="value"/> must be of the correct type.
        /// See <see cref="GetActionStateType"/>.
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than <paramref name="value"/>.
        /// See <see cref="GetActionStateHint"/>.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to request the change on
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedChangeActionState))]
        void DoChangeActionState(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Checks if the named action within <paramref name="actionGroup"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// whether or not the action is currently enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedGetActionEnabled))]
        System.Boolean DoGetActionEnabled(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// When activating the action using <see cref="ActivateAction"/>,
        /// the #GVariant given to that function must be of the type returned
        /// by this function.
        /// 
        /// In the case that this function returns <c>null</c>, you must not give any
        /// #GVariant, but <c>null</c> instead.
        /// 
        /// The parameter type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different parameter type.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedGetActionParameterType))]
        GISharp.Lib.GLib.VariantType DoGetActionParameterType(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Queries the current state of the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then <c>null</c> will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by <see cref="GetActionStateType"/>.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedGetActionState))]
        GISharp.Lib.GLib.Variant DoGetActionState(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Requests a hint about the valid range of values for the state of the
        /// named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c> is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedGetActionStateHint))]
        GISharp.Lib.GLib.Variant DoGetActionStateHint(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Queries the type of the state of the named action within
        /// <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is stateful then this function returns the
        /// #GVariantType of the state.  All calls to
        /// <see cref="ChangeActionState"/> must give a #GVariant of this
        /// type and <see cref="GetActionState"/> will return a #GVariant
        /// of the same type.
        /// 
        /// If the action is not stateful then this function will return <c>null</c>.
        /// In that case, <see cref="GetActionState"/> will return <c>null</c>
        /// and you must not call <see cref="ChangeActionState"/>.
        /// 
        /// The state type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different state type.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedGetActionStateType))]
        GISharp.Lib.GLib.VariantType DoGetActionStateType(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Checks if the named action exists within <paramref name="actionGroup"/>.
        /// </summary>
        /// <param name="actionName">
        /// the name of the action to check for
        /// </param>
        /// <returns>
        /// whether the named action exists
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedHasAction))]
        System.Boolean DoHasAction(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Lists the actions contained within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// The caller is responsible for freeing the list with g_strfreev() when
        /// it is no longer required.
        /// </remarks>
        /// <returns>
        /// a <c>null</c>-terminated array of the names of the
        /// actions in the group
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionGroupInterface.UnmanagedListActions))]
        GISharp.Lib.GLib.Strv DoListActions();
    }

    public static class ActionGroup
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_action_group_get_type();

        public sealed class ActionAddedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Utf8 ActionName => (GISharp.Lib.GLib.Utf8)args[1].Get();

            public ActionAddedEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        public sealed class ActionEnabledChangedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Utf8 ActionName => (GISharp.Lib.GLib.Utf8)args[1].Get();

            public System.Boolean Enabled => (System.Boolean)args[2].Get();

            public ActionEnabledChangedEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        public sealed class ActionRemovedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Utf8 ActionName => (GISharp.Lib.GLib.Utf8)args[1].Get();

            public ActionRemovedEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        public sealed class ActionStateChangedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Utf8 ActionName => (GISharp.Lib.GLib.Utf8)args[1].Get();

            public GISharp.Lib.GLib.Variant Value => (GISharp.Lib.GLib.Variant)args[2].Get();

            public ActionStateChangedEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_action_group_get_type();

        /// <summary>
        /// Emits the #GActionGroup::action-added signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_added(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-added signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ActionAdded(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            g_action_group_action_added(actionGroup_, actionName_);
        }

        /// <summary>
        /// Emits the #GActionGroup::action-enabled-changed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// whether or not the action is now enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_enabled_changed(
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
        /// Emits the <see cref="IActionGroup"/>::action-enabled-changed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// whether or not the action is now enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ActionEnabledChanged(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, System.Boolean enabled)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var enabled_ = (System.Boolean)enabled;
            g_action_group_action_enabled_changed(actionGroup_, actionName_, enabled_);
        }

        /// <summary>
        /// Emits the #GActionGroup::action-removed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_removed(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Emits the <see cref="IActionGroup"/>::action-removed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ActionRemoved(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            g_action_group_action_removed(actionGroup_, actionName_);
        }

        /// <summary>
        /// Emits the #GActionGroup::action-state-changed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="state">
        /// the new state of the named action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_state_changed(
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
        /// Emits the <see cref="IActionGroup"/>::action-state-changed signal on <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function should only be called by <see cref="IActionGroup"/> implementations.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="state">
        /// the new state of the named action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ActionStateChanged(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant state)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var state_ = state?.Handle ?? throw new System.ArgumentNullException(nameof(state));
            g_action_group_action_state_changed(actionGroup_, actionName_, state_);
        }

        /// <summary>
        /// Activate the named action within @action_group.
        /// </summary>
        /// <remarks>
        /// If the action is expecting a parameter, then the correct type of
        /// parameter must be given as @parameter.  If the action is expecting no
        /// parameters then @parameter must be %NULL.  See
        /// g_action_group_get_action_parameter_type().
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to activate
        /// </param>
        /// <param name="parameter">
        /// parameters to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_activate_action(
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
        /// Activate the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is expecting a parameter, then the correct type of
        /// parameter must be given as <paramref name="parameter"/>.  If the action is expecting no
        /// parameters then <paramref name="parameter"/> must be <c>null</c>.  See
        /// <see cref="GetActionParameterType"/>.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to activate
        /// </param>
        /// <param name="parameter">
        /// parameters to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ActivateAction(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant parameter)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var parameter_ = parameter?.Handle ?? System.IntPtr.Zero;
            g_action_group_activate_action(actionGroup_, actionName_, parameter_);
        }

        /// <summary>
        /// Request for the state of the named action within @action_group to be
        /// changed to @value.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and @value must be of the correct type.
        /// See g_action_group_get_action_state_type().
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than @value.
        /// See g_action_group_get_action_state_hint().
        /// 
        /// If the @value GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to request the change on
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_change_action_state(
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
        /// Request for the state of the named action within <paramref name="actionGroup"/> to be
        /// changed to <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// The action must be stateful and <paramref name="value"/> must be of the correct type.
        /// See <see cref="GetActionStateType"/>.
        /// 
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than <paramref name="value"/>.
        /// See <see cref="GetActionStateHint"/>.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to request the change on
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void ChangeActionState(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant value)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_action_group_change_action_state(actionGroup_, actionName_, value_);
        }

        /// <summary>
        /// Checks if the named action within @action_group is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// whether or not the action is currently enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_get_action_enabled(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Checks if the named action within <paramref name="actionGroup"/> is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// whether or not the action is currently enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static System.Boolean GetActionEnabled(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_enabled(actionGroup_,actionName_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// the named action within @action_group.
        /// </summary>
        /// <remarks>
        /// When activating the action using g_action_group_activate_action(),
        /// the #GVariant given to that function must be of the type returned
        /// by this function.
        /// 
        /// In the case that this function returns %NULL, you must not give any
        /// #GVariant, but %NULL instead.
        /// 
        /// The parameter type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different parameter type.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_parameter_type(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// When activating the action using <see cref="ActivateAction"/>,
        /// the #GVariant given to that function must be of the type returned
        /// by this function.
        /// 
        /// In the case that this function returns <c>null</c>, you must not give any
        /// #GVariant, but <c>null</c> instead.
        /// 
        /// The parameter type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different parameter type.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType GetActionParameterType(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_parameter_type(actionGroup_,actionName_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Queries the current state of the named action within @action_group.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then %NULL will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by g_action_group_get_action_state_type().
        /// 
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Queries the current state of the named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is not stateful then <c>null</c> will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by <see cref="GetActionStateType"/>.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant GetActionState(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_state(actionGroup_,actionName_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Requests a hint about the valid range of values for the state of the
        /// named action within @action_group.
        /// </summary>
        /// <remarks>
        /// If %NULL is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state_hint(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Requests a hint about the valid range of values for the state of the
        /// named action within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c> is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// 
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// 
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// 
        /// The return value (if non-<c>null</c>) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant GetActionStateHint(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_state_hint(actionGroup_,actionName_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries the type of the state of the named action within
        /// @action_group.
        /// </summary>
        /// <remarks>
        /// If the action is stateful then this function returns the
        /// #GVariantType of the state.  All calls to
        /// g_action_group_change_action_state() must give a #GVariant of this
        /// type and g_action_group_get_action_state() will return a #GVariant
        /// of the same type.
        /// 
        /// If the action is not stateful then this function will return %NULL.
        /// In that case, g_action_group_get_action_state() will return %NULL
        /// and you must not call g_action_group_change_action_state().
        /// 
        /// The state type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different state type.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state_type(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Queries the type of the state of the named action within
        /// <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// If the action is stateful then this function returns the
        /// #GVariantType of the state.  All calls to
        /// <see cref="ChangeActionState"/> must give a #GVariant of this
        /// type and <see cref="GetActionState"/> will return a #GVariant
        /// of the same type.
        /// 
        /// If the action is not stateful then this function will return <c>null</c>.
        /// In that case, <see cref="GetActionState"/> will return <c>null</c>
        /// and you must not call <see cref="ChangeActionState"/>.
        /// 
        /// The state type of a particular action will never change but it is
        /// possible for an action to be removed and for a new action to be added
        /// with the same name but a different state type.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType GetActionStateType(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_state_type(actionGroup_,actionName_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Checks if the named action exists within @action_group.
        /// </summary>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of the action to check for
        /// </param>
        /// <returns>
        /// whether the named action exists
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_has_action(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Checks if the named action exists within <paramref name="actionGroup"/>.
        /// </summary>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action to check for
        /// </param>
        /// <returns>
        /// whether the named action exists
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static System.Boolean HasAction(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_has_action(actionGroup_,actionName_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Lists the actions contained within @action_group.
        /// </summary>
        /// <remarks>
        /// The caller is responsible for freeing the list with g_strfreev() when
        /// it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <returns>
        /// a %NULL-terminated array of the names of the
        /// actions in the group
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_group_list_actions(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup);

        /// <summary>
        /// Lists the actions contained within <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// The caller is responsible for freeing the list with g_strfreev() when
        /// it is no longer required.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <returns>
        /// a <c>null</c>-terminated array of the names of the
        /// actions in the group
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Strv ListActions(this GISharp.Lib.Gio.IActionGroup actionGroup)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var ret_ = g_action_group_list_actions(actionGroup_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries all aspects of the named action within an @action_group.
        /// </summary>
        /// <remarks>
        /// This function acquires the information available from
        /// g_action_group_has_action(), g_action_group_get_action_enabled(),
        /// g_action_group_get_action_parameter_type(),
        /// g_action_group_get_action_state_type(),
        /// g_action_group_get_action_state_hint() and
        /// g_action_group_get_action_state() with a single function call.
        /// 
        /// This provides two main benefits.
        /// 
        /// The first is the improvement in efficiency that comes with not having
        /// to perform repeated lookups of the action in order to discover
        /// different things about it.  The second is that implementing
        /// #GActionGroup can now be done by only overriding this one virtual
        /// function.
        /// 
        /// The interface provides a default implementation of this function that
        /// calls the individual functions, as required, to fetch the
        /// information.  The interface also provides default implementations of
        /// those functions that call this function.  All implementations,
        /// therefore, must override either this function or all of the others.
        /// 
        /// If the action exists, %TRUE is returned and any of the requested
        /// fields (as indicated by having a non-%NULL reference passed in) are
        /// filled.  If the action doesn't exist, %FALSE is returned and the
        /// fields may or may not have been modified.
        /// </remarks>
        /// <param name="actionGroup">
        /// a #GActionGroup
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// if the action is presently enabled
        /// </param>
        /// <param name="parameterType">
        /// the parameter type, or %NULL if none needed
        /// </param>
        /// <param name="stateType">
        /// the state type, or %NULL if stateless
        /// </param>
        /// <param name="stateHint">
        /// the state hint, or %NULL if none
        /// </param>
        /// <param name="state">
        /// the current state, or %NULL if stateless
        /// </param>
        /// <returns>
        /// %TRUE if the action exists, else %FALSE
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_query_action(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="gboolean" type="gboolean*" managed-name="System.Boolean" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.Boolean enabled,
        /* <type name="GLib.VariantType" type="const GVariantType**" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr parameterType,
        /* <type name="GLib.VariantType" type="const GVariantType**" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr stateType,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr stateHint,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr state);

        /// <summary>
        /// Queries all aspects of the named action within an <paramref name="actionGroup"/>.
        /// </summary>
        /// <remarks>
        /// This function acquires the information available from
        /// <see cref="HasAction"/>, <see cref="GetActionEnabled"/>,
        /// <see cref="GetActionParameterType"/>,
        /// <see cref="GetActionStateType"/>,
        /// <see cref="GetActionStateHint"/> and
        /// <see cref="GetActionState"/> with a single function call.
        /// 
        /// This provides two main benefits.
        /// 
        /// The first is the improvement in efficiency that comes with not having
        /// to perform repeated lookups of the action in order to discover
        /// different things about it.  The second is that implementing
        /// <see cref="IActionGroup"/> can now be done by only overriding this one virtual
        /// function.
        /// 
        /// The interface provides a default implementation of this function that
        /// calls the individual functions, as required, to fetch the
        /// information.  The interface also provides default implementations of
        /// those functions that call this function.  All implementations,
        /// therefore, must override either this function or all of the others.
        /// 
        /// If the action exists, <c>true</c> is returned and any of the requested
        /// fields (as indicated by having a non-<c>null</c> reference passed in) are
        /// filled.  If the action doesn't exist, <c>false</c> is returned and the
        /// fields may or may not have been modified.
        /// </remarks>
        /// <param name="actionGroup">
        /// a <see cref="IActionGroup"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// if the action is presently enabled
        /// </param>
        /// <param name="parameterType">
        /// the parameter type, or <c>null</c> if none needed
        /// </param>
        /// <param name="stateType">
        /// the state type, or <c>null</c> if stateless
        /// </param>
        /// <param name="stateHint">
        /// the state hint, or <c>null</c> if none
        /// </param>
        /// <param name="state">
        /// the current state, or <c>null</c> if stateless
        /// </param>
        /// <returns>
        /// <c>true</c> if the action exists, else <c>false</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static System.Boolean TryQueryAction(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, out System.Boolean enabled, out GISharp.Lib.GLib.VariantType parameterType, out GISharp.Lib.GLib.VariantType stateType, out GISharp.Lib.GLib.Variant stateHint, out GISharp.Lib.GLib.Variant state)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_query_action(actionGroup_,actionName_,out var enabled_,out var parameterType_,out var stateType_,out var stateHint_,out var state_);
            enabled = (System.Boolean)enabled_;
            parameterType = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(parameterType_, GISharp.Runtime.Transfer.Full);
            stateType = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(stateType_, GISharp.Runtime.Transfer.Full);
            stateHint = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(stateHint_, GISharp.Runtime.Transfer.Full);
            state = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(state_, GISharp.Runtime.Transfer.Full);
            var ret = (System.Boolean)ret_;
            return ret;
        }
    }

    /// <summary>
    /// The virtual function table for <see cref="IActionGroup"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionGroupInterface : GISharp.Lib.GObject.TypeInterface
    {
        new struct Struct
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
        public delegate System.Boolean UnmanagedHasAction(
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
            public static UnmanagedHasAction Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedListActions(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup);

        /// <summary>
        /// Factory for creating <see cref="ListActions"/> methods.
        /// </summary>
        public static class ListActionsFactory
        {
            public static UnmanagedListActions Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.Boolean UnmanagedGetActionEnabled(
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
            public static UnmanagedGetActionEnabled Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetActionParameterType(
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
            public static UnmanagedGetActionParameterType Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetActionStateType(
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
            public static UnmanagedGetActionStateType Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetActionStateHint(
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
            public static UnmanagedGetActionStateHint Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetActionState(
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
            public static UnmanagedGetActionState Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedChangeActionState(
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
            public static UnmanagedChangeActionState Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActivateAction(
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
            public static UnmanagedActivateAction Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActionAdded(
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
            public static UnmanagedActionAdded Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActionRemoved(
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
            public static UnmanagedActionRemoved Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActionEnabledChanged(
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
            public static UnmanagedActionEnabledChanged Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActionStateChanged(
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
            public static UnmanagedActionStateChanged Create(System.Reflection.MethodInfo methodInfo)
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

    /// <summary>
    /// The virtual function table for <see cref="IAction"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionInterface : GISharp.Lib.GObject.TypeInterface
    {
        new struct Struct
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
        public delegate System.IntPtr UnmanagedGetName(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetName"/> methods.
        /// </summary>
        public static class GetNameFactory
        {
            public static UnmanagedGetName Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetParameterType"/> methods.
        /// </summary>
        public static class GetParameterTypeFactory
        {
            public static UnmanagedGetParameterType Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetStateType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetStateType"/> methods.
        /// </summary>
        public static class GetStateTypeFactory
        {
            public static UnmanagedGetStateType Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetStateHint"/> methods.
        /// </summary>
        public static class GetStateHintFactory
        {
            public static UnmanagedGetStateHint Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetEnabled"/> methods.
        /// </summary>
        public static class GetEnabledFactory
        {
            public static UnmanagedGetEnabled Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate System.IntPtr UnmanagedGetState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="GetState"/> methods.
        /// </summary>
        public static class GetStateFactory
        {
            public static UnmanagedGetState Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedChangeState(
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
            public static UnmanagedChangeState Create(System.Reflection.MethodInfo methodInfo)
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
        public delegate void UnmanagedActivate(
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
            public static UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
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

    /// <summary>
    /// The GActionMap interface is implemented by <see cref="IActionGroup"/>
    /// implementations that operate by containing a number of
    /// named <see cref="IAction"/> instances, such as #GSimpleActionGroup.
    /// </summary>
    /// <remarks>
    /// One useful application of this interface is to map the
    /// names of actions from various action groups to unique,
    /// prefixed names (e.g. by prepending "app." or "win.").
    /// This is the motivation for the 'Map' part of the interface
    /// name.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GActionMap", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ActionMapInterface))]
    public partial interface IActionMap : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Adds an action to the <paramref name="actionMap"/>.
        /// </summary>
        /// <remarks>
        /// If the action map already contains an action with the same name
        /// as <paramref name="action"/> then the old action is dropped from the action map.
        /// 
        /// The action map takes its own reference on <paramref name="action"/>.
        /// </remarks>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedAddAction))]
        void DoAddAction(GISharp.Lib.Gio.IAction action);

        /// <summary>
        /// Looks up the action with the name <paramref name="actionName"/> in <paramref name="actionMap"/>.
        /// </summary>
        /// <remarks>
        /// If no such action exists, returns <c>null</c>.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action
        /// </param>
        /// <returns>
        /// a <see cref="IAction"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedLookupAction))]
        GISharp.Lib.Gio.IAction DoLookupAction(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Removes the named action from the action map.
        /// </summary>
        /// <remarks>
        /// If no action of this name is in the map then nothing happens.
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedRemoveAction))]
        void DoRemoveAction(GISharp.Lib.GLib.Utf8 actionName);
    }

    public static class ActionMap
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_action_map_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_action_map_get_type();

        /// <summary>
        /// Adds an action to the @action_map.
        /// </summary>
        /// <remarks>
        /// If the action map already contains an action with the same name
        /// as @action then the old action is dropped from the action map.
        /// 
        /// The action map takes its own reference on @action.
        /// </remarks>
        /// <param name="actionMap">
        /// a #GActionMap
        /// </param>
        /// <param name="action">
        /// a #GAction
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_map_add_action(
        /* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionMap,
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

        /// <summary>
        /// Adds an action to the <paramref name="actionMap"/>.
        /// </summary>
        /// <remarks>
        /// If the action map already contains an action with the same name
        /// as <paramref name="action"/> then the old action is dropped from the action map.
        /// 
        /// The action map takes its own reference on <paramref name="action"/>.
        /// </remarks>
        /// <param name="actionMap">
        /// a <see cref="IActionMap"/>
        /// </param>
        /// <param name="action">
        /// a <see cref="IAction"/>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static void AddAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.Gio.IAction action)
        {
            var actionMap_ = actionMap?.Handle ?? throw new System.ArgumentNullException(nameof(actionMap));
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            g_action_map_add_action(actionMap_, action_);
        }

        /// <summary>
        /// Looks up the action with the name @action_name in @action_map.
        /// </summary>
        /// <remarks>
        /// If no such action exists, returns %NULL.
        /// </remarks>
        /// <param name="actionMap">
        /// a #GActionMap
        /// </param>
        /// <param name="actionName">
        /// the name of an action
        /// </param>
        /// <returns>
        /// a #GAction, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_action_map_lookup_action(
        /* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionMap,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Looks up the action with the name <paramref name="actionName"/> in <paramref name="actionMap"/>.
        /// </summary>
        /// <remarks>
        /// If no such action exists, returns <c>null</c>.
        /// </remarks>
        /// <param name="actionMap">
        /// a <see cref="IActionMap"/>
        /// </param>
        /// <param name="actionName">
        /// the name of an action
        /// </param>
        /// <returns>
        /// a <see cref="IAction"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static GISharp.Lib.Gio.IAction LookupAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionMap_ = actionMap?.Handle ?? throw new System.ArgumentNullException(nameof(actionMap));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_map_lookup_action(actionMap_,actionName_);
            var ret = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Removes the named action from the action map.
        /// </summary>
        /// <remarks>
        /// If no action of this name is in the map then nothing happens.
        /// </remarks>
        /// <param name="actionMap">
        /// a #GActionMap
        /// </param>
        /// <param name="actionName">
        /// the name of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_map_remove_action(
        /* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionMap,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

        /// <summary>
        /// Removes the named action from the action map.
        /// </summary>
        /// <remarks>
        /// If no action of this name is in the map then nothing happens.
        /// </remarks>
        /// <param name="actionMap">
        /// a <see cref="IActionMap"/>
        /// </param>
        /// <param name="actionName">
        /// the name of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static void RemoveAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionMap_ = actionMap?.Handle ?? throw new System.ArgumentNullException(nameof(actionMap));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            g_action_map_remove_action(actionMap_, actionName_);
        }
    }

    /// <summary>
    /// The virtual function table for <see cref="IActionMap"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.32")]
    public sealed class ActionMapInterface : GISharp.Lib.GObject.TypeInterface
    {
        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedLookupAction LookupAction;
            public UnmanagedAddAction AddAction;
            public UnmanagedRemoveAction RemoveAction;
#pragma warning restore CS0649
        }

        static ActionMapInterface()
        {
            System.Int32 lookupActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.LookupAction));
            RegisterVirtualMethod(lookupActionOffset, LookupActionFactory.Create);
            System.Int32 addActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.AddAction));
            RegisterVirtualMethod(addActionOffset, AddActionFactory.Create);
            System.Int32 removeActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.RemoveAction));
            RegisterVirtualMethod(removeActionOffset, RemoveActionFactory.Create);
        }

        public delegate GISharp.Lib.Gio.IAction LookupAction(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedLookupAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="LookupAction"/> methods.
        /// </summary>
        public static class LookupActionFactory
        {
            public static UnmanagedLookupAction Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr lookupAction(System.IntPtr actionMap_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doLookupAction = (LookupAction)methodInfo.CreateDelegate(typeof(LookupAction), actionMap);
                        var ret = doLookupAction(actionName);
                        var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return lookupAction;
            }
        }

        public delegate void AddAction(GISharp.Lib.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedAddAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        /// <summary>
        /// Factory for creating <see cref="AddAction"/> methods.
        /// </summary>
        public static class AddActionFactory
        {
            public static UnmanagedAddAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void addAction(System.IntPtr actionMap_, System.IntPtr action_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                        var doAddAction = (AddAction)methodInfo.CreateDelegate(typeof(AddAction), actionMap);
                        doAddAction(action);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return addAction;
            }
        }

        public delegate void RemoveAction(GISharp.Lib.GLib.Utf8 actionName);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedRemoveAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        /// <summary>
        /// Factory for creating <see cref="RemoveAction"/> methods.
        /// </summary>
        public static class RemoveActionFactory
        {
            public static UnmanagedRemoveAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void removeAction(System.IntPtr actionMap_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                        var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                        var doRemoveAction = (RemoveAction)methodInfo.CreateDelegate(typeof(RemoveAction), actionMap);
                        doRemoveAction(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return removeAction;
            }
        }

        public ActionMapInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    /// <summary>
    /// Flags used to define the behaviour of a #GApplication.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [GISharp.Runtime.GTypeAttribute("GApplicationFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum ApplicationFlags
    {
        /// <summary>
        /// Default
        /// </summary>
        FlagsNone = 0,
        /// <summary>
        /// Run as a service. In this mode, registration
        ///      fails if the service is already running, and the application
        ///      will initially wait up to 10 seconds for an initial activation
        ///      message to arrive.
        /// </summary>
        IsService = 1,
        /// <summary>
        /// Don't try to become the primary instance.
        /// </summary>
        IsLauncher = 2,
        /// <summary>
        /// This application handles opening files (in
        ///     the primary instance). Note that this flag only affects the default
        ///     implementation of local_command_line(), and has no effect if
        ///     <see cref="ApplicationFlags.HandlesCommandLine"/> is given.
        ///     See g_application_run() for details.
        /// </summary>
        HandlesOpen = 4,
        /// <summary>
        /// This application handles command line
        ///     arguments (in the primary instance). Note that this flag only affect
        ///     the default implementation of local_command_line().
        ///     See g_application_run() for details.
        /// </summary>
        HandlesCommandLine = 8,
        /// <summary>
        /// Send the environment of the
        ///     launching process to the primary instance. Set this flag if your
        ///     application is expected to behave differently depending on certain
        ///     environment variables. For instance, an editor might be expected
        ///     to use the `GIT_COMMITTER_NAME` environment variable
        ///     when editing a git commit message. The environment is available
        ///     to the #GApplication::command-line signal handler, via
        ///     g_application_command_line_getenv().
        /// </summary>
        SendEnvironment = 16,
        /// <summary>
        /// Make no attempts to do any of the typical
        ///     single-instance application negotiation, even if the application
        ///     ID is given.  The application neither attempts to become the
        ///     owner of the application ID nor does it check if an existing
        ///     owner already exists.  Everything occurs in the local process.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.30")]
        NonUnique = 32,
        /// <summary>
        /// Allow users to override the
        ///     application ID from the command line with `--gapplication-app-id`.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.48")]
        CanOverrideAppId = 64
    }

    public partial class ApplicationFlagsExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_application_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_application_flags_get_type();
    }

    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public delegate void UnmanagedAsyncReadyCallback(
    /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr sourceObject,
    /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr res,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed.
    /// </summary>
    public delegate void AsyncReadyCallback(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.IAsyncResult res);

    /// <summary>
    /// Factory for creating <see cref="AsyncReadyCallback"/> methods.
    /// </summary>
    public static class AsyncReadyCallbackFactory
    {
        class UserData
        {
            public GISharp.Lib.Gio.AsyncReadyCallback ManagedDelegate;
            public GISharp.Lib.Gio.UnmanagedAsyncReadyCallback UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.Gio.AsyncReadyCallback Create(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            return new GISharp.Lib.Gio.AsyncReadyCallback((GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.IAsyncResult res) =>
            {
                var userData_ = userData;
                var sourceObject_ = sourceObject?.Handle ?? throw new System.ArgumentNullException(nameof(sourceObject));
                var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
                callback(sourceObject_, res_, userData_);
            });
        }

        /// <summary>
        /// Wraps a <see cref="AsyncReadyCallback"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static (GISharp.Lib.Gio.UnmanagedAsyncReadyCallback, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static void UnmanagedCallback(System.IntPtr sourceObject_, System.IntPtr res_, System.IntPtr userData_)
        {
            try
            {
                var sourceObject = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(sourceObject_, GISharp.Runtime.Transfer.None);
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                userData.ManagedDelegate(sourceObject, res);
                if (userData.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(userData_);
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// Provides a base class for implementing asynchronous function results.
    /// </summary>
    /// <remarks>
    /// Asynchronous operations are broken up into two separate operations
    /// which are chained together by a <see cref="AsyncReadyCallback"/>. To begin
    /// an asynchronous operation, provide a <see cref="AsyncReadyCallback"/> to the
    /// asynchronous function. This callback will be triggered when the
    /// operation has completed, and will be passed a <see cref="IAsyncResult"/> instance
    /// filled with the details of the operation's success or failure, the
    /// object the asynchronous function was started for and any error codes
    /// returned. The asynchronous callback function is then expected to call
    /// the corresponding "_finish()" function, passing the object the
    /// function was called for, the <see cref="IAsyncResult"/> instance, and (optionally)
    /// an <paramref name="error"/> to grab any error conditions that may have occurred.
    /// 
    /// The "_finish()" function for an operation takes the generic result
    /// (of type <see cref="IAsyncResult"/>) and returns the specific result that the
    /// operation in question yields (e.g. a #GFileEnumerator for a
    /// "enumerate children" operation). If the result or error status of the
    /// operation is not needed, there is no need to call the "_finish()"
    /// function; GIO will take care of cleaning up the result and error
    /// information after the <see cref="AsyncReadyCallback"/> returns. You can pass
    /// <c>null</c> for the <see cref="AsyncReadyCallback"/> if you don't need to take any
    /// action at all after the operation completes. Applications may also
    /// take a reference to the <see cref="IAsyncResult"/> and call "_finish()" later;
    /// however, the "_finish()" function may be called at most once.
    /// 
    /// Example of a typical asynchronous operation flow:
    /// |[&lt;!-- language="C" --&gt;
    /// void _theoretical_frobnitz_async (Theoretical         *t,
    ///                                   GCancellable        *c,
    ///                                   GAsyncReadyCallback  cb,
    ///                                   gpointer             u);
    /// 
    /// gboolean _theoretical_frobnitz_finish (Theoretical   *t,
    ///                                        GAsyncResult  *res,
    ///                                        GError       **e);
    /// 
    /// static void
    /// frobnitz_result_func (GObject      *source_object,
    /// 		 GAsyncResult *res,
    /// 		 gpointer      user_data)
    /// {
    ///   gboolean success = FALSE;
    /// 
    ///   success = _theoretical_frobnitz_finish (source_object, res, NULL);
    /// 
    ///   if (success)
    ///     g_printf ("Hurray!\n");
    ///   else
    ///     g_printf ("Uh oh!\n");
    /// 
    ///   ...
    /// 
    /// }
    /// 
    /// int main (int argc, void *argv[])
    /// {
    ///    ...
    /// 
    ///    _theoretical_frobnitz_async (theoretical_data,
    ///                                 NULL,
    ///                                 frobnitz_result_func,
    ///                                 NULL);
    /// 
    ///    ...
    /// }
    /// ]|
    /// 
    /// The callback for an asynchronous operation is called only once, and is
    /// always called, even in the case of a cancelled operation. On cancellation
    /// the result is a <see cref="IOErrorEnum.Cancelled"/> error.
    /// 
    /// ## I/O Priority # {#io-priority}
    /// 
    /// Many I/O-related asynchronous operations have a priority parameter,
    /// which is used in certain cases to determine the order in which
    /// operations are executed. They are not used to determine system-wide
    /// I/O scheduling. Priorities are integers, with lower numbers indicating
    /// higher priority. It is recommended to choose priorities between
    /// %G_PRIORITY_LOW and %G_PRIORITY_HIGH, with %G_PRIORITY_DEFAULT
    /// as a default.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GAsyncResult", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(AsyncResultIface))]
    public partial interface IAsyncResult : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Gets the source object from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <returns>
        /// a new reference to the source object for the <paramref name="res"/>,
        ///    or <c>null</c> if there is none.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetSourceObject))]
        GISharp.Lib.GObject.Object DoGetSourceObject();

        /// <summary>
        /// Gets the user data from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <returns>
        /// the user data for <paramref name="res"/>.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedGetUserData))]
        System.IntPtr DoGetUserData();

        /// <summary>
        /// Checks if <paramref name="res"/> has the given <paramref name="sourceTag"/> (generally a function
        /// pointer indicating the function <paramref name="res"/> was created by).
        /// </summary>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="res"/> has the indicated <paramref name="sourceTag"/>, <c>false</c> if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncResultIface.UnmanagedIsTagged))]
        System.Boolean DoIsTagged(System.IntPtr sourceTag);
    }

    public static class AsyncResult
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_async_result_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_async_result_get_type();

        /// <summary>
        /// Gets the source object from a #GAsyncResult.
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult
        /// </param>
        /// <returns>
        /// a new reference to the source object for the @res,
        ///    or %NULL if there is none.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_async_result_get_source_object(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

        /// <summary>
        /// Gets the source object from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>
        /// </param>
        /// <returns>
        /// a new reference to the source object for the <paramref name="res"/>,
        ///    or <c>null</c> if there is none.
        /// </returns>
        public static GISharp.Lib.GObject.Object GetSourceObject(this GISharp.Lib.Gio.IAsyncResult res)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var ret_ = g_async_result_get_source_object(res_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the user data from a #GAsyncResult.
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult.
        /// </param>
        /// <returns>
        /// the user data for @res.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_async_result_get_user_data(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

        /// <summary>
        /// Gets the user data from a <see cref="IAsyncResult"/>.
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// the user data for <paramref name="res"/>.
        /// </returns>
        public static System.IntPtr GetUserData(this GISharp.Lib.Gio.IAsyncResult res)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var ret_ = g_async_result_get_user_data(res_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if @res has the given @source_tag (generally a function
        /// pointer indicating the function @res was created by).
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult
        /// </param>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// %TRUE if @res has the indicated @source_tag, %FALSE if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_async_result_is_tagged(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);

        /// <summary>
        /// Checks if <paramref name="res"/> has the given <paramref name="sourceTag"/> (generally a function
        /// pointer indicating the function <paramref name="res"/> was created by).
        /// </summary>
        /// <param name="res">
        /// a <see cref="IAsyncResult"/>
        /// </param>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="res"/> has the indicated <paramref name="sourceTag"/>, <c>false</c> if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public static System.Boolean IsTagged(this GISharp.Lib.Gio.IAsyncResult res, System.IntPtr sourceTag)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var sourceTag_ = (System.IntPtr)sourceTag;
            var ret_ = g_async_result_is_tagged(res_,sourceTag_);
            var ret = (System.Boolean)ret_;
            return ret;
        }
    }

    /// <summary>
    /// Interface definition for <see cref="IAsyncResult"/>.
    /// </summary>
    public sealed class AsyncResultIface : GISharp.Lib.GObject.TypeInterface
    {
        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedGetUserData GetUserData;
            public UnmanagedGetSourceObject GetSourceObject;
            public UnmanagedIsTagged IsTagged;
#pragma warning restore CS0649
        }

        static AsyncResultIface()
        {
            System.Int32 getUserDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetUserData));
            RegisterVirtualMethod(getUserDataOffset, GetUserDataFactory.Create);
            System.Int32 getSourceObjectOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetSourceObject));
            RegisterVirtualMethod(getSourceObjectOffset, GetSourceObjectFactory.Create);
            System.Int32 isTaggedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.IsTagged));
            RegisterVirtualMethod(isTaggedOffset, IsTaggedFactory.Create);
        }

        public delegate System.IntPtr GetUserData();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetUserData(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        /// <summary>
        /// Factory for creating <see cref="GetUserData"/> methods.
        /// </summary>
        public static class GetUserDataFactory
        {
            public static UnmanagedGetUserData Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getUserData(System.IntPtr res_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                        var doGetUserData = (GetUserData)methodInfo.CreateDelegate(typeof(GetUserData), res);
                        var ret = doGetUserData();
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getUserData;
            }
        }

        public delegate GISharp.Lib.GObject.Object GetSourceObject();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public delegate System.IntPtr UnmanagedGetSourceObject(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        /// <summary>
        /// Factory for creating <see cref="GetSourceObject"/> methods.
        /// </summary>
        public static class GetSourceObjectFactory
        {
            public static UnmanagedGetSourceObject Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr getSourceObject(System.IntPtr res_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                        var doGetSourceObject = (GetSourceObject)methodInfo.CreateDelegate(typeof(GetSourceObject), res);
                        var ret = doGetSourceObject();
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return getSourceObject;
            }
        }

        public delegate System.Boolean IsTagged(System.IntPtr sourceTag);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedIsTagged(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr sourceTag);

        /// <summary>
        /// Factory for creating <see cref="IsTagged"/> methods.
        /// </summary>
        public static class IsTaggedFactory
        {
            public static UnmanagedIsTagged Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean isTagged(System.IntPtr res_, System.IntPtr sourceTag_)
                {
                    try
                    {
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                        var sourceTag = (System.IntPtr)sourceTag_;
                        var doIsTagged = (IsTagged)methodInfo.CreateDelegate(typeof(IsTagged), res);
                        var ret = doIsTagged(sourceTag);
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return isTagged;
            }
        }

        public AsyncResultIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    /// <summary>
    /// GCancellable is a thread-safe operation cancellation stack used
    /// throughout GIO to allow for cancellation of synchronous and
    /// asynchronous operations.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GCancellable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(CancellableClass))]
    public partial class Cancellable : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_cancellable_get_type();

        protected new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.Object.Struct ParentInstance;
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// Gets the top cancellable from the stack.
        /// </summary>
        public static GISharp.Lib.Gio.Cancellable Current { get => GetCurrent(); }

        /// <summary>
        /// Gets the file descriptor for a cancellable job. This can be used to
        /// implement cancellable operations on Unix systems. The returned fd will
        /// turn readable when <paramref name="cancellable"/> is cancelled.
        /// </summary>
        /// <remarks>
        /// You are not supposed to read from the fd yourself, just check for
        /// readable status. Reading to unset the readable status is done
        /// with <see cref="Reset"/>.
        /// 
        /// After a successful return from this function, you should use
        /// <see cref="ReleaseFd"/> to free up resources allocated for
        /// the returned file descriptor.
        /// 
        /// See also <see cref="TryMakePollfd"/>.
        /// </remarks>
        public System.Int32 Fd { get => GetFd(); }

        /// <summary>
        /// Checks if a cancellable job has been cancelled.
        /// </summary>
        public System.Boolean IsCancelled { get => GetIsCancelled(); }

        public Cancellable(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GCancellable object.
        /// </summary>
        /// <remarks>
        /// Applications that want to start one or more operations
        /// that should be cancellable should create a #GCancellable
        /// and pass it to the operations.
        /// 
        /// One #GCancellable can be used in multiple consecutive
        /// operations or in multiple concurrent operations.
        /// </remarks>
        /// <returns>
        /// a #GCancellable.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_cancellable_new();

        static System.IntPtr New()
        {
            var ret_ = g_cancellable_new();
            return ret_;
        }

        /// <summary>
        /// Creates a new <see cref="Cancellable"/> object.
        /// </summary>
        /// <remarks>
        /// Applications that want to start one or more operations
        /// that should be cancellable should create a <see cref="Cancellable"/>
        /// and pass it to the operations.
        /// 
        /// One <see cref="Cancellable"/> can be used in multiple consecutive
        /// operations or in multiple concurrent operations.
        /// </remarks>
        public Cancellable() : this(New(), GISharp.Runtime.Transfer.Full)
        {
        }

        public sealed class CancelledEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public CancelledEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<CancelledEventArgs> cancelledSignalManager = new GISharp.Runtime.GSignalManager<CancelledEventArgs>("cancelled", _GType);

        /// <summary>
        /// Emitted when the operation has been cancelled.
        /// </summary>
        /// <remarks>
        /// Can be used by implementations of cancellable operations. If the
        /// operation is cancelled from another thread, the signal will be
        /// emitted in the thread that cancelled the operation, not the
        /// thread that is running the operation.
        /// 
        /// Note that disconnecting from this signal (or any signal) in a
        /// multi-threaded program is prone to race conditions. For instance
        /// it is possible that a signal handler may be invoked even after
        /// a call to g_signal_handler_disconnect() for that handler has
        /// already returned.
        /// 
        /// There is also a problem when cancellation happens right before
        /// connecting to the signal. If this happens the signal will
        /// unexpectedly not be emitted, and checking before connecting to
        /// the signal leaves a race condition where this is still happening.
        /// 
        /// In order to make it safe and easy to connect handlers there
        /// are two helper functions: <see cref="Connect"/> and
        /// <see cref="Disconnect"/> which protect against problems
        /// like this.
        /// 
        /// An example of how to us this:
        /// |[&lt;!-- language="C" --&gt;
        ///     // Make sure we don't do unnecessary work if already cancelled
        ///     if (g_cancellable_set_error_if_cancelled (cancellable, error))
        ///       return;
        /// 
        ///     // Set up all the data needed to be able to handle cancellation
        ///     // of the operation
        ///     my_data = my_data_new (...);
        /// 
        ///     id = 0;
        ///     if (cancellable)
        ///       id = g_cancellable_connect (cancellable,
        ///     			      G_CALLBACK (cancelled_handler)
        ///     			      data, NULL);
        /// 
        ///     // cancellable operation here...
        /// 
        ///     g_cancellable_disconnect (cancellable, id);
        /// 
        ///     // cancelled_handler is never called after this, it is now safe
        ///     // to free the data
        ///     my_data_free (my_data);
        /// ]|
        /// 
        /// Note that the cancelled signal is emitted in the thread that
        /// the user cancelled from, which may be the main thread. So, the
        /// cancellable signal should not do something that can block.
        /// </remarks>
        [GISharp.Runtime.GSignalAttribute("cancelled", When = GISharp.Runtime.EmissionStage.Last)]
        public event System.EventHandler<CancelledEventArgs> Cancelled { add => cancelledSignalManager.Add(this, value); remove => cancelledSignalManager.Remove(value); }

        /// <summary>
        /// Gets the top cancellable from the stack.
        /// </summary>
        /// <returns>
        /// a #GCancellable from the top
        /// of the stack, or %NULL if the stack is empty.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_cancellable_get_current();

        /// <summary>
        /// Gets the top cancellable from the stack.
        /// </summary>
        /// <returns>
        /// a <see cref="Cancellable"/> from the top
        /// of the stack, or <c>null</c> if the stack is empty.
        /// </returns>
        private static GISharp.Lib.Gio.Cancellable GetCurrent()
        {
            var ret_ = g_cancellable_get_current();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_cancellable_get_type();

        /// <summary>
        /// Will set @cancellable to cancelled, and will emit the
        /// #GCancellable::cancelled signal. (However, see the warning about
        /// race conditions in the documentation for that signal if you are
        /// planning to connect to it.)
        /// </summary>
        /// <remarks>
        /// This function is thread-safe. In other words, you can safely call
        /// it from a thread other than the one running the operation that was
        /// passed the @cancellable.
        /// 
        /// If @cancellable is %NULL, this function returns immediately for convenience.
        /// 
        /// The convention within GIO is that cancelling an asynchronous
        /// operation causes it to complete asynchronously. That is, if you
        /// cancel the operation from the same thread in which it is running,
        /// then the operation's #GAsyncReadyCallback will not be invoked until
        /// the application returns to the main loop.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable object.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_cancel(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Will set <paramref name="cancellable"/> to cancelled, and will emit the
        /// <see cref="Cancellable"/>::cancelled signal. (However, see the warning about
        /// race conditions in the documentation for that signal if you are
        /// planning to connect to it.)
        /// </summary>
        /// <remarks>
        /// This function is thread-safe. In other words, you can safely call
        /// it from a thread other than the one running the operation that was
        /// passed the <paramref name="cancellable"/>.
        /// 
        /// If <paramref name="cancellable"/> is <c>null</c>, this function returns immediately for convenience.
        /// 
        /// The convention within GIO is that cancelling an asynchronous
        /// operation causes it to complete asynchronously. That is, if you
        /// cancel the operation from the same thread in which it is running,
        /// then the operation's <see cref="AsyncReadyCallback"/> will not be invoked until
        /// the application returns to the main loop.
        /// </remarks>
        public void Cancel()
        {
            var cancellable_ = Handle;
            g_cancellable_cancel(cancellable_);
        }

        /// <summary>
        /// Convenience function to connect to the #GCancellable::cancelled
        /// signal. Also handles the race condition that may happen
        /// if the cancellable is cancelled right before connecting.
        /// </summary>
        /// <remarks>
        /// @callback is called at most once, either directly at the
        /// time of the connect if @cancellable is already cancelled,
        /// or when @cancellable is cancelled in some thread.
        /// 
        /// @data_destroy_func will be called when the handler is
        /// disconnected, or immediately if the cancellable is already
        /// cancelled.
        /// 
        /// See #GCancellable::cancelled for details on how to use this.
        /// 
        /// Since GLib 2.40, the lock protecting @cancellable is not held when
        /// @callback is invoked.  This lifts a restriction in place for
        /// earlier GLib versions which now makes it easier to write cleanup
        /// code that unconditionally invokes e.g. g_cancellable_cancel().
        /// </remarks>
        /// <param name="cancellable">
        /// A #GCancellable.
        /// </param>
        /// <param name="callback">
        /// The #GCallback to connect.
        /// </param>
        /// <param name="data">
        /// Data to pass to @callback.
        /// </param>
        /// <param name="dataDestroyFunc">
        /// Free function for @data or %NULL.
        /// </param>
        /// <returns>
        /// The id of the signal handler or 0 if @cancellable has already
        ///          been cancelled.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gulong" type="gulong" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:out */
        static extern GISharp.Runtime.NativeULong g_cancellable_connect(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GObject.Callback" type="GCallback" managed-name="System.Delegate" /> */
        /* transfer-ownership:none scope:notified closure:1 destroy:2 direction:in */
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GISharp.Lib.GLib.UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify dataDestroyFunc);

        /// <summary>
        /// Disconnects a handler from a cancellable instance similar to
        /// g_signal_handler_disconnect().  Additionally, in the event that a
        /// signal handler is currently running, this call will block until the
        /// handler has finished.  Calling this function from a
        /// #GCancellable::cancelled signal handler will therefore result in a
        /// deadlock.
        /// </summary>
        /// <remarks>
        /// This avoids a race condition where a thread cancels at the
        /// same time as the cancellable operation is finished and the
        /// signal handler is removed. See #GCancellable::cancelled for
        /// details on how to use this.
        /// 
        /// If @cancellable is %NULL or @handler_id is %0 this function does
        /// nothing.
        /// </remarks>
        /// <param name="cancellable">
        /// A #GCancellable or %NULL.
        /// </param>
        /// <param name="handlerId">
        /// Handler id of the handler to be disconnected, or %0.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_disconnect(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="gulong" type="gulong" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.NativeULong handlerId);

        /// <summary>
        /// Disconnects a handler from a cancellable instance similar to
        /// g_signal_handler_disconnect().  Additionally, in the event that a
        /// signal handler is currently running, this call will block until the
        /// handler has finished.  Calling this function from a
        /// <see cref="Cancellable"/>::cancelled signal handler will therefore result in a
        /// deadlock.
        /// </summary>
        /// <remarks>
        /// This avoids a race condition where a thread cancels at the
        /// same time as the cancellable operation is finished and the
        /// signal handler is removed. See <see cref="Cancellable"/>::cancelled for
        /// details on how to use this.
        /// 
        /// If <paramref name="cancellable"/> is <c>null</c> or <paramref name="handlerId"/> is %0 this function does
        /// nothing.
        /// </remarks>
        /// <param name="handlerId">
        /// Handler id of the handler to be disconnected, or %0.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void Disconnect(System.UInt64 handlerId)
        {
            var cancellable_ = Handle;
            var handlerId_ = (GISharp.Runtime.NativeULong)handlerId;
            g_cancellable_disconnect(cancellable_, handlerId_);
        }

        /// <summary>
        /// Gets the file descriptor for a cancellable job. This can be used to
        /// implement cancellable operations on Unix systems. The returned fd will
        /// turn readable when @cancellable is cancelled.
        /// </summary>
        /// <remarks>
        /// You are not supposed to read from the fd yourself, just check for
        /// readable status. Reading to unset the readable status is done
        /// with g_cancellable_reset().
        /// 
        /// After a successful return from this function, you should use
        /// g_cancellable_release_fd() to free up resources allocated for
        /// the returned file descriptor.
        /// 
        /// See also g_cancellable_make_pollfd().
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable.
        /// </param>
        /// <returns>
        /// A valid file descriptor. %-1 if the file descriptor
        /// is not supported, or on errors.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Int32 g_cancellable_get_fd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Gets the file descriptor for a cancellable job. This can be used to
        /// implement cancellable operations on Unix systems. The returned fd will
        /// turn readable when <paramref name="cancellable"/> is cancelled.
        /// </summary>
        /// <remarks>
        /// You are not supposed to read from the fd yourself, just check for
        /// readable status. Reading to unset the readable status is done
        /// with <see cref="Reset"/>.
        /// 
        /// After a successful return from this function, you should use
        /// <see cref="ReleaseFd"/> to free up resources allocated for
        /// the returned file descriptor.
        /// 
        /// See also <see cref="TryMakePollfd"/>.
        /// </remarks>
        /// <returns>
        /// A valid file descriptor. %-1 if the file descriptor
        /// is not supported, or on errors.
        /// </returns>
        private System.Int32 GetFd()
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_get_fd(cancellable_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if a cancellable job has been cancelled.
        /// </summary>
        /// <param name="cancellable">
        /// a #GCancellable or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if @cancellable is cancelled,
        /// FALSE if called with %NULL or if item is not cancelled.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_cancellable_is_cancelled(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Checks if a cancellable job has been cancelled.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="cancellable"/> is cancelled,
        /// FALSE if called with <c>null</c> or if item is not cancelled.
        /// </returns>
        private System.Boolean GetIsCancelled()
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_is_cancelled(cancellable_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a #GPollFD corresponding to @cancellable; this can be passed
        /// to g_poll() and used to poll for cancellation. This is useful both
        /// for unix systems without a native poll and for portability to
        /// windows.
        /// </summary>
        /// <remarks>
        /// When this function returns %TRUE, you should use
        /// g_cancellable_release_fd() to free up resources allocated for the
        /// @pollfd. After a %FALSE return, do not call g_cancellable_release_fd().
        /// 
        /// If this function returns %FALSE, either no @cancellable was given or
        /// resource limits prevent this function from allocating the necessary
        /// structures for polling. (On Linux, you will likely have reached
        /// the maximum number of file descriptors.) The suggested way to handle
        /// these cases is to ignore the @cancellable.
        /// 
        /// You are not supposed to read from the fd yourself, just check for
        /// readable status. Reading to unset the readable status is done
        /// with g_cancellable_reset().
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable or %NULL
        /// </param>
        /// <param name="pollfd">
        /// a pointer to a #GPollFD
        /// </param>
        /// <returns>
        /// %TRUE if @pollfd was successfully initialized, %FALSE on
        ///          failure to prepare the cancellable.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_cancellable_make_pollfd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.PollFD" type="GPollFD*" managed-name="GISharp.Lib.GLib.PollFD" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        out GISharp.Lib.GLib.PollFD pollfd);

        /// <summary>
        /// Creates a #GPollFD corresponding to <paramref name="cancellable"/>; this can be passed
        /// to g_poll() and used to poll for cancellation. This is useful both
        /// for unix systems without a native poll and for portability to
        /// windows.
        /// </summary>
        /// <remarks>
        /// When this function returns <c>true</c>, you should use
        /// <see cref="ReleaseFd"/> to free up resources allocated for the
        /// <paramref name="pollfd"/>. After a <c>false</c> return, do not call <see cref="ReleaseFd"/>.
        /// 
        /// If this function returns <c>false</c>, either no <paramref name="cancellable"/> was given or
        /// resource limits prevent this function from allocating the necessary
        /// structures for polling. (On Linux, you will likely have reached
        /// the maximum number of file descriptors.) The suggested way to handle
        /// these cases is to ignore the <paramref name="cancellable"/>.
        /// 
        /// You are not supposed to read from the fd yourself, just check for
        /// readable status. Reading to unset the readable status is done
        /// with <see cref="Reset"/>.
        /// </remarks>
        /// <param name="pollfd">
        /// a pointer to a #GPollFD
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="pollfd"/> was successfully initialized, <c>false</c> on
        ///          failure to prepare the cancellable.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Boolean TryMakePollfd(out GISharp.Lib.GLib.PollFD pollfd)
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_make_pollfd(cancellable_,out var pollfd_);
            pollfd = (GISharp.Lib.GLib.PollFD)pollfd_;
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Pops @cancellable off the cancellable stack (verifying that @cancellable
        /// is on the top of the stack).
        /// </summary>
        /// <param name="cancellable">
        /// a #GCancellable object
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_pop_current(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Pops <paramref name="cancellable"/> off the cancellable stack (verifying that <paramref name="cancellable"/>
        /// is on the top of the stack).
        /// </summary>
        public void PopCurrent()
        {
            var cancellable_ = Handle;
            g_cancellable_pop_current(cancellable_);
        }

        /// <summary>
        /// Pushes @cancellable onto the cancellable stack. The current
        /// cancellable can then be received using g_cancellable_get_current().
        /// </summary>
        /// <remarks>
        /// This is useful when implementing cancellable operations in
        /// code that does not allow you to pass down the cancellable object.
        /// 
        /// This is typically called automatically by e.g. #GFile operations,
        /// so you rarely have to call this yourself.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable object
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_push_current(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Pushes <paramref name="cancellable"/> onto the cancellable stack. The current
        /// cancellable can then be received using <see cref="GetCurrent"/>.
        /// </summary>
        /// <remarks>
        /// This is useful when implementing cancellable operations in
        /// code that does not allow you to pass down the cancellable object.
        /// 
        /// This is typically called automatically by e.g. #GFile operations,
        /// so you rarely have to call this yourself.
        /// </remarks>
        public void PushCurrent()
        {
            var cancellable_ = Handle;
            g_cancellable_push_current(cancellable_);
        }

        /// <summary>
        /// Releases a resources previously allocated by g_cancellable_get_fd()
        /// or g_cancellable_make_pollfd().
        /// </summary>
        /// <remarks>
        /// For compatibility reasons with older releases, calling this function
        /// is not strictly required, the resources will be automatically freed
        /// when the @cancellable is finalized. However, the @cancellable will
        /// block scarce file descriptors until it is finalized if this function
        /// is not called. This can cause the application to run out of file
        /// descriptors when many #GCancellables are used at the same time.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_release_fd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Releases a resources previously allocated by <see cref="GetFd"/>
        /// or <see cref="TryMakePollfd"/>.
        /// </summary>
        /// <remarks>
        /// For compatibility reasons with older releases, calling this function
        /// is not strictly required, the resources will be automatically freed
        /// when the <paramref name="cancellable"/> is finalized. However, the <paramref name="cancellable"/> will
        /// block scarce file descriptors until it is finalized if this function
        /// is not called. This can cause the application to run out of file
        /// descriptors when many #GCancellables are used at the same time.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void ReleaseFd()
        {
            var cancellable_ = Handle;
            g_cancellable_release_fd(cancellable_);
        }

        /// <summary>
        /// Resets @cancellable to its uncancelled state.
        /// </summary>
        /// <remarks>
        /// If cancellable is currently in use by any cancellable operation
        /// then the behavior of this function is undefined.
        /// 
        /// Note that it is generally not a good idea to reuse an existing
        /// cancellable for more operations after it has been cancelled once,
        /// as this function might tempt you to do. The recommended practice
        /// is to drop the reference to a cancellable after cancelling it,
        /// and let it die with the outstanding async operations. You should
        /// create a fresh cancellable for further async operations.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable object.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_reset(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Resets <paramref name="cancellable"/> to its uncancelled state.
        /// </summary>
        /// <remarks>
        /// If cancellable is currently in use by any cancellable operation
        /// then the behavior of this function is undefined.
        /// 
        /// Note that it is generally not a good idea to reuse an existing
        /// cancellable for more operations after it has been cancelled once,
        /// as this function might tempt you to do. The recommended practice
        /// is to drop the reference to a cancellable after cancelling it,
        /// and let it die with the outstanding async operations. You should
        /// create a fresh cancellable for further async operations.
        /// </remarks>
        public void Reset()
        {
            var cancellable_ = Handle;
            g_cancellable_reset(cancellable_);
        }

        /// <summary>
        /// If the @cancellable is cancelled, sets the error to notify
        /// that the operation was cancelled.
        /// </summary>
        /// <param name="cancellable">
        /// a #GCancellable or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if @cancellable was cancelled, %FALSE if it was not
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_cancellable_set_error_if_cancelled(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// If the <paramref name="cancellable"/> is cancelled, sets the error to notify
        /// that the operation was cancelled.
        /// </summary>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public void ThrowIfCancelled()
        {
            var cancellable_ = Handle;
            var error_ = System.IntPtr.Zero;
            g_cancellable_set_error_if_cancelled(cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        [GISharp.Runtime.GVirtualMethodAttribute(typeof(CancellableClass.UnmanagedCancelled))]
        protected virtual void DoCancelled()
        {
            var cancellable_ = Handle;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<CancellableClass.UnmanagedCancelled>(_GType)(cancellable_);
        }
    }

    public class CancellableClass : GISharp.Lib.GObject.ObjectClass
    {
        new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public UnmanagedCancelled Cancelled;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static CancellableClass()
        {
            System.Int32 cancelledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Cancelled));
            RegisterVirtualMethod(cancelledOffset, CancelledFactory.Create);
        }

        public delegate void Cancelled();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedCancelled(
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable);

        /// <summary>
        /// Factory for creating <see cref="Cancelled"/> methods.
        /// </summary>
        public static class CancelledFactory
        {
            public static UnmanagedCancelled Create(System.Reflection.MethodInfo methodInfo)
            {
                void cancelled(System.IntPtr cancellable_)
                {
                    try
                    {
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCancelled = (Cancelled)methodInfo.CreateDelegate(typeof(Cancelled), cancellable);
                        doCancelled();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return cancelled;
            }
        }

        public CancellableClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by g_cancellable_source_new().
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:out */
    public delegate System.Boolean UnmanagedCancellableSourceFunc(
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr cancellable,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by <see cref="New"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public delegate System.Boolean CancellableSourceFunc(GISharp.Lib.Gio.Cancellable cancellable = null);

    /// <summary>
    /// Factory for creating <see cref="CancellableSourceFunc"/> methods.
    /// </summary>
    public static class CancellableSourceFuncFactory
    {
        class UserData
        {
            public GISharp.Lib.Gio.CancellableSourceFunc ManagedDelegate;
            public GISharp.Lib.Gio.UnmanagedCancellableSourceFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.Gio.CancellableSourceFunc Create(GISharp.Lib.Gio.UnmanagedCancellableSourceFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            return new GISharp.Lib.Gio.CancellableSourceFunc((GISharp.Lib.Gio.Cancellable cancellable) =>
            {
                var userData_ = userData;
                var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
                var ret_ = callback(cancellable_,userData_);
                var ret = (System.Boolean)ret_;
                return ret;
            });
        }

        /// <summary>
        /// Wraps a <see cref="CancellableSourceFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static (GISharp.Lib.Gio.UnmanagedCancellableSourceFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.CancellableSourceFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static System.Boolean UnmanagedCallback(System.IntPtr cancellable_, System.IntPtr userData_)
        {
            try
            {
                var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                var ret = userData.ManagedDelegate(cancellable);
                if (userData.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(userData_);
                }
                var ret_ = (System.Boolean)ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.Boolean);
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// Error codes returned by GIO functions.
    /// </summary>
    /// <remarks>
    /// Note that this domain may be extended in future GLib releases. In
    /// general, new error codes either only apply to new APIs, or else
    /// replace <see cref="IOErrorEnum.Failed"/> in cases that were not explicitly
    /// distinguished before. You should therefore avoid writing code like
    /// |[&lt;!-- language="C" --&gt;
    /// if (g_error_matches (error, G_IO_ERROR, G_IO_ERROR_FAILED))
    ///   {
    ///     // Assume that this is EPRINTERONFIRE
    ///     ...
    ///   }
    /// ]|
    /// but should instead treat all unrecognized error codes the same as
    /// #G_IO_ERROR_FAILED.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GIOErrorEnum", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("g-io-error-quark")]
    public enum IOErrorEnum
    {
        /// <summary>
        /// Generic error condition for when an operation fails
        ///     and no more specific <see cref="IOErrorEnum"/> value is defined.
        /// </summary>
        Failed = 0,
        /// <summary>
        /// File not found.
        /// </summary>
        NotFound = 1,
        /// <summary>
        /// File already exists.
        /// </summary>
        Exists = 2,
        /// <summary>
        /// File is a directory.
        /// </summary>
        IsDirectory = 3,
        /// <summary>
        /// File is not a directory.
        /// </summary>
        NotDirectory = 4,
        /// <summary>
        /// File is a directory that isn't empty.
        /// </summary>
        NotEmpty = 5,
        /// <summary>
        /// File is not a regular file.
        /// </summary>
        NotRegularFile = 6,
        /// <summary>
        /// File is not a symbolic link.
        /// </summary>
        NotSymbolicLink = 7,
        /// <summary>
        /// File cannot be mounted.
        /// </summary>
        NotMountableFile = 8,
        /// <summary>
        /// Filename is too many characters.
        /// </summary>
        FilenameTooLong = 9,
        /// <summary>
        /// Filename is invalid or contains invalid characters.
        /// </summary>
        InvalidFilename = 10,
        /// <summary>
        /// File contains too many symbolic links.
        /// </summary>
        TooManyLinks = 11,
        /// <summary>
        /// No space left on drive.
        /// </summary>
        NoSpace = 12,
        /// <summary>
        /// Invalid argument.
        /// </summary>
        InvalidArgument = 13,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = 14,
        /// <summary>
        /// Operation (or one of its parameters) not supported
        /// </summary>
        NotSupported = 15,
        /// <summary>
        /// File isn't mounted.
        /// </summary>
        NotMounted = 16,
        /// <summary>
        /// File is already mounted.
        /// </summary>
        AlreadyMounted = 17,
        /// <summary>
        /// File was closed.
        /// </summary>
        Closed = 18,
        /// <summary>
        /// Operation was cancelled. See <see cref="Cancellable"/>.
        /// </summary>
        Cancelled = 19,
        /// <summary>
        /// Operations are still pending.
        /// </summary>
        Pending = 20,
        /// <summary>
        /// File is read only.
        /// </summary>
        ReadOnly = 21,
        /// <summary>
        /// Backup couldn't be created.
        /// </summary>
        CantCreateBackup = 22,
        /// <summary>
        /// File's Entity Tag was incorrect.
        /// </summary>
        WrongEtag = 23,
        /// <summary>
        /// Operation timed out.
        /// </summary>
        TimedOut = 24,
        /// <summary>
        /// Operation would be recursive.
        /// </summary>
        WouldRecurse = 25,
        /// <summary>
        /// File is busy.
        /// </summary>
        Busy = 26,
        /// <summary>
        /// Operation would block.
        /// </summary>
        WouldBlock = 27,
        /// <summary>
        /// Host couldn't be found (remote operations).
        /// </summary>
        HostNotFound = 28,
        /// <summary>
        /// Operation would merge files.
        /// </summary>
        WouldMerge = 29,
        /// <summary>
        /// Operation failed and a helper program has
        ///     already interacted with the user. Do not display any error dialog.
        /// </summary>
        FailedHandled = 30,
        /// <summary>
        /// The current process has too many files
        ///     open and can't open any more. Duplicate descriptors do count toward
        ///     this limit.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.20")]
        TooManyOpenFiles = 31,
        /// <summary>
        /// The object has not been initialized.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        NotInitialized = 32,
        /// <summary>
        /// The requested address is already in use.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        AddressInUse = 33,
        /// <summary>
        /// Need more input to finish operation.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        PartialInput = 34,
        /// <summary>
        /// The input data was invalid.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        InvalidData = 35,
        /// <summary>
        /// A remote object generated an error that
        ///     doesn't correspond to a locally registered #GError error
        ///     domain. Use g_dbus_error_get_remote_error() to extract the D-Bus
        ///     error name and g_dbus_error_strip_remote_error() to fix up the
        ///     message so it matches what was received on the wire.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        DbusError = 36,
        /// <summary>
        /// Host unreachable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        HostUnreachable = 37,
        /// <summary>
        /// Network unreachable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        NetworkUnreachable = 38,
        /// <summary>
        /// Connection refused.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ConnectionRefused = 39,
        /// <summary>
        /// Connection to proxy server failed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyFailed = 40,
        /// <summary>
        /// Proxy authentication failed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyAuthFailed = 41,
        /// <summary>
        /// Proxy server needs authentication.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyNeedAuth = 42,
        /// <summary>
        /// Proxy connection is not allowed by ruleset.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyNotAllowed = 43,
        /// <summary>
        /// Broken pipe.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        BrokenPipe = 44,
        /// <summary>
        /// Connection closed by peer. Note that this
        ///     is the same code as <see cref="IOErrorEnum.BrokenPipe"/>; before 2.44 some
        ///     "connection closed" errors returned <see cref="IOErrorEnum.BrokenPipe"/>, but others
        ///     returned <see cref="IOErrorEnum.Failed"/>. Now they should all return the same
        ///     value, which has this more logical name.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        ConnectionClosed = 44,
        /// <summary>
        /// Transport endpoint is not connected.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        NotConnected = 45,
        /// <summary>
        /// Message too large.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.48")]
        MessageTooLarge = 46
    }

    public partial class IOErrorEnumDomain
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_io_error_enum_get_type();

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        /// <summary>
        /// Converts errno.h error codes into GIO error codes. The fallback
        /// value %G_IO_ERROR_FAILED is returned for error codes not currently
        /// handled (but note that future GLib releases may return a more
        /// specific value instead).
        /// </summary>
        /// <remarks>
        /// As %errno is global and may be modified by intermediate function
        /// calls, you should save its value as soon as the call which sets it
        /// </remarks>
        /// <param name="errno">
        /// Error number as defined in errno.h.
        /// </param>
        /// <returns>
        /// #GIOErrorEnum value for the given errno.h error number.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="IOErrorEnum" type="GIOErrorEnum" managed-name="IOErrorEnum" /> */
        /* transfer-ownership:none direction:out */
        static extern GISharp.Lib.Gio.IOErrorEnum g_io_error_from_errno(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 errno);

        /// <summary>
        /// Converts errno.h error codes into GIO error codes. The fallback
        /// value <see cref="IOErrorEnum.Failed"/> is returned for error codes not currently
        /// handled (but note that future GLib releases may return a more
        /// specific value instead).
        /// </summary>
        /// <remarks>
        /// As %errno is global and may be modified by intermediate function
        /// calls, you should save its value as soon as the call which sets it
        /// </remarks>
        /// <param name="errno">
        /// Error number as defined in errno.h.
        /// </param>
        /// <returns>
        /// <see cref="IOErrorEnum"/> value for the given errno.h error number.
        /// </returns>
        public static GISharp.Lib.Gio.IOErrorEnum FromErrno(System.Int32 errno)
        {
            var errno_ = (System.Int32)errno;
            var ret_ = g_io_error_from_errno(errno_);
            var ret = (GISharp.Lib.Gio.IOErrorEnum)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        /// <returns>
        /// a #GQuark.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern GISharp.Lib.GLib.Quark g_io_error_quark();

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        /// <returns>
        /// a #GQuark.
        /// </returns>
        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            var ret_ = g_io_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_io_error_enum_get_type();
    }

    /// <summary>
    /// <see cref="IIcon"/> is a very minimal interface for icons. It provides functions
    /// for checking the equality of two icons, hashing of icons and
    /// serializing an icon to and from strings.
    /// </summary>
    /// <remarks>
    /// <see cref="IIcon"/> does not provide the actual pixmap for the icon as this is out
    /// of GIO's scope, however implementations of <see cref="IIcon"/> may contain the name
    /// of an icon (see <see cref="ThemedIcon"/>), or the path to an icon (see #GLoadableIcon).
    /// 
    /// To obtain a hash of a <see cref="IIcon"/>, see <see cref="GetHashCode"/>.
    /// 
    /// To check if two <see cref="IIcon"/>s are equal, see <see cref="Equals"/>.
    /// 
    /// For serializing a <see cref="IIcon"/>, use <see cref="Serialize"/> and
    /// <see cref="Deserialize"/>.
    /// 
    /// If you want to consume <see cref="IIcon"/> (for example, in a toolkit) you must
    /// be prepared to handle at least the three following cases:
    /// #GLoadableIcon, <see cref="ThemedIcon"/> and #GEmblemedIcon.  It may also make
    /// sense to have fast-paths for other cases (like handling #GdkPixbuf
    /// directly, for example) but all compliant <see cref="IIcon"/> implementations
    /// outside of GIO must implement #GLoadableIcon.
    /// 
    /// If your application or library provides one or more <see cref="IIcon"/>
    /// implementations you need to ensure that your new implementation also
    /// implements #GLoadableIcon.  Additionally, you must provide an
    /// implementation of <see cref="Serialize"/> that gives a result that is
    /// understood by <see cref="Deserialize"/>, yielding one of the built-in icon
    /// types.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(IconIface))]
    public partial interface IIcon : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon2">
        /// pointer to the second <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="icon1"/> is equal to <paramref name="icon2"/>. <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedEqual))]
        System.Boolean DoEqual(GISharp.Lib.Gio.IIcon icon2);

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <returns>
        /// a #guint containing a hash for the <paramref name="icon"/>, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedHash))]
        System.UInt32 DoHash();

        /// <summary>
        /// Serializes a <see cref="IIcon"/> into a #GVariant. An equivalent <see cref="IIcon"/> can be retrieved
        /// back by calling <see cref="Deserialize"/> on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <returns>
        /// a #GVariant, or <c>null</c> when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedSerialize))]
        GISharp.Lib.GLib.Variant DoSerialize();
    }

    public static class Icon
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_icon_get_type();

        /// <summary>
        /// Deserializes a #GIcon previously serialized using g_icon_serialize().
        /// </summary>
        /// <param name="value">
        /// a #GVariant created with g_icon_serialize()
        /// </param>
        /// <returns>
        /// a #GIcon, or %NULL when deserialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_icon_deserialize(
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Deserializes a <see cref="IIcon"/> previously serialized using <see cref="Serialize"/>.
        /// </summary>
        /// <param name="value">
        /// a #GVariant created with <see cref="Serialize"/>
        /// </param>
        /// <returns>
        /// a <see cref="IIcon"/>, or <c>null</c> when deserialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Lib.Gio.IIcon Deserialize(GISharp.Lib.GLib.Variant value)
        {
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            var ret_ = g_icon_deserialize(value_);
            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generate a #GIcon instance from @str. This function can fail if
        /// @str is not valid - see g_icon_to_string() for discussion.
        /// </summary>
        /// <remarks>
        /// If your application or library provides one or more #GIcon
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling g_icon_new_for_string().
        /// </remarks>
        /// <param name="str">
        /// A string obtained via g_icon_to_string().
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// An object implementing the #GIcon
        ///          interface or %NULL if @error is set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_icon_new_for_string(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr str,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Generate a <see cref="IIcon"/> instance from <paramref name="str"/>. This function can fail if
        /// <paramref name="str"/> is not valid - see <see cref="ToString"/> for discussion.
        /// </summary>
        /// <remarks>
        /// If your application or library provides one or more <see cref="IIcon"/>
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling <see cref="NewForString"/>.
        /// </remarks>
        /// <param name="str">
        /// A string obtained via <see cref="ToString"/>.
        /// </param>
        /// <returns>
        /// An object implementing the <see cref="IIcon"/>
        ///          interface or <c>null</c> if <paramref name="error"/> is set.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static GISharp.Lib.Gio.IIcon NewForString(GISharp.Lib.GLib.Utf8 str)
        {
            var str_ = str?.Handle ?? throw new System.ArgumentNullException(nameof(str));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_icon_new_for_string(str_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_icon_get_type();

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <param name="icon">
        /// #gconstpointer to an icon object.
        /// </param>
        /// <returns>
        /// a #guint containing a hash for the @icon, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.UInt32 g_icon_hash(
        /* <type name="Icon" type="gconstpointer" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <param name="icon">
        /// #gconstpointer to an icon object.
        /// </param>
        /// <returns>
        /// a #guint containing a hash for the <paramref name="icon"/>, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        public static System.Int32 GetHashCode(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_hash(icon_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon1">
        /// pointer to the first #GIcon.
        /// </param>
        /// <param name="icon2">
        /// pointer to the second #GIcon.
        /// </param>
        /// <returns>
        /// %TRUE if @icon1 is equal to @icon2. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_icon_equal(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon1,
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon2);

        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon1">
        /// pointer to the first <see cref="IIcon"/>.
        /// </param>
        /// <param name="icon2">
        /// pointer to the second <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="icon1"/> is equal to <paramref name="icon2"/>. <c>false</c> otherwise.
        /// </returns>
        public static System.Boolean Equals(this GISharp.Lib.Gio.IIcon icon1, GISharp.Lib.Gio.IIcon icon2)
        {
            var icon1_ = icon1?.Handle ?? System.IntPtr.Zero;
            var icon2_ = icon2?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_icon_equal(icon1_,icon2_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Serializes a #GIcon into a #GVariant. An equivalent #GIcon can be retrieved
        /// back by calling g_icon_deserialize() on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <param name="icon">
        /// a #GIcon
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_icon_serialize(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Serializes a <see cref="IIcon"/> into a #GVariant. An equivalent <see cref="IIcon"/> can be retrieved
        /// back by calling <see cref="Deserialize"/> on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <param name="icon">
        /// a <see cref="IIcon"/>
        /// </param>
        /// <returns>
        /// a #GVariant, or <c>null</c> when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Lib.GLib.Variant Serialize(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_serialize(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generates a textual representation of @icon that can be used for
        /// serialization such as when passing @icon to a different process or
        /// saving it to persistent storage. Use g_icon_new_for_string() to
        /// get @icon back from the returned string.
        /// </summary>
        /// <remarks>
        /// The encoding of the returned string is proprietary to #GIcon except
        /// in the following two cases
        /// 
        /// - If @icon is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for @icon is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// 
        /// - If @icon is a #GThemedIcon with exactly one name, the encoding is
        ///    simply the name (such as `network-server`).
        /// </remarks>
        /// <param name="icon">
        /// a #GIcon.
        /// </param>
        /// <returns>
        /// An allocated NUL-terminated UTF8 string or
        /// %NULL if @icon can't be serialized. Use g_free() to free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_icon_to_string(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Generates a textual representation of <paramref name="icon"/> that can be used for
        /// serialization such as when passing <paramref name="icon"/> to a different process or
        /// saving it to persistent storage. Use <see cref="NewForString"/> to
        /// get <paramref name="icon"/> back from the returned string.
        /// </summary>
        /// <remarks>
        /// The encoding of the returned string is proprietary to <see cref="IIcon"/> except
        /// in the following two cases
        /// 
        /// - If <paramref name="icon"/> is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for <paramref name="icon"/> is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// 
        /// - If <paramref name="icon"/> is a <see cref="ThemedIcon"/> with exactly one name, the encoding is
        ///    simply the name (such as `network-server`).
        /// </remarks>
        /// <param name="icon">
        /// a <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// An allocated NUL-terminated UTF8 string or
        /// <c>null</c> if <paramref name="icon"/> can't be serialized. Use g_free() to free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static GISharp.Lib.GLib.Utf8 ToString(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_to_string(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }

    /// <summary>
    /// GIconIface is used to implement GIcon types for various
    /// different systems. See <see cref="ThemedIcon"/> and #GLoadableIcon for
    /// examples of how to implement this interface.
    /// </summary>
    public sealed class IconIface : GISharp.Lib.GObject.TypeInterface
    {
        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedHash Hash;
            public UnmanagedEqual Equal;
            public System.IntPtr ToTokens;
            public System.IntPtr FromTokens;
            public UnmanagedSerialize Serialize;
#pragma warning restore CS0649
        }

        static IconIface()
        {
            System.Int32 hashOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Hash));
            RegisterVirtualMethod(hashOffset, HashFactory.Create);
            System.Int32 equalOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Equal));
            RegisterVirtualMethod(equalOffset, EqualFactory.Create);
            System.Int32 serializeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Serialize));
            RegisterVirtualMethod(serializeOffset, SerializeFactory.Create);
        }

        public delegate System.UInt32 Hash();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.UInt32 UnmanagedHash(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Factory for creating <see cref="Hash"/> methods.
        /// </summary>
        public static class HashFactory
        {
            public static UnmanagedHash Create(System.Reflection.MethodInfo methodInfo)
            {
                System.UInt32 hash(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None);
                        var doHash = (Hash)methodInfo.CreateDelegate(typeof(Hash), icon);
                        var ret = doHash();
                        var ret_ = (System.UInt32)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.UInt32);
                }

                return hash;
            }
        }

        public delegate System.Boolean Equal(GISharp.Lib.Gio.IIcon icon2);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedEqual(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon1,
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr icon2);

        /// <summary>
        /// Factory for creating <see cref="Equal"/> methods.
        /// </summary>
        public static class EqualFactory
        {
            public static UnmanagedEqual Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean equal(System.IntPtr icon1_, System.IntPtr icon2_)
                {
                    try
                    {
                        var icon1 = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon1_, GISharp.Runtime.Transfer.None);
                        var icon2 = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon2_, GISharp.Runtime.Transfer.None);
                        var doEqual = (Equal)methodInfo.CreateDelegate(typeof(Equal), icon1);
                        var ret = doEqual(icon2);
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return equal;
            }
        }

        public delegate GISharp.Lib.GLib.Variant Serialize();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public delegate System.IntPtr UnmanagedSerialize(
/* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr icon);

        /// <summary>
        /// Factory for creating <see cref="Serialize"/> methods.
        /// </summary>
        public static class SerializeFactory
        {
            public static UnmanagedSerialize Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr serialize(System.IntPtr icon_)
                {
                    try
                    {
                        var icon = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(icon_, GISharp.Runtime.Transfer.None);
                        var doSerialize = (Serialize)methodInfo.CreateDelegate(typeof(Serialize), icon);
                        var ret = doSerialize();
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return serialize;
            }
        }

        public IconIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    /// <summary>
    /// <see cref="InputStream"/> has functions to read from a stream (<see cref="Read"/>),
    /// to close a stream (<see cref="Close"/>) and to skip some content
    /// (<see cref="Skip"/>).
    /// </summary>
    /// <remarks>
    /// To copy the content of an input stream to an output stream without
    /// manually handling the reads and writes, use g_output_stream_splice().
    /// 
    /// See the documentation for #GIOStream for details of thread safety of
    /// streaming APIs.
    /// 
    /// All of these functions have async variants too.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GInputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(InputStreamClass))]
    public abstract partial class InputStream : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_input_stream_get_type();

        protected new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.Object.Struct ParentInstance;
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        public System.Boolean IsClosed { get => GetIsClosed(); }

        protected InputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_input_stream_get_type();

        /// <summary>
        /// Clears the pending flag on @stream.
        /// </summary>
        /// <param name="stream">
        /// input stream
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_clear_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Clears the pending flag on <paramref name="stream"/>.
        /// </summary>
        public void ClearPending()
        {
            var stream_ = Handle;
            g_input_stream_clear_pending(stream_);
        }

        /// <summary>
        /// Closes the stream, releasing resources related to it.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return %G_IO_ERROR_CLOSED.
        /// Closing a stream multiple times will not return an error.
        /// 
        /// Streams will be automatically closed when the last reference
        /// is dropped, but you might want to call this function to make sure
        /// resources are released as early as possible.
        /// 
        /// Some streams might keep the backing store of the stream (e.g. a file descriptor)
        /// open after the stream is closed. See the documentation for the individual
        /// stream for details.
        /// 
        /// On failure the first error that happened will be reported, but the close
        /// operation will finish as much as possible. A stream that failed to
        /// close will still return %G_IO_ERROR_CLOSED for all operations. Still, it
        /// is important to check and report the error to the user.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// Cancelling a close will still leave the stream closed, but some streams
        /// can use a faster close that doesn't block to e.g. check errors.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE on failure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_input_stream_close(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Closes the stream, releasing resources related to it.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return <see cref="IOErrorEnum.Closed"/>.
        /// Closing a stream multiple times will not return an error.
        /// 
        /// Streams will be automatically closed when the last reference
        /// is dropped, but you might want to call this function to make sure
        /// resources are released as early as possible.
        /// 
        /// Some streams might keep the backing store of the stream (e.g. a file descriptor)
        /// open after the stream is closed. See the documentation for the individual
        /// stream for details.
        /// 
        /// On failure the first error that happened will be reported, but the close
        /// operation will finish as much as possible. A stream that failed to
        /// close will still return <see cref="IOErrorEnum.Closed"/> for all operations. Still, it
        /// is important to check and report the error to the user.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// Cancelling a close will still leave the stream closed, but some streams
        /// can use a faster close that doesn't block to e.g. check errors.
        /// </remarks>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public void Close(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_input_stream_close(stream_, cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished @callback will be called.
        /// You can then call g_input_stream_close_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see g_input_stream_close().
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_close_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="CloseFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        public System.Threading.Tasks.Task CloseAsync(System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Object>();
            var callback_ = closeAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_close_async(stream_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes closing a stream asynchronously, started from g_input_stream_close_async().
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the stream was closed successfully.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_input_stream_close_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static void CloseFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Object>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                g_input_stream_close_finish(stream_, result_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                completionSource.SetResult(null);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback closeAsyncCallbackDelegate = CloseFinish;

        /// <summary>
        /// Checks if an input stream has pending actions.
        /// </summary>
        /// <param name="stream">
        /// input stream.
        /// </param>
        /// <returns>
        /// %TRUE if @stream has pending actions.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_input_stream_has_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an input stream has pending actions.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="stream"/> has pending actions.
        /// </returns>
        public System.Boolean HasPending()
        {
            var stream_ = Handle;
            var ret_ = g_input_stream_has_pending(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        /// <param name="stream">
        /// input stream.
        /// </param>
        /// <returns>
        /// %TRUE if the stream is closed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_input_stream_is_closed(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream is closed.
        /// </returns>
        private System.Boolean GetIsClosed()
        {
            var stream_ = Handle;
            var ret_ = g_input_stream_is_closed(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to read @count bytes from the stream into the buffer starting at
        /// @buffer. Will block during this read.
        /// </summary>
        /// <remarks>
        /// If count is zero returns zero and does nothing. A value of @count
        /// larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes read into the buffer is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. Zero is returned on end of file
        /// (or if @count is zero),  but never otherwise.
        /// 
        /// The returned @buffer is not a nul-terminated string, it can contain nul bytes
        /// at any position, and this function doesn't nul-terminate the @buffer.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error -1 is returned and @error is set accordingly.
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes read, or -1 on error, or 0 on end of file.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_input_stream_read(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Tries to read <paramref name="count"/> bytes from the stream into the buffer starting at
        /// <paramref name="buffer"/>. Will block during this read.
        /// </summary>
        /// <remarks>
        /// If count is zero returns zero and does nothing. A value of <paramref name="count"/>
        /// larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// The returned <paramref name="buffer"/> is not a nul-terminated string, it can contain nul bytes
        /// at any position, and this function doesn't nul-terminate the <paramref name="buffer"/>.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error -1 is returned and <paramref name="error"/> is set accordingly.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes read, or -1 on error, or 0 on end of file.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public System.Int32 Read(GISharp.Runtime.IArray<System.Byte> buffer, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_read(stream_,buffer_,count_,cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to read @count bytes from the stream into the buffer starting at
        /// @buffer. Will block during this read.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_input_stream_read(), except it tries to
        /// read as many bytes as requested, only stopping on an error or end of stream.
        /// 
        /// On a successful read of @count bytes, or if we reached the end of the
        /// stream,  %TRUE is returned, and @bytes_read is set to the number of bytes
        /// read into @buffer.
        /// 
        /// If there is an error during the operation %FALSE is returned and @error
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_read will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around g_input_stream_read().
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE if there was an error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_input_stream_read_all(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.UIntPtr bytesRead,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Tries to read <paramref name="count"/> bytes from the stream into the buffer starting at
        /// <paramref name="buffer"/>. Will block during this read.
        /// </summary>
        /// <remarks>
        /// This function is similar to <see cref="Read"/>, except it tries to
        /// read as many bytes as requested, only stopping on an error or end of stream.
        /// 
        /// On a successful read of <paramref name="count"/> bytes, or if we reached the end of the
        /// stream,  <c>true</c> is returned, and <paramref name="bytesRead"/> is set to the number of bytes
        /// read into <paramref name="buffer"/>.
        /// 
        /// If there is an error during the operation <c>false</c> is returned and <paramref name="error"/>
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns <c>false</c> (and sets <paramref name="error"/>) then
        /// <paramref name="bytesRead"/> will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around <see cref="Read"/>.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public void ReadAll(GISharp.Runtime.IArray<System.Byte> buffer, out System.Int32 bytesRead, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_input_stream_read_all(stream_, buffer_, count_,out var bytesRead_, cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            bytesRead = (System.Int32)bytesRead_;
        }

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into the
        /// buffer starting at @buffer.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous equivalent of g_input_stream_read_all().
        /// 
        /// Call g_input_stream_read_all_finish() to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long)
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_read_all_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the
        /// buffer starting at <paramref name="buffer"/>.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous equivalent of <see cref="ReadAll"/>.
        /// 
        /// Call <see cref="ReadAllFinish"/> to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long)
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public System.Threading.Tasks.Task<System.Int32> ReadAllAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = readAllAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_all_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream read operation started with
        /// g_input_stream_read_all_async().
        /// </summary>
        /// <remarks>
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_read will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around g_input_stream_read_async().
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE if there was an error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_input_stream_read_all_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.UIntPtr bytesRead,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static void ReadAllFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                g_input_stream_read_all_finish(stream_, result_,out var bytesRead_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var bytesRead = (System.Int32)bytesRead_;
                completionSource.SetResult((bytesRead));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readAllAsyncCallbackDelegate = ReadAllFinish;

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into the buffer
        /// starting at @buffer. When the operation is finished @callback will be called.
        /// You can then call g_input_stream_read_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on @stream, and will
        /// result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if @count is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gssize" type="gssize" managed-name="System.Int32" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_read_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the buffer
        /// starting at <paramref name="buffer"/>. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="ReadFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on <paramref name="stream"/>, and will
        /// result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public System.Threading.Tasks.Task<System.Int32> ReadAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = readAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Like g_input_stream_read(), this tries to read @count bytes from
        /// the stream in a blocking fashion. However, rather than reading into
        /// a user-supplied buffer, this will create a new #GBytes containing
        /// the data that was read. This may be easier to use from language
        /// bindings.
        /// </summary>
        /// <remarks>
        /// If count is zero, returns a zero-length #GBytes and does nothing. A
        /// value of @count larger than %G_MAXSSIZE will cause a
        /// %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, a new #GBytes is returned. It is not an error if the
        /// size of this object is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. A zero-length #GBytes is
        /// returned on end of file (or if @count is zero), but never
        /// otherwise.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error %NULL is returned and @error is set accordingly.
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="count">
        /// maximum number of bytes that will be read from the stream. Common
        /// values include 4096 and 8192.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a new #GBytes, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_input_stream_read_bytes(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Like <see cref="Read"/>, this tries to read <paramref name="count"/> bytes from
        /// the stream in a blocking fashion. However, rather than reading into
        /// a user-supplied buffer, this will create a new #GBytes containing
        /// the data that was read. This may be easier to use from language
        /// bindings.
        /// </summary>
        /// <remarks>
        /// If count is zero, returns a zero-length #GBytes and does nothing. A
        /// value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, a new #GBytes is returned. It is not an error if the
        /// size of this object is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. A zero-length #GBytes is
        /// returned on end of file (or if <paramref name="count"/> is zero), but never
        /// otherwise.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error <c>null</c> is returned and <paramref name="error"/> is set accordingly.
        /// </remarks>
        /// <param name="count">
        /// maximum number of bytes that will be read from the stream. Common
        /// values include 4096 and 8192.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a new #GBytes, or <c>null</c> on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public GISharp.Lib.GLib.Bytes ReadBytes(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_read_bytes(stream_,count_,cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Bytes>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into a
        /// new #GBytes. When the operation is finished @callback will be
        /// called. You can then call g_input_stream_read_bytes_finish() to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed
        /// on @stream, and will result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a
        /// %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the new #GBytes will be passed to the callback. It is
        /// not an error if this is smaller than the requested size, as it can
        /// happen e.g. near the end of a file, but generally we try to read as
        /// many bytes as requested. Zero is returned on end of file (or if
        /// @count is zero), but never otherwise.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_read_bytes_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into a
        /// new #GBytes. When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="ReadBytesFinish"/> to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed
        /// on <paramref name="stream"/>, and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the new #GBytes will be passed to the callback. It is
        /// not an error if this is smaller than the requested size, as it can
        /// happen e.g. near the end of a file, but generally we try to read as
        /// many bytes as requested. Zero is returned on end of file (or if
        /// <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public System.Threading.Tasks.Task<GISharp.Lib.GLib.Bytes> ReadBytesAsync(System.Int32 count, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GLib.Bytes>();
            var callback_ = readBytesAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_bytes_async(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream read-into-#GBytes operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the newly-allocated #GBytes, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_input_stream_read_bytes_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static void ReadBytesFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GLib.Bytes>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_read_bytes_finish(stream_,result_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Bytes>(ret_, GISharp.Runtime.Transfer.Full);
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readBytesAsyncCallbackDelegate = ReadBytesFinish;

        /// <summary>
        /// Finishes an asynchronous stream read operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// number of bytes read in, or -1 on error, or 0 on end of file.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_input_stream_read_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static void ReadFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_read_finish(stream_,result_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = (System.Int32)ret_;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readAsyncCallbackDelegate = ReadFinish;

        /// <summary>
        /// Sets @stream to have actions pending. If the pending flag is
        /// already set or @stream is closed, it will return %FALSE and set
        /// @error.
        /// </summary>
        /// <param name="stream">
        /// input stream
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if pending was previously unset and is now set.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_input_stream_set_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Sets <paramref name="stream"/> to have actions pending. If the pending flag is
        /// already set or <paramref name="stream"/> is closed, it will return <c>false</c> and set
        /// <paramref name="error"/>.
        /// </summary>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public void SetPending()
        {
            var stream_ = Handle;
            var error_ = System.IntPtr.Zero;
            g_input_stream_set_pending(stream_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Tries to skip @count bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to g_input_stream_read(), from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_input_stream_skip(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Tries to skip <paramref name="count"/> bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to <see cref="Read"/>, from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public System.Int32 Skip(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_skip(stream_,count_,cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Request an asynchronous skip of @count bytes from the stream.
        /// When the operation is finished @callback will be called.
        /// You can then call g_input_stream_skip_finish() to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if @count is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gssize" type="gssize" managed-name="System.Int32" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern void g_input_stream_skip_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous skip of <paramref name="count"/> bytes from the stream.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="SkipFinish"/> to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public System.Threading.Tasks.Task<System.Int32> SkipAsync(System.Int32 count, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = skipAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_skip_async(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes a stream skip operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the size of the bytes skipped, or %-1 on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_input_stream_skip_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static void SkipFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_skip_finish(stream_,result_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = (System.Int32)ret_;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback skipAsyncCallbackDelegate = SkipFinish;

        /// <summary>
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="CloseFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseAsync))]
        protected virtual void DoCloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedCloseAsync>(_GType)(stream_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes closing a stream asynchronously, started from <see cref="CloseAsync"/>.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the stream was closed successfully.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseFinish))]
        protected virtual void DoCloseFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedCloseFinish>(_GType)(stream_, result_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseFn))]
        protected abstract void DoCloseFn(GISharp.Lib.Gio.Cancellable cancellable = null);

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the buffer
        /// starting at <paramref name="buffer"/>. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="ReadFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on <paramref name="stream"/>, and will
        /// result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadAsync))]
        protected virtual void DoReadAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? System.IntPtr.Zero, buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedReadAsync>(_GType)(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes an asynchronous stream read operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// number of bytes read in, or -1 on error, or 0 on end of file.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadFinish))]
        protected virtual System.Int32 DoReadFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedReadFinish>(_GType)(stream_,result_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadFn))]
        protected abstract System.Int32 DoReadFn(System.IntPtr buffer, System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null);

        /// <summary>
        /// Tries to skip <paramref name="count"/> bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to <see cref="Read"/>, from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkip))]
        protected abstract System.Int32 DoSkip(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null);

        /// <summary>
        /// Request an asynchronous skip of <paramref name="count"/> bytes from the stream.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="SkipFinish"/> to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkipAsync))]
        protected virtual void DoSkipAsync(System.Int32 count, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedSkipAsync>(_GType)(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes a stream skip operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// the size of the bytes skipped, or %-1 on error.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkipFinish))]
        protected virtual System.Int32 DoSkipFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedSkipFinish>(_GType)(stream_,result_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }
    }

    public class InputStreamClass : GISharp.Lib.GObject.ObjectClass
    {
        new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public UnmanagedReadFn ReadFn;
            public UnmanagedSkip Skip;
            public UnmanagedCloseFn CloseFn;
            public UnmanagedReadAsync ReadAsync;
            public UnmanagedReadFinish ReadFinish;
            public UnmanagedSkipAsync SkipAsync;
            public UnmanagedSkipFinish SkipFinish;
            public UnmanagedCloseAsync CloseAsync;
            public UnmanagedCloseFinish CloseFinish;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static InputStreamClass()
        {
            System.Int32 readFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadFn));
            RegisterVirtualMethod(readFnOffset, ReadFnFactory.Create);
            System.Int32 skipOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Skip));
            RegisterVirtualMethod(skipOffset, SkipFactory.Create);
            System.Int32 closeFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFn));
            RegisterVirtualMethod(closeFnOffset, CloseFnFactory.Create);
            System.Int32 readAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadAsync));
            RegisterVirtualMethod(readAsyncOffset, ReadAsyncFactory.Create);
            System.Int32 readFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadFinish));
            RegisterVirtualMethod(readFinishOffset, ReadFinishFactory.Create);
            System.Int32 skipAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.SkipAsync));
            RegisterVirtualMethod(skipAsyncOffset, SkipAsyncFactory.Create);
            System.Int32 skipFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.SkipFinish));
            RegisterVirtualMethod(skipFinishOffset, SkipFinishFactory.Create);
            System.Int32 closeAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseAsync));
            RegisterVirtualMethod(closeAsyncOffset, CloseAsyncFactory.Create);
            System.Int32 closeFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFinish));
            RegisterVirtualMethod(closeFinishOffset, CloseFinishFactory.Create);
        }

        public delegate System.Int32 ReadFn(System.IntPtr buffer, System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedReadFn(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gpointer" type="void*" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr buffer,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="ReadFn"/> methods.
        /// </summary>
        public static class ReadFnFactory
        {
            public static UnmanagedReadFn Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr readFn(System.IntPtr stream_, System.IntPtr buffer_, System.UIntPtr count_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var buffer = (System.IntPtr)buffer_;
                        var count = (System.Int32)count_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadFn = (ReadFn)methodInfo.CreateDelegate(typeof(ReadFn), stream);
                        var ret = doReadFn(buffer, count, cancellable);
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return readFn;
            }
        }

        public delegate System.Int32 Skip(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedSkip(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="Skip"/> methods.
        /// </summary>
        public static class SkipFactory
        {
            public static UnmanagedSkip Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr skip(System.IntPtr stream_, System.UIntPtr count_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var count = (System.Int32)count_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkip = (Skip)methodInfo.CreateDelegate(typeof(Skip), stream);
                        var ret = doSkip(count, cancellable);
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return skip;
            }
        }

        public delegate void CloseFn(GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public delegate System.Boolean UnmanagedCloseFn(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="CloseFn"/> methods.
        /// </summary>
        public static class CloseFnFactory
        {
            public static UnmanagedCloseFn Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean closeFn(System.IntPtr stream_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseFn = (CloseFn)methodInfo.CreateDelegate(typeof(CloseFn), stream);
                        doCloseFn(cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return closeFn;
            }
        }

        public delegate void ReadAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 count, GISharp.Lib.Gio.AsyncReadyCallback callback, System.IntPtr userData, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedReadAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <array length="2" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr buffer,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="gint" type="int" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 ioPriority,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:6 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:6 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="ReadAsync"/> methods.
        /// </summary>
        public static class ReadAsyncFactory
        {
            public static UnmanagedReadAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void readAsync(System.IntPtr stream_, System.IntPtr buffer_, System.UIntPtr count_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var buffer = GISharp.Runtime.CArray.GetInstance<System.Byte>(buffer_, (int)ioPriority_, GISharp.Runtime.Transfer.None);
                        var count = (System.Int32)count_;
                        var callback = GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var userData = (System.IntPtr)userData_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadAsync = (ReadAsync)methodInfo.CreateDelegate(typeof(ReadAsync), stream);
                        doReadAsync(buffer, count, callback, userData, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return readAsync;
            }
        }

        public delegate System.Int32 ReadFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedReadFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="ReadFinish"/> methods.
        /// </summary>
        public static class ReadFinishFactory
        {
            public static UnmanagedReadFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr readFinish(System.IntPtr stream_, System.IntPtr result_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None);
                        var doReadFinish = (ReadFinish)methodInfo.CreateDelegate(typeof(ReadFinish), stream);
                        var ret = doReadFinish(result);
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return readFinish;
            }
        }

        public delegate void SkipAsync(System.Int32 count, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, System.IntPtr userData, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedSkipAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="gint" type="int" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 ioPriority,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="SkipAsync"/> methods.
        /// </summary>
        public static class SkipAsyncFactory
        {
            public static UnmanagedSkipAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void skipAsync(System.IntPtr stream_, System.UIntPtr count_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var count = (System.Int32)count_;
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var userData = (System.IntPtr)userData_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkipAsync = (SkipAsync)methodInfo.CreateDelegate(typeof(SkipAsync), stream);
                        doSkipAsync(count, ioPriority, callback, userData, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return skipAsync;
            }
        }

        public delegate System.Int32 SkipFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedSkipFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="SkipFinish"/> methods.
        /// </summary>
        public static class SkipFinishFactory
        {
            public static UnmanagedSkipFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr skipFinish(System.IntPtr stream_, System.IntPtr result_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None);
                        var doSkipFinish = (SkipFinish)methodInfo.CreateDelegate(typeof(SkipFinish), stream);
                        var ret = doSkipFinish(result);
                        var ret_ = (System.IntPtr)ret;
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return skipFinish;
            }
        }

        public delegate void CloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, System.IntPtr userData, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedCloseAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gint" type="int" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 ioPriority,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="CloseAsync"/> methods.
        /// </summary>
        public static class CloseAsyncFactory
        {
            public static UnmanagedCloseAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void closeAsync(System.IntPtr stream_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var userData = (System.IntPtr)userData_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseAsync = (CloseAsync)methodInfo.CreateDelegate(typeof(CloseAsync), stream);
                        doCloseAsync(ioPriority, callback, userData, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return closeAsync;
            }
        }

        public delegate void CloseFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public delegate System.Boolean UnmanagedCloseFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Factory for creating <see cref="CloseFinish"/> methods.
        /// </summary>
        public static class CloseFinishFactory
        {
            public static UnmanagedCloseFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean closeFinish(System.IntPtr stream_, System.IntPtr result_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None);
                        var doCloseFinish = (CloseFinish)methodInfo.CreateDelegate(typeof(CloseFinish), stream);
                        doCloseFinish(result);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return closeFinish;
            }
        }

        public InputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

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
        /// If the action is disabled then calls to <see cref="Activate"/> and
        /// <see cref="ChangeState"/> have no effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        public System.Boolean Enabled { get => (System.Boolean)GetProperty("enabled"); set => SetProperty("enabled", value); }

        /// <summary>
        /// The name of the action. This is mostly meaningful for identifying
        /// the action once it has been added to a #GSimpleActionGroup.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8 Name { get => (GISharp.Lib.GLib.Utf8)GetProperty("name"); set => SetProperty("name", value); }

        /// <summary>
        /// The type of the parameter that must be given when activating the
        /// action.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.VariantType ParameterType { get => (GISharp.Lib.GLib.VariantType)GetProperty("parameter-type"); set => SetProperty("parameter-type", value); }

        /// <summary>
        /// The state of the action, or <c>null</c> if the action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state", Construct = GISharp.Runtime.GPropertyConstruct.Yes)]
        public GISharp.Lib.GLib.Variant State { get => (GISharp.Lib.GLib.Variant)GetProperty("state"); set => SetProperty("state", value); }

        /// <summary>
        /// The #GVariantType of the state that the action has, or <c>null</c> if the
        /// action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        public GISharp.Lib.GLib.VariantType StateType { get => (GISharp.Lib.GLib.VariantType)GetProperty("state-type"); }

        public SimpleAction(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless.  See g_simple_action_new_stateful().
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter to the activate function
        /// </param>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_simple_action_new(
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
        /// The created action is stateless.  See <see cref="NewStateful"/>.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter to the activate function
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static System.IntPtr New(GISharp.Lib.GLib.Utf8 name, GISharp.Lib.GLib.VariantType parameterType)
        {
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_simple_action_new(name_,parameterType_);
            return ret_;
        }

        /// <summary>
        /// Creates a new action.
        /// </summary>
        /// <remarks>
        /// The created action is stateless.  See <see cref="NewStateful"/>.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of parameter to the activate function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Lib.GLib.Utf8 name, GISharp.Lib.GLib.VariantType parameterType) : this(New(name, parameterType), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// @state is the initial state of the action.  All future state values
        /// must have the same #GVariantType as the initial state.
        /// 
        /// If the @state GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter to the activate function
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
        static extern System.IntPtr g_simple_action_new_stateful(
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
        /// <paramref name="state"/> is the initial state of the action.  All future state values
        /// must have the same #GVariantType as the initial state.
        /// 
        /// If the <paramref name="state"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter to the activate function
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <returns>
        /// a new <see cref="SimpleAction"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static System.IntPtr NewStateful(GISharp.Lib.GLib.Utf8 name, GISharp.Lib.GLib.VariantType parameterType, GISharp.Lib.GLib.Variant state)
        {
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var state_ = state?.Handle ?? throw new System.ArgumentNullException(nameof(state));
            var ret_ = g_simple_action_new_stateful(name_,parameterType_,state_);
            return ret_;
        }

        /// <summary>
        /// Creates a new stateful action.
        /// </summary>
        /// <remarks>
        /// <paramref name="state"/> is the initial state of the action.  All future state values
        /// must have the same #GVariantType as the initial state.
        /// 
        /// If the <paramref name="state"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="name">
        /// the name of the action
        /// </param>
        /// <param name="parameterType">
        /// the type of the parameter to the activate function
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.Lib.GLib.Utf8 name, GISharp.Lib.GLib.VariantType parameterType, GISharp.Lib.GLib.Variant state) : this(NewStateful(name, parameterType, state), GISharp.Runtime.Transfer.Full)
        {
        }

        public sealed class ActivatedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Variant Parameter => (GISharp.Lib.GLib.Variant)args[1].Get();

            public ActivatedEventArgs(GISharp.Lib.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<ActivatedEventArgs> activatedSignalManager = new GISharp.Runtime.GSignalManager<ActivatedEventArgs>("activate", _GType);

        /// <summary>
        /// Indicates that the action was just activated.
        /// </summary>
        /// <remarks>
        /// <paramref name="parameter"/> will always be of the expected type.  In the event that
        /// an incorrect type was given, no signal will be emitted.
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
            readonly GISharp.Lib.GObject.Value[] args;

            public GISharp.Lib.GLib.Variant Value => (GISharp.Lib.GLib.Variant)args[1].Get();

            public ChangedStateEventArgs(GISharp.Lib.GObject.Value[] args)
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
        /// <paramref name="value"/> will always be of the correct state type.  In the event that
        /// an incorrect type was given, no signal will be emitted.
        /// 
        /// If no handler is connected to this signal then the default
        /// behaviour is to call <see cref="SetState"/> to set the state
        /// to the requested value. If you connect a signal handler then no
        /// default action is taken. If the state should change then you must
        /// call <see cref="SetState"/> from the handler.
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
        static extern GISharp.Lib.GObject.GType g_simple_action_get_type();

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
        static extern void g_simple_action_set_enabled(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean enabled);

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
        public void SetEnabled(System.Boolean enabled)
        {
            var simple_ = Handle;
            var enabled_ = (System.Boolean)enabled;
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
        static extern void g_simple_action_set_state(
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
        /// property.  Instead, they should call <see cref="ChangeState"/> to
        /// request the change.
        /// 
        /// If the <paramref name="value"/> GVariant is floating, it is consumed.
        /// </remarks>
        /// <param name="value">
        /// the new #GVariant for the state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        public void SetState(GISharp.Lib.GLib.Variant value)
        {
            var simple_ = Handle;
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
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
        static extern void g_simple_action_set_state_hint(
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
        /// See <see cref="GetStateHint"/> for more information about
        /// action state hints.
        /// </remarks>
        /// <param name="stateHint">
        /// a #GVariant representing the state hint
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public void SetStateHint(GISharp.Lib.GLib.Variant stateHint)
        {
            var simple_ = Handle;
            var stateHint_ = stateHint?.Handle ?? System.IntPtr.Zero;
            g_simple_action_set_state_hint(simple_, stateHint_);
        }

        void GISharp.Lib.Gio.IAction.DoActivate(GISharp.Lib.GLib.Variant parameter)
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

        GISharp.Lib.GLib.Utf8 GISharp.Lib.Gio.IAction.DoGetName()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType GISharp.Lib.Gio.IAction.DoGetParameterType()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IAction.DoGetState()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IAction.DoGetStateHint()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType GISharp.Lib.Gio.IAction.DoGetStateType()
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// A <see cref="Task"/> represents and manages a cancellable "task".
    /// </summary>
    /// <remarks>
    /// ## Asynchronous operations
    /// 
    /// The most common usage of <see cref="Task"/> is as a <see cref="IAsyncResult"/>, to
    /// manage data during an asynchronous operation. You call
    /// <see cref="New"/> in the "start" method, followed by
    /// <see cref="SetTaskData"/> and the like if you need to keep some
    /// additional data associated with the task, and then pass the
    /// task object around through your asynchronous operation.
    /// Eventually, you will call a method such as
    /// <see cref="ReturnPointer"/> or <see cref="ReturnError"/>, which will
    /// save the value you give it and then invoke the task's callback
    /// function (waiting until the next iteration of the main
    /// loop first, if necessary). The caller will pass the <see cref="Task"/> back
    /// to the operation's finish function (as a <see cref="IAsyncResult"/>), and
    /// you can use <see cref="PropagatePointer"/> or the like to extract
    /// the return value.
    /// 
    /// Here is an example for using GTask as a GAsyncResult:
    /// |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } DecorationData;
    /// 
    ///     static void
    ///     decoration_data_free (DecorationData *decoration)
    ///     {
    ///       g_free (decoration-&gt;message);
    ///       g_slice_free (DecorationData, decoration);
    ///     }
    /// 
    ///     static void
    ///     baked_cb (Cake     *cake,
    ///               gpointer  user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       DecorationData *decoration = g_task_get_task_data (task);
    ///       GError *error = NULL;
    /// 
    ///       if (cake == NULL)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_NO_FLOUR,
    ///                                    "Go to the supermarket");
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       if (!cake_decorate (cake, decoration-&gt;frosting, decoration-&gt;message, &amp;error))
    ///         {
    ///           g_object_unref (cake);
    ///           // <see cref="ReturnError"/> takes ownership of error
    ///           g_task_return_error (task, error);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       g_task_return_pointer (task, cake, g_object_unref);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       GTask *task;
    ///       DecorationData *decoration;
    ///       Cake  *cake;
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       if (radius &lt; 3)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_TOO_SMALL,
    ///                                    "%ucm radius cakes are silly",
    ///                                    radius);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       cake = _baker_get_cached_cake (self, radius, flavor, frosting, message);
    ///       if (cake != NULL)
    ///         {
    ///           // _baker_get_cached_cake() returns a reffed cake
    ///           g_task_return_pointer (task, cake, g_object_unref);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       decoration = g_slice_new (DecorationData);
    ///       decoration-&gt;frosting = frosting;
    ///       decoration-&gt;message = g_strdup (message);
    ///       g_task_set_task_data (task, decoration, (GDestroyNotify) decoration_data_free);
    /// 
    ///       _baker_begin_cake (self, radius, flavor, cancellable, baked_cb, task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Chained asynchronous operations
    /// 
    /// <see cref="Task"/> also tries to simplify asynchronous operations that
    /// internally chain together several smaller asynchronous
    /// operations. <see cref="GetCancellable"/>, <see cref="GetContext"/>,
    /// and <see cref="GetPriority"/> allow you to get back the task's
    /// <see cref="Cancellable"/>, #GMainContext, and [I/O priority][io-priority]
    /// when starting a new subtask, so you don't have to keep track
    /// of them yourself. g_task_attach_source() simplifies the case
    /// of waiting for a source to fire (automatically using the correct
    /// #GMainContext and priority).
    /// 
    /// Here is an example for chained asynchronous operations:
    ///   |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       Cake *cake;
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } BakingData;
    /// 
    ///     static void
    ///     decoration_data_free (BakingData *bd)
    ///     {
    ///       if (bd-&gt;cake)
    ///         g_object_unref (bd-&gt;cake);
    ///       g_free (bd-&gt;message);
    ///       g_slice_free (BakingData, bd);
    ///     }
    /// 
    ///     static void
    ///     decorated_cb (Cake         *cake,
    ///                   GAsyncResult *result,
    ///                   gpointer      user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       GError *error = NULL;
    /// 
    ///       if (!cake_decorate_finish (cake, result, &amp;error))
    ///         {
    ///           g_object_unref (cake);
    ///           g_task_return_error (task, error);
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       // baking_data_free() will drop its ref on the cake, so we have to
    ///       // take another here to give to the caller.
    ///       g_task_return_pointer (task, g_object_ref (cake), g_object_unref);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     static gboolean
    ///     decorator_ready (gpointer user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       BakingData *bd = g_task_get_task_data (task);
    /// 
    ///       cake_decorate_async (bd-&gt;cake, bd-&gt;frosting, bd-&gt;message,
    ///                            g_task_get_cancellable (task),
    ///                            decorated_cb, task);
    /// 
    ///       return G_SOURCE_REMOVE;
    ///     }
    /// 
    ///     static void
    ///     baked_cb (Cake     *cake,
    ///               gpointer  user_data)
    ///     {
    ///       GTask *task = user_data;
    ///       BakingData *bd = g_task_get_task_data (task);
    ///       GError *error = NULL;
    /// 
    ///       if (cake == NULL)
    ///         {
    ///           g_task_return_new_error (task, BAKER_ERROR, BAKER_ERROR_NO_FLOUR,
    ///                                    "Go to the supermarket");
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       bd-&gt;cake = cake;
    /// 
    ///       // Bail out now if the user has already cancelled
    ///       if (g_task_return_error_if_cancelled (task))
    ///         {
    ///           g_object_unref (task);
    ///           return;
    ///         }
    /// 
    ///       if (cake_decorator_available (cake))
    ///         decorator_ready (task);
    ///       else
    ///         {
    ///           GSource *source;
    /// 
    ///           source = cake_decorator_wait_source_new (cake);
    ///           // Attach <paramref name="source"/> to <paramref name="task"/>'s GMainContext and have it call
    ///           // decorator_ready() when it is ready.
    ///           g_task_attach_source (task, source, decorator_ready);
    ///           g_source_unref (source);
    ///         }
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            gint                 priority,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       GTask *task;
    ///       BakingData *bd;
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_priority (task, priority);
    /// 
    ///       bd = g_slice_new0 (BakingData);
    ///       bd-&gt;frosting = frosting;
    ///       bd-&gt;message = g_strdup (message);
    ///       g_task_set_task_data (task, bd, (GDestroyNotify) baking_data_free);
    /// 
    ///       _baker_begin_cake (self, radius, flavor, cancellable, baked_cb, task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Asynchronous operations from synchronous ones
    /// 
    /// You can use g_task_run_in_thread() to turn a synchronous
    /// operation into an asynchronous one, by running it in a thread
    /// which will then dispatch the result back to the caller's
    /// #GMainContext when it completes.
    /// 
    /// Running a task in a thread:
    ///   |[&lt;!-- language="C" --&gt;
    ///     typedef struct {
    ///       guint radius;
    ///       CakeFlavor flavor;
    ///       CakeFrostingType frosting;
    ///       char *message;
    ///     } CakeData;
    /// 
    ///     static void
    ///     cake_data_free (CakeData *cake_data)
    ///     {
    ///       g_free (cake_data-&gt;message);
    ///       g_slice_free (CakeData, cake_data);
    ///     }
    /// 
    ///     static void
    ///     bake_cake_thread (GTask         *task,
    ///                       gpointer       source_object,
    ///                       gpointer       task_data,
    ///                       GCancellable  *cancellable)
    ///     {
    ///       Baker *self = source_object;
    ///       CakeData *cake_data = task_data;
    ///       Cake *cake;
    ///       GError *error = NULL;
    /// 
    ///       cake = bake_cake (baker, cake_data-&gt;radius, cake_data-&gt;flavor,
    ///                         cake_data-&gt;frosting, cake_data-&gt;message,
    ///                         cancellable, &amp;error);
    ///       if (cake)
    ///         g_task_return_pointer (task, cake, g_object_unref);
    ///       else
    ///         g_task_return_error (task, error);
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    ///       cake_data-&gt;radius = radius;
    ///       cake_data-&gt;flavor = flavor;
    ///       cake_data-&gt;frosting = frosting;
    ///       cake_data-&gt;message = g_strdup (message);
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_run_in_thread (task, bake_cake_thread);
    ///       g_object_unref (task);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_finish (Baker         *self,
    ///                             GAsyncResult  *result,
    ///                             GError       **error)
    ///     {
    ///       g_return_val_if_fail (g_task_is_valid (result, self), NULL);
    /// 
    ///       return g_task_propagate_pointer (G_TASK (result), error);
    ///     }
    /// ]|
    /// 
    /// ## Adding cancellability to uncancellable tasks
    /// 
    /// Finally, g_task_run_in_thread() and g_task_run_in_thread_sync()
    /// can be used to turn an uncancellable operation into a
    /// cancellable one. If you call <see cref="SetReturnOnCancel"/>,
    /// passing <c>true</c>, then if the task's <see cref="Cancellable"/> is cancelled,
    /// it will return control back to the caller immediately, while
    /// allowing the task thread to continue running in the background
    /// (and simply discarding its result when it finally does finish).
    /// Provided that the task thread is careful about how it uses
    /// locks and other externally-visible resources, this allows you
    /// to make "GLib-friendly" asynchronous and cancellable
    /// synchronous variants of blocking APIs.
    /// 
    /// Cancelling a task:
    ///   |[&lt;!-- language="C" --&gt;
    ///     static void
    ///     bake_cake_thread (GTask         *task,
    ///                       gpointer       source_object,
    ///                       gpointer       task_data,
    ///                       GCancellable  *cancellable)
    ///     {
    ///       Baker *self = source_object;
    ///       CakeData *cake_data = task_data;
    ///       Cake *cake;
    ///       GError *error = NULL;
    /// 
    ///       cake = bake_cake (baker, cake_data-&gt;radius, cake_data-&gt;flavor,
    ///                         cake_data-&gt;frosting, cake_data-&gt;message,
    ///                         &amp;error);
    ///       if (error)
    ///         {
    ///           g_task_return_error (task, error);
    ///           return;
    ///         }
    /// 
    ///       // If the task has already been cancelled, then we don't want to add
    ///       // the cake to the cake cache. Likewise, we don't  want to have the
    ///       // task get cancelled in the middle of updating the cache.
    ///       // <see cref="SetReturnOnCancel"/> will return <c>true</c> here if it managed
    ///       // to disable return-on-cancel, or <c>false</c> if the task was cancelled
    ///       // before it could.
    ///       if (g_task_set_return_on_cancel (task, FALSE))
    ///         {
    ///           // If the caller cancels at this point, their
    ///           // GAsyncReadyCallback won't be invoked until we return,
    ///           // so we don't have to worry that this code will run at
    ///           // the same time as that code does. But if there were
    ///           // other functions that might look at the cake cache,
    ///           // then we'd probably need a GMutex here as well.
    ///           baker_add_cake_to_cache (baker, cake);
    ///           g_task_return_pointer (task, cake, g_object_unref);
    ///         }
    ///     }
    /// 
    ///     void
    ///     baker_bake_cake_async (Baker               *self,
    ///                            guint                radius,
    ///                            CakeFlavor           flavor,
    ///                            CakeFrostingType     frosting,
    ///                            const char          *message,
    ///                            GCancellable        *cancellable,
    ///                            GAsyncReadyCallback  callback,
    ///                            gpointer             user_data)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    /// 
    ///       ...
    /// 
    ///       task = g_task_new (self, cancellable, callback, user_data);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_set_return_on_cancel (task, TRUE);
    ///       g_task_run_in_thread (task, bake_cake_thread);
    ///     }
    /// 
    ///     Cake *
    ///     baker_bake_cake_sync (Baker               *self,
    ///                           guint                radius,
    ///                           CakeFlavor           flavor,
    ///                           CakeFrostingType     frosting,
    ///                           const char          *message,
    ///                           GCancellable        *cancellable,
    ///                           GError             **error)
    ///     {
    ///       CakeData *cake_data;
    ///       GTask *task;
    ///       Cake *cake;
    /// 
    ///       cake_data = g_slice_new (CakeData);
    /// 
    ///       ...
    /// 
    ///       task = g_task_new (self, cancellable, NULL, NULL);
    ///       g_task_set_task_data (task, cake_data, (GDestroyNotify) cake_data_free);
    ///       g_task_set_return_on_cancel (task, TRUE);
    ///       g_task_run_in_thread_sync (task, bake_cake_thread);
    /// 
    ///       cake = g_task_propagate_pointer (task, error);
    ///       g_object_unref (task);
    ///       return cake;
    ///     }
    /// ]|
    /// 
    /// ## Porting from GSimpleAsyncResult
    /// 
    /// <see cref="Task"/>'s API attempts to be simpler than #GSimpleAsyncResult's
    /// in several ways:
    /// - You can save task-specific data with <see cref="SetTaskData"/>, and
    ///   retrieve it later with <see cref="GetTaskData"/>. This replaces the
    ///   abuse of g_simple_async_result_set_op_res_gpointer() for the same
    ///   purpose with #GSimpleAsyncResult.
    /// - In addition to the task data, <see cref="Task"/> also keeps track of the
    ///   [priority][io-priority], <see cref="Cancellable"/>, and
    ///   #GMainContext associated with the task, so tasks that consist of
    ///   a chain of simpler asynchronous operations will have easy access
    ///   to those values when starting each sub-task.
    /// - <see cref="ReturnErrorIfCancelled"/> provides simplified
    ///   handling for cancellation. In addition, cancellation
    ///   overrides any other <see cref="Task"/> return value by default, like
    ///   #GSimpleAsyncResult does when
    ///   g_simple_async_result_set_check_cancellable() is called.
    ///   (You can use <see cref="SetCheckCancellable"/> to turn off that
    ///   behavior.) On the other hand, g_task_run_in_thread()
    ///   guarantees that it will always run your
    ///   `task_func`, even if the task's <see cref="Cancellable"/>
    ///   is already cancelled before the task gets a chance to run;
    ///   you can start your `task_func` with a
    ///   <see cref="ReturnErrorIfCancelled"/> check if you need the
    ///   old behavior.
    /// - The "return" methods (eg, <see cref="ReturnPointer"/>)
    ///   automatically cause the task to be "completed" as well, and
    ///   there is no need to worry about the "complete" vs "complete
    ///   in idle" distinction. (<see cref="Task"/> automatically figures out
    ///   whether the task's callback can be invoked directly, or
    ///   if it needs to be sent to another #GMainContext, or delayed
    ///   until the next iteration of the current #GMainContext.)
    /// - The "finish" functions for <see cref="Task"/>-based operations are generally
    ///   much simpler than #GSimpleAsyncResult ones, normally consisting
    ///   of only a single call to <see cref="PropagatePointer"/> or the like.
    ///   Since <see cref="PropagatePointer"/> "steals" the return value from
    ///   the <see cref="Task"/>, it is not necessary to juggle pointers around to
    ///   prevent it from being freed twice.
    /// - With #GSimpleAsyncResult, it was common to call
    ///   g_simple_async_result_propagate_error() from the
    ///   `_finish()` wrapper function, and have
    ///   virtual method implementations only deal with successful
    ///   returns. This behavior is deprecated, because it makes it
    ///   difficult for a subclass to chain to a parent class's async
    ///   methods. Instead, the wrapper function should just be a
    ///   simple wrapper, and the virtual method should call an
    ///   appropriate `g_task_propagate_` function.
    ///   Note that wrapper methods can now use
    ///   g_async_result_legacy_propagate_error() to do old-style
    ///   #GSimpleAsyncResult error-returning behavior, and
    ///   <see cref="IsTagged"/> to check if a result is tagged as
    ///   having come from the `_async()` wrapper
    ///   function (for "short-circuit" results, such as when passing
    ///   0 to <see cref="ReadAsync"/>).
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GTask", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(TaskClass))]
    public partial class Task : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IAsyncResult
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_task_get_type();

        /// <summary>
        /// Whether the task has completed, meaning its callback (if set) has been
        /// invoked. This can only happen after <see cref="ReturnPointer"/>,
        /// <see cref="ReturnError"/> or one of the other return functions have been called
        /// on the task.
        /// </summary>
        /// <remarks>
        /// This property is guaranteed to change from <c>false</c> to <c>true</c> exactly once.
        /// 
        /// The #GObject::notify signal for this change is emitted in the same main
        /// context as the task’s callback, immediately after that callback is invoked.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [GISharp.Runtime.GPropertyAttribute("completed")]
        public System.Boolean Completed_ { get => (System.Boolean)GetProperty("completed"); }

        /// <summary>
        /// Gets <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.Gio.Cancellable Cancellable { get => GetCancellable(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s check-cancellable flag. See
        /// <see cref="SetCheckCancellable"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean CheckCancellable { get => GetCheckCancellable(); set => SetCheckCancellable(value); }

        /// <summary>
        /// Gets the value of <see cref="Task"/>:completed. This changes from <c>false</c> to <c>true</c> after
        /// the task’s callback is invoked, and will return <c>false</c> if called from inside
        /// the callback.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public System.Boolean Completed { get => GetCompleted(); }

        /// <summary>
        /// Gets the #GMainContext that <paramref name="task"/> will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when <paramref name="task"/> was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-<c>null</c> value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.GLib.MainContext Context { get => GetContext(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s priority
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Int32 Priority { get => GetPriority(); set => SetPriority(value); }

        /// <summary>
        /// Gets <paramref name="task"/>'s return-on-cancel flag. See
        /// <see cref="SetReturnOnCancel"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean ReturnOnCancel { get => GetReturnOnCancel(); }

        /// <summary>
        /// Gets the source object from <paramref name="task"/>. Like
        /// <see cref="GetSourceObject"/>, but does not ref the object.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.GObject.Object SourceObject { get => GetSourceObject(); }

        /// <summary>
        /// Gets <paramref name="task"/>'s source tag. See <see cref="SetSourceTag"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.IntPtr SourceTag { get => GetSourceTag(); set => SetSourceTag(value); }

        /// <summary>
        /// Gets <paramref name="task"/>'s `task_data`.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.IntPtr TaskData { get => GetTaskData(); }

        public Task(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a #GTask acting on @source_object, which will eventually be
        /// used to invoke @callback in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the #GTask around throughout the asynchronous operation. You
        /// can use g_task_set_task_data() to attach task-specific data to the
        /// object, which you can retrieve later via g_task_get_task_data().
        /// 
        /// By default, if @cancellable is cancelled, then the return value of
        /// the task will always be %G_IO_ERROR_CANCELLED, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// g_task_set_check_cancellable() to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or %NULL.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback.
        /// </param>
        /// <param name="callbackData">
        /// user data passed to @callback.
        /// </param>
        /// <returns>
        /// a #GTask.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_task_new(
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr callbackData);

        /// <summary>
        /// Creates a <see cref="Task"/> acting on <paramref name="sourceObject"/>, which will eventually be
        /// used to invoke <paramref name="callback"/> in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the <see cref="Task"/> around throughout the asynchronous operation. You
        /// can use <see cref="SetTaskData"/> to attach task-specific data to the
        /// object, which you can retrieve later via <see cref="GetTaskData"/>.
        /// 
        /// By default, if <paramref name="cancellable"/> is cancelled, then the return value of
        /// the task will always be <see cref="IOErrorEnum.Cancelled"/>, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// <see cref="SetCheckCancellable"/> to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a <see cref="Task"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        static System.IntPtr New(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var (callback_, _, callbackData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_task_new(sourceObject_,cancellable_,callback_,callbackData_);
            return ret_;
        }

        /// <summary>
        /// Creates a <see cref="Task"/> acting on <paramref name="sourceObject"/>, which will eventually be
        /// used to invoke <paramref name="callback"/> in the current
        /// [thread-default main context][g-main-context-push-thread-default].
        /// </summary>
        /// <remarks>
        /// Call this in the "start" method of your asynchronous method, and
        /// pass the <see cref="Task"/> around throughout the asynchronous operation. You
        /// can use <see cref="SetTaskData"/> to attach task-specific data to the
        /// object, which you can retrieve later via <see cref="GetTaskData"/>.
        /// 
        /// By default, if <paramref name="cancellable"/> is cancelled, then the return value of
        /// the task will always be <see cref="IOErrorEnum.Cancelled"/>, even if the task had
        /// already completed before the cancellation. This allows for
        /// simplified handling in cases where cancellation may imply that
        /// other objects that the task depends on have been destroyed. If you
        /// do not want this behavior, you can use
        /// <see cref="SetCheckCancellable"/> to change it.
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public Task(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null) : this(New(sourceObject, callback, cancellable), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Checks that @result is a #GTask, and that @source_object is its
        /// source object (or that @source_object is %NULL and @result has no
        /// source object). This can be used in g_return_if_fail() checks.
        /// </summary>
        /// <param name="result">
        /// A #GAsyncResult
        /// </param>
        /// <param name="sourceObject">
        /// the source object
        ///   expected to be associated with the task
        /// </param>
        /// <returns>
        /// %TRUE if @result and @source_object are valid, %FALSE
        /// if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_is_valid(
        /* <type name="AsyncResult" type="gpointer" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject);

        /// <summary>
        /// Checks that <paramref name="result"/> is a <see cref="Task"/>, and that <paramref name="sourceObject"/> is its
        /// source object (or that <paramref name="sourceObject"/> is <c>null</c> and <paramref name="result"/> has no
        /// source object). This can be used in g_return_if_fail() checks.
        /// </summary>
        /// <param name="result">
        /// A <see cref="IAsyncResult"/>
        /// </param>
        /// <param name="sourceObject">
        /// the source object
        ///   expected to be associated with the task
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="result"/> and <paramref name="sourceObject"/> are valid, <c>false</c>
        /// if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public static System.Boolean IsValid(GISharp.Lib.Gio.IAsyncResult result, GISharp.Lib.GObject.Object sourceObject)
        {
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_task_is_valid(result_,sourceObject_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a #GTask and then immediately calls g_task_return_error()
        /// on it. Use this in the wrapper function of an asynchronous method
        /// when you want to avoid even calling the virtual method. You can
        /// then use g_async_result_is_tagged() in the finish method wrapper to
        /// check if the result there is tagged as having been created by the
        /// wrapper method, and deal with it appropriately if so.
        /// </summary>
        /// <remarks>
        /// See also g_task_report_new_error().
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or %NULL.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback.
        /// </param>
        /// <param name="callbackData">
        /// user data passed to @callback.
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        /// <param name="error">
        /// error to report
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_report_error(
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceObject,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:2 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr callbackData,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag,
        /* <type name="GLib.Error" type="GError*" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr error);

        /// <summary>
        /// Creates a <see cref="Task"/> and then immediately calls <see cref="ReturnError"/>
        /// on it. Use this in the wrapper function of an asynchronous method
        /// when you want to avoid even calling the virtual method. You can
        /// then use <see cref="IsTagged"/> in the finish method wrapper to
        /// check if the result there is tagged as having been created by the
        /// wrapper method, and deal with it appropriately if so.
        /// </summary>
        /// <remarks>
        /// See also g_task_report_new_error().
        /// </remarks>
        /// <param name="sourceObject">
        /// the #GObject that owns
        ///   this task, or <c>null</c>.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        /// <param name="error">
        /// error to report
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public static void ReportError(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.AsyncReadyCallback callback, System.IntPtr sourceTag, GISharp.Lib.GLib.Error error)
        {
            var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
            var (callback_, _, callbackData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var sourceTag_ = (System.IntPtr)sourceTag;
            var error_ = error?.Take() ?? throw new System.ArgumentNullException(nameof(error));
            g_task_report_error(sourceObject_, callback_, callbackData_, sourceTag_, error_);
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_task_get_type();

        /// <summary>
        /// Gets @task's #GCancellable
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's #GCancellable
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_task_get_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s <see cref="Cancellable"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private GISharp.Lib.Gio.Cancellable GetCancellable()
        {
            var task_ = Handle;
            var ret_ = g_task_get_cancellable(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's check-cancellable flag. See
        /// g_task_set_check_cancellable() for more details.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_get_check_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s check-cancellable flag. See
        /// <see cref="SetCheckCancellable"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private System.Boolean GetCheckCancellable()
        {
            var task_ = Handle;
            var ret_ = g_task_get_check_cancellable(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of #GTask:completed. This changes from %FALSE to %TRUE after
        /// the task’s callback is invoked, and will return %FALSE if called from inside
        /// the callback.
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <returns>
        /// %TRUE if the task has completed, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_get_completed(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the value of <see cref="Task"/>:completed. This changes from <c>false</c> to <c>true</c> after
        /// the task’s callback is invoked, and will return <c>false</c> if called from inside
        /// the callback.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the task has completed, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private System.Boolean GetCompleted()
        {
            var task_ = Handle;
            var ret_ = g_task_get_completed(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the #GMainContext that @task will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when @task was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-%NULL value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's #GMainContext
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.MainContext" type="GMainContext*" managed-name="GISharp.Lib.GLib.MainContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_task_get_context(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the #GMainContext that <paramref name="task"/> will return its result in (that
        /// is, the context that was the
        /// [thread-default main context][g-main-context-push-thread-default]
        /// at the point when <paramref name="task"/> was created).
        /// </summary>
        /// <remarks>
        /// This will always return a non-<c>null</c> value, even if the task's
        /// context is the default #GMainContext.
        /// </remarks>
        /// <returns>
        /// <paramref name="task"/>'s #GMainContext
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private GISharp.Lib.GLib.MainContext GetContext()
        {
            var task_ = Handle;
            var ret_ = g_task_get_context(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.MainContext>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's priority
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's priority
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Int32 g_task_get_priority(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s priority
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s priority
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private System.Int32 GetPriority()
        {
            var task_ = Handle;
            var ret_ = g_task_get_priority(task_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets @task's return-on-cancel flag. See
        /// g_task_set_return_on_cancel() for more details.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_get_return_on_cancel(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s return-on-cancel flag. See
        /// <see cref="SetReturnOnCancel"/> for more details.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private System.Boolean GetReturnOnCancel()
        {
            var task_ = Handle;
            var ret_ = g_task_get_return_on_cancel(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the source object from @task. Like
        /// g_async_result_get_source_object(), but does not ref the object.
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's source object, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_task_get_source_object(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets the source object from <paramref name="task"/>. Like
        /// <see cref="GetSourceObject"/>, but does not ref the object.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s source object, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private GISharp.Lib.GObject.Object GetSourceObject()
        {
            var task_ = Handle;
            var ret_ = g_task_get_source_object(task_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets @task's source tag. See g_task_set_source_tag().
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's source tag
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_task_get_source_tag(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s source tag. See <see cref="SetSourceTag"/>.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s source tag
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private System.IntPtr GetSourceTag()
        {
            var task_ = Handle;
            var ret_ = g_task_get_source_tag(task_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Gets @task's `task_data`.
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// @task's `task_data`.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_task_get_task_data(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Gets <paramref name="task"/>'s `task_data`.
        /// </summary>
        /// <returns>
        /// <paramref name="task"/>'s `task_data`.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private System.IntPtr GetTaskData()
        {
            var task_ = Handle;
            var ret_ = g_task_get_task_data(task_);
            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Tests if @task resulted in an error.
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <returns>
        /// %TRUE if the task resulted in an error, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_had_error(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Tests if <paramref name="task"/> resulted in an error.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the task resulted in an error, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean HadError()
        {
            var task_ = Handle;
            var ret_ = g_task_had_error(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the result of @task as a #gboolean.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return %FALSE and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or %FALSE on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_task_propagate_boolean(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as a #gboolean.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return <c>false</c> and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public void PropagateBoolean()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            g_task_propagate_boolean(task_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Gets the result of @task as an integer (#gssize).
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return -1 and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or -1 on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_task_propagate_int(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as an integer (#gssize).
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return -1 and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <returns>
        /// the task result, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Int32 PropagateInt()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_task_propagate_int(task_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the result of @task as a pointer, and transfers ownership
        /// of that value to the caller.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return %NULL and set @error.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the task result, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_task_propagate_pointer(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// Gets the result of <paramref name="task"/> as a pointer, and transfers ownership
        /// of that value to the caller.
        /// </summary>
        /// <remarks>
        /// If the task resulted in an error, or was cancelled, then this will
        /// instead return <c>null</c> and set <paramref name="error"/>.
        /// 
        /// Since this method transfers ownership of the return value (or
        /// error) to the caller, you may only call it once.
        /// </remarks>
        /// <returns>
        /// the task result, or <c>null</c> on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.IntPtr PropagatePointer()
        {
            var task_ = Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_task_propagate_pointer(task_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="result">
        /// the #gboolean result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_return_boolean(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean result);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="result"/> and completes the task (see
        /// <see cref="ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="result">
        /// the #gboolean result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public void ReturnBoolean(System.Boolean result)
        {
            var task_ = Handle;
            var result_ = (System.Boolean)result;
            g_task_return_boolean(task_, result_);
        }

        /// <summary>
        /// Sets @task's result to @error (which @task assumes ownership of)
        /// and completes the task (see g_task_return_pointer() for more
        /// discussion of exactly what this means).
        /// </summary>
        /// <remarks>
        /// Note that since the task takes ownership of @error, and since the
        /// task may be completed before returning from g_task_return_error(),
        /// you cannot assume that @error is still valid after calling this.
        /// Call g_error_copy() on the error if you need to keep a local copy
        /// as well.
        /// 
        /// See also g_task_return_new_error().
        /// </remarks>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="error">
        /// the #GError result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_return_error(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="GLib.Error" type="GError*" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr error);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="error"/> (which <paramref name="task"/> assumes ownership of)
        /// and completes the task (see <see cref="ReturnPointer"/> for more
        /// discussion of exactly what this means).
        /// </summary>
        /// <remarks>
        /// Note that since the task takes ownership of <paramref name="error"/>, and since the
        /// task may be completed before returning from <see cref="ReturnError"/>,
        /// you cannot assume that <paramref name="error"/> is still valid after calling this.
        /// Call g_error_copy() on the error if you need to keep a local copy
        /// as well.
        /// 
        /// See also g_task_return_new_error().
        /// </remarks>
        /// <param name="error">
        /// the #GError result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public void ReturnError(GISharp.Lib.GLib.Error error)
        {
            var task_ = Handle;
            var error_ = error?.Take() ?? throw new System.ArgumentNullException(nameof(error));
            g_task_return_error(task_, error_);
        }

        /// <summary>
        /// Checks if @task's #GCancellable has been cancelled, and if so, sets
        /// @task's error accordingly and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <returns>
        /// %TRUE if @task has been cancelled, %FALSE if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_return_error_if_cancelled(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task);

        /// <summary>
        /// Checks if <paramref name="task"/>'s <see cref="Cancellable"/> has been cancelled, and if so, sets
        /// <paramref name="task"/>'s error accordingly and completes the task (see
        /// <see cref="ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="task"/> has been cancelled, <c>false</c> if not
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean ReturnErrorIfCancelled()
        {
            var task_ = Handle;
            var ret_ = g_task_return_error_if_cancelled(task_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task (see
        /// g_task_return_pointer() for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="task">
        /// a #GTask.
        /// </param>
        /// <param name="result">
        /// the integer (#gssize) result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_return_int(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result);

        /// <summary>
        /// Sets <paramref name="task"/>'s result to <paramref name="result"/> and completes the task (see
        /// <see cref="ReturnPointer"/> for more discussion of exactly what this
        /// means).
        /// </summary>
        /// <param name="result">
        /// the integer (#gssize) result of a task function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public void ReturnInt(System.Int32 result)
        {
            var task_ = Handle;
            var result_ = (System.IntPtr)result;
            g_task_return_int(task_, result_);
        }

        /// <summary>
        /// Sets @task's result to @result and completes the task. If @result
        /// is not %NULL, then @result_destroy will be used to free @result if
        /// the caller does not take ownership of it with
        /// g_task_propagate_pointer().
        /// </summary>
        /// <remarks>
        /// "Completes the task" means that for an ordinary asynchronous task
        /// it will either invoke the task's callback, or else queue that
        /// callback to be invoked in the proper #GMainContext, or in the next
        /// iteration of the current #GMainContext. For a task run via
        /// g_task_run_in_thread() or g_task_run_in_thread_sync(), calling this
        /// method will save @result to be returned to the caller later, but
        /// the task will not actually be completed until the #GTaskThreadFunc
        /// exits.
        /// 
        /// Note that since the task may be completed before returning from
        /// g_task_return_pointer(), you cannot assume that @result is still
        /// valid after calling this, unless you are still holding another
        /// reference on it.
        /// </remarks>
        /// <param name="task">
        /// a #GTask
        /// </param>
        /// <param name="result">
        /// the pointer result of a task
        ///     function
        /// </param>
        /// <param name="resultDestroy">
        /// a #GDestroyNotify function.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_return_pointer(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 allow-none:1 direction:in */
        System.IntPtr result,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GISharp.Lib.GLib.UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify resultDestroy);

        /// <summary>
        /// Sets or clears @task's check-cancellable flag. If this is %TRUE
        /// (the default), then g_task_propagate_pointer(), etc, and
        /// g_task_had_error() will check the task's #GCancellable first, and
        /// if it has been cancelled, then they will consider the task to have
        /// returned an "Operation was cancelled" error
        /// (%G_IO_ERROR_CANCELLED), regardless of any other error or return
        /// value the task may have had.
        /// </summary>
        /// <remarks>
        /// If @check_cancellable is %FALSE, then the #GTask will not check the
        /// cancellable itself, and it is up to @task's owner to do this (eg,
        /// via g_task_return_error_if_cancelled()).
        /// 
        /// If you are using g_task_set_return_on_cancel() as well, then
        /// you must leave check-cancellable set %TRUE.
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="checkCancellable">
        /// whether #GTask will check the state of
        ///   its #GCancellable for you.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_set_check_cancellable(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean checkCancellable);

        /// <summary>
        /// Sets or clears <paramref name="task"/>'s check-cancellable flag. If this is <c>true</c>
        /// (the default), then <see cref="PropagatePointer"/>, etc, and
        /// <see cref="HadError"/> will check the task's <see cref="Cancellable"/> first, and
        /// if it has been cancelled, then they will consider the task to have
        /// returned an "Operation was cancelled" error
        /// (<see cref="IOErrorEnum.Cancelled"/>), regardless of any other error or return
        /// value the task may have had.
        /// </summary>
        /// <remarks>
        /// If <paramref name="checkCancellable"/> is <c>false</c>, then the <see cref="Task"/> will not check the
        /// cancellable itself, and it is up to <paramref name="task"/>'s owner to do this (eg,
        /// via <see cref="ReturnErrorIfCancelled"/>).
        /// 
        /// If you are using <see cref="SetReturnOnCancel"/> as well, then
        /// you must leave check-cancellable set <c>true</c>.
        /// </remarks>
        /// <param name="checkCancellable">
        /// whether <see cref="Task"/> will check the state of
        ///   its <see cref="Cancellable"/> for you.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private void SetCheckCancellable(System.Boolean checkCancellable)
        {
            var task_ = Handle;
            var checkCancellable_ = (System.Boolean)checkCancellable;
            g_task_set_check_cancellable(task_, checkCancellable_);
        }

        /// <summary>
        /// Sets @task's priority. If you do not call this, it will default to
        /// %G_PRIORITY_DEFAULT.
        /// </summary>
        /// <remarks>
        /// This will affect the priority of #GSources created with
        /// g_task_attach_source() and the scheduling of tasks run in threads,
        /// and can also be explicitly retrieved later via
        /// g_task_get_priority().
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="priority">
        /// the [priority][io-priority] of the request
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_set_priority(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 priority);

        /// <summary>
        /// Sets <paramref name="task"/>'s priority. If you do not call this, it will default to
        /// %G_PRIORITY_DEFAULT.
        /// </summary>
        /// <remarks>
        /// This will affect the priority of #GSources created with
        /// g_task_attach_source() and the scheduling of tasks run in threads,
        /// and can also be explicitly retrieved later via
        /// <see cref="GetPriority"/>.
        /// </remarks>
        /// <param name="priority">
        /// the [priority][io-priority] of the request
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private void SetPriority(System.Int32 priority)
        {
            var task_ = Handle;
            var priority_ = (System.Int32)priority;
            g_task_set_priority(task_, priority_);
        }

        /// <summary>
        /// Sets or clears @task's return-on-cancel flag. This is only
        /// meaningful for tasks run via g_task_run_in_thread() or
        /// g_task_run_in_thread_sync().
        /// </summary>
        /// <remarks>
        /// If @return_on_cancel is %TRUE, then cancelling @task's
        /// #GCancellable will immediately cause it to return, as though the
        /// task's #GTaskThreadFunc had called
        /// g_task_return_error_if_cancelled() and then returned.
        /// 
        /// This allows you to create a cancellable wrapper around an
        /// uninterruptable function. The #GTaskThreadFunc just needs to be
        /// careful that it does not modify any externally-visible state after
        /// it has been cancelled. To do that, the thread should call
        /// g_task_set_return_on_cancel() again to (atomically) set
        /// return-on-cancel %FALSE before making externally-visible changes;
        /// if the task gets cancelled before the return-on-cancel flag could
        /// be changed, g_task_set_return_on_cancel() will indicate this by
        /// returning %FALSE.
        /// 
        /// You can disable and re-enable this flag multiple times if you wish.
        /// If the task's #GCancellable is cancelled while return-on-cancel is
        /// %FALSE, then calling g_task_set_return_on_cancel() to set it %TRUE
        /// again will cause the task to be cancelled at that point.
        /// 
        /// If the task's #GCancellable is already cancelled before you call
        /// g_task_run_in_thread()/g_task_run_in_thread_sync(), then the
        /// #GTaskThreadFunc will still be run (for consistency), but the task
        /// will also be completed right away.
        /// </remarks>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="returnOnCancel">
        /// whether the task returns automatically when
        ///   it is cancelled.
        /// </param>
        /// <returns>
        /// %TRUE if @task's return-on-cancel flag was changed to
        ///   match @return_on_cancel. %FALSE if @task has already been
        ///   cancelled.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_task_set_return_on_cancel(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean returnOnCancel);

        /// <summary>
        /// Sets or clears <paramref name="task"/>'s return-on-cancel flag. This is only
        /// meaningful for tasks run via g_task_run_in_thread() or
        /// g_task_run_in_thread_sync().
        /// </summary>
        /// <remarks>
        /// If <paramref name="returnOnCancel"/> is <c>true</c>, then cancelling <paramref name="task"/>'s
        /// <see cref="Cancellable"/> will immediately cause it to return, as though the
        /// task's <see cref="TaskThreadFunc"/> had called
        /// <see cref="ReturnErrorIfCancelled"/> and then returned.
        /// 
        /// This allows you to create a cancellable wrapper around an
        /// uninterruptable function. The <see cref="TaskThreadFunc"/> just needs to be
        /// careful that it does not modify any externally-visible state after
        /// it has been cancelled. To do that, the thread should call
        /// <see cref="SetReturnOnCancel"/> again to (atomically) set
        /// return-on-cancel <c>false</c> before making externally-visible changes;
        /// if the task gets cancelled before the return-on-cancel flag could
        /// be changed, <see cref="SetReturnOnCancel"/> will indicate this by
        /// returning <c>false</c>.
        /// 
        /// You can disable and re-enable this flag multiple times if you wish.
        /// If the task's <see cref="Cancellable"/> is cancelled while return-on-cancel is
        /// <c>false</c>, then calling <see cref="SetReturnOnCancel"/> to set it <c>true</c>
        /// again will cause the task to be cancelled at that point.
        /// 
        /// If the task's <see cref="Cancellable"/> is already cancelled before you call
        /// g_task_run_in_thread()/g_task_run_in_thread_sync(), then the
        /// <see cref="TaskThreadFunc"/> will still be run (for consistency), but the task
        /// will also be completed right away.
        /// </remarks>
        /// <param name="returnOnCancel">
        /// whether the task returns automatically when
        ///   it is cancelled.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="task"/>'s return-on-cancel flag was changed to
        ///   match <paramref name="returnOnCancel"/>. <c>false</c> if <paramref name="task"/> has already been
        ///   cancelled.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public System.Boolean SetReturnOnCancel(System.Boolean returnOnCancel)
        {
            var task_ = Handle;
            var returnOnCancel_ = (System.Boolean)returnOnCancel;
            var ret_ = g_task_set_return_on_cancel(task_,returnOnCancel_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @task's source tag. You can use this to tag a task return
        /// value with a particular pointer (usually a pointer to the function
        /// doing the tagging) and then later check it using
        /// g_task_get_source_tag() (or g_async_result_is_tagged()) in the
        /// task's "finish" function, to figure out if the response came from a
        /// particular place.
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_set_source_tag(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);

        /// <summary>
        /// Sets <paramref name="task"/>'s source tag. You can use this to tag a task return
        /// value with a particular pointer (usually a pointer to the function
        /// doing the tagging) and then later check it using
        /// <see cref="GetSourceTag"/> (or <see cref="IsTagged"/>) in the
        /// task's "finish" function, to figure out if the response came from a
        /// particular place.
        /// </summary>
        /// <param name="sourceTag">
        /// an opaque pointer indicating the source of this task
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private void SetSourceTag(System.IntPtr sourceTag)
        {
            var task_ = Handle;
            var sourceTag_ = (System.IntPtr)sourceTag;
            g_task_set_source_tag(task_, sourceTag_);
        }

        /// <summary>
        /// Sets @task's task data (freeing the existing task data, if any).
        /// </summary>
        /// <param name="task">
        /// the #GTask
        /// </param>
        /// <param name="taskData">
        /// task-specific data
        /// </param>
        /// <param name="taskDataDestroy">
        /// #GDestroyNotify for @task_data
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_task_set_task_data(
        /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr task,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr taskData,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GISharp.Lib.GLib.UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify taskDataDestroy);

        GISharp.Lib.GObject.Object GISharp.Lib.Gio.IAsyncResult.DoGetSourceObject()
        {
            throw new System.NotImplementedException();
        }

        System.IntPtr GISharp.Lib.Gio.IAsyncResult.DoGetUserData()
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.IAsyncResult.DoIsTagged(System.IntPtr sourceTag)
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed partial class TaskClass : GISharp.Lib.GObject.ObjectClass
    {
        public TaskClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    /// <summary>
    /// The prototype for a task function to be run in a thread via
    /// g_task_run_in_thread() or g_task_run_in_thread_sync().
    /// </summary>
    /// <remarks>
    /// If the return-on-cancel flag is set on @task, and @cancellable gets
    /// cancelled, then the #GTask will be completed immediately (as though
    /// g_task_return_error_if_cancelled() had been called), without
    /// waiting for the task function to complete. However, the task
    /// function will continue running in its thread in the background. The
    /// function therefore needs to be careful about how it uses
    /// externally-visible state in this case. See
    /// g_task_set_return_on_cancel() for more details.
    /// 
    /// Other than in that case, @task will be completed when the
    /// #GTaskThreadFunc returns, not when it calls a
    /// `g_task_return_` function.
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.36")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public delegate void UnmanagedTaskThreadFunc(
    /* <type name="Task" type="GTask*" managed-name="Task" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr task,
    /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr sourceObject,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr taskData,
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr cancellable);

    /// <summary>
    /// <see cref="ThemedIcon"/> is an implementation of <see cref="IIcon"/> that supports icon themes.
    /// <see cref="ThemedIcon"/> contains a list of all of the icons present in an icon
    /// theme, so that icons can be looked up quickly. <see cref="ThemedIcon"/> does
    /// not provide actual pixmaps for icons, just the icon names.
    /// Ideally something like gtk_icon_theme_choose_icon() should be used to
    /// resolve the list of names so that fallback icons work nicely with
    /// themes that inherit other themes.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GThemedIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ThemedIconClass))]
    public partial class ThemedIcon : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IIcon
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_themed_icon_get_type();

        /// <summary>
        /// The icon name.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8 Name { set => SetProperty("name", value); }

        /// <summary>
        /// A <c>null</c>-terminated array of icon names.
        /// </summary>
        [GISharp.Runtime.GPropertyAttribute("names", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Strv Names_ { get => (GISharp.Lib.GLib.Strv)GetProperty("names"); set => SetProperty("names", value); }

        /// <summary>
        /// Whether to use the default fallbacks found by shortening the icon name
        /// at '-' characters. If the "names" array has more than one element,
        /// ignores any past the first.
        /// </summary>
        /// <remarks>
        /// For example, if the icon name was "gnome-dev-cdrom-audio", the array
        /// would become
        /// |[&lt;!-- language="C" --&gt;
        /// {
        ///   "gnome-dev-cdrom-audio",
        ///   "gnome-dev-cdrom",
        ///   "gnome-dev",
        ///   "gnome",
        ///   NULL
        /// };
        /// ]|
        /// </remarks>
        [GISharp.Runtime.GPropertyAttribute("use-default-fallbacks", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public System.Boolean UseDefaultFallbacks { get => (System.Boolean)GetProperty("use-default-fallbacks"); set => SetProperty("use-default-fallbacks", value); }

        /// <summary>
        /// Gets the names of icons from within <paramref name="icon"/>.
        /// </summary>
        public GISharp.Lib.GLib.Strv Names { get => GetNames(); }

        public ThemedIcon(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new themed icon for @iconname.
        /// </summary>
        /// <param name="iconname">
        /// a string containing an icon name.
        /// </param>
        /// <returns>
        /// a new #GThemedIcon.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_themed_icon_new(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        static System.IntPtr New(GISharp.Lib.GLib.Utf8 iconname)
        {
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            var ret_ = g_themed_icon_new(iconname_);
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for @iconnames.
        /// </summary>
        /// <param name="iconnames">
        /// an array of strings containing icon names.
        /// </param>
        /// <param name="len">
        /// the length of the @iconnames array, or -1 if @iconnames is
        ///     %NULL-terminated
        /// </param>
        /// <returns>
        /// a new #GThemedIcon
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_themed_icon_new_from_names(
        /* <array length="1" zero-terminated="0" type="char**" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconnames,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 len);

        static System.IntPtr NewFromNames(GISharp.Runtime.IArray<GISharp.Lib.GLib.Utf8> iconnames)
        {
            var (iconnames_, len_) = ((System.IntPtr, System.Int32))((iconnames?.Data ?? throw new System.ArgumentNullException(nameof(iconnames)), iconnames?.Length ?? 0));
            var ret_ = g_themed_icon_new_from_names(iconnames_,len_);
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for <paramref name="iconnames"/>.
        /// </summary>
        /// <param name="iconnames">
        /// an array of strings containing icon names.
        /// </param>
        public ThemedIcon(GISharp.Runtime.IArray<GISharp.Lib.GLib.Utf8> iconnames) : this(NewFromNames(iconnames), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new themed icon for @iconname, and all the names
        /// that can be created by shortening @iconname at '-' characters.
        /// </summary>
        /// <remarks>
        /// In the following example, @icon1 and @icon2 are equivalent:
        /// |[&lt;!-- language="C" --&gt;
        /// const char *names[] = {
        ///   "gnome-dev-cdrom-audio",
        ///   "gnome-dev-cdrom",
        ///   "gnome-dev",
        ///   "gnome"
        /// };
        /// 
        /// icon1 = g_themed_icon_new_from_names (names, 4);
        /// icon2 = g_themed_icon_new_with_default_fallbacks ("gnome-dev-cdrom-audio");
        /// ]|
        /// </remarks>
        /// <param name="iconname">
        /// a string containing an icon name
        /// </param>
        /// <returns>
        /// a new #GThemedIcon.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_themed_icon_new_with_default_fallbacks(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        static System.IntPtr NewWithDefaultFallbacks(GISharp.Lib.GLib.Utf8 iconname)
        {
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            var ret_ = g_themed_icon_new_with_default_fallbacks(iconname_);
            return ret_;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_themed_icon_get_type();

        /// <summary>
        /// Append a name to the list of icons from within @icon.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to g_icon_hash().
        /// </remarks>
        /// <param name="icon">
        /// a #GThemedIcon
        /// </param>
        /// <param name="iconname">
        /// name of icon to append to list of icons from within @icon.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_themed_icon_append_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        /// <summary>
        /// Append a name to the list of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to <see cref="GetHashCode"/>.
        /// </remarks>
        /// <param name="iconname">
        /// name of icon to append to list of icons from within <paramref name="icon"/>.
        /// </param>
        public void AppendName(GISharp.Lib.GLib.Utf8 iconname)
        {
            var icon_ = Handle;
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            g_themed_icon_append_name(icon_, iconname_);
        }

        /// <summary>
        /// Gets the names of icons from within @icon.
        /// </summary>
        /// <param name="icon">
        /// a #GThemedIcon.
        /// </param>
        /// <returns>
        /// a list of icon names.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="const gchar* const*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_themed_icon_get_names(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Gets the names of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <returns>
        /// a list of icon names.
        /// </returns>
        private GISharp.Lib.GLib.Strv GetNames()
        {
            var icon_ = Handle;
            var ret_ = g_themed_icon_get_names(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Prepend a name to the list of icons from within @icon.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to g_icon_hash().
        /// </remarks>
        /// <param name="icon">
        /// a #GThemedIcon
        /// </param>
        /// <param name="iconname">
        /// name of icon to prepend to list of icons from within @icon.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.18")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_themed_icon_prepend_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        /// <summary>
        /// Prepend a name to the list of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to <see cref="GetHashCode"/>.
        /// </remarks>
        /// <param name="iconname">
        /// name of icon to prepend to list of icons from within <paramref name="icon"/>.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.18")]
        public void PrependName(GISharp.Lib.GLib.Utf8 iconname)
        {
            var icon_ = Handle;
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            g_themed_icon_prepend_name(icon_, iconname_);
        }

        System.Boolean GISharp.Lib.Gio.IIcon.DoEqual(GISharp.Lib.Gio.IIcon icon2)
        {
            throw new System.NotImplementedException();
        }

        System.UInt32 GISharp.Lib.Gio.IIcon.DoHash()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IIcon.DoSerialize()
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed partial class ThemedIconClass : GISharp.Lib.GObject.ObjectClass
    {
        public ThemedIconClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }

    public sealed partial class CancellableSource : GISharp.Lib.GLib.Source
    {
        public CancellableSource(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a source that triggers if @cancellable is cancelled and
        /// calls its callback of type #GCancellableSourceFunc. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a %NULL #GCancellable,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the #GCancellable.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable, or %NULL
        /// </param>
        /// <returns>
        /// the new #GSource.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Source" type="GSource*" managed-name="GISharp.Lib.GLib.Source" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_cancellable_source_new(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Creates a source that triggers if <paramref name="cancellable"/> is cancelled and
        /// calls its callback of type <see cref="CancellableSourceFunc"/>. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a <c>null</c> <see cref="Cancellable"/>,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the <see cref="Cancellable"/>.
        /// </remarks>
        /// <param name="cancellable">
        /// a <see cref="Cancellable"/>, or <c>null</c>
        /// </param>
        /// <returns>
        /// the new #GSource.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static System.IntPtr New(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_cancellable_source_new(cancellable_);
            return ret_;
        }

        /// <summary>
        /// Creates a source that triggers if <paramref name="cancellable"/> is cancelled and
        /// calls its callback of type <see cref="CancellableSourceFunc"/>. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a <c>null</c> <see cref="Cancellable"/>,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the <see cref="Cancellable"/>.
        /// </remarks>
        /// <param name="cancellable">
        /// a <see cref="Cancellable"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public CancellableSource(GISharp.Lib.Gio.Cancellable cancellable = null) : this(New(cancellable), GISharp.Runtime.Transfer.Full)
        {
        }
    }
}