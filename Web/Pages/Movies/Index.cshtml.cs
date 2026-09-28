using Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;

        public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();

        public IndexModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task OnGetAsync()
        {
            Movies = await _movieService.GetAllMoviesAsync();
        }
    }
}
