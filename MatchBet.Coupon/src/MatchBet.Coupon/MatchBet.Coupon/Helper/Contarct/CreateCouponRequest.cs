using MatchBet.Coupon.Models;

namespace MatchBet.Coupon.Helper.Contarct
{
    public class CreateCouponRequest
    {
        public int OwnerId { get; set; }
        public bool Result { get; set; }
        public double TotalRate { get; set; }
        public bool IsActive { get; set; }
        public List<Helper.DTO.MatchPredictDto>? MatchPredicts { get; set; }

    }
}
