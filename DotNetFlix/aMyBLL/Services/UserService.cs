using DotNetFlix.DbEntities;
using Newtonsoft.Json;
using static DotNetFlix.aMyBLL.Models.IMDbResponseModel;

namespace DotNetFlix.aMyBLL.Services;

public class UserService
{
    private readonly DflixRepo<UserDAL> _repo;

    public UserService(DflixRepo<UserDAL> repo)
    {
        _repo = repo;
    }


    public async Task CreateDummyUser(UserDAL model)
    {
        await _repo.CreateAsync(model);
    }

}
