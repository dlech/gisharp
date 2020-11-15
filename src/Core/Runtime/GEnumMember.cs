using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for adding GType information to enum members.
    /// </summary>

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GEnumMemberAttribute : Attribute
    {
        /// <summary>
        /// The GType name of the member.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// The GType nickname of the member.
        /// </summary>
        public string? Nick { get; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="name">
        /// The GType name of the member.
        /// </param>
        /// <param name="nick">
        /// The GType nickname of the member.
        /// </param>
        public GEnumMemberAttribute(string? name = null, string? nick = null)
        {
            Name = name;
            Nick = nick;
        }
    }
}
