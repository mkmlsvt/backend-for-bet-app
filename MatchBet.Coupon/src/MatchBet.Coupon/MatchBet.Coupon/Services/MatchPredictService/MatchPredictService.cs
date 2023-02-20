using MatchBet.Coupon.Models;
using MatchBet.Coupon.Repositories.MatchPredictRepository;

namespace MatchBet.Coupon.Services.MatchPredictService
{
    public class MatchPredictService : IMatchPredictService
    {
        private readonly IMatchPredictRepository _matchPredictRepository;

        public MatchPredictService(IMatchPredictRepository matchPredictRepository)
        {
            _matchPredictRepository = matchPredictRepository;
        }

        public async Task<MatchPredict> GetMatchPredictByIdAsync(int id)
        {
            return await _matchPredictRepository.GetMatchPredictByIdAsync(id);   
        }

        public async Task SaveMatchPredictAsync(MatchPredict matchPredict)
        {
            await _matchPredictRepository.SaveMatchPredictAsync(matchPredict);
        }

        public async Task<List<MatchPredict>> GetMatchPredictByCouponIdAsync(int couponId)
        {
            return await _matchPredictRepository.GetMatchPredictByCouponIdAsync(couponId);
        }
    }
}
