using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureDataController : ControllerBase
    {
        [Authorize]
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("This is a secret message only for authorized users!   ie, Deepak Tonupunuri");
        }
    }
}