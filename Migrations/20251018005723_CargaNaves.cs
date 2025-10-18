using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioBordo.Migrations
{
    /// <inheritdoc />
    public partial class CargaNaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Andrômeda', 'A-11')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Falcão Estelar', 'F-22X')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Nebulosa', 'NB-07')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Orion', 'OR-5')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Valquíria', 'VX-300')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Titã Negra', 'TN-9')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Luz Fantasma', 'LF-01')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Vento Solar', 'VS-400')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Sentinela', 'STL-2')");
            mb.Sql(@"Insert into Naves(Nome, Modelo) Values ('Pegasus', 'PG-88')");
      
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(@"Delete from Naves");
        }
    }
}
