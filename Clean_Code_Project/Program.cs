using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Clean_Code_Project
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			GameController gameController = new GameController();
			gameController.Run();
		}	
	}
}