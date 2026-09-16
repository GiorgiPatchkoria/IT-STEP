using Core.Interfaces;
using Core.Models.Entities;

namespace Services.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task AddStudioAsync(Studio studio)
        {
            await _movieRepository.AddStudioAsync(studio);
        }

        public async Task AddCountryAsync(Country country)
        {
            await _movieRepository.AddCountryAsync(country);
        }
    }
}
