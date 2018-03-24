using System.Threading.Tasks;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial class InputStream
    {
        public Task<int> ReadAsync(IArray<byte> buffer, int ioPriority = Priority.Default, Cancellable cancellable = null)
        {
            var completion = new TaskCompletionSource<int>();

            void callback(Object sourceObject, IAsyncResult res) {
                var result = ReadFinish(res);
                completion.SetResult(result);
            }

            ReadAsync(buffer, callback, ioPriority, cancellable);

            return completion.Task;
        }
    }
}
