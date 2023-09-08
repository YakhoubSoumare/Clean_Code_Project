using Project_Library.UIs;
using Project_Library.StatisticCollections;
using Project_Library.Creators;

namespace Project_Library.Logic_And_Controller
{
	public class GameController : IGameController
	{
		IGameLogic game;
		IUI ui;
		IStatistics statistics;

		bool playOn;
		string name;
		string actualValues;
		int attempts;
		string resultOfRound;
		string guessedValues;

		public GameController(IUI ui, IGameLogic game, IStatistics statistics)
		{
			this.ui = ui;
			this.statistics = statistics;
			this.game = game;
		}
		

		public void Run()
		{	
			playOn = true;
			AskAndDisplayUserName();
			Play();
		}

		public void SetGame(IGameLogic game)
		{
			this.game = game;
		}

		void AskAndDisplayUserName()
		{
			ui.Display("Enter your user name:\n");
			name = ui.Input();
			ui.Display(name);
		}

		void Play()
		{
			do
			{
				attempts = 0;
				Start();
				Guess();
				SaveResult();
				ShowTopList();
				DisplaySuccess();
				Continue();
			} while (playOn);
		}

		void Start()
		{
			actualValues = game.GenerateActualValues();
			ui.Display("New game:\n");
			ui.Display("For practice, number is: " + actualValues + "\n");
		}

		void Guess()
		{
			do
			{
				attempts++;
				guessedValues = ui.Input();
				ui.Display(guessedValues + "\n");
				resultOfRound = game.Result(actualValues, guessedValues);
				ui.Display(resultOfRound + "\n");
			} while (!Correct());
		}

		void Continue()
		{
			ui.Display("Continue ? ");
			string answer = ui.Input();
			bool playStop = (answer == null || answer == "" || answer.Substring(0, 1) == "n");
			playOn = !playStop;
			if(playOn is true)
			{
				CheckGameSwitch();
			}
		}

		bool Correct() 
			=> (resultOfRound == game.GameWon);

		void SaveResult()
			=> statistics.Store(name, attempts);

		void ShowTopList()
			=> statistics.Show();

		void DisplaySuccess()
			=> ui.Display("Correct, it took " + attempts + " guesses");

		void CheckGameSwitch()
		{
			ui.Display("Switch Game ? \"n or Enter-key for no\" || \"any other-key for yes\"");
			string answer = ui.Input();
			bool stayCurrentGame = (answer == null || answer == "" || answer.Substring(0, 1) == "n");
			if(!stayCurrentGame)
			{
				IGameLogic game = ClassCreator.CreateSecondGame();
				SetGame(game);
			}
		}
	}
}
