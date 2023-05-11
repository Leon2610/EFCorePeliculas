using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    /// <inheritdoc />
    public partial class FotoActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoURL",
                table: "Actores",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 6,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 7,
                column: "FotoURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 8,
                column: "FotoURL",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoURL",
                table: "Actores");
        }
    }
}
