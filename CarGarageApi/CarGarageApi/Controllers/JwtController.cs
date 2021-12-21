using CarGarageApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CarGarageApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JwtController: ControllerBase
    {
        [HttpGet]
        public IActionResult Jwt()
        {            
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
