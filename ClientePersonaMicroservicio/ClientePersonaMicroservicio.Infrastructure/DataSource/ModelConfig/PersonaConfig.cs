using ClientePersonaMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientePersonaMicroservicio.Infrastructure.DataSource.ModelConfig;

public class PersonaEntityTypeConfiguration : IEntityTypeConfiguration<Persona>
{
    // Si necesitamos db constrains, este es el lugar 
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Personas");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Genero).IsRequired().HasMaxLength(1);
        builder.Property(e => e.Edad).IsRequired();
        builder.Property(e => e.Identificacion).IsRequired().HasMaxLength(20);
        builder.Property(e => e.Direccion).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
    }
}
