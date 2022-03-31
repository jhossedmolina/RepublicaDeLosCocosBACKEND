using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    class PatientStatusConfiguration : IEntityTypeConfiguration<PatientStatus>
    {
        public void Configure(EntityTypeBuilder<PatientStatus> builder)
        {
            builder.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
