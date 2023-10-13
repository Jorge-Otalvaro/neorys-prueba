using ClientePersonaMicroservicio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClientePersonaMicroservicio.Infrastructure.DataSource;

public class DataContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

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
        modelBuilder.Entity<Persona>(
            entity =>
            {
                entity.ToTable("Personas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Genero).IsRequired().HasMaxLength(1);
                entity.Property(e => e.Edad).IsRequired();
                entity.Property(e => e.Identificacion).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);                
            });

        modelBuilder.Entity<Cliente>(
            entity =>
            {
                entity.ToTable("Clientes");                        
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Estado).IsRequired();                
            });
                
        base.OnModelCreating(modelBuilder);
    }
}