using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Core.DTOs
{
    public class PatientTestDTO
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public string Dna { get; set; }
        public string Dnarepresentation { get; set; }
    }
}
