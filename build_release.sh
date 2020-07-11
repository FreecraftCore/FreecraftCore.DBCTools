#!/bin/bash

dotnet restore FreecraftCore.DBCTools.sln

dotnet publish src/FreecraftCore.DBC.CreateDBC/FreecraftCore.DBC.CreateDBC.csproj -c Release --self-contained -r linux-x64 -o Build -f netcoreapp3.1 /p:PublishSingleFile=true
dotnet publish src/FreecraftCore.DBC.CreateDatabase/FreecraftCore.DBC.CreateDatabase.csproj -c Release --self-contained -r linux-x64 -o Build -f netcoreapp3.1 /p:PublishSingleFile=true
dotnet publish src/FreecraftCore.DBC.CreateMPQ/FreecraftCore.DBC.CreateMPQ.csproj -c Release --self-contained -r linux-x64 -o Build -f netcoreapp3.1 /p:PublishSingleFile=true
dotnet publish src/FreecraftCore.DBC.CreateJSON/FreecraftCore.DBC.CreateJSON.csproj -c Release --self-contained -r linux-x64 -o Build -f netcoreapp3.1 /p:PublishSingleFile=true
dotnet publish src/FreecraftCore.DBC.CreateGDBC/FreecraftCore.DBC.CreateGDBC.csproj -c Release --self-contained -r linux-x64 -o Build -f netcoreapp3.1 /p:PublishSingleFile=true

cp lib/Stormlibsharp/StormLib.dll Build
cp lib/Stormlibsharp/stormlib_LICENSE.txt Build
cp lib/Stormlibsharp/stormlibsharp_LICENSE.txt Build