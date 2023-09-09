using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Library.Observer_Pattern_Pillars;

namespace Project_Library.Controller
{
    public interface IGameController: IController, IGameStrategy, ISubject
	{
	}
}
