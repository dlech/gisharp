// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionMap.xmldoc" path="declaration/member[@name='IActionMap']/*" />
    [GISharp.Runtime.SinceAttribute("2.32")]
    [GISharp.Runtime.GTypeAttribute("GActionMap", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ActionMapInterface))]
    public unsafe partial interface IActionMap : GISharp.Lib.GObject.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Runtime.GType _GType = g_action_map_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_action_map_get_type();

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='IActionMap.DoAddAction(GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedAddAction))]
        void DoAddAction(GISharp.Lib.Gio.IAction action);

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='IActionMap.DoLookupAction(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedLookupAction))]
        GISharp.Lib.Gio.IAction? DoLookupAction(GISharp.Runtime.UnownedUtf8 actionName);

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='IActionMap.DoRemoveAction(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ActionMapInterface.UnmanagedRemoveAction))]
        void DoRemoveAction(GISharp.Runtime.UnownedUtf8 actionName);
    }

    /// <summary>
    /// Extension methods for <see cref="IActionMap"/>
    /// </summary>
    public static unsafe partial class ActionMap
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// Adds an action to the @action_map.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the action map already contains an action with the same name
        /// as @action then the old action is dropped from the action map.
        /// </para>
        /// <para>
        /// The action map takes its own reference on @action.
        /// </para>
        /// </remarks>
        /// <param name="actionMap">
        /// a #GActionMap
        /// </param>
        /// <param name="action">
        /// a #GAction
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_action_map_add_action(
        /* <type name="ActionMap" type="GActionMap*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Action.UnmanagedStruct* action);
        static partial void CheckAddActionArgs(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.Gio.IAction action);

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='ActionMap.AddAction(GISharp.Lib.Gio.IActionMap,GISharp.Lib.Gio.IAction)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static void AddAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Lib.Gio.IAction action)
        {
            CheckAddActionArgs(actionMap, action);
            var actionMap_ = (GISharp.Lib.Gio.ActionMap.UnmanagedStruct*)actionMap.UnsafeHandle;
            var action_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)action.UnsafeHandle;
            g_action_map_add_action(actionMap_, action_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Looks up the action with the name @action_name in @action_map.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If no such action exists, returns %NULL.
        /// </para>
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
        /* <type name="Action" type="GAction*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.Gio.Action.UnmanagedStruct* g_action_map_lookup_action(
        /* <type name="ActionMap" type="GActionMap*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* actionName);
        static partial void CheckLookupActionArgs(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Runtime.UnownedUtf8 actionName);

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='ActionMap.LookupAction(GISharp.Lib.Gio.IActionMap,GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static GISharp.Lib.Gio.IAction? LookupAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Runtime.UnownedUtf8 actionName)
        {
            CheckLookupActionArgs(actionMap, actionName);
            var actionMap_ = (GISharp.Lib.Gio.ActionMap.UnmanagedStruct*)actionMap.UnsafeHandle;
            var actionName_ = (byte*)actionName.UnsafeHandle;
            var ret_ = g_action_map_lookup_action(actionMap_,actionName_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.Gio.IAction?)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Removes the named action from the action map.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If no action of this name is in the map then nothing happens.
        /// </para>
        /// </remarks>
        /// <param name="actionMap">
        /// a #GActionMap
        /// </param>
        /// <param name="actionName">
        /// the name of the action
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_action_map_remove_action(
        /* <type name="ActionMap" type="GActionMap*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* actionName);
        static partial void CheckRemoveActionArgs(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Runtime.UnownedUtf8 actionName);

        /// <include file="ActionMap.xmldoc" path="declaration/member[@name='ActionMap.RemoveAction(GISharp.Lib.Gio.IActionMap,GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static void RemoveAction(this GISharp.Lib.Gio.IActionMap actionMap, GISharp.Runtime.UnownedUtf8 actionName)
        {
            CheckRemoveActionArgs(actionMap, actionName);
            var actionMap_ = (GISharp.Lib.Gio.ActionMap.UnmanagedStruct*)actionMap.UnsafeHandle;
            var actionName_ = (byte*)actionName.UnsafeHandle;
            g_action_map_remove_action(actionMap_, actionName_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}