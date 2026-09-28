using Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace Web.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieService _movieService;

        public DetailsModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public MovieDTO Movie { get; set; }

        public async Task OnGetAsync(int id)
        {
            Movie = await _movieService.GetMovieByIdAsync(id);
        }
    }
}
