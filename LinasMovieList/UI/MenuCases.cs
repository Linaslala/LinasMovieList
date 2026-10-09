using LinasMovieList.Repositories;

namespace LinasMovieList.UI
{
    internal class MenuCases
    {
        private readonly MovieRepository _repo = new MovieRepository;


        internal static void ShowAllMovies()
        {
            throw new NotImplementedException();
        }

        public void ShowAllMovies(MovieRepository repo)
        {
            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }
        }


        //                foreach (var genre in repo.GetAllGenres())
        //            {
        //                Console.WriteLine(genre);
        //            }

        //    Console.Write("Ange genre-id: ");
        //            int genreInput = int.Parse(Console.ReadLine());
        //    Console.Write("Ange titel: ");
        //            string titleInput = Console.ReadLine();
        //    Console.Write("Ange år: ");
        //            int yearInput = int.Parse(Console.ReadLine());

        //    var newMovie = new Movie
        //    {
        //        Title = titleInput,
        //        ReleaseYear = yearInput,
        //        GenreId = genreInput
        //    };

        //    int rows = repo.AddMovie(newMovie);

        //            if (rows == 1)
        //            {
        //                Console.Write("Filmen lades till!\n");
        //            }

        //foreach (var movie in repo.GetAllMovies())
        //{
        //    Console.WriteLine(movie);
        //}

        //}

    }
}
