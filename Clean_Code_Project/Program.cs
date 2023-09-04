using Project_Library.UIs;
using Project_Library.Logic_And_Controller;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			IUI ui = new UI();
			IGame game = new GameLogic();
			IStatistics statistics = new StatisticsCollection(ui);
			IController gameController = new GameController(ui, game, statistics);
			gameController.Run();
		}	
	}
}