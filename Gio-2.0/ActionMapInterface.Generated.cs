namespace GISharp.Lib.Gio
{
    /// <summary>
    /// The virtual function table for <see cref="IActionMap"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.32")]
    public sealed class ActionMapInterface : GISharp.Lib.GObject.TypeInterface
    {
        unsafe new struct Struct
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
        public unsafe delegate System.IntPtr UnmanagedLookupAction(
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
            public static unsafe UnmanagedLookupAction Create(System.Reflection.MethodInfo methodInfo)
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
        public unsafe delegate void UnmanagedAddAction(
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
            public static unsafe UnmanagedAddAction Create(System.Reflection.MethodInfo methodInfo)
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
        public unsafe delegate void UnmanagedRemoveAction(
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
            public static unsafe UnmanagedRemoveAction Create(System.Reflection.MethodInfo methodInfo)
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
}