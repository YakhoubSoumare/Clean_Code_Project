using Project_Library.Logic_And_Controller;
using Project_Library.PlayerDatas;
using Project_Library.StatisticCollections;
using Project_Library.UIs;

namespace Project_Library.Creators
{
	public interface ICreator
	{
		IController CreateController(IUI ui, IGame game, IStatistics statistics);
		IGame CreateGameLogic();
		PlayerData CreatePlayerData(string name, int attemptsOfAllPlays);
		IFileManager CreateFileManager(string path);
		IStatistics CreateStatistics(IUI ui, IFileManager fileManager);
		IUI CreateUI();
	}
}
