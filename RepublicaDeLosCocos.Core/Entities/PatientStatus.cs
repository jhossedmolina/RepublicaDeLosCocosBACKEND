using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class PatientStatus
    {
        public PatientStatus()
        {
            Patient = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
