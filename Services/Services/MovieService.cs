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

        public async Task<ICollection<SearchMovieDTO>> SearchMoviesByStudioAsync(int year, string studioName, int minimumActorCount)
        {
            if (year < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(year));
            }
            if (string.IsNullOrWhiteSpace(studioName))
            {
                throw new ArgumentException("Studio name cannot be null or empty.", nameof(studioName));
            }
            if (minimumActorCount < 0)
            {
                throw new ArgumentException("Minimum actor count cannot be negative.", nameof(minimumActorCount));
            }

            var movies = await _movieRepository.SearchMoviesByStudioAsync(year, studioName, minimumActorCount);
            return movies.Select(MapMovieDTO).ToList();
        }


        public async Task<ICollection<SearchMovieDTO>> SearchMoviesByCountryAsync(string countryName, int minimumYear, int maximumActorCount)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentException("Studio name cannot be null or empty.", nameof(countryName));
            }
            if (minimumYear < 0)
            {
                throw new ArgumentException("Year cannot be negative.", nameof(minimumYear));
            }
            if (maximumActorCount < 0)
            {
                throw new ArgumentException("Minimum actor count cannot be negative.", nameof(maximumActorCount));
            }

            var movies = await _movieRepository.SearchMoviesByCountryAsync(countryName, minimumYear, maximumActorCount);
            return movies.Select(MapMovieDTO).ToList();
        }

        public async Task<ICollection<SearchMovieDTO>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minimumActorCount)
        {
            if (fromYear < 0)
            {
                throw new ArgumentException("From year cannot be negative.", nameof(fromYear));
            }
            if (toYear < 0)
            {
                throw new ArgumentException("To year cannot be negative.", nameof(toYear));
            }
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentException("Country name cannot be null or empty.", nameof(countryName));
            }
            if (string.IsNullOrWhiteSpace(titleText))
            {
                throw new ArgumentException("Title text cannot be null or empty.", nameof(titleText));
            }
            if (minimumActorCount < 0)
            {
                throw new ArgumentException("Minimum actor count cannot be negative.", nameof(minimumActorCount));
            }

            var movies = await _movieRepository.SearchMoviesAdvancedAsync(fromYear, toYear, countryName, titleText, minimumActorCount);
            return movies.Select(MapMovieDTO).ToList();
        }


        private static SearchMovieDTO MapMovieDTO(Movie movie)
        {
            return new SearchMovieDTO
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                StudioName = movie.Studio.Name,
                CountryName = movie.Studio.Country?.Name,
                ActorCount = movie.Actors.Count
            };

        }
    }
}
