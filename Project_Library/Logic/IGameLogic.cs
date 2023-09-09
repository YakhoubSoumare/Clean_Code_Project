namespace Project_Library.Logic
{
	public interface IGameLogic
	{
		string GameWon { get; }

		string GenerateActualValues();
		string Result(string actualValues, string guessedValues);
	}
}