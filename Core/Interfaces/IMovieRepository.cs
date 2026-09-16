using Core.Models.Entities;

namespace Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMoviesAsync();
        Task AddMovieAsync(Movie movie);
        Task AddStudioAsync(Studio studio);
        Task AddCountryAsync(Country country);
    }
}
