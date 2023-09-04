using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			string expected = game.GameWon;

			//Assert
			Assert.AreEqual("BBBB,", game.GameWon);
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

			//Assert
			Assert.AreEqual(expected, game.Result(passedActual, passedGuessed));
		}
	}
}
