// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen
{
    public static class TypeResolver
    {
        private static readonly Dictionary<string, Repository> repositoryMap = new();

        public static void AddRepository(Repository repository)
        {
            repositoryMap.TryAdd(repository.Namespace.Name, repository);
        }

        public static T ResolveType<T>(Namespace defaultNamespace, string typeName)
            where T : GIBase
        {
            var @namespace = defaultNamespace.Name;

            if (typeName.Contains('.'))
            {
                var split = typeName.Split('.');
                @namespace = split[0];
                typeName = split[1];
            }

            var repository = repositoryMap[@namespace];
            return (T)repository.Namespace.AllTypes.SingleOrDefault(x => x.GirName == typeName)
                ?? throw new KeyNotFoundException($"could not resolve {typeName}");
        }

        private record UnmanagedType(string Value);

        public static string GetUnmanagedType(this Callback callback)
        {
            var typeParameters = callback.Parameters
                .Append(callback.ReturnValue)
                .Select(x => $"{x.Type.GetUnmanagedType()}{(x.Direction != "in" ? "*" : "")}");
            return $"delegate* unmanaged[Cdecl]<{string.Join(", ", typeParameters)}>";
        }

        public static string GetUnmanagedType(this GIType type)
        {
            // return cached type if present
            if (type.Element.Annotation<UnmanagedType>() is UnmanagedType unmanaged)
            {
                return unmanaged.Value;
            }

            var pointer = type.IsPointer ? "*" : "";

            var name = type.GirName switch
            {
                // basic/fundamental types
                "none" => $"void{pointer}",
                "gboolean" => $"{typeof(Runtime.Boolean)}{pointer}",
                "gchar" or "gint8" => $"sbyte{pointer}",
                "guchar" or "guint8" => $"byte{pointer}",
                "gshort" or "gint16" => $"short{pointer}",
                "gushort" or "guint16" => $"ushort{pointer}",
                "gint" or "gint32" => $"int{pointer}",
                "guint" or "guint32" => $"uint{pointer}",
                "gint64" => $"long{pointer}",
                "guint64" => $"ulong{pointer}",
                "glong" => $"{typeof(CLong)}{pointer}",
                "gulong" => $"{typeof(CULong)}{pointer}",
                "gfloat" => $"float{pointer}",
                "gdouble" => $"double{pointer}",
                "gpointer" or "gconstpointer" => "System.IntPtr",
                "gssize" or "gintptr" => $"nint{pointer}",
                "gsize" or "guintptr" => $"nuint{pointer}",
                "gunichar" => $"uint{pointer}",
                "gunichar2" => $"char{pointer}",
                "GType" => $"GISharp.Runtime.GType{pointer}",
                "filename" or "utf8" or "bytestring" => "byte*",
                "GLib.DestroyNotify" => "delegate* unmanaged[Cdecl]<System.IntPtr, void>",
                "va_list"
                    =>
                    // va_list should be filtered out, but just in case...
                    throw new NotSupportedException("va_list is not supported"),
                var n when n is not null && n.EndsWith("Private") => "System.IntPtr",
                var n when n is not null && n.Contains('.')
                    => type switch
                    {
                        var t
                            when t.Interface is Alias alias
                                && alias.Type.Interface is Callback callback
                            => callback.GetUnmanagedType(),
                        var t when t.Interface is Callback callback => callback.GetUnmanagedType(),
                        var t when t.IsValueType() => $"GISharp.Lib.{type.GirName}{pointer}",
                        _ => $"GISharp.Lib.{type.GirName}.UnmanagedStruct{pointer}",
                    },
                var n when n is null && type is Gir.Array array
                    => $"{array.TypeParameters.Single().GetUnmanagedType()}*",
                _
                    => type switch
                    {
                        var t
                            when t.Interface is Alias alias
                                && alias.Type.Interface is Callback callback
                            => callback.GetUnmanagedType(),
                        var t when t.Interface is Alias alias && alias.Type.GirName == "utf8"
                            => "byte*",
                        var t when t.Interface is Callback callback => callback.GetUnmanagedType(),
                        var t when t.IsValueType()
                            => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}{pointer}",
                        _
                            => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}.UnmanagedStruct{pointer}",
                    }
            };

            type.Element.AddAnnotation(new UnmanagedType(name));
            return name;
        }

        private record ManagedType(string Value);

        public static string GetManagedType(this GIType type)
        {
            // return cached type if present
            if (type.Element.Annotation<ManagedType>() is ManagedType managed)
            {
                return managed.Value;
            }

            var name = type.GirName switch
            {
                // basic/fundamental types
                "none" => "void",
                "gboolean" => "bool",
                "gchar" or "gint8" => "sbyte",
                "guchar" or "guint8" => "byte",
                "gshort" or "gint16" => "short",
                "gushort" or "guint16" => "ushort",
                "gint" or "gint32" => "int",
                "guint" or "guint32" => "uint",
                "gint64" => "long",
                "guint64" => "ulong",
                "glong" => typeof(CLong).ToString(),
                "gulong" => typeof(CULong).ToString(),
                "gfloat" => "float",
                "gdouble" => "double",
                "gpointer" or "gconstpointer" => "System.IntPtr",
                "gintptr" => "nint",
                "guintptr" => "nuint",
                // size/offset are cast to int to match .NET convention
                "gsize" or "gssize" => "int",
                "gunichar" => "System.Text.Rune",
                "gunichar2" => "char",
                "GType" => "GISharp.Runtime.GType",
                "utf8" => "GISharp.Runtime.Utf8",
                "filename" => "GISharp.Runtime.Filename",
                "bytestring" => "GISharp.Runtime.ByteString",
                "va_list"
                    =>
                    // va_list should be filtered out, but just in case...
                    throw new NotSupportedException("va_list is not supported"),
                var n when n is null && type is Gir.Array
                    => type.TypeParameters.Single().IsValueType()
                        ? "GISharp.Runtime.CArray"
                        : "GISharp.Runtime.CPtrArray",
                var n when n is not null && n.EndsWith("Private") => "System.IntPtr",
                var n when n is not null && n.Contains('.') => $"GISharp.Lib.{type.GirName}",
                _ => $"GISharp.Lib.{type.Namespace.Name}.{type.GirName}",
            };

            // inject "I" for interface
            if (type.Interface is Interface)
            {
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

        /// <summary>
        /// Tests if the managed type is a value type.
        /// </summary>
        public static bool IsValueType(this GIType type)
        {
            if (type is Gir.Array)
            {
                return false;
            }

            if (
                type.GirName == "utf8" || type.GirName == "filename" || type.GirName == "bytestring"
            )
            {
                return false;
            }

            if (type.GirName == "GLib.List" || type.GirName == "GLib.SList")
            {
                return false;
            }

            if (type.GirName == "GLib.HashTable")
            {
                return false;
            }

            if (type.Interface is null)
            {
                return true;
            }

            if (type.Interface is Bitfield || type.Interface is Enumeration)
            {
                return true;
            }

            if (type.Interface is Record record)
            {
                return !record.IsDisguised && record.IsGTypeStructFor is null;
            }

            if (type.Interface is Alias alias)
            {
                return alias.Type.IsValueType();
            }

            if (type.Interface is Union)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tests if the managed type is an opaque type.
        /// </summary>
        public static bool IsOpaque(this GIType type)
        {
            if (type.IsValueType())
            {
                return false;
            }

            if (type.Interface is Callback)
            {
                return false;
            }

            return true;
        }
    }
}
