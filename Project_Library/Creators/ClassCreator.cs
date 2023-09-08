using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Project_Library.Logic_And_Controller;
using Project_Library.PlayerDatas;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Library.Creators
{
	public static class ClassCreator
	{
		public static IGameController CreateGameController(IUI ui, IGameLogic game, IStatistics statistics)
		{
			return new GameController(ui, game, statistics);
		}

		public static IFileManager CreateFileManager(string path)
		{
			return new FileManager(path);
		}

		public static IGameLogic CreateMooGame()
		{
			return new MooGame();
		}
		public static IGameLogic CreateSecondGame()
		{
			return new SecondGame();
		}

		public static PlayerData CreatePlayerData(string name, int attemptsOfAllPlays)
		{
			return new PlayerData(name, attemptsOfAllPlays);
		}

		public static IStatistics CreateStatistics(IUI ui, IFileManager fileManager)
		{
			return new StatisticCollection(ui, fileManager);
		}

		public static IUI CreateUI()
		{
			return new UI();
		}
	}
}
