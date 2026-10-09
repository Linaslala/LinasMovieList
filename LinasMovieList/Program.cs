using LinasMovieList.Repositories;


namespace LinasMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repo = new MovieRepository();

            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

            Console.Write("\nAnge movie-id: ");
            int movieInput = int.Parse(Console.ReadLine());

            int rows = repo.DeleteMovie(movieInput);

            if (rows == 1)
            {
                Console.Write("\nFilmen togs bort!\n");
            }

            Console.ReadKey();
            Console.WriteLine();

            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

        }
    }
}
