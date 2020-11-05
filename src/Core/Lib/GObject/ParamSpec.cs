using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GModule;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// <see cref="ParamSpec"/> is an object structure that encapsulates the metadata
    /// required to specify parameters, such as e.g. <see cref="Object"/> properties.
    /// </summary>
    /// <remarks>
    /// Parameter names need to start with a letter (a-z or A-Z).
    /// Subsequent characters can be letters, numbers or a '-'.
    /// All other characters are replaced by a '-' during construction.
    /// The result of this replacement is called the canonical name of
    /// the parameter.
    /// </remarks>
    [GType("GParam", IsProxyForUnmanagedType = true)]
    public class ParamSpec : TypeInstance
    {
        static readonly Quark managedProxyGCHandleQuark = Quark.FromString("gisharp-gobject-paramspec-managed-proxy-instance-quark");

        static readonly IntPtr flagsOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Flags));
        static readonly IntPtr valueTypeOffset = Marshal.OffsetOf<Struct>(nameof(Struct.ValueType));
        static readonly IntPtr ownerTypeOffset = Marshal.OffsetOf<Struct>(nameof(Struct.OwnerType));
        static readonly IntPtr refCountOffset = Marshal.OffsetOf<Struct>(nameof(Struct.RefCount));

        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        protected new struct Struct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private GTypeInstance portion
            /// </summary>
            public TypeInstance.Struct GTypeInstance;

            /// <summary>
            /// name of this parameter: always an interned string
            /// </summary>
            public IntPtr Name;

            /// <summary>
            /// GParamFlags flags for this parameter
            /// </summary>
            public ParamFlags Flags;

            /// <summary>
            /// the GValue type for this parameter
            /// </summary>
            public GType ValueType;

            /// <summary>
            /// GType type that uses (introduces) this parameter
            /// </summary>
            public GType OwnerType;

#pragma warning disable CS0169
            IntPtr name;
            IntPtr blurb;
            IntPtr qdata;
            internal uint RefCount;
            uint paramId;
#pragma warning restore CS0169
#pragma warning disable CS0649
        }

        /// <summary>
        /// <see cref="ParamFlags"/> flags for this parameter
        /// </summary>
        ParamFlags Flags => (ParamFlags)Marshal.ReadInt32(handle, (int)flagsOffset);

        /// <summary>
        /// The <see cref="Value"/> type for this parameter
        /// </summary>
        public GType ValueType => Marshal.PtrToStructure<GType>(handle + (int)valueTypeOffset);

        /// <summary>
        /// <see cref="GType"/> type that uses (introduces) this parameter
        /// </summary>
        GType OwnerType => Marshal.PtrToStructure<GType>(handle + (int)ownerTypeOffset);

        uint RefCount => Marshal.PtrToStructure<uint>(handle + (int)refCountOffset);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpec(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                this.handle = g_param_spec_ref(handle);
            }
            g_param_spec_sink(this.handle);

            // attach this managed instance to the unmanaged instanace
            var data = (IntPtr)GCHandle.Alloc(this, GCHandleType.Weak);
            g_param_spec_set_qdata_full(this.handle, managedProxyGCHandleQuark, data, freeQDataDelegate);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_param_spec_set_qdata(handle, managedProxyGCHandleQuark, IntPtr.Zero);
                g_param_spec_unref(handle);
            }
            base.Dispose(disposing);
        }

        [PtrArrayCopyFunc]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_ref(IntPtr pspec);

        /// <inheritdoc />
        public override IntPtr Take() => g_param_spec_ref(Handle);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_sink(IntPtr pspec);

        [PtrArrayFreeFunc]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_unref(IntPtr pspec);

        private protected static GType[] paramSpecTypes;

        static ParamSpec()
        {
            // Have to do some marshalling to get ParamSpec GTypes used by child
            // classes. These types don't have the usual *_get_type() functions.
            using (var lib = Module.Open(Module.BuildPath(null, "gobject-2.0", true), ModuleFlags.BindLazy)) {
                var ptr = Marshal.ReadIntPtr(lib.GetSymbol("g_param_spec_types"));
                const int paramSpecTypeCount = 23;
                paramSpecTypes = new GType[paramSpecTypeCount];
                for (int i = 0; i < paramSpecTypeCount; i++) {
                    paramSpecTypes[i] = Marshal.PtrToStructure<GType>(ptr + i * Marshal.SizeOf<GType>());
                }
            }
        }

        /// <summary>
        /// Get the short description of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the short description of @pspec.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_blurb(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the short description of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the short description of this instance.
        /// </returns>
        public UnownedUtf8 Blurb {
            get {
                var ret_ = g_param_spec_get_blurb(Handle);
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// Gets the default value of @pspec as a pointer to a #GValue.
        /// </summary>
        /// <remarks>
        /// #GValue will remain value for the life of this ParamSpec.
        /// </remarks>
        /// <returns>
        /// a pointer to a #GValue which must not be modified
        /// </returns>
        [Since("2.38")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        static extern ref Value g_param_spec_get_default_value(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr param);

        /// <summary>
        /// Gets the default value of this instance.
        /// </summary>
        /// <remarks>
        /// The <see cref="Value"/> will remain value for the life of this instance.
        /// </remarks>
        [Since("2.38")]
        public Value DefaultValue {
            get {
                var ret = g_param_spec_get_default_value(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Get the name of a #GParamSpec.
        /// </summary>
        /// <remarks>
        /// The name is always an "interned" string (as per g_intern_string()).
        /// This allows for pointer-value comparisons.
        /// </remarks>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the name of @pspec.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_name(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the name of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the name of this instance.
        /// </returns>
        public UnownedUtf8 Name {
            get {
                var ret_ = g_param_spec_get_name(Handle);
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// Gets the GQuark for the name.
        /// </summary>
        /// <param name="param">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// the GQuark for @pspec-&gt;name.
        /// </returns>
        [Since("2.46")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_param_spec_get_name_quark(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr param);

        /// <summary>
        /// Gets the <see cref="Quark"/> for the name.
        /// </summary>
        /// <returns>
        /// the <see cref="Quark"/> for <see cref="Name"/>.
        /// </returns>
        [Since("2.46")]
        public Quark NameQuark {
            get {
                var ret = g_param_spec_get_name_quark(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Get the nickname of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the nickname of @pspec.
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_nick(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the nickname of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the nickname of this instance.
        /// </returns>
        public UnownedUtf8 Nick {
            get {
                var ret_ = g_param_spec_get_nick(Handle);
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata().
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_qdata(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type #GParamSpecOverride. See g_object_class_override_property()
        /// for an example of the use of this capability.
        /// </summary>
        /// <param name="pspec">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// paramspec to which requests on this
        ///          paramspec should be redirected, or %NULL if none.
        /// </returns>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_redirect_target(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type <see cref="ParamSpecOverride"/>.
        /// </summary>
        /// <returns>
        /// paramspec to which requests on this
        /// paramspec should be redirected, or <c>null</c> if none.
        /// </returns>
        [Since("2.4")]
        public ParamSpec? RedirectTarget {
            get {
                var ret_ = g_param_spec_get_redirect_target(Handle);
                var ret = GetInstance(ret_, Transfer.None);
                return ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_set_qdata(
            IntPtr pspec,
            Quark quark,
            IntPtr data);

        /// <summary>
        /// This function works like g_param_spec_set_qdata(), but in addition,
        /// a `void (*destroy) (gpointer)` function may be
        /// specified which is called with @data as argument when the @pspec is
        /// finalized, or the data is being overwritten by a call to
        /// g_param_spec_set_qdata() with the same @quark.
        /// </summary>
        /// <param name="pspec">
        /// the #GParamSpec to set store a user data pointer
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <param name="data">
        /// an opaque user data pointer
        /// </param>
        /// <param name="destroy">
        /// function to invoke with @data as argument, when @data needs to
        ///  be freed
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_param_spec_set_qdata_full(
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data,
            /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GLib.DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify destroy);

        /// <summary>
        /// Gets and sets arbitrary user data associated with this instance.
        /// </summary>
        /// <param name="quark">
        /// a <see cref="Quark"/>, naming the user data
        /// </param>
        public object? this[Quark quark] {
            get {
                var ret = g_param_spec_get_qdata(Handle, quark);
                if (ret == IntPtr.Zero) {
                    return null;
                }
                var gcHandle = (GCHandle)ret;
                var data = gcHandle.Target;
                return data;
            }
            set {
                var this_ = Handle;
                if (value is null) {
                    g_param_spec_set_qdata(this_, quark, IntPtr.Zero);
                }
                else {
                    var data_ = (IntPtr)GCHandle.Alloc(value);
                    g_param_spec_set_qdata_full(this_, quark, data_, freeQDataDelegate);
                }
            }
        }

        static UnmanagedDestroyNotify freeQDataDelegate = FreeQData;

        static void FreeQData(IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <param name="handle">
        /// The pointer to the unmanaged instance
        /// </param>
        /// <param name="ownership">
        /// Indicates if we already have a reference to the unmanged instance
        /// or not.
        /// </param>
        /// <returns>
        /// A managed proxy instance
        /// </returns>
        /// <remarks>
        /// This method tries to get an existing managed proxy instance by
        /// looking for a GC handle attached to the unmanaged instance (using
        /// QData). If one is found, it returns the existing managed instance,
        /// otherwise a new instance is created.
        /// </remarks>
        public static new T? GetInstance<T>(IntPtr handle, Transfer ownership) where T : ParamSpec
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            // see if the unmanaged object has a managed GC handle
            var ptr = g_param_spec_get_qdata(handle, managedProxyGCHandleQuark);
            if (ptr != IntPtr.Zero) {
                var gcHandle = (GCHandle)ptr;
                if (gcHandle.IsAllocated) {
                    // the GC handle looks good, so we should have the managed
                    // proxy for the unmanged object here
                    var target = (ParamSpec)gcHandle.Target;
                    // make sure the managed object has not been disposed
                    if (target?.handle == handle) {
                        // release the extra reference, if there is one
                        if (ownership != Transfer.None) {
                            g_param_spec_unref(handle);
                        }
                        // return the existing managed proxy
                        return (T?)target;
                    }
                }
            }

            // if we get here, that means that there wasn't a viable existing
            // proxy, so we need to create a new managed instance

            // get the exact type of the object
            ptr = Marshal.ReadIntPtr(handle);
            var gtype = Marshal.PtrToStructure<GType>(ptr);
            var type = gtype.ToType();

            return (T)Activator.CreateInstance(type, handle, ownership);
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <seealso cref="GetInstance{T}"/>
        public static ParamSpec? GetInstance(IntPtr handle, Transfer ownership)
        {
            return GetInstance<ParamSpec>(handle, ownership);
        }
    }
}
