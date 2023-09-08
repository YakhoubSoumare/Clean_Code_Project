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
			string path = @"GameResults\\ShouldNeverBeAccessed.txt";
			IFileManager fileManager = ClassCreator.CreateFileManager(path);
			fileManager.SetPath(@"GameResults\\MooGame.txt");
			IUI ui = ClassCreator.CreateUI();
			IGameLogic game = ClassCreator.CreateMooGame();
			IStatistics statistics = ClassCreator.CreateStatistics(ui, fileManager);
			IGameController gameController = ClassCreator.CreateGameController(ui, game, statistics);
			gameController.Run();

			//fileManager.SetPath(@"GameResults\\SecondGame.txt");
			//gameController.SetGame(ClassCreator.CreateSecondGame());
			//gameController.Run();
		}	
	}
}