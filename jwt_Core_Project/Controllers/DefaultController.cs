using jwt_Core_Project.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_Core_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("action")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }

        [Authorize]
        [HttpGet("action")]
        public IActionResult Page1()
        {
            return Ok("Sayfa 1 İçin Girişiniz Başarılı");
        }
    }
}
