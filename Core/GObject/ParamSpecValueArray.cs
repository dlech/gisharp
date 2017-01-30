using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [DeprecatedSince ("2.32")]
    [Obsolete ("Use Array instead of ValueArray")]
    [GType ("GParamValueArray", IsWrappedNativeType = true)]
    sealed class ParamSpecValueArray : ParamSpec
    {
        struct ParamSpecValueArrayStruct
        {
            #pragma warning disable CS0649
            public ParamSpecStruct ParentInstance;
            public IntPtr ElementSpec;
            public uint FixedNElements;
            #pragma warning restore CS0649
        }

        static GType getGType ()
        {
            return paramSpecTypes[18];
        }

        public ParamSpecValueArray (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecValueArray (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
            : this (New (name, nick, blurb, elementSpec, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_value_array (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr elementSpec,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
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
            var pspecPtr = g_param_spec_value_array (namePtr, nickPtr, blurbPtr, elementSpec.Handle, flags);

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

            return pspecPtr;
        }
    }
}
