using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Code_Project
{
	public class UI
	{
		public void Display(string message)
		{
			Console.WriteLine(message);
		}

		public string Input()
		{
			string output = Console.ReadLine();
			return output;
		}

		public void Exit()
		{
			System.Environment.Exit(0);
		}
	}
}
