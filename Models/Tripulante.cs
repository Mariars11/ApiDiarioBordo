using System.Text.Json.Serialization;

namespace DiarioBordo.Models;

public class Tripulante
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }

    public int NaveId { get; set; }
    [JsonIgnore]
    public Nave? NaveNavigation { get; set; }
}
