using LinasMovieList.Models;
using LinasMovieList.Repositories;

namespace LinasMovieList.UI
{
    internal class MenuCases
    {
        private readonly MovieRepository _repo = new MovieRepository();

        public void ShowAllMovies()
        {
            Console.Clear();

            Console.WriteLine("=== FILMLISTA ===\n");

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

            Console.ReadKey();
        }

        public void SearchByGenre()
        {
            Console.Clear();

            Console.WriteLine("=== FILTRERA FILMER EFTER GENRE ===\n");

            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }

            Console.WriteLine();

            Console.Write("Ange genre-id: ");
            if (!int.TryParse(Console.ReadLine(), out int genreIdInput))
            {
                Console.WriteLine("Du måste skriva en siffra.");
                return;
            }

            List<Movie> movies = _repo.GetMoviesByGenre(genreIdInput);

            if (movies.Count == 0)
            {
                Console.WriteLine("Inga filmer hittades.");
                return;
            }

            Console.WriteLine();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            Console.ReadKey();
        }

        public void AddMovie()
        {
            Console.Clear();

            Console.WriteLine("=== LÄGG TILL NY FILM ===\n");

            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }

            Console.WriteLine();

            Console.Write("Ange genre-id: ");
            if (!int.TryParse(Console.ReadLine(), out int genreInput))
            {
                Console.WriteLine("Du måste skriva en siffra.");
                return;
            }
            Console.Write("Ange titel: ");
            string titleInput = Console.ReadLine();
            Console.Write("Ange år: ");
            if (!int.TryParse(Console.ReadLine(), out int yearInput))
            {
                Console.WriteLine("Du måste skriva en siffra.");
                return;
            }

            var newMovie = new Movie
            {
                Title = titleInput,
                ReleaseYear = yearInput,
                GenreId = genreInput
            };

            int rows = _repo.AddNewMovie(newMovie);

            Console.WriteLine();

            if (rows == 1)
            {
                Console.Write("Filmen lades till!\n");
            }

            Console.ReadKey();

        }

        public void DeleteMovie()
        {
            Console.Clear();

            Console.WriteLine("=== TA BORT FILM FRÅN DATABASEN ===\n");

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine();

            Console.Write("Ange film-id: ");
            if (!int.TryParse(Console.ReadLine(), out int movieInput))
            {
                Console.WriteLine("Du måste skriva en siffra.");
                return;
            }

            int rows = _repo.DeleteMovieFromDb(movieInput);

            Console.WriteLine();

            if (rows == 1)
            {
                Console.Write("Filmen togs bort!\n");
            }

            Console.ReadKey();
        }
    }
}
