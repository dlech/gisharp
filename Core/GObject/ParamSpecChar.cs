using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{

    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamChar", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecChar : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));
        
        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public sbyte Minimum;
            public sbyte Maximum;
            public sbyte DefaultValue;
            #pragma warning restore CS0649
        }

        public sbyte Minimum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadByte (Handle, (int)minimumOffset);
                return (sbyte)ret;
            }
        }

        public sbyte Maximum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadByte (Handle, (int)maximumOffset);
                return (sbyte)ret;
            }
        }

        public new sbyte DefaultValue {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadByte (Handle, (int)defaultValueOffset);
                return (sbyte)ret;
            }
        }

        public ParamSpecChar (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[0];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_char (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            sbyte min,
            sbyte max,
            sbyte defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            if (nick == null) {
                throw new ArgumentNullException (nameof (nick));
            }
            if (blurb == null) {
                throw new ArgumentNullException (nameof (blurb));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_char (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag (ParamFlags.StaticName)) {
                GMarshal.Free (namePtr);
            }
            if (!flags.HasFlag (ParamFlags.StaticNick)) {
                GMarshal.Free (nickPtr);
            }
            if (!flags.HasFlag (ParamFlags.StaticBlurb)) {
                GMarshal.Free (blurbPtr);
            }

            return ret;
        }

        public ParamSpecChar (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
