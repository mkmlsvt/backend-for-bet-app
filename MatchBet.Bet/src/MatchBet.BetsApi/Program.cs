using MatchBet.BetsApi.Options;
using MatchBet.BetsApi.Repositories;
using MatchBet.BetsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMatchPrepareService, MatchPrepareService>();
builder.Services.AddTransient<IMatchRepository, MatchRepository>();
builder.Services.Configure<MongoOptions>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("MongoConnection:Database").Value;
});
builder.Services.Configure<MatchConfiguration>(options =>
{
    options.Key = builder.Configuration.GetSection("MatchApiKey").Value;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();