using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for indicating in which version an API was introduced.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class SinceAttribute : Attribute
    {
        /// <summary>
        /// Gets the version in which the API was introduced.
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public SinceAttribute(string version)
        {
            Version = Version.Parse(version);
        }
    }
}
