using System;

namespace GISharp.Runtime
{
    [AttributeUsage (AttributeTargets.Enum)]
    public sealed class ErrorDomainAttribute : Attribute
    {
        public string ErrorDomain { get; private set; }

        public ErrorDomainAttribute (string errorDomain)
        {
            ErrorDomain = errorDomain;
        }
    }
}
