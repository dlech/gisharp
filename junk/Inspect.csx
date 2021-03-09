#!/usr/bin/env dotnet-script

#nullable enable

#r "System.Xml.Linq"

using System.IO;
using System.Xml.Linq;

readonly XNamespace gi = "http://www.gtk.org/introspection/core/1.0";
readonly XNamespace c = "http://www.gtk.org/introspection/c/1.0";
readonly XNamespace glib = "http://www.gtk.org/introspection/glib/1.0";
readonly XNamespace gs = "http://gisharp.org/introspection/gisharp/1.0";

foreach (var f in Directory.GetFiles("/usr/local/share/gir-1.0", "*.gir")) {
    WriteLine(f);
    var doc = XDocument.Load(f);
    // foreach (var element in doc.Descendants(gi + "doc")
    //     .Concat(doc.Descendants(gi + "source-position")).ToList()
    // ) {
    //     element.Remove();
    // }

    // foreach (var element in doc.Descendants(gi + "record")
    //     .Where(x => !(x.Attribute("name")?.Value?.EndsWith("Private") ?? false))
    //     .Where(x => x.Attribute(glib + "is-gtype-struct-for") is null)
    //     .Where(x => x.Attribute("disguised")?.Value == "1")
    // ) {
    //     element.RemoveNodes();
    //     WriteLine(element);
    // }

    // foreach (var element in doc.Descendants(gi + "record")
    //     .Where(x => x.Attribute(glib + "type-name") is null)
    //     .Where(x => x.Attribute(glib + "is-gtype-struct-for") is null)
    //     .Where(x => x.Attribute("disguised")?.Value != "1")
    // ) {
    //     element.RemoveNodes();
    //     WriteLine(element);
    // }

    foreach (var element in doc.Descendants(glib + "boxed")
    ) {
        element.RemoveNodes();
        WriteLine(element);
    }

    // foreach (var item in doc.Descendants(gi + "parameters")
    //     .Select(x => (
    //         x.Parent!.Name.LocalName,
    //         x.Parent!.Attribute("name")?.Value,
    //         x.Elements().Count(x => x.Attribute("destroy") is not null)
    //     ))
    //     .Where(x => x.Item3 > 1)
    //     .GroupBy(x => x, x => x, (x, e) => new {
    //         Element = x.LocalName,
    //         Names = string.Join(", ", e.Select(y => y.Value)),
    //         Num = x.Item3,
    //         Count = e.Count(),
    //     })
    // ) {
    //     WriteLine($"{item}");
    // }

    // foreach (var item in doc.Descendants(gi + "parameters")
    //     .Select(x => (
    //         x.Parent!.Name.LocalName,
    //         x.Parent!.Attribute("name")?.Value,
    //         x.Elements().Count(x => x.Attribute("closure") is not null)
    //     ))
    //     .Where(x => x.Item3 > 1)
    //     .GroupBy(x => x, x => x, (x, e) => new {
    //         Element = x.LocalName,
    //         Names = string.Join(", ", e.Select(y => y.Value)),
    //         Num = x.Item3,
    //         Count = e.Count(),
    //     })
    // ) {
    //     WriteLine($"{item}");
    // }

    // foreach (var element in doc.Descendants(gi + "parameter")
    //     .Where(x => x.Attribute("closure")?.Value == "1")
    // ) {
    //     WriteLine($"{element?.Parent?.Parent}");
    // }
}
