using LinasMovieList.Data;
using LinasMovieList.Repositories;
using Microsoft.Data.SqlClient;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var db = new DatabaseConnection();

            //using var connection = db.GetConnection();
            //connection.Open();

            var repo = new MovieRepository();
            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

        }
    }
}
