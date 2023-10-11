using CuentaMovimientosMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuentaMovimientosMicroservicio.Infrastructure.DataSource.ModelConfig;

public class CuentaEntityTypeConfiguration : IEntityTypeConfiguration<Cuenta>
{
    // Si necesitamos db constrains, este es el lugar 
    public void Configure(EntityTypeBuilder<Cuenta> builder)
    {
        builder.ToTable("Cuenta");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();      

        builder.Property(b => b.NumeroCuenta)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.SaldoInicial)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.TipoCuenta)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.Estado)
            .IsRequired();               
    }
}
