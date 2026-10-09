using LinasMovieList.Data;
using LinasMovieList.Repositories;
using Microsoft.Data.SqlClient;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repo = new MovieRepository();

            Console.Write("Ange genre: ");
            string genreNameInput = Console.ReadLine()!;

            var movies = repo.GetMovieByGenre(genreNameInput);

            if(movies.Count == 0)
            {
                Console.WriteLine("Inga filmer finns i denna genre");
            }

            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

        }
    }
}
