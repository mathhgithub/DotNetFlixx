using DotNetFlix.aMyBLL.Models;
using DotNetFlix.Models;

namespace DotNetFlix.aMyBLL.Services;

public class ShoppingCartService
{
    private readonly DflixRepo<ShoppingCartItemDAL> _cartRepo;
    private readonly DflixRepo<UserDAL> _userRepo;

    public ShoppingCartService(DflixRepo<ShoppingCartItemDAL> cartRepo, DflixRepo<UserDAL> userRepo)
    {
        _cartRepo = cartRepo;
        _userRepo = userRepo;
    }

    public async Task<ShoppingCartViewModel> GetCartForUser(int Id)
    {
        var currentUser = await _userRepo.GetByUserName(Id);
        var viewModel = new ShoppingCartViewModel();

        foreach (var item in currentUser.ShoppingCartItems)
        {
            var line = new ShoppingCartViewModel.ShopCarItemModel
            {
                Title = item.MovieDAL.Title,
                ImageUrl = item.MovieDAL.ImageUrl,
                Prijs = item.MovieDAL.Prijs
            };
            viewModel.Items.Add(line);
            viewModel.Totaal =+ line.Prijs;
            viewModel.Shipping = +0.50; 
        }
        return viewModel;
    }

    public async Task Addcartitem(ShoppingCartItemDAL model)
    {
        await _cartRepo.CreateAsync(model);
    }

    /*
    public async Task AddToCart(ShoppingCartItemDAL model)
    {
        var inputMovie1 = await _movieService.GetRandomModel();
        var inputShoppingCartItem1 = new ShoppingCartItemDAL { Quantity = 2, MovieDAL = inputMovie1 };

        var inputMovie2 = await _movieService.GetRandomModel();
        var inputShoppingCartItem2 = new ShoppingCartItemDAL { Quantity = 5, MovieDAL = inputMovie1 };

        var shoppingCartItemList = new List<ShoppingCartItemDAL>();
        shoppingCartItemList.Add(inputShoppingCartItem1);
        shoppingCartItemList.Add(inputShoppingCartItem2);

        var dummyUser = new UserDAL { ShoppingCartItems = shoppingCartItemList, UserFirstName = "John", UserLastName = "Snow" };
        await _userService.CreateDummyUser(dummyUser);
        return Ok();
    }
    */
}
