using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioDeBordo.Migrations
{
    /// <inheritdoc />
    public partial class CargaPlaneta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"Insert into Planetas(Nome) Values ('Terra')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Mercúrio')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Vênus')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Júpiter')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Saturno')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Urano')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Netuno')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Plutão')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Sol')");
            mb.Sql(@"Insert into Planetas(Nome) Values ('Lua')");       
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(@"Delete from Planetas");
        }
    }
}
