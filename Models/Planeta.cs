using System.Collections.ObjectModel;

namespace DiarioBordo.Models;

public class Planeta
{
    public Planeta()
    {
        Missoes = new Collection<Missao>();
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Missao>? Missoes { get; set; }
}
