#!/bin/bash

cd todo-dotnetcore/src

dotnet restore
dotnet build
dotnet test ./ToDo.Web.Test/