using System;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace GISharp.GLib
{
    public static partial class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns <c>false</c> it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using <see cref="CreateSource"/>
        /// and attaches it to the global <see cref="MainContext"/> using <see cref="Source.Attach"/>, so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        /// range between <see cref="Priority.DefaultIdle"/> and <see cref="Priority.HighIdle"/>.
        /// </param>
        /// <returns>
        /// GC handle that can be used to remove the source using <see cref="Remove"/>
        /// </returns>
        public static GCHandle Add (SourceFunc function, Int32 priority = Priority.DefaultIdle)
        {
            if (function == null)
            {
                throw new System.ArgumentNullException("function");
            }

            NativeSourceFunc nativeFunction = NativeSourceFuncFactory.Create (function, false);
            var nativeFunctionGCHandle = GCHandle.Alloc (nativeFunction);
            NativeDestroyNotify nativeNotify = NativeDestoryNotifyFactory.Create (nativeFunctionGCHandle);
            var nativeNotifyGCHandle = GCHandle.Alloc (nativeNotify);
            var data = GCHandle.ToIntPtr (nativeNotifyGCHandle);
            g_idle_add_full (priority, nativeFunction, data, nativeNotify);

            return nativeNotifyGCHandle;
        }

        /// <summary>
        /// Removes the idle function with the given <see cref="GCHandle"/>.
        /// </summary>
        /// <param name="handle">
        /// GC handle for the idle source's callback.
        /// </param>
        /// <returns>
        /// <c>true</c> if an idle source was found and removed.
        /// </returns>
        public static Boolean Remove (GCHandle handle)
        {
            var userData = GCHandle.ToIntPtr (handle);
            var ret = g_idle_remove_by_data(userData);
            return ret;
        }
    }
}
