using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MatchBet.BetsApi.Data;
using MatchBet.BetsApi.Model;
using MatchBet.BetsApi.Options;
using MatchBet.BetsApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatchBet.BetsApi.Repositories;

public class MatchRepository: IMatchRepository
{
    private readonly IMongoCollection<DailyMatches> _dailyCollection;
    private readonly MongoDbContext<DailyMatches> _dbContextMatches;
    private readonly FilterDefinitionBuilder<DailyMatches> _filterBuilder = Builders<DailyMatches>.Filter;

    public MatchRepository(IOptions<MongoOptions> options, IMatchPrepareService matchPrepareService)
    {
        _dbContextMatches = new MongoDbContext<DailyMatches>(options,matchPrepareService);
        _dailyCollection = _dbContextMatches.GetCollection<DailyMatches>();
    }

    public DailyMatches GetAsync()
    {
        var result =  _dailyCollection.Find(_filterBuilder.Empty).FirstOrDefault();
        return result;
    }
    
    public async Task DeleteAllAsync()
    {
         await _dailyCollection.DeleteManyAsync(_filterBuilder.Empty);
    }
}