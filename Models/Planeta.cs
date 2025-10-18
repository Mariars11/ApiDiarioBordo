using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DiarioBordo.Models;

public class Planeta
{
    public Planeta()
    {
        Missoes = new Collection<Missao>();
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    [JsonIgnore]
    public ICollection<Missao>? Missoes { get; set; }
}
