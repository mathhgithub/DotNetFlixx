using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class AdminController : Controller
{
    private readonly MovieService _movieService;
    private readonly UserService _userService;
    private readonly ShoppingCartService _cartService;

    public AdminController(MovieService movieService, UserService userService, ShoppingCartService cartService)
    {
        _movieService = movieService;
        _userService = userService;
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<string> DummyDataButton()
    {
        string message = await _movieService.SyncDummyData();
        return message;
    }

    [HttpGet]
    public async Task<IActionResult> DummyUserButton()
    {
        var inputMovie1 = await _movieService.GetRandomModel();
        var inputShoppingCartItem1 = new ShoppingCartItemDAL { Quantity = 2, MovieDAL = inputMovie1, UserForeignKey = 1};
        await _cartService.Addcartitem(inputShoppingCartItem1);

        var dummyUser = new UserDAL { UserFirstName = "John", UserLastName ="Snow" };
        await _userService.CreateDummyUser(dummyUser);
        return Ok();
    }

}