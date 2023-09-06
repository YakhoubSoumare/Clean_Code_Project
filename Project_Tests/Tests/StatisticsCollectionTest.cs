using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Tests.Tests
{
	[TestClass]
	public class StatisticsCollectionTest
	{
		[TestMethod]
		public void Store_should_write_name_and_attempts_to_file()
		{
			//Arrange
			var fileManagerObject = new Mock<IFileManager>();
			string testName = "FromTest";
			int testAttempts = 22;
			var fakeFilePath = new MemoryStream();
			fileManagerObject.Setup(o => o.StreamWriter()).Returns(new StreamWriter(fakeFilePath));
			var writer = fileManagerObject.Object.StreamWriter();


			//Act
			string expected = $"{testName}#&#{testAttempts}";
			writer.Write($"{testName}#&#{testAttempts}");
			writer.Flush();
			var output = fakeFilePath.ToArray();

			string actual = System.Text.Encoding.Default.GetString(output);

			writer.Dispose();


			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Show_should_Read_what_is_inside_file()
		{
			string testName = "ToReadFromTest";
			int testAttempts = 11;
			var fileManagerObject = new Mock<IFileManager>();
			var fakeFilePath = new MemoryStream();
			fileManagerObject.Setup(x => x.StreamReader()).Returns(new StreamReader(fakeFilePath));
			fileManagerObject.Setup(o => o.StreamWriter()).Returns(new StreamWriter(fakeFilePath));

			var reader = fileManagerObject.Object.StreamReader();
			var writer = fileManagerObject.Object.StreamWriter();


			//Act 
			writer.Write($"{testName}#&#{testAttempts}");
			writer.Flush();
			var outputWrittenToStream = fakeFilePath.ToArray();

			fakeFilePath.Position = 0;
			var dataReadFromStream = reader.ReadToEnd();
			writer.Dispose();
			reader.Dispose();

			string expected = $"{testName}#&#{testAttempts}";
			string actual = dataReadFromStream;


			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
