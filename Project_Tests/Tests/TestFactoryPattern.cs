using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Project_Library.Creators;
using Project_Library.Logic_And_Controller;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Tests.Tests
{
	[TestClass]
	public class TestFactoryPattern
	{
		[TestMethod]
		public void FileManager_should_return_FileManager()
		{
			string path = "";
			//Arrange
			var created = ClassCreator.CreateFileManager(path);

			//Act
			var expected = typeof(FileManager);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void UI_should_return_UI()
		{
			//Arrange
			var created = ClassCreator.CreateUI();

			//Act
			var expected = typeof(UI);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateMooGame_should_return_GameLogic()
		{
			//Arrange
			var created = ClassCreator.CreateMooGame();

			//Act
			var expected = typeof(MooGame);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateSecondGame_should_return_SecondGame()
		{
			//Arrange
			var created = ClassCreator.CreateSecondGame();

			//Act
			var expected = typeof(SecondGame);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateStatistics_should_return_StatisticCollection()
		{
			//Arrange
			var ui = new Mock<IUI>();
			var fileManager = new Mock<IFileManager>();
			var created = ClassCreator.CreateStatistics(ui.Object, fileManager.Object);

			//Act
			var expected = typeof(StatisticCollection);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateGameController_should_return_GameController()
		{
			//Arrange
			var ui = new Mock<IUI>();
			var game = new Mock<IGameLogic>();
			var statistics = new Mock<IStatistics>();
			var created = ClassCreator.CreateGameController(ui.Object, game.Object, statistics.Object);

			//Act
			var expected = typeof(GameController);
			var actual = created.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
