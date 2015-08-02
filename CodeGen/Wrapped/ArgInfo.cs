using System;

namespace GISharp.CodeGen.Wrapped
{
    public class ArgInfo : BaseInfo
    {
        internal new GISharp.GI.ArgInfo Info {
            get {
                return base.Info as GISharp.GI.ArgInfo;
            }
        }

        public new CallableInfo Container {
            get {
                return base.Container as CallableInfo;
            }
        }

        public ArgInfo ClosureArg { get; private set; }

        public ArgInfo DestroryArg { get; private set; }

        public bool IsIn {
            get {
                return Info.Direction != GISharp.GI.Direction.Out;
            }
        }

        public bool IsOut {
            get {
                return Info.Direction != GISharp.GI.Direction.In;
            }
        }

        public bool TransfersContainerOwnership {
            get {
                return Info.OwnershipTransfer != GISharp.GI.Transfer.Nothing;
            }
        }

        public bool TransfersElementOwnership {
            get {
                return Info.OwnershipTransfer == GISharp.GI.Transfer.Everything;
            }
        }

        public bool FreeUserDataOnReturn {
            get {
                return Info.Scope == GISharp.GI.ScopeType.Call;
            }
        }

        public bool FreeUserDataOnCallbackReturn {
            get {
                return Info.Scope == GISharp.GI.ScopeType.Async;
            }
        }

        public bool FreeUserOnDestroyNotify {
            get {
                return Info.Scope == GISharp.GI.ScopeType.Notified;
            }
        }

        public TypeInfo Type { get; private set; }

        public bool IsNullAllowed {
            get {
                return Info.MayBeNull;
            }
        }

        public bool IsCallerAllocates {
            get {
                return Info.IsCallerAllocates;
            }
        }

        public bool IsOptional {
            get {
                return Info.IsOptional;
            }
        }

        public bool IsReturnValue {
            get {
                return Info.IsReturnValue;
            }
        }

        public bool IsSkip {
            get {
                return Info.IsSkip;
            }
        }

        public ArgInfo (GISharp.GI.ArgInfo info) : base (info)
        {
            if (info.Closure >= 0) {
                ClosureArg = WrapInfo (Container.Info.Args [info.Closure]) as ArgInfo;
            }
            if (info.Destroy >= 0) {
                DestroryArg = WrapInfo (Container.Info.Args [info.Destroy]) as ArgInfo;
            }
            Type = WrapInfo (info.TypeInfo) as TypeInfo;
        }
    }
}
