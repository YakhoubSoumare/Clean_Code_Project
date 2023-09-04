using Project_Library.UIs;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			IUI ui = new UI();
			GameLogic game = new GameLogic();
			IStatistics statistics = new StatisticsCollection(ui);
			IController gameController = new GameController(ui, game, statistics);
			gameController.Run();
		}	
	}
}