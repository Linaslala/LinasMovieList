using LinasMovieList.Models;
using LinasMovieList.Repositories;

namespace LinasMovieList.UI
{
    internal class MenuCases
    {
        private readonly MovieRepository _repo = new MovieRepository();

        public void ShowAllMovies()
        {
            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }
        }

        public void SearchByGenre()
        {
            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }

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

            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        public void AddMovie()
        {
            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }

            Console.Write("Ange genre-id: ");
            int genreInput = int.Parse(Console.ReadLine());
            Console.Write("Ange titel: ");
            string titleInput = Console.ReadLine();
            Console.Write("Ange år: ");
            int yearInput = int.Parse(Console.ReadLine());

            var newMovie = new Movie
            {
                Title = titleInput,
                ReleaseYear = yearInput,
                GenreId = genreInput
            };

            int rows = _repo.AddNewMovie(newMovie);

            if (rows == 1)
            {
                Console.Write("Filmen lades till!\n");
            }

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }
        }

        public void DeleteMovie()
        {
            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

            Console.Write("Ange movie-id: ");
            int movieInput = int.Parse(Console.ReadLine());

            int rows = _repo.DeleteMovieFromDb(movieInput);

            if (rows == 1)
            {
                Console.Write("Filmen togs bort!\n");
            }

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }
        }
    }
}
