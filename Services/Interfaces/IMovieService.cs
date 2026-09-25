using Core.Models.DTOs;
using Core.Models.Entities;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        Task<ICollection<MovieDTO>> GetAllMoviesAsync();
        Task AddMovieAsync(CreateMovieDTO movie);
        Task AddStudioAsync(Studio studio);
        Task AddCountryAsync(Country country);
        Task DeleteMovieAsync(int id);
        Task UpdateMovieAsync(UpdateMovieDTO movie, int id);
        Task<ICollection<SearchMovieDTO>> SearchMoviesByCountryAsync(string countryName, int minimumYear, int maximumActorCount);
        Task<ICollection<SearchMovieDTO>> SearchMoviesByStudioAsync(int year, string studioName, int minimumActorCount);
        Task<ICollection<SearchMovieDTO>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minimumActorCount);
    }
}
