using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DiarioBordo.Context;
using DiarioBordo.IServices;
using DiarioBordo.Models;
using Microsoft.IdentityModel.Tokens;

namespace DiarioBordo.Services;
public class JwtService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioService _usuarioService;
    private readonly AppDbContext _context;
    public JwtService(IConfiguration configuration, IUsuarioService usuarioService, AppDbContext context)
    {
        _configuration = configuration;
        _usuarioService = usuarioService;
        _context = context;
    }

    public string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Usuario),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:ExpiresInMinutes"]!)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public User? ValidateUser(string username, string password)
    {

        var user = _context.Users.FirstOrDefault(u => u.Usuario == username);

        var userValido = _usuarioService.ValidateSenha(user, password);

        if (!userValido)
        {
            return null;
        }
        
        return user;
    }
}
