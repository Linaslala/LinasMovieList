using LinasMovieList.Data;
using LinasMovieList.Repositories;
using Microsoft.Data.SqlClient;
using LinasMovieList.Models;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repo = new MovieRepository();
                       

            foreach (var genre in repo.GetAllGenres())
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

            int rows = repo.AddMovie(newMovie);

            if (rows == 1)
            {
                Console.Write("Filmen lades till!\n");
            }

            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

        }
    }
}
