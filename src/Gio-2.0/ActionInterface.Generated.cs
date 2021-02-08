// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='ActionInterface']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed unsafe class ActionInterface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetName']/*" />
            public readonly System.IntPtr GetName;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetParameterType']/*" />
            public readonly System.IntPtr GetParameterType;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetStateType']/*" />
            public readonly System.IntPtr GetStateType;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetStateHint']/*" />
            public readonly System.IntPtr GetStateHint;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetEnabled']/*" />
            public readonly System.IntPtr GetEnabled;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetState']/*" />
            public readonly System.IntPtr GetState;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ChangeState']/*" />
            public readonly System.IntPtr ChangeState;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Activate']/*" />
            public readonly System.IntPtr Activate;
#pragma warning restore CS0169, CS0649
        }

        static ActionInterface()
        {
            System.Int32 getNameOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetName));
            RegisterVirtualMethod(getNameOffset, GetNameMarshal.Create);
            System.Int32 getParameterTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetParameterType));
            RegisterVirtualMethod(getParameterTypeOffset, GetParameterTypeMarshal.Create);
            System.Int32 getStateTypeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetStateType));
            RegisterVirtualMethod(getStateTypeOffset, GetStateTypeMarshal.Create);
            System.Int32 getStateHintOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetStateHint));
            RegisterVirtualMethod(getStateHintOffset, GetStateHintMarshal.Create);
            System.Int32 getEnabledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetEnabled));
            RegisterVirtualMethod(getEnabledOffset, GetEnabledMarshal.Create);
            System.Int32 getStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetState));
            RegisterVirtualMethod(getStateOffset, GetStateMarshal.Create);
            System.Int32 changeStateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ChangeState));
            RegisterVirtualMethod(changeStateOffset, ChangeStateMarshal.Create);
            System.Int32 activateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateMarshal.Create);
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetName']/*" />
        public delegate GISharp.Lib.GLib.UnownedUtf8 GetName();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate System.Byte* UnmanagedGetName(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetName"/> methods.
        /// </summary>
        public static unsafe class GetNameMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetName Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Byte* unmanagedGetName(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetName = (GetName)methodInfo.CreateDelegate(typeof(GetName), action); var ret = doGetName(); var ret_ = (System.Byte*)ret.UnsafeHandle; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(System.Byte*); }

                return unmanagedGetName;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetParameterType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? GetParameterType();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetParameterType"/> methods.
        /// </summary>
        public static unsafe class GetParameterTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetParameterType(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetParameterType = (GetParameterType)methodInfo.CreateDelegate(typeof(GetParameterType), action); var ret = doGetParameterType(); var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*); }

                return unmanagedGetParameterType;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetStateType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? GetStateType();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" managed-name="GISharp.Lib.GLib.VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetStateType(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetStateType"/> methods.
        /// </summary>
        public static unsafe class GetStateTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetStateType(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetStateType = (GetStateType)methodInfo.CreateDelegate(typeof(GetStateType), action); var ret = doGetStateType(); var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*); }

                return unmanagedGetStateType;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetStateHint']/*" />
        public delegate GISharp.Lib.GLib.Variant? GetStateHint();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetStateHint"/> methods.
        /// </summary>
        public static unsafe class GetStateHintMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetStateHint(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetStateHint = (GetStateHint)methodInfo.CreateDelegate(typeof(GetStateHint), action); var ret = doGetStateHint(); var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*); }

                return unmanagedGetStateHint;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetEnabled']/*" />
        public delegate System.Boolean GetEnabled();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetEnabled"/> methods.
        /// </summary>
        public static unsafe class GetEnabledMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedGetEnabled(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetEnabled = (GetEnabled)methodInfo.CreateDelegate(typeof(GetEnabled), action); var ret = doGetEnabled(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedGetEnabled;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='GetState']/*" />
        public delegate GISharp.Lib.GLib.Variant GetState();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="GetState"/> methods.
        /// </summary>
        public static unsafe class GetStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetState Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetState(GISharp.Lib.Gio.Action.UnmanagedStruct* action_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var doGetState = (GetState)methodInfo.CreateDelegate(typeof(GetState), action); var ret = doGetState(); var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)ret.Take(); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*); }

                return unmanagedGetState;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='ChangeState']/*" />
        public delegate void ChangeState(GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedChangeState(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* value);

        /// <summary>
        /// Class for marshalling <see cref="ChangeState"/> methods.
        /// </summary>
        public static unsafe class ChangeStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedChangeState Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedChangeState(GISharp.Lib.Gio.Action.UnmanagedStruct* action_, GISharp.Lib.GLib.Variant.UnmanagedStruct* value_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)value_, GISharp.Runtime.Transfer.None)!; var doChangeState = (ChangeState)methodInfo.CreateDelegate(typeof(ChangeState), action); doChangeState(value); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedChangeState;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='Activate']/*" />
        public delegate void Activate(GISharp.Lib.GLib.Variant? parameter);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Action" type="GAction*" managed-name="Action" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action,
/* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter);

        /// <summary>
        /// Class for marshalling <see cref="Activate"/> methods.
        /// </summary>
        public static unsafe class ActivateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivate(GISharp.Lib.Gio.Action.UnmanagedStruct* action_, GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter_) { try { var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!; var parameter = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)parameter_, GISharp.Runtime.Transfer.None); var doActivate = (Activate)methodInfo.CreateDelegate(typeof(Activate), action); doActivate(parameter); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedActivate;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public ActionInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}