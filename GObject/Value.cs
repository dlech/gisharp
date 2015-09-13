using System;

namespace GISharp.GObject
{
    public partial class Value
    {
        public override Value Copy ()
        {
            // TODO: Need to lookup copy function in TypeValueTable
            throw new NotImplementedException ();
        }

        protected override void Free ()
        {
            // TODO: Need to lookup free function in TypeValueTable
            throw new NotImplementedException ();
        }
    }
}
