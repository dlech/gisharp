namespace GISharp.Lib.Gio
{
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
        static extern unsafe GISharp.Lib.GObject.GType g_action_map_get_type();

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
        static extern unsafe void g_action_map_add_action(
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
        public unsafe static void AddAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.Gio.IAction action)
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
        static extern unsafe System.IntPtr g_action_map_lookup_action(
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
        public unsafe static GISharp.Lib.Gio.IAction LookupAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.GLib.Utf8 actionName)
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
        static extern unsafe void g_action_map_remove_action(
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
        public unsafe static void RemoveAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.GLib.Utf8 actionName)
        {
            var actionMap_ = actionMap?.Handle ?? throw new System.ArgumentNullException(nameof(actionMap));
            var actionName_ = actionName?.Handle ?? throw new System.ArgumentNullException(nameof(actionName));
            g_action_map_remove_action(actionMap_, actionName_);
        }
    }
}