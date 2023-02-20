namespace MatchBet.BetsApi.Entities.Bet;

public class Bet
{
    public short Id { get; set; }
    public string Name { get; set; }
    public List<BetValues> Values { get; set; }
}