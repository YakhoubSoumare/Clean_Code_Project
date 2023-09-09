
namespace Project_Library.StatisticCollections
{
	public interface IStatistics
	{
		void Show(string folder);
		void Store(string name, int attempts);
		IFileManager GetFileManager();
		void SetFileManager(IFileManager fileManager);
	}
}