using Project_Library.Controller;

namespace Project_Library.Observer_Pattern_Pillars
{
	public interface IObserver
	{
		void Update(IGameController subject);
	}
}
