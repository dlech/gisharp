using System;

namespace GISharp.Runtime
{
    [AttributeUsage (AttributeTargets.All)]
    public sealed class DeprecatedAttribute : Attribute
    {
        public Version Version { get; private set; }

        public DeprecatedAttribute (string version)
        {
            Version = Version.Parse (version);
        }
    }
}
