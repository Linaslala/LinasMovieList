using LinasMovieList.Repositories;
using LinasMovieList.UI;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startMenu = new StartMenu();
            startMenu.Run();
        }
    }
}
