using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType ("GParamInt64", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecInt64 : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public long Minimum;
            public long Maximum;
            public long DefaultValue;
            #pragma warning restore CS0649
        }

        public long Minimum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadInt64 (Handle, (int)minimumOffset);
                return ret;
            }
        }

        public long Maximum {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadInt64 (Handle, (int)maximumOffset);
                return ret;
            }
        }

        public new long DefaultValue {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadInt64 (Handle, (int)defaultValueOffset);
                return ret;
            }
        }

        public ParamSpecInt64 (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static GType getGType ()
        {
            return paramSpecTypes[7];
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int64 (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            long min,
            long max,
            long defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
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
            var ret = g_param_spec_int64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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

        public ParamSpecInt64 (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
