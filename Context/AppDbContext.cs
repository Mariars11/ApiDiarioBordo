using DiarioBordo.Models;
using Microsoft.EntityFrameworkCore;
namespace DiarioBordo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Missao> Missoes { get; set; }
    public DbSet<Nave> Naves {get; set;}
    public DbSet<Planeta> Planetas {get; set;}
    public DbSet<Tripulante> Tripulantes {get; set;}
    
}