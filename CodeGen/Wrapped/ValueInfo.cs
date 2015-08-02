using System;

namespace GISharp.CodeGen.Wrapped
{
    public class ValueInfo : BaseInfo
    {
        internal new GISharp.GI.ValueInfo Info {
            get {
                return base.Info as GISharp.GI.ValueInfo;
            }
        }

        public string Value {
            get {
                return Info.Value.ToString ();
            }
        }

        public ValueInfo (GISharp.GI.ValueInfo info) : base (info)
        {
        }
    }
}
