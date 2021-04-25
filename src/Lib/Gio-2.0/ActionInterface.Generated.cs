// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='ActionInterface']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public sealed unsafe partial class ActionInterface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetName']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, byte*> GetName;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetParameterType']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.VariantType.UnmanagedStruct*> GetParameterType;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetStateType']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.VariantType.UnmanagedStruct*> GetStateType;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetStateHint']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.Variant.UnmanagedStruct*> GetStateHint;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetEnabled']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Runtime.Boolean> GetEnabled;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetState']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.Variant.UnmanagedStruct*> GetState;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.ChangeState']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.Variant.UnmanagedStruct*, void> ChangeState;

            /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Activate']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Action.UnmanagedStruct*, GISharp.Lib.GLib.Variant.UnmanagedStruct*, void> Activate;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static ActionInterface()
        {
            int getNameOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetName));
            RegisterVirtualMethod(getNameOffset, GetNameMarshal.Create);
            int getParameterTypeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetParameterType));
            RegisterVirtualMethod(getParameterTypeOffset, GetParameterTypeMarshal.Create);
            int getStateTypeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetStateType));
            RegisterVirtualMethod(getStateTypeOffset, GetStateTypeMarshal.Create);
            int getStateHintOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetStateHint));
            RegisterVirtualMethod(getStateHintOffset, GetStateHintMarshal.Create);
            int getEnabledOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetEnabled));
            RegisterVirtualMethod(getEnabledOffset, GetEnabledMarshal.Create);
            int getStateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetState));
            RegisterVirtualMethod(getStateOffset, GetStateMarshal.Create);
            int changeStateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ChangeState));
            RegisterVirtualMethod(changeStateOffset, ChangeStateMarshal.Create);
            int activateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Activate));
            RegisterVirtualMethod(activateOffset, ActivateMarshal.Create);
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetName']/*" />
        public delegate GISharp.Runtime.UnownedUtf8 _GetName();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate byte* UnmanagedGetName(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetName"/> methods.
        /// </summary>
        public static unsafe class GetNameMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetName Create(System.Reflection.MethodInfo methodInfo)
            {
                byte* unmanagedGetName(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetName = (_GetName)methodInfo.CreateDelegate(typeof(_GetName), action);
                        var ret = doGetName();
                        var ret_ = (byte*)ret.UnsafeHandle;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(byte*);
                }

                return unmanagedGetName;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetParameterType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? _GetParameterType();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetParameterType(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetParameterType"/> methods.
        /// </summary>
        public static unsafe class GetParameterTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetParameterType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetParameterType(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetParameterType = (_GetParameterType)methodInfo.CreateDelegate(typeof(_GetParameterType), action);
                        var ret = doGetParameterType();
                        var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*);
                }

                return unmanagedGetParameterType;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetStateType']/*" />
        public delegate GISharp.Lib.GLib.VariantType? _GetStateType();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.VariantType.UnmanagedStruct* UnmanagedGetStateType(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetStateType"/> methods.
        /// </summary>
        public static unsafe class GetStateTypeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetStateType Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.VariantType.UnmanagedStruct* unmanagedGetStateType(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetStateType = (_GetStateType)methodInfo.CreateDelegate(typeof(_GetStateType), action);
                        var ret = doGetStateType();
                        var ret_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(ret?.UnsafeHandle ?? System.IntPtr.Zero);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Lib.GLib.VariantType.UnmanagedStruct*);
                }

                return unmanagedGetStateType;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetStateHint']/*" />
        public delegate GISharp.Lib.GLib.Variant? _GetStateHint();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetStateHint(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetStateHint"/> methods.
        /// </summary>
        public static unsafe class GetStateHintMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetStateHint Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetStateHint(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetStateHint = (_GetStateHint)methodInfo.CreateDelegate(typeof(_GetStateHint), action);
                        var ret = doGetStateHint();
                        var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*);
                }

                return unmanagedGetStateHint;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetEnabled']/*" />
        public delegate bool _GetEnabled();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedGetEnabled(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetEnabled"/> methods.
        /// </summary>
        public static unsafe class GetEnabledMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetEnabled Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedGetEnabled(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetEnabled = (_GetEnabled)methodInfo.CreateDelegate(typeof(_GetEnabled), action);
                        var ret = doGetEnabled();
                        var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedGetEnabled;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_GetState']/*" />
        public delegate GISharp.Lib.GLib.Variant? _GetState();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        public unsafe delegate GISharp.Lib.GLib.Variant.UnmanagedStruct* UnmanagedGetState(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action);

        /// <summary>
        /// Class for marshalling <see cref="_GetState"/> methods.
        /// </summary>
        public static unsafe class GetStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetState Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.GLib.Variant.UnmanagedStruct* unmanagedGetState(GISharp.Lib.Gio.Action.UnmanagedStruct* action_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var doGetState = (_GetState)methodInfo.CreateDelegate(typeof(_GetState), action);
                        var ret = doGetState();
                        var ret_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(ret?.Take() ?? System.IntPtr.Zero);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Lib.GLib.Variant.UnmanagedStruct*);
                }

                return unmanagedGetState;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_ChangeState']/*" />
        public delegate void _ChangeState(GISharp.Lib.GLib.Variant value);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedChangeState(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action,
/* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* value);

        /// <summary>
        /// Class for marshalling <see cref="_ChangeState"/> methods.
        /// </summary>
        public static unsafe class ChangeStateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedChangeState Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedChangeState(GISharp.Lib.Gio.Action.UnmanagedStruct* action_, GISharp.Lib.GLib.Variant.UnmanagedStruct* value_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var value = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)value_, GISharp.Runtime.Transfer.None)!;
                        var doChangeState = (_ChangeState)methodInfo.CreateDelegate(typeof(_ChangeState), action);
                        doChangeState(value);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedChangeState;
            }
        }

        /// <include file="ActionInterface.xmldoc" path="declaration/member[@name='_Activate']/*" />
        public delegate void _Activate(GISharp.Lib.GLib.Variant? parameter);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedActivate(
/* <type name="Action" type="GAction*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Action.UnmanagedStruct* action,
/* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter);

        /// <summary>
        /// Class for marshalling <see cref="_Activate"/> methods.
        /// </summary>
        public static unsafe class ActivateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedActivate Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedActivate(GISharp.Lib.Gio.Action.UnmanagedStruct* action_, GISharp.Lib.GLib.Variant.UnmanagedStruct* parameter_)
                {
                    try
                    {
                        var action = (GISharp.Lib.Gio.IAction)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)action_, GISharp.Runtime.Transfer.None)!;
                        var parameter = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)parameter_, GISharp.Runtime.Transfer.None);
                        var doActivate = (_Activate)methodInfo.CreateDelegate(typeof(_Activate), action);
                        doActivate(parameter);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedActivate;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ActionInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}