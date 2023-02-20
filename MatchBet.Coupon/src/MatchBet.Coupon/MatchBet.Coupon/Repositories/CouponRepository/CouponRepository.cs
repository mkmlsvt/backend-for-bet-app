using MatchBet.Coupon.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MatchBet.Coupon.Repositories.CouponRepository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _dataContext;

        public CouponRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateCouponAsync(Models.Coupon coupon)
        {
            await _dataContext.Coupons.AddAsync(coupon);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Models.Coupon?> GetCouponByIdAsync(int id)
        {
            return await _dataContext.Coupons.FirstOrDefaultAsync(q=>q.Id == id);
        }

        public async Task<List<Models.Coupon?>> GetCouponsAllAsync()
        {
            return await _dataContext.Coupons.ToListAsync();
        }
        public  Models.Coupon UpdateCouponAsync(Models.Coupon coupon)
        {
            _dataContext.Update(coupon);
            return coupon;
        }
        public async Task<List<Models.Coupon?>> GetCouponsByUserIdAsync(int userId)
        {
            var couponsList = await _dataContext.Coupons.Where(q=>q.OwnerId== userId).ToListAsync();
            return couponsList;
        }
    }
}
