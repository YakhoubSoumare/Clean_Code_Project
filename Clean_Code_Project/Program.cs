using Project_Library.UIs;
using Project_Library.Logic_And_Controller;
using Project_Library.StatisticCollections;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string path = "result.txt";
			IFileManager fileManager = new FileManager(path);
			IUI ui = new UI();
			IGame game = new GameLogic();
			IStatistics statistics = new StatisticsCollection(ui, fileManager);
			IController gameController = new GameController(ui, game, statistics);
			gameController.Run();
		}	
	}
}