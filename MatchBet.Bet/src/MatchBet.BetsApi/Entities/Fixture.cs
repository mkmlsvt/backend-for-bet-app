namespace MatchBet.BetsApi.Entities;

public class Fixture
{
    public long Id { get; set; }
    public string? Referee { get; set; }
    public string? TimeZone { get; set; }
    public DateTime Date { get; set; }
    public MatchStatus Status { get; set; }
}