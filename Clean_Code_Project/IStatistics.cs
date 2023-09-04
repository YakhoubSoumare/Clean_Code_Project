namespace Clean_Code_Project
{
	public interface IStatistics
	{
		void Show();
		void Store(string name, int attempts);
	}
}