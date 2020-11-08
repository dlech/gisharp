using System;
using static System.Reflection.BindingFlags;

namespace GISharp.Lib.Gio
{
    partial interface IAsyncInitable
    {
        // HACK: work around new_async being a function an new_finish being a
        // method which causes them to be split between the interface and the
        // extension methods class
        private static readonly IntPtr newAsyncCallback_ = (IntPtr)typeof(AsyncInitable)
            .GetField(nameof(newAsyncCallback_), Static | NonPublic)!.GetValue(null)!;
    }
}
