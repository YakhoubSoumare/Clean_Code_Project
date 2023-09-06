using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library.Logic_And_Controller
{
	public class GameLogic : IGame
	{
		public string GameWon { get; private set; }

		public GameLogic()
		{
			GameWon = "BBBB,";
		}

		public string GenerateActualValues()
		{
			Random randomGenerator = new Random();
			string actualValues = "";
			HashSet<int> generated = new HashSet<int>();
			while (generated.Count < 4)
			{
				generated.Add(randomGenerator.Next(10));
			}
			
			foreach(var digit in generated)
			{
				actualValues += digit.ToString();
			}
			return actualValues;
		}

		public string Result(string actualValues, string guessedValues)
		{
			int rightAtIncorrectPosition = 0, rightAtCorrectPosition = 0;
			guessedValues = (guessedValues.Length > 3) ?
				guessedValues.Substring(0, 4) : guessedValues.PadRight(guessedValues.Length + (4 - guessedValues.Length));     // if player entered less than 4 chars

			for (int indexOfActualValue = 0; indexOfActualValue < 4; indexOfActualValue++)
			{
				for (int indexOfGuessedValue = 0; indexOfGuessedValue < 4; indexOfGuessedValue++)
				{
					if (actualValues[indexOfActualValue] == guessedValues[indexOfGuessedValue])
					{
						if (indexOfActualValue == indexOfGuessedValue)
						{
							rightAtCorrectPosition++;
						}
						else
						{
							rightAtIncorrectPosition++;
						}
					}
				}
			}
			return "BBBB".Substring(0, rightAtCorrectPosition) + "," + "CCCC".Substring(0, rightAtIncorrectPosition);
		}
	}
}
