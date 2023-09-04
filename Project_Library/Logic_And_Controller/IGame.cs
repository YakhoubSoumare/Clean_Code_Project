namespace Project_Library.Logic_And_Controller
{
	public interface IGame
	{
		string GameWon { get; }

		string GenerateActualValues();
		string Result(string actualValues, string guessedValues);
	}
}