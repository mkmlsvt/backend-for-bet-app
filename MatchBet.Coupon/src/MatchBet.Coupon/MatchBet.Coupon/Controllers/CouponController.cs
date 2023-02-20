using MatchBet.Coupon.Services.CouponService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MatchBet.Coupon.Controllers
{
    [Route("coupons")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "Create Coupon Succesfully", typeof(Models.Coupon))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "BadRequest.", typeof(BadRequest))]
        public async Task<IActionResult> CreateCoupon([FromBody] Helper.Contarct.CreateCouponRequest request)
        {
            await _couponService.CreateCouponAsync(request);
            return Ok(request);
        }


        [Route("refreshAndUpdateCoupons")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Returns player by username.", typeof(List<Models.Coupon>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Returns user notfount.", typeof(NotFoundResult))]
        public async Task<IActionResult> RefreshAndUpdateCoupons(int userId)
        {
            var couponList = await _couponService.RefreshCouponsByUserId(userId);
            return Ok(couponList);
        }
    }
}
