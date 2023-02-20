using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchBet.Coupon.Data.Mappings
{
    public class MatchPredictMapping
    {
        public MatchPredictMapping(EntityTypeBuilder<Models.MatchPredict> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(q => q.Id);
            entityTypeBuilder.ToTable("matchPredicts");

            entityTypeBuilder.Property(q => q.Id).HasColumnName("id");
            entityTypeBuilder.Property(q => q.CouponId).HasColumnName("couponId");
            entityTypeBuilder.Property(q => q.MatchId).HasColumnName("matchId");
            entityTypeBuilder.Property(q => q.Prediction).HasColumnName("prediction");
            entityTypeBuilder.Property(q => q.Rate).HasColumnName("rate");
            entityTypeBuilder.Property(q => q.IsActive).HasColumnName("isActive");
            entityTypeBuilder.Property(q => q.Result).HasColumnName("result");
        }
    }
}
