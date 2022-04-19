using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class Triage
    {
        public Triage()
        {
            AssignPatient = new HashSet<AssignPatient>();
            Patient = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public int TriageCode { get; set; }
        public string TriageName { get; set; }

        public virtual ICollection<AssignPatient> AssignPatient { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
