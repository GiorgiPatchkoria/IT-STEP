using Core.Models.DTOs;
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
            await movieService.AddStudioAsync(new Studio { Name = "LucasFilm", CountryId = 1 });
            await movieService.AddStudioAsync(new Studio { Name = "DC", CountryId = 1 });
            await movieService.AddMovieAsync(new CreateMovieDTO { Title = "Star Wars", ReleaseYear = 1977, StudioId = 1});
            await movieService.AddMovieAsync(new CreateMovieDTO { Title = "Star Wars", ReleaseYear = 1980, StudioId = 1});
            await movieService.AddMovieAsync(new CreateMovieDTO { Title = "Dark Knight", ReleaseYear = 2007, StudioId = 1});

            await movieService.DeleteMovieAsync(2);
            await movieService.UpdateMovieAsync(new UpdateMovieDTO { ReleaseYear = 2008, StudioId = 2 }, 3);

            var movies = await movieService.GetAllMoviesAsync();
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
