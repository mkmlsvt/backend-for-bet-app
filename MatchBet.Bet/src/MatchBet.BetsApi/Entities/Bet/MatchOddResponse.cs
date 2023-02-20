namespace MatchBet.BetsApi.Entities.Bet;

public class MatchOddResponse
{
    public League League { get; set; }
    public Fixture Fixture { get; set; }
    public List<Bookmakers> Bookmakers { get; set; }
    public long Id => Fixture.Id;
    public Bet Bet => Bookmakers.FirstOrDefault(q => q.Bets is not null).Bets.First();
}