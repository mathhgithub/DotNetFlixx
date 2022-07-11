namespace DotNetFlix.aMyBLL.TempDAL;

public class UserDALL
{
    public int Id { get; set; }
    public List<int> Top10Array { get; set; } //array van movieId's, niet linken in database heeft geen nut

}
