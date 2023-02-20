namespace MatchBet.Coupon.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public bool Result{ get; set; }
        public double TotalRate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<MatchPredict>? MatchPredicts { get; set; }
    }
}
