using Core.Interfaces;
using Core.Models.DTOs;
using Core.Models.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ICollection<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();

            var movieDTOs = movies.Select(m => new MovieDTO
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                StudioName = m.Studio.Name
            }).ToList();

            return movieDTOs;
        }

        public async Task AddMovieAsync(CreateMovieDTO movieDTO)
        {
            if (movieDTO == null)
            {
                throw new ArgumentNullException(nameof(movieDTO));
            }
            if (string.IsNullOrWhiteSpace(movieDTO.Title))
            {
                throw new ArgumentException("Movie title cannot be null or empty.", nameof(movieDTO.Title));
            }
            if (movieDTO.ReleaseYear < 1888 || movieDTO.ReleaseYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Release year must be between 1888 and the current year.", nameof(movieDTO.ReleaseYear));
            }
            if (movieDTO.StudioId <= 0)
            {
                throw new ArgumentException("Studio ID must be a positive integer.", nameof(movieDTO.StudioId));
            }

            var newMovie = new Movie
            {
                Title = movieDTO.Title,
                ReleaseYear = movieDTO.ReleaseYear,
                StudioId = movieDTO.StudioId
            };
            await _movieRepository.AddMovieAsync(newMovie);
        }

        public async Task AddStudioAsync(Studio studio)
        {
            await _movieRepository.AddStudioAsync(studio);
        }

        public async Task AddCountryAsync(Country country)
        {
            await _movieRepository.AddCountryAsync(country);
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie != null)
            {
                await _movieRepository.DeleteMovieAsync(movie);
            }
        }

        public async Task UpdateMovieAsync(UpdateMovieDTO movie, int id)
        {
            if (movie.ReleaseYear < 1888 || movie.ReleaseYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Release year must be between 1888 and the current year.", nameof(movie.ReleaseYear));
            }
            if (movie.StudioId <= 0)
            {
                throw new ArgumentException("Studio ID must be a positive integer.", nameof(movie.StudioId));
            }


            var existingMovie = await _movieRepository.GetMovieByIdAsync(id);
            if (existingMovie != null)
            {
                existingMovie.ReleaseYear = movie.ReleaseYear;
                existingMovie.StudioId = movie.StudioId;
                await _movieRepository.UpdateMovieAsync(existingMovie);
            }
        }
    }
}
