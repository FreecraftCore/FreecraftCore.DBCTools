using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace FreecraftCore
{
	[TestFixture]
	public class GenericDBCTests
	{
		//All DBC should be marked with table attribute so
		//we can find them that way.
		/// <summary>
		/// Input test source for any test that needs to test DBC types.
		/// </summary>
		public static IEnumerable<Type> DBCStructureTypes =
			typeof(DBCHeader).Assembly
				.GetExportedTypes()
				.Where(t => t.GetCustomAttribute<TableAttribute>() != null)
				.Distinct(); //probably not needed

		public static IEnumerable<Type> NonDBCStructureWireDataContractMarkedTypes =>
			typeof(DBCHeader)
				.Assembly
				.GetExportedTypes()
				.Where(t => t.GetCustomAttribute<WireDataContractAttribute>() != null && !DBCStructureTypes.Contains(t));

		[Test]
		[TestCaseSource(nameof(DBCStructureTypes))]
		public void Test_Each_DBC_Has_WireDataContract_Attribute(Type t)
		{
			//act
			bool result = t.GetCustomAttribute<WireDataContractAttribute>(false) != null;

			//assert
			Assert.True(result, $"Type: {t.Name} does not have required {nameof(WireDataContractAttribute)} annoted on it.");
		}


		[Test]
		[TestCaseSource(nameof(DBCStructureTypes))]
		[TestCaseSource(nameof(NonDBCStructureWireDataContractMarkedTypes))]
		public void Test_Can_Register_All_Concrete_Models(Type t)
		{
			//We have to do abit of a hack if it's a generic type
			//We need a closed generic. DBCs usually are generic if they have strings
			if(t.IsGenericTypeDefinition)
			{
				//TODO: Handle contraints better, causes throw and this is a hack to catch
				//TODO: Support closing multiple type arg generics
				//Assuming this can work, assuming all 1 generic param for now.
				try
				{
					t = t.MakeGenericType(typeof(StringDBCReference));
				}
				catch(Exception e)
				{
					Assert.Inconclusive($"Cannot test Type: {t.Name} because closed generic could not be made. Maybe caused by constaints. Error: {e.Message}");
				}
			}

			//arrange
			SerializerService serializer = new SerializerService();

			//assert
			Assert.DoesNotThrow(() => serializer.RegisterType(t));
			Assert.DoesNotThrow(() => serializer.Compile());

			Assert.True(serializer.isTypeRegistered(t), $"Failed to register Type: {t.Name}");
		}

		[Test]
		[TestCaseSource(nameof(DBCStructureTypes))]
		public static void Test_That_Table_Names_Are_Unique(Type t)
		{
			//arrange
			TableAttribute tableAttri = t.GetCustomAttribute<TableAttribute>();

			//assert
			Assert.NotNull(tableAttri);

			//Check that only 1 other DBC type (this one) has the same table name
			foreach(Type dbcType in DBCStructureTypes.Where(t2 => t2 != t))
			{
				//Don't do select in foreach, we want type information so that we can log fails
				TableAttribute attribute = dbcType.GetCustomAttribute<TableAttribute>();
				Assert.AreNotEqual(attribute.Name, tableAttri.Name, $"Found DBC table definition with idential name: {attribute.Name} Type1: {t.Name} Type2: {dbcType.Name}");
			}
		}

		[Test]
		[TestCaseSource(nameof(DBCStructureTypes))]
		public static void Test_DBC_File_Converts_To_Table_Back_To_Same_DBC_File(Type t)
		{
			//arrange
			DbcTypeParser parser = new DbcTypeParser();
			string dbcType = parser.GetDbcName(t);
			string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "DBC", $"{dbcType}.dbc");

			if(!File.Exists(filePath))
				Assert.Inconclusive($"No DBC file test into provided for Type: {t.Name}");

			ApplicationConfiguration config = new ApplicationConfiguration("test", true, LogLevel.Debug, "DBC", "DBC_OUTPUT", "MPQ", "patch-6");

			//If we have a DBC file then we should prepare the DBC to Database stuff
			//so we can create an in memory database
			using(MockCreateDatabaseContainerServiceBuilder databaseCreatorContainer = new MockCreateDatabaseContainerServiceBuilder(config, dbcType, filePath))
			{
				IServiceProvider databaseCreatorServiceProvider = databaseCreatorContainer.Build();

				databaseCreatorServiceProvider.GetService<IDbcTargetFillable>().Fill();

				//At this point the inmemory database is filled.
				MockedCreateDbcContainerServiceBuilder dbcCreatorContainer = new MockedCreateDbcContainerServiceBuilder(config, t, databaseCreatorServiceProvider.GetService<DbContext>());

				IServiceProvider dbcCreatorServiceProvider = dbcCreatorContainer.Build();

				dbcCreatorServiceProvider.GetService<IDbcTargetFillable>().Fill();

				//At this point the DBC file should be in DbContext and the table should have
				//been loaded and turned back into a DBC file. Meaning we can now compare streams
				databaseCreatorContainer.MockedFileStream.Position = 0;
				using(BinaryReader binaryRead2 = new BinaryReader(dbcCreatorServiceProvider.GetService<Stream>()))
				using(BinaryReader binaryRead1 = new BinaryReader(databaseCreatorContainer.MockedFileStream))
				{
					binaryRead2.BaseStream.Position = 0;
					binaryRead1.BaseStream.Position = 0;

					byte[] originalBytes = binaryRead1.ReadBytes((int)databaseCreatorContainer.MockedFileStream.Length);
					byte[] outputBytes = binaryRead2.ReadBytes((int)binaryRead2.BaseStream.Length);

					Assert.AreEqual(originalBytes.Length, outputBytes.Length, $"Mismatch length on DBC to SQL to DBC for Type: {dbcType}");
					
					for(int i = 0; i < originalBytes.Length; i++)
						Assert.AreEqual(originalBytes[i], outputBytes[i], $"Mismatched value on DBC to SQL to DBC for Type: {dbcType} for Index: {i}");
				}
			}
		}
	}
}
