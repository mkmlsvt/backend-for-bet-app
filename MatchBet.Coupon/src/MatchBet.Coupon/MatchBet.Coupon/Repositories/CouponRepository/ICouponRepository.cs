namespace MatchBet.Coupon.Repositories.CouponRepository
{
    public interface ICouponRepository
    {
        Task<Models.Coupon?> GetCouponByIdAsync(int id);
        Task<List<Models.Coupon?>> GetCouponsAllAsync();

        Models.Coupon UpdateCouponAsync(Models.Coupon? coupon);
        Task CreateCouponAsync(Models.Coupon coupon);

        Task<List<Models.Coupon?>> GetCouponsByUserIdAsync(int userId);
    }
}
