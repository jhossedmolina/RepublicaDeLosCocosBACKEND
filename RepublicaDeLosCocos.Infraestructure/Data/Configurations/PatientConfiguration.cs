using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(e => e.CheckIn).HasColumnType("datetime");

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Symptom)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPatientStatusNavigation)
                .WithMany(p => p.Patient)
                .HasForeignKey(d => d.IdPatientStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_PatientStatus");

            builder.HasOne(d => d.IdTriageNavigation)
                .WithMany(p => p.Patient)
                .HasForeignKey(d => d.IdTriage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Triage");
        }
    }
}
