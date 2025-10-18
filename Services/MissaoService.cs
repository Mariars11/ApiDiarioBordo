// Services/ExampleService.cs
using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.EntityFrameworkCore;

public class MissaoService : IMissaoService
{

    private readonly AppDbContext _context;
    public MissaoService(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Missao> GetMissoes()
    {
        var missoes = _context.Missoes.ToList();

        return missoes;
    }

    public Missao GetMissao(int id)
    {
        var missao = _context.Missoes.FirstOrDefault(n => n.Id == id);

        return missao;
    }

    public void PostMissao(Missao missao)
    {
        if (missao is not null)
        {
            _context.Missoes.Add(missao);
            _context.SaveChanges();
        }
    }

    public void PutMissao(int id, Missao missao)
    {
        _context.Entry(missao).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public void DeleteMissao(int id)
    {
        var missao = _context.Missoes.FirstOrDefault(n => n.Id == id);

        _context.Missoes.Remove(missao);
        _context.SaveChanges();

    }
}
