using MatchBet.Player.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MatchBet.Player.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Models.Player> Players { get; set; }

        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration): base(options)
        {
            Configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetValue<string>("ConnectionString"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PlayerMapping(modelBuilder.Entity<Models.Player>());

        }
    }    
}
