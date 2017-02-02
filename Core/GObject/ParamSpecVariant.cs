using System;
using System.Runtime.InteropServices;
using GISharp.GLib;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamVariant", IsWrappedNativeType = true)]
    public sealed class ParamSpecVariant : ParamSpec
    {
        public sealed class SafeParamSpecVariantHandle : SafeParamSpecHandle
        {
            struct ParamSpecVariant
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public IntPtr VariantType;
                public IntPtr DefaultValue;
                #pragma warning restore CS0649
            }

            public IntPtr VariantType {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecVariant> (nameof (ParamSpecVariant.VariantType));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public IntPtr DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecVariant> (nameof (ParamSpecVariant.DefaultValue));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecVariantHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecVariantHandle Handle {
            get {
                return (SafeParamSpecVariantHandle)base.Handle;
            }
        }

        public VariantType VariantType {
            get {
                var ret_ = Handle.VariantType;
                var ret = GetInstance<VariantType> (ret_, Transfer.None);
                return ret;
            }
        }

        public new Variant DefaultValue {
            get {
                var ret_ = Handle.DefaultValue;
                var ret = GetInstance<Variant> (ret_, Transfer.None);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[22];
        }

        public ParamSpecVariant (SafeParamSpecVariantHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_variant (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            VariantType.SafeVariantTypeHandle  type,
            Variant.SafeVariantHandle defaultValue,
            ParamFlags flags);

        static SafeParamSpecVariantHandle New (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
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
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            if (defaultValue != null && !defaultValue.IsOfType (type)) {
                throw new ArgumentException ("default value does not match type", nameof (defaultValue));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret_ = g_param_spec_variant (namePtr, nickPtr, blurbPtr, type.Handle, defaultValue?.Handle, flags);
            var ret = new SafeParamSpecVariantHandle (ret_, Transfer.Full);

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

        public ParamSpecVariant (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, type, defaultValue, flags))
        {
        }
    }
}
