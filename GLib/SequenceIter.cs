using System;
using GISharp.Core;

namespace GISharp.GLib
{
    public partial class SequenceIter
    {
        protected override void Free ()
        {
            MarshalG.Free (Handle);
        }
    }
}

