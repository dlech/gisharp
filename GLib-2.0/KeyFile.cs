using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
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
        public void SetLocaleStringList(UnownedUtf8 groupName, UnownedUtf8 key, UnownedUtf8 locale, Strv list)
        {
            var keyFile_ = this.Handle;
            var groupName_ = groupName.Handle;
            var key_ = key.Handle;
            var locale_ = locale.Handle;
            var list_ = list.Handle;
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
        public void SetStringList(UnownedUtf8 groupName, UnownedUtf8 key, Strv list)
        {
            var keyFile_ = this.Handle;
            var groupName_ = groupName.Handle;
            var key_ = key.Handle;
            var list_ = list.Handle;
            var length_ = (UIntPtr)list.Length;
            g_key_file_set_string_list(keyFile_, groupName_, key_, list_, length_);
        }
    }
}
