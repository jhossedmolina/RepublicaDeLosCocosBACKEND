using System;

namespace RepublicaDeLosCocos.Core.DTOs
{
    public class PatientInCareDTO
    {
        public int IdPatient { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Symptom { get; set; }
        public int IdTriage { get; set; }
        public int IdPatientStatus { get; set; }
        public int IdSurgery { get; set; }
        public string SurgeryName { get; set; }
        public string NameDoctor { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Diagnostic { get; set; }
    }
}
