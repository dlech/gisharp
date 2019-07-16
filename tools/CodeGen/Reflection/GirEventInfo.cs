using System;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;

namespace GISharp.CodeGen.Reflection
{
    sealed class GirEventInfo : EventInfo
    {
        private readonly Signal signal;
        private readonly GirType declaringType;

        public GirEventInfo(Signal signal, GirType declaringType)
        {
            this.signal = signal ?? throw new ArgumentNullException(nameof(signal));
            this.declaringType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
        }
        public override EventAttributes Attributes => EventAttributes.None;

        public override System.Type DeclaringType => declaringType;

        public override string Name => signal.ManagedName;

        public override System.Type ReflectedType => throw new NotSupportedException();

        public override MethodInfo GetAddMethod(bool nonPublic) => null;

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            if (attributeType == typeof(GSignalAttribute)) {
                // FIXME: add additional attribute arguments
                return new [] { new GSignalAttribute(signal.GirName) };
            }

            return null;
        }

        public override MethodInfo GetRaiseMethod(bool nonPublic)
        {
            throw new NotSupportedException();
        }

        public override MethodInfo GetRemoveMethod(bool nonPublic)
        {
            throw new NotSupportedException();
        }

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }
    }
}
