using RepublicaDeLosCocos.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Core.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public int IdTriage { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Symptom { get; set; }
        public DateTime? CheckIn { get; set; }
    }
}
