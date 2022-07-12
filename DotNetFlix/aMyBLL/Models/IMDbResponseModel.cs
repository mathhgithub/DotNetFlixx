using Newtonsoft.Json;

namespace DotNetFlix.aMyBLL.Models;

public class IMDbResponseModel
{
    public class MovieBLL
    {
        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public string Crew { get; set; }

        public double Prijs = 4.99;

    }

    public class MovieRoot
    {
        [JsonProperty(PropertyName = "items")]
        public List<MovieBLL> Items { get; set; }

        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }
    }

}
