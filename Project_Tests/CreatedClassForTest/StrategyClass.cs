
using Project_Library.Controller;
using Project_Library.Logic;

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
