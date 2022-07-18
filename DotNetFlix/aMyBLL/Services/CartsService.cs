using DotNetFlix.aMyBLL.Models.Carts;

namespace DotNetFlix.aMyBLL.Services;

public class CartsService
{
    private readonly DflixRepo<CartDAL> _cartRepo;
    private readonly DflixRepo<CartItemDAL> _cartItemRepo;
    private readonly DflixContext _context;

    public CartsService(DflixRepo<CartDAL> cartRepo, DflixRepo<CartItemDAL> cartItemRepo, DflixContext context)
    {
        _cartRepo = cartRepo;
        _cartItemRepo = cartItemRepo;
        _context = context;
    }

    public async Task AddToCart(AddToCartRequest model)
    {
        // check of er een cart bestaat zoniet maak een nieuwe cart
        var cart = await _cartRepo.FindCartByUserIdAsync(x => x.UserId == model.UserId);
        if (cart == null) 
        {
            cart = new CartDAL
            {
                CartId = Guid.NewGuid().ToString(),
                UserId = model.UserId, 
            };
            await _cartRepo.CreateAsync(cart);
        }

        //check of het item al bestaat in de lijst 
        var cartItem = await _cartItemRepo.FindCartByUserIdAsync(x => x.MovieFK == model.MovieId);
        if (cartItem == null)
        {
            var newCartItem = new CartItemDAL
            {
                Quantity = model.Quantity,
                CartFK = cart.CartId,
                MovieFK = model.MovieId
            };
            await _cartItemRepo.Add(newCartItem);
        }
        //update carditem als het al bestaat
        else
        {
            cartItem.Quantity += model.Quantity;
            await _cartItemRepo.Update(cartItem);
        }
    }

    public async Task<int> GetCartItemCounter(string id)
    {
        var model = await _context.Carts
            .Include(m => m.CartItems).ThenInclude(ms => ms.MovieDAL)
            .FirstOrDefaultAsync(m => m.CartId == id);

        var output = model.TotalItems;
        return output;
    }


}
