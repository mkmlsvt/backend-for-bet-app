using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mini1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Deneme()
        {
            var username = HttpContext.User.Identity.Name;
            var userIdClaim = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.NameIdentifier);

            return Ok(new { username, userIdClaim.Value });
        }
    }
}
