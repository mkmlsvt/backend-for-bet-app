using MatchBet.Player.Data;
using MatchBet.Player.Repository;
using MatchBet.Player.Services;
using Microsoft.EntityFrameworkCore;
using Quartz.Impl;
using Quartz;
using MatchBet.Player.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureServices(WebApplicationBuilder? webApplicationBuilder)
{
    webApplicationBuilder.Services.AddQuartz(q =>
     {
         q.UseMicrosoftDependencyInjectionScopedJobFactory();
         // Just use the name of your job that you created in the Jobs folder.
         var jobKey = new JobKey("JonSchduler");
         q.AddJob<JobSchduler>(opts => opts.WithIdentity(jobKey));

         q.AddTrigger(opts => opts
             .ForJob(jobKey)
             .WithIdentity("UpdateCredit-Trigger")
             .StartNow()
             .WithDailyTimeIntervalSchedule(x => x
                 .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 59))
                 .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 59))
                 .OnEveryDay())
         );
     });
    webApplicationBuilder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    webApplicationBuilder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    webApplicationBuilder.Services.AddEndpointsApiExplorer();
    webApplicationBuilder.Services.AddSwaggerGen();
    webApplicationBuilder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
    webApplicationBuilder.Services.AddTransient<IPlayerServices, PlayerServices>();
    webApplicationBuilder.Services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt =>
        opt.UseNpgsql(webApplicationBuilder.Configuration.GetValue<string>("ConnectionString")));
}