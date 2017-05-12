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
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

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

            public SafeHandle (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }

            public SafeHandle ()
            {
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        public VariantType VariantType {
            get {
                var ret_ = Handle.VariantType;
                var ret = GetOrCreate<VariantType> (ret_, Transfer.None);
                return ret;
            }
        }

        public new Variant DefaultValue {
            get {
                var ret_ = Handle.DefaultValue;
                var ret = GetOrCreate<Variant> (ret_, Transfer.None);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[22];
        }

        public ParamSpecVariant (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_variant (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            VariantType.SafeHandle type,
            Variant.SafeHandle defaultValue,
            ParamFlags flags);

        static SafeHandle New (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
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
            var defaultValue_ = defaultValue?.Handle ?? Variant.SafeHandle.Zero;
            var ret_ = g_param_spec_variant (namePtr, nickPtr, blurbPtr, type.Handle, defaultValue_, flags);
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

        public ParamSpecVariant (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, type, defaultValue, flags))
        {
        }
    }
}
