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
    }
}
