using System;

namespace GISharp.Runtime
{
    [AttributeUsage (AttributeTargets.All)]
    public class SinceAttribute : Attribute
    {
        public Version Version { get; private set; }

        public SinceAttribute (string version)
        {
            Version = Version.Parse (version);
        }
    }
}
