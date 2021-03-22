// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='ParamSpecClass']/*" />
    public unsafe partial class ParamSpecClass : GISharp.Lib.GObject.TypeClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GTypeClass']/*" />
            public readonly GISharp.Lib.GObject.TypeClass.UnmanagedStruct GTypeClass;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ValueType']/*" />
            public readonly GISharp.Runtime.GType ValueType;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Finalize']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*, void> Finalize;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ValueSetDefault']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*, GISharp.Lib.GObject.Value*, void> ValueSetDefault;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ValueValidate']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*, GISharp.Lib.GObject.Value*, GISharp.Runtime.Boolean> ValueValidate;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ValuesCmp']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*, GISharp.Lib.GObject.Value*, GISharp.Lib.GObject.Value*, int> ValuesCmp;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Dummy0']/*" />
            internal readonly System.IntPtr Dummy0;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Dummy1']/*" />
            internal readonly System.IntPtr Dummy1;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Dummy2']/*" />
            internal readonly System.IntPtr Dummy2;

            /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Dummy3']/*" />
            internal readonly System.IntPtr Dummy3;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static ParamSpecClass()
        {
            int finalizeOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Finalize));
            RegisterVirtualMethod(finalizeOffset, FinalizeMarshal.Create);
            int valueSetDefaultOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ValueSetDefault));
            RegisterVirtualMethod(valueSetDefaultOffset, ValueSetDefaultMarshal.Create);
            int valueValidateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ValueValidate));
            RegisterVirtualMethod(valueValidateOffset, ValueValidateMarshal.Create);
            int valuesCmpOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ValuesCmp));
            RegisterVirtualMethod(valuesCmpOffset, ValuesCmpMarshal.Create);
        }

        /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='_Finalize']/*" />
        public delegate void _Finalize();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedFinalize(
/* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Class for marshalling <see cref="_Finalize"/> methods.
        /// </summary>
        public static unsafe class FinalizeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedFinalize Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedFinalize(GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_) { try { var pspec = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; var doFinalize = (_Finalize)methodInfo.CreateDelegate(typeof(_Finalize), pspec); doFinalize(); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedFinalize;
            }
        }

        /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='_ValueSetDefault']/*" />
        public delegate void _ValueSetDefault(ref GISharp.Lib.GObject.Value value);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedValueSetDefault(
/* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
/* <type name="Value" type="GValue*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value);

        /// <summary>
        /// Class for marshalling <see cref="_ValueSetDefault"/> methods.
        /// </summary>
        public static unsafe class ValueSetDefaultMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedValueSetDefault Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedValueSetDefault(GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_, GISharp.Lib.GObject.Value* value_) { try { var pspec = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; ref var value = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.Value>(value_); var doValueSetDefault = (_ValueSetDefault)methodInfo.CreateDelegate(typeof(_ValueSetDefault), pspec); doValueSetDefault(ref value); } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } }

                return unmanagedValueSetDefault;
            }
        }

        /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='_ValueValidate']/*" />
        public delegate bool _ValueValidate(ref GISharp.Lib.GObject.Value value);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedValueValidate(
/* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
/* <type name="Value" type="GValue*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value);

        /// <summary>
        /// Class for marshalling <see cref="_ValueValidate"/> methods.
        /// </summary>
        public static unsafe class ValueValidateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedValueValidate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedValueValidate(GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_, GISharp.Lib.GObject.Value* value_) { try { var pspec = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; ref var value = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.Value>(value_); var doValueValidate = (_ValueValidate)methodInfo.CreateDelegate(typeof(_ValueValidate), pspec); var ret = doValueValidate(ref value); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedValueValidate;
            }
        }

        /// <include file="ParamSpecClass.xmldoc" path="declaration/member[@name='_ValuesCmp']/*" />
        public delegate int _ValuesCmp(in GISharp.Lib.GObject.Value value1, in GISharp.Lib.GObject.Value value2);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate int UnmanagedValuesCmp(
/* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
/* <type name="Value" type="const GValue*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value1,
/* <type name="Value" type="const GValue*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value2);

        /// <summary>
        /// Class for marshalling <see cref="_ValuesCmp"/> methods.
        /// </summary>
        public static unsafe class ValuesCmpMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedValuesCmp Create(System.Reflection.MethodInfo methodInfo)
            {
                int unmanagedValuesCmp(GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_, GISharp.Lib.GObject.Value* value1_, GISharp.Lib.GObject.Value* value2_) { try { var pspec = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; ref var value1 = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.Value>(value1_); ref var value2 = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.GObject.Value>(value2_); var doValuesCmp = (_ValuesCmp)methodInfo.CreateDelegate(typeof(_ValuesCmp), pspec); var ret = doValuesCmp(value1, value2); var ret_ = (int)ret; return ret_; } catch (System.Exception ex) { GISharp.Runtime.GMarshal.PushUnhandledException(ex); } return default(int); }

                return unmanagedValuesCmp;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}