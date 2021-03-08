// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex']/*" />
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public unsafe partial struct Mutex
    {
#pragma warning disable CS0169, CS0649
        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.P']/*" />
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public readonly System.IntPtr P;

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.I']/*" />
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public fixed uint I[2];
#pragma warning restore CS0169, CS0649
        /// <summary>
        /// Frees the resources allocated to a mutex with g_mutex_init().
        /// </summary>
        /// <remarks>
        /// This function should not be used with a #GMutex that has been
        /// statically allocated.
        /// 
        /// Calling g_mutex_clear() on a locked mutex leads to undefined
        /// behaviour.
        /// 
        /// Sine: 2.32
        /// </remarks>
        /// <param name="mutex">
        /// an initialized #GMutex
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_mutex_clear(
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckClearArgs();

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.Clear()']/*" />
        public void Clear()
        {
            fixed (GISharp.Lib.GLib.Mutex* this_ = &this)
            {
                CheckClearArgs();
                var mutex_ = this_;
                g_mutex_clear(mutex_);
            }
        }

        /// <summary>
        /// Initializes a #GMutex so that it can be used.
        /// </summary>
        /// <remarks>
        /// This function is useful to initialize a mutex that has been
        /// allocated on the stack, or as part of a larger structure.
        /// It is not necessary to initialize a mutex that has been
        /// statically allocated.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   typedef struct {
        ///     GMutex m;
        ///     ...
        ///   } Blob;
        /// 
        /// Blob *b;
        /// 
        /// b = g_new (Blob, 1);
        /// g_mutex_init (&amp;b-&gt;m);
        /// ]|
        /// 
        /// To undo the effect of g_mutex_init() when a mutex is no longer
        /// needed, use g_mutex_clear().
        /// 
        /// Calling g_mutex_init() on an already initialized #GMutex leads
        /// to undefined behaviour.
        /// </remarks>
        /// <param name="mutex">
        /// an uninitialized #GMutex
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_mutex_init(
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckInitArgs();

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.Init()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public void Init()
        {
            fixed (GISharp.Lib.GLib.Mutex* this_ = &this)
            {
                CheckInitArgs();
                var mutex_ = this_;
                g_mutex_init(mutex_);
            }
        }

        /// <summary>
        /// Locks @mutex. If @mutex is already locked by another thread, the
        /// current thread will block until @mutex is unlocked by the other
        /// thread.
        /// </summary>
        /// <remarks>
        /// #GMutex is neither guaranteed to be recursive nor to be
        /// non-recursive.  As such, calling g_mutex_lock() on a #GMutex that has
        /// already been locked by the same thread results in undefined behaviour
        /// (including but not limited to deadlocks).
        /// </remarks>
        /// <param name="mutex">
        /// a #GMutex
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_mutex_lock(
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckLockArgs();

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.Lock()']/*" />
        public void Lock()
        {
            fixed (GISharp.Lib.GLib.Mutex* this_ = &this)
            {
                CheckLockArgs();
                var mutex_ = this_;
                g_mutex_lock(mutex_);
            }
        }

        /// <summary>
        /// Tries to lock @mutex. If @mutex is already locked by another thread,
        /// it immediately returns %FALSE. Otherwise it locks @mutex and returns
        /// %TRUE.
        /// </summary>
        /// <remarks>
        /// #GMutex is neither guaranteed to be recursive nor to be
        /// non-recursive.  As such, calling g_mutex_lock() on a #GMutex that has
        /// already been locked by the same thread results in undefined behaviour
        /// (including but not limited to deadlocks or arbitrary return values).
        /// </remarks>
        /// <param name="mutex">
        /// a #GMutex
        /// </param>
        /// <returns>
        /// %TRUE if @mutex could be locked
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_mutex_trylock(
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckTrylockArgs();

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.Trylock()']/*" />
        public bool Trylock()
        {
            fixed (GISharp.Lib.GLib.Mutex* this_ = &this)
            {
                CheckTrylockArgs();
                var mutex_ = this_;
                var ret_ = g_mutex_trylock(mutex_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }

        /// <summary>
        /// Unlocks @mutex. If another thread is blocked in a g_mutex_lock()
        /// call for @mutex, it will become unblocked and can lock @mutex itself.
        /// </summary>
        /// <remarks>
        /// Calling g_mutex_unlock() on a mutex that is not locked by the
        /// current thread leads to undefined behaviour.
        /// </remarks>
        /// <param name="mutex">
        /// a #GMutex
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_mutex_unlock(
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckUnlockArgs();

        /// <include file="Mutex.xmldoc" path="declaration/member[@name='Mutex.Unlock()']/*" />
        public void Unlock()
        {
            fixed (GISharp.Lib.GLib.Mutex* this_ = &this)
            {
                CheckUnlockArgs();
                var mutex_ = this_;
                g_mutex_unlock(mutex_);
            }
        }
    }
}