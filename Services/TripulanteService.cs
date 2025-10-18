// Services/ExampleService.cs
using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.EntityFrameworkCore;

public class TripulanteService : ITripulanteService
{

    private readonly AppDbContext _context;
    public TripulanteService(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Tripulante> GetTripulantes()
    {
        var tripulantes = _context.Tripulantes.ToList();

        return tripulantes;
    }

    public Tripulante GetTripulante(int id)
    {
        var tripulante = _context.Tripulantes.FirstOrDefault(n => n.Id == id);

        return tripulante;
    }

    public void PostTripulante(Tripulante tripulante)
    {
        if (tripulante is not null)
        {
            _context.Tripulantes.Add(tripulante);
            _context.SaveChanges();
        }
    }

    public void PutTripulante(int id, Tripulante tripulante)
    {
        _context.Entry(tripulante).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public void DeleteTripulante(int id)
    {
        var tripulante = _context.Tripulantes.FirstOrDefault(n => n.Id == id);

        _context.Tripulantes.Remove(tripulante);
        _context.SaveChanges();

    }
}
