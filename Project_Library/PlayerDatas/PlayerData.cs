using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library.PlayerDatas
{
	public class PlayerData
	{
		public string Name { get; private set; }
		public int NumberOfGames { get; private set; }
		int attemptsOfAllPlays;


		public PlayerData(string name, int attemptsOfAllPlays)
		{
			this.Name = name;
			NumberOfGames = 1;
			this.attemptsOfAllPlays = attemptsOfAllPlays;
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
