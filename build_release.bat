dotnet restore FreecraftCore.DBCTools.sln

dotnet publish src/FreecraftCore.DBC.CreateDBC/FreecraftCore.DBC.CreateDBC.csproj -c Release --self-contained -r win-x64 -o Build
dotnet publish src/FreecraftCore.DBC.CreateDatabase/FreecraftCore.DBC.CreateDatabase.csproj -c Release --self-contained -r win-x64 -o Build
dotnet publish src/FreecraftCore.DBC.CreateMPQ/FreecraftCore.DBC.CreateMPQ.csproj -c Release --self-contained -r win-x64 -o Build