using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using GISharp.Lib.GLib;
using GISharp.Runtime;
using Boolean = GISharp.Runtime.Boolean;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpecPool"/> maintains a collection of <see cref="ParamSpec"/>s
    /// which can be quickly accessed by owner and name.
    /// </summary>
    /// <remarks>
    /// The implementation of the
    /// <see cref="Object"/> property system uses such a pool to store the
    /// <see cref="ParamSpec"/>s of the properties all object types.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    [Obsolete("GParamSpecPool is deprecated and should not be used in newly-written code.")]
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
            Boolean type_prefixing);

        static IntPtr New()
        {
            return g_param_spec_pool_new(Boolean.False);
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecPool"/>.
        /// </summary>
        public ParamSpecPool() : this(New(), Transfer.Full)
        {
        }

        [DllImport("gobject-2.0")]
        static extern void g_param_spec_pool_insert(
            IntPtr pool, // GParamSpecPool*
            IntPtr pspec, // GParamSpec*
            GType owner_type);

        /// <summary>
        /// Inserts a <see cref="ParamSpec"/> in the pool.
        /// </summary>
        /// <param name="pspec">
        /// the <see cref="ParamSpec"/> to insert
        /// </param>
        /// <param name="ownerType">
        /// a <see cref="GType"/> identifying the owner of <paramref name="pspec"/>
        /// </param>
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

        /// <summary>
        /// Removes a <see cref="ParamSpec"/> from the pool.
        /// </summary>
        /// <param name="pspec">
        /// the <see cref="ParamSpec"/> to remove
        /// </param>
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
            Boolean walk_ancestors); // gboolean

        /// <summary>
        /// Looks up a <see cref="ParamSpec"/> in the pool.
        /// </summary>
        /// <param name="paramName">
        /// the name to look for
        /// </param>
        /// <param name="ownerType">
        /// the owner to look for
        /// </param>
        /// <param name="walkAncestors">
        /// If <c>true</c>, also try to find a <see cref="ParamSpec"/> with
        /// <paramref name="paramName"/> owned by an ancestor of
        /// <paramref name="ownerType"/>.
        /// </param>
        /// <returns>
        /// The found <see cref="ParamSpec"/>, or <c>null</c> if no matching
        /// <see cref="ParamSpec"/> was found.
        /// </returns>
        public ParamSpec? TryLookup(UnownedUtf8 paramName, GType ownerType, bool walkAncestors)
        {
            var this_ = Handle;
            var paramName_ = paramName.Handle;
            var walkAncestors_ = walkAncestors.ToBoolean();
            var ret_ = g_param_spec_pool_lookup(this_, paramName_, ownerType, walkAncestors_);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
            return ret;
        }

        [DllImport("gobject-2.0")]
        static extern IntPtr /* GList* */ g_param_spec_pool_list_owned(
            IntPtr pool, // GParamSpecPool*
            GType owner_type); // GType

        /// <summary>
        /// Gets a <see cref="List{T}"/> of all <see cref="ParamSpec"/>s
        /// owned by <paramref name="ownerType"/> in the pool.
        /// </summary>
        /// <param name="ownerType">
        /// the owner to look for
        /// </param>
        /// <returns>
        /// a <see cref="List{T}"/> of all <see cref="ParamSpec"/>s
        /// owned by <paramref name="ownerType"/> in the pool.
        /// </returns>
        public List<ParamSpec> List(GType ownerType)
        {
            var ret_ = g_param_spec_pool_list_owned(Handle, ownerType);
            var ret = GetInstance<List<ParamSpec>>(ret_, Transfer.Container);
            return ret;
        }
    }
}
