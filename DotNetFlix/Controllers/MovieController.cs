using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class MovieController : Controller
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    public IActionResult Index()
    {
        var model = _movieService.GetAllMoviesToList();
        return View(model);
    }


}