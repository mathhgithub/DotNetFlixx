using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class AdminController : Controller
{
    private readonly MovieService _movieService;

    public AdminController(MovieService movieService)
    {

        _movieService = movieService;
    }

    [HttpGet]
    public async Task<string> DummyDataButton()
    {
        string message = await _movieService.SyncDummyData();
        return message;
    }


}