namespace MatchBet.Coupon.Services.CouponService
{
    public interface ICouponService
    {
        Task CreateCouponAsync(Helper.Contarct.CreateCouponRequest coupon);
        Task<Models.Coupon> GetCouponByIdAsync(int id);

        Task<List<Models.Coupon?>> RefreshCouponsByUserId(int userId);

    }
}
