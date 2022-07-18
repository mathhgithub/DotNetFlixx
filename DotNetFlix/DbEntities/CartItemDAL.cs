using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetFlix.DbEntities;

public class CartItemDAL
{
    [Key]
    public int CartItemId { get; set; }

    public int Quantity { get; set; }


    [ForeignKey("MovieDAL")]
    public int MovieFK { get; set; }
    public MovieDAL MovieDAL { get; set; }


    [ForeignKey("CartDAL")]
    public string CartFK { get; set; }
    public CartDAL CartDAL { get; set; }
}
