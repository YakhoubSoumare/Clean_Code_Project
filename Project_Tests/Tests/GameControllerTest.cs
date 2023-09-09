//using System.Collections.Generic;
//using Microsoft.VisualBasic;
//using Moq;
//using Project_Library.Logic_And_Controller;
//using Project_Library.StatisticCollections;
//using Project_Library.UIs;

//namespace Project_Tests.Tests
//{
//	[TestClass]
//	public class GameControllerTest
//	{
//		[TestMethod]
//		public void Run_should_use_all_once_functions_given_the_right_gameWon_value()
//		{

//			//Arrange
//			var uiObject = new Mock<IUI>();
//			uiObject.Setup(o => o.Input()).Returns(It.IsAny<string>());

//			var gameObject = new Mock<IGameLogic>();
//			gameObject.Setup(o => o.GenerateActualValues()).Returns(It.IsAny<string>);
//			string gameWon = "BBBB,";
//			gameObject.Setup(o => o.GameWon).Returns(gameWon);
//			gameObject.SetupSequence(o => o.Result(It.IsAny<string>(), It.IsAny<string>()))
//				.Returns("No Success")
//				.Returns("No Success")
//				.Returns(gameWon);

//			var statisticsObject = new Mock<IStatistics>();
//			var observerObject = new Mock<IFileManager>();
//			IGameController sut = new GameController(uiObject.Object, gameObject.Object, statisticsObject.Object);
			

//			//Act
//			sut.Run();


//			//Assert
//			gameObject.Verify(o => o.GenerateActualValues(), Times.Exactly(1));
//			observerObject.Verify(o => o.Update(sut), Times.Exactly(1));
//			statisticsObject.Verify(o => o.Store(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(1));
//			statisticsObject.Verify(o => o.Show(It.IsAny<string>()), Times.Exactly(1));
//		}
//	}
//}
