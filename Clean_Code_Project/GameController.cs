using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Code_Project
{
	public class GameController
	{
		GameLogic game = new GameLogic();
		UI ui = new UI();
		StaticticsCollection statistics = new StaticticsCollection();

		public bool PlayOn { get; private set; }

		string name;
		string actualValues;
		int attempts;
		string resultOfRound;
		string guessedValues;

		public void Run()
		{
			PlayOn = true;

			AskUserName();
			Play();
		}

		void AskUserName()
		{
			ui.Display("Enter your user name:\n");
			name = ui.Input();
			ui.Display(name);
		}

		public void Play()
		{
			do
			{
				GenerateValues();
				ui.Display("New game:\n");
				ui.Display("For practice, number is: " + actualValues + "\n");

				GuessUntilCorrect();
				SaveResult();
				ShowTopList();
				DisplaySuccess();
				Continue();
			} while (PlayOn);
		}

		public void Continue()
		{
			bool wantExit = CheckContinue();
			PlayOn = !wantExit;
		}

		bool CheckContinue()
		{
			ui.Display("Continue ? ");
			string answer = ui.Input();
			return (answer != null && answer != "" && answer.Substring(0, 1) == "n");
		}

		void CheckAndDisplayResult(string actualValues, string guessedValues)
		{
			resultOfRound = game.Result(actualValues, guessedValues);
			ui.Display(resultOfRound + "\n");
		}

		void GuessUntilCorrect()
		{
			do
			{
				Guess();
				CheckAndDisplayResult(actualValues, guessedValues);
			} while (!Correct());
		}
		bool Correct()
		{
			return (resultOfRound == game.GameWon);
		}

		void SaveResult()
		{
			statistics.Store(name, attempts);
		}

		void GenerateValues()
		{
			actualValues = game.GenerateActualValues();
		}

		void Guess()
		{
			attempts++;
			guessedValues = ui.Input();
			ui.Display(guessedValues + "\n");
		}

		void ShowTopList()
		{
			statistics.Show();
		}

		void DisplaySuccess()
		{
			ui.Display("Correct, it took " + attempts + " guesses");
		}
	}
}
