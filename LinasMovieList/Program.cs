using Microsoft.Data.SqlClient;
using LinasMovieList.Data;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new DatabaseConnection();

            using var connection = db.GetConnection();
            connection.Open();
            Console.WriteLine("Connected!");
        }
    }
}
