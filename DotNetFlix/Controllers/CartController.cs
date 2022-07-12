using DotNetFlix.aMyBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers;

public class CartController : Controller
{
    private readonly ShopCarService _shopCarService;

    public CartController(ShopCarService shopCarService)
    {
        _shopCarService = shopCarService;
    }

    public IActionResult Index()
    {
        var model = _shopCarService.GetShopCarForUser(0);
        if (model == null) { return View("Index", model);}
        else { return View("Index"); }
        
    }

    [HttpPost]
    public ActionResult Edit(int std)
    {
        // update student to the database

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        // delete student from the database whose id matches with specified id

        return RedirectToAction("Index");
    }

}
