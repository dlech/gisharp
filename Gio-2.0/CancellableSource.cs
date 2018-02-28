
using GISharp.Runtime;

namespace GISharp.Gio
{
    partial class CancellableSource
    {
        public void SetCallback(CancellableSourceFunc func)
        {
            base.SetCallback<CancellableSourceFunc, UnmanagedCancellableSourceFunc>(func,
                CancellableSourceFuncFactory.Create);
        }
    }
}
