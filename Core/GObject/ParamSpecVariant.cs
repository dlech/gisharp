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
    sealed class ParamSpecVariant : ParamSpec
    {
        struct ParamSpecVariantStruct
        {
            public ParamSpecStruct ParentInstance;
            public IntPtr VariantType;
            public IntPtr DefaultValue;
        }

        public VariantType VariantType {
            get {
                var offset = Marshal.OffsetOf<ParamSpecVariantStruct> (nameof (ParamSpecVariantStruct.VariantType));
                var ret_ = Marshal.ReadIntPtr (Handle, (int)offset);
                var ret = GetInstance<VariantType> (ret_, Transfer.None);
                return ret;
            }
        }

        public new Variant DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecVariantStruct> (nameof (ParamSpecVariantStruct.DefaultValue));
                var ret_ = Marshal.ReadIntPtr (Handle, (int)offset);
                var ret = GetInstance<Variant> (ret_, Transfer.None);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[22];
        }

        public ParamSpecVariant (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecVariant (string name, string nick, string blurb, VariantType type, Variant defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, type, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_variant (IntPtr name,
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
            var defaultValuePtr = defaultValue == null ? IntPtr.Zero : defaultValue.Handle;
            var pspecPtr = g_param_spec_variant (namePtr, nickPtr, blurbPtr, type.Handle, defaultValuePtr, flags);

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
