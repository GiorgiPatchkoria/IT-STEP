using Core.Models.Entities;

namespace Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMoviesAsync();
        Task AddMovieAsync(Movie movie);
        Task AddStudioAsync(Studio studio);
        Task AddCountryAsync(Country country);
        Task<Movie> GetMovieByIdAsync(int id);
        Task DeleteMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);

        Task<ICollection<Movie>> SearchMoviesByStudioAsync(int year, string studioName, int minimumActorCount);
        Task<ICollection<Movie>> SearchMoviesByCountryAsync(string countryName, int minimumYear, int maximumActorCount);

        Task<ICollection<Movie>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minimumActorCount);
    }
}
