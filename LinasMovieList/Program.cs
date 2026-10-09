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

            var genres = repo.GetAllGenres();

            foreach (var genre in genres)
            {
                Console.WriteLine(genre);
            }

        }
    }
}
