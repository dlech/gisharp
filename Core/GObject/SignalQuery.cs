using System;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A structure holding in-depth information for a specific signal.
    /// </summary>
    public struct SignalQuery
    {
        uint signalId;
        IntPtr signalName;
        GType itype;
        SignalFlags signalFlags;
        GType returnType;
        uint nParams;
        IntPtr paramTypes;

        /// <summary>
        /// The signal id of the signal being queried.
        /// </summary>
        public uint SignalId => signalId;

        /// <summary>
        /// The signal name.
        /// </summary>
        public string SignalName => GMarshal.Utf8PtrToString (signalName);

        /// <summary>
        /// The interface/instance type that this signal can be emitted for.
        /// </summary>
        public GType IType => itype;

        /// <summary>
        /// The signal flags as passed in to g_signal_new().
        /// </summary>
        public SignalFlags SignalFlags => signalFlags;

        /// <summary>
        /// The signal flags as passed in to g_signal_new().
        /// </summary>
        public GType ReturnType => returnType;

        /// <summary>
        /// The individual parameter types for user callbacks.
        /// </summary>
        /// <remarks>
        /// note that the effective callback signature is:
        /// <code>
        /// ReturnType callback (IntPtr data1, [ParamTypes paramNames,] IntPtr data2);
        /// </code>
        /// </remarks>
        public IArray<GType> ParamTypes => CArray.GetInstance<GType>(paramTypes, (int)nParams, Transfer.None);
    }
}