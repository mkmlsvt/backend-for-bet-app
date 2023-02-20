using MatchBet.BetsApi.Model;

namespace MatchBet.BetsApi.Repositories;

public interface IMatchRepository
{
    DailyMatches GetAsync();
    Task DeleteAllAsync();
}