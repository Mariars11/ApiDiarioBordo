using DiarioBordo.Models;
using DiarioBordo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiarioBordo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly JwtService _jwtService;

    public LoginController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _jwtService.ValidateUser(username, password);

        if(user is null)
        {
            return Unauthorized("Credenciais inválidas");
        }

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }
}
