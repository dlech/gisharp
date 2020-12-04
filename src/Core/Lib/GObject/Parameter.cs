using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The GParameter struct is an auxiliary structure used
    /// to hand parameter name/value pairs to g_object_newv().
    /// </summary>
    [DeprecatedSince("2.54")]
    public unsafe struct Parameter
    {
        #pragma warning disable CS0649
        /// <summary>
        /// the parameter name
        /// </summary>
        public IntPtr Name;

        /// <summary>
        /// the parameter value
        /// </summary>
        public Value* Value;
        #pragma warning restore CS0649
    }
}
