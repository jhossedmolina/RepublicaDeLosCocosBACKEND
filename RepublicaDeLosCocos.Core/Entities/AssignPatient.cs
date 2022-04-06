﻿using System;

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
