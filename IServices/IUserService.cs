using DiarioBordo.Models;

namespace DiarioBordo.IServices;

public interface IUsuarioService
{
    public IEnumerable<User> GetUsers();

    public User GetUser(int id);
    public User PostUser(string username, string password, string role);

    public bool ValidateSenha(User user, string senha);

    public string GerarSenhaHash(User user, string password);
}
