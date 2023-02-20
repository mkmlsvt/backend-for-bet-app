using MatchBet.BetsApi.Model;
using MatchBet.BetsApi.Options;
using MatchBet.BetsApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MatchBet.BetsApi.Data
{
    public class SeedData<T> where T : class
    {
        public void InsertInitialData(MongoDbContext<T> dbContext, IMatchPrepareService _matchPrepareService)
        {
            var productCollection = dbContext.GetCollection<DailyMatches>();
            var isCategoryExist =  productCollection.Find(q => true).Any();
            if (isCategoryExist)
            {
                return;
            }
            var dailyMatches = new DailyMatches()
            {
                Id = new Guid().ToString(),
                Matches =   JsonConvert.SerializeObject(_matchPrepareService.PrepareMatch().Result)
            };
            productCollection.InsertOneAsync(dailyMatches);
        }
    }
}