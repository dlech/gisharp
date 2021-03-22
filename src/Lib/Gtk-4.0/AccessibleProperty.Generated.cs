// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkAccessibleProperty", IsProxyForUnmanagedType = true)]
    public enum AccessibleProperty
    {
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Autocomplete']/*" />
        Autocomplete = 0,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Description']/*" />
        Description = 1,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.HasPopup']/*" />
        HasPopup = 2,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.KeyShortcuts']/*" />
        KeyShortcuts = 3,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Label']/*" />
        Label = 4,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Level']/*" />
        Level = 5,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Modal']/*" />
        Modal = 6,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.MultiLine']/*" />
        MultiLine = 7,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.MultiSelectable']/*" />
        MultiSelectable = 8,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Orientation']/*" />
        Orientation = 9,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Placeholder']/*" />
        Placeholder = 10,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.ReadOnly']/*" />
        ReadOnly = 11,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Required']/*" />
        Required = 12,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.RoleDescription']/*" />
        RoleDescription = 13,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.Sort']/*" />
        Sort = 14,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.ValueMax']/*" />
        ValueMax = 15,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.ValueMin']/*" />
        ValueMin = 16,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.ValueNow']/*" />
        ValueNow = 17,
        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessibleProperty.ValueText']/*" />
        ValueText = 18
    }

    /// <summary>
    /// Extension methods for <see cref="AccessibleProperty"/>.
    /// </summary>
    public static unsafe partial class AccessiblePropertyExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_accessible_property_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_accessible_property_get_type();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void gtk_accessible_property_init_value(
/* <type name="AccessibleProperty" type="GtkAccessibleProperty" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gtk.AccessibleProperty property,
/* <type name="GObject.Value" type="GValue*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GObject.Value* value);
        static partial void CheckInitValueArgs(this GISharp.Lib.Gtk.AccessibleProperty property, ref GISharp.Lib.GObject.Value value);

        /// <include file="AccessibleProperty.xmldoc" path="declaration/member[@name='AccessiblePropertyExtensions.InitValue(GISharp.Lib.Gtk.AccessibleProperty,GISharp.Lib.GObject.Value)']/*" />
        public static void InitValue(this GISharp.Lib.Gtk.AccessibleProperty property, ref GISharp.Lib.GObject.Value value)
        {
            fixed (GISharp.Lib.GObject.Value* value_ = &value)
            {
                CheckInitValueArgs(property, ref value);
                var property_ = (GISharp.Lib.Gtk.AccessibleProperty)property;
                gtk_accessible_property_init_value(property_, value_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }
    }
}