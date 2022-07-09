namespace DotNetFlix.DbEntities;

public class MovieDAL
{
    public MovieDAL(int rank, string title, int year, string imageUrl, string crew)
    {
        Rank = rank;
        Title = title;
        Year = year;
        ImageUrl = imageUrl;
        Crew = crew;
    }

    public int Id { get; set; }

    // data van api
    public int Rank { set; get; }
    public string Title { set; get; }
    public int Year { set; get; }
    public string ImageUrl { get; set; }
    public string Crew { set; get; }

    // data voor features


}
