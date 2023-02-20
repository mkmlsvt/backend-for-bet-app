namespace MatchBet.BetsApi.Entities;

public class Score
{
    public Goal? HalfTime { get; set; }
    public Goal? FullTime { get; set; }
    public Goal? ExtraTime { get; set; }
    public Goal? Penalty { get; set; }
}