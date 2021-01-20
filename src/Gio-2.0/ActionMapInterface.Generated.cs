// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='ActionMapInterface']/*" />
    [GISharp.Runtime.SinceAttribute("2.32")]
    public sealed class ActionMapInterface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ActionMapInterface"/>.
        /// </summary>
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.LookupAction']/*" />
            public readonly System.IntPtr LookupAction;

            /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.AddAction']/*" />
            public readonly System.IntPtr AddAction;

            /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.RemoveAction']/*" />
            public readonly System.IntPtr RemoveAction;
#pragma warning restore CS0169, CS0649
        }

        static ActionMapInterface()
        {
            System.Int32 lookupActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.LookupAction));
            RegisterVirtualMethod(lookupActionOffset, LookupActionMarshal.Create);
            System.Int32 addActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.AddAction));
            RegisterVirtualMethod(addActionOffset, AddActionMarshal.Create);
            System.Int32 removeActionOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.RemoveAction));
            RegisterVirtualMethod(removeActionOffset, RemoveActionMarshal.Create);
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='LookupAction']/*" />
        public delegate GISharp.Lib.Gio.IAction LookupAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
        /// Class for marshalling <see cref="LookupAction"/> methods.
        /// </summary>
        public static class LookupActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedLookupAction Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedLookupAction(System.IntPtr actionMap_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doLookupAction = (LookupAction)methodInfo.CreateDelegate(typeof(LookupAction), actionMap);
                        var ret = doLookupAction(actionName);
                        var ret_ = ret.Handle;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedLookupAction;
            }
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='AddAction']/*" />
        public delegate void AddAction(GISharp.Lib.Gio.IAction action);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
        /// Class for marshalling <see cref="AddAction"/> methods.
        /// </summary>
        public static class AddActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedAddAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAddAction(System.IntPtr actionMap_, System.IntPtr action_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None)!;
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance(action_, GISharp.Runtime.Transfer.None)!;
                        var doAddAction = (AddAction)methodInfo.CreateDelegate(typeof(AddAction), actionMap);
                        doAddAction(action);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedAddAction;
            }
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='RemoveAction']/*" />
        public delegate void RemoveAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
        /// Class for marshalling <see cref="RemoveAction"/> methods.
        /// </summary>
        public static class RemoveActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedRemoveAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedRemoveAction(System.IntPtr actionMap_, System.IntPtr actionName_)
                {
                    try
                    {
                        var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance(actionMap_, GISharp.Runtime.Transfer.None)!;
                        var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_, -1);
                        var doRemoveAction = (RemoveAction)methodInfo.CreateDelegate(typeof(RemoveAction), actionMap);
                        doRemoveAction(actionName);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedRemoveAction;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public ActionMapInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}