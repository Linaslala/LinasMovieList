namespace LinasMovieList.UI
{
    internal class StartMenu
    {
        private readonly MenuCases _menuCase;

        public StartMenu(MenuCases menuCase)
        {
            _menuCase = menuCase;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("=== LINAS MOVIE SHACK ===\n");
                Console.WriteLine("1. Visa alla filmer");
                Console.WriteLine("2. Sök filmer efter genre");
                Console.WriteLine("3. Lägg till film");
                Console.WriteLine("4. Ta bort film");
                Console.WriteLine("0. Avsluta\n");
                Console.Write("Välj: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _menuCase.ShowAllMovies();
                        break;
                    case "2":
                        _menuCase.SearchByGenre();
                        break;
                    case "3":
                        _menuCase.AddMovie();
                        break;
                    case "4":
                        _menuCase.DeleteMovie();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine();
                        Console.WriteLine("Hej då!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }
        }

    }

}
