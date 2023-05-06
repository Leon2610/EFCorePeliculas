using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        //Este es el metodo del API Fluente, permite configurar las entidades y propiedades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //De esta manera se indica que el identificador es una llave primaria
            modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);

            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);

            modelBuilder.Entity<Pelicula>().Property(prop => prop.Titulo)
                .HasMaxLength(250)
                .IsRequired();

            modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Entity<CineOferta>().Property(prop => prop.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);

            modelBuilder.Entity<PeliculaActor>().HasKey(prop => 
                new { prop.PeliculaId, prop.ActorId });

            modelBuilder.Entity<PeliculaActor>().Property(prop => prop.Personaje)
                .HasMaxLength(150);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<PeliculaActor> PeliculaActores { get; set; }
    }
}
