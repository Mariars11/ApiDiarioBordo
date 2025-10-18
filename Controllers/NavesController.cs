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
public class NavesController : ControllerBase
{
    private readonly INaveService _naveService;
    public NavesController(INaveService naveService)
    {
        _naveService = naveService;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Nave>> GetNaves()
    {
        var naves = _naveService.GetNaves();

        if (naves is null)
        {
            return NotFound("Não há naves cadastradas na base de dados");
        }

        return Ok(naves);
    }
    [Authorize]
    [HttpGet("{id:int:min(1)}", Name = "ObterNave")]
    public ActionResult<Nave> GetNave(int id)
    {
        var nave = _naveService.GetNave(id);

        if (nave is null)
        {
            return NotFound($"Não há nave com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(nave);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult PostNave(Nave nave)
    {
        if (nave is null)
        {
            return BadRequest();
        }

        _naveService.PostNave(nave);

        return new CreatedAtRouteResult("ObterNave", new { id = nave.Id }, nave);
    }

    [Authorize(Roles = "BackOffice")]
    [HttpPut("{id:int:min(1)}")]
    public IActionResult PutNave(int id, Nave nave)
    {
        if (id != nave.Id)
        {
            return BadRequest($"Id \"{id}\" não corresponde à nave informada!");
        }

        _naveService.PutNave(id, nave);

        return Ok(nave);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult DeleteNave(int id)
    {
        var nave = _naveService.GetNave(id);
        if (nave is null)
        {
            return NotFound($"Nave de id \"{id}\" não encontrada!");
        }
        
        _naveService.DeleteNave(id);
        
        return Ok("Nave excluída com sucesso");
    }
}