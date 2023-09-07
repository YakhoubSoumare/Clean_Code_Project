using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library.Logic_And_Controller
{
	public class SecondGame : IGameLogic
	{
		public string GameWon {get; private set;}

		public SecondGame()
		{
			GameWon = "BBBBBB,";
		}

		public string GenerateActualValues()
		{
			Random randomGenerator = new Random();
			string actualValues = "";
			for(int i = 0; i < GameWon.Length - 1; i++)
			{
				actualValues += randomGenerator.Next(10);
			}
			return actualValues;
		}

		public string Result(string actualValues, string guessedValues)
		{
			if (actualValues == guessedValues) 
			{
				return GameWon;
			}

			guessedValues = (guessedValues.Length > actualValues.Length) ?
				guessedValues.Substring(0, actualValues.Length) : guessedValues.PadRight(guessedValues.Length + ((actualValues.Length) - guessedValues.Length));

			int correctPosition = 0, wrongPosition = 0;
			foreach(char digit in guessedValues)
			{
				if(actualValues.Contains(digit) && (guessedValues.IndexOf(digit) == (actualValues.IndexOf(digit))))
				{
					correctPosition++;
				}else if(actualValues.Contains(digit) && (guessedValues.IndexOf(digit) != (actualValues.IndexOf(digit))))
				{
					wrongPosition++;
				}
			} 


			string perfectAnswer = GameWon.Substring(0, correctPosition);
			int spaceLeft = (GameWon.Length - 1) - correctPosition;
			string wrongPositionAnswer = (spaceLeft > wrongPosition || spaceLeft == wrongPosition) ?
				"CCCCCC".Substring(correctPosition, wrongPosition) : "CCCCCC".Substring(correctPosition, spaceLeft);
			return perfectAnswer + "," + wrongPositionAnswer;
		}
	}
}
