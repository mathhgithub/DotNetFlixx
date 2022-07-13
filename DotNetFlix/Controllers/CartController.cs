using DotNetFlix.aMyBLL.Services;
using DotNetFlix.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class CartController : Controller
{
    private readonly ShoppingCartService _shopCarService;

    public CartController(ShoppingCartService shopCarService)
    {
        _shopCarService = shopCarService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = await _shopCarService.GetCartForUser(1);
        if (viewModel == null) { return View("Index"); } 
        else { return View("Index",viewModel); }    
    }


    [HttpPost]
    public async Task<ActionResult> AddToCart()
    {
        var newItem = await _shopCarService.GetCartForUser(1);

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        // delete student from the database whose id matches with specified id

        return RedirectToAction("Index");
    }

}
