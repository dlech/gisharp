// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;

namespace GISharp.CodeGen
{
    public static class TypeResolver
    {
        private static readonly Dictionary<string, Repository> repositoryMap = new();

        public static void AddRepository(Repository repository)
        {
            repositoryMap.TryAdd(repository.Namespace.Name, repository);
        }

        public static T ResolveType<T>(Namespace defaultNamespace, string typeName) where T : GIBase
        {
            var @namespace = defaultNamespace.Name;

            if (typeName.Contains('.')) {
                var split = typeName.Split('.');
                @namespace = split[0];
                typeName = split[1];
            }

            var repository = repositoryMap[@namespace];
            return (T)repository.Namespace.AllTypes.SingleOrDefault(x => x.GirName == typeName) ??
                throw new KeyNotFoundException($"could not resolve {typeName}");
        }

        private record UnmanagedType(string Value);

        public static string GetUnmanagedType(this Callback callback)
        {
            var typeParameters = callback.Parameters.Append(callback.ReturnValue)
                .Select(x => $"{x.Type.GetUnmanagedType()}{(x.Direction != "in" ? "*" : "")}");
            return $"delegate* unmanaged[Cdecl]<{string.Join(", ", typeParameters)}>";
        }

        public static string GetUnmanagedType(this GIType type)
        {
            // return cached type if present
            if (type.Element.Annotation<UnmanagedType>() is UnmanagedType unmanaged) {
                return unmanaged.Value;
            }

            var pointer = type.IsPointer ? "*" : "";

            var name = type.GirName switch {
                // basic/fundamental types
                "none" => $"void{pointer}",
                "gboolean" => $"{typeof(Runtime.Boolean)}{pointer}",
                var x when x == "gchar" || x == "gint8" => $"sbyte{pointer}",
                var x when x == "guchar" || x == "guint8" => $"byte{pointer}",
                var x when x == "gshort" || x == "gint16" => $"short{pointer}",
                var x when x == "gushort" || x == "guint16" => $"ushort{pointer}",
                var x when x == "gint" || x == "gint32" => $"int{pointer}",
                var x when x == "guint" || x == "guint32" => $"uint{pointer}",
                "gint64" => $"long{pointer}",
                "guint64" => $"ulong{pointer}",
                "glong" => $"{typeof(CLong)}{pointer}",
                "gulong" => $"{typeof(CULong)}{pointer}",
                "gfloat" => $"float{pointer}",
                "gdouble" => $"double{pointer}",
                var x when x == "gpointer" || x == "gconstpointer" => "System.IntPtr",
                var x when x == "gssize" || x == "gintptr" || x == "goffset" => $"nint{pointer}",
                var x when x == "gsize" || x == "guintptr" => $"nuint{pointer}",
                "gunichar" => $"GISharp.Lib.GLib.Unichar{pointer}",
                "gunichar2" => $"char{pointer}",
                "GType" => $"GISharp.Lib.GObject.GType{pointer}",
                var x when x == "filename" || x == "utf8" => "byte*",
                // TODO: remove name="GLib.Strv" from Fixup.cs
                "GLib.Strv" => "byte**",
                "GLib.DestroyNotify" => "delegate* unmanaged[Cdecl]<System.IntPtr, void>",
                "va_list" =>
                    // va_list should be filtered out, but just in case...
                    throw new NotSupportedException("va_list is not supported"),
                var x when x is not null && x.EndsWith("Private") => "System.IntPtr",
                var x when x is not null && x.Contains(".") => type.IsValueType() ?
                    $"GISharp.Lib.{type.GirName}{pointer}" :
                    $"GISharp.Lib.{type.GirName}.UnmanagedStruct*",
                var x when x is null && type is Gir.Array array =>
                    $"{array.TypeParameters.Single().GetUnmanagedType()}*",
                _ => type switch {
                    var x when x.Interface is Callback callback => callback.GetUnmanagedType(),
                    var x when x.IsValueType() =>
                        $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}{pointer}",
                    _ => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}.UnmanagedStruct{pointer}",
                }
            };

            type.Element.AddAnnotation(new UnmanagedType(name));
            return name;
        }

        private record ManagedType(string Value);

        public static string GetManagedType(this GIType type)
        {
            // return cached type if present
            if (type.Element.Annotation<ManagedType>() is ManagedType managed) {
                return managed.Value;
            }

            var name = type.GirName switch {
                // basic/fundamental types
                "none" => "void",
                "gboolean" => typeof(bool).ToString(),
                var x when x == "gchar" || x == "gint8" => "sbyte",
                var x when x == "guchar" || x == "guint8" => "byte",
                var x when x == "gshort" || x == "gint16" => "short",
                var x when x == "gushort" || x == "guint16" => "ushort",
                var x when x == "gint" || x == "gint32" => "int",
                var x when x == "guint" || x == "guint32" => "uint",
                "gint64" => "long",
                "guint64" => "ulong",
                "glong" => typeof(CLong).ToString(),
                "gulong" => typeof(CULong).ToString(),
                "gfloat" => "float",
                "gdouble" => "double",
                var x when x == "gpointer" || x == "gconstpointer" => "System.IntPtr",
                "gintptr" => "nint",
                "guintptr" => "nuint",
                // size/offset are cast to int to match .NET convention
                var x when x == "gsize" || x == "gssize" || x == "goffset" => "int",
                "gunichar" => "GISharp.Lib.GLib.Unichar",
                "gunichar2" => "char",
                "GType" => "GISharp.Lib.GObject.GType",
                "utf8" => "GISharp.Lib.GLib.Utf8",
                "filename" => "GISharp.Lib.GLib.Filename",
                "va_list" =>
                    // va_list should be filtered out, but just in case...
                    throw new NotSupportedException("va_list is not supported"),
                var x when x is null && type is Gir.Array array && array.IsZeroTerminated &&
                    type.TypeParameters.Single().GirName == "filename" =>
                        typeof(FilenameArray).FullName,
                var x when x is null && type is Gir.Array =>
                    type.TypeParameters.Single().IsValueType() ?
                        $"{typeof(CArray).FullName}<{type.TypeParameters.Single().GetUnmanagedType()}>" :
                        $"{typeof(CPtrArray).FullName}<{type.TypeParameters.Single().GetManagedType()}>",
                var x when x is not null && x.EndsWith("Private") => "System.IntPtr",
                var x when x is not null && x.Contains(".") => $"GISharp.Lib.{type.GirName}",
                _ => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}",
            };

            // inject "I" for interface
            if (type.Interface is Interface) {
                var lastDot = name.LastIndexOf('.') + 1;
                name = $"{name[..lastDot]}I{name[lastDot..]}";
            }

            type.Element.AddAnnotation(new ManagedType(name));
            return name;
        }

        public static string GetManagedType(this GIRegisteredType type)
        {
            var interfacePrefix = type is Interface ? "I" : "";
            return $"GISharp.Lib.{type.Namespace.Name}.{interfacePrefix}{type.GirName}";
        }

        public static bool IsValueType(this Record record)
        {
            // TODO: need better way to detect struct vs opaque
            if (record.GTypeName == "GValue") {
                return true;
            }
            if (record.GTypeName == "GPollFD") {
                return true;
            }
            if (record.CType == "GTypeInterface") {
                return false;
            }
            if (record.GTypeName is not null || record.IsDisguised || record.IsSource) {
                return false;
            }
            if (record.IsGTypeStructFor is not null) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tests if the managed type is a value type.
        /// </summary>
        public static bool IsValueType(this GIType type)
        {
            if (type is Gir.Array) {
                return false;
            }

            if (type.GirName == "utf8" || type.GirName == "filename") {
                return false;
            }

            if (type.GirName == "GLib.List" || type.GirName == "GLib.SList") {
                return false;
            }

            if (type.GirName == "GLib.Hash") {
                return false;
            }

            if (type.Interface is null) {
                return true;
            }

            if (type.Interface is Bitfield || type.Interface is Enumeration) {
                return true;
            }

            if (type.Interface is Record record) {
                return record.IsValueType();
            }

            if (type.Interface is Alias alias) {
                return alias.Type.IsValueType();
            }

            if (type.Interface is Union) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tests if the managed type is an opaque type.
        /// </summary>
        public static bool IsOpaque(this GIType type)
        {
            if (type.IsValueType()) {
                return false;
            }

            if (type.Interface is Callback) {
                return false;
            }

            return true;
        }
    }
}
