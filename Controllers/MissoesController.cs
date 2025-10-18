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
public class MissoesController : ControllerBase
{
    private readonly IMissaoService _missaoService;
    public MissoesController(IMissaoService missaoService)
    {
        _missaoService = missaoService;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Missao>> GetMissoes()
    {
        var missoes = _missaoService.GetMissoes();

        if (missoes is null)
        {
            return NotFound("Não há missões cadastradas na base de dados");
        }

        return Ok(missoes);
    }
    
    [Authorize]
    [HttpGet("{id:int:min(1)}", Name = "ObterMissao")]
    public ActionResult<Missao> GetMissao(int id)
    {
        var missao = _missaoService.GetMissao(id);

        if (missao is null)
        {
            //return NotFound($"Não há missão com id \"{id}\" cadastrado na base de dados");
            return NotFound();
        }

        return Ok(missao);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ActionResult PostMissao(Missao missao)
    {
        if (missao is null)
        {
            return BadRequest();
        }

        _missaoService.PostMissao(missao);

        return new CreatedAtRouteResult("ObterMissao", new { id = missao.Id }, missao);
    }

    [Authorize(Roles = "Admin, BackOffice")]
    [HttpPut("{id:int:min(1)}")]
    public ActionResult PutMissao(int id, Missao missao)
    {
        if (id != missao.Id)
        {
            return BadRequest($"Id \"{id}\" não corresponde à missão informada!");
        }

        _missaoService.PutMissao(id, missao);

        return Ok(missao);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int:min(1)}")]
    public ActionResult DeleteMissao(int id)
    {
        var missao = _missaoService.GetMissao(id);
        if (missao is null)
        {
            return NotFound($"Missão de id \"{id}\" não encontrada!");
        }

        _missaoService.DeleteMissao(id);

        return Ok("Missão excluída com sucesso");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("erro500")]
    public IActionResult TesteErro500()
    {
        throw new Exception("Erro de teste!");
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("erro400")]
    public IActionResult TesteErro400()
    {
        throw new ArgumentException("Parâmetro inválido");
    }
}