using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.AspNetCore.Identity;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher = new();
    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetUsers()
    {
        var users = _context.Users.ToList();
        return users;
    }

    public User GetUser(int id)
    {
        var users = _context.Users.FirstOrDefault(n => n.Id == id);

        return users;
    }

    public User PostUser(string username, string password, string role)
    {
        var user = new User()
        {
            Usuario = username,
            Role = role
        };

        user.SenhaHash = GerarSenhaHash(user, password);

        if (user is not null)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        return user;
    }

    public bool ValidateSenha(User user, string senha)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.SenhaHash, senha);
        return result == PasswordVerificationResult.Success;
    }
    
    public string GerarSenhaHash(User user, string password)
    {
        var senhaHash = _passwordHasher.HashPassword(user, password);

        return senhaHash;
    }
}