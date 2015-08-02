using System;

namespace GISharp.CodeGen.Wrapped
{
    public class VFuncInfo : CallableInfo
    {
        internal new GISharp.GI.VFuncInfo Info {
            get {
                return base.Info as GISharp.GI.VFuncInfo;
            }
        }

        public bool MustCallBase {
            get {
                return Info.Flags.HasFlag (GISharp.GI.VFuncInfoFlags.MustChainUp);
            }
        }

        public bool MustOverride {
            get {
                return Info.Flags.HasFlag (GISharp.GI.VFuncInfoFlags.MustOverride);
            }
        }

        public bool MustNotOverride {
            get {
                return Info.Flags.HasFlag (GISharp.GI.VFuncInfoFlags.MustNotOverride);
            }
        }

        SignalInfo signal;
        public SignalInfo Signal {
            get {
                if (signal == null && Info.Signal != null) {
                    signal = WrapInfo (Info.Signal) as SignalInfo;
                }
                return signal;
            }
        }

        FunctionInfo invoker;
        public FunctionInfo Invoker {
            get {
                if (invoker == null && Info.Invoker != null) {
                    invoker = WrapInfo (Info.Invoker) as FunctionInfo;
                }
                return invoker;
            }
        }

        public VFuncInfo (GISharp.GI.VFuncInfo info) : base (info)
        {
        }
    }
}
