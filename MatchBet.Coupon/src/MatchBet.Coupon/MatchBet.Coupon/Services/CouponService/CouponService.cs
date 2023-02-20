using MatchBet.Coupon.Contracts;
using MatchBet.Coupon.Helper.DTO;
using MatchBet.Coupon.Models;
using MatchBet.Coupon.Repositories.CouponRepository;
using MatchBet.Coupon.Services.MatchPredictService;
using Newtonsoft.Json;
using RestSharp;

namespace MatchBet.Coupon.Services.CouponService
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMatchPredictService _matchPredictService;

        public CouponService(ICouponRepository couponRepository, IMatchPredictService matchPredictService)
        {
            _couponRepository = couponRepository;
            _matchPredictService = matchPredictService;
        }

        public async Task CreateCouponAsync(Helper.Contarct.CreateCouponRequest coupon)
        {
            var matchPredictList = new List<MatchPredict>();

            if(coupon.MatchPredicts is not null)
            {
                foreach (var item in coupon.MatchPredicts)
                {
                    matchPredictList.Add(new MatchPredict
                    {
                        IsActive = item.IsActive,
                        MatchId = item.MatchId,
                        Prediction = item.Prediction,
                        Rate = item.Rate,
                        Result = item.Result,
                    });
                }
            }
            Models.Coupon couponModel = new Models.Coupon{
                MatchPredicts = matchPredictList,
                IsActive = coupon.IsActive,
                OwnerId = coupon.OwnerId,
                Result = coupon.Result,
                TotalRate = coupon.TotalRate,
            };
            foreach(var data in couponModel.MatchPredicts)
            {
                data.CouponId = couponModel.Id;
            }
            await _couponRepository.CreateCouponAsync(couponModel);
        }

        public async Task<Models.Coupon> GetCouponByIdAsync(int id)
        {
            return await _couponRepository.GetCouponByIdAsync(id);
        }

        public async Task<List<Models.Coupon?>> RefreshCouponsByUserId(int userId)
        {
            // hata requeste body eklerken olabilir.
            var coupons = await _couponRepository.GetCouponsByUserIdAsync(userId);
            
            foreach(var coupon in coupons)
            {
                coupon.MatchPredicts = await _matchPredictService.GetMatchPredictByCouponIdAsync(coupon.Id);
                await UpdateCouponStatus(coupon);
                if(coupon.Result == true)
                {
                    var client = new RestClient("http://player-app-lb:2424");
                   // var client = new RestClient("http://localhost:2424/");
                    var request = new RestRequest("players/updatePlayerScore");
                    request.AddJsonBody(new UpdatePlayerRequestModel
                    {
                        Score = coupon.TotalRate,
                        Id = userId
                    });
                    var response = await client.PostAsync(request).ConfigureAwait(false);
                    if(response.IsSuccessStatusCode== true)
                    {
                        Console.WriteLine("Başarıyla güncellendi.");
                    }
                    Console.WriteLine(response.StatusCode);
                }
            }
            return coupons;
        }

        public async Task<Models.Coupon> UpdateCouponStatus(Models.Coupon coupon)
        {
            coupon.Result = true;
            var matchControl = new Helper.DTO.MatchControlDto();
            foreach(var matchPredict in coupon.MatchPredicts)
            {
               
                var client = new RestClient("http://bet-app-lb:2425");
                //var client = new RestClient("http://localhost:2425");
                var request = new RestRequest("fixtures/match-control");
                request.AddParameter("matchId", matchPredict.MatchId);
                var response = await client.GetAsync(request).ConfigureAwait(false);
                if (response.IsSuccessful is false)
                {
                    Console.WriteLine("istek başarısız oldu");
                    continue;
                }
                var singleMatch = JsonConvert.DeserializeObject<MatchControlDto>(response.Content);
                if (singleMatch.IsContinue)
                    continue;
                if(singleMatch.Result != matchPredict.Prediction)
                {
                    matchPredict.IsActive = false;
                    matchPredict.Result = false;
                    break;
                }
                matchPredict.Result = true;
                matchPredict.IsActive = false;
            }
            foreach(var matchPred in coupon.MatchPredicts)
            {
                if(!matchPred.IsActive && !matchPred.Result)
                {
                    coupon.Result = false;
                    coupon.IsActive = false;
                    break;
                }
            }
            if(coupon.IsActive && coupon.MatchPredicts.Where(q => q.IsActive).ToList().Count == 0 )
            {
                coupon.Result = true;
                coupon.IsActive = false;
            }
            _couponRepository.UpdateCouponAsync(coupon);
            return coupon;
        }
    }
}
