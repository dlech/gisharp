using System;
using System.Reflection;
using GISharp.GLib;

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

    public static class ErrorDomainAttributeExtensions
    {
        public static Quark GetErrorDomain (this Enum value)
        {
            var type = value.GetType ();
            var attr = type.GetCustomAttribute<ErrorDomainAttribute> ();
            if (attr == null) {
                throw new ArgumentException ("Enum type must have ErrorDomainAttribute", nameof (value));
            }
            var quark = Quark.FromString (attr.ErrorDomain);
            return quark;
        }
    }
}
