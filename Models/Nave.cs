using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DiarioBordo.Models;

public class Nave
{
    public Nave()
    {
        Tripulantes = new Collection<Tripulante>();
        Missoes = new Collection<Missao>();
    }
    
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Nome { get; set; }
    public ICollection<Tripulante>? Tripulantes { get; set; }
    [JsonIgnore]
    public ICollection<Missao>? Missoes { get; set; }
}
