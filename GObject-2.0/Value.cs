using System;

namespace GISharp.GObject
{
    public partial class Value
    {
        protected override void Free ()
        {
            // TODO: Need to lookup free function in TypeValueTable
            throw new NotImplementedException ();
        }
    }
}
