using LinasMovieList.Data;
using LinasMovieList.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinasMovieList.Repositories
{
    internal class MovieRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public MovieRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public List<Movie> GetAllMovies()
        {
            //En tom lista som fylls på
            var movies = new List<Movie>();

            //SQL-frågan (samma som min tidigare query i ssms)
            string sql = @"
                SELECT m.Id, m.Title, m.ReleaseYear, m.GenreId, g.GenreName
                FROM Movies m
                JOIN Genres g ON m.GenreId = g.Id
                ORDER BY m.Title";

            //Hämtar en anslutning och öppna den. using stänger den automatiskt.
            using var connection = _dbConnection.GetConnection();
            connection.Open();

            //Ett kommando bär SQL-frågan till databasen
            using var command = new SqlCommand(sql, connection);

            //Kör frågan. Readern perkar på svaret, rad för rad.
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie
                {
                    Id = reader.GetInt32(0),          // kolumn 0 i SELECT = m.Id
                    Title = reader.GetString(1),      // kolumn 1 = m.Title
                    ReleaseYear = reader.GetInt32(2), // kolumn 2 = m.ReleaseYear
                    GenreId = reader.GetInt32(3),     // kolumn 3 = m.GenreId
                    GenreName = reader.GetString(4)   // kolumn 4 = g.GenreName
                };

                movies.Add(movie);
            }

            return movies;
        }

        public List<Movie> GetMovieByGenre(string genreName)
        {
            //En tom lista som fylls på
            var movies = new List<Movie>();

            //SQL-frågan
            string sqlQuery = @"
                SELECT m.Id, m.Title, m.ReleaseYear, m.GenreId, g.GenreName
                FROM Movies m
                JOIN Genres g ON m.GenreId = g.Id
                WHERE g.GenreName = @GenreName
                ORDER BY m.Title";

            //Hämtar en anslutning och öppna den. using stänger den automatiskt.
            using var connection = _dbConnection.GetConnection();
            connection.Open();

            //Ett kommando bär SQL-frågan till databasen
            using var command = new SqlCommand(sqlQuery, connection);

            //Parametiserad fråga
            command.Parameters.AddWithValue("@GenreName", genreName);

            //Kör frågan. Readern perkar på svaret, rad för rad.
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie
                {
                    Id = reader.GetInt32(0),          // kolumn 0 i SELECT = m.Id
                    Title = reader.GetString(1),      // kolumn 1 = m.Title
                    ReleaseYear = reader.GetInt32(2), // kolumn 2 = m.ReleaseYear
                    GenreId = reader.GetInt32(3),     // kolumn 3 = m.GenreId
                    GenreName = reader.GetString(4)   // kolumn 4 = g.GenreName
                };

                movies.Add(movie);
            }

            return movies;
        }

        public List<Genre> GetAllGenres()
        {
            //En tom lista som fylls på
            var genres = new List<Genre>();

            //SQL-frågan (samma som min tidigare query i ssms)
            string sqlQuery = @"
                SELECT g.Id, g.GenreName
                FROM Genres g
                ORDER BY g.GenreName";

            //Hämtar en anslutning och öppna den. using stänger den automatiskt.
            using var connection = _dbConnection.GetConnection();
            connection.Open();

            //Ett kommando bär SQL-frågan till databasen
            using var command = new SqlCommand(sqlQuery, connection);

            //Kör frågan. Readern perkar på svaret, rad för rad.
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var genre = new Genre
                {
                    Id = reader.GetInt32(0),
                    GenreName = reader.GetString(1)
                };

                genres.Add(genre);
            }

            return genres;
        }

        //Metoden returnerar en int (ett nytt id/en ny rad)
        public int AddMovie(Movie movie)
        {
            string sqlCommand =
            @"INSERT INTO Movies (Title, ReleaseYear, GenreId) 
            VALUES (@Title, @ReleaseYear, @GenreId)";
                       
            using var connection = _dbConnection.GetConnection();
            connection.Open();

            using var command = new SqlCommand(sqlCommand, connection);

            command.Parameters.AddWithValue("@Title", movie.Title);
            command.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
            command.Parameters.AddWithValue("@GenreId", movie.GenreId);

            return command.ExecuteNonQuery();
        }

        public int DeleteMovie(int id)
        {
            string sqlCommand =
            @"DELETE FROM Movies  
            WHERE Id = @Id";

            using var connection = _dbConnection.GetConnection();
            connection.Open();

            using var command = new SqlCommand(sqlCommand, connection);

            command.Parameters.AddWithValue("@Id", id);

            return command.ExecuteNonQuery();
        }
    }
}
