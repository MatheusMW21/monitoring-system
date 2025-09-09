using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Domain.Enums;
using MonitoringSystem.Shared.Notifications;    

namespace MonitoringSystem.Data
{
    public class MonitoringDbContext : DbContext
    {
        public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options) 
            : base(options)
        {
        }

        // ----------------------
        // DbSets (tabelas)
        // ----------------------
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        // ----------------------
        // Configuração das entidades
        // ----------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela Metric
            modelBuilder.Entity<Metric>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Source)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(m => m.MetricType)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(m => m.Value)
                      .IsRequired();
                entity.Property(m => m.Timestamp)
                      .IsRequired();
            });

            // Configuração da tabela Alert
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.AlertType)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(a => a.Threshold)
                      .IsRequired();
                entity.Property(a => a.Timestamp)
                      .IsRequired();
                entity.Property(a => a.Status)
                      .IsRequired();

                // Relacionamento com Metric
                entity.HasOne<Metric>()
                      .WithMany()
                      .HasForeignKey(a => a.MetricId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
