using Core.Models.Entities;
using Infrasturcture.Data;
using Infrasturcture.Repositories;
using Services.Services;

namespace UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MovieDbContext movieDbContext = new MovieDbContext();
            MovieRepository movieRepository = new MovieRepository(movieDbContext);
            MovieService movieService = new MovieService(movieRepository);

            await movieService.AddCountryAsync(new Country { Name = "USA" });
            await movieService.AddStudioAsync(new Studio { Name = "Lucasfilm", CountryId = 1 });
            await movieService.AddMovieAsync(new Movie { Title = "Star Wars", ReleaseYear = 1977, StudioId = 1});
        }
    }
}
