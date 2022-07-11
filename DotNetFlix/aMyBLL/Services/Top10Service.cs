using DotNetFlix.aMyBLL.TempDAL;

namespace DotNetFlix.aMyBLL.Services;

public class Top10Service
{
    private readonly DflixRepo<MovieDAL> _movieRepo;
    private readonly DflixRepo<UserDAL> _userRepo;

    public Top10Service(DflixRepo<MovieDAL> movieRepo, DflixRepo<UserDAL> userRepo)
    {
        _movieRepo = movieRepo;
        _userRepo = userRepo;
    }

    public int GetMatchingUserId(UserDALL a, List<UserDALL> b)
    {
        // we gebruiken een object ScoreListItem om zowel de userId als score bij te houden      
        List<ScoreListItem> listOfScoreListItems = new List<ScoreListItem>();

        foreach (var item in b)
        {
            // we berekenen een overeenkomst van onze top10movielist met elke user in de database
            var intersectionCount = a.Top10Array.Intersect(item.Top10Array).Count();
            var unionCount = a.Top10Array.Union(item.Top10Array).Count();
            var jaccardIndex = (intersectionCount / (double)unionCount);

            // we maken een tijdelijke lijst van alle scores
            double tempScore = Math.Round(jaccardIndex, 2);
            listOfScoreListItems.Add(new ScoreListItem(item.Id,tempScore)) ;        
        }
        // bereken de beste score //nog checken of er niks fout loopt wanneer er 2 dezelfde scores zijn
        var winner = listOfScoreListItems.MaxBy(x => x.Score);
        return winner.UserId;
    }

    public class ScoreListItem 
    {
        public ScoreListItem(int userId, double score)
        {
            UserId = userId;
            Score = score;
        }
        public int UserId { get; set; }
        public double Score { get; set; }
    }

    /*
    public static double CalculateJaccardIndex<T>(ICollection<T> a, ICollection<T> b)
    {
        var intersectionCount = a.Intersect(b).Count();
        var unionCount = a.Union(b).Count();

        var jaccardIndex = (intersectionCount / (double)unionCount);
        return Math.Round(jaccardIndex, 2);
    }
    */
}
