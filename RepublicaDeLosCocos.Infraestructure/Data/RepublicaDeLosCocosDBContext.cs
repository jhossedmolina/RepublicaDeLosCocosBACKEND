using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RepublicaDeLosCocos.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepublicaDeLosCocos.Infraestructure.Data
{
    public partial class RepublicaDeLosCocosDBContext : DbContext
    {
        public RepublicaDeLosCocosDBContext()
        {
        }

        public RepublicaDeLosCocosDBContext(DbContextOptions<RepublicaDeLosCocosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignPatient> AssignPatient { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Surgery> Surgery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignPatient>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssignedStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.AssignPatient)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignPatient_Patient");

                entity.HasOne(d => d.IdSurgeryNavigation)
                    .WithMany(p => p.AssignPatient)
                    .HasForeignKey(d => d.IdSurgery)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignPatient_Surgery");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssignedStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Symptom)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Triage)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Surgery>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameDoctor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurgeryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurgeryStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
