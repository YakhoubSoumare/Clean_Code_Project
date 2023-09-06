using Project_Library.UIs;
using Project_Library.Logic_And_Controller;
using Project_Library.StatisticCollections;
using Project_Library.Creators;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			ICreator creator = new ClassCreator();
			string path = "result.txt";
			IFileManager fileManager = creator.CreateFileManager(path);
			IUI ui = creator.CreateUI();
			IGame game = creator.CreateGameLogic();
			IStatistics statistics = creator.CreateStatistics(ui, fileManager);
			IController gameController = creator.CreateController(ui, game, statistics);
			gameController.Run();
		}	
	}
}