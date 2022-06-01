
# Mapping GLib Types to .NET Types

| GLib Type                   | .NET Type                           | Notes                                                                                                        |
| --------------------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| `gboolean`                  | `bool` or `GISharp.Runtime.Boolean` | `bool` for method parameters / return values, `GISharp.Runtime.Boolean` for struct fields and array elements |
| `gchar`, `gint8`            | `sbyte`                             | Also `byte` when `gchar*` is a string                                                                        |
| `guchar`, `guint8`          | `byte`                              |                                                                                                              |
| `gshort` ,`gint16`          | `short`                             |                                                                                                              |
| `gushort`, `guint16`        | `ushort`                            |                                                                                                              |
| `gint`, `gint32`            | `int`                               |                                                                                                              |
| `guint`, `guint32`          | `uint`                              |                                                                                                              |
| `glong`                     | `System.Runtime.InteropServices.CLong`             | 32-bit on Windows, pointer-sized elsewhere                                                                   |
| `gulong`                    | `System.Runtime.InteropServices.CULong`            | 32-bit on Windows, pointer-sized elsewhere                                                                   |
| `gint64`, `goffset`         | `long`                              |                                                                                                              |
| `guint64`                   | `ulong`                             |                                                                                                              |
| `gfloat`                    | `float`                             |                                                                                                              |
| `gdouble`                   | `double`                            |                                                                                                              |
| `gsize`                     | `int` or `nuint`                    | `int` for method parameters / return values, `nuint` for struct fields and array elements                    |
| `gssize`                    | `int` or `nint`                     | `int` for method parameters / return values, `nint` for struct fields and array elements                     |
| `gintptr`                   | `nint`                              | Also `GISharp.Runtime.OpaqueInt` if needed for `GISharp.Runtime.IOpaque`                                     |
| `guintptr`                  | `nuint`                             |                                                                                                              |
| `gpointer`, `gconstpointer` | `System.IntPtr`                     |                                                                                                              |
| `gunichar`                  | `System.Text.Rune`                  |                                                                                                              |
| `gunichar2`                 | `char`                              |                                                                                                              |


Also see:

- https://developer.gnome.org/glib/stable/glib-Basic-Types.html
- https://developer.gnome.org/glib/stable/glib-Unicode-Manipulation.html
- https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
- https://docs.microsoft.com/en-us/dotnet/framework/interop/blittable-and-non-blittable-types
