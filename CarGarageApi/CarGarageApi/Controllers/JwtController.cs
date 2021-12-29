using CarGarageApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CarGarageApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JwtController: ControllerBase
    {
        private readonly JwtToken _jwtToken;

        public JwtController(JwtToken jwtToken) =>
            _jwtToken = jwtToken; 

        [HttpGet]
        public IActionResult Jwt()
        {            
            return new ObjectResult(_jwtToken.GenerateJwtToken());
        }
    }
}
