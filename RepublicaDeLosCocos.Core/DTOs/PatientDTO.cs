using System;

namespace RepublicaDeLosCocos.Core.DTOs
{
    public class PatientDTO
    {
        public int IdentificationNumber { get; set; }
        public int IdTriage { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Symptom { get; set; }
        public DateTime? CheckIn { get; set; }
    }
}
