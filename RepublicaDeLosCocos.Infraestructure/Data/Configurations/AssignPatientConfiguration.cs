using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class AssignPatientConfiguration : IEntityTypeConfiguration<AssignPatient>
    {
        public void Configure(EntityTypeBuilder<AssignPatient> builder)
        {
            builder.Property(e => e.Diagnostic)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.IdTriage).HasColumnName("idTriage");

            builder.Property(e => e.RegistrationDate).HasColumnType("datetime");

            builder.Property(e => e.VirusTestFile).HasColumnType("text");

            builder.HasOne(d => d.IdPatientNavigation)
                .WithMany(p => p.AssignPatient)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignPatient_Patient");

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
