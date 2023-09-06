using Moq;
using Project_Library.Logic_And_Controller;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Tests.Tests
{
	[TestClass]
	public class GameControllerTest
	{
		[TestMethod]
		public void Run_should_use_all_once_functions_given_the_right_values()
		{
			//Arrange
			var uiObject = new Mock<IUI>();
			uiObject.Setup(o => o.Input()).Returns(It.IsAny<string>());

			var gameObject = new Mock<IGame>();
			gameObject.Setup(o => o.GenerateActualValues()).Returns("4365");
			gameObject.Setup(o => o.GameWon).Returns("BBBB,");
			gameObject.SetupSequence(o => o.Result(It.IsAny<string>(), It.IsAny<string>()))
				.Returns("No Success")
				.Returns("No Success")
				.Returns("BBBB,");

			var statisticsObject = new Mock<IStatistics>();
			
			IController sut = new GameController(uiObject.Object, gameObject.Object, statisticsObject.Object);

			//Act
			sut.Run();


			//Assert
			gameObject.Verify(o => o.GenerateActualValues(), Times.Exactly(1));
			statisticsObject.Verify(o => o.Store(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(1));
			statisticsObject.Verify(o => o.Show(), Times.Exactly(1));	
		}
	}
}
