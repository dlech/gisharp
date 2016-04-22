using System;

namespace GISharp.GObject
{
    [AttributeUsage (AttributeTargets.Enum)]
    public class ErrorDomainAttribute : Attribute
    {
        public string ErrorDomain { get; private set; }

        public ErrorDomainAttribute (string errorDomain)
        {
            ErrorDomain = errorDomain;
        }
    }
}
