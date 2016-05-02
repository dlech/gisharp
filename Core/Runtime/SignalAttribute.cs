using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is used to decorate events that should be registered
    /// as signals with the GObject type system.
    /// </summary>
    [AttributeUsage (AttributeTargets.Event, Inherited = true)]
    public sealed class SignalAttribute : Attribute
    {
        public string Name { get; private set; }

        public SignalAttribute (string name = null)
        {
            Name = name;
        }
    }
}
