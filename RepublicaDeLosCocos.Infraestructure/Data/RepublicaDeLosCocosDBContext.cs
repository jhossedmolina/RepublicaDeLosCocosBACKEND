using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Infraestructure.Data.Configurations;

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
        public virtual DbSet<PatientStatus> PatientStatus { get; set; }
        public virtual DbSet<Surgery> Surgery { get; set; }
        public virtual DbSet<SurgeryStatus> SurgeryStatus { get; set; }
        public virtual DbSet<Triage> Triage { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssignPatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new SurgeryConfiguration());
            modelBuilder.ApplyConfiguration(new PatientStatusConfiguration());
            modelBuilder.ApplyConfiguration(new SurgeryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TriageConfiguration());
        }
    }
}
