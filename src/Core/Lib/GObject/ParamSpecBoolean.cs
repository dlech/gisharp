using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for boolean properties.
    /// </summary>
    [GType("GParamBoolean", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecBoolean : ParamSpec
    {
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct>(nameof(Struct.DefaultValue));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public bool DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new bool DefaultValue => Marshal.PtrToStructure<bool>(Handle + (int)defaultValueOffset);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecBoolean(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[2];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boolean(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            Runtime.Boolean defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_boolean(namePtr, nickPtr, blurbPtr, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecBoolean"/> instance specifying a
        /// <see cref="GType.Boolean"/> property.
        /// </summary>
        /// <remarks>
        /// In many cases, it may be more appropriate to use an enum with
        /// <see cref="ParamSpecEnum"/>, both to improve code clarity by using
        /// explicitly named values, and to allow for more values to be added 
        /// in future without breaking API.
        /// </remarks>
        public ParamSpecBoolean(string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, defaultValue, flags), Transfer.None)
        {
        }
    }
}