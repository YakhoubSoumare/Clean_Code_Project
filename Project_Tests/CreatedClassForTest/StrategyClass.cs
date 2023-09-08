
using Project_Library.Logic_And_Controller;

namespace Project_Tests.CreatedClassForTest
{
	public class StrategyClass : IGameStrategy
	{
		internal IGameLogic Game { get; set; }
		public void SetGame(IGameLogic game)
		{
			Game = game;
		}
	}
}
