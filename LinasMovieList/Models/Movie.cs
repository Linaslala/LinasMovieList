namespace LinasMovieList.Models
{
    internal class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id}, {Title}, {ReleaseYear}, {GenreName}";
        }

    }
}
