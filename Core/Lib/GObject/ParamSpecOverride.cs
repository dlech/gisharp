using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// This is a type of <see cref="ParamSpec"/> type that simply redirects operations to
    /// another paramspec.  All operations other than getting or
    /// setting the value are redirected, including accessing the nick and
    /// blurb, validating a value, and so forth. See
    /// <see cref="ParamSpec.RedirectTarget"/> for retrieving the overidden
    /// property. <see cref="ParamSpecOverride"/> is used in implementing
    /// <see cref="ObjectClass.OverrideProperty"/>, and will not be directly useful
    /// unless you are implementing a new base type similar to GObject.
    /// </summary>
    [Since ("2.4")]
    [GType ("GParamOverride", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecOverride : ParamSpec
    {
        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public IntPtr Overridden;
            #pragma warning restore CS0649
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecOverride (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[20];
    }
}
