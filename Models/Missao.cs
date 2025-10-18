using System.Text.Json.Serialization;

namespace DiarioBordo.Models;

public class Missao
{

    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string NomeMissao { get; set; }
    public int NumeroMissao { get; set; }
    public string Descricao { get; set; }
    public int NaveId { get; set; }
    public int PlanetaId { get; set; }
    [JsonIgnore]
    public Planeta? PlanetaNavigation { get; set; }
    [JsonIgnore]
    public Nave? NaveNavigation { get; set; }

}
