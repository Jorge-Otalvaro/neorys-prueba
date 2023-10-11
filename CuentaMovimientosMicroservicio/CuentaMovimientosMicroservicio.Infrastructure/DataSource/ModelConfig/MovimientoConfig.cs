using CuentaMovimientosMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuentaMovimientosMicroservicio.Infrastructure.DataSource.ModelConfig;

public class MovimientoEntityTypeConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> builder)
    {
        builder.ToTable("Movimiento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.TipoMovimiento)
            .HasColumnName("TipoMovimiento")
            .IsRequired();       

        builder.Property(x => x.Fecha)
            .HasColumnName("Fecha")
            .IsRequired();

        builder.Property(x => x.Valor)
            .HasColumnName("Valor")
            .IsRequired();

        builder.Property(x => x.Saldo)
            .HasColumnName("Saldo")
            .IsRequired();

        builder.Property(x => x.NumeroCuenta)
            .HasColumnName("NumeroCuenta")
            .IsRequired();               
    }
}