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
            AssertNotDisposed ();
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            g_param_spec_pool_insert (Handle, pspec.Handle, ownerType);
            GC.KeepAlive (pspec);
        }

        [DllImport ("gobject-2.0")]
        static extern void g_param_spec_pool_remove (
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec); // GParamSpec*

        public void Remove (ParamSpec pspec)
        {
            AssertNotDisposed ();
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            g_param_spec_pool_remove (Handle, pspec.Handle);
            GC.KeepAlive (pspec);
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* ParamSpec* */ g_param_spec_pool_lookup (
            IntPtr pool, // GParamSpecPool*
            IntPtr param_name, // const gchar*
            GType owner_type, // GType
            bool walk_ancestors); // gboolean

        public ParamSpec Lookup (string paramName, GType ownerType, bool walkAncestors)
        {
            AssertNotDisposed ();
            if (paramName == null) {
                throw new ArgumentNullException (nameof (paramName));
            }
            var paramNamePtr = GMarshal.StringToUtf8Ptr (paramName);
            var retPtr = g_param_spec_pool_lookup (Handle, paramNamePtr, ownerType, walkAncestors);
            GMarshal.Free (paramNamePtr);
            var ret = GetInstance<ParamSpec> (retPtr, Transfer.None);
            return ret;
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* ParamSpec** */ g_param_spec_pool_list (
            IntPtr pool, // GParamSpecPool*
            GType owner_type, // GType
            out uint n_specs_p); // guint*

        public ParamSpec[] List (GType ownerType)
        {
            AssertNotDisposed ();
            var retPtr = g_param_spec_pool_list (Handle, ownerType, out var nSpecsP);
            var ret = GMarshal.PtrToOpaqueCArray<ParamSpec> (retPtr, (int)nSpecsP, true);
            return ret;
        }

        [DllImport ("gobject-2.0")]
        static extern IntPtr /* GList* */ g_param_spec_pool_list_owned (
            IntPtr pool, // GParamSpecPool*
            GType owner_type); // GType

        public List<ParamSpec> ListOwned (GType ownerType)
        {
            AssertNotDisposed ();
            var retPtr = g_param_spec_pool_list_owned (Handle, ownerType);
            var ret = GetInstance<List<ParamSpec>> (retPtr, Transfer.Container) ?? new List<ParamSpec> ();
            return ret;
        }
    }
}
