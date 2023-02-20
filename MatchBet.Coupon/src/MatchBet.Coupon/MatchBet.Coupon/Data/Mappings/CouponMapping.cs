using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchBet.Coupon.Data.Mappings
{
    public class CouponMapping
    {
        public CouponMapping(EntityTypeBuilder<Models.Coupon> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(q => q.Id);
            entityTypeBuilder.ToTable("coupons");

            entityTypeBuilder.Property(q => q.Id).HasColumnName("id");
            entityTypeBuilder.Property(q => q.Result).HasColumnName("result");
            entityTypeBuilder.Property(q => q.IsActive).HasColumnName("isActive");
            entityTypeBuilder.Property(q => q.OwnerId).HasColumnName("ownerId");
            entityTypeBuilder.Property(q => q.TotalRate).HasColumnName("totalRate");
        }
    }
}
