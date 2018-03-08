using System;
using GISharp.Runtime;

namespace GISharp.GLib
{
    partial class KeyFile
    {
        /// <summary>
        /// Associates a list of string values for <paramref name="key"/> and 
        /// <paramref name="locale"/> under <paramref name="groupName"/> 
        /// If the translation for <paramref name="key"/> cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// an array of locale string values
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="groupName"/>, <paramref name="key"/>,
        /// <paramref name="locale"/> or <paramref name="list"/> is <c>null</c>.
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetLocaleStringList(Utf8 groupName, Utf8 key, Utf8 locale, Strv list)
        {
            var keyFile_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? throw new ArgumentNullException(nameof(locale));
            var list_ = list?.Handle ?? throw new ArgumentNullException(nameof(list));
            var length_ = (UIntPtr)list.Length;
            g_key_file_set_locale_string_list(keyFile_, groupName_, key_, locale_, list_, length_);
        }

        /// <summary>
        /// Associates a list of string values for <paramref name="key"/> under
        /// <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// If <paramref name="groupName"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/>, <paramref name="key"/> or
        /// <paramref name="list"/> is <c>null</c>.
        /// </exception>
        [Since("2.6")]
        public void SetStringList(Utf8 groupName, Utf8 key, Strv list)
        {
            var keyFile_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new ArgumentNullException(nameof(key));
            var list_ = list?.Handle ?? throw new ArgumentNullException(nameof(list));
            var length_ = (UIntPtr)list.Length;
            g_key_file_set_string_list(keyFile_, groupName_, key_, list_, length_);
        }
    }
}
