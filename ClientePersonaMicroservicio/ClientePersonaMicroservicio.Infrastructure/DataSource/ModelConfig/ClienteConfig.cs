using ClientePersonaMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientePersonaMicroservicio.Infrastructure.DataSource.ModelConfig;

public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    // Si necesitamos db constrains, este es el lugar 
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");                    
        builder.Property(e => e.Contrasena).IsRequired().HasMaxLength(20);
        builder.Property(e => e.Estado).IsRequired();
    }
}

