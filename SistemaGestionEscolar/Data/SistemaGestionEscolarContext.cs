using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaGestionEscolar.Data
{
    public partial class SistemaGestionEscolarContext : DbContext
    {
        public SistemaGestionEscolarContext()
        {
        }

        public SistemaGestionEscolarContext(DbContextOptions<SistemaGestionEscolarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserStudent> UserStudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStudent>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__UserStud__B5007C246723F8A9");

                entity.Property(e => e.Estudiante)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Materia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salon)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
