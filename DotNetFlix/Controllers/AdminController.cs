using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class AdminController : Controller
{
    private readonly MovieService _movieService;
    private readonly UserService _userService;

    public AdminController(MovieService movieService, UserService userService)
    {
        _movieService = movieService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<string> DummyDataButton()
    {
        string message = await _movieService.SyncDummyData();
        return message;
    }


}