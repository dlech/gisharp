using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data
    /// for <see cref="GType"/> properties.
    /// </summary>
    [Since ("2.10")]
    [GType ("GParamGType", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecGType : ParamSpec
    {
        static readonly IntPtr isATypeOffset = Marshal.OffsetOf<Struct> (nameof (Struct.IsAType));
        
        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public GType IsAType;
#pragma warning restore CS0649
        }

        public GType IsAType {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<GType> (Handle + (int)isATypeOffset);
                return ret;
            }
        }

        public ParamSpecGType (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static GType getGType ()
        {
            return paramSpecTypes[21];
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_gtype (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType isAType,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, GType isAType, ParamFlags flags)
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
            var ret = g_param_spec_gtype (namePtr, nickPtr, blurbPtr, isAType, flags);

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

        public ParamSpecGType (string name, string nick, string blurb, GType isAType, ParamFlags flags)
            : this (New (name, nick, blurb, isAType, flags), Transfer.None)
        {
        }
    }
}
