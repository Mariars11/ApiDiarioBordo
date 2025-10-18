using DiarioBordo.Models;

namespace DiarioBordo.IServices;

public interface IMissaoService
{
    public IEnumerable<Missao> GetMissoes();
    public Missao GetMissao(int id);
    public void PostMissao(Missao missao);
    public void PutMissao(int id, Missao missao);
    public void DeleteMissao(int id);
}
