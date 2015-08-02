using System;

namespace GISharp.CodeGen.Wrapped
{
    public class SignalInfo : CallableInfo
    {
        internal new GISharp.GI.SignalInfo Info {
            get {
                return base.Info as GISharp.GI.SignalInfo;
            }
        }

        public bool IsHandledEvent {
            get {
                return Info.TrueStopsEmit;
            }
        }

        public SignalInfo (GISharp.GI.SignalInfo info) : base (info)
        {
        }
    }
}
