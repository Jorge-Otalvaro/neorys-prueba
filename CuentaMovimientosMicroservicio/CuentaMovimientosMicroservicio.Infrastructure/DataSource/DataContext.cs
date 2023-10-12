using CuentaMovimientosMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CuentaMovimientosMicroservicio.Infrastructure.DataSource;

public class DataContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }
    public DbSet<Persona> Personas { get; set; }

    public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            return;
        }      

        // load all entity config from current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        // if using schema in db, uncomment the following line
        // modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));        
        modelBuilder.Entity<Cuenta>(
            entity =>
            {
                entity.ToTable("Cuentas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NumeroCuenta).IsRequired();                
                entity.Property(e => e.TipoCuenta).IsRequired();                
                entity.Property(e => e.Estado).IsRequired();                
            });

        modelBuilder.Entity<Movimiento>(
            entity =>
            {
                entity.ToTable("Movimientos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();                               
                entity.Property(e => e.TipoMovimiento).IsRequired();                
                entity.Property(e => e.Valor).IsRequired();                
                entity.Property(e => e.Fecha).IsRequired();                
            });

        modelBuilder.Entity<Persona>();

        base.OnModelCreating(modelBuilder);
    }
}

