using DotNetFlix.DbEntities;
using Newtonsoft.Json;
using static DotNetFlix.aMyBLL.Models.IMDbResponseModel;

namespace DotNetFlix.aMyBLL.Services;

public class MovieService
{
    private HttpClient _httpClient;
    private readonly DflixRepo<MovieDAL> _repo;

    public MovieService(HttpClient httpClient, DflixRepo<MovieDAL> repo)
    {
        _httpClient = httpClient;
        _repo = repo;
    }

    //https://localhost:7006/IMDb/GetDummyData
    public async Task<string> SyncDummyData()
    {
        string APIURL = "Top250Movies/k_ct5w24y4";
        var response = await _httpClient.GetAsync(APIURL);
        var jsonString = response.Content.ReadAsStringAsync().Result;
        var myDeserializedClass = JsonConvert.DeserializeObject<MovieRoot>(jsonString);

        await _repo.DeleteAll();

        foreach (var item in myDeserializedClass.Items)
        {
            await _repo.CreateAsync(new MovieDAL(
                Int32.Parse(item.Rank),
                item.Title,
                Int32.Parse(item.Year),
                item.ImageUrl,
                item.Crew,
                item.Prijs
                ));
        }
        return "succes";
    }

}
