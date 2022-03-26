using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            AssignPatient = new HashSet<AssignPatient>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Triage { get; set; }
        public string Symptom { get; set; }
        public DateTime CheckIn { get; set; }
        public string PatientStatus { get; set; }
        public string AssignedStatus { get; set; }

        public virtual ICollection<AssignPatient> AssignPatient { get; set; }
    }
}
