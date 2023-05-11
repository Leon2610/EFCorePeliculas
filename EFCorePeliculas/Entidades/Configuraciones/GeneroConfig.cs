using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            //De esta manera se indica que el identificador es una llave primaria
            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasQueryFilter(g => !g.EstaBorrado);

            builder.HasIndex(t => t.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");
        }
    }
}
