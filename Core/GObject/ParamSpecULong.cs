using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamULong", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecULong : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public nulong Minimum;
            public nulong Maximum;
            public nulong DefaultValue;
            #pragma warning restore CS0649
        }

        public nulong Minimum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)minimumOffset);
                return ret;
            }
        }

        public nulong Maximum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)maximumOffset);
                return ret;
            }
        }

        public new nulong DefaultValue {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)defaultValueOffset);
                return ret;
            }
        }

        public ParamSpecULong (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static GType getGType ()
        {
            return paramSpecTypes[6];
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_ulong (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nulong min,
            nulong max,
            nulong defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
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
            var ret = g_param_spec_ulong (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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

        public ParamSpecULong (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
