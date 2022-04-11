

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class PatientTestConfiguration : IEntityTypeConfiguration<PatientTest>
    {
        public void Configure(EntityTypeBuilder<PatientTest> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.CompletionDate).HasColumnType("datetime");

            builder.Property(e => e.Dna)
                        .IsRequired()
                        .HasColumnName("DNA")
                        .HasMaxLength(50)
                        .IsUnicode(false);

            builder.Property(e => e.Dnarepresentation)
                        .IsRequired()
                        .HasColumnName("DNARepresentation")
                        .HasMaxLength(50)
                        .IsUnicode(false);

            builder.HasOne(d => d.IdPatientNavigation)
                        .WithMany(p => p.PatientTest)
                        .HasForeignKey(d => d.IdPatient)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PatientTest_Patient");
        }
    }
}
