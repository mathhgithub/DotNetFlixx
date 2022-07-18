using System.ComponentModel.DataAnnotations;

namespace DotNetFlix.aMyBLL.Models.Carts;

public class AddToCartRequest
{

    [Required]
    public int UserId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public int MovieId { get; set; }

}
