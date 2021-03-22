// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using GISharp.Runtime;
using GISharp.Lib.GLib;

using culong = GISharp.Runtime.CULong;
using Boolean = GISharp.Runtime.Boolean;

namespace GISharp.Lib.GObject
{
    unsafe partial class Signal
    {
        static readonly Regex signalNameRegex = new("^[a-zA-Z](?:[a-zA-Z0-9_]*|[a-zA-Z0-9-]*)$",
            RegexOptions.CultureInvariant);

        ///<summary>
        /// Tests if a signal name is valid.
        /// </summary>
        /// <remarks>
        /// A signal name consists of segments consisting of ASCII letters and
        /// digits, separated by either the '-' or '_' character. The first
        /// character of a signal name must be a letter. Names which violate
        /// these rules lead to undefined behavior of the GSignal system.
        ///
        /// When registering a signal and looking up a signal, either separator
        /// can be used, but they cannot be mixed.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="name"/> does not meet the criteria
        /// specified in the remarks.
        /// </exception>
        public static void ValidateName(string name)
        {
            if (!signalNameRegex.IsMatch(name)) {
                var msg = "does not meet GSignal name criteria";
                throw new ArgumentException(msg, nameof(name));
            }
        }

        /// <summary>
        /// Adds an emission hook for a signal, which will get called for any emission
        /// of that signal, independent of the instance. This is possible only
        /// for signals which don't have <see cref="SignalFlags.NoHooks"/> flag set.
        /// </summary>
        /// <param name="signalId">
        /// the signal identifier, as returned by <see cref="Lookup{T}"/>.
        /// </param>
        /// <param name="hookFunc">
        /// a <see cref="SignalEmissionHook"/> function.
        /// </param>
        /// <returns>
        /// the hook id, for later use with <see cref="RemoveEmissionHook"/>.
        /// </returns>
        public static culong AddEmissionHook(uint signalId, SignalEmissionHook hookFunc)
        {
            return AddEmissionHook(signalId, default, hookFunc);
        }
        internal static (culong id, CClosureData data, IntPtr data_) ConnectData<T>(this Object instance, UnownedUtf8 detailedSignal,
                    T handler, ConnectFlags connectFlags = default) where T : Delegate
        {
            var instance_ = (Object.UnmanagedStruct*)instance.UnsafeHandle;
            var detailedSignal_ = (byte*)detailedSignal.UnsafeHandle;
            var handler_ = (delegate* unmanaged[Cdecl]<void>)handler.GetCClosureUnmanagedFunctionPointer();
            var data = new CClosureData(handler);
            var dataHandle = GCHandle.Alloc(data);
            var data_ = (IntPtr)dataHandle;
            var notify_ = (delegate* unmanaged[Cdecl]<IntPtr, Closure.UnmanagedStruct*, void>)&Closure.ManagedDestroyNotify;
            var ret = g_signal_connect_data(instance_, detailedSignal_, handler_, data_, notify_, connectFlags);
            if (ret == default) {
                dataHandle.Free();
                data_ = IntPtr.Zero;
            }
            return (ret, data, data_);
        }

        /// <summary>
        /// Connects a #GCallback function to a signal for a particular object. Similar
        /// to g_signal_connect(), but allows to provide a #GClosureNotify for the data
        /// which will be called when the signal handler is disconnected and no longer
        /// used. Specify @connect_flags if you need `..._after()` or
        /// `..._swapped()` variants of this function.
        /// </summary>
        /// <param name="instance">
        /// the instance to connect to.
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="handler">
        /// the #GCallback to connect.
        /// </param>
        /// <param name="connectFlags">
        /// a combination of #GConnectFlags.
        /// </param>
        /// <returns>
        /// the handler id (always greater than 0 for successful connections)
        /// </returns>
        public static culong Connect<T>(this Object instance, UnownedUtf8 detailedSignal,
            T handler, ConnectFlags connectFlags = default) where T : Delegate
        {
            var (ret, _, _) = ConnectData<T>(instance, detailedSignal, handler, connectFlags);
            // TODO: raise exception on failure?
            return ret;
        }

        /// <summary>
        /// Emits a signal.
        /// </summary>
        /// <typeparam name="T">
        /// The return type
        /// </typeparam>
        /// <param name="instance">
        /// the object the signal is being emitted on
        /// </param>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="detail">
        /// the detail
        /// </param>
        /// <param name="parameters">
        /// argument list for the signal emission.
        ///  The arguments to be passed to the signal.
        /// </param>
        public static T Emit<T>(this Object instance, uint signalId, Quark detail = default, params object[] parameters)
        {
            return (T)Emit(typeof(T), instance, signalId, detail, parameters)!;
        }

        /// <summary>
        /// Emits a signal.
        /// </summary>
        /// <param name="instance">
        /// the object the signal is being emitted on
        /// </param>
        /// <param name="signalId">
        /// the signal id
        /// </param>
        /// <param name="detail">
        /// the detail
        /// </param>
        /// <param name="parameters">
        /// argument list for the signal emission.
        ///  The arguments to be passed to the signal.
        /// </param>
        public static void Emit(this Object instance, uint signalId, Quark detail = default, params object[] parameters)
        {
            Emit(typeof(void), instance, signalId, detail, parameters);
        }

        static object? Emit(Type type, Object instance, uint signalId, Quark detail, object[] parameters)
        {
            var query = Query(signalId);
            if (!instance.GetGType().IsA(query.IType)) {
                throw new ArgumentException("Instance type does not match signal type");
            }
            if (query.ParamTypes.Length != parameters.Length) {
                var message = $"Incorrect number of parameters, expecting {query.ParamTypes.Length}, but got {parameters.Length}";
                throw new ArgumentException(message);
            }

            var instanceAndParams = stackalloc Value[parameters.Length + 1];

            instanceAndParams[0].Init(instance);

            for (var i = 0; i < parameters.Length; i++) {
                var paramGType = parameters[i]?.GetGType() ?? query.ParamTypes[i];
                instanceAndParams[i + 1].Init(paramGType);
                instanceAndParams[i + 1].Set(parameters[i]);
            }

            try {
                var ret = default(object);

                if (query.ReturnType == GType.None) {
                    g_signal_emitv(instanceAndParams, signalId, detail, null);
                }
                else {
                    var returnValue = new Value(type.ToGType());
                    g_signal_emitv(instanceAndParams, signalId, detail, &returnValue);
                    ret = returnValue.Get();
                    returnValue.Unset();
                }

                return ret;
            }
            finally {
                for (int i = 0; i < parameters.Length + 1; i++) {
                    instanceAndParams[i].Unset();
                }
            }
        }

        /// <summary>
        /// Given the name of the signal and the type of object it connects to, gets
        /// the signal's identifying integer. Emitting the signal by number is
        /// somewhat faster than using the name each time.
        /// </summary>
        /// <remarks>
        /// Also tries the ancestors of the given type.
        ///
        /// See <see cref="ValidateName"/> for details on allowed signal names.
        /// </remarks>
        /// <typeparam name="T">
        /// the type that the signal operates on.
        /// </typeparam>
        /// <param name="name">
        /// the signal's name.
        /// </param>
        /// <returns>
        /// the signal's identifying number, or 0 if no signal was found.
        /// </returns>
        public static uint Lookup<T>(UnownedUtf8 name)
        {
            return Lookup(name, typeof(T).ToGType());
        }

        internal static uint Newv(UnownedUtf8 signalName, GType itype, SignalFlags signalFlags, Closure? classClosure,
            SignalAccumulator? accumulator, SignalCMarshaller? cMarshaller, GType returnType, ReadOnlySpan<GType> paramTypes)
        {
            var signalName_ = (byte*)signalName.UnsafeHandle;
            var classClosure_ = (Closure.UnmanagedStruct*)(classClosure?.UnsafeHandle ?? IntPtr.Zero);
            var accumulator_ = accumulator is null ? default(delegate* unmanaged[Cdecl]<SignalInvocationHint*, Value*, Value*, IntPtr, Boolean>)
                : throw new NotImplementedException("need to implement UnmanagedSignalAccumulator factory");
            var accuData_ = IntPtr.Zero;
            var cMarshaller_ = cMarshaller is null ? default(delegate* unmanaged[Cdecl]<Closure.UnmanagedStruct*, Value*, uint, Value*, IntPtr, IntPtr, void>)
                : throw new NotImplementedException("need to implement UnmangagedSignalCMarshaller factory");
            var nParams_ = (uint)paramTypes.Length;
            fixed (GType* paramTypes_ = paramTypes) {
                var ret = g_signal_newv(signalName_, itype, signalFlags, classClosure_, accumulator_,
                    accuData_, cMarshaller_, returnType, nParams_, paramTypes_);

                return ret;
            }
        }

        /// <summary>
        /// Internal function to parse a signal name into its signal id
        /// and detail quark.
        /// </summary>
        /// <param name="detailedSignal">
        /// a string of the form "signal-name::detail".
        /// </param>
        /// <param name="itype">
        /// The interface/instance type that introduced "signal-name".
        /// </param>
        /// <param name="forceDetailQuark">
        /// <c>true</c> forces creation of a <see cref="Quark"/> for the detail.
        /// </param>
        /// <returns>
        /// A tuple containing the signal id and detail quark.
        /// </returns>
        public static (uint, Quark) ParseName(UnownedUtf8 detailedSignal, GType itype, bool forceDetailQuark = false)
        {
            if (TryParseName(detailedSignal, itype, out var signalId, out var detail, forceDetailQuark)) {
                return (signalId, detail);
            }
            throw new ArgumentException("matching signal could not be found");
        }

        /// <summary>
        /// Queries the signal system for in-depth information about a
        /// specific signal.
        /// </summary>
        /// <param name="signalId">
        /// The signal id of the signal to query information for.
        /// </param>
        /// <returns>
        /// A structure with signal-specific information.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw if and invalid signal id is passed in.
        /// </exception>
        public static SignalQuery Query(uint signalId)
        {
            Query(signalId, out var query);
            if (query.SignalId == 0) {
                throw new ArgumentOutOfRangeException(nameof(signalId));
            }
            return query;
        }

        /// <summary>
        /// Finds the first signal handler that matches certain selection criteria.
        /// The non-null criteria are passed in an OR-ed combination.
        /// If no handler was found, 0 is returned.
        /// </summary>
        /// <param name="instance">
        /// The instance owning the signal handler to be found.
        /// </param>
        /// <param name="signalId">
        /// Signal the handler has to be connected to.
        /// </param>
        /// <param name="detail">
        /// Signal detail the handler has to be connected to.
        /// </param>
        /// <param name="closure">
        /// The closure the handler will invoke.
        /// </param>
        /// <param name="func">
        /// The C closure callback of the handler (useless for non-C closures).
        /// </param>
        /// <param name="data">
        /// The closure data of the handler's closure.
        /// </param>
        /// <param name="unblocked">
        /// Only unblocked signals will be matched.
        /// </param>
        /// <returns>
        /// A valid non-0 signal handler id for a successful match.
        /// </returns>
        public static culong HandlerFind(Object instance, uint? signalId = default,
            Quark? detail = default, Closure? closure = default, IntPtr? func = default,
            IntPtr? data = default, bool unblocked = default)
        {
            var instance_ = (Object.UnmanagedStruct*)instance.UnsafeHandle;
            var mask_ = default(SignalMatchType);
            var signalId_ = default(uint);
            if (signalId.HasValue) {
                signalId_ = signalId.Value;
                mask_ |= SignalMatchType.Id;
            }
            var detail_ = default(Quark);
            if (detail.HasValue) {
                detail_ = detail.Value;
                mask_ |= SignalMatchType.Detail;
            }
            var closure_ = default(Closure.UnmanagedStruct*);
            if (closure is not null) {
                closure_ = (Closure.UnmanagedStruct*)closure.UnsafeHandle;
                mask_ |= SignalMatchType.Closure;
            }
            var func_ = default(IntPtr);
            if (func.HasValue) {
                func_ = func.Value;
                mask_ |= SignalMatchType.Func;
            }
            var data_ = default(IntPtr);
            if (data.HasValue) {
                data_ = data.Value;
                mask_ |= SignalMatchType.Data;
            }
            if (unblocked) {
                mask_ |= SignalMatchType.Unblocked;
            }
            var ret = g_signal_handler_find(instance_, mask_, signalId_, detail_, closure_, func_, data_);
            return ret;
        }
    }
}
