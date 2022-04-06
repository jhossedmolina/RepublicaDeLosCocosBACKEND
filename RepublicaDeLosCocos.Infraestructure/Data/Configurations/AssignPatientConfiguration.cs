using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class AssignPatientConfiguration : IEntityTypeConfiguration<AssignPatient>
    {
        public void Configure(EntityTypeBuilder<AssignPatient> builder)
        {
            builder.Property(e => e.IdPatientStatus).HasColumnName("idPatientStatus");

            builder.Property(e => e.IdTriage).HasColumnName("idTriage");

            builder.Property(e => e.RegistrationDate).HasColumnType("datetime");

            builder.HasOne(d => d.IdPatientNavigation)
                .WithMany(p => p.AssignPatient)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignPatient_Patient");

            builder.HasOne(d => d.IdPatientStatusNavigation)
                .WithMany(p => p.AssignPatient)
                .HasForeignKey(d => d.IdPatientStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignPatient_PatientStatus");

            builder.HasOne(d => d.IdSurgeryNavigation)
                .WithMany(p => p.AssignPatient)
                .HasForeignKey(d => d.IdSurgery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignPatient_Surgery");

            builder.HasOne(d => d.IdTriageNavigation)
                .WithMany(p => p.AssignPatient)
                .HasForeignKey(d => d.IdTriage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignPatient_Triage");
        }
    }
}
