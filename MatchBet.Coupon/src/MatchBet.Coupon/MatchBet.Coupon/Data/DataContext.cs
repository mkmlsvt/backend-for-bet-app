using MatchBet.Coupon.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MatchBet.Coupon.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Models.Coupon> Coupons { get; set; }
        public DbSet<Models.MatchPredict> MatchPredicts { get; set; }

        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetValue<string>("ConnectionString"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.MatchPredict>()
                .HasOne<Models.Coupon>(q => q.Coupon)
                .WithMany(s => s.MatchPredicts)
                .HasForeignKey(q => q.CouponId);
            new CouponMapping(modelBuilder.Entity<Models.Coupon>());
            new MatchPredictMapping(modelBuilder.Entity<Models.MatchPredict>());

        }
    }
}
