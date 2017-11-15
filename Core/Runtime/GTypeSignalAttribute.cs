using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is used to decorate events that should be registered
    /// as signals with the GObject type system.
    /// </summary>
    [AttributeUsage (AttributeTargets.Event, Inherited = true)]
    public sealed class GTypeSignalAttribute : Attribute
    {
        public string Name { get; private set; }

        public GTypeSignalAttribute (string name = null)
        {
            Name = name;
        }
    }
}
