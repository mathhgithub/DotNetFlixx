using DotNetFlix.aMyBLL.Models;

namespace DotNetFlix.aMyBLL.Services;

public class ShopCarService
{
    private readonly DflixRepo<ShopCarTableDAL> _repo;

    public ShopCarService(DflixRepo<ShopCarTableDAL> repo)
    {
        _repo = repo;
    }

    public async Task<ShopCarTableModel> GetShopCarForUser(int Id)
    {
        var input = await _repo.GetByUserName(Id);
        var tableModel = new ShopCarTableModel();

        foreach (var item in input.Items)
        {
            var itemModel = new ShopCarItemModel
            {
                Title = item.Title,
                ImageUrl = item.ImageUrl,
                Prijs = item.Prijs,
            };
            tableModel.Totaal =+ item.Prijs;
            tableModel.Items.Add(itemModel);
        }
        return tableModel;
    }

}
