using System.Collections.Generic;

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
        public string TriageName { get; set; }

        public virtual ICollection<AssignPatient> AssignPatient { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
