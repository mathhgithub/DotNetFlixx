namespace DotNetFlix.aMyBLL.Models;

public class ShopCarTableModel
{
    public List<ShopCarItemModel> Items { get; set; }

    public double Totaal { get; set; }

    public double Shipping { get; set; }
}
