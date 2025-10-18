using DiarioBordo.Models;

namespace DiarioBordo.IServices;

public interface ITripulanteService
{
    public IEnumerable<Tripulante> GetTripulantes();
    public Tripulante GetTripulante(int id);
    public void PostTripulante(Tripulante tripulante);
    public void PutTripulante(int id, Tripulante tripulante);
    public void DeleteTripulante(int id);
}
