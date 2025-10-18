using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiarioBordo.Controlles;

[Route("[controller]")]
[ApiController]
public class PlanetasController : ControllerBase
{
    private readonly IPlanetaService _planetaService;
    public PlanetasController(IPlanetaService planetaService)
    {
        _planetaService = planetaService;
    }
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

    [HttpGet("{id:int}", Name="ObterPlaneta")]
    public ActionResult<Planeta> GetPlaneta(int id)
    {
        var planeta = _planetaService.GetPlaneta(id);

        if (planeta is null)
        {
            return NotFound($"Não há planeta com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(planeta);
    }

    [HttpPost]
    public ActionResult PostPlaneta(Planeta planeta)
    {
        if (planeta is null)
        {
            return BadRequest();
        }

        _planetaService.PostPlaneta(planeta);

        return new CreatedAtRouteResult("ObterPlaneta", new { id = planeta.Id }, planeta);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutPlaneta(int id, Planeta planeta)
    {
        if (id != planeta.Id)
        {
            return BadRequest($"Id \"{id}\" não corresponde à missão informada!");
        }

        _planetaService.PutPlaneta(id, planeta);

        return Ok(planeta);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult DeletePlaneta(int id)
    {
        var planeta = _planetaService.GetPlaneta(id);
        if (planeta is null)
        {
            return NotFound($"Missão de id \"{id}\" não encontrada!");
        }
        
        _planetaService.DeletePlaneta(id);
        
        return Ok("Missão excluída com sucesso");
    }
}