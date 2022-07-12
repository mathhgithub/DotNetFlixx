namespace DotNetFlix.DbEntities;

public class ShopCarTableDAL
{
    public int Id { get; set; }

    public List<MovieDAL> Items { get; set; }


    public int UserId { get; set; }
    public UserDAL User { get; set; }
}