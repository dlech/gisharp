
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial class CancellableSource
    {
        public void SetCallback(CancellableSourceFunc func)
        {
            base.SetCallback<CancellableSourceFunc>(func,
                CancellableSourceFuncMarshal.ToPointer);
        }
    }
}
