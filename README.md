# FreecraftCore.DBCTools

FreecraftCore's C#/.NET library and tools for DBC file editing, versioning and SQL. Provides several applications that can be used to create a toolchain for DBC development.

Supports:
- [ ] 1.12.1
- [ ] 2.4.3
- [x] 3.3.5
- [ ] 4.x

## Why?

I noticed a lack of fully automated and managed pipeline for developing DBC editing tools, for managing DBC content, for turning edited DBCs into MPQ patches and for data versioning. I happened to need tools like this so I developed them to support these needs.

### CreateDatabase

[FreecraftCore.DBCTools.CreateDatabase](https://github.com/FreecraftCore/FreecraftCore.DBCTools/tree/master/src/FreecraftCore.DBC.CreateDatabase) is the tool that is responsible for creating SQL tables for DBC editing. To use this tool you only need to configure the DBC input path, which defaults to DBC folder, and the Database connection string. Right now only MySQL is supported by any SQL provider could be used in the future.

This will generate a table for each DBC implemented, not all are implemented yet, and will look like this:

![Tables](https://i.imgur.com/B7W7tgr.png)

The concept is that the raw DBC format is **NOT** ideal for editing. A relational database such as MySQL provides significant advantages for editing, even with just raw SQL. Though it's recommended to build tooling/UI/GUI applications that interact with these tables. You can access the DbContext and tables/structures by referencing the Management library in this project (soon to be on NuGet).

### CreateDBC

[FreecraftCore.DBCTools.CreateDBC](https://github.com/FreecraftCore/FreecraftCore.DBCTools/tree/master/src/FreecraftCore.DBC.CreateDBC) is similar to CreateDatabase but is the inverse. It is responsible for loading the SQL tables into memory and generating DBC files for the tables. This will include all modifications done to the tables. Meaning this is the rebuilding tool that should be used after editing the tables, if you actually need this data back into DBC format.

Make sure to configure the output directory for the DBC files. The default is DBC_OUTPUT/DBCFilesClient.

### CreateMPQ

[FreecraftCore.DBCTools.CreateMPQ](https://github.com/FreecraftCore/FreecraftCore.DBCTools/tree/master/src/FreecraftCore.DBC.CreateMPQ) is the final stage of the current toolchain. It takes the DBC files in the configured DBC output directory and generates, with the help of [stormlib](https://github.com/ladislav-zezula/StormLib), an MPQ with the name specified in the configuration file.

# Releases

## Github:

TODO
