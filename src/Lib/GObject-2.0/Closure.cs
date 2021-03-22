// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Closure
    {
        uint BitFields => ((UnmanagedStruct*)UnsafeHandle)->Bits0;

        uint RefCount => BitFields & 0x7FFF;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Closure(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                this.handle = (IntPtr)g_closure_ref((UnmanagedStruct*)handle);
            }
            g_closure_sink((UnmanagedStruct*)this.handle);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Indicates whether the closure is currently being invoked with <see cref="Invoke"/>.
        /// </summary>
        public bool InMarshal {
            get {
                var ret_ = BitFields >> 30;
                var ret = Convert.ToBoolean(ret_ & 0x1);
                return ret;
            }
        }

        /// <summary>
        /// Indicates whether the closure has been invalidated by <see cref="Invalidate"/>.
        /// </summary>
        public bool IsInvalid {
            get {
                var ret_ = BitFields >> 31;
                var ret = Convert.ToBoolean(ret_ & 0x1);
                return ret;
            }
        }

        static readonly int sizeOfStruct = Marshal.SizeOf<UnmanagedStruct>();

        static partial void CheckNewObjectArgs(uint sizeofClosure, Object @object)
        {
            if (sizeofClosure < sizeOfStruct) {
                const string message = "size must be at least as big as Closure.Struct";
                throw new ArgumentOutOfRangeException(nameof(sizeofClosure), message);
            }
        }

        /// <summary>
        /// Invokes the closure, i.e. executes the callback represented by this closure.
        /// </summary>
        /// <param name="paramValues">
        /// an array of #GValues holding the arguments on which to
        /// invoke the callback of this closure
        /// </param>
        /// <returns>The return value of the closure invocation</returns>
        public T Invoke<T>(params object?[] paramValues)
        {
            var this_ = (UnmanagedStruct*)UnsafeHandle;
            if (paramValues is null) {
                throw new ArgumentNullException(nameof(paramValues));
            }

            var returnValue = new Value(typeof(T).ToGType());
            var paramValues_ = stackalloc Value[paramValues.Length];
            for (int i = 0; i < paramValues.Length; i++) {
                var p = paramValues[i];
                if (p is string s) {
                    p = (Utf8)s;
                }
                paramValues_[i].Init(p?.GetGType() ?? throw new NotImplementedException());
                paramValues_[i].Set(p);
            }

            g_closure_invoke(this_, &returnValue, (uint)paramValues.Length, paramValues_, IntPtr.Zero);
            for (int i = 0; i < paramValues.Length; i++) {
                paramValues_[i].Unset();
            }

            var ret = returnValue.Get();
            returnValue.Unset();

            return (T)ret!;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        internal static void ManagedDestroyNotify(IntPtr userData_, UnmanagedStruct* closure_)
        {
            try {
                GCHandle.FromIntPtr(userData_).Free();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedMetaMarshal(UnmanagedStruct* closure_, Value* returnValue_, uint nParamValues_, Value* paramValues_, IntPtr invocationHint, IntPtr marshalData)
        {
            try {
                var nParamValues = (int)nParamValues_;
                var managedParams = new object?[nParamValues];
                for (int i = 0; i < nParamValues; i++) {
                    managedParams[i] = paramValues_[i].Get();
                }
                var callback = (Func<object?[], object?>)GCHandle.FromIntPtr(marshalData).Target!;
                var ret = callback.Invoke(managedParams);
                if (returnValue_ != null) {
                    returnValue_->Set(ret);
                }
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        private static UnmanagedStruct* NewManaged(Func<object?[], object?> callback)
        {
            var sizeofClosure_ = (uint)sizeof(UnmanagedStruct);
            var dataHandle = GCHandle.Alloc(callback);
            var data_ = (IntPtr)dataHandle;
            var closure_ = g_closure_new_simple(sizeofClosure_, data_);
            var notifyFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, UnmanagedStruct*, void>)&ManagedDestroyNotify;
            g_closure_add_finalize_notifier(closure_, data_, notifyFunc_);
            var metaMarshal_ = (delegate* unmanaged[Cdecl]<UnmanagedStruct*, Value*, uint, Value*, IntPtr, IntPtr, void>)&ManagedMetaMarshal;
            g_closure_set_meta_marshal(closure_, data_, metaMarshal_);
            GMarshal.PopUnhandledException();
            return closure_;
        }

        /// <summary>
        /// Creates a new closure.
        /// </summary>
        public Closure(Func<object?[], object?> callback) : this((IntPtr)NewManaged(callback), Transfer.None)
        {
        }
    }
}
