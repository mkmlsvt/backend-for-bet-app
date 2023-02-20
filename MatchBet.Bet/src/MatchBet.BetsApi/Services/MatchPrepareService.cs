using MatchBet.BetsApi.Entities;
using MatchBet.BetsApi.Entities.Bet;
using MatchBet.BetsApi.Helper;
using MatchBet.BetsApi.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace MatchBet.BetsApi.Services;

public interface IMatchPrepareService
{
    Task<List<MatchResponse>> PrepareMatch();
    Task<List<MatchResponse>> GetAllDailyMatches();
}

public class MatchPrepareService : IMatchPrepareService
{
    public static Dictionary<Leagues, int> pageSizeForLeague = new();
    public static List<Leagues> leagues = new()
    {
        Leagues.WorldCup, Leagues.ChampionsLeague, Leagues.UefaEuropeLeague,
        Leagues.PremierLeague,  Leagues.BundesLiga,
        Leagues.France, Leagues.LaLiga,  Leagues.SuperLig, Leagues.ItalySerieA
    };
    private readonly IOptions<MatchConfiguration> _matchConfiguration;
    
    public MatchPrepareService(IOptions<MatchConfiguration> matchConfiguration)
    {
        _matchConfiguration = matchConfiguration;
    }

    public async Task<List<MatchResponse>> PrepareMatch() // Job günde 1 kere çalıştırıcak
    {
        var dailyMatches = await GetAllDailyMatches();
        var matchOddResponses = await GetMatchOddsData();
        foreach (var dailyMatch in dailyMatches)
        {
            var matchRate = matchOddResponses.FirstOrDefault(q => q.Id == dailyMatch.Id);
            if (matchRate is null)
            {
                continue;
            }
            dailyMatch.Bets = matchRate.Bookmakers.FirstOrDefault(q => q.Bets.Any())?.Bets;
        }

        var json = JsonConvert.SerializeObject(dailyMatches);
        return dailyMatches;
    }

    private async Task<List<MatchOddResponse>> GetMatchOddsData()
    {
        var key = _matchConfiguration.Value.Key;
        var date = DateTime.Now;
        var matchOddResponses = new List<MatchOddResponse>();
        foreach (var league in leagues)
        {
            var pageSize = pageSizeForLeague[league];
            for (var page = 0; page < pageSize; page++)
            {
                var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3");
                var request = new RestRequest("odds?league="+(int)league +"&season=2022&date=" +date.Year + "-" + date.Month.ToString("D2")+ "-" +date.Day.ToString("D2") + "&page="+(page+1)+"&bet=1");
                request.AddHeader("X-RapidAPI-Key", key);
                request.AddHeader("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful is false || response.Content is null)
                {
                    return matchOddResponses;
                }

                var result =  JsonConvert.DeserializeObject<HttpResponseMessageHelper<MatchOddResponse>>(response?.Content);
                if (result is null || result.Response.Count == 0)
                {
                    break;
                }
                matchOddResponses.AddRange(result.Response);
                page++;
            }
            
            
        }
 
        return matchOddResponses;
    }

    public async Task<List<MatchResponse>> GetAllDailyMatches()
    {
        var key = _matchConfiguration.Value.Key;
        var matchList = new List<MatchResponse>();
        var date = DateTime.Now;
        foreach (var league in leagues)
        {
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3");
            var dateQueryParams = "fixtures?date=" +date.Year + "-" + date.Month.ToString("D2") + 
                                  "-" +date.Day.ToString("D2") +"&league="+(int)league+"&season=2022";
            var request = new RestRequest($"{dateQueryParams}");
            request.AddHeader("X-RapidAPI-Key", key);
            request.AddHeader("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful is false)
            {
                return matchList;
            }

            var result = JsonConvert.DeserializeObject<HttpResponseMessageHelper<MatchResponse>>(response.Content);
            if (result.Response is null)
            {
                continue;
            }
            pageSizeForLeague[league] = result.Response.Count == 0 ? 0 : result.Response.Count / 10 + 1;
            matchList.AddRange(result.Response);
        }
     
        return matchList;

    }
}