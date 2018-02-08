using System;
using System.Runtime.InteropServices;

using GISharp.GLib;
using GISharp.Runtime;

namespace GISharp.GObject
{
    public sealed class ParamSpecPool : Opaque
    {
        public ParamSpecPool (IntPtr handle, Transfer ownership) : base (handle)
        {
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr g_param_spec_pool_new (bool type_prefixing);

        static IntPtr New ()
        {
            return g_param_spec_pool_new (false);
        }

        public ParamSpecPool () : this (New (), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0")]
        static extern void g_param_spec_pool_insert (
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec, // GParamSpec*
            GType owner_type);

        public void Insert (ParamSpec pspec, GType ownerType)
        {
            var this_ = Handle;
            var pspec_ = pspec?.Handle ?? throw new ArgumentNullException(nameof(pspec));
            g_param_spec_pool_insert(this_, pspec_, ownerType);
        }

        [DllImport ("gobject-2.0")]
        static extern void g_param_spec_pool_remove (
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec); // GParamSpec*

        public void Remove (ParamSpec pspec)
        {
            var this_ = Handle;
            var pspec_ = pspec?.Handle ?? throw new ArgumentNullException(nameof(pspec));
            g_param_spec_pool_remove(this_, pspec_);
            GC.KeepAlive (pspec);
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* ParamSpec* */ g_param_spec_pool_lookup (
            IntPtr pool, // GParamSpecPool*
            IntPtr param_name, // const gchar*
            GType owner_type, // GType
            bool walk_ancestors); // gboolean

        public ParamSpec Lookup(Utf8 paramName, GType ownerType, bool walkAncestors)
        {
            var this_ = Handle;
            var paramName_ = paramName?.Handle ?? throw new ArgumentNullException(nameof(paramName));
            var ret_ = g_param_spec_pool_lookup(this_, paramName_, ownerType, walkAncestors);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
            return ret;
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* ParamSpec** */ g_param_spec_pool_list (
            IntPtr pool, // GParamSpecPool*
            GType owner_type, // GType
            out uint n_specs_p); // guint*

        public IArray<ParamSpec> List(GType ownerType)
        {
            var ret_ = g_param_spec_pool_list(Handle, ownerType, out var nSpecsP);
            var ret = CPtrArray.GetInstance<ParamSpec>(ret_, (int)nSpecsP, Transfer.Container);
            return ret;
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* GList* */ g_param_spec_pool_list_owned (
            IntPtr pool, // GParamSpecPool*
            GType owner_type); // GType

        public List<ParamSpec> ListOwned (GType ownerType)
        {
            var retPtr = g_param_spec_pool_list_owned (Handle, ownerType);
            var ret = GetInstance<List<ParamSpec>> (retPtr, Transfer.Container) ?? new List<ParamSpec> ();
            return ret;
        }
    }
}
