namespace GISharp.Gio
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
    [GISharp.Runtime.GTypeStructAttribute(typeof(GISharp.Gio.ActionInterface))]
    public interface IAction : GISharp.Runtime.GInterface<GISharp.GObject.Object>
    {
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        System.Boolean Enabled { get; }
        [GISharp.Runtime.GPropertyAttribute("name")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.GLib.Utf8 Name { get; }
        [GISharp.Runtime.GPropertyAttribute("parameter-type")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.GLib.VariantType ParameterType { get; }
        [GISharp.Runtime.GPropertyAttribute("state")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.GLib.Variant State { get; }
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.GLib.VariantType StateType { get; }

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
        void Activate(GISharp.GLib.Variant parameter);

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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.30")]
        void ChangeState(GISharp.GLib.Variant value);

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
        System.Boolean GetEnabled();

        /// <summary>
        /// Queries the name of @action.
        /// </summary>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        GISharp.GLib.Utf8 GetName();

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
        GISharp.GLib.VariantType GetParameterType();

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
        GISharp.GLib.Variant GetState();

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
        GISharp.GLib.Variant GetStateHint();

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
        GISharp.GLib.VariantType GetStateType();
    }

    public static class Action
    {
        static readonly GISharp.GObject.GType _GType = g_action_get_type();

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
        /* transfer-ownership:none */
        static extern System.Boolean g_action_name_is_valid(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="actionName"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if @action_name is valid
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static System.Boolean NameIsValid(GISharp.GLib.Utf8 actionName)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var ret = g_action_name_is_valid(actionName_);
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
        /* transfer-ownership:none */
        static extern System.Boolean g_action_parse_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr detailedName,
        /* <type name="utf8" type="gchar**" managed-name="Utf8" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant**" managed-name="GLib.Variant" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.IntPtr targetValue,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="detailedName"/> is <c>null</c>.
        ///</exception>
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
        public static System.Boolean TryParseDetailedName(GISharp.GLib.Utf8 detailedName, out GISharp.GLib.Utf8 actionName, out GISharp.GLib.Variant targetValue)
        {
            var detailedName_ = detailedName?.Handle ?? throw new System.ArgumentNullException(nameof(detailedName));
            System.IntPtr actionName_;
            System.IntPtr targetValue_;
            System.IntPtr error_;
            var ret = g_action_parse_detailed_name(detailedName_,out actionName_,out targetValue_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            actionName = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(actionName_, GISharp.Runtime.Transfer.Full);
            targetValue = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(targetValue_, GISharp.Runtime.Transfer.Full);
            return ret;
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
        /* transfer-ownership:full */
        static extern System.IntPtr g_action_print_detailed_name(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr actionName,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="actionName"/> is <c>null</c>.
        ///</exception>
        /// <param name="targetValue">
        /// a #GVariant target value, or %NULL
        /// </param>
        /// <returns>
        /// a detailed format string
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.GLib.Utf8 PrintDetailedName(GISharp.GLib.Utf8 actionName, GISharp.GLib.Variant targetValue)
        {
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            var targetValue_ = targetValue?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_action_print_detailed_name(actionName_, targetValue_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GISharp.GObject.GType g_action_get_type();

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
        /* transfer-ownership:none */
        static extern void g_action_activate(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void Activate(GISharp.Gio.IAction action, GISharp.GLib.Variant parameter)
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
        /* transfer-ownership:none */
        static extern void g_action_change_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr action,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// the new state
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.30")]
        public static void ChangeState(GISharp.Gio.IAction action, GISharp.GLib.Variant value)
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
        /* transfer-ownership:none */
        static extern System.Boolean g_action_get_enabled(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static System.Boolean GetEnabled(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret = g_action_get_enabled(action_);
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
        /* transfer-ownership:none */
        static extern System.IntPtr g_action_get_name(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr action);

        /// <summary>
        /// Queries the name of @action.
        /// </summary>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the name of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.GLib.Utf8 GetName(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_name(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
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
        /* transfer-ownership:none nullable:1 */
        static extern System.IntPtr g_action_get_parameter_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.GLib.VariantType GetParameterType(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_parameter_type(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
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
        /* transfer-ownership:full */
        static extern System.IntPtr g_action_get_state(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.GLib.Variant GetState(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
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
        /* transfer-ownership:full nullable:1 */
        static extern System.IntPtr g_action_get_state_hint(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.GLib.Variant GetStateHint(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state_hint(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
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
        /* transfer-ownership:none nullable:1 */
        static extern System.IntPtr g_action_get_state_type(
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.GLib.VariantType GetStateType(GISharp.Gio.IAction action)
        {
            var action_ = action?.Handle ?? throw new System.ArgumentNullException(nameof(action));
            var ret_ = g_action_get_state_type(action_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.VariantType>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }

    /// <summary>
    /// The virtual function table for #GAction.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed partial class ActionInterface : GISharp.GObject.TypeInterface
    {
        static readonly System.IntPtr gIfaceOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GIface));
        static readonly System.IntPtr getNameOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetName));
        static readonly UnmanagedGetName getNameDelegate = OnGetName;
        static readonly System.IntPtr getNameDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getNameDelegate);
        static readonly System.IntPtr getParameterTypeOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetParameterType));
        static readonly UnmanagedGetParameterType getParameterTypeDelegate = OnGetParameterType;
        static readonly System.IntPtr getParameterTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getParameterTypeDelegate);
        static readonly System.IntPtr getStateTypeOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetStateType));
        static readonly UnmanagedGetStateType getStateTypeDelegate = OnGetStateType;
        static readonly System.IntPtr getStateTypeDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getStateTypeDelegate);
        static readonly System.IntPtr getStateHintOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetStateHint));
        static readonly UnmanagedGetStateHint getStateHintDelegate = OnGetStateHint;
        static readonly System.IntPtr getStateHintDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getStateHintDelegate);
        static readonly System.IntPtr getEnabledOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetEnabled));
        static readonly UnmanagedGetEnabled getEnabledDelegate = OnGetEnabled;
        static readonly System.IntPtr getEnabledDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getEnabledDelegate);
        static readonly System.IntPtr getStateOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetState));
        static readonly UnmanagedGetState getStateDelegate = OnGetState;
        static readonly System.IntPtr getStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(getStateDelegate);
        static readonly System.IntPtr changeStateOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ChangeState));
        static readonly UnmanagedChangeState changeStateDelegate = OnChangeState;
        static readonly System.IntPtr changeStateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(changeStateDelegate);
        static readonly System.IntPtr activateOffset = System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Activate));
        static readonly UnmanagedActivate activateDelegate = OnActivate;
        static readonly System.IntPtr activateDelegate_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(activateDelegate);

        new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.GObject.TypeInterface.Struct GIface;
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

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.IntPtr UnmanagedGetName(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate GISharp.GLib.Utf8 GetName(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.IntPtr UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate GISharp.GLib.VariantType GetParameterType(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.IntPtr UnmanagedGetStateType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate GISharp.GLib.VariantType GetStateType(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.IntPtr UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate GISharp.GLib.Variant GetStateHint(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate System.Boolean GetEnabled(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate System.IntPtr UnmanagedGetState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action);

        public delegate GISharp.GLib.Variant GetState(GISharp.Gio.IAction action);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void UnmanagedChangeState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr value);

        public delegate void ChangeState(GISharp.Gio.IAction action, GISharp.GLib.Variant value);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void UnmanagedActivate(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none */
System.IntPtr action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 */
System.IntPtr parameter);

        public delegate void Activate(GISharp.Gio.IAction action, GISharp.GLib.Variant parameter);

        public ActionInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        public override GISharp.GObject.InterfaceInfo CreateInterfaceInfo(System.Type type)
        {
            var ret = new GISharp.GObject.InterfaceInfo
            {
                InterfaceInit = InterfaceInit,
            };
            return ret;
        }

        static void InterfaceInit(System.IntPtr gIface, System.IntPtr userData)
        {
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getNameOffset, getNameDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getParameterTypeOffset, getParameterTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getStateTypeOffset, getStateTypeDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getStateHintOffset, getStateHintDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getEnabledOffset, getEnabledDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)getStateOffset, getStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)changeStateOffset, changeStateDelegate_);
            System.Runtime.InteropServices.Marshal.WriteIntPtr(gIface, (int)activateOffset, activateDelegate_);
        }

        static System.IntPtr OnGetName(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetName();
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetParameterType(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetParameterType();
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetStateType(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetStateType();
                var ret_ = ret?.Handle ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.IntPtr OnGetStateHint(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetStateHint();
                var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static System.Boolean OnGetEnabled(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetEnabled();
                return ret;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.Boolean);
            }
        }

        static System.IntPtr OnGetState(System.IntPtr action_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var ret = action.GetState();
                var ret_ = ret?.Take() ?? System.IntPtr.Zero;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
                return default(System.IntPtr);
            }
        }

        static void OnChangeState(System.IntPtr action_, System.IntPtr value_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(value_, GISharp.Runtime.Transfer.None);
                action.ChangeState(value);
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void OnActivate(System.IntPtr action_, System.IntPtr parameter_)
        {
            try
            {
                var action = (GISharp.Gio.IAction)GISharp.Runtime.Opaque.GetInstance<GISharp.GObject.Object>(action_, GISharp.Runtime.Transfer.None);
                var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(parameter_, GISharp.Runtime.Transfer.None);
                action.Activate(parameter);
            }
            catch (System.Exception ex)
            {
                GISharp.GLib.Log.LogUnhandledException(ex);
            }
        }
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
    public sealed partial class SimpleAction : GISharp.GObject.Object, GISharp.Gio.IAction
    {
        static readonly GISharp.GObject.GType _GType = g_simple_action_get_type();
        static readonly GISharp.GLib.Utf8 nameofEnabled = new GISharp.GLib.Utf8("enabled");

        [GISharp.Runtime.GPropertyAttribute("enabled")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        public System.Boolean Enabled { get => (System.Boolean)GetProperty(nameofEnabled);set => SetProperty(nameofEnabled, value);}

        static readonly GISharp.GLib.Utf8 nameofName = new GISharp.GLib.Utf8("name");

        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.GLib.Utf8 Name { get => (GISharp.GLib.Utf8)GetProperty(nameofName);}

        static readonly GISharp.GLib.Utf8 nameofParameterType = new GISharp.GLib.Utf8("parameter-type");

        [GISharp.Runtime.GPropertyAttribute("parameter-type", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.GLib.VariantType ParameterType { get => (GISharp.GLib.VariantType)GetProperty(nameofParameterType);}

        static readonly GISharp.GLib.Utf8 nameofState = new GISharp.GLib.Utf8("state");

        [GISharp.Runtime.GPropertyAttribute("state", Construct = GISharp.Runtime.GPropertyConstruct.Yes)]
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.GLib.Variant State { get => (GISharp.GLib.Variant)GetProperty(nameofState);set => SetProperty(nameofState, value);}

        static readonly GISharp.GLib.Utf8 nameofStateType = new GISharp.GLib.Utf8("state-type");

        [GISharp.Runtime.GPropertyAttribute("state-type")]
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.GLib.VariantType StateType { get => (GISharp.GLib.VariantType)GetProperty(nameofStateType);}

        public sealed class ActivatedEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.GObject.Value[] args;

            public GISharp.GLib.Variant Parameter => (GISharp.GLib.Variant)args[1].Get();

            public ActivatedEventArgs(GISharp.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<ActivatedEventArgs> activatedSignalHandler = new GISharp.Runtime.GSignalManager<ActivatedEventArgs>("activate", _GType);

        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GSignalAttribute("activate", When = GISharp.Runtime.EmissionStage.Last)]
        public event System.EventHandler<ActivatedEventArgs> Activated { add => activatedSignalHandler.Add(this, value); remove => activatedSignalHandler.Remove(value); }

        public sealed class ChangedStateEventArgs : GISharp.Runtime.GSignalEventArgs
        {
            readonly GISharp.GObject.Value[] args;

            public GISharp.GLib.Variant Value => (GISharp.GLib.Variant)args[1].Get();

            public ChangedStateEventArgs(GISharp.GObject.Value[] args)
            {
                this.args = args ?? throw new System.ArgumentNullException(nameof(args));
            }
        }

        readonly GISharp.Runtime.GSignalManager<ChangedStateEventArgs> changedStateSignalHandler = new GISharp.Runtime.GSignalManager<ChangedStateEventArgs>("change-state", _GType);

        [GISharp.Runtime.SinceAttribute("2.30")]
        [GISharp.Runtime.GSignalAttribute("change-state", When = GISharp.Runtime.EmissionStage.Last)]
        public event System.EventHandler<ChangedStateEventArgs> ChangedState { add => changedStateSignalHandler.Add(this, value); remove => changedStateSignalHandler.Remove(value); }

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
        /* transfer-ownership:full */
        static extern System.IntPtr g_simple_action_new(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="name"/> is <c>null</c>.
        ///</exception>
        /// <param name="parameterType">
        /// the type of parameter to the activate function
        /// </param>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static System.IntPtr New(GISharp.GLib.Utf8 name, GISharp.GLib.VariantType parameterType)
        {
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_simple_action_new(name_, parameterType_);
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="name"/> is <c>null</c>.
        ///</exception>
        /// <param name="parameterType">
        /// the type of parameter to the activate function
        /// </param>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.GLib.Utf8 name, GISharp.GLib.VariantType parameterType) : this(New(name, parameterType), GISharp.Runtime.Transfer.Full)
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
        /* transfer-ownership:full */
        static extern System.IntPtr g_simple_action_new_stateful(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr name,
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr parameterType,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="name"/> is <c>null</c>.
        ///</exception>
        /// <param name="parameterType">
        /// the type of the parameter to the activate function
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="state"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static System.IntPtr NewStateful(GISharp.GLib.Utf8 name, GISharp.GLib.VariantType parameterType, GISharp.GLib.Variant state)
        {
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            var parameterType_ = parameterType?.Handle ?? System.IntPtr.Zero;
            var state_ = state?.Handle ?? throw new System.ArgumentNullException(nameof(state));
            var ret_ = g_simple_action_new_stateful(name_, parameterType_, state_);
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="name"/> is <c>null</c>.
        ///</exception>
        /// <param name="parameterType">
        /// the type of the parameter to the activate function
        /// </param>
        /// <param name="state">
        /// the initial state of the action
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="state"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a new #GSimpleAction
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public SimpleAction(GISharp.GLib.Utf8 name, GISharp.GLib.VariantType parameterType, GISharp.GLib.Variant state) : this(NewStateful(name, parameterType, state), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GISharp.GObject.GType g_simple_action_get_type();

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
        /* transfer-ownership:none */
        static extern void g_simple_action_set_enabled(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr simple,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
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
            var this_ = this.Handle;
            g_simple_action_set_enabled(this_, enabled);
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
        /* transfer-ownership:none */
        static extern void g_simple_action_set_state(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
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
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.30")]
        public void SetState(GISharp.GLib.Variant value)
        {
            var this_ = this.Handle;
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_simple_action_set_state(this_, value_);
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
        /* transfer-ownership:none */
        static extern void g_simple_action_set_state_hint(
        /* <type name="SimpleAction" type="GSimpleAction*" managed-name="SimpleAction" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr simple,
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
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
        public void SetStateHint(GISharp.GLib.Variant stateHint)
        {
            var this_ = this.Handle;
            var stateHint_ = stateHint?.Handle ?? System.IntPtr.Zero;
            g_simple_action_set_state_hint(this_, stateHint_);
        }

        /// <inheritdoc />
        public void Activate(GISharp.GLib.Variant parameter) => GISharp.Gio.Action.Activate(this, parameter);

        /// <inheritdoc />
        public void ChangeState(GISharp.GLib.Variant value) => GISharp.Gio.Action.ChangeState(this, value);

        /// <inheritdoc />
        public System.Boolean GetEnabled() => GISharp.Gio.Action.GetEnabled(this);

        /// <inheritdoc />
        public GISharp.GLib.Utf8 GetName() => GISharp.Gio.Action.GetName(this);

        /// <inheritdoc />
        public GISharp.GLib.VariantType GetParameterType() => GISharp.Gio.Action.GetParameterType(this);

        /// <inheritdoc />
        public GISharp.GLib.Variant GetState() => GISharp.Gio.Action.GetState(this);

        /// <inheritdoc />
        public GISharp.GLib.Variant GetStateHint() => GISharp.Gio.Action.GetStateHint(this);

        /// <inheritdoc />
        public GISharp.GLib.VariantType GetStateType() => GISharp.Gio.Action.GetStateType(this);
    }
}