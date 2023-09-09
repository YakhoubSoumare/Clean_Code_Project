namespace Project_Library.Logic
{
	public class MooGame : IGameLogic
	{
		public string GameWon { get; private set; }

		public MooGame()
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
			if (actualValues == guessedValues)
			{
				return GameWon;
			}

			guessedValues = (guessedValues.Length > actualValues.Length) ?
				guessedValues.Substring(0, actualValues.Length) : guessedValues.PadRight(guessedValues.Length + ((actualValues.Length) - guessedValues.Length));

			int correctPosition = 0, wrongPosition = 0;
			foreach (char digit in guessedValues)
			{
				if (actualValues.Contains(digit) && (guessedValues.IndexOf(digit) == (actualValues.IndexOf(digit))))
				{
					correctPosition++;
				}
				else if (actualValues.Contains(digit) && (guessedValues.IndexOf(digit) != (actualValues.IndexOf(digit))))
				{
					wrongPosition++;
				}
			}

			string perfectAnswer = GameWon.Substring(0, correctPosition);
			int spaceLeft = (GameWon.Length - 1) - correctPosition;
			string wrongPositionAnswer = (spaceLeft > wrongPosition || spaceLeft == wrongPosition) ?
				"CCCC".Substring(correctPosition, wrongPosition) : "CCCC".Substring(correctPosition, spaceLeft);
			return perfectAnswer + "," + wrongPositionAnswer;
		}
	}
}
