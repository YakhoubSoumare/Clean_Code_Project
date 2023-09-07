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
			var game = new MooGame();

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
			var game = new MooGame();
			var mock = new Mock<IGameLogic>();
			
			if(game.GetType() == typeof(MooGame))
			{
				mock.Setup(r => r.GenerateActualValues()).Returns("1438");
			}
			else if(game.GetType() == typeof(SecondGame))
			{
				mock.Setup(r => r.GenerateActualValues()).Returns("143868");
			}


			//Act
			string passedGuessed = "";
			string expected = "";
			string passedActual = mock.Object.GenerateActualValues();
			if (game.GetType() == typeof(MooGame))
			{
				passedGuessed = "2397";
				expected = ",C";
			}
			else if (game.GetType() == typeof(SecondGame))
			{
				passedGuessed = "239789";
				expected = ",CC";
			}

			string actual = game.Result(passedActual, passedGuessed);

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
