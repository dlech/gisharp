// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='ActionMapInterface']/*" />
    [GISharp.Runtime.SinceAttribute("2.32")]
    public sealed unsafe class ActionMapInterface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
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
            int lookupActionOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.LookupAction));
            RegisterVirtualMethod(lookupActionOffset, LookupActionMarshal.Create);
            int addActionOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.AddAction));
            RegisterVirtualMethod(addActionOffset, AddActionMarshal.Create);
            int removeActionOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.RemoveAction));
            RegisterVirtualMethod(removeActionOffset, RemoveActionMarshal.Create);
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='LookupAction']/*" />
        public delegate GISharp.Lib.Gio.IAction LookupAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Lib.Gio.Action.UnmanagedStruct* UnmanagedLookupAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="LookupAction"/> methods.
        /// </summary>
        public static unsafe class LookupActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedLookupAction Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.Action.UnmanagedStruct* unmanagedLookupAction(GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap_, byte* actionName_) { try { var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionMap_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doLookupAction = (LookupAction)methodInfo.CreateDelegate(typeof(LookupAction), actionMap); var ret = doLookupAction(actionName); var ret_ = (GISharp.Lib.Gio.Action.UnmanagedStruct*)ret.UnsafeHandle; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.Gio.Action.UnmanagedStruct*); }

                return unmanagedLookupAction;
            }
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='AddAction']/*" />
        public delegate void AddAction(GISharp.Lib.Gio.IAction action);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedAddAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="AddAction"/> methods.
        /// </summary>
        public static unsafe class AddActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedAddAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedAddAction(GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap_, GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionMap_, GISharp.Runtime.Transfer.None)!; var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doAddAction = (AddAction)methodInfo.CreateDelegate(typeof(AddAction), actionMap); doAddAction(action); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedAddAction;
            }
        }

        /// <include file="ActionMapInterface.xmldoc" path="declaration/member[@name='RemoveAction']/*" />
        public delegate void RemoveAction(GISharp.Lib.GLib.UnownedUtf8 actionName);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedRemoveAction(
/* <type name="ActionMap" type="GActionMap*" managed-name="ActionMap" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* actionName);

        /// <summary>
        /// Class for marshalling <see cref="RemoveAction"/> methods.
        /// </summary>
        public static unsafe class RemoveActionMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedRemoveAction Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedRemoveAction(GISharp.Lib.Gio.ActionMap.UnmanagedStruct* actionMap_, byte* actionName_) { try { var actionMap = (GISharp.Lib.Gio.IActionMap)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)actionMap_, GISharp.Runtime.Transfer.None)!; var actionName = new GISharp.Lib.GLib.UnownedUtf8(actionName_); var doRemoveAction = (RemoveAction)methodInfo.CreateDelegate(typeof(RemoveAction), actionMap); doRemoveAction(actionName); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedRemoveAction;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ActionMapInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}