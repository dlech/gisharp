using System;
using System.Runtime.InteropServices;
using GISharp.GLib;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamVariant", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecVariant : ParamSpec
    {
        static readonly IntPtr variantTypeOffset = Marshal.OffsetOf<Struct> (nameof (Struct.VariantType));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public IntPtr VariantType;
            public IntPtr DefaultValue;
            #pragma warning restore CS0649
        }

        public VariantType VariantType {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)variantTypeOffset);
                var ret = Opaque.GetInstance<VariantType> (ret_, Transfer.None);
                return ret;
            }
        }

        public new Variant DefaultValue {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)defaultValueOffset);
                var ret = Opaque.GetInstance<Variant> (ret_, Transfer.None);
                return ret;
            }
        }

        public ParamSpecVariant (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[22];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_variant (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr type,
            IntPtr defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
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
            var defaultValuePtr = defaultValue?.Handle ?? IntPtr.Zero;
            var ret = g_param_spec_variant (namePtr, nickPtr, blurbPtr, type.Handle, defaultValuePtr, flags);
            GC.KeepAlive (type);
            GC.KeepAlive (defaultValue);

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
            : this (New (name, nick, blurb, type, defaultValue, flags), Transfer.None)
        {
        }
    }
}
