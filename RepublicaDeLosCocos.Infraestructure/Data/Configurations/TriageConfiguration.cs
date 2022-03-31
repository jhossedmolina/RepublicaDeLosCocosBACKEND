using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicaDeLosCocos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Infraestructure.Data.Configurations
{
    public class TriageConfiguration : IEntityTypeConfiguration<Triage>
    {
        public void Configure(EntityTypeBuilder<Triage> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.TriageName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.TriagePriority)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
