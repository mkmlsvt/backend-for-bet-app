namespace MatchBet.BetsApi.Entities.Bet;

public class Bookmakers
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public List<Bet> Bets { get; set; }
}