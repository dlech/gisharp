using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    [ExcludeFromCodeCoverage]
    public sealed class ParamSpecPool : Opaque
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecPool(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        [DllImport("gobject-2.0")]
        static extern IntPtr g_param_spec_pool_new(
            Runtime.Boolean type_prefixing);

        static IntPtr New()
        {
            return g_param_spec_pool_new(Runtime.Boolean.False);
        }

        public ParamSpecPool() : this(New(), Transfer.Full)
        {
        }

        [DllImport("gobject-2.0")]
        static extern void g_param_spec_pool_insert(
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec, // GParamSpec*
            GType owner_type);

        public void Insert(ParamSpec pspec, GType ownerType)
        {
            var this_ = Handle;
            var pspec_ = pspec.Handle;
            g_param_spec_pool_insert(this_, pspec_, ownerType);
        }

        [DllImport("gobject-2.0")]
        static extern void g_param_spec_pool_remove(
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec); // GParamSpec*

        public void Remove(ParamSpec pspec)
        {
            var this_ = Handle;
            var pspec_ = pspec.Handle;
            g_param_spec_pool_remove(this_, pspec_);
            GC.KeepAlive(pspec);
        }

        [DllImport("gobject-2.0")]
        static extern IntPtr /* ParamSpec* */ g_param_spec_pool_lookup(
            IntPtr pool, // GParamSpecPool*
            IntPtr param_name, // const gchar*
            GType owner_type, // GType
            bool walk_ancestors); // gboolean

        public ParamSpec? Lookup(UnownedUtf8 paramName, GType ownerType, bool walkAncestors)
        {
            var this_ = Handle;
            var paramName_ = paramName.Handle;
            var ret_ = g_param_spec_pool_lookup(this_, paramName_, ownerType, walkAncestors);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
            return ret;
        }

        [DllImport("gobject-2.0")]
        static extern IntPtr /* ParamSpec** */ g_param_spec_pool_list(
            IntPtr pool, // GParamSpecPool*
            GType owner_type, // GType
            out uint n_specs_p); // guint*

        public CPtrArray<ParamSpec> List(GType ownerType)
        {
            var ret_ = g_param_spec_pool_list(Handle, ownerType, out var nSpecsP);
            var ret = CPtrArray.GetInstance<ParamSpec>(ret_, (int)nSpecsP, Transfer.Container);
            return ret;
        }

        [DllImport("gobject-2.0")]
        static extern IntPtr /* GList* */ g_param_spec_pool_list_owned(
            IntPtr pool, // GParamSpecPool*
            GType owner_type); // GType

        public List<ParamSpec> ListOwned(GType ownerType)
        {
            var retPtr = g_param_spec_pool_list_owned(Handle, ownerType);
            var ret = GetInstance<List<ParamSpec>>(retPtr, Transfer.Container) ?? new List<ParamSpec>();
            return ret;
        }
    }
}
