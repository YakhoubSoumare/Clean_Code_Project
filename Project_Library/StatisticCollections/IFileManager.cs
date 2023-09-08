
namespace Project_Library.StatisticCollections
{
	public interface IFileManager
	{
		StreamWriter StreamWriter();
		StreamReader StreamReader();
		void SetPath(string path);
	}
}
