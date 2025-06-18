using Microsoft.EntityFrameworkCore;
using TelemarketingPerformance.Domain.Entities;

namespace TelemarketingPerformance.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Indicador> Indicadores { get; set; }
    public DbSet<Coleta> Coletas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Indicador>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired();
            entity.Property(e => e.TipoDeCalculo).IsRequired();
        });

        modelBuilder.Entity<Coleta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Data).IsRequired();
            entity.Property(e => e.Valor).HasPrecision(18, 2).IsRequired();

            entity.HasOne(e => e.Indicador)
                .WithMany(i => i.Coletas)
                .HasForeignKey(e => e.IndicadorId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
} 