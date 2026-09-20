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
    }
}
