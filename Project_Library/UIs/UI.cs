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

	}
}
