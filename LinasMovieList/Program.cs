using LinasMovieList.UI;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var menuCases = new MenuCases();
            var startMenu = new StartMenu(menuCases);

            startMenu.Run();
        }

    }
}
