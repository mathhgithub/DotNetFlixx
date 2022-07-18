using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetFlix.DbEntities;

public class CartDAL
{
    [Key]
    public string CartId { get; set; }

    public int UserId { get; set; }

    public List<CartItemDAL> CartItems { get; set; }

    [NotMapped]
    public double SubTotaal => Math.Round(CartItems.Sum(item => item.MovieDAL.Prijs * item.Quantity),2);

    [NotMapped]
    public double Shipping => 4.99;

    [NotMapped]
    public double Totaal => Math.Round(SubTotaal+Shipping,2);

    [NotMapped]
    public int TotalItems => CartItems.Sum(item => item.Quantity);
}
