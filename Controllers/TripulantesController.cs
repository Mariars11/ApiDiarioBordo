using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiarioBordo.Controlles;

[Route("[controller]")]
[ApiController]
public class TripulantesController : ControllerBase
{
    private readonly ITripulanteService _tripulanteService;
    public TripulantesController(ITripulanteService tripulanteService)
    {
        _tripulanteService = tripulanteService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Tripulante>> GetTripulantes()
    {
        var tripulantes = _tripulanteService.GetTripulantes();

        if (tripulantes is null)
        {
            return NotFound("Não há Tripulantes cadastrados na base de dados");
        }

        return Ok(tripulantes);
    }

    [HttpGet("{id:int}", Name="ObterTripulante")]
    public ActionResult<Tripulante> GetTripulante(int id)
    {
        var tripulante = _tripulanteService.GetTripulante(id);

        if (tripulante is null)
        {
            return NotFound($"Não há tripulante com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(tripulante);
    }

    [HttpPost]
    public ActionResult PostTripulante(Tripulante tripulante)
    {
        if (tripulante is null)
        {
            return BadRequest();
        }

        _tripulanteService.PostTripulante(tripulante);

        return new CreatedAtRouteResult("ObterTripulante", new { id = tripulante.Id }, tripulante);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutTripulante(int id, Tripulante tripulante)
    {
        if (id != tripulante.Id)
        {
            return BadRequest($"Id \"{id}\" não corresponde à missão informada!");
        }

        _tripulanteService.PutTripulante(id, tripulante);

        return Ok(tripulante);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult DeleteTripulante(int id)
    {
        var tripulante = _tripulanteService.GetTripulante(id);
        if (tripulante is null)
        {
            return NotFound($"Tripulante de id \"{id}\" não encontrada!");
        }
        
        _tripulanteService.DeleteTripulante(id);
        
        return Ok("Missão excluída com sucesso");
    }
}