using Core.Interfaces;
using Core.Models.Entities;
using Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcture.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            return await _movieDbContext.Movies
                .Include(m => m.Studio)
                .ToListAsync();
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieDbContext.Movies.AddAsync(movie);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task AddStudioAsync(Studio studio)
        {
            await _movieDbContext.Studios.AddAsync(studio);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task AddCountryAsync(Country country)
        {
            await _movieDbContext.Countries.AddAsync(country);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieDbContext.Movies
                .Include(m => m.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            _movieDbContext.Movies.Remove(movie);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _movieDbContext.Movies.Update(movie);
            await _movieDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesByStudioAsync(int year, string studioName, int minimumActorCount)
        {
            return await _movieDbContext.Movies
                        .Include(m => m.Studio)
                        .Include(m => m.Actors)
                        .Where(m => m.ReleaseYear >= year &&
                            m.Studio.Name == studioName &&
                            m.Actors.Count >= minimumActorCount)
                        .OrderByDescending(m => m.ReleaseYear)
                        .ThenBy(m => m.Title)
                        .ToListAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesByCountryAsync(string countryName, int minimumYear, int maximumActorCount)
        {
            return await _movieDbContext.Movies
                        .Include(m => m.Studio)
                            .ThenInclude(s => s.Country)
                        .Include(m => m.Actors)
                        .Where(m => m.Studio.Country.Name == countryName && 
                            m.ReleaseYear >= minimumYear &&
                            m.Actors.Count <= maximumActorCount)
                        .OrderBy(m => m.Actors.Count)
                        .ThenByDescending(m => m.ReleaseYear)
                        .ThenBy(m => m.Title)
                        .ToListAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minimumActorCount)
        {
            return await _movieDbContext.Movies
                        .Include(m => m.Studio)
                            .ThenInclude(s => s.Country)
                        .Include(m => m.Actors)
                        .Where(m => m.ReleaseYear >= fromYear &&
                            m.ReleaseYear <= toYear &&
                            m.Studio.Country.Name == countryName &&
                            m.Title.Contains(titleText) &&
                            m.Actors.Count >= minimumActorCount)
                        .OrderByDescending(m => m.Actors.Count)
                        .ThenByDescending(m => m.ReleaseYear)
                        .ThenBy(m => m.Studio.Name)
                        .ThenBy(m => m.Title)
                        .ToListAsync();
        }
    }
}
