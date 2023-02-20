using MatchBet.BetsApi.Entities;

namespace MatchBet.BetsApi.Contracts
{
    public class MatchControlResponse
    {
        public string? HomeTeamName { get; set; }
        public string? AwayTeamName { get; set; }
        public Goal? Goals { get; set; }
        public short Result { get; set; }
        public bool IsContinue { get; set; }
    }
}
