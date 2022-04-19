using System.Collections.Generic;

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class PatientStatus
    {
        public PatientStatus()
        {
            Patient = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
