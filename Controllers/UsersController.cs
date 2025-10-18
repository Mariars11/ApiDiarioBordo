using DiarioBordo.Filters;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiarioBordo.Controlles;

[Route("v1/api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiLoggingFilter))]
[TypeFilter(typeof(CustomExceptionFilter))]
public class UsersController : ControllerBase
{
    private readonly IUsuarioService _userService;
    public UsersController(IUsuarioService userService)
    {
        _userService = userService;
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var Users = _userService.GetUsers();

        if (Users is null)
        {
            return NotFound("Não há usuários cadastrados na base de dados");
        }
        

        return Ok(Users);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("{id:int:min(1)}", Name = "ObterUser")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _userService.GetUser(id);

        if (user is null)
        {
            return NotFound($"Não há usuário com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(user);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("senha", Name="ValidarSenha")]
    public IActionResult GetValidaSenha(User user, string senha)
    {
        bool isValida = _userService.ValidateSenha(user, senha);

        if (!isValida)
        {
            return BadRequest("Senha inválida");
        }

        return Ok("Senha válida");
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult PostUser(string username, string password, string role)
    {
        if (username is null || password is null || role is null)
        {
            return BadRequest();
        }

        var user = _userService.PostUser(username, password, role);

        return new CreatedAtRouteResult("ObterNave", new { id = user.Id }, user);
    }

    
}