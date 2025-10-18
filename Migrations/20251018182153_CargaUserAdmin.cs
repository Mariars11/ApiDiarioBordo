using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioDeBordo.Migrations
{
    /// <inheritdoc />
    public partial class CargaUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"INSERT INTO Users (Usuario, SenhaHash, Role) VALUES ('admin', 'AQAAAAIAAYagAAAAENamY3jNZXcdDcCXLI0viogjnmLArgMYCi5T2dLOndz50qCQ9297anz69ZVzvVVcZw==', 'Admin')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(@"Delete from Users");
        }
    }
}
