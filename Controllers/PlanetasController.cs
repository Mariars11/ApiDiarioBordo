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
public class PlanetasController : ControllerBase
{
    private readonly IPlanetaService _planetaService;
    public PlanetasController(IPlanetaService planetaService)
    {
        _planetaService = planetaService;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Planeta>> GetPlanetas()
    {
        var planetas = _planetaService.GetPlanetas();

        if (planetas is null)
        {
            return NotFound("Não há planetas cadastrados na base de dados");
        }

        return Ok(planetas);
    }

    [Authorize]
    [HttpGet("{id:int:min(1)}", Name = "ObterPlaneta")]
    public ActionResult<Planeta> GetPlaneta(int id)
    {
        var planeta = _planetaService.GetPlaneta(id);

        if (planeta is null)
        {
            return NotFound($"Não há planeta com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(planeta);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult PostPlaneta(Planeta planeta)
    {
        if (planeta is null)
        {
            return BadRequest();
        }

        _planetaService.PostPlaneta(planeta);

        return new CreatedAtRouteResult("ObterPlaneta", new { id = planeta.Id }, planeta);
    }

    [Authorize(Roles = "Admin, BackOffice")]
    [HttpPut("{id:int:min(1)}")]
    public IActionResult PutPlaneta(int id, Planeta planeta)
    {
        if (id != planeta.Id)
        {
            return BadRequest($"Id \"{id}\" não corresponde ao planeta informado!");
        }

        _planetaService.PutPlaneta(id, planeta);

        return Ok(planeta);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult DeletePlaneta(int id)
    {
        var planeta = _planetaService.GetPlaneta(id);
        if (planeta is null)
        {
            return NotFound($"Planeta de id \"{id}\" não encontrado!");
        }
        
        _planetaService.DeletePlaneta(id);
        
        return Ok("Planeta excluído com sucesso");
    }
}