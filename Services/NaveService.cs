// Services/ExampleService.cs
using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.EntityFrameworkCore;

public class NaveService : INaveService
{

    private readonly AppDbContext _context;
    public NaveService(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Nave> GetNaves()
    {
        var naves = _context.Naves.Include(n => n.Tripulantes).ToList();

        return naves;
    }

    public Nave GetNave(int id)
    {
        var nave = _context.Naves.FirstOrDefault(n => n.Id == id);

        return nave;
    }

    public void PostNave(Nave nave)
    {
        if (nave is not null)
        {
            _context.Naves.Add(nave);
            _context.SaveChanges();
        }
    }

    public void PutNave(int id, Nave nave)
    {
        _context.Entry(nave).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public void DeleteNave(int id)
    {
        var nave = _context.Naves.FirstOrDefault(n => n.Id == id);

        _context.Naves.Remove(nave);
        _context.SaveChanges();

    }
}
