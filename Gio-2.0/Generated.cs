namespace GISharp.Lib.Gio
{
    /// <summary>
    /// #GAction represents a single named action.
    /// </summary>
    /// <remarks>
    /// The main interface to an action is that it can be activated with
    /// g_action_activate().  This results in the 'activate' signal being
    /// emitted.  An activation has a #GVariant parameter (which may be
    /// %NULL).  The correct type for the parameter is determined by a static
    /// parameter type (which is given at construction time).
    /// 
    /// An action may optionally have a state, in which case the state may be
    /// set with g_action_change_state().  This call takes a #GVariant.  The
    /// correct type for the state is determined by a static state type
    /// (which is given at construction time).
    /// 
    /// The state may have a hint associated with it, specifying its valid
    /// range.
    /// 
    /// #GAction is merely the interface to the concept of an action, as
    /// described above.  Various implementations of actions exist, including
    /// #GSimpleAction.
    /// 
    /// In all cases, the implementing class is responsible for storing the
    /// name of the action, the parameter type, the enabled state, the
    /// optional state type and the state and emitting the appropriate
    /// signals when these change.  The implementor is responsible for filtering
    /// calls to g_action_activate() and g_action_change_state() for type
    /// safety and for the state being enabled.
    /// 
    /// Probably the only useful thing to do with a #GAction is to put it
    /// inside of a #GSimpleActionGroup.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GAction", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Lib.Gio.ActionInterface))]
    public interface IAction : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// If @action is currently enabled.
        /// </summary>
        /// <remarks>
        /// If the action is disabled then calls to g_action_activate() and
        /// g_action_change_state() have no effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        System.Boolean Enabled { get; }

        /// <summary>
        /// The name of the action.  This is mostly meaningful for identifying
        /// the action once it has been added to a #GActionGroup. It is immutable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name")]
        GISharp.Lib.GLib.Utf8 Name { get; }

        /// <summary>
        /// The type of the parameter that must be given when activating the
        /// action. This is immutable, and may be %NULL if no parameter is needed when
        /// activating the action.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type")]
        GISharp.Lib.GLib.VariantType ParameterType { get; }

        /// <summary>
        /// The state of the action, or %NULL if the action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state")]
        GISharp.Lib.GLib.Variant State { get; }

        /// <summary>
        /// The #GVariantType of the state that the action has, or %NULL if the
        /// action is stateless. This is immutable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        GISharp.Lib.GLib.VariantType StateType { get; }

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
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActivate(GISharp.Lib.GLib.Variant parameter);

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
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        void OnChangeState(GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Checks if @action is currently enabled.
        /// </summary>
        /// <remarks>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </remarks>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        System.Boolean OnGetEnabled();

        /// <summary>
        /// Queries the name of @action.
        /// </summary>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Utf8 OnGetName();

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
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.VariantType OnGetParameterType();

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
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Variant OnGetState();

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
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Variant OnGetStateHint();

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
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.VariantType OnGetStateType();
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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_name_is_valid(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        public static System.Boolean NameIsValid(GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_name_is_valid(actionName_);
            var ret = ret_;
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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_action_parse_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr detailedName,
        /* <type name="utf8" type="gchar**" managed-name="Utf8" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr targetValue,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
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
        /// the target value, or %NULL for no target
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
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
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_print_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr targetValue);

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
        public static GISharp.Lib.GLib.Utf8 PrintDetailedName(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant targetValue)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var targetValue_ = targetValue?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_action_print_detailed_name(actionName_,targetValue_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_activate(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameter);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_change_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_get_enabled(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        public static System.Boolean GetEnabled(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_enabled(action_);
            var ret = ret_;
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
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern System.IntPtr g_action_get_name(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_get_parameter_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_get_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_get_state_hint(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_get_state_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        public static GISharp.Lib.GLib.VariantType GetStateType(this GISharp.Lib.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state_type(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }

    /// <summary>
    /// #GActionGroup represents a group of actions. Actions can be used to
    /// expose functionality in a structured way, either from one part of a
    /// program to another, or to the outside world. Action groups are often
    /// used together with a #GMenuModel that provides additional
    /// representation data for displaying the actions to the user, e.g. in
    /// a menu.
    /// </summary>
    /// <remarks>
    /// The main way to interact with the actions in a GActionGroup is to
    /// activate them with g_action_group_activate_action(). Activating an
    /// action may require a #GVariant parameter. The required type of the
    /// parameter can be inquired with g_action_group_get_action_parameter_type().
    /// Actions may be disabled, see g_action_group_get_action_enabled().
    /// Activating a disabled action has no effect.
    /// 
    /// Actions may optionally have a state in the form of a #GVariant. The
    /// current state of an action can be inquired with
    /// g_action_group_get_action_state(). Activating a stateful action may
    /// change its state, but it is also possible to set the state by calling
    /// g_action_group_change_action_state().
    /// 
    /// As typical example, consider a text editing application which has an
    /// option to change the current font to 'bold'. A good way to represent
    /// this would be a stateful action, with a boolean state. Activating the
    /// action would toggle the state.
    /// 
    /// Each action in the group has a unique name (which is a string).  All
    /// method calls, except g_action_group_list_actions() take the name of
    /// an action as an argument.
    /// 
    /// The #GActionGroup API is meant to be the 'public' API to the action
    /// group.  The calls here are exactly the interaction that 'external
    /// forces' (eg: UI, incoming D-Bus messages, etc.) are supposed to have
    /// with actions.  'Internal' APIs (ie: ones meant only to be accessed by
    /// the action group implementation) are found on subclasses.  This is
    /// why you will find - for example - g_action_group_get_action_enabled()
    /// but not an equivalent set() call.
    /// 
    /// Signals are emitted on the action group in response to state changes
    /// on individual actions.
    /// 
    /// Implementations of #GActionGroup should provide implementations for
    /// the virtual functions g_action_group_list_actions() and
    /// g_action_group_query_action().  The other virtual functions should
    /// not be implemented - their "wrappers" are actually implemented with
    /// calls to g_action_group_query_action().
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GActionGroup", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Lib.Gio.ActionGroupInterface))]
    public interface IActionGroup : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Signals that a new action was just added to the group.
        /// This signal is emitted after the action has been added
        /// and is now visible.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-added", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<GISharp.Lib.Gio.ActionGroup.ActionAddedEventArgs> ActionAdded;

        /// <summary>
        /// Signals that the enabled status of the named action has changed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-enabled-changed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<GISharp.Lib.Gio.ActionGroup.ActionEnabledChangedEventArgs> ActionEnabledChanged;

        /// <summary>
        /// Signals that an action is just about to be removed from the group.
        /// This signal is emitted before the action is removed, so the action
        /// is still visible and can be queried from the signal handler.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-removed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<GISharp.Lib.Gio.ActionGroup.ActionRemovedEventArgs> ActionRemoved;

        /// <summary>
        /// Signals that the state of the named action has changed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("action-state-changed", When = GISharp.Runtime.EmissionStage.Last, IsDetailed = true)]
        event System.EventHandler<GISharp.Lib.Gio.ActionGroup.ActionStateChangedEventArgs> ActionStateChanged;

        /// <summary>
        /// Emits the #GActionGroup::action-added signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActionAdded(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Emits the #GActionGroup::action-enabled-changed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="enabled">
        /// whether or not the action is now enabled
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActionEnabledChanged(GISharp.Lib.GLib.Utf8 actionName, System.Boolean enabled);

        /// <summary>
        /// Emits the #GActionGroup::action-removed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActionRemoved(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Emits the #GActionGroup::action-state-changed signal on @action_group.
        /// </summary>
        /// <remarks>
        /// This function should only be called by #GActionGroup implementations.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action in the group
        /// </param>
        /// <param name="state">
        /// the new state of the named action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActionStateChanged(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant state);

        /// <summary>
        /// Activate the named action within @action_group.
        /// </summary>
        /// <remarks>
        /// If the action is expecting a parameter, then the correct type of
        /// parameter must be given as @parameter.  If the action is expecting no
        /// parameters then @parameter must be %NULL.  See
        /// g_action_group_get_action_parameter_type().
        /// </remarks>
        /// <param name="actionName">
        /// the name of the action to activate
        /// </param>
        /// <param name="parameter">
        /// parameters to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnActivateAction(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant parameter);

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
        /// <param name="actionName">
        /// the name of the action to request the change on
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        void OnChangeActionState(GISharp.Lib.GLib.Utf8 actionName, GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Checks if the named action within @action_group is currently enabled.
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
        System.Boolean OnGetActionEnabled(GISharp.Lib.GLib.Utf8 actionName);

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
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.VariantType OnGetActionParameterType(GISharp.Lib.GLib.Utf8 actionName);

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
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Variant OnGetActionState(GISharp.Lib.GLib.Utf8 actionName);

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
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Variant OnGetActionStateHint(GISharp.Lib.GLib.Utf8 actionName);

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
        /// <param name="actionName">
        /// the name of the action to query
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.VariantType OnGetActionStateType(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Checks if the named action exists within @action_group.
        /// </summary>
        /// <param name="actionName">
        /// the name of the action to check for
        /// </param>
        /// <returns>
        /// whether the named action exists
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        System.Boolean OnHasAction(GISharp.Lib.GLib.Utf8 actionName);

        /// <summary>
        /// Lists the actions contained within @action_group.
        /// </summary>
        /// <remarks>
        /// The caller is responsible for freeing the list with g_strfreev() when
        /// it is no longer required.
        /// </remarks>
        /// <returns>
        /// a %NULL-terminated array of the names of the
        /// actions in the group
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.Lib.GLib.Strv OnListActions();
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
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_added(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_enabled_changed(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean enabled);

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
        public static void ActionEnabledChanged(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, System.Boolean enabled)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var enabled_ = enabled;
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_removed(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_action_state_changed(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr state);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_activate_action(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameter);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_group_change_action_state(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_get_action_enabled(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        public static System.Boolean GetActionEnabled(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_get_action_enabled(actionGroup_,actionName_);
            var ret = ret_;
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
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_parameter_type(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state_hint(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern System.IntPtr g_action_group_get_action_state_type(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_has_action(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        public static System.Boolean HasAction(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_has_action(actionGroup_,actionName_);
            var ret = ret_;
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
        /* <array type="gchar**" zero-terminated="1" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_action_group_list_actions(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup);

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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_action_group_query_action(
        /* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionGroup,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName,
        /* <type name="gboolean" type="gboolean*" managed-name="Gboolean" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.Boolean enabled,
        /* <type name="GLib.VariantType" type="const GVariantType**" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr parameterType,
        /* <type name="GLib.VariantType" type="const GVariantType**" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr stateType,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr stateHint,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr state);

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
        public static System.Boolean TryQueryAction(this GISharp.Lib.Gio.IActionGroup actionGroup, GISharp.Lib.GLib.Utf8 actionName, out System.Boolean enabled, out GISharp.Lib.GLib.VariantType parameterType, out GISharp.Lib.GLib.VariantType stateType, out GISharp.Lib.GLib.Variant stateHint, out GISharp.Lib.GLib.Variant state)
        {
            var actionGroup_ = actionGroup?.Handle ?? throw new System.ArgumentNullException(nameof(actionGroup));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret_ = g_action_group_query_action(actionGroup_,actionName_,out var enabled_,out var parameterType_,out var stateType_,out var stateHint_,out var state_);
            enabled = enabled_;
            parameterType = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(parameterType_, GISharp.Runtime.Transfer.Full);
            stateType = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantType>(stateType_, GISharp.Runtime.Transfer.Full);
            stateHint = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(stateHint_, GISharp.Runtime.Transfer.Full);
            state = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(state_, GISharp.Runtime.Transfer.Full);
            var ret = ret_;
            return ret;
        }
    }

    /// <summary>
    /// The virtual function table for #GActionGroup.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionGroupInterface : GISharp.Lib.GObject.TypeInterface
    {
        static readonly System.Int32 gIfaceOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GIface));
        static readonly System.Int32 onHasActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnHasAction));
        static readonly UnmanagedHasAction onHasActionDelegate = OnHasAction;
        static readonly System.IntPtr onHasActionDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onHasActionDelegate);
        static readonly System.Int32 onListActionsOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnListActions));
        static readonly UnmanagedListActions onListActionsDelegate = OnListActions;
        static readonly System.IntPtr onListActionsDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onListActionsDelegate);
        static readonly System.Int32 onGetActionEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetActionEnabled));
        static readonly UnmanagedGetActionEnabled onGetActionEnabledDelegate = OnGetActionEnabled;
        static readonly System.IntPtr onGetActionEnabledDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetActionEnabledDelegate);
        static readonly System.Int32 onGetActionParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetActionParameterType));
        static readonly UnmanagedGetActionParameterType onGetActionParameterTypeDelegate = OnGetActionParameterType;
        static readonly System.IntPtr onGetActionParameterTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetActionParameterTypeDelegate);
        static readonly System.Int32 onGetActionStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetActionStateType));
        static readonly UnmanagedGetActionStateType onGetActionStateTypeDelegate = OnGetActionStateType;
        static readonly System.IntPtr onGetActionStateTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetActionStateTypeDelegate);
        static readonly System.Int32 onGetActionStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetActionStateHint));
        static readonly UnmanagedGetActionStateHint onGetActionStateHintDelegate = OnGetActionStateHint;
        static readonly System.IntPtr onGetActionStateHintDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetActionStateHintDelegate);
        static readonly System.Int32 onGetActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetActionState));
        static readonly UnmanagedGetActionState onGetActionStateDelegate = OnGetActionState;
        static readonly System.IntPtr onGetActionStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetActionStateDelegate);
        static readonly System.Int32 onChangeActionStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnChangeActionState));
        static readonly UnmanagedChangeActionState onChangeActionStateDelegate = OnChangeActionState;
        static readonly System.IntPtr onChangeActionStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onChangeActionStateDelegate);
        static readonly System.Int32 onActivateActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActivateAction));
        static readonly UnmanagedActivateAction onActivateActionDelegate = OnActivateAction;
        static readonly System.IntPtr onActivateActionDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActivateActionDelegate);
        static readonly System.Int32 onActionAddedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActionAdded));
        static readonly UnmanagedActionAdded onActionAddedDelegate = OnActionAdded;
        static readonly System.IntPtr onActionAddedDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActionAddedDelegate);
        static readonly System.Int32 onActionRemovedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActionRemoved));
        static readonly UnmanagedActionRemoved onActionRemovedDelegate = OnActionRemoved;
        static readonly System.IntPtr onActionRemovedDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActionRemovedDelegate);
        static readonly System.Int32 onActionEnabledChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActionEnabledChanged));
        static readonly UnmanagedActionEnabledChanged onActionEnabledChangedDelegate = OnActionEnabledChanged;
        static readonly System.IntPtr onActionEnabledChangedDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActionEnabledChangedDelegate);
        static readonly System.Int32 onActionStateChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActionStateChanged));
        static readonly UnmanagedActionStateChanged onActionStateChangedDelegate = OnActionStateChanged;
        static readonly System.IntPtr onActionStateChangedDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActionStateChangedDelegate);
        static readonly System.Int32 queryActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryAction));

        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public System.IntPtr OnHasAction;
            public System.IntPtr OnListActions;
            public System.IntPtr OnGetActionEnabled;
            public System.IntPtr OnGetActionParameterType;
            public System.IntPtr OnGetActionStateType;
            public System.IntPtr OnGetActionStateHint;
            public System.IntPtr OnGetActionState;
            public System.IntPtr OnChangeActionState;
            public System.IntPtr OnActivateAction;
            public System.IntPtr OnActionAdded;
            public System.IntPtr OnActionRemoved;
            public System.IntPtr OnActionEnabledChanged;
            public System.IntPtr OnActionStateChanged;
            public System.IntPtr QueryAction;
#pragma warning restore CS0649
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedHasAction(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedHasAction OnHasActionDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedHasAction>(Handle, onHasActionOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        public delegate System.IntPtr UnmanagedListActions(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup);

        public UnmanagedListActions OnListActionsDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedListActions>(Handle, onListActionsOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedGetActionEnabled(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedGetActionEnabled OnGetActionEnabledDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetActionEnabled>(Handle, onGetActionEnabledOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetActionParameterType(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedGetActionParameterType OnGetActionParameterTypeDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetActionParameterType>(Handle, onGetActionParameterTypeOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetActionStateType(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedGetActionStateType OnGetActionStateTypeDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetActionStateType>(Handle, onGetActionStateTypeOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetActionStateHint(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedGetActionStateHint OnGetActionStateHintDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetActionStateHint>(Handle, onGetActionStateHintOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetActionState(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedGetActionState OnGetActionStateDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetActionState>(Handle, onGetActionStateOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedChangeActionState(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr value);

        public UnmanagedChangeActionState OnChangeActionStateDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedChangeActionState>(Handle, onChangeActionStateOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActivateAction(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr parameter);

        public UnmanagedActivateAction OnActivateActionDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActivateAction>(Handle, onActivateActionOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActionAdded(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedActionAdded OnActionAddedDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActionAdded>(Handle, onActionAddedOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActionRemoved(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedActionRemoved OnActionRemovedDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActionRemoved>(Handle, onActionRemovedOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActionEnabledChanged(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
/* transfer-ownership:none direction:in */
System.Boolean enabled);

        public UnmanagedActionEnabledChanged OnActionEnabledChangedDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActionEnabledChanged>(Handle, onActionEnabledChangedOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActionStateChanged(
/* <type name="ActionGroup" type="GActionGroup*" managed-name="ActionGroup" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionGroup,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr state);

        public UnmanagedActionStateChanged OnActionStateChangedDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActionStateChanged>(Handle, onActionStateChangedOffset);

        public ActionGroupInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.Lib.GObject.InterfaceInfo CreateInterfaceInfo(System.Type type)
        {
            var ret = new GISharp.Lib.GObject.InterfaceInfo
            {
                InterfaceInit = InterfaceInit,
            };
            return ret;
        }

        static void InterfaceInit(System.IntPtr gIface, System.IntPtr userData)
        {
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onHasActionOffset, onHasActionDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onListActionsOffset, onListActionsDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetActionEnabledOffset, onGetActionEnabledDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetActionParameterTypeOffset, onGetActionParameterTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetActionStateTypeOffset, onGetActionStateTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetActionStateHintOffset, onGetActionStateHintDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetActionStateOffset, onGetActionStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onChangeActionStateOffset, onChangeActionStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActivateActionOffset, onActivateActionDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActionAddedOffset, onActionAddedDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActionRemovedOffset, onActionRemovedDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActionEnabledChangedOffset, onActionEnabledChangedDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActionStateChangedOffset, onActionStateChangedDelegate_);
        }

        static System.Boolean OnHasAction(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnHasAction(actionName);
                var ret_ = ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.Boolean);
            }
        }

        static System.IntPtr OnListActions(System.IntPtr actionGroup_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnListActions();
                var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.Boolean OnGetActionEnabled(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnGetActionEnabled(actionName);
                var ret_ = ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.Boolean);
            }
        }

        static System.IntPtr OnGetActionParameterType(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnGetActionParameterType(actionName);
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetActionStateType(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnGetActionStateType(actionName);
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetActionStateHint(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnGetActionStateHint(actionName);
                var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetActionState(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionGroup.OnGetActionState(actionName);
                var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static void OnChangeActionState(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr value_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(value_, GISharp.Runtime.Transfer.None);
                actionGroup.OnChangeActionState(actionName, value);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActivateAction(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr parameter_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                actionGroup.OnActivateAction(actionName, parameter);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActionAdded(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                actionGroup.OnActionAdded(actionName);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActionRemoved(System.IntPtr actionGroup_, System.IntPtr actionName_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                actionGroup.OnActionRemoved(actionName);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActionEnabledChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, System.Boolean enabled_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var enabled = enabled_;
                actionGroup.OnActionEnabledChanged(actionName, enabled);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActionStateChanged(System.IntPtr actionGroup_, System.IntPtr actionName_, System.IntPtr state_)
        {
            try
            {
                var actionGroup = (GISharp.Lib.Gio.IActionGroup)GISharp.Lib.GObject.Object.GetInstance(actionGroup_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var state = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(state_, GISharp.Runtime.Transfer.None);
                actionGroup.OnActionStateChanged(actionName, state);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// The virtual function table for #GAction.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed class ActionInterface : GISharp.Lib.GObject.TypeInterface
    {
        static readonly System.Int32 gIfaceOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GIface));
        static readonly System.Int32 onGetNameOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetName));
        static readonly UnmanagedGetName onGetNameDelegate = OnGetName;
        static readonly System.IntPtr onGetNameDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetNameDelegate);
        static readonly System.Int32 onGetParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetParameterType));
        static readonly UnmanagedGetParameterType onGetParameterTypeDelegate = OnGetParameterType;
        static readonly System.IntPtr onGetParameterTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetParameterTypeDelegate);
        static readonly System.Int32 onGetStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetStateType));
        static readonly UnmanagedGetStateType onGetStateTypeDelegate = OnGetStateType;
        static readonly System.IntPtr onGetStateTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetStateTypeDelegate);
        static readonly System.Int32 onGetStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetStateHint));
        static readonly UnmanagedGetStateHint onGetStateHintDelegate = OnGetStateHint;
        static readonly System.IntPtr onGetStateHintDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetStateHintDelegate);
        static readonly System.Int32 onGetEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetEnabled));
        static readonly UnmanagedGetEnabled onGetEnabledDelegate = OnGetEnabled;
        static readonly System.IntPtr onGetEnabledDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetEnabledDelegate);
        static readonly System.Int32 onGetStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetState));
        static readonly UnmanagedGetState onGetStateDelegate = OnGetState;
        static readonly System.IntPtr onGetStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetStateDelegate);
        static readonly System.Int32 onChangeStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnChangeState));
        static readonly UnmanagedChangeState onChangeStateDelegate = OnChangeState;
        static readonly System.IntPtr onChangeStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onChangeStateDelegate);
        static readonly System.Int32 onActivateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnActivate));
        static readonly UnmanagedActivate onActivateDelegate = OnActivate;
        static readonly System.IntPtr onActivateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onActivateDelegate);

        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public System.IntPtr OnGetName;
            public System.IntPtr OnGetParameterType;
            public System.IntPtr OnGetStateType;
            public System.IntPtr OnGetStateHint;
            public System.IntPtr OnGetEnabled;
            public System.IntPtr OnGetState;
            public System.IntPtr OnChangeState;
            public System.IntPtr OnActivate;
#pragma warning restore CS0649
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedGetName(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetName OnGetNameDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetName>(Handle, onGetNameOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetParameterType OnGetParameterTypeDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetParameterType>(Handle, onGetParameterTypeOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetStateType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetStateType OnGetStateTypeDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetStateType>(Handle, onGetStateTypeOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetStateHint OnGetStateHintDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetStateHint>(Handle, onGetStateHintOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetEnabled OnGetEnabledDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetEnabled>(Handle, onGetEnabledOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public delegate System.IntPtr UnmanagedGetState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedGetState OnGetStateDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetState>(Handle, onGetStateOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedChangeState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr value);

        public UnmanagedChangeState OnChangeStateDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedChangeState>(Handle, onChangeStateOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedActivate(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr parameter);

        public UnmanagedActivate OnActivateDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedActivate>(Handle, onActivateOffset);

        public ActionInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.Lib.GObject.InterfaceInfo CreateInterfaceInfo(System.Type type)
        {
            var ret = new GISharp.Lib.GObject.InterfaceInfo
            {
                InterfaceInit = InterfaceInit,
            };
            return ret;
        }

        static void InterfaceInit(System.IntPtr gIface, System.IntPtr userData)
        {
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetNameOffset, onGetNameDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetParameterTypeOffset, onGetParameterTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetStateTypeOffset, onGetStateTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetStateHintOffset, onGetStateHintDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetEnabledOffset, onGetEnabledDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetStateOffset, onGetStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onChangeStateOffset, onChangeStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onActivateOffset, onActivateDelegate_);
        }

        static System.IntPtr OnGetName(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetName();
                var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetParameterType(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetParameterType();
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetStateType(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetStateType();
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetStateHint(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetStateHint();
                var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.Boolean OnGetEnabled(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetEnabled();
                var ret_ = ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.Boolean);
            }
        }

        static System.IntPtr OnGetState(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var ret = action.OnGetState();
                var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static void OnChangeState(System.IntPtr action_, System.IntPtr value_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(value_, GISharp.Runtime.Transfer.None);
                action.OnChangeState(value);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActivate(System.IntPtr action_, System.IntPtr parameter_)
        {
            try
            {
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                action.OnActivate(parameter);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// The GActionMap interface is implemented by #GActionGroup
    /// implementations that operate by containing a number of
    /// named #GAction instances, such as #GSimpleActionGroup.
    /// </summary>
    /// <remarks>
    /// One useful application of this interface is to map the
    /// names of actions from various action groups to unique,
    /// prefixed names (e.g. by prepending "app." or "win.").
    /// This is the motivation for the 'Map' part of the interface
    /// name.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GActionMap", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Lib.Gio.ActionMapInterface))]
    public interface IActionMap : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Adds an action to the @action_map.
        /// </summary>
        /// <remarks>
        /// If the action map already contains an action with the same name
        /// as @action then the old action is dropped from the action map.
        /// 
        /// The action map takes its own reference on @action.
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        void OnAddAction(GISharp.Lib.Gio.IAction action);

        /// <summary>
        /// Looks up the action with the name @action_name in @action_map.
        /// </summary>
        /// <remarks>
        /// If no such action exists, returns %NULL.
        /// </remarks>
        /// <param name="actionName">
        /// the name of an action
        /// </param>
        /// <returns>
        /// a #GAction, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        GISharp.Lib.Gio.IAction OnLookupAction(GISharp.Lib.GLib.Utf8 actionName);

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
        void OnRemoveAction(GISharp.Lib.GLib.Utf8 actionName);
    }

    public static class ActionMap
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_action_map_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_map_add_action(
        /* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionMap,
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr action);

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
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_action_map_remove_action(
        /* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionMap,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr actionName);

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
        public static void RemoveAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionMap_ = actionMap?.Handle ?? throw new System.ArgumentNullException(nameof(actionMap));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            g_action_map_remove_action(actionMap_, actionName_);
        }
    }

    /// <summary>
    /// The virtual function table for #GActionMap.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.32")]
    public sealed class ActionMapInterface : GISharp.Lib.GObject.TypeInterface
    {
        static readonly System.Int32 gIfaceOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GIface));
        static readonly System.Int32 onLookupActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnLookupAction));
        static readonly UnmanagedLookupAction onLookupActionDelegate = OnLookupAction;
        static readonly System.IntPtr onLookupActionDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onLookupActionDelegate);
        static readonly System.Int32 onAddActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnAddAction));
        static readonly UnmanagedAddAction onAddActionDelegate = OnAddAction;
        static readonly System.IntPtr onAddActionDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onAddActionDelegate);
        static readonly System.Int32 onRemoveActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnRemoveAction));
        static readonly UnmanagedRemoveAction onRemoveActionDelegate = OnRemoveAction;
        static readonly System.IntPtr onRemoveActionDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onRemoveActionDelegate);

        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public System.IntPtr OnLookupAction;
            public System.IntPtr OnAddAction;
            public System.IntPtr OnRemoveAction;
#pragma warning restore CS0649
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.IntPtr UnmanagedLookupAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedLookupAction OnLookupActionDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedLookupAction>(Handle, onLookupActionOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedAddAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr action);

        public UnmanagedAddAction OnAddActionDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedAddAction>(Handle, onAddActionOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedRemoveAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionMap,
/* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr actionName);

        public UnmanagedRemoveAction OnRemoveActionDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedRemoveAction>(Handle, onRemoveActionOffset);

        public ActionMapInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.Lib.GObject.InterfaceInfo CreateInterfaceInfo(System.Type type)
        {
            var ret = new GISharp.Lib.GObject.InterfaceInfo
            {
                InterfaceInit = InterfaceInit,
            };
            return ret;
        }

        static void InterfaceInit(System.IntPtr gIface, System.IntPtr userData)
        {
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onLookupActionOffset, onLookupActionDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onAddActionOffset, onAddActionDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onRemoveActionOffset, onRemoveActionDelegate_);
        }

        static System.IntPtr OnLookupAction(System.IntPtr actionMap_, System.IntPtr actionName_)
        {
            try
            {
                var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                var ret = actionMap.OnLookupAction(actionName);
                var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static void OnAddAction(System.IntPtr actionMap_, System.IntPtr action_)
        {
            try
            {
                var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None);
                actionMap.OnAddAction(action);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnRemoveAction(System.IntPtr actionMap_, System.IntPtr actionName_)
        {
            try
            {
                var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None);
                var actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.None);
                actionMap.OnRemoveAction(actionName);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="None" /> */
    /* transfer-ownership:none direction:out */
    public delegate void UnmanagedAsyncReadyCallback(
    /* <type name="GObject.Object" type="GObject*" managed-name="GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr sourceObject,
    /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr res,
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
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
    /// which are chained together by a #GAsyncReadyCallback. To begin
    /// an asynchronous operation, provide a #GAsyncReadyCallback to the
    /// asynchronous function. This callback will be triggered when the
    /// operation has completed, and will be passed a #GAsyncResult instance
    /// filled with the details of the operation's success or failure, the
    /// object the asynchronous function was started for and any error codes
    /// returned. The asynchronous callback function is then expected to call
    /// the corresponding "_finish()" function, passing the object the
    /// function was called for, the #GAsyncResult instance, and (optionally)
    /// an @error to grab any error conditions that may have occurred.
    /// 
    /// The "_finish()" function for an operation takes the generic result
    /// (of type #GAsyncResult) and returns the specific result that the
    /// operation in question yields (e.g. a #GFileEnumerator for a
    /// "enumerate children" operation). If the result or error status of the
    /// operation is not needed, there is no need to call the "_finish()"
    /// function; GIO will take care of cleaning up the result and error
    /// information after the #GAsyncReadyCallback returns. You can pass
    /// %NULL for the #GAsyncReadyCallback if you don't need to take any
    /// action at all after the operation completes. Applications may also
    /// take a reference to the #GAsyncResult and call "_finish()" later;
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
    /// the result is a %G_IO_ERROR_CANCELLED error.
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
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Lib.Gio.AsyncResultIface))]
    public interface IAsyncResult : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Gets the source object from a #GAsyncResult.
        /// </summary>
        /// <returns>
        /// a new reference to the source object for the @res,
        ///    or %NULL if there is none.
        /// </returns>
        GISharp.Lib.GObject.Object OnGetSourceObject();

        /// <summary>
        /// Gets the user data from a #GAsyncResult.
        /// </summary>
        /// <returns>
        /// the user data for @res.
        /// </returns>
        System.IntPtr OnGetUserData();

        /// <summary>
        /// Checks if @res has the given @source_tag (generally a function
        /// pointer indicating the function @res was created by).
        /// </summary>
        /// <param name="sourceTag">
        /// an application-defined tag
        /// </param>
        /// <returns>
        /// %TRUE if @res has the indicated @source_tag, %FALSE if
        ///   not.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        System.Boolean OnIsTagged(System.IntPtr sourceTag);
    }

    public static class AsyncResult
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_async_result_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="GObject.Object" type="GObject*" managed-name="GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_async_result_get_source_object(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

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
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern System.IntPtr g_async_result_get_user_data(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res);

        /// <summary>
        /// Gets the user data from a #GAsyncResult.
        /// </summary>
        /// <param name="res">
        /// a #GAsyncResult.
        /// </param>
        /// <returns>
        /// the user data for @res.
        /// </returns>
        public static System.IntPtr GetUserData(this GISharp.Lib.Gio.IAsyncResult res)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var ret_ = g_async_result_get_user_data(res_);
            var ret = ret_;
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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_async_result_is_tagged(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr sourceTag);

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
        public static System.Boolean IsTagged(this GISharp.Lib.Gio.IAsyncResult res, System.IntPtr sourceTag)
        {
            var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
            var sourceTag_ = sourceTag;
            var ret_ = g_async_result_is_tagged(res_,sourceTag_);
            var ret = ret_;
            return ret;
        }
    }

    /// <summary>
    /// Interface definition for #GAsyncResult.
    /// </summary>
    public sealed class AsyncResultIface : GISharp.Lib.GObject.TypeInterface
    {
        static readonly System.Int32 gIfaceOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GIface));
        static readonly System.Int32 onGetUserDataOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetUserData));
        static readonly UnmanagedGetUserData onGetUserDataDelegate = OnGetUserData;
        static readonly System.IntPtr onGetUserDataDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetUserDataDelegate);
        static readonly System.Int32 onGetSourceObjectOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnGetSourceObject));
        static readonly UnmanagedGetSourceObject onGetSourceObjectDelegate = OnGetSourceObject;
        static readonly System.IntPtr onGetSourceObjectDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onGetSourceObjectDelegate);
        static readonly System.Int32 onIsTaggedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnIsTagged));
        static readonly UnmanagedIsTagged onIsTaggedDelegate = OnIsTagged;
        static readonly System.IntPtr onIsTaggedDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onIsTaggedDelegate);

        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public System.IntPtr OnGetUserData;
            public System.IntPtr OnGetSourceObject;
            public System.IntPtr OnIsTagged;
#pragma warning restore CS0649
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        public delegate System.IntPtr UnmanagedGetUserData(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        public UnmanagedGetUserData OnGetUserDataDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetUserData>(Handle, onGetUserDataOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public delegate System.IntPtr UnmanagedGetSourceObject(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res);

        public UnmanagedGetSourceObject OnGetSourceObjectDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedGetSourceObject>(Handle, onGetSourceObjectOffset);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        public delegate System.Boolean UnmanagedIsTagged(
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res,
/* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr sourceTag);

        public UnmanagedIsTagged OnIsTaggedDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedIsTagged>(Handle, onIsTaggedOffset);

        public AsyncResultIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.Lib.GObject.InterfaceInfo CreateInterfaceInfo(System.Type type)
        {
            var ret = new GISharp.Lib.GObject.InterfaceInfo
            {
                InterfaceInit = InterfaceInit,
            };
            return ret;
        }

        static void InterfaceInit(System.IntPtr gIface, System.IntPtr userData)
        {
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetUserDataOffset, onGetUserDataDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onGetSourceObjectOffset, onGetSourceObjectDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)onIsTaggedOffset, onIsTaggedDelegate_);
        }

        static System.IntPtr OnGetUserData(System.IntPtr res_)
        {
            try
            {
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                var ret = res.OnGetUserData();
                var ret_ = ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetSourceObject(System.IntPtr res_)
        {
            try
            {
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                var ret = res.OnGetSourceObject();
                var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.Boolean OnIsTagged(System.IntPtr res_, System.IntPtr sourceTag_)
        {
            try
            {
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
                var sourceTag = sourceTag_;
                var ret = res.OnIsTagged(sourceTag);
                var ret_ = ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                return default(System.Boolean);
            }
        }
    }

    /// <summary>
    /// GCancellable is a thread-safe operation cancellation stack used
    /// throughout GIO to allow for cancellation of synchronous and
    /// asynchronous operations.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GCancellable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Lib.Gio.CancellableClass))]
    public partial class Cancellable : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_cancellable_get_type();

        /// <summary>
        /// Gets the top cancellable from the stack.
        /// </summary>
        public static GISharp.Lib.Gio.Cancellable Current { get => GetCurrent(); }

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
        /// are two helper functions: g_cancellable_connect() and
        /// g_cancellable_disconnect() which protect against problems
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
        /// a #GCancellable from the top
        /// of the stack, or %NULL if the stack is empty.
        /// </returns>
        private static GISharp.Lib.Gio.Cancellable GetCurrent()
        {
            var ret_ = g_cancellable_get_current();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_cancel(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none direction:out */
        static extern GISharp.Runtime.NativeULong g_cancellable_connect(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="gpointer" type="GCallback" managed-name="UnmanagedGpointer" /> */
        /* transfer-ownership:none scope:notified closure:1 destroy:2 direction:in */
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedGLib.DestroyNotify" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_disconnect(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="gulong" type="gulong" managed-name="Gulong" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.NativeULong handlerId);

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
        /// <param name="handlerId">
        /// Handler id of the handler to be disconnected, or %0.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void Disconnect(GISharp.Runtime.NativeULong handlerId)
        {
            var cancellable_ = Handle;
            var handlerId_ = handlerId;
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
        /* <type name="gint" type="int" managed-name="Gint" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Int32 g_cancellable_get_fd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        /// <returns>
        /// A valid file descriptor. %-1 if the file descriptor
        /// is not supported, or on errors.
        /// </returns>
        private System.Int32 GetFd()
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_get_fd(cancellable_);
            var ret = ret_;
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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_cancellable_is_cancelled(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Checks if a cancellable job has been cancelled.
        /// </summary>
        /// <returns>
        /// %TRUE if @cancellable is cancelled,
        /// FALSE if called with %NULL or if item is not cancelled.
        /// </returns>
        private System.Boolean GetIsCancelled()
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_is_cancelled(cancellable_);
            var ret = ret_;
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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none direction:out */
        static extern System.Boolean g_cancellable_make_pollfd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.PollFD" type="GPollFD*" managed-name="GLib.PollFD" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        out GISharp.Lib.GLib.PollFD pollfd);

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
        /// <param name="pollfd">
        /// a pointer to a #GPollFD
        /// </param>
        /// <returns>
        /// %TRUE if @pollfd was successfully initialized, %FALSE on
        ///          failure to prepare the cancellable.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Boolean TryMakePollfd(out GISharp.Lib.GLib.PollFD pollfd)
        {
            var cancellable_ = Handle;
            var ret_ = g_cancellable_make_pollfd(cancellable_,out var pollfd_);
            pollfd = pollfd_;
            var ret = ret_;
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_pop_current(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Pops @cancellable off the cancellable stack (verifying that @cancellable
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_push_current(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_release_fd(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_cancellable_reset(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern System.Boolean g_cancellable_set_error_if_cancelled(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <summary>
        /// If the @cancellable is cancelled, sets the error to notify
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

        internal protected virtual void OnCancelled()
        {
            var cancellable_ = Handle;
            GISharp.Lib.GObject.TypeClass.GetInstance<CancellableClass>(_GType).OnCancelledDelegate(cancellable_);
        }
    }

    public class CancellableClass : GISharp.Lib.GObject.ObjectClass
    {
        static readonly System.Int32 parentClassOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ParentClass));
        static readonly System.Int32 onCancelledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.OnCancelled));
        static readonly UnmanagedCancelled onCancelledDelegate = OnCancelled;
        static readonly System.IntPtr onCancelledDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(onCancelledDelegate);
        static readonly System.Int32 gReserved1Offset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GReserved1));
        static readonly System.Int32 gReserved2Offset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GReserved2));
        static readonly System.Int32 gReserved3Offset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GReserved3));
        static readonly System.Int32 gReserved4Offset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GReserved4));
        static readonly System.Int32 gReserved5Offset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GReserved5));

        new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public System.IntPtr OnCancelled;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        public delegate void UnmanagedCancelled(
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable);

        public UnmanagedCancelled OnCancelledDelegate => GISharp.Runtime.GMarshal.GetVirtualMethodDelegate<UnmanagedCancelled>(Handle, onCancelledOffset);

        public CancellableClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.Lib.GObject.TypeInfo GetTypeInfo(System.Type type)
        {
            throw new System.NotImplementedException();
        }

        static void OnCancelled(System.IntPtr cancellable_)
        {
            try
            {
                var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                cancellable.OnCancelled();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by g_cancellable_source_new().
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
    /* transfer-ownership:none direction:out */
    public delegate System.Boolean UnmanagedCancellableSourceFunc(
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr cancellable,
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by g_cancellable_source_new().
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public delegate System.Boolean CancellableSourceFunc(GISharp.Lib.Gio.Cancellable cancellable);

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
                var ret = ret_;
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
                var ret_ = ret;
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
    /// replace %G_IO_ERROR_FAILED in cases that were not explicitly
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
        ///     and no more specific #GIOErrorEnum value is defined.
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
        /// Operation was cancelled. See #GCancellable.
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
        ///     this limit. Since 2.20
        /// </summary>
        TooManyOpenFiles = 31,
        /// <summary>
        /// The object has not been initialized. Since 2.22
        /// </summary>
        NotInitialized = 32,
        /// <summary>
        /// The requested address is already in use. Since 2.22
        /// </summary>
        AddressInUse = 33,
        /// <summary>
        /// Need more input to finish operation. Since 2.24
        /// </summary>
        PartialInput = 34,
        /// <summary>
        /// The input data was invalid. Since 2.24
        /// </summary>
        InvalidData = 35,
        /// <summary>
        /// A remote object generated an error that
        ///     doesn't correspond to a locally registered #GError error
        ///     domain. Use g_dbus_error_get_remote_error() to extract the D-Bus
        ///     error name and g_dbus_error_strip_remote_error() to fix up the
        ///     message so it matches what was received on the wire. Since 2.26.
        /// </summary>
        DbusError = 36,
        /// <summary>
        /// Host unreachable. Since 2.26
        /// </summary>
        HostUnreachable = 37,
        /// <summary>
        /// Network unreachable. Since 2.26
        /// </summary>
        NetworkUnreachable = 38,
        /// <summary>
        /// Connection refused. Since 2.26
        /// </summary>
        ConnectionRefused = 39,
        /// <summary>
        /// Connection to proxy server failed. Since 2.26
        /// </summary>
        ProxyFailed = 40,
        /// <summary>
        /// Proxy authentication failed. Since 2.26
        /// </summary>
        ProxyAuthFailed = 41,
        /// <summary>
        /// Proxy server needs authentication. Since 2.26
        /// </summary>
        ProxyNeedAuth = 42,
        /// <summary>
        /// Proxy connection is not allowed by ruleset.
        ///     Since 2.26
        /// </summary>
        ProxyNotAllowed = 43,
        /// <summary>
        /// Broken pipe. Since 2.36
        /// </summary>
        BrokenPipe = 44,
        /// <summary>
        /// Connection closed by peer. Note that this
        ///     is the same code as %G_IO_ERROR_BROKEN_PIPE; before 2.44 some
        ///     "connection closed" errors returned %G_IO_ERROR_BROKEN_PIPE, but others
        ///     returned %G_IO_ERROR_FAILED. Now they should all return the same
        ///     value, which has this more logical name. Since 2.44.
        /// </summary>
        ConnectionClosed = 44,
        /// <summary>
        /// Transport endpoint is not connected. Since 2.44
        /// </summary>
        NotConnected = 45,
        /// <summary>
        /// Message too large. Since 2.48.
        /// </summary>
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
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 errno);

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
        public static GISharp.Lib.Gio.IOErrorEnum FromErrno(System.Int32 errno)
        {
            var errno_ = errno;
            var ret_ = g_io_error_from_errno(errno_);
            var ret = ret_;
            return ret;
        }

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        /// <returns>
        /// a #GQuark.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
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
            var ret = ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* transfer-ownership:full direction:out */
        static extern GISharp.Lib.GObject.GType g_io_error_enum_get_type();
    }

    /// <summary>
    /// A #GSimpleAction is the obvious simple implementation of the #GAction
    /// interface. This is the easiest way to create an action for purposes of
    /// adding it to a #GSimpleActionGroup.
    /// </summary>
    /// <remarks>
    /// See also #GtkAction.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GSimpleAction", IsProxyForUnmanagedType = true)]
    public sealed partial class SimpleAction : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IAction
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_simple_action_get_type();

        /// <summary>
        /// If @action is currently enabled.
        /// </summary>
        /// <remarks>
        /// If the action is disabled then calls to g_action_activate() and
        /// g_action_change_state() have no effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        public System.Boolean Enabled { get => (System.Boolean)GetProperty("enabled"); }

        /// <summary>
        /// The name of the action. This is mostly meaningful for identifying
        /// the action once it has been added to a #GSimpleActionGroup.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name")]
        public GISharp.Lib.GLib.Utf8 Name { get => (GISharp.Lib.GLib.Utf8)GetProperty("name"); set => SetProperty("name", value); }

        /// <summary>
        /// The type of the parameter that must be given when activating the
        /// action.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type")]
        public GISharp.Lib.GLib.VariantType ParameterType { get => (GISharp.Lib.GLib.VariantType)GetProperty("parameter-type"); set => SetProperty("parameter-type", value); }

        /// <summary>
        /// The state of the action, or %NULL if the action is stateless.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state")]
        public GISharp.Lib.GLib.Variant State { get => (GISharp.Lib.GLib.Variant)GetProperty("state"); }

        /// <summary>
        /// The #GVariantType of the state that the action has, or %NULL if the
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
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterType);

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
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterType,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr state);

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
        /// @parameter will always be of the expected type.  In the event that
        /// an incorrect type was given, no signal will be emitted.
        /// 
        /// Since GLib 2.40, if no handler is connected to this signal then the
        /// default behaviour for boolean-stated actions with a %NULL parameter
        /// type is to toggle them via the #GSimpleAction::change-state signal.
        /// For stateful actions where the state type is equal to the parameter
        /// type, the default is to forward them directly to
        /// #GSimpleAction::change-state.  This should allow almost all users
        /// of #GSimpleAction to connect only one handler or the other.
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
        /// @value will always be of the correct state type.  In the event that
        /// an incorrect type was given, no signal will be emitted.
        /// 
        /// If no handler is connected to this signal then the default
        /// behaviour is to call g_simple_action_set_state() to set the state
        /// to the requested value. If you connect a signal handler then no
        /// default action is taken. If the state should change then you must
        /// call g_simple_action_set_state() from the handler.
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
        /* <type name="GType" managed-name="GType" /> */
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_simple_action_set_enabled(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
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
            var enabled_ = enabled;
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_simple_action_set_state(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
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
        /// property.  Instead, they should call g_action_change_state() to
        /// request the change.
        /// 
        /// If the @value GVariant is floating, it is consumed.
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
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none direction:out */
        static extern void g_simple_action_set_state_hint(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr stateHint);

        /// <summary>
        /// Sets the state hint for the action.
        /// </summary>
        /// <remarks>
        /// See g_action_get_state_hint() for more information about
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

        void GISharp.Lib.Gio.IAction.OnActivate(GISharp.Lib.GLib.Variant parameter)
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.IAction.OnChangeState(GISharp.Lib.GLib.Variant value)
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.IAction.OnGetEnabled()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Utf8 GISharp.Lib.Gio.IAction.OnGetName()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType GISharp.Lib.Gio.IAction.OnGetParameterType()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IAction.OnGetState()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IAction.OnGetStateHint()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.VariantType GISharp.Lib.Gio.IAction.OnGetStateType()
        {
            throw new System.NotImplementedException();
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
        /* <type name="GLib.Source" type="GSource*" managed-name="GLib.Source" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern System.IntPtr g_cancellable_source_new(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

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
        static System.IntPtr New(GISharp.Lib.Gio.Cancellable cancellable)
        {
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_cancellable_source_new(cancellable_);
            return ret_;
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
        public CancellableSource(GISharp.Lib.Gio.Cancellable cancellable) : this(New(cancellable), GISharp.Runtime.Transfer.Full)
        {
        }
    }
}