// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
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
                var x when x == "gchar" || x == "gint8" => $"{typeof(sbyte)}{pointer}",
                var x when x == "guchar" || x == "guint8" => $"{typeof(byte)}{pointer}",
                var x when x == "gshort" || x == "gint16" => $"{typeof(short)}{pointer}",
                var x when x == "gushort" || x == "guint16" => $"{typeof(ushort)}{pointer}",
                var x when x == "gint" || x == "gint32" => $"{typeof(int)}{pointer}",
                var x when x == "guint" || x == "guint32" => $"{typeof(uint)}{pointer}",
                "gint64" => $"{typeof(long)}{pointer}",
                "guint64" => $"{typeof(ulong)}{pointer}",
                "glong" => $"{typeof(CLong)}{pointer}",
                "gulong" => $"{typeof(CULong)}{pointer}",
                "gfloat" => $"{typeof(float)}{pointer}",
                "gdouble" => $"{typeof(double)}{pointer}",
                var x when x == "gpointer" || x == "gconstpointer" => "System.IntPtr",
                var x when x == "gssize" || x == "gintptr" || x == "goffset" => $"nint{pointer}",
                var x when x == "gsize" || x == "guintptr" => $"nuint{pointer}",
                "gunichar" => $"{typeof(Unichar)}{pointer}",
                "gunichar2" => $"{typeof(char)}{pointer}",
                "GType" => $"{typeof(GType)}{pointer}",
                var x when x == "filename" || x == "utf8" => typeof(byte*).ToString(),
                // TODO: remove name="GLib.Strv" from Fixup.cs
                "GLib.Strv" => typeof(byte**).FullName,
                "GLib.DestroyNotify" => typeof(IntPtr).FullName,
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
                    var x when x.ParentNode is GIArg arg && arg.Scope is not null => "System.IntPtr",
                    var x when x.Interface is Callback => typeof(IntPtr).FullName,
                    var x when x.IsValueType() =>
                        $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}{pointer}",
                    _ => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}.UnmanagedStruct{pointer}",
                }
            };

            type.Element.AddAnnotation(new UnmanagedType(name));
            return name;
        }

        public static string GetUnmanagedType(this GIRegisteredType type)
        {
            return $"GISharp.Lib.{type.Namespace}.{type.GirName}.UnmanagedStruct";
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
                var x when x == "gchar" || x == "gint8" => typeof(sbyte).ToString(),
                var x when x == "guchar" || x == "guint8" => typeof(byte).ToString(),
                var x when x == "gshort" || x == "gint16" => typeof(short).ToString(),
                var x when x == "gushort" || x == "guint16" => typeof(ushort).ToString(),
                var x when x == "gint" || x == "gint32" => typeof(int).ToString(),
                var x when x == "guint" || x == "guint32" => typeof(uint).ToString(),
                "gint64" => typeof(long).ToString(),
                "guint64" => typeof(ulong).ToString(),
                "glong" => typeof(CLong).ToString(),
                "gulong" => typeof(CULong).ToString(),
                "gfloat" => typeof(float).ToString(),
                "gdouble" => typeof(double).ToString(),
                var x when x == "gpointer" || x == "gconstpointer" => "System.IntPtr",
                "gintptr" => "nint",
                "guintptr" => "nuint",
                // size/offset are cast to int to match .NET convention
                var x when x == "gsize" || x == "gssize" || x == "goffset" => typeof(int).ToString(),
                "gunichar" => typeof(Unichar).ToString(),
                "gunichar2" => typeof(char).ToString(),
                "GType" => typeof(GType).FullName,
                "utf8" => typeof(Utf8).FullName,
                "filename" => typeof(Filename).FullName,
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
