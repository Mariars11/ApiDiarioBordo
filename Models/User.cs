namespace DiarioBordo.Models;
public class User
{
    public int Id { get; set; }
    public string Usuario { get; set; }
    public string SenhaHash { get; set; }
    public string Role { get; set; }

}