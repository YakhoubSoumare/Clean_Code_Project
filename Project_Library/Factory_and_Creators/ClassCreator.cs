using Project_Library.Controller;
using Project_Library.Logic;
using Project_Library.PlayerDatas;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Library.Factory_and_Creators
{
	public static class ClassCreator
	{
		public static GameController CreateGameController(IUI ui, IGameLogic game, IStatistics statistics)
		{
			return new GameController(ui, game, statistics);
		}

		public static FileManager CreateFileManager()
		{
			return new FileManager("");
		}

		public static MooGame CreateMooGame()
		{
			return new MooGame();
		}
		public static SecondGame CreateSecondGame()
		{
			return new SecondGame();
		}

		public static PlayerData CreatePlayerData(string name, int attemptsOfAllPlays)
		{
			return new PlayerData(name, attemptsOfAllPlays);
		}

		public static StatisticCollection CreateStatistics(IUI ui, IFileManager fileManager)
		{
			return new StatisticCollection(ui, fileManager);
		}

		public static UI CreateUI()
		{
			return new UI();
		}
	}
}
