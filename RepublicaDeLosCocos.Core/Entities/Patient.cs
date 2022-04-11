using System;
using System.Collections.Generic;

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            AssignPatient = new HashSet<AssignPatient>();
            PatientTest = new HashSet<PatientTest>();
        }

        public int Id { get; set; }
        public int IdTriage { get; set; }
        public int IdPatientStatus { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Symptom { get; set; }
        public DateTime? CheckIn { get; set; }

        public virtual PatientStatus IdPatientStatusNavigation { get; set; }
        public virtual Triage IdTriageNavigation { get; set; }
        public virtual ICollection<AssignPatient> AssignPatient { get; set; }
        public virtual ICollection<PatientTest> PatientTest { get; set; }
    }
}
