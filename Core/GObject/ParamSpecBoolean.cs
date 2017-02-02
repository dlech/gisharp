using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for boolean properties.
    /// </summary>
    [GType ("GParamBoolean", IsWrappedNativeType = true)]
    public sealed class ParamSpecBoolean : ParamSpec
    {
        public sealed class SafeParamSpecBooleanHandle : SafeParamSpecHandle
        {
            struct ParamSpecBoolean
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public bool DefaultValue;
                #pragma warning restore CS0649
            }
            
            public bool DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecBoolean> (nameof (ParamSpecBoolean.DefaultValue));
                    var ret = Marshal.PtrToStructure<bool> (handle + (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecBooleanHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecBooleanHandle Handle {
            get {
                return (SafeParamSpecBooleanHandle)base.Handle;
            }
        }

        public new bool DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[2];
        }

        public ParamSpecBoolean (SafeParamSpecBooleanHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boolean (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            bool defaultValue,
            ParamFlags flags);

        static SafeParamSpecBooleanHandle New (string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_boolean (namePtr, nickPtr, blurbPtr, defaultValue, flags);
            var ret = new SafeParamSpecBooleanHandle (ret_, Transfer.Full);

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

        public ParamSpecBoolean (string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags))
        {
        }
    }
}
