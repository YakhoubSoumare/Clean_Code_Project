
using Project_Library.UIs;

namespace Clean_Code_Project
{
	public class StatisticsCollection : IStatistics
	{
		IUI ui;
		List<PlayerData> playerDataCollection;
		public StatisticsCollection(IUI ui)
		{
			this.ui = ui;
			playerDataCollection = new List<PlayerData>();
		}

		public void Store(string name, int attempts)
		{
			StreamWriter streamWriter = new StreamWriter("result.txt", append: true);
			streamWriter.WriteLine(name + "#&#" + attempts);
			streamWriter.Close();
		}

		public void Show()
		{
			StreamReader streamReader = new StreamReader("result.txt");
			playerDataCollection.Clear();

			ReadStream(streamReader);
			Sort(playerDataCollection);
			ui.Display(string.Format("{0,-20}", "Player   games average"));
			playerDataCollection.ForEach(playerData =>
				ui.Display(string.Format("{0,-20}{1,5:D}{2,9:F2}", playerData.Name, playerData.NumberOfGames, playerData.Average())));

			streamReader.Close();
		}

		void ReadStream(StreamReader streamReader)
		{
			string lineFromFile;
			while ((lineFromFile = streamReader.ReadLine()) != null)
			{
				string[] nameAndScore = lineFromFile.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				int playerDataIndex = GetPlayerIndex(name);
				if(playerDataIndex < 0)
				{
					playerDataCollection.Add(new PlayerData(name, guesses));
					
				}
				else
				{
					playerDataCollection[playerDataIndex].Update(guesses);
				}	
			}
		}

		void Sort(List<PlayerData> playerDataCollection)
		{
			playerDataCollection.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
		}

		int GetPlayerIndex(string name)
		{
			int indexOfPlayerData = playerDataCollection.FindIndex(x => x.Name == name);
			return indexOfPlayerData;
		}
	}
}
