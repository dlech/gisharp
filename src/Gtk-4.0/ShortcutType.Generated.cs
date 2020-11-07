// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkShortcutType", IsProxyForUnmanagedType = true)]
    public enum ShortcutType
    {
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.Accelerator']/*" />
        Accelerator = 0,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GesturePinch']/*" />
        GesturePinch = 1,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureStretch']/*" />
        GestureStretch = 2,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureRotateClockwise']/*" />
        GestureRotateClockwise = 3,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureRotateCounterclockwise']/*" />
        GestureRotateCounterclockwise = 4,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureTwoFingerSwipeLeft']/*" />
        GestureTwoFingerSwipeLeft = 5,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureTwoFingerSwipeRight']/*" />
        GestureTwoFingerSwipeRight = 6,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.Gesture']/*" />
        Gesture = 7,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureSwipeLeft']/*" />
        GestureSwipeLeft = 8,
        /// <include file="ShortcutType.xmldoc" path="declaration/member[@name='ShortcutType.GestureSwipeRight']/*" />
        GestureSwipeRight = 9
    }

    /// <summary>
    /// Extension methods for <see cref="ShortcutType"/>.
    /// </summary>
    public static partial class ShortcutTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_shortcut_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_shortcut_type_get_type();
    }
}