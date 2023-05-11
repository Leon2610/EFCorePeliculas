using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    /// <inheritdoc />
    public partial class VistaConteoPeliculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE VIEW [dbo].[PeliculasConteos]
AS
Select Id, Titulo,
(Select count(*)
FROM GeneroPelicula
WHERE PeliculasId = Peliculas.Id) as CantidadGeneros,
(Select count(distinct CineId)
FROM PeliculaSalaDeCine
INNER JOIN SalasDeCine
ON SalasDeCine.Id = PeliculaSalaDeCine.SalaDeCinesId
WHERE Peliculas.Id = Peliculas.Id) as CantidadesCines,
(
Select count(*)
FROM PeliculaActores
WHERE PeliculaId = Peliculas.Id) as CantidadActores
FROM Peliculas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[PeliculasConteos]");
        }
    }
}
