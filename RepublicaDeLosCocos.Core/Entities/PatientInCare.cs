using System;

namespace RepublicaDeLosCocos.Core.Entities
{
    public class PatientInCare : AssignPatient
    {
        public int IdentificationNumber { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Symptom { get; set; }
        public string SurgeryName { get; set; }
        public string NameDoctor { get; set; }
    }
}
