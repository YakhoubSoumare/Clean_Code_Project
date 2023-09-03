using System;
using System.IO;
using System.Collections.Generic;

namespace Clean_Code_Project
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			bool playOn = true;
			Console.WriteLine("Enter your user name:\n");
			string name = Console.ReadLine();

			while (playOn)
			{
				string actualValues = GenerateActualValues();


				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + actualValues + "\n");
				string guessedValues = Console.ReadLine();

				int attempts = 1;
				string resultOfRound = ResultOfRound(actualValues, guessedValues);
				Console.WriteLine(resultOfRound + "\n");
				while (resultOfRound != "BBBB,")
				{
					attempts++;
					guessedValues = Console.ReadLine();
					Console.WriteLine(guessedValues + "\n");
					resultOfRound = ResultOfRound(actualValues, guessedValues);
					Console.WriteLine(resultOfRound + "\n");
				}
				StreamWriter streamWriter = new StreamWriter("result.txt", append: true);
				streamWriter.WriteLine(name + "#&#" + attempts);
				streamWriter.Close();
				ShowTopList();
				Console.WriteLine("Correct, it took " + attempts + " guesses\nContinue?");
				string answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}
		static string GenerateActualValues()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		static string ResultOfRound(string actualValues, string guessedValues)
		{
			int rightAtIncorrectPosition = 0, rightAtCorrectPosition = 0;
			guessedValues += "    ";     // if player entered less than 4 chars
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


		static void ShowTopList()
		{
			StreamReader streamReader = new StreamReader("result.txt");
			List<PlayerData> playerDataCollection = new List<PlayerData>();
			string lineFromFile;
			while ((lineFromFile = streamReader.ReadLine()) != null)
			{
				string[] nameAndScore = lineFromFile.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData playerData = new PlayerData(name, guesses);
				int indexOfplayerData = playerDataCollection.IndexOf(playerData);
				if (indexOfplayerData < 0)
				{
					playerDataCollection.Add(playerData);
				}
				else
				{
					playerDataCollection[indexOfplayerData].Update(guesses);
				}


			}
			playerDataCollection.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData player in playerDataCollection)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
			}
			streamReader.Close();
		}
	}

	class PlayerData
	{
		public string Name { get; private set; }
		public int NumberOfGames { get; private set; }
		int attemptsOfAllPlays;


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NumberOfGames = 1;
			attemptsOfAllPlays = guesses;
		}

		public void Update(int guesses)
		{
			attemptsOfAllPlays += guesses;
			NumberOfGames++;
		}

		public double Average()
		{
			return (double)attemptsOfAllPlays / NumberOfGames;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}