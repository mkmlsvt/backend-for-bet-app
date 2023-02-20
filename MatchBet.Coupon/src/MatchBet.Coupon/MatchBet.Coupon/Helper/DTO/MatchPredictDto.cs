namespace MatchBet.Coupon.Helper.DTO
{
    public class MatchPredictDto
    {
        public string? MatchId { get; set; }
        public int Prediction { get; set; }
        public float Rate { get; set; }
        public bool IsActive { get; set; }
        public bool Result { get; set; }
    }
}
