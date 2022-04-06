using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class AssignPatient
    {
        public int Id { get; set; }
        public int IdSurgery { get; set; }
        public int IdPatient { get; set; }
        public int IdTriage { get; set; }
        public int IdPatientStatus { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Patient IdPatientNavigation { get; set; }
        public virtual PatientStatus IdPatientStatusNavigation { get; set; }
        public virtual Surgery IdSurgeryNavigation { get; set; }
        public virtual Triage IdTriageNavigation { get; set; }
    }
}
