// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='ObjectClass']/*" />
    public unsafe class ObjectClass : GISharp.Lib.GObject.TypeClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GTypeClass']/*" />
            public readonly GISharp.Lib.GObject.TypeClass GTypeClass;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ConstructProperties']/*" />
            private readonly GISharp.Lib.GLib.SList.UnmanagedStruct* ConstructProperties;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Constructor']/*" />
            public readonly System.IntPtr Constructor;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.SetProperty']/*" />
            public readonly System.IntPtr SetProperty;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetProperty']/*" />
            public readonly System.IntPtr GetProperty;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Dispose']/*" />
            public readonly System.IntPtr Dispose;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Finalize']/*" />
            public readonly System.IntPtr Finalize;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.DispatchPropertiesChanged']/*" />
            public readonly System.IntPtr DispatchPropertiesChanged;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Notify']/*" />
            public readonly System.IntPtr Notify;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Constructed']/*" />
            public readonly System.IntPtr Constructed;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Flags']/*" />
            private readonly nuint Flags;

            /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Pdummy']/*" />
            private fixed long Pdummy[6];
#pragma warning restore CS0169, CS0649
        }

        static ObjectClass()
        {
            System.Int32 setPropertyOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.SetProperty));
            RegisterVirtualMethod(setPropertyOffset, SetPropertyMarshal.Create);
            System.Int32 getPropertyOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetProperty));
            RegisterVirtualMethod(getPropertyOffset, GetPropertyMarshal.Create);
            System.Int32 disposeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Dispose));
            RegisterVirtualMethod(disposeOffset, DisposeMarshal.Create);
            System.Int32 finalizeOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Finalize));
            RegisterVirtualMethod(finalizeOffset, FinalizeMarshal.Create);
            System.Int32 dispatchPropertiesChangedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.DispatchPropertiesChanged));
            RegisterVirtualMethod(dispatchPropertiesChangedOffset, DispatchPropertiesChangedMarshal.Create);
            System.Int32 notifyOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Notify));
            RegisterVirtualMethod(notifyOffset, NotifyMarshal.Create);
            System.Int32 constructedOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Constructed));
            RegisterVirtualMethod(constructedOffset, ConstructedMarshal.Create);
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='SetProperty']/*" />
        public delegate void SetProperty(uint propertyId, GISharp.Lib.GObject.Value value, GISharp.Lib.GObject.ParamSpec pspec);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedSetProperty(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object,
/* <type name="guint" type="guint" managed-name="System.UInt32" /> */
/* transfer-ownership:none direction:in */
uint propertyId,
/* <type name="Value" type="const GValue*" managed-name="Value" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value,
/* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Class for marshalling <see cref="SetProperty"/> methods.
        /// </summary>
        public static unsafe class SetPropertyMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSetProperty Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedSetProperty(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_, uint propertyId_, GISharp.Lib.GObject.Value* value_, GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var propertyId = (uint)propertyId_; var value = (GISharp.Lib.GObject.Value)value_; var pspec = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; var doSetProperty = (SetProperty)methodInfo.CreateDelegate(typeof(SetProperty), @object); doSetProperty(propertyId, value, pspec); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedSetProperty;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='GetProperty']/*" />
        public delegate void GetProperty(uint propertyId, GISharp.Lib.GObject.Value value, GISharp.Lib.GObject.ParamSpec pspec);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedGetProperty(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object,
/* <type name="guint" type="guint" managed-name="System.UInt32" /> */
/* transfer-ownership:none direction:in */
uint propertyId,
/* <type name="Value" type="GValue*" managed-name="Value" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value,
/* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Class for marshalling <see cref="GetProperty"/> methods.
        /// </summary>
        public static unsafe class GetPropertyMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetProperty Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedGetProperty(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_, uint propertyId_, GISharp.Lib.GObject.Value* value_, GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var propertyId = (uint)propertyId_; var value = (GISharp.Lib.GObject.Value)value_; var pspec = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; var doGetProperty = (GetProperty)methodInfo.CreateDelegate(typeof(GetProperty), @object); doGetProperty(propertyId, value, pspec); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedGetProperty;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='Dispose']/*" />
        public delegate void Dispose();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedDispose(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object);

        /// <summary>
        /// Class for marshalling <see cref="Dispose"/> methods.
        /// </summary>
        public static unsafe class DisposeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedDispose Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedDispose(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var doDispose = (Dispose)methodInfo.CreateDelegate(typeof(Dispose), @object); doDispose(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedDispose;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='Finalize']/*" />
        public delegate void Finalize();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedFinalize(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object);

        /// <summary>
        /// Class for marshalling <see cref="Finalize"/> methods.
        /// </summary>
        public static unsafe class FinalizeMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedFinalize Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedFinalize(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var doFinalize = (Finalize)methodInfo.CreateDelegate(typeof(Finalize), @object); doFinalize(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedFinalize;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='DispatchPropertiesChanged']/*" />
        public delegate void DispatchPropertiesChanged(uint nPspecs, GISharp.Lib.GObject.ParamSpec pspecs);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedDispatchPropertiesChanged(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object,
/* <type name="guint" type="guint" managed-name="System.UInt32" /> */
/* transfer-ownership:none direction:in */
uint nPspecs,
/* <type name="ParamSpec" type="GParamSpec**" managed-name="ParamSpec" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspecs);

        /// <summary>
        /// Class for marshalling <see cref="DispatchPropertiesChanged"/> methods.
        /// </summary>
        public static unsafe class DispatchPropertiesChangedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedDispatchPropertiesChanged Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedDispatchPropertiesChanged(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_, uint nPspecs_, GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspecs_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var nPspecs = (uint)nPspecs_; var pspecs = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspecs_, GISharp.Runtime.Transfer.None)!; var doDispatchPropertiesChanged = (DispatchPropertiesChanged)methodInfo.CreateDelegate(typeof(DispatchPropertiesChanged), @object); doDispatchPropertiesChanged(nPspecs, pspecs); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedDispatchPropertiesChanged;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='Notify']/*" />
        public delegate void Notify(GISharp.Lib.GObject.ParamSpec pspec);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedNotify(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object,
/* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);

        /// <summary>
        /// Class for marshalling <see cref="Notify"/> methods.
        /// </summary>
        public static unsafe class NotifyMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedNotify Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedNotify(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_, GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var pspec = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)pspec_, GISharp.Runtime.Transfer.None)!; var doNotify = (Notify)methodInfo.CreateDelegate(typeof(Notify), @object); doNotify(pspec); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedNotify;
            }
        }

        /// <include file="ObjectClass.xmldoc" path="declaration/member[@name='Constructed']/*" />
        public delegate void Constructed();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedConstructed(
/* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Object.UnmanagedStruct* @object);

        /// <summary>
        /// Class for marshalling <see cref="Constructed"/> methods.
        /// </summary>
        public static unsafe class ConstructedMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedConstructed Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedConstructed(GISharp.Lib.GObject.Object.UnmanagedStruct* @object_) { try { var @object = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)@object_, GISharp.Runtime.Transfer.None)!; var doConstructed = (Constructed)methodInfo.CreateDelegate(typeof(Constructed), @object); doConstructed(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedConstructed;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ObjectClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}