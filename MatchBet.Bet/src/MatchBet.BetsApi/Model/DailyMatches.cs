using MongoDB.Bson.Serialization.Attributes;

namespace MatchBet.BetsApi.Model;

public class DailyMatches
{
    [BsonId]
    [BsonElement("_id")]
    public string Id { get; set; }
    [BsonElement("matches")]
    public string? Matches { get; set; }
}