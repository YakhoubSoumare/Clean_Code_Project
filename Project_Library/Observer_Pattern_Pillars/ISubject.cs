using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Library.StatisticCollections;

namespace Project_Library.Observer_Pattern_Pillars
{
	public interface ISubject
	{
		void Attach(IFileManager observer);
		void Detach(IFileManager observer);
		void Notify();
	}
}
