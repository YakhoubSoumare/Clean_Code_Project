
using System;
using Project_Library.Controller;
using Project_Library.Observer_Pattern_Pillars;

namespace Project_Library.StatisticCollections
{
	public interface IFileManager
	{
		StreamWriter StreamWriter();
		StreamReader StreamReader(string path);
		void SetPath(string path);
		IFileManager GetClass();
		void Update(IGameController subject);
	}
}
