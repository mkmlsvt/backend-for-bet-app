using MatchBet.BetsApi.Options;
using MatchBet.BetsApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatchBet.BetsApi.Data
{
    public class MongoDbContext<T> where T : class
    {
        protected readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoOptions> options, IMatchPrepareService matchPrepareService)
        {
            var client =  new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
            new SeedData<T>().InsertInitialData(this, matchPrepareService);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.Trim());
        }
    }
}