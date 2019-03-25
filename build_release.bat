dotnet restore FreecraftCore.DBCTools.sln

dotnet publish src/FreecraftCore.DBC.CreateDBC/FreecraftCore.DBC.CreateDBC.csproj -c Release --self-contained -r win-x64 -o Build -f netcoreapp2.1
dotnet publish src/FreecraftCore.DBC.CreateDatabase/FreecraftCore.DBC.CreateDatabase.csproj -c Release --self-contained -r win-x64 -o Build -f netcoreapp2.1
dotnet publish src/FreecraftCore.DBC.CreateMPQ/FreecraftCore.DBC.CreateMPQ.csproj -c Release --self-contained -r win-x64 -o Build -f netcoreapp2.1
dotnet publish src/FreecraftCore.DBC.CreateJSON/FreecraftCore.DBC.CreateJSON.csproj -c Release --self-contained -r win-x64 -o Build -f netcoreapp2.1
PAUSE

mkdir build
mkdir build\release
xcopy src\FreecraftCore.DBC.CreateDBC\Build build\release /Y /q /EXCLUDE:BuildExclude.txt
xcopy src\FreecraftCore.DBC.CreateDatabase\Build build\release /Y /q /EXCLUDE:BuildExclude.txt
xcopy src\FreecraftCore.DBC.CreateMPQ\Build build\release /Y /q /EXCLUDE:BuildExclude.txt
xcopy src\FreecraftCore.DBC.CreateJSON\Build build\release /Y /q /EXCLUDE:BuildExclude.txt