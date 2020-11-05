using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Indicates the library version in which the attribute target was deprecated.
    /// </summary>
    [AttributeUsage (AttributeTargets.All)]
    public sealed class DeprecatedSinceAttribute : Attribute
    {
        public Version Version { get; }

        public DeprecatedSinceAttribute (string version)
        {
            Version = Version.Parse (version);
        }
    }
}
