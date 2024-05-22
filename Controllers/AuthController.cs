using Microsoft.AspNetCore.Mvc;
using Project1.Helpers;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _secretKey = "this_is_a_very_long_secret_key_1234567890";
        private readonly string _issuer = "yourissuer";
        private readonly string _audience = "youraudience";

        [HttpPost("Login/Admin")]
        public IActionResult LoginAdmin()
        {
            var token = JwtHelper.GenerateJwtToken("admin", "admin", _secretKey, _issuer, _audience);
            return Ok(new { token });
        }

        [HttpPost("Login/User")]
        public IActionResult LoginUser()
        {
            var token = JwtHelper.GenerateJwtToken("user", "user", _secretKey, _issuer, _audience);
            return Ok(new { token });
        }
    }
}
