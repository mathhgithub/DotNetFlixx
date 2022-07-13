namespace DotNetFlix.Models;

public class ShoppingCartViewModel
{
    public List<ShopCarItemModel> Items { get; set; }

    public double Totaal { get; set; }

    public double Shipping { get; set; }


    public class ShopCarItemModel
    {
        public string Title { set; get; }

        public string ImageUrl { get; set; }

        public double Prijs { set; get; }
    }

}
