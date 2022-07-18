using DotNetFlix.aMyBLL.Models.Carts;
using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class CartsController : Controller
{
    private readonly DflixContext _context;
    private readonly CartsService _cartsService;
    public CartsController(DflixContext context, CartsService cartsService) { _context = context; _cartsService = cartsService; }


    public async Task<IActionResult> Index()
    {
        string id = "e8325fd5-f84c-495d-8638-82d67759a8ff";

        var model = await _context.Carts
            .Include(m => m.CartItems).ThenInclude(ms => ms.MovieDAL)
            .FirstOrDefaultAsync(m => m.CartId == id);

        // 404.
        if (model == null) { return NotFound();}

        return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddToCart([FromForm] AddToCartRequest model)
    {
        // checken of er een cart bestaat voor de user
        if (!ModelState.IsValid) { return BadRequest("slecht model"); }
        else { await _cartsService.AddToCart(model); }
        return RedirectToAction("Index");
    }



}
