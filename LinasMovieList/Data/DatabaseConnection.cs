using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LinasMovieList.Data
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = config.GetConnectionString("LinasMovieDb")!;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        
    }
}
