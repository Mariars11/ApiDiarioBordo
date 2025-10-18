using DiarioBordo.Context;
using DiarioBordo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiarioBordo.Controlles;

[Route("[controller]")]
[ApiController]
public class MissoesController : ControllerBase
{
    private readonly AppDbContext _context;
    public MissoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Missao>> GetMissoes()
    {
        var missoes = _context.Missoes.ToList();

        if (missoes is null)
        {
            return NotFound("Não há missões cadastradas na base de dados");
        }

        return Ok(missoes);
    }

    [HttpGet("{id:int}", Name="ObterMissao")]
    public ActionResult<Missao> GetMissao(int id)
    {
        var missao = _context.Missoes.FirstOrDefault(n => n.Id == id);

        if (missao is null)
        {
            return NotFound($"Não há missão com id \"{id}\" cadastrado na base de dados");
        }

        return Ok(missao);
    }

    [HttpPost]
    public ActionResult PostMissao(Missao missao)
    {
        if(missao is null)
        {
            return BadRequest();
        }
        _context.Missoes.Add(missao);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterMissao", new { id = missao.Id }, missao);
    }
}