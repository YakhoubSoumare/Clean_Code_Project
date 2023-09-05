using Project_Library.PlayerDatas;

namespace Project_Tests.Tests
{
	[TestClass]
	public class PlayerDataTest
	{
		[TestMethod]
		public void Update_should_update_number_of_games()
		{
			//Arrange
			var playerData = new PlayerData("yakhoub", 1);

			//Act
			playerData.Update(6);
			int expected = 2;
			int actual = playerData.NumberOfGames;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Update_should_update_average()
		{
			//Arrange
			var playerData = new PlayerData("yakhoub", 5);

			//Act
			playerData.Update(7);
			double expected = 6;
			double actual = playerData.Average();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Equals_should_match_name()
		{
			//Arrange
			var playerData = new PlayerData("yakhoub", 5);
			var comparedData = new PlayerData("yakhoub", 1);

			//Act
			bool actual = playerData.Equals(comparedData);

			//Assert
			Assert.IsTrue(actual);
		}
	}
}
