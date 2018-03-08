using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is used to decorate events that should be registered
    /// as signals with the GObject type system.
    /// </summary>
    [AttributeUsage (AttributeTargets.Event, Inherited = true)]
    public sealed class GSignalAttribute : Attribute
    {
        public string Name { get; private set; }

        public EmissionStage When;

        public bool IsNoRecurse;

        public bool IsDetailed;

        public bool IsAction;

        public bool IsNoHooks;

        public GSignalAttribute (string name = null)
        {
            Name = name;
        }
    }
}
