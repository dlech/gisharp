
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial class CancellableSource
    {
        /// <inheritdoc />
        public void SetCallback(CancellableSourceFunc func)
        {
            SetCallback<CancellableSourceFunc>(func,
                CancellableSourceFuncMarshal.ToPointer);
        }
    }
}
