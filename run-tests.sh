#!/bin/bash

set -e

dotnet test Core.Test/
dotnet test GIRepository-2.0.Test/
dotnet test GLib-2.0.Test/
dotnet test Gio-2.0.Test/
