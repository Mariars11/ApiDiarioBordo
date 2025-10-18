// Services/ExampleService.cs
using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.EntityFrameworkCore;

public class PlanetaService : IPlanetaService
{

    private readonly AppDbContext _context;
    public PlanetaService(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Planeta> GetPlanetas()
    {
        var planetas = _context.Planetas.ToList();

        return planetas;
    }

    public Planeta GetPlaneta(int id)
    {
        var planeta = _context.Planetas.FirstOrDefault(n => n.Id == id);

        return planeta;
    }

    public void PostPlaneta(Planeta planeta)
    {
        if (planeta is not null)
        {
            _context.Planetas.Add(planeta);
            _context.SaveChanges();
        }
    }

    public void PutPlaneta(int id, Planeta planeta)
    {
        _context.Entry(planeta).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public void DeletePlaneta(int id)
    {
        var planeta = _context.Planetas.FirstOrDefault(n => n.Id == id);

        _context.Planetas.Remove(planeta);
        _context.SaveChanges();

    }
}
