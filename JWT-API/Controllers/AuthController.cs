using JWT_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWT_API.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : Controller
{
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "admin" && password == "admin")
        {
            var token = TokenGenerator.GenerateToken(new Models.Employee());
            return Ok(token);
        }
        return BadRequest();
    }
}