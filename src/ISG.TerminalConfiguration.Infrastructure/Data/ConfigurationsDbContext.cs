using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Infrastructure.DTO;
using ISG.TerminalConfiguration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.Data
{
    public class ConfigurationsDbContext : DbContext
    {
        public ConfigurationsDbContext(DbContextOptions<ConfigurationsDbContext> options) : base(options)
        {
        }

        public DbSet<TerminalConfigurationDTO> TerminalConfigurations { get; set; }
        public DbSet<TerminalSecurityDTO> TerminalSecurities { get; set; }
        public DbSet<KioskDTO> kiosks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TerminalConfigurationDTO>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasConversion(
                          v => v.ToString(),
                         v => Guid.Parse(v)
                    );
                entity.Property(e => e.TerminalId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IpAddress).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Port)
                         .HasConversion(
                             v => v.ToString(),
                             v => int.Parse(v)
                         )
                         .HasMaxLength(10);
                entity.Property(e => e.Enabled)
                      .HasColumnType("bit") // Explicitly map to SQL Server bit type
                      .HasConversion(
                          v => v,       // No conversion needed when writing to DB
                          v => v        // No conversion needed when reading from DB
                      );
                entity.Property(e => e.clientID).IsRequired().HasMaxLength(50);
                entity.Property(e => e.KioskID).IsRequired().HasMaxLength(50);

                // One-to-one relationship with TerminalSecurity
                entity.HasOne(e => e.Security)
                      .WithOne(s => s.Configuration)
                      .HasForeignKey<TerminalSecurityDTO>(s => s.TerminalId)
                      .HasPrincipalKey<TerminalConfigurationDTO>(c => c.Id);
            });

            modelBuilder.Entity<TerminalSecurityDTO>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                        .HasColumnName("Id")
                        .HasConversion(
                            v => v.ToString(),
                            v => Guid.Parse(v)
                        )
                        .HasMaxLength(50);
                entity.Property(e => e.token).IsRequired();
                entity.Property(e => e.TerminalId).
                        HasConversion(
                          v => v.ToString(),  // Convert Guid to string when saving
                          v => Guid.Parse(v)  // Convert string to Guid when reading
              ).IsRequired().HasMaxLength(50);
                entity.Property(e => e.expirationDate).IsRequired();

                // Index for faster lookups by TerminalId
                entity.HasIndex(e => e.TerminalId).IsUnique();
            });

            modelBuilder.Entity<KioskDTO>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasConversion(
                          v => v.ToString(),
                          v => Guid.Parse(v)
                    );
                entity.Property(e => e.ClientID).HasConversion(
                          v => v.ToString(),
                          v => Guid.Parse(v)
                    ).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(255);
            });
        }
    }
}
