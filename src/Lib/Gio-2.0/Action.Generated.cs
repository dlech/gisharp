// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="Action.xmldoc" path="declaration/member[@name='IAction']/*" />
    [GISharp.Runtime.GTypeAttribute("GAction", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ActionInterface))]
    public unsafe partial interface IAction : GISharp.Lib.GObject.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Runtime.GType _GType = g_action_get_type();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.Enabled']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("enabled")]
        bool Enabled { get; }

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.Name']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("name")]
        GISharp.Runtime.Utf8? Name { get; }

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.ParameterType']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("parameter-type")]
        GISharp.Lib.GLib.VariantType? ParameterType { get; }

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.State']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state")]
        GISharp.Lib.GLib.Variant? State { get; }

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.StateType']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GPropertyAttribute("state-type")]
        GISharp.Lib.GLib.VariantType? StateType { get; }

        /// <summary>
        /// Checks if @action_name is valid.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @action_name is valid if it consists only of alphanumeric characters,
        /// plus '-' and '.'.  The empty string is not a valid action name.
        /// </para>
        /// <para>
        /// It is an error to call this function with a non-utf8 @action_name.
        /// @action_name must not be %NULL.
        /// </para>
        /// </remarks>
        /// <param name="actionName">
        /// a potential action name
        /// </param>
        /// <returns>
        /// %TRUE if @action_name is valid
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_action_name_is_valid(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* actionName);
        static partial void CheckNameIsValidArgs(GISharp.Runtime.UnownedUtf8 actionName);

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.NameIsValid(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static bool NameIsValid(GISharp.Runtime.UnownedUtf8 actionName)
        {
            CheckNameIsValidArgs(actionName);
            var actionName_ = (byte*)actionName.UnsafeHandle;
            var ret_ = g_action_name_is_valid(actionName_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Parses a detailed action name into its separate name and target
        /// components.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Detailed action names can have three formats.
        /// </para>
        /// <para>
        /// The first format is used to represent an action name with no target
        /// value and consists of just an action name containing no whitespace
        /// nor the characters `:`, `(` or `)`.  For example: `app.action`.
        /// </para>
        /// <para>
        /// The second format is used to represent an action with a target value
        /// that is a non-empty string consisting only of alphanumerics, plus `-`
        /// and `.`.  In that case, the action name and target value are
        /// separated by a double colon (`::`).  For example:
        /// `app.action::target`.
        /// </para>
        /// <para>
        /// The third format is used to represent an action with any type of
        /// target value, including strings.  The target value follows the action
        /// name, surrounded in parens.  For example: `app.action(42)`.  The
        /// target value is parsed using g_variant_parse().  If a tuple-typed
        /// value is desired, it must be specified in the same way, resulting in
        /// two sets of parens, for example: `app.action((1,2,3))`.  A string
        /// target can be specified this way as well: `app.action('target')`.
        /// For strings, this third format must be used if target value is
        /// empty or contains characters other than alphanumerics, `-` and `.`.
        /// </para>
        /// <para>
        /// If this function returns %TRUE, a non-%NULL value is guaranteed to be returned
        /// in @action_name (if a pointer is passed in). A %NULL value may still be
        /// returned in @target_value, as the @detailed_name may not contain a target.
        /// </para>
        /// <para>
        /// If returned, the #GVariant in @target_value is guaranteed to not be floating.
        /// </para>
        /// </remarks>
        /// <param name="detailedName">
        /// a detailed action name
        /// </param>
        /// <param name="actionName">
        /// the action name
        /// </param>
        /// <param name="targetValue">
        /// the target value,
        ///   or %NULL for no target
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_action_parse_detailed_name(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* detailedName,
        /* <type name="utf8" type="gchar**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        byte** actionName,
        /* <type name="GLib.Variant" type="GVariant**" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full nullable:1 optional:1 allow-none:1 */
        GISharp.Lib.GLib.Variant.UnmanagedStruct** targetValue,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        static partial void CheckParseDetailedNameArgs(GISharp.Runtime.UnownedUtf8 detailedName);

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.ParseDetailedName(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.Utf8,GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static void ParseDetailedName(GISharp.Runtime.UnownedUtf8 detailedName, out GISharp.Runtime.Utf8 actionName, out GISharp.Lib.GLib.Variant? targetValue)
        {
            CheckParseDetailedNameArgs(detailedName);
            var detailedName_ = (byte*)detailedName.UnsafeHandle;
            byte* actionName_;
            GISharp.Lib.GLib.Variant.UnmanagedStruct* targetValue_;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            g_action_parse_detailed_name(detailedName_, &actionName_, &targetValue_, &error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            actionName = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)actionName_, GISharp.Runtime.Transfer.Full)!;
            targetValue = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)targetValue_, GISharp.Runtime.Transfer.Full);
        }

        /// <summary>
        /// Formats a detailed action name from @action_name and @target_value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is an error to call this function with an invalid action name.
        /// </para>
        /// <para>
        /// This function is the opposite of g_action_parse_detailed_name().
        /// It will produce a string that can be parsed back to the @action_name
        /// and @target_value by that function.
        /// </para>
        /// <para>
        /// See that function for the types of strings that will be printed by
        /// this function.
        /// </para>
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
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_action_print_detailed_name(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* actionName,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* targetValue);
        static partial void CheckPrintDetailedNameArgs(GISharp.Runtime.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant? targetValue);

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.PrintDetailedName(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Runtime.Utf8 PrintDetailedName(GISharp.Runtime.UnownedUtf8 actionName, GISharp.Lib.GLib.Variant? targetValue)
        {
            CheckPrintDetailedNameArgs(actionName, targetValue);
            var actionName_ = (byte*)actionName.UnsafeHandle;
            var targetValue_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(targetValue?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_action_print_detailed_name(actionName_,targetValue_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_action_get_type();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoActivate(GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedActivate))]
        void DoActivate(GISharp.Lib.GLib.Variant? parameter);

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoChangeState(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedChangeState))]
        void DoChangeState(GISharp.Lib.GLib.Variant value);

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetEnabled()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetEnabled))]
        bool DoGetEnabled();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetName()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetName))]
        GISharp.Runtime.UnownedUtf8 DoGetName();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetParameterType()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetParameterType))]
        GISharp.Lib.GLib.VariantType? DoGetParameterType();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetState()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetState))]
        GISharp.Lib.GLib.Variant? DoGetState();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetStateHint()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetStateHint))]
        GISharp.Lib.GLib.Variant? DoGetStateHint();

        /// <include file="Action.xmldoc" path="declaration/member[@name='IAction.DoGetStateType()']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionInterface.UnmanagedGetStateType))]
        GISharp.Lib.GLib.VariantType? DoGetStateType();
    }

    /// <summary>
    /// Extension methods for <see cref="IAction"/>
    /// </summary>
    public static unsafe partial class Action
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// Activates the action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @parameter must be the correct type of parameter for the action (ie:
        /// the parameter type given at construction time).  If the parameter
        /// type was %NULL then @parameter must also be %NULL.
        /// </para>
        /// <para>
        /// If the @parameter GVariant is floating, it is consumed.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <param name="parameter">
        /// the parameter to the activation
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_action_activate(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter);
        static partial void CheckActivateArgs(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant? parameter);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.Activate(GISharp.Lib.Gio.IAction,GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static void Activate(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant? parameter)
        {
            CheckActivateArgs(action, parameter);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var parameter_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(parameter?.UnsafeHandle ?? System.IntPtr.Zero);
            g_action_activate(action_, parameter_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Request for the state of @action to be changed to @value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The action must be stateful and @value must be of the correct type.
        /// See g_action_get_state_type().
        /// </para>
        /// <para>
        /// This call merely requests a change.  The action may refuse to change
        /// its state or may change its state to something other than @value.
        /// See g_action_get_state_hint().
        /// </para>
        /// <para>
        /// If the @value GVariant is floating, it is consumed.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <param name="value">
        /// the new state
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_action_change_state(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action,
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        static partial void CheckChangeStateArgs(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant value);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.ChangeState(GISharp.Lib.Gio.IAction,GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        public static void ChangeState(this GISharp.Lib.Gio.IAction action, GISharp.Lib.GLib.Variant value)
        {
            CheckChangeStateArgs(action, value);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
            g_action_change_state(action_, value_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Checks if @action is currently enabled.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An action must be enabled in order to be activated or in order to
        /// have its state changed from outside callers.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// whether the action is enabled
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_action_get_enabled(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetEnabledArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetEnabled(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static bool GetEnabled(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetEnabledArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_enabled(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_action_get_name(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetNameArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetName(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Runtime.UnownedUtf8 GetName(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetNameArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_name(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Queries the type of the parameter that must be given when activating
        /// @action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When activating the action using g_action_activate(), the #GVariant
        /// given to that function must be of the type returned by this function.
        /// </para>
        /// <para>
        /// In the case that this function returns %NULL, you must not give any
        /// #GVariant, but %NULL instead.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the parameter type
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.VariantType.UnmanagedStruct* g_action_get_parameter_type(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetParameterTypeArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetParameterType(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType? GetParameterType(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetParameterTypeArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_parameter_type(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.VariantType.GetInstance<GISharp.Lib.GLib.VariantType>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Queries the current state of @action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the action is not stateful then %NULL will be returned.  If the
        /// action is stateful then the type of the return value is the type
        /// given by g_action_get_state_type().
        /// </para>
        /// <para>
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the current state of the action
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_action_get_state(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetStateArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetState(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant? GetState(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetStateArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_state(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Requests a hint about the valid range of values for the state of
        /// @action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If %NULL is returned it either means that the action is not stateful
        /// or that there is no hint about the valid range of values for the
        /// state of the action.
        /// </para>
        /// <para>
        /// If a #GVariant array is returned then each item in the array is a
        /// possible value for the state.  If a #GVariant pair (ie: two-tuple) is
        /// returned then the tuple specifies the inclusive lower and upper bound
        /// of valid values for the state.
        /// </para>
        /// <para>
        /// In any case, the information is merely a hint.  It may be possible to
        /// have a state value outside of the hinted range and setting a value
        /// within the range may fail.
        /// </para>
        /// <para>
        /// The return value (if non-%NULL) should be freed with
        /// g_variant_unref() when it is no longer required.
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the state range hint
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_action_get_state_hint(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetStateHintArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetStateHint(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.Variant? GetStateHint(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetStateHintArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_state_hint(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries the type of the state of @action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the action is stateful (e.g. created with
        /// g_simple_action_new_stateful()) then this function returns the
        /// #GVariantType of the state.  This is the type of the initial value
        /// given as the state. All calls to g_action_change_state() must give a
        /// #GVariant of this type and g_action_get_state() will return a
        /// #GVariant of the same type.
        /// </para>
        /// <para>
        /// If the action is not stateful (e.g. created with g_simple_action_new())
        /// then this function will return %NULL. In that case, g_action_get_state()
        /// will return %NULL and you must not call g_action_change_state().
        /// </para>
        /// </remarks>
        /// <param name="action">
        /// a #GAction
        /// </param>
        /// <returns>
        /// the state type, if the action is stateful
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.VariantType.UnmanagedStruct* g_action_get_state_type(
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckGetStateTypeArgs(this GISharp.Lib.Gio.IAction action);

        /// <include file="Action.xmldoc" path="declaration/member[@name='Action.GetStateType(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public static GISharp.Lib.GLib.VariantType? GetStateType(this GISharp.Lib.Gio.IAction action)
        {
            CheckGetStateTypeArgs(action);
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            var ret_ = g_action_get_state_type(action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.VariantType.GetInstance<GISharp.Lib.GLib.VariantType>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }
}