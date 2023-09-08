
using Project_Library.PlayerDatas;
using Project_Library.UIs;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("GameController")]
namespace Project_Library.StatisticCollections
{
	public class StatisticCollection : IStatistics
	{
		IUI ui;
		List<PlayerData> playerDataCollection;
		IFileManager fileManager;
		public StatisticCollection(IUI ui, IFileManager fileManager)
		{
			this.ui = ui;
			playerDataCollection = new List<PlayerData>();
			this.fileManager = fileManager;
		}

		public void Store(string name, int attempts)
		{
			using (var streamWriter = fileManager.StreamWriter())
			{
				streamWriter.WriteLine(name + "#&#" + attempts);
			}
		}

		public void ShowResult()
		{
			playerDataCollection.Clear();
			playerDataCollection = ReadStream();
			Sort(playerDataCollection);
			ui.Display(string.Format("{0,-20}{1,5:D}{2,9:F2}", "Player", "Games", "Average"));
			playerDataCollection.ForEach(playerData =>
				ui.Display(string.Format("{0,-20}{1,5:D}{2,9:F2}", playerData.Name, playerData.NumberOfGames, playerData.Average())));
		}

		public void Show()
		{
			playerDataCollection.Clear();
			playerDataCollection = ReadStream();
			Sort(playerDataCollection);
			ui.Display(string.Format("{0,-20}{1,5:D}{2,9:F2}", "Player", "Games", "Average"));
			playerDataCollection.ForEach(playerData =>
				ui.Display(string.Format("{0,-20}{1,5:D}{2,9:F2}", playerData.Name, playerData.NumberOfGames, playerData.Average())));

			
		}

		List<PlayerData> ReadStream()
		{
			using (var streamReader = fileManager.StreamReader())
			{
				string lineFromFile = string.Empty;
				while ((lineFromFile = streamReader.ReadLine()) != null)
				{
					string[] nameAndScore = lineFromFile.Split(new string[] { "#&#" }, StringSplitOptions.None);
					string name = nameAndScore[0];
					int guesses = Convert.ToInt32(nameAndScore[1]);
					int playerDataIndex = GetPlayerIndex(name);
					if (playerDataIndex < 0)
					{
						playerDataCollection.Add(new PlayerData(name, guesses));
					}
					else
					{
						playerDataCollection[playerDataIndex].Update(guesses);
					}
				}
				streamReader.Close();
			}
			
			return playerDataCollection;
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
