// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="IInitable"/> is implemented by objects that can fail during
    /// initialization. If an object implements this interface then
    /// it must be initialized as the first thing after construction,
    /// either via <see cref="Initable.Init"/> or <see cref="AsyncInitable.InitAsync"/>
    /// (the latter is only available if it also implements <see cref="IAsyncInitable"/>).
    /// </summary>
    /// <remarks>
    /// If the object is not initialized, or initialization returns with an
    /// error, then all operations on the object except g_object_ref() and
    /// g_object_unref() are considered to be invalid, and have undefined
    /// behaviour. They will often fail with g_critical() or g_warning(), but
    /// this must not be relied on.
    /// 
    /// Users of objects implementing this are not intended to use
    /// the interface method directly, instead it will be used automatically
    /// in various ways. For C applications you generally just call
    /// g_initable_new() directly, or indirectly via a foo_thing_new() wrapper.
    /// This will call <see cref="Initable.Init"/> under the cover, returning <c>null</c> and
    /// setting a #GError on failure (at which point the instance is
    /// unreferenced).
    /// 
    /// For bindings in languages where the native constructor supports
    /// exceptions the binding could check for objects implemention %GInitable
    /// during normal construction and automatically initialize them, throwing
    /// an exception on failure.
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GInitable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(InitableIface))]
    public partial interface IInitable : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Initializes the object implementing the interface.
        /// </summary>
        /// <remarks>
        /// This method is intended for language bindings. If writing in C,
        /// g_initable_new() should typically be used instead.
        /// 
        /// The object must be initialized before any real use after initial
        /// construction, either with this function or <see cref="AsyncInitable.InitAsync"/>.
        /// 
        /// Implementations may also support cancellation. If <paramref name="cancellable"/> is not <c>null</c>,
        /// then initialization can be cancelled by triggering the cancellable object
        /// from another thread. If the operation was cancelled, the error
        /// <see cref="IOErrorEnum.Cancelled"/> will be returned. If <paramref name="cancellable"/> is not <c>null</c> and
        /// the object doesn't support cancellable initialization the error
        /// <see cref="IOErrorEnum.NotSupported"/> will be returned.
        /// 
        /// If the object is not initialized, or initialization returns with an
        /// error, then all operations on the object except g_object_ref() and
        /// g_object_unref() are considered to be invalid, and have undefined
        /// behaviour. See the [introduction][ginitable] for more details.
        /// 
        /// Callers should not assume that a class which implements <see cref="IInitable"/> can be
        /// initialized multiple times, unless the class explicitly documents itself as
        /// supporting this. Generally, a class’ implementation of init() can assume
        /// (and assert) that it will only be called once. Previously, this documentation
        /// recommended all <see cref="IInitable"/> implementations should be idempotent; that
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
        /// In this pattern, a caller would expect to be able to call <see cref="Initable.Init"/>
        /// on the result of g_object_new(), regardless of whether it is in fact a new
        /// instance.
        /// </remarks>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful. If an error has occurred, this function will
        ///     return <c>false</c> and set <paramref name="error"/> appropriately if present.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InitableIface.UnmanagedInit))]
        void DoInit(GISharp.Lib.Gio.Cancellable? cancellable = null);
    }

    public static partial class Initable
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_initable_get_type();

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
        static extern unsafe System.Boolean g_initable_init(
        /* <type name="Initable" type="GInitable*" managed-name="Initable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr initable,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Initializes the object implementing the interface.
        /// </summary>
        /// <remarks>
        /// This method is intended for language bindings. If writing in C,
        /// g_initable_new() should typically be used instead.
        /// 
        /// The object must be initialized before any real use after initial
        /// construction, either with this function or <see cref="AsyncInitable.InitAsync"/>.
        /// 
        /// Implementations may also support cancellation. If <paramref name="cancellable"/> is not <c>null</c>,
        /// then initialization can be cancelled by triggering the cancellable object
        /// from another thread. If the operation was cancelled, the error
        /// <see cref="IOErrorEnum.Cancelled"/> will be returned. If <paramref name="cancellable"/> is not <c>null</c> and
        /// the object doesn't support cancellable initialization the error
        /// <see cref="IOErrorEnum.NotSupported"/> will be returned.
        /// 
        /// If the object is not initialized, or initialization returns with an
        /// error, then all operations on the object except g_object_ref() and
        /// g_object_unref() are considered to be invalid, and have undefined
        /// behaviour. See the [introduction][ginitable] for more details.
        /// 
        /// Callers should not assume that a class which implements <see cref="IInitable"/> can be
        /// initialized multiple times, unless the class explicitly documents itself as
        /// supporting this. Generally, a class’ implementation of init() can assume
        /// (and assert) that it will only be called once. Previously, this documentation
        /// recommended all <see cref="IInitable"/> implementations should be idempotent; that
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
        /// In this pattern, a caller would expect to be able to call <see cref="Initable.Init"/>
        /// on the result of g_object_new(), regardless of whether it is in fact a new
        /// instance.
        /// </remarks>
        /// <param name="initable">
        /// a <see cref="IInitable"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe static void Init(this GISharp.Lib.Gio.IInitable initable, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var initable_ = initable.Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_initable_init(initable_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }
    }
}