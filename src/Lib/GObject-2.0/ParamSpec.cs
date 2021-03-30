// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpec
    {
        private static readonly GType _GType = GType.Param;

        private static readonly Quark managedProxyGCHandleQuark = Quark.FromString("gisharp-gobject-paramspec-managed-proxy-instance-quark");

        /// <summary>
        /// <see cref="ParamFlags"/> flags for this parameter
        /// </summary>
        ParamFlags Flags => ((UnmanagedStruct*)UnsafeHandle)->Flags;

        /// <summary>
        /// The <see cref="Value"/> type for this parameter
        /// </summary>
        public GType ValueType => ((UnmanagedStruct*)UnsafeHandle)->ValueType;

        /// <summary>
        /// <see cref="GType"/> type that uses (introduces) this parameter
        /// </summary>
        GType OwnerType => ((UnmanagedStruct*)UnsafeHandle)->OwnerType;

        uint RefCount => ((UnmanagedStruct*)UnsafeHandle)->RefCount;

        [PtrArrayCopyFunc]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_ref(IntPtr pspec);

        [PtrArrayFreeFunc]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_unref(IntPtr pspec);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpec(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                this.handle = (IntPtr)g_param_spec_ref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            g_param_spec_sink((UnmanagedStruct*)this.handle);
            GMarshal.PopUnhandledException();

            // attach this managed instance to the unmanaged instanace
            var data_ = (IntPtr)GCHandle.Alloc(this, GCHandleType.Weak);
            var destroy_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
            g_param_spec_set_qdata_full((UnmanagedStruct*)this.handle, managedProxyGCHandleQuark, data_, destroy_);
            GMarshal.PopUnhandledException();
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_param_spec_set_qdata((UnmanagedStruct*)handle, managedProxyGCHandleQuark, IntPtr.Zero);
                g_param_spec_unref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            base.Dispose(disposing);
        }

        private protected static readonly GType[] paramSpecTypes;

        static ParamSpec()
        {
            // Have to do some marshalling to get ParamSpec GTypes used by child
            // classes. These types don't have the usual *_get_type() functions.
            var ptr = Marshal.ReadIntPtr(CLibrary.GetSymbol("gobject-2.0", "g_param_spec_types"));
            const int paramSpecTypeCount = 23;
            paramSpecTypes = new GType[paramSpecTypeCount];
            for (int i = 0; i < paramSpecTypeCount; i++) {
                paramSpecTypes[i] = Marshal.PtrToStructure<GType>(ptr + i * sizeof(GType));
            }
        }

        /// <summary>
        /// Gets and sets arbitrary user data associated with this instance.
        /// </summary>
        /// <param name="quark">
        /// a <see cref="Quark"/>, naming the user data
        /// </param>
        public object? this[Quark quark] {
            get {
                var pspec_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_param_spec_get_qdata(pspec_, quark);
                GMarshal.PopUnhandledException();
                if (ret == IntPtr.Zero) {
                    return null;
                }
                var gcHandle = (GCHandle)ret;
                var data = gcHandle.Target;
                return data;
            }
            set {
                var pspec_ = (UnmanagedStruct*)UnsafeHandle;
                if (value is null) {
                    g_param_spec_set_qdata(pspec_, quark, IntPtr.Zero);
                    GMarshal.PopUnhandledException();
                }
                else {
                    var data_ = (IntPtr)GCHandle.Alloc(value);
                    var destroy_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
                    g_param_spec_set_qdata_full(pspec_, quark, data_, destroy_);
                    GMarshal.PopUnhandledException();
                }
            }
        }

        [ModuleInitializer]
        internal static void RegisterTypeResolver()
        {
            RegisterTypeResolver<ParamSpec>(GetInstance);
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <param name="handle">
        /// The pointer to the unmanaged instance
        /// </param>
        /// <param name="ownership">
        /// Indicates if we already have a reference to the unmanged instance
        /// or not.
        /// </param>
        /// <returns>
        /// A managed proxy instance
        /// </returns>
        /// <remarks>
        /// This method tries to get an existing managed proxy instance by
        /// looking for a GC handle attached to the unmanaged instance (using
        /// QData). If one is found, it returns the existing managed instance,
        /// otherwise a new instance is created.
        /// </remarks>
        public static new T? GetInstance<T>(IntPtr handle, Transfer ownership) where T : ParamSpec
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            // see if the unmanaged object has a managed GC handle
            var ptr = g_param_spec_get_qdata((UnmanagedStruct*)handle, managedProxyGCHandleQuark);
            GMarshal.PopUnhandledException();
            if (ptr != IntPtr.Zero) {
                var gcHandle = (GCHandle)ptr;
                if (gcHandle.IsAllocated) {
                    // the GC handle looks good, so we should have the managed
                    // proxy for the unmanged object here
                    var target = (ParamSpec)gcHandle.Target!;
                    // make sure the managed object has not been disposed
                    if (target.handle == handle) {
                        // release the extra reference, if there is one
                        if (ownership != Transfer.None) {
                            g_param_spec_unref((UnmanagedStruct*)handle);
                        }
                        // return the existing managed proxy
                        return (T?)target;
                    }
                }
            }

            // if we get here, that means that there wasn't a viable existing
            // proxy, so we need to create a new managed instance

            // get the exact type of the object
            ptr = Marshal.ReadIntPtr(handle);
            var gtype = Marshal.PtrToStructure<GType>(ptr);
            var type = gtype.ToType();

            return (T)Activator.CreateInstance(type, handle, ownership)!;
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <seealso cref="GetInstance{T}"/>
        public static ParamSpec? GetInstance(IntPtr handle, Transfer ownership)
        {
            return GetInstance<ParamSpec>(handle, ownership);
        }
    }
}
