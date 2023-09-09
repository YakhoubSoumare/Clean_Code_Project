using Project_Library.UIs;
using Project_Library.Controller;
using Project_Library.StatisticCollections;
using Project_Library.Factory_and_Creators;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var fileManager = ClassCreator.CreateFileManager();
			var ui = ClassCreator.CreateUI();
			var game = ClassCreator.CreateMooGame();
			var statistics = ClassCreator.CreateStatistics(ui, fileManager);
			var gameController = ClassCreator.CreateGameController(ui, game, statistics);
			gameController.Run();
		}	
	}
}