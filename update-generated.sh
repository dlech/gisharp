#!/bin/bash

dotnet run --project CodeGen/CodeGen.csproj -- -p GLib-2.0 -c generate
dotnet run --project CodeGen/CodeGen.csproj -- -p GObject-2.0 -c generate
dotnet run --project CodeGen/CodeGen.csproj -- -p Gio-2.0 -c generate
