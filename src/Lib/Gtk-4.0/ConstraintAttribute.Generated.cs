// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkConstraintAttribute", IsProxyForUnmanagedType = true)]
    public enum ConstraintAttribute
    {
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.None']/*" />
        None = 0,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Left']/*" />
        Left = 1,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Right']/*" />
        Right = 2,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Top']/*" />
        Top = 3,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Bottom']/*" />
        Bottom = 4,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Start']/*" />
        Start = 5,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.End']/*" />
        End = 6,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Width']/*" />
        Width = 7,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Height']/*" />
        Height = 8,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.CenterX']/*" />
        CenterX = 9,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.CenterY']/*" />
        CenterY = 10,
        /// <include file="ConstraintAttribute.xmldoc" path="declaration/member[@name='ConstraintAttribute.Baseline']/*" />
        Baseline = 11
    }

    /// <summary>
    /// Extension methods for <see cref="ConstraintAttribute"/>.
    /// </summary>
    public static unsafe partial class ConstraintAttributeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_constraint_attribute_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_constraint_attribute_get_type();
    }
}