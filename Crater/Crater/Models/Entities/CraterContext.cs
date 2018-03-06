using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Crater.Models.Entities
{
    public partial class CraterContext : DbContext
    {
        public virtual DbSet<CraterDetails> CraterDetails { get; set; }
        public virtual DbSet<CraterLocation> CraterLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Crater;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CraterDetails>(entity =>
            {
                entity.HasKey(e => e.CraterId);

                entity.ToTable("Crater_Details");

                entity.Property(e => e.CraterId).ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompositionType)
                    .IsRequired()
                    .HasColumnName("Composition_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CraterName)
                    .IsRequired()
                    .HasColumnName("Crater_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Diameter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CraterDetails)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Crater_De__Locat__29572725");
            });

            modelBuilder.Entity<CraterLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("Crater_Location");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });
        }
    }
}
