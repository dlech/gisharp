// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="Initable.xmldoc" path="declaration/member[@name='IInitable']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GInitable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(InitableIface))]
    public partial interface IInitable : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <include file="Initable.xmldoc" path="declaration/member[@name='DoInit(GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InitableIface.UnmanagedInit))]
        void DoInit(GISharp.Lib.Gio.Cancellable? cancellable = null);
    }

    /// <summary>
    /// Extension methods for <see cref="IInitable"/>
    /// </summary>
    public static partial class Initable
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_initable_get_type();

        /// <summary>
        /// Helper function for constructing #GInitable object. This is
        /// similar to g_object_newv() but also initializes the object
        /// and returns %NULL, setting an error on failure.
        /// </summary>
        /// <param name="objectType">
        /// a #GType supporting #GInitable.
        /// </param>
        /// <param name="nParameters">
        /// the number of parameters in @parameters
        /// </param>
        /// <param name="parameters">
        /// the parameters to use to construct the object
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated
        ///      #GObject, or %NULL on error
        /// </returns>
        [System.ObsoleteAttribute("Use g_object_new_with_properties() and\ng_initable_init() instead. See #GParameter for more information.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.54")]
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="gpointer" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_initable_newv(
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType objectType,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 nParameters,
        /* <array length="1" zero-terminated="0" type="GParameter*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="GObject.Parameter" type="GParameter" managed-name="GISharp.Lib.GObject.Parameter" />
* </array> */
        /* transfer-ownership:none direction:in */
        in GISharp.Lib.GObject.Parameter parameters,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_initable_get_type();

        /// <summary>
        /// Initializes the object implementing the interface.
        /// </summary>
        /// <remarks>
        /// This method is intended for language bindings. If writing in C,
        /// g_initable_new() should typically be used instead.
        /// 
        /// The object must be initialized before any real use after initial
        /// construction, either with this function or g_async_initable_init_async().
        /// 
        /// Implementations may also support cancellation. If @cancellable is not %NULL,
        /// then initialization can be cancelled by triggering the cancellable object
        /// from another thread. If the operation was cancelled, the error
        /// %G_IO_ERROR_CANCELLED will be returned. If @cancellable is not %NULL and
        /// the object doesn't support cancellable initialization the error
        /// %G_IO_ERROR_NOT_SUPPORTED will be returned.
        /// 
        /// If the object is not initialized, or initialization returns with an
        /// error, then all operations on the object except g_object_ref() and
        /// g_object_unref() are considered to be invalid, and have undefined
        /// behaviour. See the [introduction][ginitable] for more details.
        /// 
        /// Callers should not assume that a class which implements #GInitable can be
        /// initialized multiple times, unless the class explicitly documents itself as
        /// supporting this. Generally, a class’ implementation of init() can assume
        /// (and assert) that it will only be called once. Previously, this documentation
        /// recommended all #GInitable implementations should be idempotent; that
        /// recommendation was relaxed in GLib 2.54.
        /// 
        /// If a class explicitly supports being initialized multiple times, it is
        /// recommended that the method is idempotent: multiple calls with the same
        /// arguments should return the same results. Only the first call initializes
        /// the object; further calls return the result of the first call.
        /// 
        /// One reason why a class might need to support idempotent initialization is if
        /// it is designed to be used via the singleton pattern, with a
        /// #GObjectClass.constructor that sometimes returns an existing instance.
        /// In this pattern, a caller would expect to be able to call g_initable_init()
        /// on the result of g_object_new(), regardless of whether it is in fact a new
        /// instance.
        /// </remarks>
        /// <param name="initable">
        /// a #GInitable.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful. If an error has occurred, this function will
        ///     return %FALSE and set @error appropriately if present.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe GISharp.Runtime.Boolean g_initable_init(
        /* <type name="Initable" type="GInitable*" managed-name="Initable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr initable,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <include file="Initable.xmldoc" path="declaration/member[@name='Init(GISharp.Lib.Gio.IInitable,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe static void Init(this GISharp.Lib.Gio.IInitable initable, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var initable_ = initable.Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_initable_init(initable_, cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }
    }
}