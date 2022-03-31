using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class SurgeryStatusConfiguration : IEntityTypeConfiguration<SurgeryStatus>
    {
        public void Configure(EntityTypeBuilder<SurgeryStatus> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
