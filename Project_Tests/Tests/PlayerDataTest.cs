using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			PlayerData playerData = new PlayerData("yakhoub", 1);

			//Act
			playerData.Update(6);

			//Assert
			Assert.AreEqual(2, playerData.NumberOfGames);
		}

		[TestMethod]
		public void Update_should_update_average()
		{
			//Arrange
			PlayerData playerData = new PlayerData("yakhoub", 5);

			//Act
			playerData.Update(7);

			//Assert
			Assert.AreEqual(6, playerData.Average());
		}

		[TestMethod]
		public void Equals_should_match_name()
		{
			//Arrange
			PlayerData playerData = new PlayerData("yakhoub", 5);
			var comparedData = new PlayerData("yakhoub", 1);

			//Act
			bool expected = playerData.Equals(comparedData);

			//Assert
			Assert.IsTrue(expected);
		}
	}
}
