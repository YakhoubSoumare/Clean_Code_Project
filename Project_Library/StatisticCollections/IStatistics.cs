
namespace Project_Library.StatisticCollections
{
	public interface IStatistics
	{
		void Show();
		void Store(string name, int attempts);
	}
}