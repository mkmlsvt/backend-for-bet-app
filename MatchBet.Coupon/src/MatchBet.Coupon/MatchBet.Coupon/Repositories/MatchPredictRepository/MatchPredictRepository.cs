using MatchBet.Coupon.Data;
using MatchBet.Coupon.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchBet.Coupon.Repositories.MatchPredictRepository
{
    public class MatchPredictRepository : IMatchPredictRepository
    {
        private readonly DataContext _dataContext;

        public MatchPredictRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MatchPredict> GetMatchPredictByIdAsync(int id)
        {
            return await _dataContext.MatchPredicts.FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<List<MatchPredict>> GetMatchPredictByCouponIdAsync(int couponId)
        {
            return await _dataContext.MatchPredicts.Where(q => q.CouponId == couponId).ToListAsync();
        }

        public async Task SaveMatchPredictAsync(MatchPredict matchPredict)
        {
            await _dataContext.MatchPredicts.AddAsync(matchPredict);
            await _dataContext.SaveChangesAsync();
        }

        public  MatchPredict UpdateMatchPredictAsync(MatchPredict matchPredict)
        {
            _dataContext.MatchPredicts.Update(matchPredict);
            return matchPredict;
        }
    }
}
