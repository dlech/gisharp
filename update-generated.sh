#!/bin/bash

dotnet run --project tools/CodeGen/CodeGen.csproj -- -p src/GLib-2.0 -c generate
dotnet run --project tools/CodeGen/CodeGen.csproj -- -p src/GObject-2.0 -c generate
dotnet run --project tools/CodeGen/CodeGen.csproj -- -p Gio-2.0 -c generate
