using MatchBet.Coupon.Models;

namespace MatchBet.Coupon.Services.MatchPredictService
{
    public interface IMatchPredictService
    {
        Task SaveMatchPredictAsync(Models.MatchPredict matchPredict);
        Task<Models.MatchPredict> GetMatchPredictByIdAsync(int id);
        Task<List<MatchPredict>> GetMatchPredictByCouponIdAsync(int couponId);
    }
}
