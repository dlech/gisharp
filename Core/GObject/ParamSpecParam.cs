using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for <see cref="ParamSpec"/>
    /// properties.
    /// </summary>
    [GType ("GParamParam", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecParam : ParamSpec
    {
        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct parentInstance;
            #pragma warning restore CS0649
        }

        public ParamSpecParam (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static GType getGType ()
        {
            return paramSpecTypes[15];
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_param (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType paramType,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, GType paramType, ParamFlags flags)
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
            if (!paramType.IsA (GType.Param)) {
                throw new ArgumentException ("Expecting param type.", nameof (paramType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_param (namePtr, nickPtr, blurbPtr, paramType, flags);

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

        public ParamSpecParam (string name, string nick, string blurb, GType paramType, ParamFlags flags)
            : this (New (name, nick, blurb, paramType, flags), Transfer.None)
        {
        }
    }
}
