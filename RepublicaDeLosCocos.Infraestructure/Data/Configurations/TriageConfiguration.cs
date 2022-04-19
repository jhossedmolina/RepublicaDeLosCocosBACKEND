using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class TriageConfiguration : IEntityTypeConfiguration<Triage>
    {
        public void Configure(EntityTypeBuilder<Triage> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.TriageName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
