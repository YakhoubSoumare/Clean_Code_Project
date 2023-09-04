using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library.UIs
{
	public class UI : IUI
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
