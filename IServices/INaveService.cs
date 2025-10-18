using DiarioBordo.Models;

namespace DiarioBordo.IServices;

public interface INaveService
{
    public IEnumerable<Nave> GetNaves();
    public Nave GetNave(int id);
    public void PostNave(Nave nave);
    public void PutNave(int id, Nave nave);
    public void DeleteNave(int id);
}
