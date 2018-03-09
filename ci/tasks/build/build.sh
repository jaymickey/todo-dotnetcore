#!/bin/bash

cd git/src

dotnet restore
dotnet build
dotnet test ./ToDo.Web.Test/