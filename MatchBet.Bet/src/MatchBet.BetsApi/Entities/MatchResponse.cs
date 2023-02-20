namespace MatchBet.BetsApi.Entities;

public class MatchResponse
{
    public Fixture Fixture { get; set; }
    public League League { get; set; }
    public Versus Teams { get; set; }
    public Goal Goals { get; set; }
    public Score Score { get; set; }
    public long? Id => Fixture?.Id;
    public string? MatchBetRate { get; set; }
    public List<Bet.Bet>? Bets { get; set; }

}