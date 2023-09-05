using Moq;
using Project_Library.Logic_And_Controller;

namespace Project_Tests.Tests
{
	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void Constructor_should_set_certain_string_to_GameWon_Property()
		{
			//Arrange
			var game = new GameLogic();

			//Act
			string expected = "BBBB,";
			string actual = game.GameWon;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Result_should_correct_handle_guessed_values()
		{
			//Arrange
			var mock = new Mock<IGame>();
			mock.Setup(r => r.GenerateActualValues()).Returns("1438");
			var game = new GameLogic();


			//Act
			string passedActual = mock.Object.GenerateActualValues();
			string passedGuessed = "2397";
			string expected = ",C";
			string actual = game.Result(passedActual, passedGuessed);

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
