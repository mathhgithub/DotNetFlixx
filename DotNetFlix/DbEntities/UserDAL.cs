using System.ComponentModel.DataAnnotations;

namespace DotNetFlix.DbEntities;

public class UserDAL
{
    [Key]
    public int UserId { get; set; }

    public string UserFirstName { get; set; }

    public string UserLastName { get; set; }

  
}