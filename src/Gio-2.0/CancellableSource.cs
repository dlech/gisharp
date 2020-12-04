
namespace GISharp.Lib.Gio
{
    partial class CancellableSource
    {
        /// <inheritdoc />
        public void SetCallback(CancellableSourceFunc func)
        {
            SetCallback(func, CancellableSourceFuncMarshal.ToUnmanagedFunctionPointer);
        }
    }
}
