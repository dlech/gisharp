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
    public sealed class ParamSpecValueArray : ParamSpec
    {
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            struct ParamSpecValueArray
            {
#pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public IntPtr ElementSpec;
                public uint FixedNElements;
#pragma warning restore CS0649
            }

            public IntPtr ElementSpec {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecValueArray> (nameof (ParamSpecValueArray.ElementSpec));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public uint FixedNElements {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecValueArray> (nameof (ParamSpecValueArray.FixedNElements));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public SafeHandle (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }

            public SafeHandle ()
            {
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        static GType getGType ()
        {
            return paramSpecTypes[18];
        }

        public ParamSpecValueArray (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_value_array (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ParamSpec.SafeHandle elementSpec,
            ParamFlags flags);

        static SafeHandle New (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
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
            var ret_ = g_param_spec_value_array (namePtr, nickPtr, blurbPtr, elementSpec.Handle, flags);
            var ret = new SafeHandle (ret_, Transfer.None);

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

        public ParamSpecValueArray (string name, string nick, string blurb, ParamSpec elementSpec, ParamFlags flags)
            : this (New (name, nick, blurb, elementSpec, flags))
        {
        }
    }
}
