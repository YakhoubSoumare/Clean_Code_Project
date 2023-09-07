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
	public class ClassCreator : ICreator
	{
		public IController CreateController(IUI ui, IGameLogic game, IStatistics statistics)
		{
			return new GameController(ui, game, statistics);
		}

		public IFileManager CreateFileManager(string path)
		{
			return new FileManager(path);
		}

		public IGameLogic CreateGameLogic()
		{
			return new MooGame();
			//return new SecondGame();
		}

		public PlayerData CreatePlayerData(string name, int attemptsOfAllPlays)
		{
			return new PlayerData(name, attemptsOfAllPlays);
		}

		public IStatistics CreateStatistics(IUI ui, IFileManager fileManager)
		{
			return new StatisticCollection(ui, fileManager);
		}

		public IUI CreateUI()
		{
			return new UI();
		}
	}
}
