
using MatchBet.Coupon.Models;

namespace MatchBet.Coupon.Repositories.MatchPredictRepository
{
    public interface IMatchPredictRepository
    {
        Task<Models.MatchPredict> GetMatchPredictByIdAsync(int id);
        Models.MatchPredict UpdateMatchPredictAsync(Models.MatchPredict matchPredict);
        Task SaveMatchPredictAsync(Models.MatchPredict matchPredict);
        Task<List<MatchPredict>> GetMatchPredictByCouponIdAsync(int couponId);

    }
}
