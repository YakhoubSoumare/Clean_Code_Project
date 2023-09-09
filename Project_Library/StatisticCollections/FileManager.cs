using System.IO;
using Project_Library.Controller;
using Project_Library.Observer_Pattern_Pillars;

namespace Project_Library.StatisticCollections
{
    public class FileManager : IFileManager
	{
		string path = "";
		public FileManager(string path)
		{
			this.path = path;
		}

		public void SetPath(string path)
		{
			this.path = path;
		}

		public IFileManager GetClass()
		{
			return this;
		}

		public StreamWriter StreamWriter()
		{
			return new StreamWriter(path, append: true);
		}
		public StreamReader StreamReader(string path)
		{
			return new StreamReader(path);
		}

		public void Update(IGameController subject)
		{
			string newPath = (subject as GameController).State;
			if (newPath != this.path)
			{
				SetPath(newPath);
			}
		}
	}
}
