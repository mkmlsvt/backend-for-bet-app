namespace MatchBet.Coupon.Models
{
    public class MatchPredict
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public string? MatchId{ get; set; }
        public int Prediction{ get; set; }
        public float Rate{ get; set; }
        public bool IsActive{ get; set;}
        public bool Result{ get; set;}
        public Coupon? Coupon { get; set; } 
    }
}
