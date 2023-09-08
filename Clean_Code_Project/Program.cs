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
			string path = @"GameResults\\ShouldNeverBeAccessed.txt";
			IFileManager fileManager = creator.CreateFileManager(path);
			fileManager.SetPath(@"GameResults\\MooGame.txt");
			IUI ui = creator.CreateUI();
			IGameLogic game = creator.CreateMooGame();
			IStatistics statistics = creator.CreateStatistics(ui, fileManager);
			IGameController gameController = creator.CreateGameController(ui, game, statistics);
			//Console.WriteLine(typeof(GameController).Assembly.GetName().Name);
			gameController.Run();
			fileManager.SetPath(@"GameResults\\SecondGame.txt");
			gameController.SetGame(creator.CreateSecondGame());
			gameController.Run();
		}	
	}
}