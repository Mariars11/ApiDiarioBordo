using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioBordo.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoTripulanteNave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Naves_NaveId",
                table: "Tripulantes");

            migrationBuilder.AlterColumn<int>(
                name: "NaveId",
                table: "Tripulantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Naves_NaveId",
                table: "Tripulantes",
                column: "NaveId",
                principalTable: "Naves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Naves_NaveId",
                table: "Tripulantes");

            migrationBuilder.AlterColumn<int>(
                name: "NaveId",
                table: "Tripulantes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Naves_NaveId",
                table: "Tripulantes",
                column: "NaveId",
                principalTable: "Naves",
                principalColumn: "Id");
        }
    }
}
