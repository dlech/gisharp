using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [DeprecatedSince("2.32")]
    [Obsolete("Use Array instead of ValueArray")]
    [GType("GParamValueArray", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecValueArray : ParamSpec
    {
        static readonly IntPtr elementSpecOffset = Marshal.OffsetOf<Struct>(nameof(Struct.ElementSpec));
        static readonly IntPtr fixedNElementsOffset = Marshal.OffsetOf<Struct>(nameof(Struct.FixedNElements));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public IntPtr ElementSpec;
            public uint FixedNElements;
#pragma warning restore CS0649
        }

        /// <summary>
        /// a <see cref="ParamSpec"/> describing the elements contained in arrays
        /// of this property, may be <c>null</c>
        /// </summary>
        public ParamSpec? ElementSpec {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)elementSpecOffset);
                var ret = GetInstance(ret_, Transfer.None)!;
                return ret;
            }
        }

        /// <summary>
        /// if greater than 0, arrays of this property will always have this many elements
        /// </summary>
        public uint FixedNElements => (uint)Marshal.ReadInt32(Handle, (int)fixedNElementsOffset);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecValueArray(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[18];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_value_array(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr elementSpec,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var elementSpecPtr = elementSpec?.Handle ?? IntPtr.Zero;
            var ret = g_param_spec_value_array(namePtr, nickPtr, blurbPtr, elementSpecPtr, flags);
            GC.KeepAlive(elementSpec);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(namePtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nickPtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurbPtr);
            }

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecValueArray" /> instance specifying
        /// a G_TYPE_VALUE_ARRAY property. 
        /// </summary>
        public ParamSpecValueArray(string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
            : this(New(name, nick, blurb, elementSpec, flags), Transfer.None)
        {
        }
    }
}
