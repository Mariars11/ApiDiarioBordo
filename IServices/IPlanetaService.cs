using DiarioBordo.Models;

namespace DiarioBordo.IServices;

public interface IPlanetaService
{
    public IEnumerable<Planeta> GetPlanetas();
    public Planeta GetPlaneta(int id);
    public void PostPlaneta(Planeta planeta);
    public void PutPlaneta(int id, Planeta planeta);
    public void DeletePlaneta(int id);
}
