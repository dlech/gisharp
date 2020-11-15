using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType("GParamVariant", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecVariant : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecVariant"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// a GVariantType, or NULL
            /// </summary>
            public IntPtr VariantType;

            /// <summary>
            /// a GVariant, or NULL
            /// </summary>
            public IntPtr DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// A <see cref="VariantType" /> or <c>null</c>
        /// </summary>
        public unsafe VariantType? VariantType {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->VariantType;
                var ret = Opaque.GetInstance<VariantType>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// A <see cref="Variant" /> or <c>null</c>
        /// </summary>
        public unsafe new Variant? DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->DefaultValue;
                var ret = Opaque.GetInstance<Variant>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecVariant(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[22];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_variant(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr type,
            IntPtr defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, VariantType type, Variant? defaultValue, ParamFlags flags)
        {
            if (defaultValue is not null && !defaultValue.IsOfType(type)) {
                throw new ArgumentException("default value does not match type", nameof(defaultValue));
            }
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var defaultValuePtr = defaultValue?.Handle ?? IntPtr.Zero;
            var ret = g_param_spec_variant(namePtr, nickPtr, blurbPtr, type.Handle, defaultValuePtr, flags);
            GC.KeepAlive(type);
            GC.KeepAlive(defaultValue);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(namePtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nickPtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurbPtr);
            }

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecVariant" /> instance specifying a
        /// <see cref="Variant" /> property.
        /// </summary>
        /// <param name="name">canonical name of the property specified</param>
        /// <param name="nick">nick name for the property specified</param>
        /// <param name="blurb">description of the property specified</param>
        /// <param name="type">a <see cref="VariantType" /></param>
        /// <param name="defaultValue">a <see cref="Variant" /> of type type to
        /// use as the default value, or <c>null</c></param>
        /// <param name="flags">flags for the property specified</param>
        public ParamSpecVariant(string name, string nick, string blurb, VariantType type, Variant? defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, type, defaultValue, flags), Transfer.None)
        {
        }
    }
}
