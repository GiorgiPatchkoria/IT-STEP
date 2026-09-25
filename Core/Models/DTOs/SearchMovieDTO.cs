namespace Core.Models.DTOs
{
    public class SearchMovieDTO
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string StudioName { get; set; }
        public string CountryName { get; set; }
        public int ActorCount { get; set; }
        public override string? ToString()
        {
            return $"{Title} ({ReleaseYear}) - {StudioName}, {CountryName}, {ActorCount} Actors";
        }
    }
}
