using System.ComponentModel.DataAnnotations;

namespace DotNetFlix.DbEntities;

public class ShoppingCartItemDAL
{
    [Key]
    public int ShoppingCartItemId { get; set; }

    public MovieDAL MovieDAL { get; set; }
    public int Quantity { get; set; }


    public int UserForeignKey { get; set; }
    public UserDAL UserDAL { get; set; }
}