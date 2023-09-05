
namespace Project_Library.StatisticCollections
{
	public class FileManager : IFileManager
	{
		string path;
		public FileManager(string path)
		{
			this.path = path;
		}

		public StreamWriter StreamWriter()
		{
			return new StreamWriter(path, append: true);
		}
		public StreamReader StreamReader()
		{
			return new StreamReader(path);
		}
	}
}
