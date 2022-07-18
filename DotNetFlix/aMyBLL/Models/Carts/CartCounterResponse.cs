using System.ComponentModel.DataAnnotations;

namespace DotNetFlix.aMyBLL.Models.Carts;

public class CartCounterResponse
{

    [Required]
    public int TotalItems { get; set; }


}
