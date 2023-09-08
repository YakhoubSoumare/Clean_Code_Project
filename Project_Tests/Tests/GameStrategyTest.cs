
using Project_Library.Logic_And_Controller;
using Project_Tests.CreatedClassForTest;

namespace Project_Tests.Tests
{
	[TestClass]
	public class GameStrategyTest
	{
		[TestMethod]
		public void SetGame_should_alter_game()
		{
			//Arrange
			var strategy = new StrategyClass();
			strategy.Game = new MooGame();

			//Act
			strategy.SetGame(new SecondGame());
			var expected = typeof(SecondGame);
			var actual = strategy.Game.GetType();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
